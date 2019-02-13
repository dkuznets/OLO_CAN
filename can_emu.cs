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
        #region OLO_Emu
        #region CAN
        private void bt_OpenCAN3_Click(object sender, EventArgs e)
        {
            if (cb_CAN3.SelectedItem.ToString() == "No CAN" || cb_CAN3.Items.Count < 1)
                return;
            if (cb_CAN3.SelectedItem.ToString() == "USB Marathon")
            {
                marCAN = new MCANConverter();
                uniCAN = marCAN as MCANConverter;
            }
            else if (cb_CAN3.SelectedItem.ToString() == "PCI Advantech")
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
            lb_error_CAN3.Visible = false;
            if (!uniCAN.Open())
            {
                state_Error();
                return;
            }
            state_Ready();
            frame.data = new Byte[8];
            _state = State.OpenedState;
            uniCAN.Recv_Enable();
            Timer_GetData3.Enabled = true;
            gb3_shoot.Enabled = true;
        }
        private void bt_CloseCAN3_Click(object sender, EventArgs e)
        {
            timer_testOLO_R3.Enabled = false;
            timer_testOLO_L3.Enabled = false;
            cb_olo_l_ena.CheckState = CheckState.Unchecked;
            cb_olo_r_ena.CheckState = CheckState.Unchecked;
            if (uniCAN.Is_Open)
            {
                uniCAN.Recv_Disable();
                uniCAN.Close();
            }
            state_NotReady();
            lb_error_CAN3.Visible = false;
            uniCAN.Recv_Disable();
            uniCAN = null;
            Timer_GetData3.Enabled = false;
            chb_R_Err_int.Checked = false;
            chb_R_Err_file.Checked = false;
            chb_R_Err_plis.Checked = false;
            chb_L_Err_int.Checked = false;
            chb_L_Err_file.Checked = false;
            chb_L_Err_plis.Checked = false;
            gb3_shoot.Enabled = false;
        }

        #endregion
        #region Кнопки выстрелов
        private void shoot_l_Click(object sender, EventArgs e)
        {
            msg_t mm = new msg_t();
            mm.deviceID = Const.OLO_Left;
            mm.messageID = msg_t.mID_DATA;

            Random r = new Random();
            mm.messageLen = 8;
            int az, um;
            if (!chb3_shoot_ena.Checked)
            {
                az = r.Next(180 * 60) - 5400;
                um = r.Next(180 * 60) - 5400;
            }
            else
            {
                az = trackBar3_az.Value;
                um = trackBar3_um.Value;
            }
            int dl = r.Next(15000);
            mm.messageData[0] = (Byte)dl;
            mm.messageData[1] = (Byte)(dl >> 8);
            mm.messageData[4] = (Byte)az;
            mm.messageData[5] = (Byte)(az >> 8);
            mm.messageData[6] = (Byte)um;
            mm.messageData[7] = (Byte)(um >> 8);

            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref mmsg, 200))
                return;
            messages.Add(mm);
        }
        private void shoot_r_Click(object sender, EventArgs e)
        {
            msg_t mm = new msg_t();
            mm.deviceID = Const.OLO_Right;
            mm.messageID = msg_t.mID_DATA;

            Random r = new Random();
            mm.messageLen = 8;
            int az, um;
            if (!chb3_shoot_ena.Checked)
            {
                az = r.Next(180 * 60) - 5400;
                um = r.Next(180 * 60) - 5400;
            }
            else
            {
                az = trackBar3_az.Value;
                um = trackBar3_um.Value;
            }
            int dl = r.Next(15000);
            mm.messageData[0] = (Byte)dl;
            mm.messageData[1] = (Byte)(dl >> 8);
            mm.messageData[4] = (Byte)az;
            mm.messageData[5] = (Byte)(az >> 8);
            mm.messageData[6] = (Byte)um;
            mm.messageData[7] = (Byte)(um >> 8);

            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref mmsg, 200))
                return;
            messages.Add(mm);
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            scroll = true;
            chb_dgview3.Text = "Скролл включен";
            dgview3.GridColor = SystemColors.ControlDark;
            chb_dgview3.BackColor = Color.SpringGreen;
            messages.Clear();
            dgview3.Rows.Clear();
        }
        #region Выдача статуса по таймеру
        private void timer_testOLO_L3_Tick(object sender, EventArgs e)
        {
            msg_t mmm = new msg_t();
            mmm.messageID = msg_t.mID_STATUS;
            mmm.deviceID = Const.OLO_Left;
            //отправка статуса по таймеру, интегральная исправность, штатный режим
            mmm.messageData[0] = (Byte)(1 + (chb_L_Err_int.Checked ? 0 : 16) + 32);
            mmm.messageData[1] = 0; //штатный режим
            mmm.messageData[2] = (Byte)((chb_L_Err_plis.Checked ? 0 : 1) + (chb_L_Err_file.Checked ? 0 : 2)); //исправность компонент
            unchecked
            {
                mmm.messageData[3] = (Byte)(-11); //T1
                mmm.messageData[4] = (Byte)(+11); //T2
                mmm.messageData[5] = (Byte)(+31); //T3
            }
            mmm.messageLen = 8;
            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mmm.ToCAN(mmm);
            if (!uniCAN.Send(ref mmsg, 200))
                return;
            messages.Add(mmm);
        }
        private void timer_testOLO_R3_Tick(object sender, EventArgs e)
        {
            msg_t mmm = new msg_t();
            mmm.messageID = msg_t.mID_STATUS;
            mmm.deviceID = Const.OLO_Right;
            //отправка статуса по таймеру, интегральная исправность, штатный режим
            mmm.messageData[0] = (Byte)(1 + (chb_R_Err_int.Checked ? 0 : 16) + 32);
            mmm.messageData[1] = 0; //штатный режим
            mmm.messageData[2] = (Byte)((chb_R_Err_plis.Checked ? 0 : 1) + (chb_R_Err_file.Checked ? 0 : 2)); //исправность компонент
            unchecked
            {
                mmm.messageData[3] = (Byte)(-12); //T1
                mmm.messageData[4] = (Byte)(+12); //T2
                mmm.messageData[5] = (Byte)(+32); //T3
            }
            mmm.messageLen = 8;
            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mmm.ToCAN(mmm);
            if (!uniCAN.Send(ref mmsg, 200))
                return;
            messages.Add(mmm);
        }

        #endregion
        private void Timer_GetData3_Tick(object sender, EventArgs e)
        {
            #region чекбоксы Неисправности
            if (chb_L_Err_plis.Checked || chb_L_Err_file.Checked)
            {
                chb_L_Err_int.Checked = true;
                chb_L_Err_int.ForeColor = Color.White;
                chb_L_Err_int.BackColor = Color.Red;
            }
            else
            {
                chb_L_Err_int.Checked = false;
                chb_L_Err_int.ForeColor = SystemColors.ControlText;
                chb_L_Err_int.BackColor = Color.Transparent;
            }
            if (chb_R_Err_plis.Checked || chb_R_Err_file.Checked)
            {
                chb_R_Err_int.Checked = true;
                chb_R_Err_int.ForeColor = Color.White;
                chb_R_Err_int.BackColor = Color.Red;
            }
            else
            {
                chb_R_Err_int.Checked = false;
                chb_R_Err_int.ForeColor = SystemColors.ControlText;
                chb_R_Err_int.BackColor = Color.Transparent;
            }
            #endregion
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg_t mm = new msg_t();
            msg_t mmm = new msg_t();
            if (uniCAN != null)
            {
                while (uniCAN.VectorSize() > 0)
                {
                    uniCAN.Recv(ref msg, 100);
                    Application.DoEvents();
                    mm = mm.FromCAN(msg);
                    if (mm.deviceID == Const.OLO_Left && cb_olo_l_ena.Checked)
                        messages.Add(mm);
                    if (mm.deviceID == Const.OLO_Right && cb_olo_r_ena.Checked)
                        messages.Add(mm);
                    if (mm.deviceID == Const.OLO_All && (cb_olo_r_ena.Checked || cb_olo_l_ena.Checked))
                        messages.Add(mm);
                }
            }
            for (int i = 0; i < messages.Count; i++)
            {
                Bitmap strelka = null;
                String strelka_s = "";
                Bitmap strelka_LB = Properties.Resources.a_left_Blue;
                Bitmap strelka_RB = Properties.Resources.a_right_Blue;
                Bitmap strelka_LG = Properties.Resources.a_left_Green;
                Bitmap strelka_RG = Properties.Resources.a_right_Green;
                Bitmap strelka_L = Properties.Resources.a_left;
                Bitmap strelka_R = Properties.Resources.a_right;

                if (messages[i].deviceID == Const.OLO_Left)
                    strelka_s = "ОЛО левый";
                else if (messages[i].deviceID == Const.OLO_Right)
                    strelka_s = "ОЛО правый";
                else
                    strelka_s = "Всем ОЛО";
                String mss = "";
                switch (messages[i].messageID)
                {
                    case msg_t.mID_SIMRESET:
                        mss = "Сброс эмулятора" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                        strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                        if (messages[i].deviceID == Const.OLO_Left)
                            cb_olo_l_ena.CheckState = CheckState.Unchecked;
                        else
                            cb_olo_r_ena.CheckState = CheckState.Unchecked;
                        break;

                    case msg_t.mID_RESET:
                        if (messages[i].deviceID != 0)
                        {
                            mss = "Системный сброс" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                            if (messages[i].deviceID == Const.OLO_Left)
                                timer_testOLO_L3.Enabled = false;
                            else
                                timer_testOLO_R3.Enabled = false;
                        }
                        else
                        {
                            mss = "Системный сброс ОЛО";
                            timer_testOLO_L3.Enabled = false;
                            timer_testOLO_R3.Enabled = false;
                            strelka = strelka_R;
                        }
                        break;

                    case msg_t.mID_SYNCTIME:
                        if (messages[i].deviceID != Const.OLO_All)
                        {
                            mss = "Синхронизация времени" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                        }
                        else
                        {
                            mss = "Синхронизация времени ОЛО";
                            strelka = strelka_R;
                        }
                        break;

                    case msg_t.mID_REQTIME:
                        mss = "Запрос времени" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                        strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                        if (messages[i].deviceID == Const.OLO_Left)
                        {
                            mmm.messageID = msg_t.mID_GETTIME;
                            mmm.deviceID = Const.OLO_Left;
                            mmm.messageData = BitConverter.GetBytes(ConvertToUnixTimestamp(DateTime.Now));
                            mmm.messageLen = 8;
                            canmsg_t mmsg = new canmsg_t();
                            mmsg.data = new Byte[8];
                            mmsg = mmm.ToCAN(mmm);
                            if (!uniCAN.Send(ref mmsg, 200))
                                return;
                            messages.Add(mmm);
                        }
                        else
                        {
                            mmm.messageID = msg_t.mID_GETTIME;
                            mmm.deviceID = Const.OLO_Right;
                            mmm.messageData = BitConverter.GetBytes(ConvertToUnixTimestamp(DateTime.Now));
                            mmm.messageLen = 8;
                            canmsg_t mmsg = new canmsg_t();
                            mmsg.data = new Byte[8];
                            mmsg = mmm.ToCAN(mmm);
                            if (!uniCAN.Send(ref mmsg, 200))
                                return;
                            messages.Add(mmm);
                        }

                        break;

                    case msg_t.mID_GETTIME:
                        DateTime dt = ConvertFromUnixTimestamp(BitConverter.ToUInt64(messages[i].messageData, 0));
                        if (messages[i].deviceID != Const.OLO_All)
                        {
                            mss = "Время" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П") + " " + dt.ToShortDateString() + " " + dt.ToLongTimeString();
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_LB : strelka_LG;
                        }
                        else
                        {
                            mss = "Синхронизация времени ОЛО";
                            strelka = strelka_L;
                        }
                        break;

                    case msg_t.mID_MODULE:
                        if (messages[i].deviceID != Const.OLO_All)
                        {
                            mss = "Режим модуля" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                        }
                        else
                        {
                            mss = "Режим модуля ОЛО";
                            strelka = strelka_R;
                        }
                        break;

                    case msg_t.mID_SOER:
                        if (messages[i].deviceID != Const.OLO_All)
                        {
                            mss = "Режим СОЭР" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                        }
                        else
                        {
                            mss = "Режим СОЭР ОЛО";
                            strelka = strelka_R;
                        }
                        break;

                    case msg_t.mID_PROG:
                        if (messages[i].deviceID != Const.OLO_All)
                        {
                            mss = "Режим программирования" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                        }
                        else
                        {
                            mss = "Режим программирования ОЛО";
                            strelka = strelka_R;
                        }
                        break;

                    case msg_t.mID_STATREQ:
                        if (messages[i].deviceID != Const.OLO_All)
                        {
                            mss = "Запрос статуса" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                            if (messages[i].messageData[4] == 1 || messages[i].messageData[4] == 3) // Включение автоматической выдачи статуса 
                            {
                                if (messages[i].deviceID == Const.OLO_Left)
                                {
                                    timer_testOLO_L3.Interval = (int)period(BitConverter.ToUInt32(messages[i].messageData, 0));
                                    timer_testOLO_L3.Enabled = true;
                                }
                                else
                                {
                                    timer_testOLO_R3.Interval = (int)period(BitConverter.ToUInt32(messages[i].messageData, 0));
                                    timer_testOLO_R3.Enabled = true;
                                }
                            }
                            else // Выдача статуса по запросу
                            {
                                if (messages[i].deviceID == Const.OLO_Left)
                                {
                                    timer_testOLO_L3.Enabled = false;
                                    mmm.messageID = msg_t.mID_STATUS;
                                    mmm.deviceID = Const.OLO_Left;
                                    //отправка статуса по запросу, интегральная исправность, штатный режим
                                    mmm.messageData[0] = (Byte)(0 + (chb_L_Err_int.Checked ? 0 : 16) + 32);
                                    mmm.messageData[1] = 0; //штатный режим
                                    mmm.messageData[2] = (Byte)((chb_L_Err_plis.Checked ? 0 : 1) + (chb_L_Err_file.Checked ? 0 : 2)); //исправность компонент
                                    unchecked
                                    {
                                        mmm.messageData[3] = (Byte)(-11); //T1
                                        mmm.messageData[4] = (Byte)(+11); //T2
                                        mmm.messageData[5] = (Byte)(+31); //T3
                                    }
                                    mmm.messageLen = 8;
                                    canmsg_t mmsg = new canmsg_t();
                                    mmsg.data = new Byte[8];
                                    mmsg = mmm.ToCAN(mmm);
                                    if (!uniCAN.Send(ref mmsg, 200))
                                        return;
                                    messages.Add(mmm);
                                }
                                else
                                {
                                    timer_testOLO_R3.Enabled = false;
                                    mmm.messageID = msg_t.mID_STATUS;
                                    mmm.deviceID = Const.OLO_Right;
                                    //отправка статуса по запросу, интегральная исправность, штатный режим
                                    mmm.messageData[0] = (Byte)(0 + (chb_R_Err_int.Checked ? 0 : 16) + 32);
                                    mmm.messageData[1] = 0; //штатный режим
                                    mmm.messageData[2] = (Byte)((chb_R_Err_plis.Checked ? 0 : 1) + (chb_R_Err_file.Checked ? 0 : 2)); //исправность компонент
                                    unchecked
                                    {
                                        mmm.messageData[3] = (Byte)(-12); //T1
                                        mmm.messageData[4] = (Byte)(+12); //T2
                                        mmm.messageData[5] = (Byte)(+32); //T3
                                    }
                                    mmm.messageLen = 8;
                                    canmsg_t mmsg = new canmsg_t();
                                    mmsg.data = new Byte[8];
                                    mmsg = mmm.ToCAN(mmm);
                                    if (!uniCAN.Send(ref mmsg, 200))
                                        return;
                                    messages.Add(mmm);
                                }
                            }
                        }
                        else
                        {
                            mss = "Запрос статуса ОЛО";
                            strelka = strelka_R;
                            if (messages[i].messageData[4] == 1 || messages[i].messageData[4] == 3)
                            {
                                if (cb_olo_l_ena.Checked)
                                {
                                    timer_testOLO_L3.Interval = (int)period(BitConverter.ToUInt32(messages[i].messageData, 0));
                                    timer_testOLO_L3.Enabled = true;
                                }
                                if (cb_olo_r_ena.Checked)
                                {
                                    timer_testOLO_R3.Interval = (int)period(BitConverter.ToUInt32(messages[i].messageData, 0));
                                    timer_testOLO_R3.Enabled = true;
                                }
                            }
                            else
                            {
                                if (cb_olo_l_ena.Checked)
                                {
                                    timer_testOLO_L3.Enabled = false;
                                    mmm.messageID = msg_t.mID_STATUS;
                                    mmm.deviceID = Const.OLO_Left;
                                    //отправка статуса по запросу, интегральная исправность, штатный режим
                                    mmm.messageData[0] = (Byte)(0 + (chb_L_Err_int.Checked ? 0 : 16) + 32);
                                    mmm.messageData[1] = 0; //штатный режим
                                    mmm.messageData[2] = (Byte)((chb_L_Err_plis.Checked ? 0 : 1) + (chb_L_Err_file.Checked ? 0 : 2)); //исправность компонент
                                    unchecked
                                    {
                                        mmm.messageData[3] = (Byte)(-11); //T1
                                        mmm.messageData[4] = (Byte)(+11); //T2
                                        mmm.messageData[5] = (Byte)(+31); //T3
                                    }
                                    mmm.messageLen = 8;
                                    canmsg_t mmsg = new canmsg_t();
                                    mmsg.data = new Byte[8];
                                    mmsg = mmm.ToCAN(mmm);
                                    if (!uniCAN.Send(ref mmsg, 200))
                                        return;
                                    messages.Add(mmm);
                                }
                                if (cb_olo_r_ena.Checked)
                                {
                                    timer_testOLO_R3.Enabled = false;
                                    mmm.messageID = msg_t.mID_STATUS;
                                    mmm.deviceID = Const.OLO_Right;
                                    //отправка статуса по запросу, интегральная исправность, штатный режим
                                    mmm.messageData[0] = (Byte)(0 + (chb_R_Err_int.Checked ? 0 : 16) + 32);
                                    mmm.messageData[1] = 0; //штатный режим
                                    mmm.messageData[2] = (Byte)((chb_R_Err_plis.Checked ? 0 : 1) + (chb_R_Err_file.Checked ? 0 : 2)); //исправность компонент
                                    unchecked
                                    {
                                        mmm.messageData[3] = (Byte)(-12); //T1
                                        mmm.messageData[4] = (Byte)(+12); //T2
                                        mmm.messageData[5] = (Byte)(+32); //T3
                                    }
                                    mmm.messageLen = 8;
                                    canmsg_t mmsg = new canmsg_t();
                                    mmsg.data = new Byte[8];
                                    mmsg = mmm.ToCAN(mmm);
                                    if (!uniCAN.Send(ref mmsg, 200))
                                        return;
                                    messages.Add(mmm);
                                }
                            }
                        }
                        break;

                    case msg_t.mID_DATA:
                        int az = BitConverter.ToInt16(messages[i].messageData, 4);
                        int um = BitConverter.ToInt16(messages[i].messageData, 6);
                        //mss = "Азимут = " + (az / 60).ToString("0'°'") + (az % 60).ToString() + "' " +
                        //      "Угол = " + (um / 60).ToString("0'°'") + (um % 60).ToString() + "'";
                        if (az >= 0)
                            mss = "Азимут = " + (az / 60).ToString("0'°'") + (az % 60).ToString() + "' ";
                        else
                            mss = "Азимут = -" + (Math.Abs(az) / 60).ToString("0'°'") + (Math.Abs(az) % 60).ToString() + "' ";
                        if (um >= 0)
                            mss += "Угол = " + (um / 60).ToString("0'°'") + (um % 60).ToString() + "'";
                        else
                            mss += "Угол = -" + (Math.Abs(um) / 60).ToString("0'°'") + (Math.Abs(um) % 60).ToString() + "'";
                        Shots sh = new Shots();
                        sh.bort = (messages[i].deviceID == Const.OLO_Left) ? (Byte)0 : (Byte)1;
                        sh.azimut = BitConverter.ToInt16(messages[i].messageData, 4);
                        sh.ugol = BitConverter.ToInt16(messages[i].messageData, 6);
                        list_shots.Add(sh);
                        //label3.Text = list_shots.Count.ToString();
                        if (timer_Reset_Shots3.Enabled == false)
                        {
                            timer_Reset_Shots3.Enabled = true;
                            panel3.Refresh();
                        }
                        else
                        {
                            timer_Reset_Shots3.Enabled = false;
                            timer_Reset_Shots3.Enabled = true;
                            panel3.Refresh();
                        }
                        strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_LB : strelka_LG;
                        break;

                    case msg_t.mID_STATUS:
                        mss = "T1=" + ((SByte)messages[i].messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                            "T2=" + ((SByte)messages[i].messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                            "T3=" + ((SByte)messages[i].messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                        strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_LB : strelka_LG;
                        break;

                }
                String rawdata = "";
                for (int j = 0; j < messages[i].messageLen; j++)
                    rawdata += messages[i].messageData[j].ToString("X2") + " ";

                if (scroll)
                {
                    if (dgview3.RowCount >= 100)
                        dgview3.Rows.Clear();
                    dgview3.Rows.Add(strelka, strelka_s, rawdata, mss, DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff"), messages[i].messageID.ToString("X2"));
                    dgview3.FirstDisplayedScrollingRowIndex = dgview3.Rows.Count - 1;
                    if (dgview3.Rows[dgview3.Rows.Count - 1].Cells[5].Value.ToString() == "2D")
                        dgview3.Rows[dgview3.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Orange;
                }

                //if (dgview.Rows[dgview.Rows.Count - 1].Cells[1].Value.ToString() == "ОЛО левый" && dgview.Rows[dgview.Rows.Count - 1].Cells[5].Value.ToString() != "2D")
                //    dgview.Rows[dgview.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                //if (dgview.Rows[dgview.Rows.Count - 1].Cells[1].Value.ToString() == "ОЛО правый" && dgview.Rows[dgview.Rows.Count - 1].Cells[5].Value.ToString() != "2D")
                //    dgview.Rows[dgview.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            if (scroll)
                messages.Clear();
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            if (!chb4_nopaint.Checked)
            {
                Graphics gr = e.Graphics;
                Pen p = new Pen(Color.Blue, 1);// цвет линии и ширина
                gr.FillEllipse(new SolidBrush(Color.White), 0, 0, 199, 199);
                gr.DrawEllipse(p, 0, 0, 199, 199);

                for (int i = 0; i < 12; i++)
                {
                    Point p1 = new Point(99, 99);// первая точка
                    int x = (int)(99 * Math.Cos((Double)(i * 30 * Math.PI / 180)));
                    int y = (int)(99 * Math.Sin((Double)(i * 30 * Math.PI / 180)));
                    Point p2 = new Point(x + 99, y + 99);// вторая точка
                    gr.DrawLine(p, p1, p2);// рисуем линию
                }

                if (list_shots.Count > 0)
                {
                    foreach (var it in list_shots)
                    {
                        int x = 0, y = 0;
                        int z = 0;
                        // костылик, мля... лениво думать...
                        int ugol = it.ugol + 5400, azimut = it.azimut + 5400;

                        if ((ugol / 60) <= 90)
                            z = (int)(ugol / 60 * Math.Sin(ugol / 60 * Math.PI / 180));
                        else
                            z = (int)((180 - ugol / 60) * Math.Sin((180 - ugol / 60) * Math.PI / 180));
                        if (it.bort == 1)
                        {
                            x = (int)(z * Math.Cos((Double)((azimut - 90 * 60) / 60 * Math.PI / 180)));
                            y = (int)(z * Math.Sin((Double)((azimut - 90 * 60) / 60 * Math.PI / 180)));
                        }
                        else
                        {
                            x = (int)(z * Math.Cos((Double)(-(azimut + 90 * 60) / 60 * Math.PI / 180)));
                            y = (int)(z * Math.Sin((Double)(-(azimut + 90 * 60) / 60 * Math.PI / 180)));
                        }
                        gr.FillEllipse(new SolidBrush(Color.Red), x + 99 - 5, y + 99 - 5, 10, 10);
                    }
                }
                gr.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
            }
        }
        private void timer_Reset_Shots3_Tick(object sender, EventArgs e)
        {
            timer_Reset_Shots3.Enabled = false;
            list_shots.Clear();
            //label3.Text = list_shots.Count.ToString();
            panel3.Refresh();
        }
        private void cb_olo_l_ena_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_olo_l_ena.Checked)
            {
                cb_olo_l_ena.Text = "Эмуляция включена";
                shoot_l.Enabled = true;
                chb_L_Err_int.Enabled = true;
                chb_L_Err_file.Enabled = true;
                chb_L_Err_plis.Enabled = true;
                label26.Enabled = true;
                //                timer_testOLO_L.Enabled = false;
            }
            else
            {
                cb_olo_l_ena.Text = "Эмуляция выключена";
                shoot_l.Enabled = false;
                timer_testOLO_L.Enabled = false;
                label26.Enabled = false;
                chb_L_Err_int.Enabled = false;
                chb_L_Err_file.Enabled = false;
                chb_L_Err_plis.Enabled = false;
                chb_L_Err_int.Checked = false;
                chb_L_Err_file.Checked = false;
                chb_L_Err_plis.Checked = false;
            }
        }
        private void cb_olo_r_ena_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_olo_r_ena.Checked)
            {
                cb_olo_r_ena.Text = "Эмуляция включена";
                shoot_r.Enabled = true;
                chb_R_Err_int.Enabled = true;
                chb_R_Err_file.Enabled = true;
                chb_R_Err_plis.Enabled = true;
                label27.Enabled = true;
            }
            else
            {
                shoot_r.Enabled = false;
                cb_olo_r_ena.Text = "Эмуляция выключена";
                timer_testOLO_R.Enabled = false;
                chb_R_Err_int.Enabled = false;
                chb_R_Err_file.Enabled = false;
                chb_R_Err_plis.Enabled = false;
                chb_R_Err_int.Checked = false;
                chb_R_Err_file.Checked = false;
                chb_R_Err_plis.Checked = false;
                label27.Enabled = false;
            }
        }
        uint period(uint tt)
        {
            if (tt < 0x3E000000)
                return 32000; // 32c
            //return 0x3D000000;
            if (tt >= 0x3E000000 && tt < 0x3F000000)
                return 8000; // 8c
            //return 0x3E000000;
            if (tt >= 0x3F000000 && tt < 0x3F7FFFFF)
                return 2000; // 2c
            //return 0x3F000000;
            if (tt >= 0x3F7FFFFF && tt < 0x40000000)
                return 1000; // 1c
            //return 0x3F7FFFFF;
            if (tt >= 0x40000000 && tt < 0x41000000)
                return 500; // 500mc
            //return 0x40000000;
            if (tt >= 0x41000000)
                return 125; // 125mc
            //return 0x41000000;
            return 0x3F7FFFFF; // 1c
        }
        private void dgview3_Click(object sender, EventArgs e)
        {
            if (!scroll)
            {
                scroll = true;
                chb_dgview3.Text = "Скролл включен";
                dgview3.GridColor = SystemColors.ControlDark;
            }
            else
            {
                scroll = false;
                chb_dgview3.Text = "Скролл выключен";
                dgview3.GridColor = Color.Blue;
            }
        }
        private void chb_dgview3_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_dgview3.Checked)
            {
                chb_dgview3.Text = "Скролл включен";
                scroll = true;
                chb_dgview3.BackColor = Color.SpringGreen;
            }
            else
            {
                chb_dgview3.Text = "Скролл выключен";
                scroll = false;
                chb_dgview3.BackColor = Color.OrangeRed;
            }
        }
        private void trackBar3_az_Scroll(object sender, EventArgs e)
        {
            lb3_shoot_az_val.Text = (trackBar3_az.Value / 60).ToString("0'°'") + (trackBar3_az.Value % 60).ToString() + "' ";
        }
        private void trackBar3_um_Scroll(object sender, EventArgs e)
        {
            lb3_shoot_um_val.Text = (trackBar3_um.Value / 60).ToString("0'°'") + (trackBar3_um.Value % 60).ToString() + "' ";
        }
        private void chb3_shoot_ena_CheckedChanged(object sender, EventArgs e)
        {
            if (chb3_shoot_ena.Checked)
            {
                lb3_shoot_az_val.Enabled = true;
                lb3_freq_val.Enabled = true;
                lb3_freq_txt.Enabled = true;
                lb3_shoot_um_val.Enabled = true;
                lb3_shoot_az_txt.Enabled = true;
                lb3_shoot_um_txt.Enabled = true;
                if (trackBar3_az.Value >= 0)
                    lb3_shoot_az_val.Text = (trackBar3_az.Value / 60).ToString("0'°'") + (trackBar3_az.Value % 60).ToString() + "' ";
                else
                    lb3_shoot_az_val.Text = "-" + (Math.Abs(trackBar3_az.Value) / 60).ToString("0'°'") + (Math.Abs(trackBar3_az.Value) % 60).ToString() + "' ";
                if (trackBar3_um.Value >= 0)
                    lb3_shoot_um_val.Text = (trackBar3_um.Value / 60).ToString("0'°'") + (trackBar3_um.Value % 60).ToString() + "' ";
                else
                    lb3_shoot_um_val.Text = "-" + (Math.Abs(trackBar3_um.Value) / 60).ToString("0'°'") + (Math.Abs(trackBar3_um.Value) % 60).ToString() + "' ";

                trackBar3_az.Enabled = true;
                trackBar3_um.Enabled = true;
                trackBar1.Enabled = true;
                lb3_freq_val.Text = (trackBar1.Value * 10).ToString() + " Гц";
            }
            else
            {
                lb3_shoot_az_val.Enabled = false;
                lb3_shoot_um_val.Enabled = false;
                lb3_shoot_az_txt.Enabled = false;
                lb3_shoot_um_txt.Enabled = false;
                lb3_freq_val.Enabled = false;
                lb3_freq_txt.Enabled = false;
                trackBar3_az.Enabled = false;
                trackBar3_um.Enabled = false;
                trackBar1.Enabled = false;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lb3_freq_val.Text = (trackBar1.Value * 10).ToString() + " Гц";
            //            tm4_test.Interval = 1000 / trackBar1.Value;
        }
        private void chb4_enshl_CheckedChanged(object sender, EventArgs e)
        {
            if (chb4_enshl.Checked)
            {
                //                tm4_counter.Interval = 1000 / trackBar1.Value;
                //                if (trackBar1.Value < 30) 
                //                    tm4_autoshl.Interval = 1000 / trackBar1.Value;
                //                else
                //                    tm4_autoshl.Interval = 1000 / 30;
                tm4_autoshl.Enabled = true;
            }
            else
            {
                tm4_autoshl.Enabled = false;
            }
        }
        private void chb4_enshr_CheckedChanged(object sender, EventArgs e)
        {
            if (chb4_enshr.Checked)
            {
                //                tm4_counter.Interval = 1000 / trackBar1.Value;
                //                if (trackBar1.Value < 30)
                //                    tm4_autoshr.Interval = 1000 / trackBar1.Value;
                //                else
                //                    tm4_autoshr.Interval = 1000 / 30;
                tm4_autoshr.Enabled = true;
            }
            else
            {
                tm4_autoshr.Enabled = false;
            }
        }
        private void tm4_autoshl_Tick(object sender, EventArgs e)
        {
            msg_t mm = new msg_t();
            mm.deviceID = Const.OLO_Left;
            mm.messageID = msg_t.mID_DATA;

            Random r = new Random();
            mm.messageLen = 8;
            int az, um;
            if (!chb3_shoot_ena.Checked)
            {
                az = r.Next(180 * 60) - 5400;
                um = r.Next(180 * 60) - 5400;
            }
            else
            {
                az = trackBar3_az.Value;
                um = trackBar3_um.Value;
            }

            count_l += (UInt16)trackBar1.Value;

            mm.messageData[0] = (Byte)count_l;
            mm.messageData[1] = (Byte)(count_l >> 8);
            mm.messageData[2] = (Byte)(trackBar1.Value * 10);
            mm.messageData[3] = (Byte)((trackBar1.Value * 10) >> 8);
            mm.messageData[4] = (Byte)az;
            mm.messageData[5] = (Byte)(az >> 8);
            mm.messageData[6] = (Byte)um;
            mm.messageData[7] = (Byte)(um >> 8);

            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mm.ToCAN(mm);
            if (uniCAN == null || !uniCAN.Send(ref mmsg, 200))
                return;
            messages.Add(mm);
        }
        private void tm4_autoshr_Tick(object sender, EventArgs e)
        {
            msg_t mm = new msg_t();
            mm.deviceID = Const.OLO_Right;
            mm.messageID = msg_t.mID_DATA;

            Random r = new Random();
            mm.messageLen = 8;
            int az, um;
            if (!chb3_shoot_ena.Checked)
            {
                az = r.Next(180 * 60) - 5400;
                um = r.Next(180 * 60) - 5400;
            }
            else
            {
                az = trackBar3_az.Value;
                um = trackBar3_um.Value;
            }

            count_r += (UInt16)trackBar1.Value;

            mm.messageData[0] = (Byte)count_r;
            mm.messageData[1] = (Byte)(count_r >> 8);
            mm.messageData[2] = (Byte)(trackBar1.Value * 10);
            mm.messageData[3] = (Byte)((trackBar1.Value * 10) >> 8);
            mm.messageData[4] = (Byte)az;
            mm.messageData[5] = (Byte)(az >> 8);
            mm.messageData[6] = (Byte)um;
            mm.messageData[7] = (Byte)(um >> 8);

            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mm.ToCAN(mm);
            if (uniCAN == null || !uniCAN.Send(ref mmsg, 200))
                return;
            messages.Add(mm);
        }
        private void tm4_counter_Tick(object sender, EventArgs e)
        {
        }

        private void tm4_test_Tick(object sender, EventArgs e)
        {
        }
        #endregion
    }
}
