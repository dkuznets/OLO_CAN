using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Diagnostics;
using TM = System.Timers;
using System.Globalization;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;

namespace OLO_CAN
{
    public partial class Form1 : Form
    {
        #region newRUP
        #region CAN
        private void bt_OpenCAN5_Click(object sender, EventArgs e)
        {
            if (cb_CAN5.SelectedItem.ToString() == "No CAN" || cb_CAN5.Items.Count < 1)
                return;
            if (cb_CAN5.SelectedItem.ToString() == "USB Marathon")
            {
                marCAN = new MCANConverter();
                uniCAN = marCAN as MCANConverter;
            }
            else if (cb_CAN5.SelectedItem.ToString() == "PCI Advantech")
            {
                advCAN = new ACANConverter();
                uniCAN = advCAN as ACANConverter;
            }
            else
            {
                elcCAN = new ECANConverter();
                uniCAN = elcCAN as ECANConverter;
            }

            uniCAN.ErrEvent += new MyDelegate(Err_Handler);
            uniCAN.Progress += new MyDelegate(Progress_Handler);

            uniCAN.Port = 0;
            uniCAN.Speed = 2;
            lb_error_CAN5.Visible = false;
            if (!uniCAN.Open())
            {
                state_Error();
                return;
            }
            state_Ready();
            frame.data = new Byte[8];
            _state = State.OpenedState;
            uniCAN.Recv_Enable();
            richTextBox1.Clear();
        }
        private void bt_CloseCAN5_Click(object sender, EventArgs e)
        {
            if (uniCAN.Is_Open)
            {
                uniCAN.Recv_Disable();
                uniCAN.Close();
            }
            state_NotReady();
            lb_error_CAN5.Visible = false;
            uniCAN.Recv_Disable();
            uniCAN = null;
            //            Timer_GetData3.Enabled = false;
            aktiv = false;
            dataGridView1.Rows.Clear();
        }
        #endregion
        #region Обработка меню
        private void toolStripMenuItem2_Click(object sender, EventArgs e) // скачать файл
        {
            text2rtb("Скачиваю файл " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "...");

            Byte fileindex = Convert.ToByte(dataGridView1.SelectedRows[0].Cells[7].Value);
            UInt32 _addr = 0;
            for (Byte i = 0; i < 4; i++)
            {
                if (fff[i].begin == _addr)
                {
                    fileindex = i;
                    break;
                }
            }

            //            if (fileindex != 0xFF)

            Byte[] buf = new Byte[fff[fileindex].size];
            if (!read_area(fff[fileindex].begin, fff[fileindex].size, ref buf))
            {
                err2rtb("Не удалось скачать файл.");
                return;
            }
            done2rtb("Скачивание завершено.");
            Trace.WriteLine("file read");
            text2rtb("Проверка CRC32...");
            Crc32 crc32 = new Crc32();
            String hash = String.Empty;
            foreach (byte b in crc32.ComputeHash(buf))
                hash += b.ToString("X2");
            Trace.WriteLine(hash);
            Byte[] crc = new Byte[4];
            crc = crc32.ComputeHash(buf);
            Array.Reverse(crc);
            if (BitConverter.ToUInt32(crc, 0) == fff[fileindex].crc32)
            {
                done2rtb("CRC32 OК");
                Trace.WriteLine("CRC32 OK");
            }
            else
            {
                err2rtb("CRC32 failed!!!");
            }

            using (SaveFileDialog fd = new SaveFileDialog())
            {
                fd.Filter = "Файлы (*.bin)|*.bin";
                fd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                fd.FileName = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (fd.ShowDialog() != DialogResult.OK)
                    return;
                using (FileStream fs = new FileStream(fd.FileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buf, 0, buf.Length);
                }
            }
            done2rtb("Файл сохранен.");
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e) // заменить
        {
            if (aktiv)
            {
                Byte filenum = Convert.ToByte(dataGridView1.SelectedRows[0].Cells[7].Value);
                UploadFile uf = new UploadFile();
                uf.mtb_begin.Text = fff[filenum].begin.ToString("X");
                DialogResult re = uf.ShowDialog();
                if (re == System.Windows.Forms.DialogResult.Cancel)
                    return;

                switch (uf._addr)
                {
                    case START_FILE:
                        text2rtb("Обновление файла прошивки...");
                        if (!writefile(START_FILE, uf._fname, uf._rdfile, uf._len, "Файл прошивки ОЛО"))
                        {
                            err2rtb("Не удалось записать файл.");
                            return;
                        }
                        break;

                    case START_CONFIG:
                        text2rtb("Обновление файла конфигурации...");
                        DATATABLE dt = new DATATABLE();
                        dt = CreateStruct<DATATABLE>(uf._rdfile);
                        String sn = Encoding.Default.GetString(dt.ser_num, 0, 8);
                        switch (major_id(dt.dev_id))
                        {
                            case 0x11:
                                if (!writefile(START_CONFIG, uf._fname, uf._rdfile, SIZE_CONFIG, "Файл конфигурации ОЛО - правый, з/н " + sn))
                                {
                                    err2rtb("Не удалось закачать файл конфигурации");
                                    return;
                                }
                                break;

                            case 0x12:
                                if (!writefile(START_CONFIG, uf._fname, uf._rdfile, SIZE_CONFIG, "Файл конфигурации ОЛО - левый, з/н " + sn))
                                {
                                    err2rtb("Не удалось закачать файл конфигурации");
                                    return;
                                }
                                break;

                            default:
                                err2rtb("Идентификатор не распознан.");
                                return;
                        }
                        break;

                    default:
                        if (!writefile(uf._addr, uf._fname, uf._rdfile, uf._len, ""))
                        {
                            err2rtb("Не удалось записать файл.");
                            return;
                        }
                        break;
                }
                done2rtb("Файл записан.");
            }
            else
            {
                err2rtb("РУП не активирован.");
                return;
            }
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e) // стереть файл
        {
            if (aktiv)
            {
                text2rtb("Стираю файл " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "...");
                Byte filenum = Convert.ToByte(dataGridView1.SelectedRows[0].Cells[7].Value);
                if (!erase_area(fff[filenum].begin, fff[filenum].size))
                {
                    err2rtb("Не удалось очистить флеш.");
                    return;
                }
                done2rtb("Стирание завешено.");
                text2rtb("Обновляю таблицу файлов.");

                fff[filenum] = new FILETABLE(0xFF);
                filetable_sort();
                if (!filetable_save())
                {
                    err2rtb("Не удалось записать таблицу файлов");
                    return;
                }
                filetable_2_dg();
            }
            else
            {
                err2rtb("РУП не активирован.");
                return;
            }
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e) // проверить
        {
            progressBar1.Value = 0;
            Byte fileindex = Convert.ToByte(dataGridView1.SelectedRows[0].Cells[7].Value);
            text2rtb("Проверка файла " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            progressBar1.Maximum = (int)fff[fileindex].size;
            Array.Clear(frame.data, 0, 8);
            frame.id = rup_id.READ_DATA_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
            Byte[] tmparr = new Byte[4];
            frame.len = 8;
            tmparr = BitConverter.GetBytes(fff[fileindex].begin);
            for (byte n = 0; n < 4; n++)
                frame.data[n] = tmparr[n];
            tmparr = BitConverter.GetBytes(fff[fileindex].size);
            for (byte n = 0; n < 4; n++)
                frame.data[n + 4] = tmparr[n];
            if (uniCAN == null || !uniCAN.Send(ref frame))
            {
                err2rtb("Error send READ_DATA_ID");
                return;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                err2rtb("Error recv ACK");
                return;
            }
#if DEBUG
            print2_msg(frame);
#endif
            UInt32 numpack = (fff[fileindex].size + 8 - 1) / 8;
            byte[] buf = new byte[fff[fileindex].size];
            UInt32 buf_count = 0;
            for (int i = 0; i < numpack; i++)
            {
                frame.id = rup_id.READ_DATA_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
                frame.len = 0;
                if (uniCAN == null || !uniCAN.Send(ref frame))
                {
                    Trace.WriteLine("Error send READ_DATA_ID");
                    return;
                }
                if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
                {
                    Trace.WriteLine("Error recv READ_DATA_ID");
                    return;
                }
                for (int j = 0; j < frame.len; j++)
                {
                    progressBar1.Value = (int)buf_count;
                    buf[buf_count++] = frame.data[j];
                }
            }
            Trace.WriteLine("file read");
            Crc32 crc32 = new Crc32();
            String hash = String.Empty;
            foreach (byte b in crc32.ComputeHash(buf))
                hash += b.ToString("X2");
            Trace.WriteLine(hash);
            Byte[] crc = new Byte[4];
            crc = crc32.ComputeHash(buf);
            Array.Reverse(crc);
            if (BitConverter.ToUInt32(crc, 0) == fff[fileindex].crc32)
                done2rtb("Контрольная сумма CRC32 совпадает.");
            else
                err2rtb("Ошибка!!! Не совпадает контрольная сумма CRC32!!!");
        }
        private void toolStripMenuItem7_Click(object sender, EventArgs e) // закачать
        {
            filetable_sort();
            UploadFile uf = new UploadFile();
            DialogResult re = uf.ShowDialog();
            if (re == System.Windows.Forms.DialogResult.Cancel)
                return;
            //            MessageBox.Show(fff[0].size.ToString());
            String filename = uf._fname;

            if (!writefile(uf._addr, uf._fname, uf._rdfile, uf._len, Environment.UserName))
            {
                err2rtb("Не удалось записать файл.");
                return;
            }
            done2rtb("Файл записан.");
        }
        private void toolStripMenuItem8_Click(object sender, EventArgs e) // форматировать флеш
        {
            if (aktiv)
            {
                text2rtb("Форматирование флеша...");
                if (!erase_area(begin_flash1, size_flash1))
                {
                    err2rtb("Не удалось отформатировать флеш.");
                    return;
                }

                done2rtb("Форматирование флеша завершено.");
                for (int i = 0; i < 4; i++)
                {
                    fff[i] = new FILETABLE(0xFF);
                }
                text2rtb("Сохраняю таблицу файлов...");
                if (!filetable_save())
                {
                    err2rtb("Не удалось сохранить таблицу файлов.");
                    return;
                }
                if (!filetable_load())
                {
                    err2rtb("Не удалось прочитать таблицу файлов.");
                    return;
                }
                filetable_2_dg();
            }
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e) // закачать файл прошивки
        {
            filetable_sort();
            UploadFile uf = new UploadFile();
            uf.mtb_begin.Text = String.Format("0x{0:X}", START_FW);
            uf.Text = "Загрузка файла прошивки";
            DialogResult re = uf.ShowDialog();
            if (re == System.Windows.Forms.DialogResult.Cancel)
                return;
            text2rtb("Закачиваю файл прошивки...");
            if (!writefile(START_FW, uf._fname, uf._rdfile, uf._len, "Файл прошивки ОЛО"))
            {
                err2rtb("Не удалось закачать файл прошивки.");
                return;
            }
        }
        private void toolStripMenuItem10_Click(object sender, EventArgs e) // закачать файл конфигурации
        {
            filetable_sort();
            UploadFile uf = new UploadFile();
            uf.mtb_begin.Text = String.Format("0x{0:X}", START_CONFIG);
            uf.Text = "Загрузка файла конфигурации";
            DialogResult re = uf.ShowDialog();
            if (re == System.Windows.Forms.DialogResult.Cancel)
                return;
            DATATABLE dt = new DATATABLE();
            dt = CreateStruct<DATATABLE>(uf._rdfile);
            String sn = Encoding.Default.GetString(dt.ser_num, 0, 8);
            text2rtb("Закачиваю файл конфигурации...");
            switch (major_id(dt.dev_id))
            {
                case 0x11:
                    if (!writefile(START_CONFIG, uf._fname, uf._rdfile, SIZE_CONFIG, "Файл конфигурации ОЛО - правый, з/н " + sn))
                    {
                        err2rtb("Не удалось закачать файл конфигурации");
                        return;
                    }
                    break;

                case 0x12:
                    if (!writefile(START_CONFIG, uf._fname, uf._rdfile, SIZE_CONFIG, "Файл конфигурации ОЛО - левый, з/н " + sn))
                    {
                        err2rtb("Не удалось закачать файл конфигурации");
                        return;
                    }
                    break;

                default:
                    err2rtb("Идентификатор не распознан.");
                    return;
                //                    break;
            }
            done2rtb("Файл конфигурации записан.");
        }
        private void toolStripMenuItem11_Click(object sender, EventArgs e) // создать и закачать конфиг
        {
            if (aktiv)
            {
                newconfig nc = new newconfig();
                DialogResult re = nc.ShowDialog();
                if (re == System.Windows.Forms.DialogResult.Cancel)
                    return;
                if (nc.rb7_olo_right.Checked)
                    done2rtb("Создан файл \"" + nc.nc_filename + "\" для ОЛО правый, зав. номер " + nc.tb7_sernum.Text);
                else
                    done2rtb("Создан файл \"" + nc.nc_filename + "\" для ОЛО левый, зав. номер " + nc.tb7_sernum.Text);

                Byte[] rdfile = new Byte[SIZE_CONFIG];
                using (FileStream fs = new FileStream(nc.nc_filename, FileMode.Open, FileAccess.Read))
                {
                    fs.Read(rdfile, 0, (int)SIZE_CONFIG);
                }
                text2rtb("Закачиваю файл конфигурации...");
                if (nc.rb7_olo_right.Checked)
                {
                    if (!writefile(START_CONFIG, nc.nc_filename, rdfile, SIZE_CONFIG, "Файл конфигурации ОЛО - правый, з/н " + nc.tb7_sernum.Text))
                    {
                        err2rtb("Не удалось закачать файл конфигурации");
                        return;
                    }
                }
                else
                {
                    if (!writefile(START_CONFIG, nc.nc_filename, rdfile, SIZE_CONFIG, "Файл конфигурации ОЛО - левый, з/н " + nc.tb7_sernum.Text))
                    {
                        err2rtb("Не удалось закачать файл конфигурации");
                        return;
                    }
                }
                done2rtb("Файл конфигурации записан.");
            }
        }

        #endregion
        #region основные кнопки
        private void bt_status5_Click(object sender, EventArgs e)
        {
            try
            {
                Array.Clear(frame.data, 0, 8);
                frame.id = rup_id.STATUS_REQUEST_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
                frame.len = 0;
                if (uniCAN == null || !uniCAN.Send(ref frame))
                {
                    err2rtb("Error send STATUS_REQUEST_ID");
                    return;
                }
                if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
                {
                    err2rtb("Error recv STATUS_RESPONCE_ID");
                    return;
                }
#if DEBUG
                msg_2_log(frame);
#endif
                if (frame.id - (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID) == rup_id.STATUS_RESPONCE_ID)
                {
                    done2rtb("Режим " + ((rup_id.Mode)(frame.data[0] & 0x3)).ToString() +
                        " Команда " + ((rup_id.Comm)(frame.data[2] & 0x3F)).ToString() +
                        " Состояние " + ((rup_id.Receipt)(frame.data[2] >> 6)).ToString());
                }
            }
            catch (Exception ee)
            {
                err2rtb("Ошибка " + ee.ToString());
            }

        }
        private void bt_aktiv5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            dataGridView1.Rows.Clear();
            Boolean test = false;

            //активация РУП
            aktiv = false;
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Array.Clear(frame.data, 0, 8);
                    frame.id = rup_id.RUP_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
                    frame.len = 2;
                    frame.data[0] = 0x5A;
                    frame.data[1] = 0x5A;
                    if (uniCAN == null || !uniCAN.Send(ref frame))
                    {
                        err2rtb("Error send RUP_ID");
                        continue;
                    }
                    if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                    {
                        err2rtb("Error recv ACK_ID");
                        continue;
                    }
                    test = true;
                }
                catch (Exception)
                {
                }
                Application.DoEvents();
            }
            if (!test)
            {
                err2rtb("Ошибка! РУП не активирован.");
                return;
            }

#if DEBUG
            msg_2_log(frame);
#endif
            if ((frame.data[0] >> 6) == 3)
            {
                // запрос статуса

                Array.Clear(frame.data, 0, 8);
                frame.id = rup_id.STATUS_REQUEST_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
                frame.len = 0;
                if (uniCAN == null || !uniCAN.Send(ref frame))
                {
                    err2rtb("Error send STATUS_REQUEST_ID");
                    return;
                }
                if (uniCAN == null || !uniCAN.Recv(ref frame, 1000))
                {
                    err2rtb("Error recv STATUS_RESPONCE_ID");
                    return;
                }
                if ((frame.data[0] & 0x3) == 3)
                    done2rtb("РУП активирован.");
                else
                {
                    err2rtb("Ошибка! РУП не активирован.");
                    return;
                }
            }
            else
            {
                err2rtb("Ошибка! РУП не активирован.");
                return;
            }

            // активация флеш 1

            Array.Clear(frame.data, 0, 8);
            frame.id = rup_id.ACTIV_FLASH_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
            frame.len = 1;
            frame.data[0] = 1;
            if (uniCAN == null || !uniCAN.Send(ref frame))
            {
                err2rtb("Error send ACTIV_FLASH_ID 1");
                return;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                err2rtb("Error recv ACK_ID");
                return;
            }
#if DEBUG
            msg_2_log(frame);
#endif
            if (frame.id - (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID) == rup_id.FLASH_TABLE_RESPONCE_ID)
            {
                begin_flash1 = BitConverter.ToUInt32(frame.data, 0);
                size_flash1 = BitConverter.ToUInt32(frame.data, 4) + 1 - 0x4000 - 0x2000; // последний сектор отдали под файловую таблицу
                aktiv = true;
                //#if DEBUG
                //                msg_2_log(frame);
                //#endif

                // Запрос таблицы файлов

                if (!filetable_load())
                {
                    err2rtb("Не могу прочитать таблицу файлов.");
                    return;
                }
                filetable_2_dg();
            }
            else
            {
                err2rtb("Ошибка! Flash #1 не активирован.");
                return;
            }
            bt_verifi5.Enabled = true;

            dataGridView1.Enabled = true;
            progressBar1.Enabled = true;
            richTextBox1.Enabled = true;
        }
        private void bt_reboot5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            dataGridView1.Rows.Clear();
            Array.Clear(frame.data, 0, 8);
            frame.id = rup_id.RUP_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
            frame.len = 2;
            frame.data[0] = 0xB4;
            frame.data[1] = 0xB4;
            if (uniCAN == null || !uniCAN.Send(ref frame))
            {
                err2rtb("Error send RUP_ID");
                return;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                err2rtb("Error recv ACK_ID");
                return;
            }
#if DEBUG
            msg_2_log(frame);
#endif
            done2rtb("РУП деактивирован.");
            Array.Clear(frame.data, 0, 8);
            frame.len = 0;
            frame.id = rup_id.RECONFIG_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
            if (uniCAN == null || !uniCAN.Send(ref frame))
            {
                err2rtb("Error send RECONFIG_ID");
                return;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                err2rtb("Error recv ACK_ID");
                return;
            }
#if DEBUG
            msg_2_log(frame);
#endif
            warn2rtb("Перезагрузка.");
            aktiv = false;
            bt_verifi5.Enabled = false;
        }
        private void bt_verifi5_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            Byte fileindex = Convert.ToByte(dataGridView1.SelectedRows[0].Cells[7].Value);
            //            MessageBox.Show(dataGridView1.SelectedRows[0].Index.ToString());
            if (dataGridView1.SelectedRows[0].Index == 0)
                return;
            text2rtb("Проверка файла " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            Application.DoEvents();
            progressBar1.Maximum = (int)fff[fileindex].size;
            Array.Clear(frame.data, 0, 8);
            frame.id = rup_id.READ_DATA_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
            Byte[] tmparr = new Byte[4];
            frame.len = 8;
            tmparr = BitConverter.GetBytes(fff[fileindex].begin);
            for (byte n = 0; n < 4; n++)
                frame.data[n] = tmparr[n];
            tmparr = BitConverter.GetBytes(fff[fileindex].size);
            for (byte n = 0; n < 4; n++)
                frame.data[n + 4] = tmparr[n];
            if (uniCAN == null || !uniCAN.Send(ref frame))
            {
                err2rtb("Error send READ_DATA_ID");
                return;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                err2rtb("Error recv ACK");
                return;
            }

#if DEBUG
            print2_msg(frame);
#endif
            UInt32 numpack = (fff[fileindex].size + 8 - 1) / 8;
            byte[] buf = new byte[fff[fileindex].size];
            UInt32 buf_count = 0;
            for (int i = 0; i < numpack; i++)
            {
                frame.id = rup_id.READ_DATA_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
                frame.len = 0;
                if (uniCAN == null || !uniCAN.Send(ref frame))
                {
                    Trace.WriteLine("Error send READ_DATA_ID");
                    return;
                }
                if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
                {
                    Trace.WriteLine("Error recv READ_DATA_ID");
                    return;
                }
                for (int j = 0; j < frame.len; j++)
                {
                    progressBar1.Value = (int)buf_count;
                    buf[buf_count++] = frame.data[j];
                }
            }
            Trace.WriteLine("file read");
            Crc32 crc32 = new Crc32();
            String hash = String.Empty;
            foreach (byte b in crc32.ComputeHash(buf))
                hash += b.ToString("X2");
            Trace.WriteLine(hash);
            Byte[] crc = new Byte[4];
            crc = crc32.ComputeHash(buf);
            Array.Reverse(crc);
            if (BitConverter.ToUInt32(crc, 0) == fff[fileindex].crc32)
                done2rtb("Контрольная сумма CRC32 совпадает.");
            else
                err2rtb("Ошибка!!! Не совпадает контрольная сумма CRC32!!!");
        }
        #endregion
        #region Служебные функции
        Boolean writefile(UInt32 _addr, String _filename, Byte[] _buffer, UInt32 _bufsize, String _comment)
        {
            Byte filenum = 0xFF;

            // проверка наличия файла по этому адресу

            for (Byte i = 0; i < 4; i++)
            {
                if (fff[i].begin == _addr)
                {
                    filenum = i;
                    break;
                }
            }

            if (filenum != 0xFF)
            {
                warn2rtb("Файл по адресу " + String.Format("0x{0:X}", _addr) + " существует.");
                text2rtb("Удаляю файл \"" + gettextfromarr(fff[filenum].name, (Byte)(fff[filenum].name.Length)) + "\" ...");
                if (!erase_area(fff[filenum].begin, fff[filenum].size))
                {
                    err2rtb("Не удалось очиститить флеш.");
                    return false;
                }
                done2rtb("Удаление завершено.");
                text2rtb("Обновляю таблицу файлов.");

                // зачищаем слот и сортируем
                fff[filenum] = new FILETABLE(0xFF);
                filetable_sort();
                if (!filetable_save())
                {
                    err2rtb("Не удалось записать таблицу файлов.");
                    return false;
                }
                filetable_2_dg();
            }

            // поиск первого свободного слота
            if (!filetable_load())
            {
                err2rtb("Не удалось прочитать таблицу файлов.");
                return false;
            }
            filetable_2_dg();
            filenum = 0xFF;
            for (Byte i = 0; i < 4; i++)
            {
                //                if (fff[i].begin == 0 || fff[i].begin == 0xFFFFFFFF)
                // Для МУК 
                if ((fff[i].begin == 0 || fff[i].begin == 0xFFFFFFFF) && fff[i].name[0] == 0x03)
                {
                    filenum = i;
                    break;
                }
            }
            if (filenum == 0xFF)
            {
                err2rtb("Нельзя записать больше 4-х файлов!!!");
                return false;
            }

            // нашли свободный слот, пишем в него
            String filename = _filename;
            if (_filename.Length > 28)
            {
                filename = _filename.Remove(22) + "~.bin";
                warn2rtb("Имя файла слишком длинное. Обрезаем.");
            }
            else
                filename = _filename;
            Byte[] tmparr = new Byte[Encoding.Default.GetBytes(filename).Length];
            fff[filenum].name = new Byte[28];
            for (int i = 0; i < 28; i++)
                fff[filenum].name[i] = 0;
            Array.Copy(Encoding.Default.GetBytes(filename), fff[filenum].name, tmparr.Length);
            fff[filenum].begin = _addr;
            fff[filenum].size = _bufsize;
            fff[filenum].time = (UInt32)((DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds);
            Byte[] crc = new Byte[4];
            Crc32 crc32 = new Crc32();
            crc = crc32.ComputeHash(_buffer);
            Array.Reverse(crc);
            UInt32 _crc = BitConverter.ToUInt32(crc, 0);
            fff[filenum].crc32 = _crc;
            fff[filenum].version = 1;
            if (_comment == "")
            {
                tmparr = new Byte[Encoding.Default.GetBytes(Environment.UserName).Length];
                tmparr = Encoding.Default.GetBytes(Environment.UserName);
            }
            else
            {
                tmparr = new Byte[Encoding.Default.GetBytes(_comment).Length];
                tmparr = Encoding.Default.GetBytes(_comment);
            }
            fff[filenum].comment = new Byte[80];
            for (int i = 0; i < 80; i++)
                fff[filenum].comment[i] = 0;
            if (tmparr.Length > 80)
            {
                Array.Copy(tmparr, fff[filenum].comment, 80);
            }
            else
                Array.Copy(tmparr, fff[filenum].comment, tmparr.Length);

            // очистка флеш

            text2rtb("Очистка области...");
            if (!erase_area(fff[filenum].begin, fff[filenum].size))
            {
                err2rtb("Не удалось очиститить флеш.");
                return false;
            }
            done2rtb("Очистка области завершена.");

            // запись файла
            text2rtb("Запись файла \"" + filename + "\" ...");

            if (!write_area(fff[filenum].begin, fff[filenum].size, _buffer))
            {
                err2rtb("Не удалось записать данные");
                return false;
            }
            done2rtb("Запись файла завершена.");

            filetable_sort();
            if (!filetable_save())
            {
                err2rtb("Не удалось записать таблицу файлов.");
                return false;
            }
            filetable_2_dg();
            return true;
        }
        Boolean filetable_load()
        {
            Array.Clear(frame.data, 0, 8);
            frame.id = rup_id.FILE_TABLE_REQUEST_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
            frame.len = 0;
            if (uniCAN == null || !uniCAN.Send(ref frame))
            {
                err2rtb("Error send FILE_TABLE_REQUEST_ID");
                return false;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 1000))
            {
                err2rtb("Error recv FILE_TABLE_ADDRESS_ID");
                return false;
            }
#if DEBUG
            msg_2_log(frame);
#endif
            //            begin_filetable = BitConverter.ToUInt32(frame.data, 0);
            begin_filetable = START_FILE;
            Trace.WriteLine(begin_filetable.ToString());
            // read file table 128 byte 4 блока!!!!

            Byte iii = 0;
            do
            {
                Byte[] buf = new Byte[SIZE_FILE];
                if (!read_area((UInt32)(START_FILE + iii * SIZE_FILE), SIZE_FILE, ref buf))
                    return false;
                fff[iii] = CreateStruct<FILETABLE>(buf);
                iii++;
            } while (iii < 4);
            Trace.WriteLine("file table read");
            filetable_sort();
            if (fff[0].name[0] == 0xFF)
            {
                fff[0].name[0] = 0x03;
//                warn2rtb("Таблица файлов пуста.");
            }
            return true;
        }
        Boolean filetable_save()
        {
            filetable_sort();

            // стереть последний сектор

            Array.Clear(frame.data, 0, 8);
            frame.id = rup_id.ERASE_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
            frame.len = 8;
            Byte[] tmparr = new Byte[4];
            frame.len = 8;
            tmparr = BitConverter.GetBytes(START_FILE);
            for (byte n = 0; n < 4; n++)
                frame.data[n] = tmparr[n];
            tmparr = BitConverter.GetBytes(0x2000);
            for (byte n = 0; n < 4; n++)
                frame.data[n + 4] = tmparr[n];
            if (uniCAN == null || !uniCAN.Send(ref frame))
            {
                err2rtb("Error send ERASE_ID");
                return false;
            }
            progressBar1.Value = 0;
            do
            {
                Array.Clear(frame.data, 0, 8);
                frame.id = rup_id.STATUS_REQUEST_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
                frame.len = 0;
                if (uniCAN == null || !uniCAN.Send(ref frame))
                {
                    Trace.WriteLine("Error send STATUS_REQUEST_ID");
                    return false;
                }
                if (uniCAN == null || !uniCAN.Recv(ref frame, 1000))
                {
                    Trace.WriteLine("Error recv STATUS_RESPONCE_ID");
                    return false;
                }
            } while ((frame.data[2] >> 6) == 0);
            Trace.WriteLine("Erase sector 16 complete.");

            // структуру в массив

            Byte[] buf = new Byte[SIZE_FILE * 4];
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = 0xFF;
            }
            int ii = 0;
            for (int i = 0; i < 4; i++)
            {
                if (fff[i].size > 0 && fff[i].size < UInt32.MaxValue)
                {
                    Byte[] arr = new Byte[SIZE_FILE];
                    arr = StructToBuff<FILETABLE>(fff[i]);
                    Array.Copy(arr, 0, buf, SIZE_FILE * ii, SIZE_FILE);
                    ii++;
                }
            }

            // под МУК пишем в первый свободный слот 0x03
            if (ii < 4)
                buf[SIZE_FILE * ii] = 0x03;

            // записать в флеш filetable
            Trace.WriteLine("Запись адрес" + begin_filetable.ToString("X"));
            Trace.WriteLine("Запись длина" + ((uint)buf.Length).ToString("X"));

            if (!write_area(START_FILE, (uint)buf.Length, buf))
            {
                err2rtb("Не удалось записать данные.");
                return false;
            }
            //            mark2rtb("Таблица файлов записана.");
            Trace.WriteLine("file table saved");
            return true;
        }
        void filetable_2_dg()
        {
            filetable_sort();
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add("Flash #1",
                "0x" + begin_flash1.ToString("X"),
                "0x" + size_flash1.ToString("X"));
            dataGridView1.Rows[0].DefaultCellStyle.BackColor = Color.LightGreen;

            for (int i = 0; i < 4; i++)
            {
                if (fff[i].size != 0 && fff[i].size != 0xFFFFFFFF)
                {
                    String name = Encoding.Default.GetString(fff[i].name, 0, 28);
                    DateTime pDate = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(fff[i].time);
                    String comment = Encoding.Default.GetString(fff[i].comment, 0, 80);
#if DEBUG
                    listBox1.Items.Insert(0, "Файл: " + name.Substring(0, name.IndexOf('\0')) +
                        " Адрес: " + fff[i].begin.ToString("X") +
                        " Размер: " + fff[i].size.ToString("X") +
                        " Время: " + pDate.ToString() +
                        " CRC32: " + fff[i].crc32.ToString("X8") +
                        " версия " + getver(fff[i].version) +
                        " Коммент: " + comment.Substring(0, comment.IndexOf('\0')));
#endif
                    try
                    {
                        dataGridView1.Rows.Add(name.Substring(0, name.IndexOf('\0')),
                            "0x" + fff[i].begin.ToString("X"),
                            "0x" + fff[i].size.ToString("X"),
                            pDate.ToString(),
                            fff[i].crc32.ToString("X8"),
                            getver(fff[i].version),
                            comment.Substring(0, comment.IndexOf('\0')),
                            i);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Загрузчик не соответствует!\r\nНе удалось прочитать таблицу файлов!");
                    }
                }
            }
        }
        void filetable_sort()
        {
            Array.Sort(fff, delegate(FILETABLE fff1, FILETABLE fff2)
            {
                return fff1.begin.CompareTo(fff2.begin);
            });
        }
        Boolean erase_area(UInt32 begin, UInt32 size)
        {
            if (aktiv)
            {
                // запрос границ стирания

                Array.Clear(frame.data, 0, 8);
                frame.id = rup_id.AREA_ERASE_REQUEST_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
                frame.len = 7;
                Byte[] tmparr = new Byte[4];
                frame.len = 8;
                tmparr = BitConverter.GetBytes(begin);
                for (byte n = 0; n < 4; n++)
                    frame.data[n] = tmparr[n];
                tmparr = BitConverter.GetBytes(size);
                for (byte n = 0; n < 4; n++)
                    frame.data[n + 4] = tmparr[n];
                if (uniCAN == null || !uniCAN.Send(ref frame))
                {
                    err2rtb("Error send AREA_ERASE_REQUEST_ID");
                    return false;
                }
                if (uniCAN == null || !uniCAN.Recv(ref frame, 1000))
                {
                    err2rtb("Error recv AREA_ERASE_RESPONCE_ID");
                    return false;
                }
#if DEBUG
                msg_2_log(frame);
#endif

                // команда на стирание

                frame.id = rup_id.ERASE_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
                frame.len = 7;
                if (uniCAN == null || !uniCAN.Send(ref frame))
                {
                    err2rtb("Error send ERASE_ID");
                    return false;
                }

                progressBar1.Value = 0;
                progressBar1.Maximum = 15;
                int pbval = 0;
                do
                {
                    Array.Clear(frame.data, 0, 8);
                    frame.id = rup_id.STATUS_REQUEST_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
                    frame.len = 0;
                    if (uniCAN == null || !uniCAN.Send(ref frame))
                    {
                        Trace.WriteLine("Error send STATUS_REQUEST_ID");
                        return false;
                    }
                    if (uniCAN == null || !uniCAN.Recv(ref frame, 1000))
                    {
                        Trace.WriteLine("Error recv STATUS_RESPONCE_ID");
                        return false;
                    }
#if DEBUG
                    msg_2_log(frame);
#endif
                    progressBar1.Value = pbval++;
                } while ((frame.data[2] >> 6) == 0);

#if DEBUG
                listBox1.Items.Insert(0, "Очистка области завершена.");
#endif
                progressBar1.Value = 0;
            }
            else
                return false;
            return true;
        }
        Boolean write_area(UInt32 begin, UInt32 size, Byte[] buf)
        {
            if (aktiv)
            {
                // записать в флеш

                Array.Clear(frame.data, 0, 8);
                frame.id = rup_id.WRITE_DATA_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
                Byte[] tmparr = new Byte[4];
                frame.len = 7;
                tmparr = BitConverter.GetBytes(begin);
                for (byte n = 0; n < 4; n++)
                    frame.data[n] = tmparr[n];
                tmparr = BitConverter.GetBytes(size);
                for (byte n = 0; n < 4; n++)
                    frame.data[n + 4] = tmparr[n];
                if (uniCAN == null || !uniCAN.Send(ref frame))
                {
                    err2rtb("Error send WRITE_DATA_ID");
                    return false;
                }
                if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
                {
                    err2rtb("Error recv ACK");
                    return false;
                }
#if DEBUG
                msg_2_log(frame);
#endif
                if ((frame.data[0] >> 6) == 1)
                {
                    UInt32 numpack = (size + 8 - 1) / 8;
                    UInt32 lastframelen = (UInt32)(buf.Length - (numpack - 1) * 8);
                    progressBar1.Value = 0;
                    progressBar1.Maximum = (int)numpack;
                    for (int i = 0; i < numpack; i++)
                    {
                        Array.Clear(frame.data, 0, 8);
                        frame.id = rup_id.DATA_SEGMENT_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
                        if (i != (numpack - 1))
                            frame.len = 8;
                        else
                            frame.len = (Byte)lastframelen;

                        for (int j = 0; j < frame.len; j++)
                            frame.data[j] = buf[i * 8 + j];
                        if (uniCAN == null || !uniCAN.Send(ref frame))
                        {
                            err2rtb("Error send DATA_SEGMENT_ID");
                            return false;
                        }
                        if (uniCAN == null || !uniCAN.Recv(ref frame, 1000))
                        {
                            err2rtb("Error recv ACK");
                            return false;
                        }
                        Application.DoEvents();
                        progressBar1.Value = i;
                    }
                    Trace.WriteLine("file saved");
                    progressBar1.Value = 0;
                }
            }
            else
                return false;
            return true;
        }
        Boolean read_area(UInt32 begin, UInt32 size, ref Byte[] buf)
        {
            progressBar1.Value = 0;
            Application.DoEvents();
            progressBar1.Maximum = (int)size;

            Array.Clear(frame.data, 0, 8);
            frame.id = rup_id.READ_DATA_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
            Byte[] tmparr = new Byte[4];
            frame.len = 8;
            tmparr = BitConverter.GetBytes(begin);
            for (byte n = 0; n < 4; n++)
                frame.data[n] = tmparr[n];
            tmparr = BitConverter.GetBytes(size);
            for (byte n = 0; n < 4; n++)
                frame.data[n + 4] = tmparr[n];
            if (uniCAN == null || !uniCAN.Send(ref frame))
            {
                Trace.WriteLine("Error send READ_DATA_ID");
                return false;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 1000))
            {
                Trace.WriteLine("Error recv ACK");
                return false;
            }
#if DEBUG
            print2_msg(frame);
#endif
            UInt32 numpack = (size + 8 - 1) / 8;
            UInt32 buf_count = 0;
            for (int i = 0; i < numpack; i++)
            {
                frame.id = rup_id.READ_DATA_ID | (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID);
                frame.len = 0;
                if (uniCAN == null || !uniCAN.Send(ref frame))
                {
                    Trace.WriteLine("Error send READ_DATA_ID");
                    return false;
                }
                if (uniCAN == null || !uniCAN.Recv(ref frame, 1000))
                {
                    Trace.WriteLine("Error recv READ_DATA_ID");
                    return false;
                }
                for (int j = 0; j < frame.len; j++)
                {
                    progressBar1.Value = (int)buf_count;
                    buf[buf_count++] = frame.data[j];
                }
            }
            Trace.WriteLine("area read complete");
            progressBar1.Value = 0;
            return true;
        }
        Boolean datatable_load()
        {
            Byte[] arr = new Byte[size_dtable];
            if (!read_area(begin_dtable, size_dtable, ref arr))
            {
                err2rtb("Не удалось прочитать файл конфигурации.");
                return false;
            }
            GCHandle handle = GCHandle.Alloc(arr, GCHandleType.Pinned);
            dtable = (DATATABLE)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(DATATABLE));
            handle.Free();
            return true;
        }
        Boolean datatable_save()
        {
            Byte[] arr = new Byte[size_dtable];
            arr = StructToBuff<DATATABLE>(dtable);
            if (!write_area(begin_dtable, size_dtable, arr))
            {
                err2rtb("Не удалось записать файл конфигурации.");
                return false;
            }
            return true;
        }
        static unsafe byte[] GetBytes<T>(T obj) where T : struct
        {
            var size = Marshal.SizeOf(typeof(T));
            var buffer = new byte[size];

            fixed (void* pointer = buffer)
            {
                Marshal.StructureToPtr(obj, new IntPtr(pointer), false);
                return buffer;
            }
        }
        static unsafe T CreateStruct<T>(byte[] buffer)
        {
            fixed (void* pointer = buffer)
            {
                return (T)Marshal.PtrToStructure(new IntPtr(pointer), typeof(T));
            }
        }
        String getver(UInt32 num)
        {
            Byte[] v = new Byte[4];
            v = BitConverter.GetBytes(num);
            return v[0].ToString() + "." + v[1].ToString() + "." + v[2].ToString() + "." + v[3].ToString();
        }
        String gettextfromarr(Byte[] a, Byte b)
        {
            String name = Encoding.Default.GetString(a, 0, b);
            return name.Substring(0, name.IndexOf('\0'));
        }
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Point pt = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                pt.X += e.Location.X;
                pt.Y += e.Location.Y;
                if (e.RowIndex != 0)
                {
                    DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
                    if (!c.Selected)
                    {
                        c.DataGridView.ClearSelection();
                        c.DataGridView.CurrentCell = c;
                        c.Selected = true;
                    }
                    toolStripMenuItem1.Text = "Файл: " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString();// +" " + dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                    contextMenuStrip1.Show(dataGridView1, pt);
                }
                else
                {
                    toolStripMenuItem6.Text = "Flash: " + dataGridView1.Rows[0].Cells[0].Value.ToString();
                    contextMenuStrip2.Show(dataGridView1, pt);
                }
            }
        }
        void err2rtb(String sss)
        {
#if DBG
            richTextBox1.AppendText(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " - " + sss + crlf, Color.Red, Color.Black);
#else
            richTextBox1.AppendText(sss + crlf, Color.IndianRed, Color.White);
#endif
            Application.DoEvents();
        }
        void done2rtb(String sss)
        {
#if DBG
            richTextBox1.AppendText(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " - " + sss + crlf, Color.LawnGreen, Color.Black);
#else
            richTextBox1.AppendText(sss + crlf, Color.LawnGreen, Color.Black);
#endif
            Application.DoEvents();
        }
        void warn2rtb(String sss)
        {
#if DBG
            richTextBox1.AppendText(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " - " + sss + crlf, Color.Yellow, Color.Black);
#else
            richTextBox1.AppendText(sss + crlf, Color.Yellow, Color.Black);
#endif
            Application.DoEvents();
        }
        void text2rtb(String sss)
        {
#if DBG
            richTextBox1.AppendText(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " - " + sss + crlf);
#else
            richTextBox1.AppendText(sss + crlf);
#endif
            Application.DoEvents();
        }
        Byte major_id(Byte[] id)
        {
            if (id[0] == id[1])
                return id[0];
            if (id[0] == id[2])
                return id[0];
            if (id[1] == id[2])
                return id[1];
            return 0;
        }
        #endregion
        #endregion
    }

    [Serializable]
    public class CNF
    {
        public CNF()
        {
            for (int i = 0; i < 3; i++)
                dev_id[i] = 0xFF;
            //            dev_id[0] = 0xBA;
            //            dev_id[2] = 0xBB;
            for (int i = 0; i < 8; i++)
                ser_num[i] = 0xFF;
            //            ser_num[0] = 0xCA;
            //            ser_num[7] = 0xCB;
            for (int i = 0; i < 116; i++)
                rezerv[i] = 0xFF;
            //            rezerv[0] = 0xDA;
            //            rezerv[115] = 0xDB;

        }
        public CNF(Byte devid, String sernum, String comm)
        {
            for (int i = 0; i < 3; i++)
            {
                dev_id[i] = idev_id;
            }

            if (iser_num == "")
            {
                iser_num = "00000000";
            }
            //            Byte[] tmparr = new Byte[8];
            for (int i = 0; i < 8; i++)
                ser_num[i] = 0;
            Array.Copy(Encoding.Default.GetBytes(iser_num), ser_num, 8);

            for (int i = 0; i < 116; i++)
                rezerv[i] = 0;
            Array.Copy(Encoding.Default.GetBytes(icomment), rezerv, Encoding.Default.GetBytes(icomment).Length);
        }

        private Byte test = 0;
        private Byte[] dev_id = new Byte[3]; //3
        private Byte[] ser_num = new Byte[8]; //8
        private Byte[] rezerv = new Byte[116]; //116

        public Byte idev_id = 0;
        public String iser_num = "";
        public String icomment = "";
//        ~CNF();

        public Boolean Save(String filename)
        {
            for (int i = 0; i < 3; i++)
            {
                dev_id[i] = idev_id;
            }

            if (iser_num == "")
            {
                iser_num = "00000000";
            }
//            Byte[] tmparr = new Byte[8];
            for (int i = 0; i < 8; i++)
                ser_num[i] = 0;
            Array.Copy(Encoding.Default.GetBytes(iser_num), ser_num, 8);

            for (int i = 0; i < 116; i++)
                rezerv[i] = 0;
            Array.Copy(Encoding.Default.GetBytes(icomment), rezerv, Encoding.Default.GetBytes(icomment).Length);

            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, this);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
