using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
//using System.Drawing.Imaging;
//using System.IO;
//using System.Threading;
//using System.Drawing.Drawing2D;
//using System.Reflection;
using System.Diagnostics;
//using TM = System.Timers;
//using System.Globalization;
//using System.Security.Cryptography;

namespace OLO_CAN
{
    public partial class Form1 : Form
    {
        #region принты разные
        void print2_msg(canmsg_t msg)
        {
            Trace.Write(" ID=" + ((rup_id.IDs)(msg.id - (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID))).ToString() + " len=" + msg.len.ToString());
            Trace.Write(" Data:");
            for (int i = 0; i < msg.len; i++)
                Trace.Write(" 0x" + msg.data[i].ToString("X2"));
            Trace.WriteLine("");
            if (msg.id - (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID) == rup_id.ACK_ID)
            {
                Trace.Write(" Команда " + ((rup_id.Comm)(msg.data[0] & 0x3F)).ToString());
                Trace.Write(" Состояние " + ((rup_id.Receipt)(msg.data[0] >> 6)).ToString());
            }
            if (msg.id - (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID) == rup_id.STATUS_RESPONCE_ID)
            {
                Trace.Write(" Режим " + ((rup_id.Mode)(msg.data[0] & 0x3)).ToString());
                Trace.Write(" Команда " + ((rup_id.Comm)(msg.data[2] & 0x3F)).ToString());
                Trace.Write(" Состояние " + ((rup_id.Receipt)(msg.data[2] >> 6)).ToString());
            }
            if (msg.id - (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID) == rup_id.FLASH_TABLE_RESPONCE_ID)
            {
                Trace.Write(" Начальный адрес " + (BitConverter.ToUInt32(msg.data, 0)).ToString("X8"));
                Trace.Write(" Размер " + (BitConverter.ToInt32(msg.data, 4)).ToString("X8"));
            }
            if (msg.id - (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID) == rup_id.FILE_TABLE_ADDRESS_ID)
            {
                Trace.Write(" Адрес таблицы файлов " + (BitConverter.ToUInt32(msg.data, 0)).ToString("X8"));
            }
            Trace.WriteLine("");
        }
        void msg_2_log(canmsg_t msg)
        {
            text2rtb(" ID=" + ((rup_id.IDs)(msg.id - (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID))).ToString() + " len=" + msg.len.ToString());
            String tttt = " Data:";
            for (int i = 0; i < msg.len; i++)
                tttt += " 0x" + msg.data[i].ToString("X2");
            text2rtb(tttt);
            if (msg.id - (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID) == rup_id.ACK_ID)
            {
                text2rtb(" Команда " + ((rup_id.Comm)(msg.data[0] & 0x3F)).ToString() +
                    " Состояние " + ((rup_id.Receipt)(msg.data[0] >> 6)).ToString());
            }
            if (msg.id - (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID) == rup_id.STATUS_RESPONCE_ID)
            {
                text2rtb(" Режим " + ((rup_id.Mode)(msg.data[0] & 0x3)).ToString() +
                    " Команда " + ((rup_id.Comm)(msg.data[2] & 0x3F)).ToString() +
                    " Состояние " + ((rup_id.Receipt)(msg.data[2] >> 6)).ToString());
            }
            if (msg.id - (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID) == rup_id.FLASH_TABLE_RESPONCE_ID)
            {
                text2rtb(" Начальный адрес " + (BitConverter.ToUInt32(msg.data, 0)).ToString("X8") +
                    " Размер " + (BitConverter.ToInt32(msg.data, 4)).ToString("X8"));
            }
            if (msg.id - (rb_r5.Checked ? rup_id.RIGHT_WING_DEV_ID : rup_id.LEFT_WING_DEV_ID) == rup_id.FILE_TABLE_ADDRESS_ID)
            {
                text2rtb(" Адрес таблицы файлов " + (BitConverter.ToUInt32(msg.data, 0)).ToString("X8"));
            }
        }
        public unsafe void print_cmd(COMMAND cmd, String txt)
        {
            canmsg_t msg = new canmsg_t();
            Trace.WriteLine(txt);
            msg.data = new Byte[8];
            msg.id = Const.CAN_PC2ARM_MSG_ID;
            msg.len = 6;
            Marshal.Copy(new IntPtr(&cmd), msg.data, 0, 8);
            print_msg(msg);
        }
        void print_msg(canmsg_t msg)
        {
            Trace.Write(" ID=" + msg.id.ToString("X2") + " len=" + msg.len.ToString());
            Trace.Write(" Data:");
            for (int i = 0; i < msg.len; i++)
                Trace.Write(" 0x" + msg.data[i].ToString("X2"));
            Trace.WriteLine("");
        }
        void print_msg(msg_t msg)
        {
            Trace.Write(" dID=" + msg.deviceID.ToString("X2") + " mID=" + msg.messageID.ToString("X2") + " len=" + msg.messageLen.ToString());
            Trace.Write(" Data:");
            for (int i = 0; i < msg.messageLen; i++)
                Trace.Write(" 0x" + msg.messageData[i].ToString("X2"));
            Trace.WriteLine("");
        }
         #endregion
    }
}
