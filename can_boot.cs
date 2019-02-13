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
        #region OLO_CANBoot
        #region Открытие файла
        private void bt_openMC1_Click(object sender, EventArgs e)
        {
            lb_Load_OK1.Visible = false;
            lb_error_CAN1.Visible = false;
            lb_noerr1.Visible = false;

            rb_file_open.BackColor = SystemColors.ActiveCaption;
            rb_file_open.Checked = true;

            OpenFileDialog ofd_MC = new OpenFileDialog();
            ofd_MC.DefaultExt = "bin";
            ofd_MC.Filter = "Файл прошивки (*.bin)|*.bin|Все файлы (*.*)|*.*";
            DialogResult dr = ofd_MC.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.OK)
            {
                bt_loadMC1.Enabled = false;
                chb_eraseALL1.Enabled = false;
                return;
            }
            else
            {
                tb_fnameMC1.Text = ofd_MC.FileName;
                FileInfo fi = new FileInfo(ofd_MC.FileName);
                size = (_u32)fi.Length;
                Buffer = new _u8[size];
                using (BinaryReader reader = new BinaryReader(File.Open(ofd_MC.FileName, FileMode.Open)))
                {
                    for (long i = 0; i < size; i++)
                        Buffer[i] = reader.ReadByte();
                }
                bt_loadMC1.Enabled = true;
                //				bt_runMC.Enabled = true;
                chb_eraseALL1.Enabled = true;

            }
        }
        #endregion
        #region Загрузка прошивки в МК
        private void bt_loadMC1_Click(object sender, EventArgs e)
        {
            #region CAN

            //if (uniCAN != null)
            //    if (uniCAN.Is_Open)
            //    {
            //        uniCAN.Recv_Disable();
            //        uniCAN.Close();
            //    }
            //            if (cb_CAN1.SelectedItem.ToString() == "No CAN" || cb_CAN1.Items.Count < 1)
            if (cb_CAN1.Items.Count < 1)
                return;
            if (cb_CAN1.SelectedItem.ToString() == "USB Marathon")
            {
                marCAN = new MCANConverter();
                uniCAN = marCAN as MCANConverter;
            }
            else if (cb_CAN1.SelectedItem.ToString() == "PCI Advantech")
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
            state_Ready();
            lb_error_CAN1.Visible = false;
            uniCAN.Port = 0;
            uniCAN.Speed = 2;
            if (!uniCAN.Open())
            {
                lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                lb_error_CAN1.Visible = true;
                lb_noerr1.Visible = false;
                return;
            }
            //            timer_Error_Boot.Enabled = true;
            uniCAN.Recv_Enable();
            lb_noerr1.Text = uniCAN.Info;
            frame.data = new Byte[8];
            ClearData();
            #endregion

            pb_loadMC1.Visible = true;
            pb_loadMC1.Value = 0;
            bt_loadMC1.Text = "Загрузка..." + " 0%";
            //            lb_progress1.Text = "0%";
            gb_CAN1.Enabled = false;
            gb_MC1.Enabled = false;

            if (rb_cmos12_select_long_time.Checked)
            {
                Buffer = new _u8[FWDATA.SOLO2_SELECT_LONG_size];
                Buffer = (_u8[])FWDATA.SOLO2_SELECT_LONG;
            }
            if (rb_cmos12_select.Checked)
            {
                Buffer = new _u8[FWDATA.SOLO2_SELECT_size];
                Buffer = (_u8[])FWDATA.SOLO2_SELECT;
            }
            if (rb_flight_left_wing_double_pass.Checked)
            {
                Buffer = new _u8[FWDATA.SOLO2_FLIGHT_LEFT_size];
                Buffer = (_u8[])FWDATA.SOLO2_FLIGHT_LEFT;
            }
            if (rb_flight_right_wing_double_pass.Checked)
            {
                Buffer = new _u8[FWDATA.SOLO2_FLIGHT_RIGHT_size];
                Buffer = (_u8[])FWDATA.SOLO2_FLIGHT_RIGHT;
            }
            if (rb_cmos12_select_long_time2.Checked)
            {
                Buffer = new _u8[FWDATA.SELECT_LONG_TIME_V2_size];
                Buffer = (_u8[])FWDATA.SELECT_LONG_TIME_V2;
            }
            if (rb_cmos12_select2.Checked)
            {
                Buffer = new _u8[FWDATA.SOLO2_SELECT_V2_size];
                Buffer = (_u8[])FWDATA.SOLO2_SELECT_V2;
            }
            if (rb_new_RUP.Checked)
            {
                Buffer = new _u8[FWDATA.app_bootloader_to_RUP_style_size];
                Buffer = (_u8[])FWDATA.app_bootloader_to_RUP_style;
            }

            if (rb_flight_universal.Checked)
            {
                Buffer = new _u8[FWDATA.FLIGHT_U_2_2_3_size];
                Buffer = (_u8[])FWDATA.FLIGHT_U_2_2_3;
            }


            size = (uint)Buffer.Length;
            _u8 crc8 = 0;
            for (int i = 0; i < size; i++)
                crc8 += Buffer[i];

            #region reset before upload

            if (rb1_addr_uni.Checked)
            {
                if (chb1_need_reset.Checked)
                {
                    msg_t mm = new msg_t();

                    mm.deviceID = Const.OLO_All;
                    mm.messageID = msg_t.mID_RESET;
                    mm.messageLen = 1;
                    mm.messageData[0] = 0;
                    canmsg_t msg = new canmsg_t();
                    msg.data = new Byte[8];
                    msg = mm.ToCAN(mm);
                    if (!uniCAN.Send(ref msg, 100))
                        return;
                    double ii = 1.0;
                    for (int i = 0; i < 5; i++)
                    {
                        bt_loadMC1.Text = "Сброс ОЛО - " + (ii - i * 0.2).ToString("F1", CultureInfo.InvariantCulture) + " c";
                        bt_loadMC1.Refresh();
                        Thread.Sleep(100);
                    }
                }
                else
                    chb1_need_reset.Checked = false;
            }
            #endregion

            uint CAN_MSG_ID_MC2PC = Const.CAN_MSG_ID_MC2PC;
            uint CAN_MSG_ID_PC2MC = Const.CAN_MSG_ID_PC2MC;

            if (rb1_addr_uni.Checked)
            {
                #region Загрузка алгоритм Иоселева
                frame = new canmsg_t();
                frame.data = new Byte[8];
                frame.id = Const.CAN_MSG_ID_PC2MC;
                CAN_MSG_ID_MC2PC = (Byte)Const.CAN_MSG_ID_MC2PC;
                CAN_MSG_ID_PC2MC = (Byte)Const.CAN_MSG_ID_PC2MC;
                frame.len = (Byte)Marshal.SizeOf(cmd);

                cmd.command = Const.COMMAND_UPLOAD_FIRMWARE;
                cmd.size = (_u32)size;
                cmd.flags = (chb_eraseALL1.Checked ? Const.FLAG_ERASE_USER_CODE : (_u16)0);
                cmd.crc8 = (_u8)(0 - crc8);

                set_cmd(cmd, ref frame.data);

                if (!uniCAN.Send(ref frame, 2000))
                    return;
                Trace.WriteLine("Send commmand ID=0x" + frame.id.ToString("X2"));
                ClearData();
                if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                    return;
                Trace.WriteLine("Recv ID=0x" + frame.id.ToString("X2"));
                if (frame.id != CAN_MSG_ID_MC2PC)
                {
                    Trace.WriteLine("Неверный идентификатор пакета");
                    lb_error_CAN.Text = "Неверный идентификатор пакета";
                    lb_error_CAN.Visible = true;
                    lb_noerr.Visible = false;
                    uniCAN.Close();
                    gb_CAN1.Enabled = true;
                    gb_MC1.Enabled = true;
                    return;
                }
                get_ack(ref ack, frame.data);
                if (ack.error_code != Const.CMD_ERR_NO_ERROR)
                {
                    lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                    lb_error_CAN1.Visible = true;
                    lb_noerr1.Visible = false;
                    uniCAN.Close();
                    gb_CAN1.Enabled = true;
                    gb_MC1.Enabled = true;
                    return;
                }
                Trace.WriteLine("ACK no error");

                _u32 num_of_packets = (size + Const.CAN_MAX_PACKET_SIZE - 1) / Const.CAN_MAX_PACKET_SIZE;
                _u32 last_packet_size = (size % Const.CAN_MAX_PACKET_SIZE > 0 ? size % Const.CAN_MAX_PACKET_SIZE : Const.CAN_MAX_PACKET_SIZE);
                _u32 packets_in_block = Const.PACKETS_IN_BLOCK;

                for (_u32 i = 0; i < num_of_packets; i++)
                {
                    _u32 dlen = ((i == num_of_packets - 1) ? last_packet_size : Const.CAN_MAX_PACKET_SIZE);

                    ClearData();
                    ///// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    frame.id = Const.CAN_MSG_ID_PC2MC;
                    frame.len = (_u8)dlen;
                    for (_u8 ii = 0; ii < dlen; ii++)
                        frame.data[ii] = Buffer[i * Const.CAN_MAX_PACKET_SIZE + ii];

                    if (!uniCAN.Send(ref frame, 200))
                        return;
                    Trace.WriteLine("Send pack ID=0x" + frame.id.ToString("X2"));
                    if ((--packets_in_block) == 0)
                    {
                        packets_in_block = Const.PACKETS_IN_BLOCK;

                        if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                            return;
                        Trace.WriteLine("Recv pack block ID=0x" + frame.id.ToString("X2"));
                        uniCAN.HWReset();
                        get_ack(ref ack, frame.data);
                        if (ack.error_code != Const.CMD_ERR_NO_ERROR)
                        {
                            lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                            lb_error_CAN1.Visible = true;
                            lb_noerr1.Visible = false;
                            uniCAN.Close();
                            gb_CAN1.Enabled = true;
                            gb_MC1.Enabled = true;
                            return;
                        }
                    }
                    _u32 progress = (i + 1) * 100 / num_of_packets;
                    pb_loadMC1.Value = (_s32)progress;
                    bt_loadMC1.Text = "Загрузка..." + progress.ToString() + "%";
                    Application.DoEvents();
                }
                ClearData();
                if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                    return;
                if (frame.id != Const.CAN_MSG_ID_MC2PC)
                {
                    lb_error_CAN1.Text = "Неверный идентификатор пакета";
                    lb_error_CAN1.Visible = true;
                    lb_noerr1.Visible = false;
                    gb_CAN1.Enabled = true;
                    gb_MC1.Enabled = true;
                    return;
                }
                #endregion
            }
            else
            {
                #region Загрузка новый алгоритм
                frame = new canmsg_t();
                frame.data = new Byte[8];
                // отправляем команду режим модуля - режим программирования.
                if (rb1_addr_left.Checked)
                {
                    msg_t mm = new msg_t();
                    mm.deviceID = Const.OLO_Left;
                    mm.messageID = msg_t.mID_MODULE;
                    mm.messageLen = 1;
                    mm.messageData[0] = Const.COMMAND_MODULE_PROGRAMMING;
                    canmsg_t msg = new canmsg_t();
                    msg.data = new Byte[8];
                    msg = mm.ToCAN(mm);
                    if (!uniCAN.Send(ref msg, 100))
                        return;
                    frame.id = (msg_t.mID_PROG << 5) | Const.OLO_Left;
                    CAN_MSG_ID_MC2PC = (msg_t.mID_PROG << 5) | Const.OLO_Left;
                    CAN_MSG_ID_PC2MC = (msg_t.mID_PROG << 5) | Const.OLO_Left;
                }
                else
                {
                    msg_t mm = new msg_t();
                    mm.deviceID = Const.OLO_Right;
                    mm.messageID = msg_t.mID_MODULE;
                    mm.messageLen = 1;
                    mm.messageData[0] = Const.COMMAND_MODULE_PROGRAMMING;
                    canmsg_t msg = new canmsg_t();
                    msg.data = new Byte[8];
                    msg = mm.ToCAN(mm);
                    if (!uniCAN.Send(ref msg, 100))
                        return;
                    frame.id = (msg_t.mID_PROG << 5) | Const.OLO_Right;
                    CAN_MSG_ID_MC2PC = (msg_t.mID_PROG << 5) | Const.OLO_Right;
                    CAN_MSG_ID_PC2MC = (msg_t.mID_PROG << 5) | Const.OLO_Right;
                }

                // отправляем команду режим программирования - COMMAND_UPLOAD_FIRMWARE
                frame.len = (Byte)Marshal.SizeOf(cmd);
                frame.id = (msg_t.mID_PROG << 5) | (uint)(rb1_addr_left.Checked ? Const.OLO_Left : Const.OLO_Right);
                cmd.command = Const.COMMAND_UPLOAD_FIRMWARE;
                cmd.size = (_u32)size;
                cmd.flags = (chb_eraseALL1.Checked ? Const.FLAG_ERASE_USER_CODE : (_u16)0);
                cmd.crc8 = (_u8)(0 - crc8);

                set_cmd(cmd, ref frame.data);

                if (!uniCAN.Send(ref frame, 2000))
                    return;
                Trace.WriteLine("Send commmand ID=0x" + frame.id.ToString("X2"));
                ClearData();
                if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                    return;
                Trace.WriteLine("Recv ID=0x" + frame.id.ToString("X2"));
                CAN_MSG_ID_MC2PC = (msg_t.mID_OUTLOADER << 5) | (uint)(rb1_addr_left.Checked ? Const.OLO_Left : Const.OLO_Right);
                CAN_MSG_ID_PC2MC = (msg_t.mID_INLOADER << 5) | (uint)(rb1_addr_left.Checked ? Const.OLO_Left : Const.OLO_Right);
                if (frame.id != CAN_MSG_ID_MC2PC)
                {
                    Trace.WriteLine("Неверный идентификатор пакета");
                    lb_error_CAN.Text = "Неверный идентификатор пакета";
                    lb_error_CAN.Visible = true;
                    lb_noerr.Visible = false;
                    uniCAN.Close();
                    gb_CAN1.Enabled = true;
                    gb_MC1.Enabled = true;
                    return;
                }
                get_ack(ref ack, frame.data);
                if (ack.error_code != Const.CMD_ERR_NO_ERROR)
                {
                    lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                    lb_error_CAN1.Visible = true;
                    lb_noerr1.Visible = false;
                    uniCAN.Close();
                    gb_CAN1.Enabled = true;
                    gb_MC1.Enabled = true;
                    return;
                }
                print_msg(frame);
                Trace.WriteLine("ACK no error");
                _u32 num_of_packets = (size + Const.CAN_MAX_PACKET_SIZE - 1) / Const.CAN_MAX_PACKET_SIZE;
                _u32 last_packet_size = (size % Const.CAN_MAX_PACKET_SIZE > 0 ? size % Const.CAN_MAX_PACKET_SIZE : Const.CAN_MAX_PACKET_SIZE);
                _u32 packets_in_block = Const.PACKETS_IN_BLOCK;
                for (_u32 i = 0; i < num_of_packets; i++)
                {
                    _u32 dlen = ((i == num_of_packets - 1) ? last_packet_size : Const.CAN_MAX_PACKET_SIZE);

                    ClearData();
                    ///// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    frame.id = CAN_MSG_ID_PC2MC;
                    frame.len = (_u8)dlen;
                    for (_u8 ii = 0; ii < dlen; ii++)
                        frame.data[ii] = Buffer[i * Const.CAN_MAX_PACKET_SIZE + ii];

                    if (!uniCAN.Send(ref frame, 200))
                        return;
                    Trace.WriteLine("Send pack ID=0x" + frame.id.ToString("X2"));
                    if ((--packets_in_block) == 0)
                    {
                        packets_in_block = Const.PACKETS_IN_BLOCK;
                        //                        packets_in_block = 100;

                        if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                            return;
                        Trace.WriteLine("Recv pack block ID=0x" + frame.id.ToString("X2"));
                        uniCAN.HWReset();
                        get_ack(ref ack, frame.data);
                        if (ack.error_code != Const.CMD_ERR_NO_ERROR)
                        {
                            lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                            lb_error_CAN1.Visible = true;
                            lb_noerr1.Visible = false;
                            uniCAN.Close();
                            gb_CAN1.Enabled = true;
                            gb_MC1.Enabled = true;
                            return;
                        }
                    }
                    _u32 progress = (i + 1) * 100 / num_of_packets;
                    pb_loadMC1.Value = (_s32)progress;
                    bt_loadMC1.Text = "Загрузка..." + progress.ToString() + "%";
                    Application.DoEvents();
                }
                Trace.WriteLine("Transmit complete " + num_of_packets.ToString() + " pack");
                ClearData();
                if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                    return;
                if (frame.id != CAN_MSG_ID_MC2PC)
                {
                    lb_error_CAN1.Text = "Неверный идентификатор пакета";
                    lb_error_CAN1.Visible = true;
                    lb_noerr1.Visible = false;
                    gb_CAN1.Enabled = true;
                    gb_MC1.Enabled = true;
                    return;
                }
                #endregion
            }

            get_ack(ref ack, frame.data);
            if (ack.error_code != Const.CMD_ERR_NO_ERROR)
            {
                lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                lb_error_CAN1.Visible = true;
                lb_noerr1.Visible = false;
                uniCAN.Close();
                gb_CAN1.Enabled = true;
                gb_MC1.Enabled = true;
                return;
            }
            pb_loadMC1.Visible = false;
            pb_loadMC1.Value = 0;
            lb_Load_OK1.Text = "Микропрограмма успешно загружена";
            chb1_need_reset.Checked = false;
            lb_Load_OK1.Visible = true;
            gb_CAN1.Enabled = true;
            gb_MC1.Enabled = true;
            tb_fnameMC1.Text = "";
            lb_noerr1.Visible = false;
            lb_error_CAN1.Visible = false;
            timer_Error_Boot.Enabled = false;
            bt_loadMC1.Text = "Загрузить файл";
            //MessageBox.Show("Микропрограмма успешно загружена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            uniCAN.Recv_Disable();
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            #region CAN

            //if (uniCAN != null)
            //    if (uniCAN.Is_Open)
            //    {
            //        uniCAN.Recv_Disable();
            //        uniCAN.Close();
            //    }
            if (cb_CAN1.SelectedItem.ToString() == "No CAN" || cb_CAN1.Items.Count < 1)
                return;
            if (cb_CAN1.SelectedItem.ToString() == "USB Marathon")
            {
                marCAN = new MCANConverter();
                uniCAN = marCAN as MCANConverter;
            }
            else if (cb_CAN1.SelectedItem.ToString() == "PCI Advantech")
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
            state_Ready();
            lb_error_CAN1.Visible = false;
            uniCAN.Port = 0;
            uniCAN.Speed = 2;
            if (!uniCAN.Open())
            {
                lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                lb_error_CAN1.Visible = true;
                lb_noerr1.Visible = false;
                return;
            }
            //            timer_Error_Boot.Enabled = true;
            uniCAN.Recv_Enable();
            lb_noerr1.Text = uniCAN.Info;
            frame.data = new Byte[8];
            ClearData();
            #endregion

            pb_loadMC1.Visible = true;
            bt_loadMC1.Text = "Загрузка..." + " 0%";
            //            lb_progress1.Text = "0%";
            gb_CAN1.Enabled = false;
            gb_MC1.Enabled = false;

            _u8 crc8 = 0;
            for (int i = 0; i < size; i++)
                crc8 += Buffer[i];

            #region reset before upload

            if (rb1_addr_uni.Checked)
            {
                if (chb1_need_reset.Checked)
                {
                    msg_t mm = new msg_t();

                    mm.deviceID = Const.OLO_All;
                    mm.messageID = msg_t.mID_RESET;
                    mm.messageLen = 1;
                    mm.messageData[0] = 0;
                    canmsg_t msg = new canmsg_t();
                    msg.data = new Byte[8];
                    msg = mm.ToCAN(mm);
                    if (!uniCAN.Send(ref msg, 100))
                        return;
                    bt_loadMC1.Text = "Сброс ОЛО... 2 c";
                    bt_loadMC1.Refresh();
                    Thread.Sleep(1000);
                    bt_loadMC1.Text = "Сброс ОЛО... 1 c";
                    bt_loadMC1.Refresh();
                    Thread.Sleep(1000);
                }
                else
                    chb1_need_reset.Checked = false;
            }
            #endregion

            uint CAN_MSG_ID_MC2PC = Const.CAN_MSG_ID_MC2PC;
            uint CAN_MSG_ID_PC2MC = Const.CAN_MSG_ID_PC2MC;

            if (rb1_addr_uni.Checked)
            {
                #region Загрузка алгоритм Иоселева
                frame = new canmsg_t();
                frame.data = new Byte[8];
                frame.id = Const.CAN_MSG_ID_PC2MC;
                CAN_MSG_ID_MC2PC = (Byte)Const.CAN_MSG_ID_MC2PC;
                CAN_MSG_ID_PC2MC = (Byte)Const.CAN_MSG_ID_PC2MC;
                frame.len = (Byte)Marshal.SizeOf(cmd);

                cmd.command = Const.COMMAND_UPLOAD_FIRMWARE;
                cmd.size = (_u32)size;
                cmd.flags = (chb_eraseALL1.Checked ? Const.FLAG_ERASE_USER_CODE : (_u16)0);
                cmd.crc8 = (_u8)(0 - crc8);

                set_cmd(cmd, ref frame.data);

                if (!uniCAN.Send(ref frame, 2000))
                    return;
                Trace.WriteLine("Send commmand ID=0x" + frame.id.ToString("X2"));
                ClearData();
                if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                    return;
                Trace.WriteLine("Recv ID=0x" + frame.id.ToString("X2"));
                if (frame.id != CAN_MSG_ID_MC2PC)
                {
                    Trace.WriteLine("Неверный идентификатор пакета");
                    lb_error_CAN.Text = "Неверный идентификатор пакета";
                    lb_error_CAN.Visible = true;
                    lb_noerr.Visible = false;
                    uniCAN.Close();
                    gb_CAN1.Enabled = true;
                    gb_MC1.Enabled = true;
                    return;
                }
                get_ack(ref ack, frame.data);
                if (ack.error_code != Const.CMD_ERR_NO_ERROR)
                {
                    lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                    lb_error_CAN1.Visible = true;
                    lb_noerr1.Visible = false;
                    uniCAN.Close();
                    gb_CAN1.Enabled = true;
                    gb_MC1.Enabled = true;
                    return;
                }
                Trace.WriteLine("ACK no error");

                _u32 num_of_packets = (size + Const.CAN_MAX_PACKET_SIZE - 1) / Const.CAN_MAX_PACKET_SIZE;
                _u32 last_packet_size = (size % Const.CAN_MAX_PACKET_SIZE > 0 ? size % Const.CAN_MAX_PACKET_SIZE : Const.CAN_MAX_PACKET_SIZE);
                _u32 packets_in_block = Const.PACKETS_IN_BLOCK;

                for (_u32 i = 0; i < num_of_packets; i++)
                {
                    _u32 dlen = ((i == num_of_packets - 1) ? last_packet_size : Const.CAN_MAX_PACKET_SIZE);

                    ClearData();
                    ///// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    frame.id = Const.CAN_MSG_ID_PC2MC;
                    frame.len = (_u8)dlen;
                    for (_u8 ii = 0; ii < dlen; ii++)
                        frame.data[ii] = Buffer[i * Const.CAN_MAX_PACKET_SIZE + ii];

                    if (!uniCAN.Send(ref frame, 200))
                        return;
                    Trace.WriteLine("Send pack ID=0x" + frame.id.ToString("X2"));
                    if ((--packets_in_block) == 0)
                    {
                        packets_in_block = Const.PACKETS_IN_BLOCK;

                        if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                            return;
                        Trace.WriteLine("Recv pack block ID=0x" + frame.id.ToString("X2"));
                        uniCAN.HWReset();
                        get_ack(ref ack, frame.data);
                        if (ack.error_code != Const.CMD_ERR_NO_ERROR)
                        {
                            lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                            lb_error_CAN1.Visible = true;
                            lb_noerr1.Visible = false;
                            uniCAN.Close();
                            gb_CAN1.Enabled = true;
                            gb_MC1.Enabled = true;
                            return;
                        }
                    }
                    _u32 progress = (i + 1) * 100 / num_of_packets;
                    pb_loadMC1.Value = (_s32)progress;
                    bt_loadMC1.Text = "Загрузка..." + progress.ToString() + "%";
                    Application.DoEvents();
                }
                ClearData();
                if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                    return;
                if (frame.id != Const.CAN_MSG_ID_MC2PC)
                {
                    lb_error_CAN1.Text = "Неверный идентификатор пакета";
                    lb_error_CAN1.Visible = true;
                    lb_noerr1.Visible = false;
                    gb_CAN1.Enabled = true;
                    gb_MC1.Enabled = true;
                    return;
                }
                #endregion
            }
            else
            {
                #region Загрузка новый алгоритм
                CAN_MSG_ID_MC2PC = (msg_t.mID_OUTLOADER << 5) | (uint)(rb1_addr_left.Checked ? Const.OLO_Left : Const.OLO_Right);
                CAN_MSG_ID_PC2MC = (msg_t.mID_INLOADER << 5) | (uint)(rb1_addr_left.Checked ? Const.OLO_Left : Const.OLO_Right);
                frame = new canmsg_t();
                frame.data = new Byte[8];
                frame.id = CAN_MSG_ID_PC2MC;
                frame.len = (Byte)Marshal.SizeOf(cmd);

                cmd.command = Const.COMMAND_UPLOAD_FIRMWARE;
                cmd.size = (_u32)size;
                cmd.flags = (chb_eraseALL1.Checked ? Const.FLAG_ERASE_USER_CODE : (_u16)0);
                cmd.crc8 = (_u8)(0 - crc8);

                set_cmd(cmd, ref frame.data);

                if (!uniCAN.Send(ref frame, 2000))
                    return;
                Trace.WriteLine("Send commmand ID=0x" + frame.id.ToString("X2"));
                ClearData();
                if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                    return;
                Trace.WriteLine("Recv ID=0x" + frame.id.ToString("X2"));
                if (frame.id != CAN_MSG_ID_MC2PC)
                {
                    Trace.WriteLine("Неверный идентификатор пакета");
                    lb_error_CAN.Text = "Неверный идентификатор пакета";
                    lb_error_CAN.Visible = true;
                    lb_noerr.Visible = false;
                    uniCAN.Close();
                    gb_CAN1.Enabled = true;
                    gb_MC1.Enabled = true;
                    return;
                }
                get_ack(ref ack, frame.data);
                if (ack.error_code != Const.CMD_ERR_NO_ERROR)
                {
                    lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                    lb_error_CAN1.Visible = true;
                    lb_noerr1.Visible = false;
                    uniCAN.Close();
                    gb_CAN1.Enabled = true;
                    gb_MC1.Enabled = true;
                    return;
                }
                Trace.WriteLine("ACK no error");

                _u32 num_of_packets = (size + Const.CAN_MAX_PACKET_SIZE - 1) / Const.CAN_MAX_PACKET_SIZE;
                _u32 last_packet_size = (size % Const.CAN_MAX_PACKET_SIZE > 0 ? size % Const.CAN_MAX_PACKET_SIZE : Const.CAN_MAX_PACKET_SIZE);
                _u32 packets_in_block = Const.PACKETS_IN_BLOCK;

                for (_u32 i = 0; i < num_of_packets; i++)
                {
                    _u32 dlen = ((i == num_of_packets - 1) ? last_packet_size : Const.CAN_MAX_PACKET_SIZE);

                    ClearData();
                    ///// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    frame.id = CAN_MSG_ID_PC2MC;
                    frame.len = (_u8)dlen;
                    for (_u8 ii = 0; ii < dlen; ii++)
                        frame.data[ii] = Buffer[i * Const.CAN_MAX_PACKET_SIZE + ii];

                    if (!uniCAN.Send(ref frame, 200))
                        return;
                    Trace.WriteLine("Send pack ID=0x" + frame.id.ToString("X2"));
                    if ((--packets_in_block) == 0)
                    {
                        packets_in_block = Const.PACKETS_IN_BLOCK;

                        if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                            return;
                        Trace.WriteLine("Recv pack block ID=0x" + frame.id.ToString("X2"));
                        uniCAN.HWReset();
                        get_ack(ref ack, frame.data);
                        if (ack.error_code != Const.CMD_ERR_NO_ERROR)
                        {
                            lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                            lb_error_CAN1.Visible = true;
                            lb_noerr1.Visible = false;
                            uniCAN.Close();
                            gb_CAN1.Enabled = true;
                            gb_MC1.Enabled = true;
                            return;
                        }
                    }
                    _u32 progress = (i + 1) * 100 / num_of_packets;
                    pb_loadMC1.Value = (_s32)progress;
                    bt_loadMC1.Text = "Загрузка..." + progress.ToString() + "%";
                    Application.DoEvents();
                }
                ClearData();
                if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                    return;
                if (frame.id != CAN_MSG_ID_MC2PC)
                {
                    lb_error_CAN1.Text = "Неверный идентификатор пакета";
                    lb_error_CAN1.Visible = true;
                    lb_noerr1.Visible = false;
                    gb_CAN1.Enabled = true;
                    gb_MC1.Enabled = true;
                    return;
                }
                #endregion
            }

            get_ack(ref ack, frame.data);
            if (ack.error_code != Const.CMD_ERR_NO_ERROR)
            {
                lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                lb_error_CAN1.Visible = true;
                lb_noerr1.Visible = false;
                uniCAN.Close();
                gb_CAN1.Enabled = true;
                gb_MC1.Enabled = true;
                return;
            }
            pb_loadMC1.Visible = false;
            lb_Load_OK1.Text = "Микропрограмма успешно загружена";
            chb1_need_reset.Checked = false;
            lb_Load_OK1.Visible = true;
            gb_CAN1.Enabled = true;
            gb_MC1.Enabled = true;
            tb_fnameMC1.Text = "";
            lb_noerr1.Visible = false;
            lb_error_CAN1.Visible = false;
            timer_Error_Boot.Enabled = false;
            bt_loadMC1.Text = "Загрузить файл";
            //MessageBox.Show("Микропрограмма успешно загружена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            uniCAN.Recv_Disable();
            uniCAN.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сброс ОЛО - " + (1.0 - 1 * 0.2).ToString("F1", CultureInfo.InvariantCulture) + " c");
        }
        #endregion
        #region Кнопка Запустить
        private void bt_runMC_Click(object sender, EventArgs e)
        {
            //if (uniCAN != null)
            //    if (uniCAN.Is_Open)
            //    {
            //        uniCAN.Recv_Disable();
            //        uniCAN.Close();
            //    }
            if (cb_CAN1.SelectedItem.ToString() == "No CAN" || cb_CAN1.Items.Count < 1)
                return;
            if (cb_CAN1.SelectedItem.ToString() == "USB Marathon")
            {
                marCAN = new MCANConverter();
                uniCAN = marCAN as MCANConverter;
            }
            else if (cb_CAN1.SelectedItem.ToString() == "PCI Advantech")
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
            state_Ready();
            lb_error_CAN1.Visible = false;
            uniCAN.Port = 0;
            uniCAN.Speed = 2;
            if (!uniCAN.Open())
            {
                lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                lb_error_CAN1.Visible = true;
                lb_noerr1.Visible = false;
                return;
            }
            //            timer_Error_Boot.Enabled = true;
            uniCAN.Recv_Enable();
            lb_noerr1.Text = uniCAN.Info;
            frame.data = new Byte[8];
            ClearData();

            pb_loadMC1.Visible = true;
            pb_loadMC1.Value = 0;

            _u8 crc8 = 0;
            for (int i = 0; i < size; i++)
                crc8 += Buffer[i];

            ClearData();
            frame.id = Const.CAN_MSG_ID_PC2MC;
            frame.len = 8;

            //                PACKET_CMD* cmd = (PACKET_CMD*)msg.data;
            cmd.command = Const.COMMAND_EXECUTE_USER_CODE;
            set_cmd(cmd, ref frame.data);

            if (!uniCAN.Send(ref frame, 2000))
                return;

            if (uniCAN == null || !uniCAN.Recv(ref frame, 2000))
                return;

            if (frame.id != Const.CAN_MSG_ID_MC2PC)
            {
                lb_error_CAN1.Text = "Неверный идентификатор пакета";
                lb_error_CAN1.Visible = true;
                lb_noerr1.Visible = false;
                return;
            }

            get_ack(ref ack, frame.data);
            if (ack.error_code != Const.CMD_ERR_NO_ERROR)
            {
                lb_error_CAN1.Text = GetAcknowledgeErrorString(ack);
                lb_error_CAN1.Visible = true;
                lb_noerr1.Visible = false;
                return;
            }

            lb_Load_OK1.Text = "Микропрограмма успешно запущена";
            lb_Load_OK1.Visible = true;
            uniCAN.Recv_Disable();
            uniCAN.Close();
        }
        #endregion
        #region Обработка радиобатонов
        private void rb_cmos12_select_long_time_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_cmos12_select_long_time.Checked)
            {
                rb_cmos12_select_long_time.BackColor = SystemColors.ActiveCaption;
                Buffer = new _u8[FWDATA.SOLO2_SELECT_LONG_size];
                Buffer = (_u8[])FWDATA.SOLO2_SELECT_LONG;
                size = (uint)Buffer.Length;
                bt_loadMC1.Enabled = true;
                chb_eraseALL1.Enabled = true;
            }
            else
            {
                rb_cmos12_select_long_time.BackColor = Color.Transparent;
            }

        }
        private void rb_cmos12_select_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_cmos12_select.Checked)
            {
                rb_cmos12_select.BackColor = SystemColors.ActiveCaption;
                Buffer = new _u8[FWDATA.SOLO2_SELECT_size];
                Buffer = (_u8[])FWDATA.SOLO2_SELECT;
                size = (uint)Buffer.Length;
                bt_loadMC1.Enabled = true;
                chb_eraseALL1.Enabled = true;
            }
            else
            {
                rb_cmos12_select.BackColor = Color.Transparent;
            }
        }
        private void rb_flight_left_wing_double_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_flight_left_wing_double_pass.Checked)
            {
                Buffer = new _u8[FWDATA.SOLO2_FLIGHT_LEFT_size];
                Buffer = (_u8[])FWDATA.SOLO2_FLIGHT_LEFT;
                size = (uint)Buffer.Length;
                bt_loadMC1.Enabled = true;
                chb_eraseALL1.Enabled = true;
                rb_flight_left_wing_double_pass.BackColor = SystemColors.ActiveCaption;
            }
            else
            {
                rb_flight_left_wing_double_pass.BackColor = Color.Transparent;
            }
        }
        private void rb_flight_right_wing_double_pass_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_flight_right_wing_double_pass.Checked)
            {
                rb_flight_right_wing_double_pass.BackColor = SystemColors.ActiveCaption;
                Buffer = new _u8[FWDATA.SOLO2_FLIGHT_RIGHT_size];
                Buffer = (_u8[])FWDATA.SOLO2_FLIGHT_RIGHT;
                size = (uint)Buffer.Length;
                bt_loadMC1.Enabled = true;
                chb_eraseALL1.Enabled = true;
            }
            else
            {
                rb_flight_right_wing_double_pass.BackColor = Color.Transparent;
            }
        }
        private void rb_file_open_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_file_open.Checked)
            {
                rb_file_open.BackColor = SystemColors.ActiveCaption;
                bt_loadMC1.Enabled = false;
                chb_eraseALL1.Enabled = false;
            }
            else
            {
                rb_file_open.BackColor = Color.Transparent;
            }
        }
        private void rb_cmos12_select_long_time2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_cmos12_select_long_time2.Checked)
            {
                rb_cmos12_select_long_time2.BackColor = SystemColors.ActiveCaption;
                Buffer = new _u8[FWDATA.SELECT_LONG_TIME_V2_size];
                Buffer = (_u8[])FWDATA.SELECT_LONG_TIME_V2;
                size = (uint)Buffer.Length;
                bt_loadMC1.Enabled = true;
                chb_eraseALL1.Enabled = true;
            }
            else
            {
                rb_cmos12_select_long_time2.BackColor = Color.Transparent;
            }

        }
        private void rb_cmos12_select2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_cmos12_select2.Checked)
            {
                rb_cmos12_select2.BackColor = SystemColors.ActiveCaption;
                Buffer = new _u8[FWDATA.SOLO2_SELECT_V2_size];
                Buffer = (_u8[])FWDATA.SOLO2_SELECT_V2;
                size = (uint)Buffer.Length;
                bt_loadMC1.Enabled = true;
                chb_eraseALL1.Enabled = true;
            }
            else
            {
                rb_cmos12_select2.BackColor = Color.Transparent;
            }
        }
        private void rb_new_RUP_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_new_RUP.Checked)
            {
                rb_new_RUP.BackColor = SystemColors.ActiveCaption;
                Buffer = new _u8[FWDATA.app_bootloader_to_RUP_style_size];
                Buffer = (_u8[])FWDATA.app_bootloader_to_RUP_style;
                size = (uint)Buffer.Length;
                bt_loadMC1.Enabled = true;
                chb_eraseALL1.Enabled = true;
            }
            else
            {
                rb_new_RUP.BackColor = Color.Transparent;
            }
        }
        private void rb_flight_universal_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_flight_universal.Checked)
            {
                rb_flight_universal.BackColor = SystemColors.ActiveCaption;
                Buffer = new _u8[FWDATA.FLIGHT_U_2_2_3_size];
                Buffer = (_u8[])FWDATA.FLIGHT_U_2_2_3;
                size = (uint)Buffer.Length;
                bt_loadMC1.Enabled = true;
                chb_eraseALL1.Enabled = true;
            }
            else
            {
                rb_flight_universal.BackColor = Color.Transparent;
            }
        }
        #endregion
        private void timer_Error_Boot_Tick(object sender, EventArgs e)
        {
            lb_error_CAN1.Text = "Ошибка!!!";
            lb_error_CAN1.Visible = true;
            lb_noerr1.Visible = false;
            lb_noerr1.Visible = false;
            bt_About1.Enabled = true;
            bt_Exit1.Enabled = true;
            gb_CAN1.Enabled = true;
            gb_MC1.Enabled = true;
            timer_Error_Boot.Enabled = false;
        }
        void get_ack(ref PACKET_ACK aa, _u8[] data)
        {
            aa.error_code = data[0];
            aa.iap_error_code = data[1];
        }
        void set_cmd(PACKET_CMD aa, ref _u8[] data)
        {
            IntPtr buf = Marshal.AllocHGlobal(Marshal.SizeOf(aa));
            Marshal.StructureToPtr(aa, buf, false);
            Marshal.Copy(buf, data, 0, Marshal.SizeOf(aa));
            Marshal.FreeHGlobal(buf);
        }
        void ClearData()
        {
            Array.Clear(frame.data, 0, 8);
            frame.flags = 0;
            frame.id = 0;
            frame.len = 0;
        }
        void CD(ref canmsg_t aa)
        {
            Array.Clear(aa.data, 0, 8);
            aa.flags = 0;
            aa.id = 0;
            aa.len = 0;
        }
        #region Выдача ошибок
        String GetAcknowledgeErrorString(PACKET_ACK ac)
        {
            String err_str = "";
            switch (ac.error_code)
            {
                case Const.CMD_ERR_NO_ERROR:
                    err_str = "Нет ошибки";
                    break;

                case Const.CMD_ERR_INVALID_FIRMWARE_SIZE:
                    err_str = "Недопустимая длина микропрограммы";
                    break;

                case Const.CMD_ERR_IAP_ERROR:
                    switch (ac.iap_error_code)
                    {
                        case Const.IAP_ERR_CMD_SUCCESS:
                            err_str = "IAP - Нет ошибки";
                            break;
                        case Const.IAP_ERR_INVALID_COMMAND:
                            err_str = "IAP - Неверная команда";
                            break;
                        case Const.IAP_ERR_SRC_ADDR_ERROR:
                            err_str = "IAP - Адрес источника не выровнен по границе слова";
                            break;
                        case Const.IAP_ERR_DST_ADDR_ERROR:
                            err_str = "IAP - Адрес приемника не выровнен по необходимой величине";
                            break;
                        case Const.IAP_ERR_SRC_ADDR_NOT_MAPPED:
                            err_str = "IAP - Адрес источника (с учетом счетчика байт) выходит за пределы памяти";
                            break;
                        case Const.IAP_ERR_DST_ADDR_NOT_MAPPED:
                            err_str = "IAP - Адрес приемника (с учетом счетчика байт) выходит за пределы памяти";
                            break;
                        case Const.IAP_ERR_COUNT_ERROR:
                            err_str = "IAP - Счетчик байт не кратен 4 или имеет недопустимое значение";
                            break;
                        case Const.IAP_ERR_INVALID_SECTOR:
                            err_str = "IAP - Неверный номер сектора или адрес последнего сектора меньше адреса первого";
                            break;
                        case Const.IAP_ERR_SECTOR_NOT_BLANK:
                            err_str = "IAP - Сектор не был предварительно очищен";
                            break;
                        case Const.IAP_ERR_SECTOR_NOT_PREPARED_FOR_WRITE_OPERATION:
                            err_str = "IAP - Сектор не был подготовлен для операции записи";
                            break;
                        case Const.IAP_ERR_COMPARE_ERROR:
                            err_str = "IAP - Данные источника и приемника не совпадают";
                            break;
                        case Const.IAP_ERR_BUSY:
                            err_str = "IAP - Интерфейс аппаратного программирования занят";
                            break;
                        default:
                            err_str = "IAP - Неизвестный код ошибки: " + ac.iap_error_code.ToString();
                            break;
                    }
                    break;

                case Const.CMD_ERR_USER_CODE_NOT_PRESENT:
                    err_str = "В устройстве отсутствует микропрограмма";
                    break;

                case Const.CMD_ERR_CRC8_ERROR:
                    err_str = "Неверная контрольная сумма микропрограммы (CRC8)";
                    break;

                default:
                    err_str = "Неизвестный код ошибки: " + ac.error_code.ToString();
                    break;
            }
            return err_str;
        }
        #endregion
        #endregion
    }
}
