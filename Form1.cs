﻿using System;
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

namespace OLO_CAN
{

//    public delegate void MyDelegate(object sender, MyEventArgs e);  
    #region переопределение типов
    using _u8 = System.Byte;
    using _s8 = System.SByte;
    using _u16 = System.UInt16;
    using _s16 = System.Int16;
    using _u32 = System.UInt32;
    using _s32 = System.Int32;
    #endregion
    #region Структуры данных

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct PACKET_CMD
    {
        public _u8 command; // command code
        public _u32 size; // firmware size to be loaded into flash, in bytes
        public _u16 flags; // combination of FLAG_xxx
        public _u8 crc8; // CRC8 value for firmware
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct PACKET_ACK
    {
        public _u8 error_code; // one of CMD_ERR_xxx
        public _u8 iap_error_code; // one of IAP_ERR_xxx if error_code is CMD_ERR_IAP_ERROR
    };
    #endregion
 
	public partial class Form1 : Form
	{
        #region Импорт функций из ДЛЛ

        [DllImport(@"Conv_sk.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Conv_olo_to_ssk(int carrier_type, short[] olo_measures, uint olo_num, float[] ssk);
        [DllImport(@"Conv_sk.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Conv_ssk_to_olo(int carrier_type, float[] ssk, uint olo_num, short[] olo_measures);
        #endregion
        public enum Conv_Carrier
        {
            SU = 1, MiG = 2
        };
        public enum Conv_OLO_num
        {
            Left = 18, Right = 17
        };

        #region Переменные
        public String crlf = "\r\n";
        public const Byte qq = 0;
        public canmsg_t frame = new canmsg_t();
        public canerrs_t errs = new canerrs_t();
        public canwait_t cw = new canwait_t();
		public int ret;
		public Byte chan;
        //static bool generator_running = false;
        //static bool cycle_test_D21_running = false;
        //static bool cycle_test_D13_running = false;
        //static bool cycle_test_D19_running = false;

//        public canmsg_t frame = new canmsg_t();
//        public canerrs_t errs = new canerrs_t();
//        public canwait_t cw = new canwait_t();
        public PACKET_CMD cmd = new PACKET_CMD();
        public PACKET_ACK ack = new PACKET_ACK();
//        public int ret;
//        public _u8 chan;
        public _u32 size;

//        static Byte[] Buffer;

        Boolean calibration_started = false;
//        Boolean calibration_ended = false;

        public byte select_CMOS = 0;
        public byte select_wing = 0;

        public Bitmap image_CMOS = new Bitmap(Const.IMAGE_CX, Const.IMAGE_CY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

        public Bitmap image_CMOS1 = new Bitmap(Const.IMAGE_CX, Const.IMAGE_CY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        public Bitmap image_CMOS2 = new Bitmap(Const.IMAGE_CX, Const.IMAGE_CY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        Byte[] image_data1 = new Byte[Const.IMAGE_CX * Const.IMAGE_CY];
        Byte[] image_data2 = new Byte[Const.IMAGE_CX * Const.IMAGE_CY];

        Byte[] image_data = new Byte[Const.IMAGE_CX * Const.IMAGE_CY];

        //        public Bitmap image_CMOS = new Bitmap(IMAGE_CX, IMAGE_CY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        static Byte[] Buffer = new Byte[Const.IMAGE_CX * Const.IMAGE_CY];

        public MCANConverter marCAN = null;
        public ACANConverter advCAN = null;
        public ECANConverter elcCAN = null;
        public FCANConverter fakeCAN = null;

        public static IUCANConverter uniCAN = null;

        List<String> list_badpix_TXT = new List<string>();
        List<String> list_badpixCal = new List<string>();
        List<FIFO_ITEM> list_badpix_FIFO = new List<FIFO_ITEM>();
        int num_bad_points = 0;

        String m_strPathToPassports = Path.GetDirectoryName(Application.ExecutablePath) + "\\passports\\";
        String m_strPathToConfigs = Path.GetDirectoryName(Application.ExecutablePath) + "\\configs\\";
        String m_strPathToScreens = Path.GetDirectoryName(Application.ExecutablePath) + "\\screenshots\\";
        public enum State
        {
            NotOpenState,
            OpenedState,
            VideoState,
            StoppingVideoState
        }
        State _state = State.NotOpenState;

        Boolean m_bMousePressed;
        Boolean m_bAreaSelected;
        Point m_p1, m_p2;
        int X = 0, Y = 0;
        Byte[] shot_array = new Byte[100000 * 8];
        List<FIFO_ITEM> shot_array_list = new List<FIFO_ITEM>();

        Byte[] shot_array1 = new Byte[100000 * 8];
        List<FIFO_ITEM> shot_array_list1 = new List<FIFO_ITEM>();
        Byte[] shot_array2 = new Byte[100000 * 8];
        List<FIFO_ITEM> shot_array_list2 = new List<FIFO_ITEM>();

        ZoomedForm zoom = new ZoomedForm();

        List<COMMAND> EnqueueCommandList = new List<COMMAND>();
        Byte[] cans = new Byte[3] { 0, 0, 0 };

        string CR = "\r\n";

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 155)]
        Byte[] cfg_array;// = new Byte[Marshal.SizeOf(cfg)];

        int currTab = 0;
        const Byte def_NUM_TABS = 8;
        ComboBox[] cb_CAN = new ComboBox[def_NUM_TABS];
        Button[] bt_CAN = new Button[def_NUM_TABS - 1];

        IniFile inicfg;

        Bitmap bm91;
        Bitmap bm92;
        Boolean flag_stop8 = false;

        #endregion

        #region Tab2
        public Byte OLO_Select = Const.OLO_Left;

        public byte select_CMOS2 = 0;
        public byte select_wing2 = 0;

        public Boolean scroll = true;

//        public Bitmap malevich = new Bitmap(Const.IMAGE_CX * 2, Const.IMAGE_CY * 2, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

        msg_t m = new msg_t();

        DataTable dt = new DataTable("data");
        public struct Shots
        {
            public Byte bort;
            public Int16 azimut;
            public Int16 ugol;
        }

        List<Shots> list_shots = new List<Shots>();
        public static List<msg_t> messages = new List<msg_t>();


        static bool generator_running = false;
        static bool cycle_test_D21_running = false;
        static bool cycle_test_D13_running = false;
        static bool cycle_test_D19_running = false;
        public uint ver = 0;
        public Bitmap image_CMOS14 = null;
        public Bitmap image_CMOS24 = null;

//        bool mousetest = false;

        TM.Timer rstTimer3 = new TM.Timer();

        UInt16 count_l = 0, count_r = 0;

        #endregion
        #region Tab3
        SaveFileDialog savelog = new SaveFileDialog();
        StreamWriter logwr;
        #endregion
        #region Tab7
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public unsafe struct FILETABLE
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
            public Byte[] name;
            public UInt32 begin;
            public UInt32 size;
            public UInt32 time;
            public UInt32 crc32;
            public UInt32 version;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
            public Byte[] comment;
            public FILETABLE(Byte init) : this()
            {
                begin = UInt32.MaxValue;
                size = UInt32.MaxValue;
                time = UInt32.MaxValue;
                crc32 = UInt32.MaxValue;
                version = UInt32.MaxValue;
                name = new Byte[28];
                for (int i = 0; i < 28; i++)
                {
                    name[i] = init;
                }
                comment = new Byte[80];
                for (int i = 0; i < 80; i++)
                {
                    comment[i] = init;
                }
            }
        };
        public unsafe struct DATATABLE
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public Byte[] test;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public Byte[] dev_id;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public Byte[] ser_num;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 116)]
            public Byte[] rezerv;
        };

        UInt32 size_dtable = 128;
        UInt32 begin_dtable = 0x3A000;
        FILETABLE[] fff = new FILETABLE[4];
        DATATABLE dtable = new DATATABLE();
        UInt32 begin_filetable = 0;
        UInt32 begin_flash1 = 0;
        UInt32 size_flash1 = 0;
        Boolean aktiv = false;
        const UInt32 START_CONFIG = 0x3A000;
        const UInt32 SIZE_CONFIG = 0x80;
        const UInt32 START_FILE = 0x3C000;
        const UInt32 SIZE_FILE = 0x80;
        const UInt32 START_FW = 0x4000;
       
        #endregion
        #region Tab4
        int timer_Reset_Shots_Interval = 10000;
        UInt32 timestamp = 0;
        UInt32 timestampold = 0;

        Boolean flag_reset_left = false;
        Boolean flag_reset_right = false;
        Byte soer_l = 0;
        Byte soer_r = 0;
        Thread thr_l_shoot;
        Thread thr_r_shoot;
        autoshoots auto_l;
        autoshoots auto_r;
        public static Boolean flag_thr_l_shoot;
        public static Boolean flag_thr_r_shoot;
        String lolo = "левого ОЛО";
        String polo = "правого ОЛО";

        Double[,] prsu = new Double[,] { { 0.0, -0.9903, -0.1392 }, { 0.0, 0.1392, -0.9903 }, { 1.0, 0.0, 0.0 } };
        Double[,] plsu = new Double[,] { { 0.0, -0.9903, 0.1392 }, { 0.0, 0.1392, 0.9903 }, { -1.0, -0.0, 0.0 } };
        Double[,] prmg = new Double[,] { { 0, -0, 1 }, { 0, -1, -0 }, { 1, 0, -0 } };
        Double[,] plmg = new Double[,] { { 0, -0, -1 }, { 0, -1, 0 }, { -1, -0, 0 } };

        short[] ms = new short[2];
        float[] ssk = new float[2];

        public struct SCENE
        {
            public Int32 time;
            public Byte olo;
            public Int32 azimut;
            public Int32 ugolmesta;
        };
        List<SCENE> scene = new List<SCENE>();
        Boolean flag_enable_scene = false;
        Int32 scene_time = 0;
        Int32 scene_cnt = 0;
        #endregion

        #region Преобразование номера версии
        public _u32 VERSUB(_u32 ver)
        {
            return (_u32)(ver & 0xff);
        }

        public _u32 VERMIN(_u32 ver)
        {
            return (_u32)((ver >> 8) & 0xff);
        }

        public _u32 VERMAJ(_u32 ver)
        {
            return (_u32)((ver >> 16) & 0xff);
        }
        #endregion

        #region События формы
        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
        [Description("Sets The Gradient Style"), Category("Appearance")]
        public void EnableDoubleBuffering()
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            DoubleBuffered = true;
            EnableDoubleBuffering();

            this.Text = AboutBox.AssemblyTitle + String.Format(" Версия {0}", AboutBox.AssemblyVersion) + " " + AboutBox.AssemblyCopyright + " CANLib " 
            + String.Format(" Версия {0}", CANLib.AssemblyVersion);

            this.KeyPreview = true;
            Boolean existed;
            String guid = Marshal.GetTypeLibGuidForAssembly(Assembly.GetExecutingAssembly()).ToString();
            Mutex mtx = new Mutex(true, guid, out existed);

            //for (int i = 0; i < Const.IMAGE_CX * 2; i++)
            //    for (int j = 0; j < Const.IMAGE_CY * 2; j++)
            //        malevich.SetPixel(i, j, Color.Black);

            if (!existed)
            {
                if (MessageBox.Show("Приложение уже запущено! Запустить еще один экземпляр?", "Повторный запуск", MessageBoxButtons.YesNo,MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                Application.Exit();
            }

            cb_CAN[0] = comboBox1;
            cb_CAN[1] = cb_CAN1;
            cb_CAN[2] = cb_CAN2;
            cb_CAN[3] = cb_CAN3;
            cb_CAN[4] = cb_CAN4;
            cb_CAN[5] = cb_CAN5;
            cb_CAN[6] = cb_CAN8;
            cb_CAN[7] = cb_CAN9;

            bt_CAN[0] = bt_CloseCAN;
            bt_CAN[1] = bt_CloseCAN2;
            bt_CAN[2] = bt_CloseCAN3;
            bt_CAN[3] = bt_CloseCAN5;
            bt_CAN[4] = bt_CloseCAN8;
            bt_CAN[5] = bt_CloseCAN9;
            bt_CAN[6] = bt_CloseCAN4;

            state_Error();
            
            if (!Directory.Exists(m_strPathToPassports))
                Directory.CreateDirectory(m_strPathToPassports);
            if (!Directory.Exists(m_strPathToConfigs))
                Directory.CreateDirectory(m_strPathToConfigs);
            if (!Directory.Exists(m_strPathToScreens))
                Directory.CreateDirectory(m_strPathToScreens);
            UpdatePassportList();

            comboBox1.Items.Clear();
            try
            {
                marCAN = new MCANConverter();
                if (marCAN.Is_Present)
                {
                    comboBox1.Items.Add("USB Marathon");
                    marCAN.Close();
                }
            }
            catch (Exception)
            {
            }
            try
            {
                advCAN = new ACANConverter();
                if (advCAN.Is_Present)
                {
                    comboBox1.Items.Add("PCI Advantech");
                    advCAN.Close();
                }
            }
            catch (Exception)
            {
            }
            try
            {
                elcCAN = new ECANConverter();
                if (elcCAN.Is_Present)
                {
                    comboBox1.Items.Add("PCI Elcus");
                    elcCAN.Close();
                }
            }
            catch (Exception)
            {
            }
            //try
            //{
            //    elcCAN18 = new ECAN18Converter();
            //    if (elcCAN18.Is_Present)
            //    {
            //        comboBox1.Items.Add("PCI Elcus 1.8");
            //        elcCAN18.Close();
            //    }
            //}
            //catch (Exception)
            //{
            //}

            
            inicfg = new IniFile(Application.StartupPath.ToString() + "\\olo_can.cfg");
            if (System.IO.File.Exists(Application.StartupPath.ToString() + "\\olo_can.cfg"))
            {
                try { chb_6_1.Checked = inicfg._GetBool("setup", "key1"); }
                catch (Exception) { }
                try { chb_6_2.Checked = inicfg._GetBool("setup", "key2"); }
                catch (Exception) { }
                try { chb_6_3.Checked = inicfg._GetBool("setup", "key3"); }
                catch (Exception) { }
                try { chb_6_4.Checked = inicfg._GetBool("setup", "key4"); }
                catch (Exception) { }
                try { chb_6_5.Checked = inicfg._GetBool("setup", "key5"); }
                catch (Exception) { }
                try { chb_6_6.Checked = inicfg._GetBool("setup", "key6"); }
                catch (Exception) { }
                try { chb_6_7.Checked = inicfg._GetBool("setup", "key7"); }
                catch (Exception) { }
                try { chb_6_8.Checked = inicfg._GetBool("setup", "key8"); }
                catch (Exception) { }
                try { chb_6_9.Checked = inicfg._GetBool("setup", "key9"); }
                catch (Exception) { }
                try { chb_6_10.Checked = inicfg._GetBool("setup", "key10"); }
                catch (Exception) { }
            }
            else
            {
                chb_6_1.Checked = true;
                chb_6_2.Checked = true;
                chb_6_3.Checked = true;
                chb_6_4.Checked = true;
                chb_6_5.Checked = true;
                chb_6_7.Checked = true;
                chb_6_6.Checked = true;
                chb_6_8.Checked = true;
                chb_6_9.Checked = true;
                chb_6_10.Checked = true;
            }
            try
            {
                if (!chb_6_1.Checked)
                    tabControl1.TabPages["tabPage1"].Parent = null;
                else
                    tabControl1.TabPages["tabPage1"].Parent = tabControl1;
                if (!chb_6_2.Checked)
                    tabControl1.TabPages["tabPage2"].Parent = null;
                else
                    tabControl1.TabPages["tabPage2"].Parent = tabControl1;
                if (!chb_6_3.Checked)
                    tabControl1.TabPages["tabPage3"].Parent = null;
                else
                    tabControl1.TabPages["tabPage3"].Parent = tabControl1;
                if (!chb_6_4.Checked)
                    tabControl1.TabPages["tabPage4"].Parent = null;
                else
                    tabControl1.TabPages["tabPage4"].Parent = tabControl1;
                if (!chb_6_5.Checked)
                    tabControl1.TabPages["tabPage5"].Parent = null;
                else
                    tabControl1.TabPages["tabPage5"].Parent = tabControl1;
                if (!chb_6_6.Checked)
                    tabControl1.TabPages["tabPage6"].Parent = null;
                else
                    tabControl1.TabPages["tabPage6"].Parent = tabControl1;
                if (!chb_6_7.Checked)
                    tabControl1.TabPages["tabPage7"].Parent = null;
                else
                    tabControl1.TabPages["tabPage7"].Parent = tabControl1;
                if (!chb_6_8.Checked)
                    tabControl1.TabPages["tabPage8"].Parent = null;
                else
                    tabControl1.TabPages["tabPage8"].Parent = tabControl1;
                if (!chb_6_9.Checked)
                    tabControl1.TabPages["tabPage9"].Parent = null;
                else
                    tabControl1.TabPages["tabPage9"].Parent = tabControl1;
            }
            catch (Exception)
            {
            }
            if (chb_6_10.Checked)
            {
                try
                {
                    fakeCAN = new FCANConverter();
                    if (fakeCAN.Is_Present)
                    {
                        comboBox1.Items.Add("Fake CAN driver");
                        fakeCAN.Close();
                    }
                }
                catch (Exception)
                {
                }
            }

            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Add("No CAN");
                comboBox1.SelectedIndex = 0;
                lb_error_CAN.Text = "CAN-контроллеры не найдены!";
                for (int k = 1; k < def_NUM_TABS; k++)
                {
                    cb_CAN[k].Items.Clear();
                    foreach (var item in comboBox1.Items)
                        cb_CAN[k].Items.Add(item);
                    cb_CAN[k].SelectedIndex = 0;
                }
                state_Error();
                return;
            }
            comboBox1.SelectedIndex = 0;
            cb_module2.SelectedIndex = 0;
            for (int k = 1; k < def_NUM_TABS; k++)
            {
                cb_CAN[k].Items.Clear();
                foreach (var item in comboBox1.Items)
                    cb_CAN[k].Items.Add(item);
                cb_CAN[k].SelectedIndex = 0;
            }


        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (uniCAN != null)
                if (uniCAN.Is_Open)
                {
                    uniCAN.Recv_Disable();
                    uniCAN.Close();
                }
        }
        private void Err_Handler(object sender, MyEventArgs e)
        {
            lb_error_CAN.Text = e.Text;
            if (chb_PRunVideo.Checked & chb_PShot.Checked)
            {
                lb_error_CAN.Visible = true;
                lb_noerr.Visible = false;
                state_Error();
                uniCAN.Recv_Disable();
                uniCAN.Close();
            }
            if (chb_PRunVideo.Checked & !chb_PShot.Checked)
            {
                lb_error_CAN.Visible = true;
                lb_noerr.Visible = false;
            }
            lb_error_CAN1.Text = e.Text;
            lb_error_CAN1.Visible = true;
            lb_noerr1.Visible = false;
            state_Error();

            lb_error_CAN2.Text = e.Text;
            lb_error_CAN2.Visible = true;
            lb_noerr2.Visible = false;

            lb_error_CAN3.Text = e.Text;
            lb_error_CAN3.Visible = true;
            lb_noerr3.Visible = false;

            uniCAN.Recv_Disable();
            uniCAN.Close();
            lb_error_CAN2.Visible = true;
            lb_noerr2.Visible = false;

            lb_error_CAN3.Visible = true;
            lb_noerr3.Visible = false;

            lb_error_CAN4.Text = e.Text;
            lb_error_CAN4.Visible = true;
            lb_version.Visible = false;
            state_Error();

            lb_error_CAN5.Text = e.Text;
            lb_error_CAN5.Visible = true;
            lb_noerr5.Visible = false;
            state_Error();
            uniCAN.Close();
            uniCAN = null;
            lb_error_CAN4.Text = e.Text;

            lb_error_CAN8.Text = e.Text;
            lb_error_CAN8.Visible = true;
            lb_noerr8.Visible = false;
            state_Error();
            uniCAN.Close();
            uniCAN = null;
            lb_error_CAN8.Text = e.Text;

            lb_error_CAN9.Visible = true;
            lb_noerr9.Visible = false;
            state_Error();
            uniCAN.Close();
            uniCAN = null;
            lb_error_CAN9.Text = e.Text;
        }
        private void Progress_Handler(object sender, MyEventArgs e)
        {
            //if (InvokeRequired)
            //{
            //    BeginInvoke(new MyDelegate(Progress_Handler), new object[] { e.Val });
            //    //this.Invoke(new Action(Progress_Handler), new object[] { e.Val });
            //    return;
            //}
            //else
            if (pb_CMOS.Maximum > e.Val)
            {
                pb_CMOS.Value = e.Val;
                pb_CMOS.Refresh();
            }
            if (pb_CMOS1.Maximum > e.Val)
            {
                pb_CMOS1.Value = e.Val;
                pb_CMOS1.Refresh();
            }
            if (pb_CMOS2.Maximum > e.Val)
            {
                pb_CMOS2.Value = e.Val;
                pb_CMOS2.Refresh();
            }
            if (pb_loadbmp8.Maximum > e.Val)
            {
                pb_loadbmp8.Value = e.Val;
                pb_loadbmp8.Refresh();
            }
            //MyProgressBar mpb_cmos = new MyProgressBar();
        }
        private void Progress9_Handler(object sender, MyEventArgs e)
        {
            //if (InvokeRequired)
            //{
            //    BeginInvoke(new MyDelegate(Progress_Handler), new object[] { e.Val });
            //    //this.Invoke(new Action(Progress_Handler), new object[] { e.Val });
            //    return;
            //}
            //else
            if (pb_loadbmp9.Maximum > e.Val)
            {
                pb_loadbmp9.Value = e.Val;
                pb_loadbmp9.Refresh();
            }
        }
        private void state_Error()
        {
            // Tab 0
            bt_CloseCAN.Enabled = false;
            bt_OpenCAN.Enabled = true;
            gbox_Cross.Enabled = false;
            gbox_Image.Enabled = false;
            gbox_Temperature.Enabled = false;
            gbox_CMOS1.Enabled = false;
            gbox_CMOS2.Enabled = false;
            gbox_Passports.Enabled = false;
            gbox_Process.Enabled = false;
            VideoTimer.Enabled = false;
            lb_noerr.Visible = false;
            bt_About.Enabled = true;
            bt_Exit.Enabled = true;
            chb_Calibr.Checked = false;
            lb_num_bad_points.Visible = false;
            chb_PFIFO.Checked = false;
            chb_PHidebadpix.Checked = false;
            chb_PRunVideo.Checked = false;
            chb_PShot.Checked = false;
            chb_EnableCross.Checked = false;
            rb_CMOS1.Enabled = false;
            rb_CMOS2.Enabled = false;

            // Tab 1
            lb_noerr1.Visible = false;
            bt_About1.Enabled = true;
            bt_Exit1.Enabled = true;
            gb_CAN1.Enabled = true;
            gb_MC1.Enabled = true;

            // Tab2
            bt_CloseCAN2.Enabled = false;
            bt_OpenCAN2.Enabled = true;

            lb_noerr2.Visible = false;

            bt_About2.Enabled = true;
            bt_Exit2.Enabled = true;

            label16.Enabled = false;
            label17.Enabled = false;
            label18.Enabled = false;
            cb2_select_olo.Enabled = false;
            cb2_period_ans.Enabled = false;
            bt_About3.Enabled = false;
            bt_SyncTime.Enabled = false;
            bt_Request2.Enabled = false;
            rtb2_datagrid.Enabled = false;
            panel1.Enabled = false;
            btn_REQSN.Enabled = false;
            btn_Reset.Enabled = false;
            button1.Enabled = false;
            chb_dgview2.Enabled = false;
            numericUpDown1.Enabled = false;

            gbox_statusL2.Enabled = false;
            gbox_statusR2.Enabled = false;
            bt_mod2.Enabled = false;
            REQ_VER.Enabled = false;
            cb_module2.Enabled = false;
            chb3_savelog.Enabled = false;

            lb_statusL_file2.Text = "";
            lb_statusL_mode2.Text = "";
            lb_statusL_plis2.Text = "";
            lb_statusL_reason2.Text = "";
            lb_statusL_status2.Text = "";
            lb_statusL_t12.Text = "";
            lb_statusL_t22.Text = "";
            lb_statusL_t32.Text = "";

            lb_statusR_file2.Text = "";
            lb_statusR_mode2.Text = "";
            lb_statusR_plis2.Text = "";
            lb_statusR_reason2.Text = "";
            lb_statusR_status2.Text = "";
            lb_statusR_t12.Text = "";
            lb_statusR_t22.Text = "";
            lb_statusR_t32.Text = "";

            gbox_ecL2.Enabled = false;
            gbox_ecR2.Enabled = false;

            lb_ecL2_file.Text = "";
            lb_ecL2_plis1.Text = "";
            lb_ecL2_plis2.Text = "";
            lb_ecL2_ram.Text = "";
            lb_ecL2_ram1.Text = "";
            lb_ecL2_ram2.Text = "";

            lb_ecR2_file.Text = "";
            lb_ecR2_plis1.Text = "";
            lb_ecR2_plis2.Text = "";
            lb_ecR2_ram.Text = "";
            lb_ecR2_ram1.Text = "";
            lb_ecR2_ram2.Text = "";

            gb_stL2.Enabled = false;
            gb_stR2.Enabled = false;

            lb_stL2_cmos1.Text = "";
            lb_stL2_cmos2.Text = "";
            lb_stR2_cmos1.Text = "";
            lb_stR2_cmos2.Text = "";
            tb_SN.Text = "";

            // Tab3
            bt_CloseCAN3.Enabled = false;
            bt_OpenCAN3.Enabled = true;
            lb_noerr3.Visible = false;
            bt_About3.Enabled = true;
            bt_Exit3.Enabled = true;
            rtb3_datagrid.Enabled = false;
            panel3.Enabled = false;
            gb_olo_L.Enabled = false;
            gb_olo_R.Enabled = false;
            chb4_enshl.CheckState = CheckState.Unchecked;
            chb4_enshr.CheckState = CheckState.Unchecked;

            // Tab4
            bt_CloseCAN4.Enabled = false;
            bt_OpenCAN4.Enabled = true;
            cb_CAN4.Enabled = true;
            gb_Tests.Enabled = false;
            gb_Image14.Enabled = false;
            gb_Temperature.Enabled = false;
            timer_temperature.Enabled = false;
            lb_version.Visible = false;
            lb_test_plis.Text = "";
            lb_test_D13.Text = "";
            lb_test_D19.Text = "";
            lb_test_D21_1.Text = "";
            lb_test_D21_2.Text = "";
            lb_test_FLASH.Text = "";
            lb_CMOS14.Text = "";
            bt_About4.Enabled = true;
            bt_Exit4.Enabled = true;
            сброс_результатов();

            // Tab5
            bt_CloseCAN5.Enabled = false;
            bt_OpenCAN5.Enabled = true;
            cb_CAN5.Enabled = true;
            bt_CloseCAN5.Enabled = false;
            bt_OpenCAN5.Enabled = true;

            lb_noerr5.Visible = false;

            rb_r5.Enabled = false;
            rb_l5.Enabled = false;
            bt_aktiv5.Enabled = false;
            bt_reboot5.Enabled = false;
            bt_status5.Enabled = false;
            bt_verifi5.Enabled = false;

            dataGridView1.Enabled = false;
            progressBar1.Enabled = false;
            richTextBox1.Enabled = false;

            // Tab8
            bt_CloseCAN8.Enabled = false;
            bt_OpenCAN8.Enabled = true;
            cb_CAN8.Enabled = true;
            bt_CloseCAN8.Enabled = false;
            bt_OpenCAN8.Enabled = true;

            lb_noerr8.Visible = false;

            // Tab8
            bt_CloseCAN9.Enabled = false;
            bt_OpenCAN9.Enabled = true;
            cb_CAN9.Enabled = true;
            bt_CloseCAN9.Enabled = false;
            bt_sendbmp9.Enabled = false;
            bt_OpenCAN9.Enabled = true;
            lb_noerr9.Visible = false;
            //            rb_r8.Enabled = false;
//            rb_l8.Enabled = false;
        }
        private void state_Ready()
        {
            // Tab 0
            bt_CloseCAN.Enabled = true;
            bt_OpenCAN.Enabled = false;
            gbox_Cross.Enabled = true;
            gbox_Image.Enabled = true;
            gbox_Temperature.Enabled = true;
            gbox_CMOS1.Enabled = true;
            gbox_CMOS2.Enabled = true;
            gbox_Passports.Enabled = true;
            gbox_Process.Enabled = true;
            VideoTimer.Enabled = false;
            lb_noerr.Visible = true;
            lb_noerr.Text = uniCAN.Info;
            bt_About.Enabled = true;
            bt_Exit.Enabled = true;
            chb_Calibr.Checked = false;
            lb_num_bad_points.Visible = false;
            chb_PFIFO.Checked = false;
            chb_PHidebadpix.Checked = false;
            chb_PRunVideo.Checked = false;
            chb_PShot.Checked = false;
            chb_EnableCross.Checked = false;
            rb_CMOS1.Enabled = true;
            rb_CMOS2.Enabled = true;
            pb_CMOS.Value = 0;

            //Tab 1
            lb_noerr1.Visible = true;
            lb_noerr1.Text = uniCAN.Info;
            bt_About1.Enabled = true;
            bt_Exit1.Enabled = true;

            // Tab2
            bt_CloseCAN2.Enabled = true;
            bt_OpenCAN2.Enabled = false;
            lb_noerr2.Visible = true;
            lb_noerr2.Text = uniCAN.Info;
            bt_About2.Enabled = true;
            bt_Exit2.Enabled = true;
            label16.Enabled = true;
            label17.Enabled = true;
            label18.Enabled = true;
            cb2_select_olo.Enabled = true;
            cb2_period_ans.Enabled = true;
            bt_About3.Enabled = true;
            bt_SyncTime.Enabled = true;
            label17.Enabled = true;
            cb_CAN2.Enabled = true;
            bt_Request2.Enabled = true;
            rtb2_datagrid.Enabled = true;
            panel1.Enabled = true;
            btn_REQSN.Enabled = true;
            btn_Reset.Enabled = true;
            button1.Enabled = true;
            chb_dgview2.Enabled = true;
            numericUpDown1.Enabled = true;

            gbox_statusL2.Enabled = true;
            gbox_statusR2.Enabled = true;
            bt_mod2.Enabled = true;
            REQ_VER.Enabled = true;
            cb_module2.Enabled = true;
            chb3_savelog.Enabled = true;

            lb_statusL_file2.Text = "";
            lb_statusL_mode2.Text = "";
            lb_statusL_plis2.Text = "";
            lb_statusL_reason2.Text = "";
            lb_statusL_status2.Text = "";
            lb_statusL_t12.Text = "";
            lb_statusL_t22.Text = "";
            lb_statusL_t32.Text = "";

            lb_statusR_file2.Text = "";
            lb_statusR_mode2.Text = "";
            lb_statusR_plis2.Text = "";
            lb_statusR_reason2.Text = "";
            lb_statusR_status2.Text = "";
            lb_statusR_t12.Text = "";
            lb_statusR_t22.Text = "";
            lb_statusR_t32.Text = "";

//            gbox_ecL2.Enabled = true;
//            gbox_ecR2.Enabled = true;

            lb_ecL2_file.Text = "";
            lb_ecL2_plis1.Text = "";
            lb_ecL2_plis2.Text = "";
            lb_ecL2_ram.Text = "";
            lb_ecL2_ram1.Text = "";
            lb_ecL2_ram2.Text = "";

            lb_ecR2_file.Text = "";
            lb_ecR2_plis1.Text = "";
            lb_ecR2_plis2.Text = "";
            lb_ecR2_ram.Text = "";
            lb_ecR2_ram1.Text = "";
            lb_ecR2_ram2.Text = "";

//            gb_stL2.Enabled = true;
//            gb_stR2.Enabled = true;

            lb_stL2_cmos1.Text = "";
            lb_stL2_cmos2.Text = "";
            lb_stR2_cmos1.Text = "";
            lb_stR2_cmos2.Text = "";
            tb_SN.Text = "";

            // Tab3
            bt_CloseCAN3.Enabled = true;
            bt_OpenCAN3.Enabled = false;

            lb_noerr3.Visible = true;
            lb_noerr3.Text = uniCAN.Info;

            bt_About3.Enabled = true;
            bt_Exit3.Enabled = true;

            cb_CAN3.Enabled = true;
            rtb3_datagrid.Enabled = true;
            panel3.Enabled = true;
            gb_olo_L.Enabled = true;
            gb_olo_R.Enabled = true;

            // Tab4
            bt_CloseCAN4.Enabled = true;
            bt_OpenCAN4.Enabled = false;
            cb_CAN4.Enabled = false;
            gb_Tests.Enabled = true;
            gb_Image14.Enabled = true;
            gb_Image24.Enabled = true;
            gb_Temperature.Enabled = true;
            //timer_temperature.Enabled = true;
            bt_About4.Enabled = true;
            bt_Exit4.Enabled = true;
            lb_test_plis.Text = "";
            lb_test_D13.Text = "";
            lb_test_D19.Text = "";
            lb_test_D21_1.Text = "";
            lb_test_D21_2.Text = "";
            lb_test_FLASH.Text = "";
            lb_CMOS14.Text = "";

            // Tab3
            bt_CloseCAN3.Enabled = true;
            bt_OpenCAN3.Enabled = false;

            lb_noerr3.Visible = true;
            lb_noerr3.Text = uniCAN.Info;

            bt_About3.Enabled = true;
            bt_Exit3.Enabled = true;

            cb_CAN3.Enabled = true;
            rtb3_datagrid.Enabled = true;
            panel3.Enabled = true;
            gb_olo_L.Enabled = true;
            gb_olo_R.Enabled = true;

            // Tab5
            bt_CloseCAN5.Enabled = true;
            bt_OpenCAN5.Enabled = false;
            cb_CAN5.Enabled = false;
            lb_noerr5.Visible = true;
            lb_noerr5.Text = uniCAN.Info;

            rb_r5.Enabled = true;
            rb_l5.Enabled = true;
            bt_aktiv5.Enabled = true;
            bt_reboot5.Enabled = true;
            bt_status5.Enabled = true;
            bt_verifi5.Enabled = false;

            dataGridView1.Enabled = false;
            progressBar1.Enabled = false;
            richTextBox1.Enabled = false;

            // Tab8
            bt_CloseCAN8.Enabled = true;
            bt_OpenCAN8.Enabled = false;
            cb_CAN8.Enabled = false;
            lb_noerr8.Visible = true;
            lb_noerr8.Text = uniCAN.Info;
            // Tab9
            bt_CloseCAN9.Enabled = true;
            bt_OpenCAN9.Enabled = false;
            cb_CAN9.Enabled = false;
            lb_noerr9.Visible = true;
            lb_noerr9.Text = uniCAN.Info;
            bt_sendbmp9.Enabled = true;
            rb_olo_l9.Enabled = true;
            rb_olo_r9.Enabled = true;

        }
        private void state_NotReady()
        {
            bt_CloseCAN2.Enabled = false;
            bt_OpenCAN2.Enabled = true;

            lb_noerr2.Visible = false;

            bt_About2.Enabled = true;
            bt_Exit2.Enabled = true;

            label16.Enabled = false;
            label17.Enabled = false;
            label18.Enabled = false;
            cb2_select_olo.Enabled = false;
            cb2_period_ans.Enabled = false;
            bt_SyncTime.Enabled = false;
            cb_CAN2.Enabled = true;
            bt_Request2.Enabled = false;
            rtb2_datagrid.Enabled = false;
            panel1.Enabled = false;
            btn_REQSN.Enabled = false;
            bt_SyncTime.Enabled = false;
            btn_Reset.Enabled = false;
            button1.Enabled = false;
            chb_dgview2.Enabled = false;
            numericUpDown1.Enabled = false;

            // Tab3
            bt_CloseCAN3.Enabled = false;
            bt_OpenCAN3.Enabled = true;
            lb_noerr3.Visible = false;
            bt_About3.Enabled = true;
            bt_Exit3.Enabled = true;
            rtb3_datagrid.Enabled = false;
            panel3.Enabled = false;
            gb_olo_L.Enabled = false;
            gb_olo_R.Enabled = false;

            // tab2
            gbox_statusL2.Enabled = false;
            gbox_statusR2.Enabled = false;
            bt_mod2.Enabled = false;
            REQ_VER.Enabled = false;
            cb_module2.Enabled = false;
            chb3_savelog.Enabled = false;

            lb_statusL_file2.Text = "";
            lb_statusL_mode2.Text = "";
            lb_statusL_plis2.Text = "";
            lb_statusL_reason2.Text = "";
            lb_statusL_status2.Text = "";
            lb_statusL_t12.Text = "";
            lb_statusL_t22.Text = "";
            lb_statusL_t32.Text = "";

            lb_statusR_file2.Text = "";
            lb_statusR_mode2.Text = "";
            lb_statusR_plis2.Text = "";
            lb_statusR_reason2.Text = "";
            lb_statusR_status2.Text = "";
            lb_statusR_t12.Text = "";
            lb_statusR_t22.Text = "";
            lb_statusR_t32.Text = "";

            gbox_ecL2.Enabled = false;
            gbox_ecR2.Enabled = false;

            lb_ecL2_file.Text = "";
            lb_ecL2_plis1.Text = "";
            lb_ecL2_plis2.Text = "";
            lb_ecL2_ram.Text = "";
            lb_ecL2_ram1.Text = "";
            lb_ecL2_ram2.Text = "";

            lb_ecR2_file.Text = "";
            lb_ecR2_plis1.Text = "";
            lb_ecR2_plis2.Text = "";
            lb_ecR2_ram.Text = "";
            lb_ecR2_ram1.Text = "";
            lb_ecR2_ram2.Text = "";

            gb_stL2.Enabled = false;
            gb_stR2.Enabled = false;

            lb_stL2_cmos1.Text = "";
            lb_stL2_cmos2.Text = "";
            lb_stR2_cmos1.Text = "";
            lb_stR2_cmos2.Text = "";
            tb_SN.Text = "";

            // Tab3
            bt_CloseCAN5.Enabled = false;
            bt_OpenCAN5.Enabled = true;
            lb_noerr5.Visible = false;
            cb_CAN5.Enabled = true;

            rb_r5.Enabled = false;
            rb_l5.Enabled = false;
            bt_aktiv5.Enabled = false;
            bt_reboot5.Enabled = false;
            bt_status5.Enabled = false;
            bt_verifi5.Enabled = false;

            dataGridView1.Enabled = false;
            progressBar1.Enabled = false;
            richTextBox1.Enabled = false;

            // Tab8
            bt_CloseCAN8.Enabled = false;
            bt_OpenCAN8.Enabled = true;
            lb_noerr8.Visible = false;
            cb_CAN8.Enabled = true;
            // Tab8
            bt_CloseCAN9.Enabled = false;
            bt_OpenCAN9.Enabled = true;
            lb_noerr9.Visible = false;
            cb_CAN9.Enabled = true;
            bt_sendbmp9.Enabled = false;
            rb_olo_l9.Enabled = false;
            rb_olo_r9.Enabled = false;

//            rb_r8.Enabled = false;
//            rb_l8.Enabled = false;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cb_CAN[tabControl1.SelectedIndex].SelectedIndex = cb_CAN[currTab].SelectedIndex;
            }
            catch (Exception)
            {
            }
            cb2_period_ans.SelectedIndex = 0;
            cb2_select_olo.SelectedIndex = 0;
            foreach (var item in tabControl1.TabPages)
            {
                //Trace.WriteLine(item.ToString());
                //Trace.WriteLine(tabControl1.SelectedTab.ToString());
                //Trace.WriteLine(tabControl1.SelectedTab.Name.ToString());
            }
            for (int i = 0; i < def_NUM_TABS - 1; i++)
            {
                bt_CAN[i].PerformClick();
            }
            //if (tabControl1.TabPages.)
            //{
                
            //}
            /*
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                        bt_CloseCAN2.PerformClick();
                        bt_CloseCAN3.PerformClick();
                        bt_CloseCAN4.PerformClick();
                        bt_CloseCAN5.PerformClick();
                        bt_CloseCAN8.PerformClick();
                        break;
                case 1:
                        bt_CloseCAN.PerformClick();
                        bt_CloseCAN2.PerformClick();
                        bt_CloseCAN3.PerformClick();
                        bt_CloseCAN4.PerformClick();
                        bt_CloseCAN5.PerformClick();
                        bt_CloseCAN8.PerformClick();
                        break;
                case 2:
                        bt_CloseCAN.PerformClick();
                        bt_CloseCAN3.PerformClick();
                        bt_CloseCAN4.PerformClick();
                        bt_CloseCAN5.PerformClick();
                        state_NotReady();
                        rtb2_datagrid.ResetText();
                        bt_CloseCAN8.PerformClick();
                        break;
                case 3:
                        bt_CloseCAN.PerformClick();
                        bt_CloseCAN2.PerformClick();
                        bt_CloseCAN4.PerformClick();
                        bt_CloseCAN5.PerformClick();
                        bt_CloseCAN8.PerformClick();
                        break;
                case 4:
                        bt_CloseCAN.PerformClick();
                        bt_CloseCAN2.PerformClick();
                        bt_CloseCAN3.PerformClick();
                        bt_CloseCAN5.PerformClick();
                        bt_CloseCAN8.PerformClick();
                        break;
                case 5:
                        bt_CloseCAN.PerformClick();
                        bt_CloseCAN2.PerformClick();
                        bt_CloseCAN3.PerformClick();
                        bt_CloseCAN4.PerformClick();
                        bt_CloseCAN5.PerformClick();
                        bt_CloseCAN8.PerformClick();
                        break;
                case 6:
                        bt_CloseCAN.PerformClick();
                        bt_CloseCAN2.PerformClick();
                        bt_CloseCAN3.PerformClick();
                        bt_CloseCAN4.PerformClick();
                        bt_CloseCAN8.PerformClick();
                        bt_CloseCAN5.PerformClick();
                        break;
                case 7:
                        bt_CloseCAN.PerformClick();
                        bt_CloseCAN2.PerformClick();
                        bt_CloseCAN3.PerformClick();
                        bt_CloseCAN4.PerformClick();
                        bt_CloseCAN8.PerformClick();
                        break;
                case 8:
                        bt_CloseCAN.PerformClick();
                        bt_CloseCAN2.PerformClick();
                        bt_CloseCAN3.PerformClick();
                        bt_CloseCAN4.PerformClick();
                        bt_CloseCAN5.PerformClick();
                        break;
                default:
                        break;
            }
             */
            /*
            switch (tabControl1.SelectedTab.Name)
            {
                case "tabPage1":
                    bt_CloseCAN2.PerformClick();
                    bt_CloseCAN3.PerformClick();
                    bt_CloseCAN5.PerformClick();
                    bt_CloseCAN8.PerformClick();
                    bt_CloseCAN9.PerformClick();
                    bt_CloseCAN4.PerformClick();
                    break;
                case "tabPage2":
                    bt_CloseCAN.PerformClick();
                    bt_CloseCAN2.PerformClick();
                    bt_CloseCAN3.PerformClick();
                    bt_CloseCAN5.PerformClick();
                    bt_CloseCAN8.PerformClick();
                    bt_CloseCAN9.PerformClick();
                    bt_CloseCAN4.PerformClick();
                    break;
                case "tabPage3":
                    bt_CloseCAN.PerformClick();
                    bt_CloseCAN3.PerformClick();
                    bt_CloseCAN5.PerformClick();
                    bt_CloseCAN8.PerformClick();
                    bt_CloseCAN9.PerformClick();
                    bt_CloseCAN4.PerformClick();
                    state_NotReady();
                    rtb2_datagrid.ResetText();
                    break;
                case "tabPage4":
                    bt_CloseCAN.PerformClick();
                    bt_CloseCAN2.PerformClick();
                    bt_CloseCAN5.PerformClick();
                    bt_CloseCAN8.PerformClick();
                    bt_CloseCAN9.PerformClick();
                    bt_CloseCAN4.PerformClick();
                    break;
                case "tabPage7":
                    bt_CloseCAN.PerformClick();
                    bt_CloseCAN2.PerformClick();
                    bt_CloseCAN3.PerformClick();
                    bt_CloseCAN8.PerformClick();
                    bt_CloseCAN9.PerformClick();
                    bt_CloseCAN4.PerformClick();
                    break;
                case "tabPage8":
                    bt_CloseCAN.PerformClick();
                    bt_CloseCAN2.PerformClick();
                    bt_CloseCAN3.PerformClick();
                    bt_CloseCAN5.PerformClick();
                    bt_CloseCAN9.PerformClick();
                    bt_CloseCAN4.PerformClick();
                    break;
                case "tabPage9":
                    bt_CloseCAN.PerformClick();
                    bt_CloseCAN2.PerformClick();
                    bt_CloseCAN3.PerformClick();
                    bt_CloseCAN5.PerformClick();
                    bt_CloseCAN8.PerformClick();
                    bt_CloseCAN4.PerformClick();
                    break;
                case "tabPage5":
                    bt_CloseCAN.PerformClick();
                    bt_CloseCAN2.PerformClick();
                    bt_CloseCAN3.PerformClick();
                    bt_CloseCAN5.PerformClick();
                    bt_CloseCAN8.PerformClick();
                    bt_CloseCAN9.PerformClick();
                    break;
                case "tabPage6":
                    bt_CloseCAN.PerformClick();
                    bt_CloseCAN2.PerformClick();
                    bt_CloseCAN3.PerformClick();
                    bt_CloseCAN5.PerformClick();
                    bt_CloseCAN8.PerformClick();
                    bt_CloseCAN9.PerformClick();
                    bt_CloseCAN4.PerformClick();
                    break;
                default:
                    break;
            }
            */
            // Disable Tabs
            if (_state == State.VideoState)
            {
                _state = State.StoppingVideoState;
                VideoTimer.Enabled = false;
                chb_PShot.CheckState = CheckState.Unchecked;
                chb_PRunVideo.CheckState = CheckState.Unchecked;
            }
            if (_state == State.OpenedState)
            {
                if (uniCAN != null && uniCAN.Is_Open)
                {
                    uniCAN.Recv_Disable();
                    uniCAN.Close();
                }
            }
            state_Error();
            lb_error_CAN.Visible = false;
            _state = State.NotOpenState;
            if (listb_badpix.Items.Count > 0)
                listb_badpix.Items.Clear();
            list_badpix_FIFO.Clear();
            if (uniCAN != null)
                if (uniCAN.Is_Open)
                {
                    uniCAN.Recv_Disable();
                    uniCAN.Close();
                }
            bt_CloseCAN2.PerformClick();
            if (uniCAN != null && uniCAN.Is_Open)
            {
                uniCAN.Recv_Disable();
                uniCAN.Close();
            }
            state_NotReady();
            lb_error_CAN2.Visible = false;
//            uniCAN.Recv_Disable();
            uniCAN = null;
            Timer_GetData.Enabled = false;
            timer_Reset_Shots.Enabled = false;
            timer_testOLO_L.Enabled = false;
            timer_testOLO_R.Enabled = false;
            //Timer_UpdateTime.Enabled = false;
            currTab = tabControl1.SelectedIndex;
            lb_error_CAN.Visible = false;
            lb_error_CAN1.Visible = false;
            lb_error_CAN2.Visible = false;
            lb_error_CAN3.Visible = false;
            lb_error_CAN4.Visible = false;
            timer_Error_Boot.Enabled = false;
            tb_fnameMC1.Text = "";
            pb_loadMC1.Value = 0;

            lb_statusL_file2.Text = "";
            lb_statusL_mode2.Text = "";
            lb_statusL_plis2.Text = "";
            lb_statusL_reason2.Text = "";
            lb_statusL_status2.Text = "";
            lb_statusL_t12.Text = "";
            lb_statusL_t22.Text = "";
            lb_statusL_t32.Text = "";

            lb_statusR_file2.Text = "";
            lb_statusR_mode2.Text = "";
            lb_statusR_plis2.Text = "";
            lb_statusR_reason2.Text = "";
            lb_statusR_status2.Text = "";
            lb_statusR_t12.Text = "";
            lb_statusR_t22.Text = "";
            lb_statusR_t32.Text = "";

            lb_ecL2_file.Text = "";
            lb_ecL2_plis1.Text = "";
            lb_ecL2_plis2.Text = "";
            lb_ecL2_ram.Text = "";
            lb_ecL2_ram1.Text = "";
            lb_ecL2_ram2.Text = "";

            lb_ecR2_file.Text = "";
            lb_ecR2_plis1.Text = "";
            lb_ecR2_plis2.Text = "";
            lb_ecR2_ram.Text = "";
            lb_ecR2_ram1.Text = "";
            lb_ecR2_ram2.Text = "";

            lb_stL2_cmos1.Text = "";
            lb_stL2_cmos2.Text = "";
            lb_stR2_cmos1.Text = "";
            lb_stR2_cmos2.Text = "";
            tb_SN.Text = "";

        }
        
        #endregion

        #region OLO_CANSet
        private void bt_Exit_Click(object sender, EventArgs e)
        {
            if (uniCAN != null)
                if (uniCAN.Is_Open)
                {
                    uniCAN.Recv_Disable();
                    uniCAN.Close();
                }
            Application.Exit();
        }
        private void bt_About_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }
        private void UpdatePassportList()
        {
            listb_Passport.Items.Clear();
            listb_Passport.Items.AddRange((new DirectoryInfo(m_strPathToPassports)).GetFiles("*.txt"));
            if (listb_Passport.Items.Count > 0)
                listb_Passport.SelectedIndex = 0;
        }

		#region Управление CAN
		private void bt_OpenCAN_Click(object sender, EventArgs e)
		{
            if (comboBox1.SelectedItem.ToString() == "No CAN" || comboBox1.Items.Count < 1)
                return;
            if (comboBox1.SelectedItem.ToString() == "USB Marathon")
            {
                marCAN = new MCANConverter();
                uniCAN = marCAN as MCANConverter;
            }
            //else if (comboBox1.SelectedItem.ToString() == "USB Marathon2")
            //{
            //    mar2CAN = new M2CANConverter();
            //    uniCAN = mar2CAN as M2CANConverter;
            //}
            else if (comboBox1.SelectedItem.ToString() == "PCI Advantech")
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
            uniCAN.Speed = 0;
            lb_error_CAN.Visible = false;
            if (!uniCAN.Open())
            {
                state_Error();
                return;
            }
            state_Ready();
			frame.data = new Byte[8];
            _state = State.OpenedState;
            if (listb_badpix.Items.Count > 0)
                listb_badpix.Items.Clear();
            list_badpix_FIFO.Clear();
            uniCAN.Recv_Enable();
		}
        private void bt_CloseCAN_Click(object sender, EventArgs e)
		{
            if (_state == State.VideoState)
            {
                _state = State.StoppingVideoState;
                VideoTimer.Enabled = false;
                //chb_PRunVideo.Checked = false;
                //chb_PShot.Checked = false;
                chb_PShot.CheckState = CheckState.Unchecked;
                chb_PRunVideo.CheckState = CheckState.Unchecked;
            }
            if (_state == State.OpenedState)
            {
                if (uniCAN.Is_Open)
                {
                    uniCAN.Recv_Disable();
                    uniCAN.Close();
                }
            }
            state_Error();
            lb_error_CAN.Visible = false;
            _state = State.NotOpenState;
            if (listb_badpix.Items.Count > 0)
                listb_badpix.Items.Clear();
            list_badpix_FIFO.Clear();
            uniCAN.Recv_Disable();
            uniCAN = null;
        }

		#endregion

        #region Обработка нажатий мыши на списке паспортов
        private void listb_Passport_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint num_points_in_pass = 0;
            lb_num_points_in_pass.Text = "";
            if (listb_Passport.Items.Count > 0)
            {
                using (StreamReader sr = new StreamReader(m_strPathToPassports + listb_Passport.SelectedItem.ToString()))
                {
                    String bad_pix_Pas;
                    list_badpix_TXT.Clear();
                    while (sr.Peek() >= 0)
                    {
                        if ((bad_pix_Pas = sr.ReadLine()) != "")
                        {
                            num_points_in_pass++;
                            list_badpix_TXT.Add(bad_pix_Pas);
                        }
                    }
                }
                lb_num_points_in_pass.Text = "Точек: " + num_points_in_pass.ToString();
            }
        }
        private void listb_Passport_Click(object sender, EventArgs e)
        {
            uint num_points_in_pass = 0;
            lb_num_points_in_pass.Text = "";
            if (listb_Passport.Items.Count > 0)
            {
                using (StreamReader sr = new StreamReader(m_strPathToPassports + listb_Passport.SelectedItem.ToString()))
                {
                    String bad_pixPas;
                    list_badpix_TXT.Clear();
                    while (sr.Peek() >= 0)
                    {
                        if ((bad_pixPas = sr.ReadLine()) != "")
                        { 
                            num_points_in_pass++;
                            list_badpix_TXT.Add(bad_pixPas);
                        }
                    }
                }
                lb_num_points_in_pass.Text = "Точек: " + num_points_in_pass.ToString();
            }
        }
        private void listb_Passport_DoubleClick(object sender, EventArgs e)
        {
            uint num_points_in_pass = 0;
            lb_num_points_in_pass.Text = "";
            if (listb_Passport.Items.Count > 0)
            {
                using (StreamReader sr = new StreamReader(m_strPathToPassports + listb_Passport.SelectedItem.ToString()))
                {
                    String bad_pixPas;
                    list_badpix_TXT.Clear();
                    while (sr.Peek() >= 0)
                    {
                        if ((bad_pixPas = sr.ReadLine()) != "")
                        {
                            num_points_in_pass++;
                            list_badpix_TXT.Add(bad_pixPas);
                        }
                    }
                }
                lb_num_points_in_pass.Text = "Точек: " + num_points_in_pass.ToString();
                if (listb_badpix.Items.Count > 0)
                    listb_badpix.Items.Clear();
                foreach (var item in list_badpix_TXT)
                    listb_badpix.Items.Add(item);
                list_badpix_FIFO.Clear();
                foreach (var item in list_badpix_TXT)
                {
                    FIFO_ITEM tmp = new FIFO_ITEM();
                    tmp.x = Convert.ToUInt16(item.Split(new Char[] { ' ', '\t' })[0]);
                    tmp.y = Convert.ToUInt16(item.Split(new Char[] { ' ', '\t' })[1]);
                    list_badpix_FIFO.Add(tmp);
                }

            }
        }
      
        #endregion

        void malevich()
        {
            for (int i = 0; i < Const.IMAGE_CX; i++)
                for (int j = 0; j < Const.IMAGE_CY; j++)
                {
                    image_CMOS.SetPixel(i, j, Color.Black);
                    image_CMOS1.SetPixel(i, j, Color.Black);
                    image_CMOS2.SetPixel(i, j, Color.Black);
                }
            //for (int i = 0; i < Const.IMAGE_CX * 2; i++)
            //    for (int j = 0; j < Const.IMAGE_CY * 2; j++)
            //        image_CMOS.SetPixel(i, j, Color.Black);
            Bitmap ni = new Bitmap(Const.IMAGE_CX * 2, Const.IMAGE_CY * 2);
            using (Graphics gr = Graphics.FromImage(ni))
            {
                gr.CompositingMode = CompositingMode.SourceCopy;
                gr.CompositingQuality = CompositingQuality.HighSpeed;
                gr.SmoothingMode = SmoothingMode.HighSpeed;//.HighQuality;
                gr.InterpolationMode = InterpolationMode.NearestNeighbor;// .HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.None;// .HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    gr.DrawImage(image_CMOS, new Rectangle(0, 0, Const.IMAGE_CX * 2, Const.IMAGE_CY * 2), 0, 0, image_CMOS.Width, image_CMOS.Height, GraphicsUnit.Pixel, wrapMode);
                    gr.DrawImage(image_CMOS1, new Rectangle(0, 0, Const.IMAGE_CX * 2, Const.IMAGE_CY * 2), 0, 0, image_CMOS.Width, image_CMOS.Height, GraphicsUnit.Pixel, wrapMode);
                    gr.DrawImage(image_CMOS2, new Rectangle(0, 0, Const.IMAGE_CX * 2, Const.IMAGE_CY * 2), 0, 0, image_CMOS.Width, image_CMOS.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            pictureBox1.Image = ni;
            for (int i = 0; i < image_data.Length; i++)
            {
                image_data[i] = 0;
//                image_data1[i] = 0;
//                image_data2[i] = 0;
            }
        }
        #region Переключение матриц
        private void rb_CMOS1_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_CMOS1.Checked)
            {
                gbox_CMOS1.Enabled = true;
                gbox_CMOS2.Enabled = false;
                gbox_CMOS2.BackColor = SystemColors.Control;
                gbox_CMOS1.BackColor = Color.PowderBlue;
                rb_CMOS2.Checked = false;
                select_CMOS = 0;
                list_badpixCal.Clear();
                if (listb_badpix.Items.Count > 0)
                    listb_badpix.Items.Clear();
                foreach (var item in list_badpixCal)
                    listb_badpix.Items.Add(item);
                list_badpix_FIFO.Clear();
                chb_Calibr.CheckState = CheckState.Unchecked;
                chb_Calibr.Checked = false;
//                image_CMOS = (Bitmap)malevich.Clone();
//                pictureBox1.Image = image_CMOS;
                malevich();
            }
        }
        private void rb_CMOS2_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_CMOS2.Checked)
            {
                gbox_CMOS2.Enabled = true;
                gbox_CMOS1.Enabled = false;
                gbox_CMOS1.BackColor = SystemColors.Control;
                gbox_CMOS2.BackColor = Color.PowderBlue;
                rb_CMOS1.Checked = false;
                select_CMOS = 1;
                list_badpixCal.Clear();
                if (listb_badpix.Items.Count > 0)
                    listb_badpix.Items.Clear();
                foreach (var item in list_badpixCal)
                    listb_badpix.Items.Add(item);
                list_badpix_FIFO.Clear();
                chb_Calibr.CheckState = CheckState.Unchecked;
                chb_Calibr.Checked = false;
//                image_CMOS = (Bitmap)malevich.Clone();
//                pictureBox1.Image = image_CMOS;
                malevich();
            }
        }
        #endregion

        #region Включить/выключить передачу кадров
        private void chb_PRunVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_PRunVideo.Checked)
            {
                VideoTimer.Enabled = true;
                _state = State.VideoState;
                //if(!uniCAN.Is_Open)
                //    uniCAN.Open();
                listb_Passport.Enabled = false;
                bt_SavePass.Enabled = false;
                bt_UpLoadPass.Enabled = false;
                bt_DnLoadPass.Enabled = false;
                bt_UpLoadConf.Enabled = false;
                bt_DnLoadConf.Enabled = false;
//                image_CMOS = (Bitmap)malevich.Clone();
//                pictureBox1.Image = image_CMOS;
                malevich();
                chb_PFIFO.Enabled = false;
            }
            else
            {
//                VideoTimer.Enabled = false;
                _state = State.StoppingVideoState;
                uniCAN.Clear_RX();
                //if (uniCAN.Is_Open)
                //    uniCAN.Close();
                listb_Passport.Enabled = true;
                bt_SavePass.Enabled = true;
                bt_UpLoadPass.Enabled = true;
                bt_DnLoadPass.Enabled = true;
                bt_UpLoadConf.Enabled = true;
                bt_DnLoadConf.Enabled = true;
                chb_PShot.CheckState = CheckState.Unchecked;
                malevich();
                chb_PFIFO.Enabled = true;
            }
        }
        #endregion
        #region Изменение параметров CMOS1
        private void bt_CMOS1SetDAC1_Click(object sender, EventArgs e)
        {
            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS1_SET_VREF;
            cmd.prm.words.lo_word.word = Convert.ToUInt16(tb_VREF1.Text);
            if (_state == State.VideoState)
                EnqueueCommandList.Add(cmd);
            else
                if (!SendCommand(cmd, ref res))
                    return;
        }
        private void CMOS1SetDAC2_Click(object sender, EventArgs e)
        {
            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS1_SET_VINB;
            cmd.prm.words.lo_word.word = Convert.ToUInt16(tb_VINB1.Text);
            if (_state == State.VideoState)
                EnqueueCommandList.Add(cmd);
            else
                if (!SendCommand(cmd, ref res))
                    return;
        }
        private void cb_CMOS1Enable_CheckedChanged(object sender, EventArgs e)
        {
            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS1_ENABLE_TERMOSTAT;
            cmd.prm.words.lo_word.bytes.lo_byte = (cb_CMOS1Enable.Checked ? (Byte)1 : (Byte)0);

            if (_state == State.VideoState)
                EnqueueCommandList.Add(cmd);
            else
                if (!SendCommand(cmd, ref res))
                    return;
        }
        #endregion
        #region Изменение параметров CMOS2
        private void CMOS2SetDAC1_Click(object sender, EventArgs e)
        {
            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS2_SET_VREF;
            cmd.prm.words.lo_word.word = Convert.ToUInt16(tb_VREF2.Text);
            if (_state == State.VideoState)
                EnqueueCommandList.Add(cmd);
            else
                if (!SendCommand(cmd, ref res))
                    return;
        }
        private void CMOS2SetDAC2_Click(object sender, EventArgs e)
        {
            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS2_SET_VINB;
            cmd.prm.words.lo_word.word = Convert.ToUInt16(tb_VINB2.Text);
            if (_state == State.VideoState)
                EnqueueCommandList.Add(cmd);
            else
                if (!SendCommand(cmd, ref res))
                    return;
        }
        private void cb_CMOS2Enable_CheckedChanged(object sender, EventArgs e)
        {
            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS2_ENABLE_TERMOSTAT;
            cmd.prm.words.lo_word.bytes.lo_byte = (cb_CMOS2Enable.Checked ? (Byte)1 : (Byte)0);

            if (_state == State.VideoState)
                EnqueueCommandList.Add(cmd);
            else
                if (!SendCommand(cmd, ref res))
                    return;
        }
        #endregion

        #region SendCommand Отправка команды и получение результата
        public unsafe Boolean SendCommand(COMMAND cc, ref RESULT res)
        {
            if (uniCAN.Is_Open)
            {
                canmsg_t msg = new canmsg_t();
                msg.data = new Byte[8];
                RESULT rr = new RESULT();
                msg.id = Const.CAN_PC2ARM_MSG_ID;
                msg.len = 6;
                Marshal.Copy(new IntPtr(&cc), msg.data, 0, 8);
                if (!uniCAN.Send(ref msg, 10000))
                    return false;
                Byte[] arr = new Byte[8];
/*
                do
                {
                    uniCAN.Recv(ref msg, 100);
                } while (msg.data[0] != 0x55);
*/
                try
                {
                    uniCAN.Recv(ref msg, 10000);
                }
                catch (Exception)
                {
                    return false;
                }
                if (msg.data[0] != 0x55)
                    return false;
                Marshal.Copy(msg.data, 0, new IntPtr(&rr), 8);
                res = rr;
//                uniCAN.Clear_RX();
                return true;
            }
            else
                return false;
        }
        #endregion

        #region Очистка списка битых пикселей
        private void bt_clear_badpix_Click(object sender, EventArgs e)
        {
            list_badpixCal.Clear();
            listb_badpix.Items.Clear();
            list_badpix_FIFO.Clear();
            num_bad_points = list_badpix_FIFO.Count;
            lb_num_bad_points.Text = "Плохих точек:  " + num_bad_points.ToString();
        }
        #endregion
        #region Сортировка списка битых пикселей
        private void bt_sort_badpix_Click(object sender, EventArgs e)
        {
            list_badpix_FIFO = list_badpix_FIFO.Distinct().ToList();
            list_badpix_FIFO.Sort(delegate(FIFO_ITEM us1, FIFO_ITEM us2)
            { return us1.x.CompareTo(us2.x); });
            num_bad_points = list_badpix_FIFO.Count;

            listb_badpix.Items.Clear();

            foreach (var item in list_badpix_FIFO)
            {
                listb_badpix.Items.Add(item.x.ToString() + "\t" + item.y.ToString());
            }
            lb_num_bad_points.Text = "Плохих точек:  " + num_bad_points.ToString();
        }
        #endregion

        #region Включение калибровки
        private void chb_Calibr_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_Calibr.Checked)
            {
                lb_num_bad_points.Visible = true;
                lb_num_bad_points.ForeColor = Color.White;
                lb_num_bad_points.BackColor = Color.Red;
            }
            else
            {
                lb_num_bad_points.ForeColor = SystemColors.ControlText;
                lb_num_bad_points.BackColor = SystemColors.Control;
                lb_num_bad_points.Visible = false;
                list_badpix_FIFO.Clear();
            }
            //using (Graphics g = Graphics.FromImage(image_CMOS))
            //{
            //    Pen pen_black = new Pen(Color.Black);
            //    g.FillRectangle(Brushes.Black, 0, 0, IMAGE_CX, IMAGE_CY);
            //}
        }
        #endregion

        #region Выбор правое/левое крыло для паспорта и конфига
        private void rb_LeftW_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_LeftW.Checked)
                select_wing = 0;
            else
                select_wing = 1;
        }
        private void rb_RightW_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_RightW.Checked)
                select_wing = 1;
            else
                select_wing = 0;
        }
        #endregion

        #region Сохранение конфига под новый/старый объектив в файл
        private void bt_SaveConf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.DefaultExt = "cfg";
                sfd.AddExtension = true;
                sfd.Filter = "Файлы конфигурации (*.cfg)|*.cfg";
                sfd.InitialDirectory = m_strPathToConfigs;
                sfd.FileName = dttostr();
                if (select_CMOS == 0)
                    sfd.FileName += "_CMOS1";
                else
                    sfd.FileName += "_CMOS2";

                if (select_wing == 0)
                    sfd.FileName += "_Left";
                else
                    sfd.FileName += "_Right";

                if (chb_oldlens.Checked)
                    sfd.FileName += "_old_lens";
                else
                    sfd.FileName += "_new_lens";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Default))
                {
                    sw.WriteLine("[CONFIGURATION]");
                    sw.Write("SN=СУ-35 ");

                    if (select_wing == 0)
                        sw.Write("левый борт ");
                    else
                        sw.Write("правый борт ");

                    if (select_CMOS == 0)
                        sw.Write("CMOS1, ");
                    else
                        sw.Write("CMOS2, ");

                    if (chb_oldlens.Checked)
                        sw.Write("старый объектив, ");
                    else
                        sw.Write("новый объектив, ");

                    sw.WriteLine(DateTime.Now.Day.ToString("D2") + "." + DateTime.Now.Month.ToString("D2") + "." + DateTime.Now.Year.ToString());

                    sw.WriteLine("Xc=" + num_CX.Value.ToString());
                    sw.WriteLine("Yc=" + num_CY.Value.ToString());
                    sw.WriteLine("Rs=120\r\nRb=122\r\nLc=5\r\nLimit=80\r\nVinb=1023\r\nVref=900");
                    if (chb_oldlens.Checked)
                        sw.WriteLine("\r\n; Fi=AX^3+BX^2+CX\r\nA=+1,8e-5\r\nB=+3,81e-5\r\nC=+4,5e-1");
                    else
                        sw.WriteLine("A=+1,64940E-5\r\nB=-1,47800E-3\r\nC=+6,67499E-1");
                }
            }
        }
        #endregion
        #region Загрузка конфига в ОЛО
        private void bt_UpLoadConf_Click(object sender, EventArgs e)
        {
            //DialogResult upl = MessageBox.Show("Загрузить в ОЛО конфигурацию матрицы " + ((select_CMOS == 0) ? "CMOS1" : "CMOS2") + " из файла?",
            //                    "Загрузка конфигурации в ОЛО", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            DialogResult upl = MessageBox.Show("Загрузить в ОЛО конфигурацию матрицы " + ((select_CMOS == 0) ? "CMOS1" : "CMOS2") + "\r\nиз таблицы (Да) или из файла (Нет)?",
                                "Загрузка конфигурации в ОЛО", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (upl == DialogResult.Cancel)
                return;
            if (upl == DialogResult.Yes)
            {
                CONFIG_FILE_STRUCTURE cfg = new CONFIG_FILE_STRUCTURE();

                String sn = "СУ-35 ";
                if (select_wing == 0)
                    sn += "левый борт ";
                else
                    sn += "правый борт ";
                if (select_CMOS == 0)
                    sn += "CMOS1, ";
                else
                    sn += "CMOS2, ";
                if (chb_oldlens.Checked)
                    sn += "старый объектив, ";
                else
                    sn += "новый объектив, ";
                sn += DateTime.Now.Day.ToString("D2") + "." + DateTime.Now.Month.ToString("D2") + "." + DateTime.Now.Year.ToString();
                Byte[] tmp = new Byte[128];
                tmp = Encoding.Default.GetBytes(sn);
                cfg.szSerialNumber = new Byte[128];
                //cfg.szSerialNumber
                for (int i = 0; i < 128; i++)
                    cfg.szSerialNumber[i] = 0;
                Array.Copy(tmp, cfg.szSerialNumber, tmp.Length);
                cfg.nXc = (UInt16)num_CX.Value;
                cfg.nYc = (UInt16)num_CY.Value;
                cfg.nRs = (UInt16)120;
                cfg.nRb = (UInt16)122;
                cfg.cLc = (Byte)5;
                cfg.nLimit = (UInt16)80;
                cfg.nVinb = (UInt16)1023;
                cfg.nVref = (UInt16)900;
                if (chb_oldlens.Checked)
                {
                    cfg.fA = (Single)(+1.8e-5);
                    cfg.fB = (Single)(+3.81e-5);
                    cfg.fC = (Single)(+4.5e-1);
                }
                else
                {
                    cfg.fA = (Single)(+1.64940E-5);
                    cfg.fB = (Single)(-1.47800E-3);
                    cfg.fC = (Single)(+6.67499E-1);
                }

                Byte[] cfg_array = new Byte[Marshal.SizeOf(cfg)];
                cfg_array = StructToBuff<CONFIG_FILE_STRUCTURE>(cfg);

                COMMAND cmd = new COMMAND();
                RESULT res = new RESULT();
                cmd.magic = Const.MAGIC_BYTE;
                cmd.cmd = rb_CMOS1.Checked ? Const.COMMAND_CMOS1_SAVE_CONFIG : Const.COMMAND_CMOS2_SAVE_CONFIG;
                cmd.prm.words.lo_word.word = (UInt16)Marshal.SizeOf(cfg);

                //if (uniCAN.Is_Open)
                //    uniCAN.Close();
                //uniCAN.Open();
                if (!SendCommand(cmd, ref res))
                    return;

                int packets = (Marshal.SizeOf(cfg) + 8 - 1) / 8;
                int last_packet_size = ((Marshal.SizeOf(cfg) % 8) == 0 ? 8 : Marshal.SizeOf(cfg) % 8);
                int counter = 0;
                for (int i = 0; i < packets; i++)
                {
                    int packet_size = (i == packets - 1 ? last_packet_size : 8);
                    canmsg_t msg = new canmsg_t();
                    msg.data = new Byte[8];
                    msg.id = Const.CAN_PC2ARM_MSG_ID;
                    msg.len = (Byte)packet_size;

                    for (int j = 0; j < packet_size; j++)
                        msg.data[j] = cfg_array[counter++];

                    if (!uniCAN.Send(ref msg))
                        return;
                }
                MessageBox.Show("Конфигурация матрицы " + (rb_CMOS1.Checked ? "CMOS1" : "CMOS2") + " успешно записана в ОЛО", "Запись Конфигурации", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (upl == DialogResult.No)
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Файлы конфигурации (*.cfg)|*.cfg";
                    ofd.InitialDirectory = m_strPathToConfigs;
                    if (ofd.ShowDialog() != DialogResult.OK)
                        return;

                    CONFIG_FILE_STRUCTURE cfg = new CONFIG_FILE_STRUCTURE();

                    IniFile inifile = new IniFile(ofd.FileName);
                    cfg.szSerialNumber = new Byte[128];
                    System.Text.Encoding.Default.GetBytes(inifile._GetString("CONFIGURATION", "SN"), 0, inifile._GetString("CONFIGURATION", "SN").Length, cfg.szSerialNumber, 0);
                    cfg.nXc = (UInt16)inifile._GetInt("CONFIGURATION", "Xc");
                    cfg.nYc = (UInt16)inifile._GetInt("CONFIGURATION", "Yc");
                    cfg.nRs = (UInt16)inifile._GetInt("CONFIGURATION", "Rs");
                    cfg.nRb = (UInt16)inifile._GetInt("CONFIGURATION", "Rb");
                    cfg.cLc = (Byte)inifile._GetInt("CONFIGURATION", "Lc");
                    cfg.nLimit =(UInt16) inifile._GetInt("CONFIGURATION", "Limit");
                    cfg.nVinb = (UInt16)inifile._GetInt("CONFIGURATION", "Vinb");
                    cfg.nVref = (UInt16)inifile._GetInt("CONFIGURATION", "Vref");
                    cfg.fA = (Single)inifile._GetDouble("CONFIGURATION", "A");
                    cfg.fB = (Single)inifile._GetDouble("CONFIGURATION", "B");
                    cfg.fC = (Single)inifile._GetDouble("CONFIGURATION", "C");

                    Byte[] cfg_array = new Byte[Marshal.SizeOf(cfg)];
                    cfg_array = StructToBuff<CONFIG_FILE_STRUCTURE>(cfg);

                    COMMAND cmd = new COMMAND();
                    RESULT res = new RESULT();
                    cmd.magic = Const.MAGIC_BYTE;
                    cmd.cmd = rb_CMOS1.Checked ? Const.COMMAND_CMOS1_SAVE_CONFIG : Const.COMMAND_CMOS2_SAVE_CONFIG;
                    cmd.prm.words.lo_word.word = (UInt16)Marshal.SizeOf(cfg);

                    //if (uniCAN.Is_Open)
                    //    uniCAN.Close();
                    //uniCAN.Open();
                    if (!SendCommand(cmd, ref res))
                        return;

			        int packets = (Marshal.SizeOf(cfg) + 8 - 1) / 8;
			        int last_packet_size = ((Marshal.SizeOf(cfg) % 8) == 0 ? 8 : Marshal.SizeOf(cfg) % 8);
                    int counter = 0;
                    for (int i = 0; i < packets; i++)
                    {
				        int packet_size = (i == packets - 1 ? last_packet_size : 8);
                        canmsg_t msg = new canmsg_t();
                        msg.data = new Byte[8];
                        msg.id = Const.CAN_PC2ARM_MSG_ID;
                        msg.len = (Byte)packet_size;

				        for(int j = 0; j < packet_size; j++)
                            msg.data[j] = cfg_array[counter++];

                        if (!uniCAN.Send(ref msg))
                            return;
                    }
                    //if (uniCAN.Is_Open)
                    //    uniCAN.Close();
                    MessageBox.Show("Конфигурация матрицы " + (rb_CMOS1.Checked ? "CMOS1" : "CMOS2") + " успешно записана в ОЛО", "Запись Конфигурации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion
        #region Чтение конфига из ОЛО
        private unsafe void bt_DnLoadConf_Click(object sender, EventArgs e)
        {
            CONFIG_FILE_STRUCTURE cfg = new CONFIG_FILE_STRUCTURE();
            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = rb_CMOS1.Checked ? Const.COMMAND_CMOS1_GET_CONFIG : Const.COMMAND_CMOS2_GET_CONFIG;
            if (!SendCommand(cmd, ref res))
                return;
			int packets = (Marshal.SizeOf(cfg) + 8 - 1) / 8;
            int last_packet_size = ((Marshal.SizeOf(cfg) % 8) == 0 ? 8 : Marshal.SizeOf(cfg) % 8);

            cfg_array = new Byte[Marshal.SizeOf(cfg)];
            pb_CMOS.Maximum = packets - 1;

            if (uniCAN == null || !uniCAN.RecvPack(ref cfg_array, ref packets, 2000))
            {
                Trace.WriteLine("Err recv config data");
                return;
            }

            GCHandle handle = GCHandle.Alloc(cfg_array, GCHandleType.Pinned);
            cfg = (CONFIG_FILE_STRUCTURE)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(CONFIG_FILE_STRUCTURE));
            handle.Free();

            //cfg = BuffToStruct<CONFIG_FILE_STRUCTURE>(cfg_array);
            string ss = "Паспорт матрицы " + (rb_CMOS1.Checked ? "CMOS1" : "CMOS2") + " прочитан из ОЛО\r\n\r\n";
            String sn = Encoding.Default.GetString(cfg.szSerialNumber, 0, 128);
            ss += "SN = " + sn.Substring(0,sn.IndexOf('\0')) + CR;
            ss += "Xc = " + cfg.nXc.ToString() + CR;
            ss += "Yc = " + cfg.nYc.ToString() + CR;
            ss += "Rs = " + cfg.nRs.ToString() + CR;
            ss += "Rb = " + cfg.nRb.ToString() + CR;
            ss += "Lc = " + cfg.cLc.ToString() + CR;
            ss += "Limit = " + cfg.nLimit.ToString() + CR;
            ss += "Vinb = " + cfg.nVinb.ToString() + CR;
            ss += "Vref = " + cfg.nVref.ToString() + CR;
            ss += "A = " + cfg.fA.ToString() + CR;
            ss += "B = " + cfg.fB.ToString() + CR;
            ss += "C = " + cfg.fC.ToString() + CR;

            if (MessageBox.Show(ss + "\r\nСохранить в файл?", "Чтение конфига", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.DefaultExt = "cfg";
                    sfd.AddExtension = true;
                    sfd.Filter = "Файлы конфигурации (*.cfg)|*.cfg";
                    sfd.InitialDirectory = m_strPathToConfigs;
                    sfd.FileName = dttostr();
                    if (select_CMOS == 0)
                        sfd.FileName += "_CMOS1";
                    else
                        sfd.FileName += "_CMOS2";

                    if (select_wing == 0)
                        sfd.FileName += "_Left";
                    else
                        sfd.FileName += "_Right";

                    if (chb_oldlens.Checked)
                        sfd.FileName += "_old_lens";
                    else
                        sfd.FileName += "_new_lens";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    IniFile inifile = new IniFile(sfd.FileName);
                    inifile._SetString("CONFIGURATION", "SN", sn.Substring(0, sn.IndexOf('\0')));
                    inifile._SetInt("CONFIGURATION", "Xc", cfg.nXc);
                    inifile._SetInt("CONFIGURATION", "Yc", cfg.nYc);
                    inifile._SetInt("CONFIGURATION", "Rs", cfg.nRs);
                    inifile._SetInt("CONFIGURATION", "Rb", cfg.nRb);
                    inifile._SetInt("CONFIGURATION", "Lc", cfg.cLc);
                    inifile._SetInt("CONFIGURATION", "Limit", cfg.nLimit);
                    inifile._SetInt("CONFIGURATION", "Vinb", cfg.nVinb);
                    inifile._SetInt("CONFIGURATION", "Vref", cfg.nVref);
                    inifile._SetDouble("CONFIGURATION", "A", cfg.fA);
                    inifile._SetDouble("CONFIGURATION", "B", cfg.fB);
                    inifile._SetDouble("CONFIGURATION", "C", cfg.fC);
                }
            }
        }
        #endregion

        #region Сохранение паспорта в файл
        private void bt_SavePass_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.DefaultExt = "txt";
                sfd.AddExtension = true;
                sfd.Filter = "Файлы паспортов (*.txt)|*.txt";
                sfd.InitialDirectory = m_strPathToPassports;
                sfd.FileName = dttostr();
                if (select_CMOS == 0)
                    sfd.FileName += "_CMOS1";
                else
                    sfd.FileName += "_CMOS2";

                if (select_wing == 0)
                    sfd.FileName += "_Left";
                else
                    sfd.FileName += "_Right";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                if (listb_badpix.Items.Count == 0)
                    listb_badpix.Items.Add("0\t0");
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false))
                {
                    foreach (var item in listb_badpix.Items)
                        sw.WriteLine(item);
                }
            }

            UpdatePassportList();
        }
        #endregion
        #region Загрузка паспорта в ОЛО
        private void bt_UpLoadPass_Click(object sender, EventArgs e)
        {
            DialogResult upl = MessageBox.Show("Загрузить в ОЛО паспорт матрицы " + ((select_CMOS == 0) ? "CMOS1" : "CMOS2") + "\r\nиз таблицы (Да) или из файла (Нет)?",
                                "Загрузка паспорта в ОЛО", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (upl == DialogResult.Cancel)
                return;
            if (upl == DialogResult.Yes)
            {
/*
                if (list_badpixCal.Count == 0)
                    list_badpixCal.Add("0\t0");
                String FileName = m_strPathToPassports + "\\" + dttostr();
                if (select_CMOS == 0)
                    FileName += "_CMOS1";
                else
                    FileName += "_CMOS2";

                if (select_wing == 0)
                    FileName += "_Left";
                else
                    FileName += "_Right";

                using (StreamWriter sw = new StreamWriter(FileName + ".txt", false))
                {
                    foreach (var item in list_badpixCal)
                        sw.WriteLine(item);
                }
 */
                // перегружаем список в массив битых пикселов
                list_badpix_FIFO.Clear();
                //foreach (var item in list_badpixCal)
                //{
                //    FIFO_ITEM tmp = new FIFO_ITEM();
                //    tmp.x = Convert.ToUInt16(item.Split(new Char[] { ' ', '\t' })[0]);
                //    tmp.y = Convert.ToUInt16(item.Split(new Char[] { ' ', '\t' })[1]);
                //    list_badpix_FIFO.Add(tmp);
                //}
                foreach (String item in listb_badpix.Items)
                {
                    FIFO_ITEM tmp = new FIFO_ITEM();
                    tmp.x = Convert.ToUInt16(item.Split(new Char[] { ' ', '\t' })[0]);
                    tmp.y = Convert.ToUInt16(item.Split(new Char[] { ' ', '\t' })[1]);
                    list_badpix_FIFO.Add(tmp);
                }
            }
            else
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Файлы паспортов (*.txt)|*.txt";
                    ofd.InitialDirectory = m_strPathToPassports;
                    if (ofd.ShowDialog() != DialogResult.OK)
                        return;
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {
                        String bad_pixPas;
                        list_badpix_TXT.Clear();
                        while (sr.Peek() >= 0)
                        {
                            if ((bad_pixPas = sr.ReadLine()) != "")
                                list_badpix_TXT.Add(bad_pixPas);
                        }
                    }
                }
                list_badpix_FIFO.Clear();
                foreach (var item in list_badpix_TXT)
                {
                    FIFO_ITEM tmp = new FIFO_ITEM();
                    tmp.x = Convert.ToUInt16(item.Split(new Char[] { ' ', '\t' })[0]);
                    tmp.y = Convert.ToUInt16(item.Split(new Char[] { ' ', '\t' })[1]);
                    list_badpix_FIFO.Add(tmp);
                }
            }
            UpdatePassportList();
            // Если список пустой, добавляем точку с координатами 0,0
            if(list_badpix_FIFO.Count() == 0)
            {
                FIFO_ITEM tmp = new FIFO_ITEM();
                tmp.x = 0;
                tmp.y = 0;
                list_badpix_FIFO.Add(tmp);
            }
            /*
             * 
             * Загрузка в ОЛО 
             * 
             */
            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = rb_CMOS1.Checked ? Const.COMMAND_CMOS1_SAVE_BAD_PIXELS : Const.COMMAND_CMOS2_SAVE_BAD_PIXELS;
            cmd.prm.words.lo_word.word = (UInt16)list_badpix_FIFO.Count();
            //if (uniCAN.Is_Open)
            //    uniCAN.Close();
            //uniCAN.Open();
            if (!SendCommand(cmd, ref res))
                return;
            for (int i = 0; i < list_badpix_FIFO.Count(); i++)
            {
                canmsg_t msg = new canmsg_t();
                msg.data = new Byte[8];
                msg.id = Const.CAN_PC2ARM_MSG_ID;
                msg.len = 4;
                msg.data[0] = (Byte)list_badpix_FIFO[i].x;
                msg.data[1] = (Byte)(list_badpix_FIFO[i].x >> 8);
                msg.data[2] = (Byte)list_badpix_FIFO[i].y;
                msg.data[3] = (Byte)(list_badpix_FIFO[i].y >> 8);
                if (!uniCAN.Send(ref msg))
                    return;
            }
            //if (uniCAN.Is_Open)
            //    uniCAN.Close();
            MessageBox.Show("Паспорт матрицы " + (rb_CMOS1.Checked ? "CMOS1" : "CMOS2") + " успешно записан в устройство", "Запись паспорта", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
        #region Чтение паспорта из ОЛО
        private unsafe void bt_DnLoadPass_Click(object sender, EventArgs e)
        {
            COMMAND cmd = new COMMAND();
//            RESULT res = new RESULT();
            cmd.magic = Const.MAGIC_BYTE;
            if (rb_CMOS1.Checked == true && rb_CMOS2.Checked == false)
                cmd.cmd = Const.COMMAND_CMOS1_GET_BAD_PIXELS;
            else if (rb_CMOS1.Checked == false && rb_CMOS2.Checked == true)
                cmd.cmd = Const.COMMAND_CMOS2_GET_BAD_PIXELS;
            else
            {
                cmd.cmd = Const.COMMAND_CMOS1_GET_BAD_PIXELS;
                rb_CMOS1.Checked = true;
            }
//            cmd.cmd = rb_CMOS1.Checked ? COMMAND_CMOS1_GET_BAD_PIXELS : COMMAND_CMOS2_GET_BAD_PIXELS;
            list_badpix_FIFO.Clear();
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
//            RESULT rr = new RESULT();
            msg.id = Const.CAN_PC2ARM_MSG_ID;
            msg.len = 6;
            Marshal.Copy(new IntPtr(&cmd), msg.data, 0, 8);

            if (!uniCAN.Send(ref msg))
            {
                Trace.WriteLine("error send cmd");
                return;
            }
            Byte[] aaa = new Byte[8];
            int item_count = 1;
//            uniCAN.Clear_RX();

            msg.data = new Byte[8];
            uniCAN.Recv(ref msg, 2000);
            while (msg.data[0] != 0x55 && msg.len != 6)
            {
                uniCAN.Recv(ref msg, 2000);
//                print_msg(msg);
            }
//            Trace.WriteLine("================");
//            print_msg(msg);
//            Trace.WriteLine("================");
            if (msg.data[0] != 0x55)
            {
                    Trace.WriteLine("Ошибка приема длины паспорта ОЛО. Принято magic " + aaa[0].ToString());
                return;
            }
            //int ret_item_count = item_count = aaa[2];
            int ret_item_count = item_count = BitConverter.ToUInt16(msg.data,2);
//            pb_CMOS.Maximum = item_count - 1;
            aaa = new Byte[item_count * 8];
            if (uniCAN == null || !uniCAN.RecvPack(ref aaa, ref ret_item_count, 5000))
            {
                Trace.WriteLine("Ошибка приема паспорта ОЛО. Принято " + ret_item_count.ToString());
//                    return;
            }
            for (int i = 0; i < item_count * 8; i += 8)
            {
                FIFO_ITEM tmp = new FIFO_ITEM();
                tmp.x = BitConverter.ToUInt16(aaa, i);
                tmp.y = BitConverter.ToUInt16(aaa, i + 2);
                list_badpix_FIFO.Add(tmp);
            }
            //}
            //if (uniCAN.Is_Open)
            //    uniCAN.Close();

            string ss = "";
            foreach (var item in list_badpix_FIFO)
                ss += item.x.ToString() + "\t" + item.y.ToString() + "\r\n";
            ss += "\r\nВсего битых пикселов: " + list_badpix_FIFO.Count.ToString() + "\r\n";
            if (MessageBox.Show("Паспорт матрицы " + (rb_CMOS1.Checked ? "CMOS1" : "CMOS2") + " прочитан из ОЛО\r\n\r\n" + 
                            ss + "\r\n\r\nСохранить в файл?", "Чтение паспорта", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.DefaultExt = "txt";
                    sfd.AddExtension = true;
                    sfd.Filter = "Файлы паспортов (*.txt)|*.txt";
                    sfd.InitialDirectory = m_strPathToPassports;
                    sfd.FileName = dttostr();
                    if (select_CMOS == 0)
                        sfd.FileName += "_CMOS1";
                    else
                        sfd.FileName += "_CMOS2";

                    if (select_wing == 0)
                        sfd.FileName += "_Left";
                    else
                        sfd.FileName += "_Right";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false))
                    {
                        foreach (var item in list_badpix_FIFO)
                            sw.WriteLine(item.x.ToString() + "\t" + item.y.ToString());
                    }
                }
                UpdatePassportList();
            }
        }
        #endregion

        #region Создание стринга из даты для имени файла
        public String dttostr()
        {
            return DateTime.Now.Year.ToString() +
                ((DateTime.Now.Month < 10) ? '0' + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) +
                ((DateTime.Now.Day < 10) ? '0' + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString()) +
                ((DateTime.Now.Hour < 10) ? '0' + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) +
                ((DateTime.Now.Minute < 10) ? '0' + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString());
        }
        public String dttostr2()
        {
            return DateTime.Now.Year.ToString() +
                ((DateTime.Now.Month < 10) ? '0' + DateTime.Now.Month.ToString() : DateTime.Now.Month.ToString()) +
                ((DateTime.Now.Day < 10) ? '0' + DateTime.Now.Day.ToString() : DateTime.Now.Day.ToString()) +
                ((DateTime.Now.Hour < 10) ? '0' + DateTime.Now.Hour.ToString() : DateTime.Now.Hour.ToString()) +
                ((DateTime.Now.Minute < 10) ? '0' + DateTime.Now.Minute.ToString() : DateTime.Now.Minute.ToString()) +
                ((DateTime.Now.Second < 10) ? '0' + DateTime.Now.Second.ToString() : DateTime.Now.Second.ToString());
        }
        #endregion

        #region Чтение картинки из ОЛО, отправка команд из буфера, рисование круга и прочая хрень
        private unsafe void VideoTimer_Tick(object sender, EventArgs e)
        {
            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();

            VideoTimer.Enabled = false;

            // отправляем все сообщения из списка
            while (EnqueueCommandList.Count > 0)
            {
                SendCommand(EnqueueCommandList[0], ref res);
                EnqueueCommandList.RemoveAt(0);
            }
            //if (_state != State.VideoState)
            //    return;
            // Установка симуляции выстрелов
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS_SET_SIMULATION_MODE;
		    cmd.prm.words.lo_word.bytes.lo_byte = (chb_PShot.Checked ? (Byte)0x01 : (Byte)0x00);
		    cmd.prm.words.lo_word.bytes.hi_byte = (chb_PFIFO.Checked ? (Byte)0x01 : (Byte)0x00);

            pb_CMOS.Maximum = 100;
            pb_CMOS.Value = 0;
            pb_CMOS.Refresh();
            if (!SendCommand(cmd, ref res))
                return;
            Trace.WriteLine("Установка симуляции выстрелов");
            //if (_state != State.VideoState)
            //    return;

            // Читаем температуру CMOS1
            pb_CMOS.Value = 25;
            pb_CMOS.Refresh();
//            Thread.Sleep(100);
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS1_GET_TEMPERATURE;

            if (!SendCommand(cmd, ref res))
            {
                chb_PRunVideo.CheckState = CheckState.Unchecked;
                return;
            }
            Trace.WriteLine("Читаем температуру CMOS1");

            Single fT1 = ((short)res.prm.words.lo_word.word) / (Single)10.0;
            lb_T1_val.Text = fT1.ToString("'+'0.0'°';'-'0.0'°';'0.0°'");

            // Читаем температуру CMOS2
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS2_GET_TEMPERATURE;

            pb_CMOS.Value = 50;
            pb_CMOS.Refresh();
//            Thread.Sleep(100);
            if (!SendCommand(cmd, ref res))
            {
                chb_PRunVideo.CheckState = CheckState.Unchecked;
                return;
            }
            Trace.WriteLine("Читаем температуру CMOS2");
            //if (_state != State.VideoState)
            //    return;

            Single fT2 = ((short)res.prm.words.lo_word.word) / (Single)10.0;
            lb_T2_val.Text = fT2.ToString("'+'0.0'°';'-'0.0'°';'0.0°'");

            pb_CMOS.Value = 75;
            pb_CMOS.Refresh();
//            Thread.Sleep(100);
            UInt32 shot_pixels = 0;

            // Чтение картинки
            cmd.prm.dword = 0;
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = rb_CMOS1.Checked ? Const.COMMAND_CMOS1_GET_RAW_IMAGE : Const.COMMAND_CMOS2_GET_RAW_IMAGE;
//            Byte[] image_data = new Byte[IMAGE_CX * IMAGE_CY];

            if (_state != State.VideoState)
                return;

            pb_CMOS.Value = 100;
            pb_CMOS.Refresh();
//            Thread.Sleep(100);
            //if (_state != State.VideoState)
            //    return;
            do
            {
                if (_state != State.VideoState)
                    return;
                if (!SendCommand(cmd, ref res))
                {
                    chb_PRunVideo.CheckState = CheckState.Unchecked;
                    return;
                }
                Application.DoEvents();
            } while (res.stat != Const.STATUS_OK);

            pb_CMOS.Value = 0;
            if (!chb_PFIFO.Checked)
            {
                Trace.WriteLine("Чтение картинки");
                UInt32 image_size = Const.IMAGE_CX * Const.IMAGE_CY * sizeof(Byte);
                UInt32 image_data_count = 0;
                image_size = 81353;
                int msg_count = (int)(image_size + Const.CAN_MAX_DATA_SIZE - 1) / Const.CAN_MAX_DATA_SIZE;
                msg_count = 10169;
                image_data = new Byte[msg_count * 8];
                pb_CMOS.Maximum = msg_count;
                pb_CMOS.Value = 0;
/*
                for (UInt32 i = 0; i < msg_count; i++)
                {
                    canmsg_t dat = new canmsg_t();
//                        label29.Text = i.ToString();
//                        label29.Refresh();
                    dat.data = new Byte[8];
                    if (uniCAN == null || !uniCAN.Recv(ref dat, 10))
                    {
                        Trace.WriteLine("Err recv image data");
                        return;
                    }
                    pb_CMOS.Value = (int)i;
                    pb_CMOS.Refresh();
//                        pb_CMOS.Invalidate();
                    UInt32 data_size = dat.len;
                    for (UInt32 j = 0; j < data_size; j++)
                        image_data[j + image_data_count] = dat.data[j];
                    image_data_count += data_size;
                }
*/

                if (uniCAN == null || !uniCAN.RecvPack(ref image_data, ref msg_count, 4000)) //!!!!!!!!!!!!!!!!!!!!!!!!!
                {
                    Trace.WriteLine("Err recv image data");
                    if (!chb_PShot.Checked)
                        goto lbl_pass;
                    return;
                }

                #region Режим калибровки (поиска плохих точек)
                if (chb_Calibr.Checked)
                {
                    if (calibration_started == false)
                    {
                        calibration_started = true;
                        list_badpix_FIFO.Clear();
                    }

                    for (int y = 0; y < Const.IMAGE_CY; y++)
                    {
                        for (int x = 0; x < Const.IMAGE_CX; x++)
                        {
                            Byte pixel = image_data[y * Const.IMAGE_CX + x];
                            if (pixel >= num_BadPixLimit.Value)
                            {
                                FIFO_ITEM item;
                                item.x = (ushort)x;
                                item.y = (ushort)y;
                                list_badpix_FIFO.Add(item);
                            }
                        }
                    }
                    list_badpix_FIFO = list_badpix_FIFO.Distinct().ToList();
                    listb_badpix.DataSource = null;
                    listb_badpix.Items.Clear();
                    foreach (var item in list_badpix_FIFO)
                        listb_badpix.Items.Add(item.x.ToString() + "\t" + item.y.ToString());
                    num_bad_points = list_badpix_FIFO.Count;
                    lb_num_bad_points.Text = "Плохих точек:  " + num_bad_points.ToString();

                }
                else
                {
                    calibration_started = false;
                }
                lb_num_bad_points.Text = "Плохих точек:" + list_badpix_FIFO.Count().ToString();
                #endregion
            }
            else
            {
                image_data = new Byte[10169 * 8];
            }

            // read CMOS FIFO buffer size
            Trace.WriteLine("Чтение кол-ва выстрелов");
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            if (uniCAN == null || !uniCAN.Recv(ref msg, 100))
            {
                Trace.WriteLine("Error read CMOS FIFO buffer size");
                shot_pixels = 0;
                //                    return;
            }
            else
            {
                shot_pixels = BitConverter.ToUInt16(msg.data, 0);
                Trace.WriteLine("CMOS FIFO buffer size = " + shot_pixels.ToString());
            }
            // read CMOS FIFO buffer data if exists
            // получаем массив координат выстрелов
            if (shot_pixels > 0)
            {
                UInt32 image_size = shot_pixels * 4;
                int msg_count = (int)(image_size + Const.CAN_MAX_DATA_SIZE - 1) / Const.CAN_MAX_DATA_SIZE;
                Trace.WriteLine("Чтение выстрелов");
                if (uniCAN == null || !uniCAN.RecvPack(ref shot_array, ref msg_count, 2000))
                {
                    Trace.WriteLine("Error read CMOS FIFO buffer data");
                    return;
                }

                shot_array_list.Clear();
                for (int i = 0; i < shot_pixels * 4; i += 4)
                {
                    FIFO_ITEM tmp;
                    tmp.x = BitConverter.ToUInt16(shot_array, i);
                    tmp.y = BitConverter.ToUInt16(shot_array, i + 2);
                    shot_array_list.Add(tmp);
                }
			}

            #region Средний фон
            UInt32 srfon = 0;
            if (chb0_srfon.Checked)
            {
                for (uint ii = 0; ii < Const.IMAGE_CY * Const.IMAGE_CX; ii++)
                {
                    srfon += image_data[ii];
                }
                srfon /= Const.IMAGE_CY * Const.IMAGE_CX;
                label29.Text = "Средний фон = " + srfon.ToString();
            }
            else
                label29.Text = "";

            #endregion

            #region построение картинки
            
            Trace.WriteLine("построение картинки");
            // построение картинки

            for (int ii = 0; ii < Const.IMAGE_CY; ii++)
            {
                for (int jj = 0; jj < Const.IMAGE_CX; jj++)
                {
                    Color col = Color.FromArgb(image_data[Const.IMAGE_CX * ii + jj], image_data[Const.IMAGE_CX * ii + jj], image_data[Const.IMAGE_CX * ii + jj]);
                    image_CMOS.SetPixel(jj, ii, col);
                }
            }

            // draw LEFT and TOP pixel lines with BLACK COLOR (for MIM Visualizer)
            using (Graphics g = Graphics.FromImage(image_CMOS))
            {
                Pen pen_black = new Pen(Color.Black);
                g.DrawLine(pen_black, 0, 0, Const.IMAGE_CX, 0);
                g.DrawLine(pen_black, 0, 0, 0, Const.IMAGE_CY);
            }

            // закрашиваем битые пиксели черным или подсвечиваем зеленым
            foreach (var item in list_badpix_FIFO)
            {
                if (chb_PHidebadpix.Checked)
                    image_CMOS.SetPixel(item.x, item.y, Color.Black);
                else
                    image_CMOS.SetPixel(item.x, item.y, Color.Lime);
            }

            if (cb_shotshow.Checked)
            {
                // рисуем выстрелы фиолетовым
                foreach (var item in shot_array_list)
                    image_CMOS.SetPixel(item.x, item.y, Color.Fuchsia);
                shot_array_list.Clear();
            }

            if (chb0_screen.Checked)
            {
                String scrname = dttostr2();
                if (select_CMOS == 0)
                    scrname += "_CMOS1";
                else
                    scrname += "_CMOS2";
                image_CMOS.Save(m_strPathToScreens + scrname + ".bmp", ImageFormat.Bmp);
                //using(var stream = FileStream(m_strPathToScreens + scrname + ".dat", FileMode.Create))
                //{
                //    stream.
                //}
                File.WriteAllBytes(m_strPathToScreens + scrname + ".dat", image_data);

                //Byte[] idata = new Byte[image_data.Length * 3];
                //uint num = 0;
                //for (int i = 0; i < image_data.Length; i++)
                //{
                //    idata[num++] = image_data[i];
                //    idata[num++] = image_data[i];
                //    idata[num++] = image_data[i];
                //}

                //                using (var stream = new MemoryStream(idata))
                //using (var bmp = new Bitmap(319, 255, PixelFormat.Format24bppRgb))
                //{
                //    BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
                //    Marshal.Copy(idata, 0, bmpData.Scan0, idata.Length);
                //    bmp.UnlockBits(bmpData);
                //    bmp.Save(m_strPathToScreens + scrname + "_.bmp", ImageFormat.Bmp);
                //}
            }

            // Увеличиваем картинку под размер picturebox
            Bitmap newImage = new Bitmap(Const.IMAGE_CX * 2, Const.IMAGE_CY * 2);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.CompositingMode = CompositingMode.SourceCopy;
                gr.CompositingQuality = CompositingQuality.HighSpeed;
                gr.SmoothingMode = SmoothingMode.HighSpeed;//.HighQuality;
                gr.InterpolationMode = InterpolationMode.NearestNeighbor;// .HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.None;// .HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    gr.DrawImage(image_CMOS, new Rectangle(0, 0, Const.IMAGE_CX * 2, Const.IMAGE_CY * 2), 0, 0, image_CMOS.Width, image_CMOS.Height, GraphicsUnit.Pixel, wrapMode);
                }            
            }

            pictureBox1.Image = newImage;

            if (pictureBox1.Image != null)
                DrawCrossCirkle();

#endregion
            #region Zoom
            if (m_bMousePressed == true) 
                DrawSelectionFrame();	// show selection frame

            if (m_bAreaSelected == true)
            {
                // copy selected area to zoomed-view window
                Bitmap tmp = new Bitmap(m_p2.X - m_p1.X, m_p2.Y - m_p1.Y);
                using (Graphics g = Graphics.FromImage(tmp))
                {
                    g.DrawImage(pictureBox1.Image, 0, 0, new Rectangle(m_p1.X, m_p1.Y, m_p2.X - m_p1.X, m_p2.Y - m_p1.Y), GraphicsUnit.Pixel);
                }

                Bitmap tmp_zoom = new Bitmap(zoom.pictureBox1.Width, zoom.pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(tmp_zoom))
                {
                    g.CompositingMode = CompositingMode.SourceCopy;
                    g.CompositingQuality = CompositingQuality.HighSpeed;
                    g.SmoothingMode = SmoothingMode.HighSpeed;//.HighQuality;
                    g.InterpolationMode = InterpolationMode.NearestNeighbor;// .HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.None;// .HighQuality;
                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        g.DrawImage(tmp, new Rectangle(0, 0, zoom.pictureBox1.Width, zoom.pictureBox1.Height), 0, 0, tmp.Width, tmp.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }
                zoom.pictureBox1.Image = tmp_zoom;
            }
            else
            {
                //zoom.Hide();
                if (zoom.Visible == true)
                    zoom.ClearView();
            }
            #endregion

        lbl_pass:
            if (_state == State.StoppingVideoState)
            {
                _state = State.OpenedState;
                VideoTimer.Enabled = false;
                return;
            }
            VideoTimer.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS_SET_SIMULATION_MODE;
            cmd.prm.words.lo_word.bytes.lo_byte = (chb_PShot.Checked ? (Byte)0x01 : (Byte)0x00);
            cmd.prm.words.lo_word.bytes.hi_byte = (chb_PFIFO.Checked ? (Byte)0x01 : (Byte)0x00);

            if (!SendCommand(cmd, ref res))
                return;
            Trace.WriteLine("Установка симуляции выстрелов");
            cmd.prm.dword = 0;
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = rb_CMOS1.Checked ? Const.COMMAND_CMOS1_GET_RAW_IMAGE : Const.COMMAND_CMOS2_GET_RAW_IMAGE;
            for (int i = 0; i < 10; i++)
			{
                SendCommand(cmd, ref res);
                Trace.WriteLine("Запрос картинки");
                Thread.Sleep(1000);
			}
        }
        #endregion

        #region Рисуем крест и круг
        private void DrawCrossCirkle()
        {
            if (chb_EnableCross.Checked) // Рисуем крест с окружностью
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    int xo = (int)num_CX.Value * pictureBox1.Width / Const.IMAGE_CX;
                    int yo = (int)num_CY.Value * pictureBox1.Height / Const.IMAGE_CY;

                    //      (1)
                    //       |
                    // (4)---0---(2)
                    //       |
                    //      (3)

                    int[,] pos = { { 0, -2000 }, { +2000, 0 }, { 0, +2000 }, { -2000, 0 } };

                    int x1;
                    int y1;
                    int x2;
                    int y2;

                    Double angle = (Double)num_CAngle.Value * Math.PI / 180;
                    Pen pen_red = new Pen(Color.Red);

                    // vertical line
                    x1 = (int)(pos[0, 0] * Math.Cos(angle) - pos[0, 1] * Math.Sin(angle));
                    y1 = (int)(pos[0, 0] * Math.Sin(angle) + pos[0, 1] * Math.Cos(angle));
                    x2 = (int)(pos[2, 0] * Math.Cos(angle) - pos[2, 1] * Math.Sin(angle));
                    y2 = (int)(pos[2, 0] * Math.Sin(angle) + pos[2, 1] * Math.Cos(angle));

                    g.DrawLine(pen_red, xo + x1, yo + y1, xo + x2, yo + y2);

                    // horizontal line
                    x1 = (int)(pos[1, 0] * Math.Cos(angle) - pos[1, 1] * Math.Sin(angle));
                    y1 = (int)(pos[1, 0] * Math.Sin(angle) + pos[1, 1] * Math.Cos(angle));
                    x2 = (int)(pos[3, 0] * Math.Cos(angle) - pos[3, 1] * Math.Sin(angle));
                    y2 = (int)(pos[3, 0] * Math.Sin(angle) + pos[3, 1] * Math.Cos(angle));

                    g.DrawLine(pen_red, xo + x1, yo + y1, xo + x2, yo + y2);

                    if (chb_CCirkle.Checked)
                    {
                        int R = (int)num_CCirkle.Value * pictureBox1.Width / Const.IMAGE_CX;
                        g.DrawEllipse(pen_red, xo - R, yo - R, R * 2, R * 2);
                    }
                }

            }

        }
        #endregion
        #region Окно зума и обработка кликов мыши
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (e.Button == MouseButtons.Left && m_bMousePressed == false)
                {
                    HideSelection();
                    m_bMousePressed = true;
                    m_p1 = new Point(e.X, e.Y);
                    m_p2 = m_p1;
                    DrawSelectionFrame();	// show selection frame
                }
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (e.Button == MouseButtons.Left && m_bMousePressed == true)
                {
                    X = e.X;
                    Y = e.Y;
                    CorrectXY(ref X, ref Y);
                    m_bMousePressed = false;
                    DrawSelectionFrame();	// hide selection frame
                    if (Math.Abs(m_p2.X - m_p1.X) > 3 && Math.Abs(m_p2.Y - m_p1.Y) > 3)
                    {
                        int l = Math.Min(m_p1.X, m_p2.X);
                        int t = Math.Min(m_p1.Y, m_p2.Y);
                        int r = Math.Max(m_p1.X, m_p2.X) + 1;
                        int b = Math.Max(m_p1.Y, m_p2.Y) + 1;
                        m_p1.X = l;
                        m_p1.Y = t;
                        m_p2.X = r;
                        m_p2.Y = b;
                        m_bAreaSelected = true;
                        if ((m_p2.X - m_p1.X) > 0 && (m_p2.Y - m_p1.Y) > 0)
                        {
                            zoom.Show();
                            zoom.BringToFront();
                            zoom.WindowState = FormWindowState.Normal;
                        }

                    }
                    else
                        m_bAreaSelected = false;
                    pictureBox1.Refresh();
                }
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (m_bMousePressed == true)
                {
                    X = e.X;
                    Y = e.Y;
                    CorrectXY(ref X, ref Y);

                    DrawSelectionFrame();	// hide selection frame
                    m_p2 = new Point(X, Y);
                    DrawSelectionFrame();	// show selection frame
                    pictureBox1.Refresh();
                }
            }
        }
        void DrawSelectionFrame()
        {
            if (pictureBox1.Image != null)
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    Pen pen_white = new Pen(Color.White);
                    pen_white.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    g.DrawRectangle(pen_white, m_p1.X, m_p1.Y, m_p2.X - m_p1.X, m_p2.Y - m_p1.Y);
                }
            }
        }
        void HideSelection()
        {
            m_bAreaSelected = false;
            //PaintBox->Repaint();
        }
        void CorrectXY(ref int X, ref int Y)
        {
            if (X < 0)
                X = 0;
            if (X > pictureBox1.Width - 1)
                X = pictureBox1.Width - 1;
            if (Y < 0)
                Y = 0;
            if (Y > pictureBox1.Height - 1)
                Y = pictureBox1.Height - 1;
        }
        #endregion
        public static T BuffToStruct<T>(byte[] arr)
        {
            GCHandle gch = GCHandle.Alloc(arr, GCHandleType.Pinned);
            IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(arr, 0);
            T ret = (T)Marshal.PtrToStructure(ptr, typeof(T));
            gch.Free();
            return default(T);
        }
        public static byte[] StructToBuff<T>(T value) where T : struct
        {
            byte[] arr = new byte[Marshal.SizeOf(value)]; // создать массив
            GCHandle gch = GCHandle.Alloc(arr, GCHandleType.Pinned); // зафиксировать в памяти
            IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(arr, 0); // и взять его адрес
            Marshal.StructureToPtr(value, ptr, true); // копировать в массив
            gch.Free(); // снять фиксацию
            return arr;
        }
        private void chb_EnableCross_CheckedChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                DrawCrossCirkle();
        }
        private void chb_CCirkle_CheckedChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
                DrawCrossCirkle();
        }
        private void listb_Passport_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (MessageBox.Show("Удалить " + m_strPathToPassports + listb_Passport.SelectedItem.ToString() + "?", "Удаление файла", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    File.Delete(m_strPathToPassports + listb_Passport.SelectedItem.ToString());
                    UpdatePassportList();
                }
            }
        }
        #region Запрос и запись серийника
        private void bt_SAVESN1_Click(object sender, EventArgs e)
        {
            if (tb_SN1.TextLength != 8)
            {
                MessageBox.Show("Ошибка! Длина серийного номера должна быть 8 цифр.");
                return;
            }
            char[] char_sn = new char[tb_SN1.TextLength];
            String[] str_sn = new String[tb_SN1.TextLength];

            Byte[] byte_sn = new Byte[tb_SN1.TextLength];
            char_sn = tb_SN1.Text.ToCharArray();
            for (int i = 0; i < char_sn.Length; i++)
            {
                Byte a;
                String b = "";
                b += char_sn[i];
                if (!Byte.TryParse(b, out a))
                {
                    MessageBox.Show("Ошибка! Длина серийного номера должна быть 8 цифр.");
                    return;
                }
                byte_sn[i] = a;
            }

            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = 0x16;
            if (!SendCommand(cmd, ref res))
                return;

            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg.id = Const.CAN_MSG_ID_PC2MC;
            msg.len = 8;
            for (int i = 0; i < 8; i++)
                msg.data[i] = byte_sn[i];

            if (!uniCAN.Send(ref msg))
            {
                Trace.WriteLine("error send cmd");
                return;
            }
            if (!uniCAN.Recv(ref msg, 2000))
                return;

        }
        private void bt_REQSN1_Click(object sender, EventArgs e)
        {
            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = 0x15;
            if (!SendCommand(cmd, ref res))
                return;
            
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            uniCAN.Recv(ref msg, 2000);
            tb_SN1.Clear();
            for (int j = 0; j < 8; j++)
            {
                tb_SN1.Text += msg.data[j].ToString();
            }
        }
        #endregion
        #endregion

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

        #region OLO_Test
        #region CAN
        private void bt_CloseCAN2_Click(object sender, EventArgs e)
        {
            if (uniCAN.Is_Open)
            {
                uniCAN.Recv_Disable();
                uniCAN.Close();
            }
            state_NotReady();
            lb_error_CAN.Visible = false;
            uniCAN.Recv_Disable();
            uniCAN = null;
            Timer_GetData.Enabled = false;
            timer_Reset_Shots.Enabled = false;
            timer_testOLO_L.Enabled = false;
            timer_testOLO_R.Enabled = false;
            //Timer_UpdateTime.Enabled = false;
            chb3_savelog.CheckState = CheckState.Unchecked;
        }
        private void bt_OpenCAN2_Click(object sender, EventArgs e)
        {
            switch (cb_CAN2.SelectedItem.ToString())
            {
                case "No CAN":
                    return;
                case "USB Marathon":
                    marCAN = new MCANConverter();
                    uniCAN = marCAN as MCANConverter;
                    break;
                case "PCI Advantech":
                    advCAN = new ACANConverter();
                    uniCAN = advCAN as ACANConverter;
                    break;
                case "PCI Elcus":
                    elcCAN = new ECANConverter();
                    uniCAN = elcCAN as ECANConverter;
                    break;
                case "Fake CAN driver":
                    fakeCAN = new FCANConverter();
                    uniCAN = fakeCAN as FCANConverter;
                    break;
                default:
                    return;
            }

            uniCAN.ErrEvent += new MyDelegate(Err_Handler);
            uniCAN.Progress += new MyDelegate(Progress_Handler);

            uniCAN.Port = 0;
            uniCAN.Speed = 2;
            lb_error_CAN2.Visible = false;
            if (!uniCAN.Open())
            {
                state_Error();
                return;
            }
            state_Ready();
            frame.data = new Byte[8];
            _state = State.OpenedState;
            uniCAN.Recv_Enable();
            Timer_GetData.Enabled = true;

            rstTimer3.AutoReset = false;
            rstTimer3.Interval = 5000;
            chb3_savelog.CheckState = CheckState.Unchecked;
            //            rstTimer3.
        }
        #endregion
        private void timer_testOLO_L_Tick(object sender, EventArgs e)
        {
            msg_t mm = new msg_t();
            mm.deviceID = Const.OLO_Left;
            mm.messageID = msg_t.mID_STATUS;
            Random r = new Random();
            mm.messageLen = 8;
            r.NextBytes(mm.messageData);
            mm.messageData[0] = 2;
            messages.Add(mm);
        }
        private void timer_testOLO_R_Tick(object sender, EventArgs e)
        {
            msg_t mm = new msg_t();
            mm.deviceID = Const.OLO_Right;
            mm.messageID = msg_t.mID_STATUS;
            Random r = new Random();
            mm.messageLen = 8;
            r.NextBytes(mm.messageData);
            mm.messageData[0] = 2;
            messages.Add(mm);
        }
        private void Timer_GetData_Tick(object sender, EventArgs e)
        {
            Timer_GetData.Enabled = false;
            //            Trace.Write("Recv... ");
            int az = 0, um = 0;
            label37.Text = uniCAN.VectorSize().ToString();
            if (uniCAN.VectorSize() > 50)
                uniCAN.Clear_RX();
            label37.Refresh();
            while (uniCAN.VectorSize() > 0)
            {
                canmsg_t msg = new canmsg_t();
                msg.data = new Byte[8];
                msg_t mm = new msg_t();
//                Application.DoEvents();
                uniCAN.Recv(ref msg, 100);
                mm = mm.FromCAN(msg);
                String strelka_s = "";
                String mss = ""; //, devname = "";
//                Application.DoEvents();
                switch (mm.deviceID)
                {
                    case Const.OLO_Left:
                        strelka_s = "ОЛО левый";
                        break;
                    case Const.OLO_Right:
                        strelka_s = "ОЛО правый";
                        break;
                    case Const.OLO_All:
                        strelka_s = "Всем ОЛО";
                        break;
                    default:
                        strelka_s = "Всем ОЛО";
                        break;
                }
                switch (mm.messageID)
                {
                    #region mID_DATA
                    case msg_t.mID_DATA:

                        az = BitConverter.ToInt16(mm.messageData, 4);
                        um = BitConverter.ToInt16(mm.messageData, 6);
                        if (az != 0x7FFF && um != 0x7FFF)
                        {
                            if (az >= 0)
                                mss = "Азимут = " + (az / 60).ToString("0'°'") + (az % 60).ToString() + "' ";
                            else
                                mss = "Азимут = -" + (Math.Abs(az) / 60).ToString("0'°'") + (Math.Abs(az) % 60).ToString() + "' ";
                            if (um >= 0)
                                mss += "Угол = " + (um / 60).ToString("0'°'") + (um % 60).ToString() + "'";
                            else
                                mss += "Угол = -" + (Math.Abs(um) / 60).ToString("0'°'") + (Math.Abs(um) % 60).ToString() + "'";
                            Shots sh = new Shots();
                            sh.bort = (mm.deviceID == Const.OLO_Left) ? (Byte)0 : (Byte)1;
                            sh.azimut = BitConverter.ToInt16(mm.messageData, 4);
                            sh.ugol = BitConverter.ToInt16(mm.messageData, 6);
                            list_shots.Add(sh);

                            if (timer_Reset_Shots.Enabled == false)
                            {
                                timer_Reset_Shots.Interval = timer_Reset_Shots_Interval;
                                timer_Reset_Shots.Enabled = true;
                            }
                            else
                            {
                                timer_Reset_Shots.Enabled = false;
                                timer_Reset_Shots.Interval = timer_Reset_Shots_Interval;
                                timer_Reset_Shots.Enabled = true;
                            }
                            //                        if (az != 0x7FFF && um != 0x7FFF && messages[i].messageID == msg_t.mID_DATA)
                            panel1.Refresh();
                        }
                        else
                            mss = "\tНе определено...\t";
                        break;
                    #endregion
                    #region mID_PROG
                    case msg_t.mID_PROG:
                        mss = "Переход ОЛО в РУП";
                        break;
                    #endregion
                    #region mID_STATUS
                    case msg_t.mID_STATUS:
                        if (rb2_piv11.Checked)
                        {
                            #region ПИВ 1.1
                            mss = "T1=" + ((SByte)mm.messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                                "T2=" + ((SByte)mm.messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                                "T3=" + ((SByte)mm.messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                            if (mm.deviceID == Const.OLO_Left)
                            {
                                switch (mm.messageData[0] & 3)
                                {
                                    case 0:
                                        lb_statusL_mode2.Text = "OPERATIONAL";
                                        cb_module2.SelectedIndex = 0;
                                        break;
                                    case 1:
                                        lb_statusL_mode2.Text = "SELFTEST";
                                        cb_module2.SelectedIndex = 1;
                                        break;
                                    case 2:
                                        lb_statusL_mode2.Text = "EMBEDCONTROL";
                                        cb_module2.SelectedIndex = 2;
                                        break;
                                    case 3:
                                        lb_statusL_mode2.Text = "PROGRAMMING";
                                        cb_module2.SelectedIndex = 3;
                                        break;
                                    default:
                                        lb_statusL_mode2.Text = "OPERATIONAL";
                                        break;
                                }
                                switch ((mm.messageData[0] >> 2) & 3)
                                {
                                    case 0:
                                        lb_statusL_reason2.Text = "BY REQUEST";
                                        break;
                                    case 1:
                                        lb_statusL_reason2.Text = "BY TIMER";
                                        break;
                                    case 2:
                                        lb_statusL_reason2.Text = "BY STATE";
                                        break;
                                    default:
                                        lb_statusL_reason2.Text = "BY REQUEST";
                                        break;
                                }
                                lb_statusL_status2.Text = (((mm.messageData[0] >> 4) & 1) == 1) ? "STATUS OK" : "STATUS FAIL";
                                lb_statusL_plis2.Text = (mm.messageData[2] & 1) == 1 && ((mm.messageData[2] >> 1) & 1) == 1 ? "PLIS OK" : "PLIS FAIL";
                                lb_statusL_file2.Text = ((mm.messageData[2] >> 2) & 1) == 1 ? "FILE OK" : "FILE FAIL";
                                lb_statusL_t12.Text = ((SByte)mm.messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                                lb_statusL_t22.Text = ((SByte)mm.messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                                lb_statusL_t32.Text = ((SByte)mm.messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");

                                lb_ecL2_file.Text = ((mm.messageData[2] >> 2) & 1) == 1 ? "FILE OK" : "FILE FAIL";
                                lb_ecL2_plis1.Text = (mm.messageData[2] & 1) == 1 ? "PLIS OK" : "PLIS FAIL";
                                lb_ecL2_plis2.Text = ((mm.messageData[2] >> 1) & 1) == 1 ? "PLIS OK" : "PLIS FAIL";
                                lb_ecL2_ram.Text = ((mm.messageData[2] >> 3) & 1) == 1 ? "RAM OK" : "RAM FAIL";
                                lb_ecL2_ram1.Text = ((mm.messageData[2] >> 4) & 1) == 1 ? "RAM OK" : "RAM FAIL";
                                lb_ecL2_ram2.Text = ((mm.messageData[2] >> 5) & 1) == 1 ? "RAM OK" : "RAM FAIL";

                                if (mm.messageData[6] != 0)
                                    lb_stL2_cmos1.Text = mm.messageData[6].ToString();
                                else
                                    lb_stL2_cmos1.Text = "";
                                if (mm.messageData[7] != 0)
                                    lb_stL2_cmos2.Text = mm.messageData[7].ToString();
                                else
                                    lb_stL2_cmos2.Text = "";
                            }
                            else
                            {
                                switch (mm.messageData[0] & 3)
                                {
                                    case 0:
                                        lb_statusR_mode2.Text = "OPERATIONAL";
                                        cb_module2.SelectedIndex = 0;
                                        break;
                                    case 1:
                                        lb_statusR_mode2.Text = "SELFTEST";
                                        cb_module2.SelectedIndex = 1;
                                        break;
                                    case 2:
                                        lb_statusR_mode2.Text = "EMBEDCONTROL";
                                        cb_module2.SelectedIndex = 2;
                                        break;
                                    case 3:
                                        lb_statusR_mode2.Text = "PROGRAMMING";
                                        cb_module2.SelectedIndex = 3;
                                        break;
                                    default:
                                        lb_statusR_mode2.Text = "OPERATIONAL";
                                        break;
                                }
                                switch ((mm.messageData[0] >> 2) & 3)
                                {
                                    case 0:
                                        lb_statusR_reason2.Text = "BY REQUEST";
                                        break;
                                    case 1:
                                        lb_statusR_reason2.Text = "BY TIMER";
                                        break;
                                    case 2:
                                        lb_statusR_reason2.Text = "BY STATE";
                                        break;
                                    default:
                                        lb_statusR_reason2.Text = "BY REQUEST";
                                        break;
                                }
                                lb_statusR_status2.Text = (((mm.messageData[0] >> 4) & 1) == 1) ? "STATUS OK" : "STATUS BAD";
                                lb_statusR_plis2.Text = (mm.messageData[2] & 1) == 1 && ((mm.messageData[2] >> 1) & 1) == 1 ? "PLIS OK" : "PLIS FAIL";
                                lb_statusR_file2.Text = ((mm.messageData[2] >> 1) & 1) == 1 ? "FILE OK" : "FILE BAD";
                                lb_statusR_t12.Text = ((SByte)mm.messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                                lb_statusR_t22.Text = ((SByte)mm.messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                                lb_statusR_t32.Text = ((SByte)mm.messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");

                                lb_ecR2_file.Text = ((mm.messageData[2] >> 2) & 1) == 1 ? "FILE OK" : "FILE FAIL";
                                lb_ecR2_plis1.Text = (mm.messageData[2] & 1) == 1 ? "PLIS OK" : "PLIS FAIL";
                                lb_ecR2_plis2.Text = ((mm.messageData[2] >> 1) & 1) == 1 ? "PLIS OK" : "PLIS FAIL";
                                lb_ecR2_ram.Text = ((mm.messageData[2] >> 3) & 1) == 1 ? "RAM OK" : "RAM FAIL";
                                lb_ecR2_ram1.Text = ((mm.messageData[2] >> 4) & 1) == 1 ? "RAM OK" : "RAM FAIL";
                                lb_ecR2_ram2.Text = ((mm.messageData[2] >> 5) & 1) == 1 ? "RAM OK" : "RAM FAIL";

                                if (mm.messageData[6] != 0)
                                    lb_stR2_cmos1.Text = mm.messageData[6].ToString();
                                else
                                    lb_stR2_cmos1.Text = "";
                                if (mm.messageData[7] != 0)
                                    lb_stR2_cmos2.Text = mm.messageData[7].ToString();
                                else
                                    lb_stR2_cmos2.Text = "";
                            }

                            #endregion
                        }
                        if (rb2_piv10.Checked)
                        {
                            #region ПИВ 1.0
                            if (mm.deviceID == Const.OLO_Left)
                            {
                            #region OLO_Left
                                if (mm.messageData[0] >> 5 == 1) // Рабочий режим
                                {
                                    mss = "T1=" + ((SByte)mm.messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                                        "T2=" + ((SByte)mm.messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                                        "T3=" + ((SByte)mm.messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                                    switch (mm.messageData[0] & 0x0F) // причина выдачи статуса
                                    {
                                        case 0:
                                            lb_statusL_reason2.Text = "BY REQUEST";
                                            break;
                                        case 1:
                                            lb_statusL_reason2.Text = "BY TIMER";
                                            break;
                                        case 2:
                                            lb_statusL_reason2.Text = "BY STATE";
                                            break;
                                        default:
                                            lb_statusL_reason2.Text = "BY REQUEST";
                                            break;
                                    }
                                    switch ((mm.messageData[0] >> 5) & 0x03) // режим
                                    {
                                        case 1:
                                            lb_statusL_mode2.Text = "OPERATIONAL";
                                            cb_module2.SelectedIndex = 1;
                                            break;
                                        case 2:
                                            lb_statusL_mode2.Text = "PROGRAMMING";
                                            cb_module2.SelectedIndex = 2;
                                            break;
                                        default:
                                            lb_statusL_mode2.Text = "OPERATIONAL";
                                            break;
                                    }
                                    lb_statusL_status2.Text = (((mm.messageData[0] >> 4) & 1) == 1) ? "STATUS OK" : "STATUS FAIL";
                                    lb_statusL_plis2.Text = (mm.messageData[2] & 0x01) == 1 ? "PLIS OK" : "PLIS FAIL";
                                    lb_statusL_file2.Text = ((mm.messageData[2] >> 1) & 0x01) == 1 ? "FILE OK" : "FILE FAIL";
                                    lb_statusL_t12.Text = ((SByte)mm.messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                                    lb_statusL_t22.Text = ((SByte)mm.messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                                    lb_statusL_t32.Text = ((SByte)mm.messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");

                                    if (mm.messageData[6] != 0)
                                        lb_stL2_cmos1.Text = mm.messageData[6].ToString();
                                    else
                                        lb_stL2_cmos1.Text = "";
                                    if (mm.messageData[7] != 0)
                                        lb_stL2_cmos2.Text = mm.messageData[7].ToString();
                                    else
                                        lb_stL2_cmos2.Text = "";
                                }
                                else // Режим программирования
                                {
                                    lb_statusL_mode2.Text = "PROGRAMMING";
                                    lb_statusL_reason2.Text = "BY REQUEST";
                                    cb_module2.SelectedIndex = 2;
                                    lb_statusL_status2.Text = (((mm.messageData[0] >> 4) & 1) == 1) ? "STATUS OK" : "STATUS FAIL";
                                    lb_statusL_plis2.Text = "";
                                    lb_statusL_file2.Text = "";
                                    lb_statusL_t12.Text = "";
                                    lb_statusL_t22.Text = "";
                                    lb_statusL_t32.Text = "";
                                }
                            #endregion
                            }
                            else
                            {
                            #region OLO_Right
                                if (mm.messageData[0] >> 5 == 1) // Рабочий режим
                                {
                                    mss = "T1=" + ((SByte)mm.messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                                        "T2=" + ((SByte)mm.messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                                        "T3=" + ((SByte)mm.messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                                    switch (mm.messageData[0] & 0x0F) // причина выдачи статуса
                                    {
                                        case 0:
                                            lb_statusR_reason2.Text = "BY REQUEST";
                                            break;
                                        case 1:
                                            lb_statusR_reason2.Text = "BY TIMER";
                                            break;
                                        case 2:
                                            lb_statusR_reason2.Text = "BY STATE";
                                            break;
                                        default:
                                            lb_statusR_reason2.Text = "BY REQUEST";
                                            break;
                                    }
                                    switch ((mm.messageData[0] >> 5) & 0x03) // режим
                                    {
                                        case 1:
                                            lb_statusR_mode2.Text = "OPERATIONAL";
                                            cb_module2.SelectedIndex = 1;
                                            break;
                                        case 2:
                                            lb_statusR_mode2.Text = "PROGRAMMING";
                                            cb_module2.SelectedIndex = 2;
                                            break;
                                        default:
                                            lb_statusR_mode2.Text = "OPERATIONAL";
                                            break;
                                    }
                                    lb_statusR_status2.Text = (((mm.messageData[0] >> 4) & 1) == 1) ? "STATUS OK" : "STATUS FAIL";
                                    lb_statusR_plis2.Text = (mm.messageData[2] & 0x01) == 1 ? "PLIS OK" : "PLIS FAIL";
                                    lb_statusR_file2.Text = ((mm.messageData[2] >> 1) & 0x01) == 1 ? "FILE OK" : "FILE FAIL";
                                    lb_statusR_t12.Text = ((SByte)mm.messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                                    lb_statusR_t22.Text = ((SByte)mm.messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                                    lb_statusR_t32.Text = ((SByte)mm.messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");

                                    if (mm.messageData[6] != 0)
                                        lb_stR2_cmos1.Text = mm.messageData[6].ToString();
                                    else
                                        lb_stR2_cmos1.Text = "";
                                    if (mm.messageData[7] != 0)
                                        lb_stR2_cmos2.Text = mm.messageData[7].ToString();
                                    else
                                        lb_stR2_cmos2.Text = "";
                                }
                                else // Режим программирования
                                {
                                    lb_statusR_mode2.Text = "PROGRAMMING";
                                    lb_statusR_reason2.Text = "BY REQUEST";
                                    cb_module2.SelectedIndex = 2;
                                    lb_statusR_status2.Text = (((mm.messageData[0] >> 4) & 1) == 1) ? "STATUS OK" : "STATUS FAIL";
                                    lb_statusR_plis2.Text = "";
                                    lb_statusR_file2.Text = "";
                                    lb_statusR_t12.Text = "";
                                    lb_statusR_t22.Text = "";
                                    lb_statusR_t32.Text = "";
                                }
                            }
                            #endregion
                            #endregion
                        }
                        break;
                    #endregion
                    #region mID_STATREQ
                    case msg_t.mID_STATREQ:
                        if (mm.deviceID != 0)
                        {
                            mss = "Запрос статуса" + ((mm.deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                        }
                        else
                        {
                            mss = "Запрос статуса всех ОЛО";
                        }
                        break;
                    #endregion
                    #region mID_MODULE
                    case msg_t.mID_MODULE:
                        if (mm.deviceID != 0)
                        {
                            mss = "Режим модуля";
                            switch (mm.messageData[0])
                            {
                                case 0:
                                    mss += " OPERATIONAL";
                                    break;
                                case 1:
                                    mss += " SELFTEST";
                                    break;
                                case 2:
                                    mss += " EMBEDCONTROL";
                                    break;
                                case 3:
                                    mss += " PROGRAMMING";
                                    break;
                                default:
                                    mss += " OPERATIONAL";
                                    break;
                            }
                        }
                        else
                        {
                            mss = "Режим модуля ";
                        }
                        break;
                    #endregion
                    #region mID_RESET
                    case msg_t.mID_RESET:
                        if (mm.deviceID != 0)
                        {
                            mss = "Системный сброс" + ((mm.deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                        }
                        else
                        {
                            mss = "Системный сброс всех ОЛО";
                        }
                        break;
                    #endregion
                }

                #region Вывод инфы в грид
                String rawdata = "";
                for (int j = 0; j < mm.messageLen; j++)
                    rawdata += mm.messageData[j].ToString("X2") + " ";
                String stimestamp = "";

                #region Фильтры
                timestamp = 0;
                if (rb2_filter_all.Checked)
                {
                    String temp_str = "";
                    temp_str = strelka_s + "\t" + rawdata + " \t" + mss;
                    if (mm.messageID.ToString("X2") == "2D")
                    {
                        timestamp = BitConverter.ToUInt32(mm.messageData, 0);
                        stimestamp = timestamp.ToString();
                        temp_str += "\t" + stimestamp;
                        if (BitConverter.ToInt16(mm.messageData, 4) == 0x7FFF)
                        {
                            if (timestampold != 0)
                            {
                                UInt32 period = timestamp - timestampold;
                                if (period > 0 && period < 100000)
                                {
                                    temp_str += "\t" + (period / 100).ToString() + "мс";
                                    temp_str += ", " + Math.Round(100000F / period).ToString() + "Гц";
                                }
                            }
                            timestampold = timestamp;
                        }
                    }
                    temp_str += "\r\n";
                    if (mm.messageID.ToString("X2") == "2D")
                    {
                        if (BitConverter.ToInt16(mm.messageData, 4) != 0x7FFF)
                        {
                            rtb2_datagrid.AppendText(temp_str, Color.Orange, Color.Black);
                        }
                        else
                        {
                            rtb2_datagrid.AppendText(temp_str, Color.Red);
                        }
                    }
                    else
                    {
                        if (mm.messageID == msg_t.mID_STATUS && (((mm.messageData[0] >> 4) & 0x01) == 0))
                        {
                            rtb2_datagrid.AppendText(temp_str, Color.Red);
                        }
                        else
                        {
                            rtb2_datagrid.AppendText(temp_str);
                        }
                    }
                    rtb2_datagrid.ScrollToCaret();
                }
                if (rb2_filter_data.Checked)
                {
                    String temp_str = "";
                    if (mm.messageID.ToString("X2") == "2D" && BitConverter.ToInt16(mm.messageData, 4) != 0x7FFF)
                    {
                        temp_str = strelka_s + "\t" + rawdata + " \t" + mss;
                        timestamp = 0;
                        timestamp = BitConverter.ToUInt32(mm.messageData, 0);
                        stimestamp = timestamp.ToString();
                        temp_str += "\t" + stimestamp;
                        temp_str += "\r\n";
                    }
                    rtb2_datagrid.AppendText(temp_str, Color.Orange, Color.Black);
                    rtb2_datagrid.ScrollToCaret();
                }
                if (rb2_filter_7fff.Checked)
                {
                    String temp_str = "";
                    if (mm.messageID.ToString("X2") == "2D" && BitConverter.ToInt16(mm.messageData, 4) == 0x7FFF)
                    {
                        temp_str = strelka_s + "\t" + rawdata + " \t" + mss;
                        timestamp = BitConverter.ToUInt32(mm.messageData, 0);
                        stimestamp = timestamp.ToString();
                        temp_str += "\t" + stimestamp;
                        if (timestampold != 0)
                        {
                            UInt32 period = timestamp - timestampold;
                            if (period > 0 && period < 100000)
                            {
                                temp_str += "\t" + (period / 100).ToString() + "мс";
                                temp_str += ", " + (100000 / period).ToString() + "Гц";
                            }
                        }
                        timestampold = timestamp;
                        temp_str += "\r\n";
                    }
                    rtb2_datagrid.AppendText(temp_str, Color.Red);
                    rtb2_datagrid.ScrollToCaret();
                }
                #endregion
                #region Запись в лог
                if (chb3_savelog.Checked && logwr != null)
                {
                    logwr.Write(DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff") + ";");
                    logwr.Write(strelka_s + ";");
                    logwr.Write(rawdata + ";");
                    logwr.Write(mss + ";");
                    if (mm.messageID.ToString("X2") == "2D")
                        logwr.WriteLine(stimestamp + ";");
                    else
                        logwr.WriteLine(";");
                }
                #endregion
                #endregion
                //messages.
                messages.Clear();
            }
            Timer_GetData.Enabled = true;
        }
        private void timer_Reset_Shots_Tick(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
            {
                timer_Reset_Shots.Enabled = false;
                timer_Reset_Shots.Interval = timer_Reset_Shots_Interval;
                list_shots.Clear();
                //label3.Text = list_shots.Count.ToString();
                panel1.Refresh();
            }
        }
        static DateTime ConvertFromUnixTimestamp(UInt64 timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
        public static UInt64 ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return (UInt64)Math.Floor(diff.TotalSeconds);
        }
        Byte[] TimestampToArray(UInt64 stamp)
        {
            Byte[] tmp = new Byte[8];
            tmp = BitConverter.GetBytes(stamp);
            return tmp;
        }
        private void Timer_UpdateTime_Tick(object sender, EventArgs e)
        {
            label17.Text = DateTime.Now.ToString("");
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox3.SelectedIndex == 0)
            //    OLO_Select = Const.OLO_Left;
            //else
            //    OLO_Select = Const.OLO_Right;
            switch (cb2_select_olo.SelectedIndex)
            {
                case 0:
                    OLO_Select = Const.OLO_Left;
                    break;
                case 1:
                    OLO_Select = Const.OLO_Right;
                    break;
                default:
                    OLO_Select = Const.OLO_Right;
                    break;
            }
        }
        private void bt_Request2_Click(object sender, EventArgs e)
        {
            int to = 0;
            msg_t mm = new msg_t();
            mm.messageID = msg_t.mID_STATREQ;
            Byte[] tmp = new Byte[4];

            switch (cb2_period_ans.SelectedIndex)
            {
                case 0:
                    mm.messageData[4] = 2;
                    break;
                case 1:
                    mm.messageData[4] = 3;
                    to = 0x3F000000;
                    break;
                case 2:
                    mm.messageData[4] = 3;
                    to = 0x3F7FFFFF;
                    break;
                case 3:
                    mm.messageData[4] = 3;
                    to = 0x40000000;
                    break;
            }
            String sss = "";
            switch (cb2_select_olo.SelectedIndex)
            {
                case 0:
                    mm.deviceID = Const.OLO_Left;
                    sss = "Запрос статуса левого ОЛО";
                    break;
                case 1:
                    mm.deviceID = Const.OLO_Right;
                    sss = "Запрос статуса правого ОЛО";
                    break;
            }
            tmp = BitConverter.GetBytes(to);
            Array.Copy(tmp, mm.messageData, 4);
            mm.messageLen = 5;
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref msg, 100))
                return;
            text2rtb(rtb2_datagrid, msgdata2string(msg) + sss, Color.Aquamarine, Color.Black);
//            messages.Add(mm);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            const UInt16 DSPOT = 4;
            if (list_shots.Count > 0)
            {
                foreach (var it in list_shots)
                {
                    int x = 0, y = 0;
                    Double z = 0;
                    Double ugol = (Double)it.ugol / 60, azimut = (Double)it.azimut / 60;
                    z = (int)Math.Abs(ugol);

                    if (it.bort == 1)
                    {
                        x = (int)(z * Math.Cos((Double)(azimut * Math.PI / 180)));
                        y = (int)(z * Math.Sin((Double)(azimut * Math.PI / 180)));
                    }
                    else
                    {
                        x = (int)(z * Math.Cos((Double)((azimut + 180) * Math.PI / 180)));
                        y = (int)(z * Math.Sin((Double)((azimut + 180) * Math.PI / 180)));
                    }
                    if (ugol < 0)
                        gr.FillEllipse(new SolidBrush(Color.Red), x + 99 - DSPOT, y + 99 - DSPOT, DSPOT * 2, DSPOT * 2);
                    else
                        gr.FillEllipse(new SolidBrush(Color.Green), x + 99 - DSPOT, y + 99 - DSPOT, DSPOT * 2, DSPOT * 2);
                }
                if(cb_clear_shot.Checked)
                    list_shots.Clear();
            }
            gr.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
        }
        private void chb_dgview2_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_dgview2.Checked)
            {
                chb_dgview2.Text = "Скролл включен";
                scroll = true;
                chb_dgview2.BackColor = Color.SpringGreen;
            }
            else
            {
                chb_dgview2.Text = "Скролл выключен";
                scroll = false;
                chb_dgview2.BackColor = Color.OrangeRed;
            }
        }
        #region Старые кнопки
        private void btn_REQSN_Click(object sender, EventArgs e) // Запрос серийного номера
        {
            msg_t mm = new msg_t();
            switch (cb2_select_olo.SelectedIndex)
            {
                case 0:
                    mm.deviceID = Const.OLO_Left;
                    break;
                case 1:
                    mm.deviceID = Const.OLO_Right;
                    break;
            }
            mm.messageID = msg_t.mID_GET_SN;
            mm.messageLen = 1;
            mm.messageData[0] = 0;
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref msg, 100))
                return;
            messages.Add(mm);
        }
        private void btn_SAVESN_Click(object sender, EventArgs e) // Сохранение серийного номера
        {
            msg_t mm = new msg_t();
            switch (cb2_select_olo.SelectedIndex)
            {
                case 0:
                    mm.deviceID = Const.OLO_Left;
                    break;
                case 1:
                    mm.deviceID = Const.OLO_Right;
                    break;
                case 2:
                    MessageBox.Show("Ошибка! Выберите OLO_Left или OLO_Right");
                    return;
            }
            if (tb_SN.TextLength != 8)
            {
                MessageBox.Show("Ошибка! Длина серийного номера должна быть 8 цифр.");
                return;
            }

            char[] char_sn = new char[tb_SN.TextLength];
            String[] str_sn = new String[tb_SN.TextLength];

            Byte[] byte_sn = new Byte[tb_SN.TextLength];
            char_sn = tb_SN.Text.ToCharArray();
            for (int i = 0; i < char_sn.Length; i++)
            {
                Byte a;
                String b = "";
                b += char_sn[i];
                if (!Byte.TryParse(b, out a))
                {
                    MessageBox.Show("Ошибка! Длина серийного номера должна быть 8 цифр.");
                    return;
                }
                byte_sn[i] = a;
            }

            mm.messageID = msg_t.mID_SET_SN;
            mm.messageLen = 8;
            mm.messageData = byte_sn;
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref msg, 100))
                return;
            messages.Add(mm);
        }
        private void REQ_VER_Click(object sender, EventArgs e)
        {
            msg_t mm = new msg_t();
            switch (cb2_select_olo.SelectedIndex)
        	{
                case 0:
                    mm.deviceID = Const.OLO_Left;
                    break;
                case 1:
                    mm.deviceID = Const.OLO_Right;
                    break;
	        }
            mm.messageID = msg_t.mID_REQVER;
//            mm.messageID = msg_t.mID_STATREQ;
            mm.messageLen = 1;
            mm.messageData[0] = 0;
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref msg, 100))
                return;
            messages.Add(mm);
            //if (uniCAN == null || !uniCAN.Recv(ref msg, 100))
            //{
            //    Trace.WriteLine("Error read packet");
            //    return;
            //}
            //string ss = Convert.ToChar(msg.data[0]) + "" + Convert.ToChar(msg.data[1]);
            //ss += " " + (Convert.ToChar(msg.data[2]) == 'L' ? "Левый борт": "Правый борт");
            //ss += " " + (msg.data[6] < 10 ? "0" + msg.data[6].ToString() : msg.data[6].ToString());
            //ss += "." + (msg.data[5] < 10 ? "0" + msg.data[5].ToString() : msg.data[5].ToString());
            //ss += "." + BitConverter.ToUInt16(msg.data, 3).ToString();
            //ss += " v." + (msg.data[7] < 10 ? "0" + msg.data[7].ToString() : msg.data[7].ToString());
            //MessageBox.Show(ss);
        }
        private void bt_mod2_Click(object sender, EventArgs e)
        {
//            int to = 0;
            msg_t mm = new msg_t();
            mm.messageID = msg_t.mID_MODULE;
            mm.messageLen = 1;
            Byte[] tmp = new Byte[4];

            switch (cb_module2.SelectedIndex)
            {
                case 0: // рабочий режим
                    mm.messageData[0] = 0;
                    break;
                case 1: // режим самотестирования
                    mm.messageData[0] = 1;
                    break;
                case 2: // встроенный контроль
                    mm.messageData[0] = 2;
                    if (cb2_select_olo.SelectedIndex == 0)
                    {
                        lb_ecR2_file.Text = "";
                        lb_ecR2_plis1.Text = "";
                        lb_ecR2_plis2.Text = "";
                        lb_ecR2_ram.Text = "";
                        lb_ecR2_ram1.Text = "";
                        lb_ecR2_ram2.Text = "";
                    }
                    if (cb2_select_olo.SelectedIndex == 1)
                    {
                        lb_ecL2_file.Text = "";
                        lb_ecL2_plis1.Text = "";
                        lb_ecL2_plis2.Text = "";
                        lb_ecL2_ram.Text = "";
                        lb_ecL2_ram1.Text = "";
                        lb_ecL2_ram2.Text = "";
                    }
                    if (cb2_select_olo.SelectedIndex == 2)
                    {
                        lb_ecR2_file.Text = "";
                        lb_ecR2_plis1.Text = "";
                        lb_ecR2_plis2.Text = "";
                        lb_ecR2_ram.Text = "";
                        lb_ecR2_ram1.Text = "";
                        lb_ecR2_ram2.Text = "";
                        lb_ecL2_file.Text = "";
                        lb_ecL2_plis1.Text = "";
                        lb_ecL2_plis2.Text = "";
                        lb_ecL2_ram.Text = "";
                        lb_ecL2_ram1.Text = "";
                        lb_ecL2_ram2.Text = "";
                    }
                    gbox_ecL2.Refresh();
                    gbox_ecR2.Refresh();
                    break;
                case 3: // режим программирования
                    mm.messageID = msg_t.mID_PROG;
                    mm.messageData[0] = 0x5A;
                    mm.messageData[1] = 0x5A;
                    mm.messageLen = 2;
                    break;
            }
            switch (cb2_select_olo.SelectedIndex)
            {
                case 0:
                    mm.deviceID = Const.OLO_Left;
                    break;
                case 1:
                    mm.deviceID = Const.OLO_Right;
                    break;
            }
//            tmp = BitConverter.GetBytes(to);
//            Array.Copy(tmp, mm.messageData, 4);
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref msg, 100))
                return;
            messages.Add(mm);
        }
        
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            scroll = true;
            chb_dgview2.Text = "Скролл включен";
            chb_dgview2.BackColor = Color.SpringGreen;
            messages.Clear();
            list_shots.Clear();
            if (rtb2_datagrid.Created)
                rtb2_datagrid.ResetText();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
                timer_Reset_Shots_Interval = (int)numericUpDown1.Value * 1000;
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            msg_t mm = new msg_t();

            if (cb2_select_olo.SelectedIndex == 0)
                mm.deviceID = Const.OLO_Left;
            else
                mm.deviceID = Const.OLO_Right;
            mm.messageID = msg_t.mID_RESET;
            mm.messageLen = 1;
            mm.messageData[0] = 0;
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref msg, 100))
                return;
            text2rtb(rtb2_datagrid, msgdata2string(msg) + "Перезагрузка " + (mm.deviceID == Const.OLO_Left ? lolo : polo), Color.Aquamarine, Color.Black);
//            messages.Add(mm);
        }
        private void bt_SyncTime_Click(object sender, EventArgs e) // Переход в РУП
        {
            msg_t mm = new msg_t();

            if (cb2_select_olo.SelectedIndex == 0)
                mm.deviceID = Const.OLO_Left;
            else
                mm.deviceID = Const.OLO_Right;
            mm.messageID = msg_t.mID_PROG;
            mm.messageLen = 2;
            Array.Clear(mm.messageData, 0, 8);
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg.data[0] = 0x5A;
            msg.data[1] = 0x5A;
            msg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref msg, 100))
                return;
            text2rtb(rtb2_datagrid, msgdata2string(msg) + "Режим удаленного программирования " + (mm.deviceID == Const.OLO_Left ? lolo : polo), Color.Aquamarine, Color.Black);
//            messages.Add(mm);
        }
        private void chb3_savelog_CheckedChanged(object sender, EventArgs e)
        {
            if (chb3_savelog.Checked)
            {
                savelog.DefaultExt = "csv";
                savelog.Filter = "Файлы логов (*.csv)|*.csv";
                savelog.FileName = "log_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
                if (savelog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    logwr = new StreamWriter(savelog.FileName, false, Encoding.Default);
            }
            else
            {
                chb3_savelog.Checked = false;
                logwr.Close();
            }
        }
        #endregion

        #region OLO_Emu
        #region CAN
        private void bt_OpenCAN3_Click(object sender, EventArgs e)
        {
/*
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
*/
            switch (cb_CAN3.SelectedItem.ToString())
            {
                case "No CAN":
                    return;
                case "USB Marathon":
                    marCAN = new MCANConverter();
                    uniCAN = marCAN as MCANConverter;
                    break;
                case "PCI Advantech":
                    advCAN = new ACANConverter();
                    uniCAN = advCAN as ACANConverter;
                    break;
                case "PCI Elcus":
                    elcCAN = new ECANConverter();
                    uniCAN = elcCAN as ECANConverter;
                    break;
                case "Fake CAN driver":
                    fakeCAN = new FCANConverter();
                    uniCAN = fakeCAN as FCANConverter;
                    break;
                default:
                    return;
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
        private void shoot(_u8 id)
        {
            msg_t mm = new msg_t();
            mm.deviceID = id;
            mm.messageID = msg_t.mID_DATA;

            Random r = new Random();
            mm.messageLen = 8;
            int az, um;
            if (!chb3_shoot_ena.Checked)
            {
                az = r.Next(-90 * 60, 90 * 60);
                um = r.Next(-90 * 60, 90 * 60);
            }
            else
            {
                if (id == Const.OLO_Left)
                {
                    az = trackBar3_az_l.Value * 60;
                    um = trackBar3_um_l.Value * 60;
                }
                else
                {
                    az = trackBar3_az_r.Value * 60;
                    um = trackBar3_um_r.Value * 60;
                }
            }

            UInt64 dl = (ConvertToUnixTimestamp(DateTime.Now) * 1000 + (UInt32)DateTime.Now.Millisecond) * 100;
            mm.messageData[0] = (Byte)dl;
            mm.messageData[1] = (Byte)(dl >> 8);
            mm.messageData[2] = (Byte)(dl >> 16);
            mm.messageData[3] = (Byte)(dl >> 24);
            mm.messageData[4] = 0xFF;
            mm.messageData[5] = 0x7F;
            mm.messageData[6] = 0xFF;
            mm.messageData[7] = 0x7F;

            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref mmsg, 200))
                return;

            dl = (ConvertToUnixTimestamp(DateTime.Now) * 1000 + (UInt32)DateTime.Now.Millisecond) * 100;
            mm.messageData[0] = (Byte)dl;
            mm.messageData[1] = (Byte)(dl >> 8);
            mm.messageData[2] = (Byte)(dl >> 16);
            mm.messageData[3] = (Byte)(dl >> 24);
            mm.messageData[4] = (Byte)az;
            mm.messageData[5] = (Byte)(az >> 8);
            mm.messageData[6] = (Byte)um;
            mm.messageData[7] = (Byte)(um >> 8);
            mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref mmsg, 200))
                return;
            String mss;
            mss = "Азимут = " + (az / 60).ToString("0'°'") + (az % 60).ToString() + "' ";
            mss += "Угол = " + (um / 60).ToString("0'°'") + (um % 60).ToString() + "'";
            Shots sh = new Shots();
            sh.bort = (mm.deviceID == Const.OLO_Left) ? (Byte)0 : (Byte)1;
            sh.azimut = (Int16)az;
            sh.ugol = (Int16)um;
            list_shots.Add(sh);
            text2rtb(rtb3_datagrid, msgdata2string(mmsg) +"\t" + "Выстрел " + (mm.deviceID == Const.OLO_Left ? lolo : polo) + "\t" + mss, Color.Aquamarine, Color.Black);
            //            messages.Add(mm);
            panel3.Refresh();
        }
        private void shoot_l_Click(object sender, EventArgs e)
        {
            shoot(Const.OLO_Left);
        }
        private void shoot_r_Click(object sender, EventArgs e)
        {
            shoot(Const.OLO_Right);
        }
        #endregion
        #region Мусорные кнопки
        void badstatus(Byte id) // Ошибочное сообщение статуса
        {
            msg_t mm = new msg_t();
            mm.deviceID = id;
            mm.messageID = msg_t.mID_STATUS;
            mm.messageLen = 8;
            Random r = new Random();
            for (int i = 0; i < 8; i++)
            {
                mm.messageData[i] = (Byte)r.Next(-127, 127);
            }
            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref mmsg, 200))
                return;
            String mss;
            mss = "Ошибочное сообщение статуса ";
            text2rtb(rtb3_datagrid, mss + (mm.deviceID == Const.OLO_Left ? lolo : polo) + "\t" + msgdata2string(mmsg), Color.RoyalBlue, Color.White);
        }
        void baddata(Byte id) // Ошибочные данные
        {
            msg_t mm = new msg_t();
            mm.deviceID = id;
            mm.messageID = msg_t.mID_DATA;
            mm.messageLen = 8;
            Random r = new Random();
            for (int i = 0; i < 8; i++)
            {
                mm.messageData[i] = (Byte)r.Next(-127, 127);
            }
            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref mmsg, 200))
                return;
            String mss;
            mss = "Ошибочные данные ";
            text2rtb(rtb3_datagrid, mss + (mm.deviceID == Const.OLO_Left ? lolo : polo) + "\t" + msgdata2string(mmsg), Color.RoyalBlue, Color.White);
        }
        void trash() // полный трэш
        {
            msg_t mm = new msg_t();
            Random r = new Random();
            mm.deviceID = (Byte)r.Next(-127, 127);
            mm.messageID = (Byte)r.Next(-127, 127);
            mm.messageLen = (Byte)r.Next(0, 8);
            for (int i = 0; i < mm.messageLen; i++)
            {
                mm.messageData[i] = (Byte)r.Next(-127, 127);
            }
            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[mm.messageLen];
            mmsg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref mmsg, 200))
                return;
            String mss;
            mss = "Полный трэш";
            text2rtb(rtb3_datagrid, mss + "\t" + msgdata2string(mmsg), Color.RoyalBlue, Color.White);
        }
        private void bt3_badstatus_l_Click(object sender, EventArgs e)
        {
            badstatus(Const.OLO_Left);
        }
        private void bt3_badstatus_r_Click(object sender, EventArgs e)
        {
            badstatus(Const.OLO_Right);
        }
        private void bt3_baddata_l_Click(object sender, EventArgs e)
        {
            baddata(Const.OLO_Left);
        }
        private void bt3_baddata_r_Click(object sender, EventArgs e)
        {
            baddata(Const.OLO_Right);
        }
        private void bt3_trash_l_Click(object sender, EventArgs e)
        {
            trash();
        }
        private void bt3_trash_r_Click(object sender, EventArgs e)
        {
            trash();
        }
        #endregion
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
            try
            {
                mmm.messageData[3] = Byte.Parse(tb3_tarm_l.Text);
            }
            catch (FormatException)
            {
                mmm.messageData[3] = 0;
            }
            try
            {
                mmm.messageData[4] = Byte.Parse(tb3_t1_l.Text);
            }
            catch (FormatException)
            {
                mmm.messageData[4] = 0;
            }
            try
            {
                mmm.messageData[5] = Byte.Parse(tb3_t2_l.Text);
            }
            catch (FormatException)
            {
                mmm.messageData[5] = 0;
            }
            mmm.messageLen = 8;
            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mmm.ToCAN(mmm);
            if (!uniCAN.Send(ref mmsg, 200))
                return;
            String mss = "T1=" + ((SByte)mmm.messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                "T2=" + ((SByte)mmm.messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                "T3=" + ((SByte)mmm.messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
            text2rtb(rtb3_datagrid, "Статус " + lolo + "\t" + msgdata2string(mmsg) + "\t" + mss, Color.Aquamarine, Color.Black);
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
            try
            {
                mmm.messageData[3] = Byte.Parse(tb3_tarm_r.Text);
            }
            catch (FormatException)
            {
                mmm.messageData[3] = 0;
            }
            try
            {
                mmm.messageData[4] = Byte.Parse(tb3_t1_r.Text);
            }
            catch (FormatException)
            {
                mmm.messageData[4] = 0;
            }
            try
            {
                mmm.messageData[5] = Byte.Parse(tb3_t2_r.Text);
            }
            catch (FormatException)
            {
                mmm.messageData[5] = 0;
            }
            mmm.messageLen = 8;
            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mmm.ToCAN(mmm);
            if (!uniCAN.Send(ref mmsg, 200))
                return;
            String mss = "T1=" + ((SByte)mmm.messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                "T2=" + ((SByte)mmm.messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                "T3=" + ((SByte)mmm.messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
            text2rtb(rtb3_datagrid, "Статус " + polo + "\t" + msgdata2string(mmsg) + "\t" + mss, Color.Aquamarine, Color.Black);
        }
        
        #endregion
        private void Timer_GetData3_Tick(object sender, EventArgs e)
        {
            Timer_GetData3.Enabled = false;
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
//                    Application.DoEvents();
                    mm = mm.FromCAN(msg);
                    if (!cb_olo_l_ena.Checked && mm.deviceID == Const.OLO_Left)
                    {
                        continue;
                    }
                    if (!cb_olo_r_ena.Checked && mm.deviceID == Const.OLO_Right)
                    {
                        continue;
                    }
                    String strelka_s = "";

                    if (mm.deviceID == Const.OLO_Left)
                        strelka_s = "ОЛО левый";
                    else if(mm.deviceID == Const.OLO_Right)
                        strelka_s = "ОЛО правый";
                    else
                        strelka_s = "Всем ОЛО";
                    String mss = "";
                    switch (mm.messageID)
                    {
                        case msg_t.mID_RESET:
    #region mID_RESET
                            if (mm.deviceID != 0)
                            {
                                mss = "Запрос системного сброса" + ((mm.deviceID == Const.OLO_Left) ? lolo : polo);
                                text2rtb(rtb3_datagrid, mss);
                                if (mm.deviceID == Const.OLO_Left)
                                {
                                    timer_testOLO_L3.Enabled = false;
                                    flag_reset_left = true;
                                    timer3_reset_l.Enabled = false;
                                    timer3_reset_l.Enabled = true;
                                }
                                else
                                {
                                    timer_testOLO_R3.Enabled = false;
                                    flag_reset_right = true;
                                    timer3_reset_r.Enabled = false;
                                    timer3_reset_r.Enabled = true;
                                }
                                mss = "Перезагрузка " + ((mm.deviceID == Const.OLO_Left) ? lolo : polo) + "...";
                                text2rtb(rtb3_datagrid, mss, Color.Aquamarine, Color.Black);
                            }
                            break;
    #endregion
                        case msg_t.mID_MODULE:
    #region mID_MODULE
                            #region сброс сообщений для ОЛО в режиме программирования
                            if (mm.deviceID == Const.OLO_Left && flag_reset_left)
                            {
                                break;
                            }
                            if (mm.deviceID == Const.OLO_Right && flag_reset_right)
                            {
                                break;
                            }
                            #endregion
                            if (mm.deviceID != Const.OLO_All)
                            {
                                mss = "Режим модуля" + ((mm.deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                            }
                            else
	                        {
                                mss = "Режим модуля ОЛО";
	                        }
                            break;
    #endregion
                        case msg_t.mID_SOER:
    #region mID_SOER
                            #region сброс сообщений для ОЛО в режиме программирования
                            if (mm.deviceID == Const.OLO_Left && flag_reset_left)
                            {
                                break;
                            }
                            if (mm.deviceID == Const.OLO_Right && flag_reset_right)
                            {
                                break;
                            }
                            #endregion
                            if (mm.deviceID != Const.OLO_All)
                            {
                                mss = "Режим СОЭР" + ((mm.deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                                if (mm.deviceID != Const.OLO_Left)
                                {
                                    soer_l = mm.messageData[0];
                                }
                                else
                                {
                                    soer_r = mm.messageData[0];
                                }
                            }
                            else
	                        {
                                mss = "Режим СОЭР ОЛО";
	                        }
                            break;
    #endregion
                        case msg_t.mID_PROG:
    #region mID_PROG
                            #region сброс сообщений для ОЛО в режиме программирования
                            if(mm.deviceID == Const.OLO_Left && flag_reset_left)
                            {
                                break;
                            }
                            if (mm.deviceID == Const.OLO_Right && flag_reset_right)
                            {
                                break;
                            }
                            #endregion
                            mss = "Запрос перехода в Режим удаленного перепрограммирования " + ((mm.deviceID == Const.OLO_Left) ? lolo : polo);
                            text2rtb(rtb3_datagrid, mss);
                            if (mm.deviceID == Const.OLO_Left)
                            {
                                timer_testOLO_L3.Enabled = false;
                                flag_reset_left = true;
                                timer3_reset_l.Enabled = false;
                                timer3_reset_l.Enabled = true;
                            }
                            else
                            {
                                timer_testOLO_R3.Enabled = false;
                                flag_reset_right = true;
                                timer3_reset_r.Enabled = false;
                                timer3_reset_r.Enabled = true;
                            }
                            text2rtb(rtb3_datagrid, "Статус " + ((mm.deviceID == Const.OLO_Left) ? lolo : polo) + ":\t" + "PROGRAMMING MODE", Color.Aquamarine, Color.Black);
                            break;
    #endregion
                        case msg_t.mID_STATREQ:
    #region mID_STATREQ
                            #region сброс сообщений для ОЛО в режиме программирования
                            if(mm.deviceID == Const.OLO_Left && flag_reset_left)
                            {
                                mss = "Запрос статуса " + ((mm.deviceID == Const.OLO_Left) ? lolo : polo);
                                text2rtb(rtb3_datagrid, mss);
                                mmm.messageID = msg_t.mID_STATUS;
                                mmm.deviceID = Const.OLO_Left;
                                mmm.messageData[0] = 0x13;
                                mmm.messageData[1] = 0x23;
                                mmm.messageData[2] = 0xF2;
                                mmm.messageData[3] = 0x00;
                                mmm.messageData[4] = 0x11;
                                mmm.messageData[5] = 0x80;
                                mmm.messageData[6] = 0x00;
                                mmm.messageData[7] = 0x00;
                                mmm.messageLen = 8;
                                canmsg_t mmsg = new canmsg_t();
                                mmsg.data = new Byte[8];
                                mmsg = mmm.ToCAN(mmm);
                                if (!uniCAN.Send(ref mmsg, 200))
                                    return;
//                                messages.Add(mmm);
                                text2rtb(rtb3_datagrid, "Статус " + lolo + ":\t" + "PROGRAMMING MODE", Color.Aquamarine, Color.Black);
                                break;
                            }
                            if (mm.deviceID == Const.OLO_Right && flag_reset_right)
                            {
                                mss = "Запрос статуса " + ((mm.deviceID == Const.OLO_Left) ? lolo : polo);
                                text2rtb(rtb3_datagrid, mss);
                                mmm.messageID = msg_t.mID_STATUS;
                                mmm.deviceID = Const.OLO_Right;
                                mmm.messageData[0] = 0x13;
                                mmm.messageData[1] = 0x23;
                                mmm.messageData[2] = 0xF2;
                                mmm.messageData[3] = 0x00;
                                mmm.messageData[4] = 0x11;
                                mmm.messageData[5] = 0x80;
                                mmm.messageData[6] = 0x00;
                                mmm.messageData[7] = 0x00;
                                mmm.messageLen = 8;
                                canmsg_t mmsg = new canmsg_t();
                                mmsg.data = new Byte[8];
                                mmsg = mmm.ToCAN(mmm);
                                if (!uniCAN.Send(ref mmsg, 200))
                                    return;
//                                messages.Add(mmm);
                                text2rtb(rtb3_datagrid, "Статус " + polo + ":\t" + "PROGRAMMING MODE", Color.Aquamarine, Color.Black);
                                break;
                            }
                            #endregion

                            if (mm.messageData[4] == 1 || mm.messageData[4] == 3)
                            {
                                #region Включение автоматической выдачи статуса
                                mss = "Запрос включения автоматического статуса" + ((mm.deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                                text2rtb(rtb3_datagrid, mss);
                                if (mm.deviceID == Const.OLO_Left)
                                {
                                    timer_testOLO_L3.Interval = (int)period(BitConverter.ToUInt32(mm.messageData, 0));
                                    timer_testOLO_L3.Enabled = true;
                                }
                                else
                                {
                                    timer_testOLO_R3.Interval = (int)period(BitConverter.ToUInt32(mm.messageData, 0));
                                    timer_testOLO_R3.Enabled = true;
                                }
                                #endregion
                            }
                            else
                            {
                                #region Выдача статуса по запросу
                                mss = "Запрос статуса " + ((mm.deviceID == Const.OLO_Left) ? lolo : polo);
                                text2rtb(rtb3_datagrid, mss);
                                if (mm.deviceID == Const.OLO_Left)
                                {
                                    timer_testOLO_L3.Enabled = false;
                                    mmm.messageID = msg_t.mID_STATUS;
                                    mmm.deviceID = Const.OLO_Left;
                                    //отправка статуса по запросу, интегральная исправность, штатный режим
                                    mmm.messageData[0] = (Byte)(0 + (chb_L_Err_int.Checked ? 0 : 16) + 32);
                                    mmm.messageData[1] = 0; //штатный режим
                                    mmm.messageData[2] = (Byte)((chb_L_Err_plis.Checked ? 0 : 1) + (chb_L_Err_file.Checked ? 0 : 2)); //исправность компонент
                                    try
                                    {
                                        mmm.messageData[3] = (Byte)SByte.Parse(tb3_tarm_l.Text);
                                    }
                                    catch (FormatException)
                                    {
                                        mmm.messageData[3] = 0;
                                    }
                                    try
                                    {
                                        mmm.messageData[4] = (Byte)SByte.Parse(tb3_t1_l.Text);
                                    }
                                    catch (FormatException)
                                    {
                                        mmm.messageData[4] = 0;
                                    }
                                    try
                                    {
                                        mmm.messageData[5] = (Byte)SByte.Parse(tb3_t2_l.Text);
                                    }
                                    catch (FormatException)
                                    {
                                        mmm.messageData[5] = 0;
                                    }
                                    mmm.messageLen = 8;
                                    canmsg_t mmsg = new canmsg_t();
                                    mmsg.data = new Byte[8];
                                    mmsg = mmm.ToCAN(mmm);
                                    if (!uniCAN.Send(ref mmsg, 200))
                                        return;
                                    mss = "T1=" + ((SByte)mmm.messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                                        "T2=" + ((SByte)mmm.messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                                        "T3=" + ((SByte)mmm.messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                                    text2rtb(rtb3_datagrid, "Статус " + lolo + "\t" + msgdata2string(mmsg) + "\t" + mss, Color.Aquamarine, Color.Black);
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
                                    try
                                    {
                                        mmm.messageData[3] = (Byte)SByte.Parse(tb3_tarm_r.Text);
                                    }
                                    catch (FormatException)
                                    {
                                        mmm.messageData[3] = 0;
                                    }
                                    try
                                    {
                                        mmm.messageData[4] = (Byte)SByte.Parse(tb3_t1_r.Text);
                                    }
                                    catch (FormatException)
                                    {
                                        mmm.messageData[4] = 0;
                                    }
                                    try
                                    {
                                        mmm.messageData[5] = (Byte)SByte.Parse(tb3_t2_r.Text);
                                    }
                                    catch (FormatException)
                                    {
                                        mmm.messageData[5] = 0;
                                    }
                                    mmm.messageLen = 8;
                                    canmsg_t mmsg = new canmsg_t();
                                    mmsg.data = new Byte[8];
                                    mmsg = mmm.ToCAN(mmm);
                                    if (!uniCAN.Send(ref mmsg, 200))
                                        return;
                                    mss = "T1=" + ((SByte)mmm.messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                                        "T2=" + ((SByte)mmm.messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                                        "T3=" + ((SByte)mmm.messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                                    text2rtb(rtb3_datagrid, "Статус " + polo + "\t" + msgdata2string(mmsg) + "\t" + mss, Color.Aquamarine, Color.Black);
                                }
                                #endregion
                            }
                            break;
    #endregion
                        case msg_t.mID_DATA:
    #region mID_DATA
                            #region сброс сообщений для ОЛО в режиме программирования
                            if (mm.deviceID == Const.OLO_Left && flag_reset_left)
                            {
                                break;
                            }
                            if (mm.deviceID == Const.OLO_Right && flag_reset_right)
                            {
                                break;
                            }
                            #endregion
                            int az = BitConverter.ToInt16(mm.messageData, 4);
                            int um = BitConverter.ToInt16(mm.messageData, 6);
                            //mss = "Азимут = " + (az / 60).ToString("0'°'") + (az % 60).ToString() + "' " +
                            //      "Угол = " + (um / 60).ToString("0'°'") + (um % 60).ToString() + "'";
                            mss = "Азимут = " + (az / 60).ToString("0'°'") + (az % 60).ToString() + "' ";
                            mss += "Угол = " + (um / 60).ToString("0'°'") + (um % 60).ToString() + "'";
                            Shots sh = new Shots();
                            sh.bort = (mm.deviceID == Const.OLO_Left) ? (Byte)0 : (Byte)1;
                            sh.azimut = BitConverter.ToInt16(mm.messageData, 4);
                            sh.ugol = BitConverter.ToInt16(mm.messageData, 6);
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
                            break;
    #endregion
                        case msg_t.mID_STATUS:
    #region mID_STATUS
                            mss = "T1=" + ((SByte)mm.messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                                "T2=" + ((SByte)mm.messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                                "T3=" + ((SByte)mm.messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                            break;
    #endregion
                    }
    #region Вывод инфы в грид
/*
                    String rawdata = "";
                    for (int j = 0; j < mm.messageLen; j++)
                        rawdata += mm.messageData[j].ToString("X2") + " ";

                    String stimestamp = "";

                    timestamp = 0;
                    String temp_str = "";
                    temp_str = strelka_s + "\t" + rawdata + " \t" + mss;
                    if (mm.messageID.ToString("X2") == "2D")
                    {
                        timestamp = BitConverter.ToUInt32(mm.messageData, 0);
                        stimestamp = timestamp.ToString();
                        temp_str += "\t" + stimestamp;
                    }
                    temp_str += "\r\n";
                    if (mm.messageID.ToString("X2") == "2D")
                    {
                        if (BitConverter.ToInt16(mm.messageData, 4) != 0x7FFF)
                        {
                            rtb3_datagrid.AppendText(temp_str, Color.Orange, Color.Black);
                        }
                        else
                        {
                            rtb3_datagrid.AppendText(temp_str, Color.Red);
                        }
                    }
                    else
                    {
                        rtb3_datagrid.AppendText(temp_str);
                    }
                    rtb3_datagrid.ScrollToCaret();
*/
    #endregion
                }
            }
            Timer_GetData3.Enabled = true;
        }
        #region таймеры эмуляции ресета
        private void timer3_reset_l_Tick(object sender, EventArgs e)
        {
            flag_reset_left = false;
            timer3_reset_l.Enabled = false;
        }
        private void timer3_reset_r_Tick(object sender, EventArgs e)
        {
            flag_reset_right = false;
            timer3_reset_r.Enabled = false;
        }
        #endregion
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            const UInt16 DSPOT = 4;
            if (list_shots.Count > 0)
            {
                foreach (var it in list_shots)
                {
                    int x = 0, y = 0;
                    Double z = 0;
                    Double ugol = (Double)it.ugol / 60, azimut = (Double)it.azimut / 60;
                    z = (int)Math.Abs(ugol);

                    if (it.bort == 1)
                    {
                        x = (int)(z * Math.Cos((Double)(azimut * Math.PI / 180)));
                        y = (int)(z * Math.Sin((Double)(azimut * Math.PI / 180)));
                    }
                    else
                    {
                        x = (int)(z * Math.Cos((Double)((azimut + 180) * Math.PI / 180)));
                        y = (int)(z * Math.Sin((Double)((azimut + 180) * Math.PI / 180)));
                    }
                    if (ugol < 0)
                        gr.FillEllipse(new SolidBrush(Color.Red), x + 99 - DSPOT, y + 99 - DSPOT, DSPOT * 2, DSPOT * 2);
                    else
                        gr.FillEllipse(new SolidBrush(Color.Green), x + 99 - DSPOT, y + 99 - DSPOT, DSPOT * 2, DSPOT * 2);
                }
                if(cb_clear_shot.Checked)
                    list_shots.Clear();
            }
            gr.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
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
                gb_olo_L.BackColor = Color.PaleGreen;
                shoot_l.Enabled = true;
                chb_L_Err_int.Enabled = true;
                chb_L_Err_file.Enabled = true;
                chb_L_Err_plis.Enabled = true;
                label26.Enabled = true;
                cb_olo_l_ena.BackColor = Color.SpringGreen;
//                timer_testOLO_L.Enabled = false;
                chb4_enshl.Enabled = true;
                bt3_baddata_l.Enabled = true;
                bt3_badstatus_l.Enabled = true;
                bt3_trash_l.Enabled = true;
                lb3_t1_l.Enabled = true;
                lb3_t2_l.Enabled = true;
                lb3_tarm_l.Enabled = true;
                tb3_t1_l.Enabled = true;
                tb3_t2_l.Enabled = true;
                tb3_tarm_l.Enabled = true;
            }
            else
            {
                cb_olo_l_ena.Text = "Эмуляция выключена";
                gb_olo_L.BackColor = Color.Transparent;
                shoot_l.Enabled = false;
                timer_testOLO_L.Enabled = false;
                label26.Enabled = false;
                chb_L_Err_int.Enabled = false;
                chb_L_Err_file.Enabled = false;
                chb_L_Err_plis.Enabled = false;
                chb_L_Err_int.Checked = false;
                chb_L_Err_file.Checked = false;
                chb_L_Err_plis.Checked = false;
                cb_olo_l_ena.BackColor = Color.Transparent;
                chb4_enshl.Enabled = false;
                bt3_baddata_l.Enabled = false;
                bt3_badstatus_l.Enabled = false;
                bt3_trash_l.Enabled = false;
                lb3_t1_l.Enabled = false;
                lb3_t2_l.Enabled = false;
                lb3_tarm_l.Enabled = false;
                tb3_t1_l.Enabled = false;
                tb3_t2_l.Enabled = false;
                tb3_tarm_l.Enabled = false;
            }
        }
        private void cb_olo_r_ena_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_olo_r_ena.Checked)
            {
                cb_olo_r_ena.Text = "Эмуляция включена";
                gb_olo_R.BackColor = Color.PaleGreen;
                shoot_r.Enabled = true;
                chb_R_Err_int.Enabled = true;
                chb_R_Err_file.Enabled = true;
                chb_R_Err_plis.Enabled = true;
                label27.Enabled = true;
                cb_olo_r_ena.BackColor = Color.SpringGreen;
                chb4_enshr.Enabled = true;
                bt3_baddata_r.Enabled = true;
                bt3_badstatus_r.Enabled = true;
                bt3_trash_r.Enabled = true;
                lb3_t1_r.Enabled = true;
                lb3_t2_r.Enabled = true;
                lb3_tarm_r.Enabled = true;
                tb3_t1_r.Enabled = true;
                tb3_t2_r.Enabled = true;
                tb3_tarm_r.Enabled = true;
            }
            else
            {
                shoot_r.Enabled = false;
                cb_olo_r_ena.Text = "Эмуляция выключена";
                gb_olo_R.BackColor = Color.Transparent;
                timer_testOLO_R.Enabled = false;
                chb_R_Err_int.Enabled = false;
                chb_R_Err_file.Enabled = false;
                chb_R_Err_plis.Enabled = false;
                chb_R_Err_int.Checked = false;
                chb_R_Err_file.Checked = false;
                chb_R_Err_plis.Checked = false;
                label27.Enabled = false;
                cb_olo_r_ena.BackColor = Color.Transparent;
                chb4_enshr.Enabled = false;
                bt3_baddata_r.Enabled = false;
                bt3_badstatus_r.Enabled = false;
                bt3_trash_r.Enabled = false;
                lb3_t1_r.Enabled = false;
                lb3_t2_r.Enabled = false;
                lb3_tarm_r.Enabled = false;
                tb3_t1_r.Enabled = false;
                tb3_t2_r.Enabled = false;
                tb3_tarm_r.Enabled = false;
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
        private void bt3_clearlog_Click(object sender, EventArgs e)
        {
            rtb3_datagrid.Clear();
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
        private void chb3_shoot_ena_CheckedChanged(object sender, EventArgs e)
        {
            list_shots.Clear();
            panel3.Refresh();
            if (chb3_shoot_ena.Checked)
            {
                lb3_shoot_az_val_l.Enabled = true;
                lb3_freq_val_l.Enabled = true;
                lb3_freq_txt_l.Enabled = true;
                lb3_shoot_um_val_l.Enabled = true;
                lb3_shoot_az_txt_l.Enabled = true;
                lb3_shoot_um_txt_l.Enabled = true;
                lb3_shoot_az_val_l.Text = (trackBar3_az_l.Value).ToString("0'°'");
                lb3_shoot_um_val_l.Text = (trackBar3_um_l.Value).ToString("0'°'");
                trackBar3_az_l.Enabled = true;
                trackBar3_um_l.Enabled = true;
                trackBar3_freq_l.Enabled = true;
                lb3_freq_val_l.Text = (trackBar3_freq_l.Value).ToString() + " Гц";

                lb3_shoot_az_val_r.Enabled = true;
                lb3_freq_val_r.Enabled = true;
                lb3_freq_txt_r.Enabled = true;
                lb3_shoot_um_val_r.Enabled = true;
                lb3_shoot_az_txt_r.Enabled = true;
                lb3_shoot_um_txt_r.Enabled = true;
                lb3_shoot_az_val_r.Text = (trackBar3_az_r.Value).ToString("0'°'");
                lb3_shoot_um_val_r.Text = (trackBar3_um_r.Value).ToString("0'°'");
                trackBar3_az_r.Enabled = true;
                trackBar3_um_r.Enabled = true;
                trackBar3_freq_r.Enabled = true;
                lb3_freq_val_r.Text = (trackBar3_freq_r.Value).ToString() + " Гц";

                lb3_az_su_l.Enabled = true;
                lb3_az_su_r.Enabled = true;
                lb3_um_su_l.Enabled = true;
                lb3_um_su_r.Enabled = true;

                lb3_az_mig_l.Enabled = true;
                lb3_az_mig_r.Enabled = true;
                lb3_um_mig_l.Enabled = true;
                lb3_um_mig_r.Enabled = true;

                label70.Enabled = true;
                label72.Enabled = true;
                label83.Enabled = true;
                label64.Enabled = true;
                label63.Enabled = true;
                label84.Enabled = true;
                label82.Enabled = true;
                label81.Enabled = true;
                label78.Enabled = true;
                label77.Enabled = true;

                ms[0] = (short)(trackBar3_az_l.Value * 60);
                ms[1] = (short)(trackBar3_um_l.Value * 60);
                Conv_olo_to_ssk((Int32)Conv_Carrier.SU, ms, (UInt32)Conv_OLO_num.Left, ssk);
                lb3_az_su_l.Text = rad2deg(ssk[0]).ToString("F3") + '°';
                lb3_um_su_l.Text = rad2deg(ssk[1]).ToString("F3") + '°';
                Conv_olo_to_ssk((Int32)Conv_Carrier.MiG, ms, (UInt32)Conv_OLO_num.Left, ssk);
                lb3_az_mig_l.Text = rad2deg(ssk[0]).ToString("F3") + '°';
                lb3_um_mig_l.Text = rad2deg(ssk[1]).ToString("F3") + '°';

                ms[0] = (short)(trackBar3_az_r.Value * 60);
                ms[1] = (short)(trackBar3_um_r.Value * 60);
                Conv_olo_to_ssk((Int32)Conv_Carrier.SU, ms, (UInt32)Conv_OLO_num.Right, ssk);
                lb3_az_su_r.Text = rad2deg(ssk[0]).ToString("F3") + '°';
                lb3_um_su_r.Text = rad2deg(ssk[1]).ToString("F3") + '°';
                Conv_olo_to_ssk((Int32)Conv_Carrier.MiG, ms, (UInt32)Conv_OLO_num.Right, ssk);
                lb3_az_mig_r.Text = rad2deg(ssk[0]).ToString("F3") + '°';
                lb3_um_mig_r.Text = rad2deg(ssk[1]).ToString("F3") + '°';
            }
            else
            {
                lb3_shoot_az_val_l.Enabled = false;
                lb3_shoot_um_val_l.Enabled = false;
                lb3_shoot_az_txt_l.Enabled = false;
                lb3_shoot_um_txt_l.Enabled = false;
                lb3_freq_val_l.Enabled = false;
                lb3_freq_txt_l.Enabled = false;
                trackBar3_az_l.Enabled = false;
                trackBar3_um_l.Enabled = false;
                trackBar3_freq_l.Enabled = false;

                lb3_shoot_az_val_r.Enabled = false;
                lb3_shoot_um_val_r.Enabled = false;
                lb3_shoot_az_txt_r.Enabled = false;
                lb3_shoot_um_txt_r.Enabled = false;
                lb3_freq_val_r.Enabled = false;
                lb3_freq_txt_r.Enabled = false;
                trackBar3_az_r.Enabled = false;
                trackBar3_um_r.Enabled = false;
                trackBar3_freq_r.Enabled = false;

                chb4_enshl.CheckState = CheckState.Unchecked;
                chb4_enshr.CheckState = CheckState.Unchecked;

                lb3_az_su_l.Enabled = false;
                lb3_az_su_r.Enabled = false;
                lb3_um_su_l.Enabled = false;
                lb3_um_su_r.Enabled = false;

                lb3_az_mig_r.Enabled = false;
                lb3_az_mig_l.Enabled = false;
                lb3_um_mig_l.Enabled = false;
                lb3_um_mig_r.Enabled = false;

                label70.Enabled = false;
                label72.Enabled = false;
                label83.Enabled = false;
                label64.Enabled = false;
                label63.Enabled = false;
                label84.Enabled = false;
                label82.Enabled = false;
                label81.Enabled = false;
                label78.Enabled = false;
                label77.Enabled = false;
            }
        }
        private void chb4_enshl_CheckedChanged(object sender, EventArgs e)
        {
            if (chb4_enshl.Checked)
            {
                chb4_enshl.BackColor = Color.SpringGreen;
                auto_l = new autoshoots(Const.OLO_Left, (Int16)(trackBar3_az_l.Value * 60), (Int16)(trackBar3_um_l.Value * 60), (Byte)trackBar3_freq_l.Value, !chb3_shoot_ena.Checked);
                flag_thr_l_shoot = true;
                thr_l_shoot = new Thread(new ThreadStart(auto_l.Shoot_L));
                thr_l_shoot.Start();
                String mss;
                mss = "Азимут = " + trackBar3_az_l.Value.ToString("0'°'");
                mss += " Угол = " + trackBar3_um_l.Value.ToString("0'°'") + "\t";
                Shots sh = new Shots();
                sh.bort = (Byte)0;
                sh.azimut = (Int16)(trackBar3_az_l.Value * 60);
                sh.ugol = (Int16)(trackBar3_um_l.Value * 60);
                list_shots.Add(sh);
                panel3.Refresh();
                text2rtb(rtb3_datagrid, "Запуск выстрелов " + lolo + "\t" + mss + "\t" + trackBar3_freq_l.Value.ToString() + " Гц", Color.Orange, Color.Black);
            }
            else
            {
//                thr_l_shoot.Abort();
                flag_thr_l_shoot = false;
                while (thr_l_shoot.ThreadState != System.Threading.ThreadState.Stopped) ;
                chb4_enshl.BackColor = Color.Transparent;
                text2rtb(rtb3_datagrid, "Выключение выстрелов " + lolo, Color.Orange, Color.Black);
            }
        }
        private void chb4_enshr_CheckedChanged(object sender, EventArgs e)
        {
            if (chb4_enshr.Checked)
            {
                chb4_enshr.BackColor = Color.SpringGreen;
                auto_r = new autoshoots(Const.OLO_Right, (Int16)(trackBar3_az_r.Value * 60), (Int16)(trackBar3_um_r.Value * 60), (Byte)trackBar3_freq_r.Value, !chb3_shoot_ena.Checked);
                flag_thr_r_shoot = true;
                thr_r_shoot = new Thread(new ThreadStart(auto_r.Shoot_R));
                thr_r_shoot.Start();
                String mss;
                mss = "Азимут = " + trackBar3_az_r.Value.ToString("0'°'");
                mss += " Угол = " + trackBar3_um_r.Value.ToString("0'°'") + "\t";
                Shots sh = new Shots();
                sh.bort = (Byte)1;
                sh.azimut = (Int16)(trackBar3_az_r.Value * 60);
                sh.ugol = (Int16)(trackBar3_um_r.Value * 60);
                list_shots.Add(sh);
                text2rtb(rtb3_datagrid, "Запуск выстрелов " + polo + "\t" + mss + "\t" + trackBar3_freq_r.Value.ToString() + " Гц", Color.Orange, Color.Black);
                panel3.Refresh();
            }
            else
            {
                flag_thr_r_shoot = false;
//                thr_r_shoot.Abort();
                while (thr_r_shoot.ThreadState != System.Threading.ThreadState.Stopped) ;
                chb4_enshr.BackColor = Color.Transparent;
                text2rtb(rtb3_datagrid, "Выключение выстрелов " + polo, Color.Orange, Color.Black);
            }
        }
        private void bt4_scene_start_Click(object sender, EventArgs e)
        {
            tim4_run_scene.Enabled = true;
            bt3_scene_start.Enabled = false;
            bt3_scene_stop.Enabled = true;
            scene_time = 0;
            flag_enable_scene = true;
            tim4_run_scene.Interval = scene[0].time;
            scene_cnt = 0;
        }
        private void bt4_scene_stop_Click(object sender, EventArgs e)
        {
            tim4_run_scene.Enabled = false;
            bt3_scene_start.Enabled = true;
            bt3_scene_stop.Enabled = false;
            flag_enable_scene = false;
        }
        private void bt4_load_scene_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd4 = new OpenFileDialog();
            ofd4.Title = "Загрузка файла сценария";
            ofd4.Filter = "Файлы сценария (*.txt; *.scn)|*.txt;*.scn|Все файлы (*.*)|*.*";
            if (ofd4.ShowDialog() != DialogResult.OK)
            {
                bt3_scene_start.Enabled = false;
                bt3_scene_stop.Enabled = false;
                return;
            }
            FileInfo scfi = new FileInfo(ofd4.FileName);
            tb4_scene_file.Text = scfi.Name;
            using (StreamReader sr = new StreamReader(ofd4.FileName))
            {
                UInt32 ccc = 0;
                String rline = "";
                String[] aline = new String[4];
                SCENE scline = new SCENE();
                scene.Clear();
                while (sr.Peek() >= 0)
                {
                    if ((rline = sr.ReadLine()) != "")
                    {
                        aline = rline.Split(new char[] { ';' });
                        scline.time = Convert.ToInt32(aline[0]);
                        scline.olo = Convert.ToByte(aline[1]);
                        if (chb4_PSK.Checked)
                        {
                            scline.azimut = Convert.ToInt32(aline[2]);
                            scline.ugolmesta = Convert.ToInt32(aline[3]);
                        }
                        else
                        {
                            if (chb4_SU.Checked)
                            {
                                ssk[0] = (float)deg2rad((float)(Convert.ToInt32(aline[2])) / 60) ;
                                ssk[1] = (float)deg2rad((float)(Convert.ToInt32(aline[3])) / 60) ;
                                if (scline.olo == 0)
                                    Conv_ssk_to_olo((Int32)Conv_Carrier.SU, ssk, (UInt32)Conv_OLO_num.Right, ms);
                                else
                                    Conv_ssk_to_olo((Int32)Conv_Carrier.SU, ssk, (UInt32)Conv_OLO_num.Left, ms);
                            }
                            else
                            {
                                ssk[0] = (float)deg2rad((float)(Convert.ToInt32(aline[2])) / 60);
                                ssk[1] = (float)deg2rad((float)(Convert.ToInt32(aline[3])) / 60);
                                if (scline.olo == 0)
                                    Conv_ssk_to_olo((Int32)Conv_Carrier.MiG, ssk, (UInt32)Conv_OLO_num.Right, ms);
                                else
                                    Conv_ssk_to_olo((Int32)Conv_Carrier.MiG, ssk, (UInt32)Conv_OLO_num.Left, ms);
                            }
                            scline.azimut = ms[0];
                            scline.ugolmesta = ms[1];
                        }
                        scene.Add(scline);
                        //                        rtb3_datagrid.AppendText(scline.time.ToString() + " " + scline.olo.ToString() + " " + scline.azimut.ToString() + " " + scline.ugolmesta.ToString() + crlf);
                    }
                }
            }
            bt3_scene_start.Enabled = true;
        }
        private void tim4_run_scene_Tick(object sender, EventArgs e)
        {
            scene_time = scene[scene_cnt].time;

            msg_t mm = new msg_t();
            if (scene[scene_cnt].olo == 0)
                mm.deviceID = Const.OLO_Right;
            else
                mm.deviceID = Const.OLO_Left;

            mm.messageID = msg_t.mID_DATA;
            mm.messageLen = 8;

            UInt64 dl = (ConvertToUnixTimestamp(DateTime.Now) * 1000 + (UInt32)DateTime.Now.Millisecond) * 100;
            mm.messageData[0] = (Byte)dl;
            mm.messageData[1] = (Byte)(dl >> 8);
            mm.messageData[2] = (Byte)(dl >> 16);
            mm.messageData[3] = (Byte)(dl >> 24);
            mm.messageData[4] = 0xFF;
            mm.messageData[5] = 0x7F;
            mm.messageData[6] = 0xFF;
            mm.messageData[7] = 0x7F;

            canmsg_t mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mm.ToCAN(mm);
            if (!Form1.uniCAN.Send(ref mmsg, 200))
                return;

            dl = (ConvertToUnixTimestamp(DateTime.Now) * 1000 + (UInt32)DateTime.Now.Millisecond) * 100;
            mm.messageData[0] = (Byte)dl;
            mm.messageData[1] = (Byte)(dl >> 8);
            mm.messageData[2] = (Byte)(dl >> 16);
            mm.messageData[3] = (Byte)(dl >> 24);

            mm.messageData[4] = (Byte)scene[scene_cnt].azimut;
            mm.messageData[5] = (Byte)(scene[scene_cnt].azimut >> 8);
            mm.messageData[6] = (Byte)scene[scene_cnt].ugolmesta;
            mm.messageData[7] = (Byte)(scene[scene_cnt].ugolmesta >> 8);
            mmsg = new canmsg_t();
            mmsg.data = new Byte[8];
            mmsg = mm.ToCAN(mm);
            if (!Form1.uniCAN.Send(ref mmsg, 200))
                return;


            scene_cnt++;
            rtb3_datagrid.AppendText(scene_time.ToString() + crlf);
            if (scene_cnt == scene.Count)
            {
                bt3_scene_stop.PerformClick();
                return;
            }
            if (scene[scene_cnt].time - scene_time > 0)
            {
                tim4_run_scene.Interval = scene[scene_cnt].time - scene_time;
            }
            else
            {
                tim4_run_scene.Interval = scene[scene_cnt].time;
            }
        }
        #region Чекбоксы входных данных сценария
        private void chb4_PSK_CheckedChanged(object sender, EventArgs e)
        {
            if (chb4_PSK.Checked)
            {
                //chb4_SSK.Checked = false;
                chb4_SSK.CheckState = CheckState.Unchecked;
                chb4_SU.Enabled = false;
                chb4_MIG.Enabled = false;
            }
            else
            {
                chb4_SSK.CheckState = CheckState.Checked;
                //chb4_SSK.Checked = true;
                chb4_SU.Enabled = true;
                chb4_MIG.Enabled = true;
            }
        }
        private void chb4_SSK_CheckedChanged(object sender, EventArgs e)
        {
            if (chb4_SSK.Checked)
            {
                chb4_PSK.CheckState = CheckState.Unchecked;
                //chb4_PSK.Checked = false;
                chb4_SU.Enabled = true;
                chb4_MIG.Enabled = true;
            }
            else
            {
                chb4_PSK.CheckState = CheckState.Checked;
                //chb4_SSK.Checked = true;
                chb4_SU.Enabled = false;
                chb4_MIG.Enabled = false;
            }
        }
        private void chb4_SU_CheckedChanged(object sender, EventArgs e)
        {
            if (chb4_SU.Checked)
                chb4_MIG.CheckState = CheckState.Unchecked;
            else
                chb4_MIG.CheckState = CheckState.Checked;
        }
        private void chb4_MIG_CheckedChanged(object sender, EventArgs e)
        {
            if (chb4_MIG.Checked)
                chb4_SU.CheckState = CheckState.Unchecked;
            else
                chb4_SU.CheckState = CheckState.Checked;
        }
        #endregion

        #region Тракбары
        private void trackBar3_az_l_Scroll(object sender, EventArgs e)
        {
            lb3_shoot_az_val_l.Text = (trackBar3_az_l.Value).ToString("0'°'");
            ms[0] = (short)(trackBar3_az_l.Value * 60);
            ms[1] = (short)(trackBar3_um_l.Value * 60);
            Conv_olo_to_ssk((Int32)Conv_Carrier.SU, ms, (UInt32)Conv_OLO_num.Left, ssk);
            lb3_az_su_l.Text = rad2deg(ssk[0]).ToString("F3") + '°';
            lb3_um_su_l.Text = rad2deg(ssk[1]).ToString("F3") + '°';
            Conv_olo_to_ssk((Int32)Conv_Carrier.MiG, ms, (UInt32)Conv_OLO_num.Left, ssk);
            lb3_az_mig_l.Text = rad2deg(ssk[0]).ToString("F3") + '°';
            lb3_um_mig_l.Text = rad2deg(ssk[1]).ToString("F3") + '°';
        }
        private void trackBar3_um_l_Scroll(object sender, EventArgs e)
        {
            lb3_shoot_um_val_l.Text = (trackBar3_um_l.Value).ToString("0'°'");
            ms[0] = (short)(trackBar3_az_l.Value * 60);
            ms[1] = (short)(trackBar3_um_l.Value * 60);
            Conv_olo_to_ssk((Int32)Conv_Carrier.SU, ms, (UInt32)Conv_OLO_num.Left, ssk);
            lb3_az_su_l.Text = rad2deg(ssk[0]).ToString("F3") + '°';
            lb3_um_su_l.Text = rad2deg(ssk[1]).ToString("F3") + '°';
            Conv_olo_to_ssk((Int32)Conv_Carrier.MiG, ms, (UInt32)Conv_OLO_num.Left, ssk);
            lb3_az_mig_l.Text = rad2deg(ssk[0]).ToString("F3") + '°';
            lb3_um_mig_l.Text = rad2deg(ssk[1]).ToString("F3") + '°';
        }
        private void trackBar3_freq_l_Scroll(object sender, EventArgs e)
        {
            lb3_freq_val_l.Text = (trackBar3_freq_l.Value).ToString() + " Гц";
        }
        private void trackBar3_az_r_Scroll(object sender, EventArgs e)
        {
            lb3_shoot_az_val_r.Text = (trackBar3_az_r.Value).ToString("0'°'");
            ms[0] = (short)(trackBar3_az_r.Value * 60);
            ms[1] = (short)(trackBar3_um_r.Value * 60);
            Conv_olo_to_ssk((Int32)Conv_Carrier.SU, ms, (UInt32)Conv_OLO_num.Right, ssk);
            lb3_az_su_r.Text = rad2deg(ssk[0]).ToString("F3") + '°';
            lb3_um_su_r.Text = rad2deg(ssk[1]).ToString("F3") + '°';
            Conv_olo_to_ssk((Int32)Conv_Carrier.MiG, ms, (UInt32)Conv_OLO_num.Right, ssk);
            lb3_az_mig_r.Text = rad2deg(ssk[0]).ToString("F3") + '°';
            lb3_um_mig_r.Text = rad2deg(ssk[1]).ToString("F3") + '°';
        }
        private void trackBar3_um_r_Scroll(object sender, EventArgs e)
        {
            lb3_shoot_um_val_r.Text = (trackBar3_um_r.Value).ToString("0'°'");
            ms[0] = (short)(trackBar3_az_r.Value * 60);
            ms[1] = (short)(trackBar3_um_r.Value * 60);
            Conv_olo_to_ssk((Int32)Conv_Carrier.SU, ms, (UInt32)Conv_OLO_num.Right, ssk);
            lb3_az_su_r.Text = rad2deg(ssk[0]).ToString("F3") + '°';
            lb3_um_su_r.Text = rad2deg(ssk[1]).ToString("F3") + '°';
            Conv_olo_to_ssk((Int32)Conv_Carrier.MiG, ms, (UInt32)Conv_OLO_num.Right, ssk);
            lb3_az_mig_r.Text = rad2deg(ssk[0]).ToString("F3") + '°';
            lb3_um_mig_r.Text = rad2deg(ssk[1]).ToString("F3") + '°';
        }
        private void trackBar3_freq_r_Scroll(object sender, EventArgs e)
        {
            lb3_freq_val_r.Text = (trackBar3_freq_r.Value).ToString() + " Гц";
        }
        
        #endregion
        #endregion

        #region OLO_CANTest
        private void bt_OpenCAN4_Click(object sender, EventArgs e)
        {
            if (uniCAN != null)// && uniCAN.Is_Open)
            {
                uniCAN.Recv_Disable();
                uniCAN.Close();
                state_Error();
                lb_error_CAN.Visible = false;
                uniCAN = null;
            }
            GC.Collect();

            if (cb_CAN4.SelectedItem.ToString() == "No CAN" || cb_CAN4.Items.Count < 1)
                return;
            if (cb_CAN4.SelectedItem.ToString() == "USB Marathon")
            {
                marCAN = new MCANConverter();
                uniCAN = marCAN as MCANConverter;
            }
            else if (cb_CAN4.SelectedItem.ToString() == "PCI Advantech")
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
            uniCAN.Speed = 0;
            lb_error_CAN.Visible = false;
            if (!uniCAN.Open())
            {
                state_Error();
                return;
            }
            state_Ready();
            lb_noerr4.Visible = true;
            lb_noerr4.Text = uniCAN.Info;
            frame.data = new Byte[8];
            uniCAN.Recv_Enable();

            if (uniCAN.Is_Open)
            {
                // Запрос температуры
                frame.id = Const.CAN_ID_GET_TEMPERATURES;
                Array.Clear(frame.data, 0, 8);
                if (!uniCAN.Send(ref frame))
                    return;
                if (uniCAN == null || !uniCAN.Recv(ref frame, 200))
                    return;
                else
                {
                    if (frame.id == 0xA7)
                        lb_version.Text = "Тестовая прошивка v." + frame.data[3].ToString();
                    lb_version.Visible = true;
                    ver = frame.data[3];
                    lb_T1_val4.Text = ((_s8)frame.data[0]).ToString("'+'##.0'°';'-'##.0'°';'0°'");
                    lb_T2_val4.Text = ((_s8)frame.data[1]).ToString("'+'##.0'°';'-'##.0'°';'0°'");
                    lb_T3_val4.Text = ((_s8)frame.data[2]).ToString("'+'##.0'°';'-'##.0'°';'0°'");
                }
            }
            timer_temperature.Enabled = true;
        }
        private void bt_CloseCAN4_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;

            uniCAN.Recv_Disable();
            if (uniCAN != null && uniCAN.Is_Open)
            {
                uniCAN.Recv_Disable();
                uniCAN.Close();
            }
            state_Error();
            lb_error_CAN4.Visible = false;
            uniCAN = null;
        }
        #region Тест загрузки ПЛИС
//#define	CAN_ID_LOAD_PLIS1								0x66
//#define	CAN_ID_LOAD_PLIS2								0x67
//#define	CAN_ID_INIT_PLIS								0x68
        private void bt_plis_init_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            gb_Tests.Enabled = false;
            lb_plis_init.Text = "";
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);
            frame.id = 0x68;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            Byte init = (Byte)(frame.data[0] & 1);
            lb_plis_init.Text = "";
            if (init > 0)
                lb_plis_init.Text = "OK";
            else
                lb_plis_init.Text = "ERR";
        }

        private void bt_plis1_load_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            gb_Tests.Enabled = false;
            lb_plis1_load.Text = "";
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);
            frame.id = 0x66;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            Byte init = (Byte)(frame.data[0] & 1);
            lb_plis1_load.Text = "";
            if (init > 0)
                lb_plis1_load.Text = "OK";
            else
                lb_plis1_load.Text = "ERR";
        }

        private void bt_plis2_load_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            gb_Tests.Enabled = false;
            lb_plis2_load.Text = "";
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);
            frame.id = 0x67;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            Byte init = (Byte)(frame.data[0] & 1);
            //            Byte upload1 = (Byte)((frame.data[0] >> 1) & 1);
            //            Byte upload2 = (Byte)((frame.data[0] >> 2) & 1);
            lb_plis2_load.Text = "";
            if (init > 0)
                lb_plis2_load.Text = "OK";
            else
                lb_plis2_load.Text = "ERR";

            //            lb_test_plis.Text += (upload1 > 0) ? "PLIS1 ERR, " : "PLIS1 OK, ";
            //            lb_test_plis.Text += (upload2 > 0) ? "PLIS2 ERR" : "PLIS2 OK";
            //            lb_test_plis.Text += (upload1 > 0) ? "PLIS1 OK, " : "PLIS1 ERR, ";
            //            lb_test_plis.Text += (upload2 > 0) ? "PLIS2 OK" : "PLIS2 ERR";
        }
        private void bt_test_PLIS_Click(object sender, EventArgs e)
        {
			timer_temperature.Enabled = false;
			gb_Tests.Enabled = false;
			lb_test_plis.Text = "";
			gb_Tests.Refresh();
			Array.Clear(frame.data, 0, 8);
            frame.id = Const.CAN_ID_TEST_PLIS;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
			}
			if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
			{
				timer_temperature.Enabled = true;
                return;
			}
            timer_temperature.Enabled = true;
			gb_Tests.Enabled = true;
            Byte init = (Byte)(frame.data[0] & 1), upload1 = (Byte)((frame.data[0] >> 1) & 1), upload2 = (Byte)((frame.data[0] >> 2) & 1);
            lb_test_plis.Text = "";
            if (init > 0)
                lb_test_plis.Text = "Init OK, ";
            else
                lb_test_plis.Text = "Init ERR, ";

//            lb_test_plis.Text += (upload1 > 0) ? "PLIS1 ERR, " : "PLIS1 OK, ";
//            lb_test_plis.Text += (upload2 > 0) ? "PLIS2 ERR" : "PLIS2 OK";
            lb_test_plis.Text += (upload1 > 0) ? "PLIS1 OK, " : "PLIS1 ERR, ";
            lb_test_plis.Text += (upload2 > 0) ? "PLIS2 OK" : "PLIS2 ERR";
        }
		#endregion
        #region Test RAM D21
        private void bt_test_D21_1_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            gb_Tests.Enabled = false;
            lb_test_D21_1.Text = "";
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);
            frame.id = Const.CAN_ID_TEST_RAM_D21;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
            // Test 1 0x00 pattern
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            lb_test_D21_1.Text += (((frame.data[0] & 0x01) >> 0) == 1 ? "Test 1 - OK\r\n" : "Test 1 - ERR" + " 0x" + BitConverter.ToUInt32(frame.data, 3).ToString("X6") + " 0x" + frame.data[1].ToString("X2") + " 0x" + frame.data[2].ToString("X2") + "\r\n");
            // Test 2 0xFF pattern
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            lb_test_D21_1.Text += (((frame.data[0] & 0x01) >> 0) == 1 ? "Test 2 - OK\r\n" : "Test 2 - ERR" + " 0x" + BitConverter.ToUInt32(frame.data, 3).ToString("X6") + " 0x" + frame.data[1].ToString("X2") + " 0x" + frame.data[2].ToString("X2") + "\r\n");
            // Test 3 0x01-0xFF
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            lb_test_D21_1.Text += (((frame.data[0] & 0x01) >> 0) == 1 ? "Test 3 - OK\r\n" : "Test 3 - ERR" + " 0x" + BitConverter.ToUInt32(frame.data, 3).ToString("X6") + " 0x" + frame.data[1].ToString("X2") + " 0x" + frame.data[2].ToString("X2") + "\r\n");
            // Test 4 0xAA & 0x55 pattern
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            lb_test_D21_1.Text += (((frame.data[0] & 0x01) >> 0) == 1 ? "Test 4 - OK\r\n" : "Test 4 - ERR" + " 0x" + BitConverter.ToUInt32(frame.data, 3).ToString("X6") + " 0x" + frame.data[1].ToString("X2") + " 0x" + frame.data[2].ToString("X2") + "\r\n");
            // Test 5 random pattern
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            lb_test_D21_1.Text += (((frame.data[0] & 0x01) >> 0) == 1 ? "Test 5 - OK\r\n" : "Test 5 - ERR" + " 0x" + BitConverter.ToUInt32(frame.data, 3).ToString("X6") + " 0x" + frame.data[1].ToString("X2") + " 0x" + frame.data[2].ToString("X2") + "\r\n");
        }
        #endregion
        #region Test 2 RAM D21
        private void bt_test_D21_2_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            gb_Tests.Enabled = false;
            lb_test_D21_2.Text = "";
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);
            frame.id = Const.CAN_ID_RWTEST_RAM_D21;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            lb_test_D21_2.Text = (frame.data[0] == 1 ? "OK" : "ERR" + " 0x" + ((byte)frame.data[1]).ToString("X2") + " 0x" + ((byte)frame.data[2]).ToString("X2") + "\r\n" + BitConverter.ToUInt32(frame.data, 3).ToString("X8"));
        }
        #endregion
        #region Test RAM D13
        private void bt_test_D13_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            gb_Tests.Enabled = false;
            lb_test_D13.Text = "";
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);
            frame.id = Const.CAN_ID_TEST_RAM_D13;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            lb_test_D13.Text = (frame.data[0] > 0 ? "OK" : "ОШИБКА" + " 0x" + BitConverter.ToUInt32(frame.data, 3).ToString("X8") + " 0x" + frame.data[1].ToString("X2") + " 0x" + frame.data[2].ToString("X2"));
        }
        private void bt_test_D13_2_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            gb_Tests.Enabled = false;
            lb_test_D13_2.Text = "";
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);
            frame.id = Const.CAN_ID_TEST_RAM_D13_2;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            lb_test_D13_2.Text = (frame.data[0] > 0 ? "OK" : "ОШИБКА" + " 0x" + BitConverter.ToUInt32(frame.data, 3).ToString("X8") + " 0x" + frame.data[1].ToString("X2") + " 0x" + frame.data[2].ToString("X2"));

        }
        #endregion
        #region Test RAM D19
        private void bt_test_D19_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            gb_Tests.Enabled = false;
            lb_test_D19.Text = "";
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);
            frame.id = Const.CAN_ID_TEST_RAM_D19;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            lb_test_D19.Text = (frame.data[0] > 0 ? "OK" : "ОШИБКА" + " 0x" + BitConverter.ToUInt32(frame.data, 3).ToString("X8") + " 0x" + frame.data[1].ToString("X2") + " 0x" + frame.data[2].ToString("X2"));
        }
        private void bt_test_D19_2_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            gb_Tests.Enabled = false;
            lb_test_D19_2.Text = "";
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);
            frame.id = Const.CAN_ID_TEST_RAM_D19_2;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            lb_test_D19_2.Text = (frame.data[0] > 0 ? "OK" : "ОШИБКА" + " 0x" + BitConverter.ToUInt32(frame.data, 3).ToString("X8") + " 0x" + frame.data[1].ToString("X2") + " 0x" + frame.data[2].ToString("X2"));
        }
        #endregion
        #region Тест FLASH
        private void bt_test_FLASH_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            gb_Tests.Enabled = false;
            lb_test_FLASH.Text = "";
            lb_test_FLASH_2.Text = "";
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);
            frame.id = Const.CAN_ID_TEST_FLASH;
            string sss = "";
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            // Flash init
            if (uniCAN == null || uniCAN == null || !uniCAN.Recv(ref frame, 5000))
            {
                lb_test_FLASH.Text = "Init ОШИБКА";
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            lb_test_FLASH.Text = (frame.data[0] > 0 ? "Init OK" : "Init ОШИБКА");
            lb_test_FLASH_2.Text += frame.data[7].ToString() + "-";
            // Flash format
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                lb_test_FLASH.Text = "_format ОШИБКА";
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            lb_test_FLASH.Text = (frame.data[0] > 0 ? "format OK" : "format ОШИБКА");
            lb_test_FLASH_2.Text += frame.data[7].ToString() + "-";
            // Flash open
            if (uniCAN == null || !uniCAN.Recv(ref frame, 5000))
            {
                lb_test_FLASH.Text = "_open 1 ОШИБКА";
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            lb_test_FLASH.Text = (frame.data[0] > 0 ? "open 1 OK" : "open 1 ОШИБКА");
            lb_test_FLASH_2.Text += frame.data[7].ToString() + "-";
            // Flash write
            if (uniCAN == null || !uniCAN.Recv(ref frame, 20000))
            {
                lb_test_FLASH.Text = "_write ОШИБКА" + frame.data[1] + " x " + (frame.data[2] + (frame.data[3] << 8)).ToString();
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            lb_test_FLASH_2.Text += frame.data[7].ToString() + "-";
            lb_test_FLASH.Text = (frame.data[0] > 0 ? "write OK" : "write ОШИБКА" + frame.data[1] + " x " + (frame.data[2] + (frame.data[3] << 8)).ToString());
            // Flash open
            if (uniCAN == null || !uniCAN.Recv(ref frame, 5000))
            {
                lb_test_FLASH.Text = "_open 2 ОШИБКА";
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            lb_test_FLASH.Text = (frame.data[0] > 0 ? "open 2 OK" : "open 2 ОШИБКА");
            lb_test_FLASH_2.Text += frame.data[7].ToString() + "-";
            // Flash read
            if (uniCAN == null || !uniCAN.Recv(ref frame, 20000))
            {
                if (frame.data[2] == 0)
                    lb_test_FLASH.Text = "_read ОШИБКА " + frame.data[1].ToString();
                else
                    lb_test_FLASH.Text = "_Data ОШИБКА" + frame.data[1].ToString();
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            if (frame.data[0] == 0)
            {
                if (frame.data[2] == 0)
                    lb_test_FLASH.Text = "read ОШИБКА " + frame.data[1].ToString() + " " + (frame.data[3] + (frame.data[4] << 8)).ToString();
                else
                    lb_test_FLASH.Text = "Data ОШИБКА" + frame.data[1].ToString() + " " + (frame.data[3] + (frame.data[4] << 8)).ToString();
            }
            else
                lb_test_FLASH.Text = "read OK";
            lb_test_FLASH_2.Text += frame.data[7].ToString() + "-";
            // Flash OK
            if (uniCAN == null || !uniCAN.Recv(ref frame, 5000))
            {
                lb_test_FLASH.Text = "_Flash ОШИБКА";
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            lb_test_FLASH_2.Text += frame.data[7].ToString();
            lb_test_FLASH.Text = (frame.data[0] > 0 ? "FLASH OK" : "FLASH ОШИБКА" + sss);
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
        }
        #endregion
        #region Получаем изображение с матриц
        private unsafe void bt_get_CMOS1_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            bt_About4.Enabled = false;
            bt_Exit4.Enabled = false;
            gb_Tests.Enabled = false;
            pb_CMOS1.Visible = true;
            lb_CMOS14.Visible = false;
            pb_CMOS1.Value = 0;
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);

            image_CMOS14 = new Bitmap(Const.IMAGE_CX, Const.IMAGE_CY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Buffer = new Byte[Const.IMAGE_CX * Const.IMAGE_CY];
            for (int i = 0; i < Buffer.Length; i++)
                Buffer[i] = 0;
            for (int ii = 0; ii < Const.IMAGE_CY; ii++)
            {
                for (int jj = 0; jj < Const.IMAGE_CX; jj++)
                {
                    Color col = Color.FromArgb(Buffer[Const.IMAGE_CX * ii + jj], Buffer[Const.IMAGE_CX * ii + jj], Buffer[Const.IMAGE_CX * ii + jj]);
                    image_CMOS14.SetPixel(jj, ii, col);
                }
            }
            pictureBox14.Image = image_CMOS14;

            ulong packet_count = (Const.IMAGE_CX * Const.IMAGE_CY + 8 - 1) / 8;
            int pix = 10169;
            pb_CMOS1.Maximum = (int)packet_count - 1;
            pb_CMOS2.Maximum = (int)packet_count - 1;
            frame.id = Const.CAN_ID_GET2_CMOS1_IMAGE;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                pb_CMOS1.Visible = false;
                gb_Tests.Enabled = true;
                lb_CMOS14.Visible = true;
                lb_CMOS14.Text = "Ошибка";
                return;
            }

            if (uniCAN == null || !uniCAN.RecvPack(ref Buffer, ref pix, 30000))
            {
                timer_temperature.Enabled = true;
                pb_CMOS1.Visible = false;
                gb_Tests.Enabled = true;
                lb_CMOS14.Visible = true;
                lb_CMOS14.Text = "Ошибка " + pix.ToString();
                return;
            }
            Application.DoEvents();

            pb_CMOS1.Visible = false;
            lb_CMOS14.Visible = true;
            lb_CMOS14.Text = "OK";

            image_CMOS14 = new Bitmap(Const.IMAGE_CX, Const.IMAGE_CY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (int ii = 0; ii < Const.IMAGE_CY; ii++)
            {
                for (int jj = 0; jj < Const.IMAGE_CX; jj++)
                {
                    Color col = Color.FromArgb(Buffer[Const.IMAGE_CX * ii + jj], Buffer[Const.IMAGE_CX * ii + jj], Buffer[Const.IMAGE_CX * ii + jj]);
                    image_CMOS14.SetPixel(jj, ii, col);
                }
            }

            pictureBox14.Image = image_CMOS14;

            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            bt_About4.Enabled = true;
            bt_Exit4.Enabled = true;
        }
        private unsafe void bt_get_CMOS2_Click(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            bt_About4.Enabled = false;
            bt_Exit4.Enabled = false;
            gb_Tests.Enabled = false;
            pb_CMOS2.Visible = true;
            lb_CMOS24.Visible = false;
            pb_CMOS2.Value = 0;
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);

            image_CMOS24 = new Bitmap(Const.IMAGE_CX, Const.IMAGE_CY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Buffer = new Byte[Const.IMAGE_CX * Const.IMAGE_CY];
            for (int i = 0; i < Buffer.Length; i++)
                Buffer[i] = 0;
            for (int ii = 0; ii < Const.IMAGE_CY; ii++)
            {
                for (int jj = 0; jj < Const.IMAGE_CX; jj++)
                {
                    Color col = Color.FromArgb(Buffer[Const.IMAGE_CX * ii + jj], Buffer[Const.IMAGE_CX * ii + jj], Buffer[Const.IMAGE_CX * ii + jj]);
                    image_CMOS24.SetPixel(jj, ii, col);
                }
            }
            pictureBox24.Image = image_CMOS24;

            ulong packet_count = (Const.IMAGE_CX * Const.IMAGE_CY + 8 - 1) / 8;
            int pix = 10169;
            pb_CMOS1.Maximum = (int)packet_count - 1;
            pb_CMOS2.Maximum = (int)packet_count - 1;
            frame.id = Const.CAN_ID_GET2_CMOS1_IMAGE;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                pb_CMOS2.Visible = false;
                gb_Tests.Enabled = true;
                lb_CMOS24.Visible = true;
                lb_CMOS24.Text = "Ошибка";
                return;
            }

            if (uniCAN == null || !uniCAN.RecvPack(ref Buffer, ref pix, 30000))
            {
                timer_temperature.Enabled = true;
                pb_CMOS2.Visible = false;
                gb_Tests.Enabled = true;
                lb_CMOS24.Visible = true;
                lb_CMOS24.Text = "Ошибка " + pix.ToString();
                return;
            }
            Application.DoEvents();

            pb_CMOS2.Visible = false;
            lb_CMOS24.Visible = true;
            lb_CMOS24.Text = "OK";

            image_CMOS24 = new Bitmap(Const.IMAGE_CX, Const.IMAGE_CY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (int ii = 0; ii < Const.IMAGE_CY; ii++)
            {
                for (int jj = 0; jj < Const.IMAGE_CX; jj++)
                {
                    Color col = Color.FromArgb(Buffer[Const.IMAGE_CX * ii + jj], Buffer[Const.IMAGE_CX * ii + jj], Buffer[Const.IMAGE_CX * ii + jj]);
                    image_CMOS24.SetPixel(jj, ii, col);
                }
            }

            pictureBox24.Image = image_CMOS24;

            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
            bt_About4.Enabled = true;
            bt_Exit4.Enabled = true;
        }
        #endregion
        #region Управление элементами Пельтье
        private void chb_Peltier1_CheckedChanged(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            gb_Tests.Enabled = false;
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);
            frame.id = Const.CAN_ID_SET_PELTIE1;
            frame.len = 1;
            frame.data[0] = (byte)(chb_Peltier1.Checked ? 1 : 0);
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
        }
        private void chb_Peltier2_CheckedChanged(object sender, EventArgs e)
        {
            timer_temperature.Enabled = false;
            gb_Tests.Enabled = false;
            gb_Tests.Refresh();
            Array.Clear(frame.data, 0, 8);
            frame.id = Const.CAN_ID_SET_PELTIE2;
            frame.len = 1;
            frame.data[0] = (byte)(chb_Peltier2.Checked ? 1 : 0);
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
            timer_temperature.Enabled = true;
            gb_Tests.Enabled = true;
        }
        #endregion
        #region Получаем температуру по таймеру и переключаем циклические тесты
        private void timer_temperature_Tick(object sender, EventArgs e)
        {
            if (chb5_timer_enable.Checked)
            {
                if (uniCAN != null && uniCAN.Is_Open)
                {
                    // Запрос температуры
                    frame.id = Const.CAN_ID_GET_TEMPERATURES;
                    Array.Clear(frame.data, 0, 8);
                    if (!uniCAN.Send(ref frame))
                        return;
                    if (uniCAN == null || !uniCAN.Recv(ref frame, 200))
                        return;
                    else
                    {
                        if (frame.id == 0xA7)
                            lb_version.Text = "Тестовая прошивка v." + frame.data[3].ToString();
                        lb_version.Visible = true;
                        lb_T1_val4.Text = ((_s8)frame.data[0]).ToString("'+'##.0'°';'-'##.0'°';'0°'");
                        lb_T2_val4.Text = ((_s8)frame.data[1]).ToString("'+'##.0'°';'-'##.0'°';'0°'");
                        lb_T3_val4.Text = ((_s8)frame.data[2]).ToString("'+'##.0'°';'-'##.0'°';'0°'");
                    }

                    // Старт - стоп генератора синуса
                    if (chb_Sin.Checked && generator_running == false)
                    {
                        frame.id = Const.CAN_ID_RUN_GENERATOR;
                        Array.Clear(frame.data, 0, 8);
                        if (!uniCAN.Send(ref frame))
                            return;
                        generator_running = true;
                    }
                    if (!chb_Sin.Checked && generator_running == true)
                    {
                        frame.id = Const.CAN_ID_STOP_GENERATOR;
                        Array.Clear(frame.data, 0, 8);
                        Array.Clear(frame.data, 0, 8);
                        if (!uniCAN.Send(ref frame))
                            return;
                        generator_running = false;
                    }

                    // Старт - стоп теста D21
                    if (chb_cycle_test_D21.Checked && cycle_test_D21_running == false)
                    {
                        frame.id = Const.CAN_ID_TEST_RAM_D21_RUN;
                        Array.Clear(frame.data, 0, 8);
                        if (!uniCAN.Send(ref frame))
                            return;
                        cycle_test_D21_running = true;
                    }
                    if (!chb_cycle_test_D21.Checked && cycle_test_D21_running == true)
                    {
                        frame.id = Const.CAN_ID_TEST_RAM_D21_STOP;
                        Array.Clear(frame.data, 0, 8);
                        if (!uniCAN.Send(ref frame))
                            return;
                        cycle_test_D21_running = false;
                    }

                    // Старт - стоп теста D13
                    if (chb_cycle_test_D13.Checked && cycle_test_D13_running == false)
                    {
                        frame.id = Const.CAN_ID_TEST_RAM_D13_RUN;
                        Array.Clear(frame.data, 0, 8);
                        if (!uniCAN.Send(ref frame))
                            return;
                        cycle_test_D13_running = true;
                    }
                    if (!chb_cycle_test_D13.Checked && cycle_test_D13_running == true)
                    {
                        frame.id = Const.CAN_ID_TEST_RAM_D13_STOP;
                        Array.Clear(frame.data, 0, 8);
                        if (!uniCAN.Send(ref frame))
                            return;
                        cycle_test_D13_running = false;
                    }

                    // Старт - стоп теста D19
                    if (chb_cycle_test_D19.Checked && cycle_test_D19_running == false)
                    {
                        frame.id = Const.CAN_ID_TEST_RAM_D19_RUN;
                        Array.Clear(frame.data, 0, 8);
                        if (!uniCAN.Send(ref frame))
                            return;
                        cycle_test_D19_running = true;
                    }
                    if (!chb_cycle_test_D19.Checked && cycle_test_D19_running == true)
                    {
                        frame.id = Const.CAN_ID_TEST_RAM_D19_STOP;
                        Array.Clear(frame.data, 0, 8);
                        if (!uniCAN.Send(ref frame))
                            return;
                        cycle_test_D19_running = false;
                    }
                }
            }
        }

        #endregion
        #region Тесты шины данных и адреса
        private void chb5_d21_CheckedChanged(object sender, EventArgs e)
        {
            if (chb5_d21.Checked)
            {
                chb5_d13.Enabled = false;
                chb5_d19.Enabled = false;
                gb5_ba.Enabled = false;
                gb5_bd.Enabled = false;
                timer_temperature.Enabled = false;
                Array.Clear(frame.data, 0, 8);
                frame.id = Const.CAN_ID_TEST_RAM_D21_E;
                Byte ba = 0, bd = 0;
                if (rb5_d_0.Checked)
                    bd = 0;
                if (rb5_d_1.Checked)
                    bd = 1;
                if (rb5_d_01.Checked)
                    bd = 2;
                if (rb5_a_0.Checked)
                    ba = 0;
                if (rb5_a_1.Checked)
                    ba = 1;
                if (rb5_a_01.Checked)
                    ba = 2;
                frame.data[0] = bd;
                frame.data[1] = ba;
                if (!uniCAN.Send(ref frame))
                {
                    timer_temperature.Enabled = true;
                    return;
                }
            }
            else
            {
                chb5_d13.Enabled = true;
                chb5_d19.Enabled = true;
                gb5_ba.Enabled = true;
                gb5_bd.Enabled = true;
                timer_temperature.Enabled = true;
                Array.Clear(frame.data, 0, 8);
                frame.id = Const.CAN_ID_TEST_RAM_D21_D;
                if (!uniCAN.Send(ref frame))
                {
                    timer_temperature.Enabled = true;
                    return;
                }
            }
        }
        private void chb5_d13_CheckedChanged(object sender, EventArgs e)
        {
            if (chb5_d13.Checked)
            {
                chb5_d21.Enabled = false;
                chb5_d19.Enabled = false;
                gb5_ba.Enabled = false;
                gb5_bd.Enabled = false;
                timer_temperature.Enabled = false;
                Array.Clear(frame.data, 0, 8);
                frame.id = Const.CAN_ID_TEST_RAM_D13_E;
                Byte ba = 0, bd = 0;
                if (rb5_d_0.Checked)
                    bd = 0;
                if (rb5_d_1.Checked)
                    bd = 1;
                if (rb5_d_01.Checked)
                    bd = 2;
                if (rb5_a_0.Checked)
                    ba = 0;
                if (rb5_a_1.Checked)
                    ba = 1;
                if (rb5_a_01.Checked)
                    ba = 2;
                frame.data[0] = bd;
                frame.data[1] = ba;
                if (!uniCAN.Send(ref frame))
                {
                    timer_temperature.Enabled = true;
                    return;
                }
            }
            else
            {
                chb5_d21.Enabled = true;
                chb5_d19.Enabled = true;
                gb5_ba.Enabled = true;
                gb5_bd.Enabled = true;
                timer_temperature.Enabled = true;
                Array.Clear(frame.data, 0, 8);
                frame.id = Const.CAN_ID_TEST_RAM_D13_D;
                if (!uniCAN.Send(ref frame))
                {
                    timer_temperature.Enabled = true;
                    return;
                }
            }
        }
        private void chb5_d19_CheckedChanged(object sender, EventArgs e)
        {
            if (chb5_d19.Checked)
            {
                chb5_d21.Enabled = false;
                chb5_d13.Enabled = false;
                gb5_ba.Enabled = false;
                gb5_bd.Enabled = false;
                timer_temperature.Enabled = false;
                Array.Clear(frame.data, 0, 8);
                frame.id = Const.CAN_ID_TEST_RAM_D19_E;
                Byte ba = 0, bd = 0;
                if (rb5_d_0.Checked)
                    bd = 0;
                if (rb5_d_1.Checked)
                    bd = 1;
                if (rb5_d_01.Checked)
                    bd = 2;
                if (rb5_a_0.Checked)
                    ba = 0;
                if (rb5_a_1.Checked)
                    ba = 1;
                if (rb5_a_01.Checked)
                    ba = 2;
                frame.data[0] = bd;
                frame.data[1] = ba;
                if (!uniCAN.Send(ref frame))
                {
                    timer_temperature.Enabled = true;
                    return;
                }
            }
            else
            {
                chb5_d21.Enabled = true;
                chb5_d13.Enabled = true;
                gb5_ba.Enabled = true;
                gb5_bd.Enabled = true;
                timer_temperature.Enabled = true;
                Array.Clear(frame.data, 0, 8);
                frame.id = Const.CAN_ID_TEST_RAM_D19_D;
                if (!uniCAN.Send(ref frame))
                {
                    timer_temperature.Enabled = true;
                    return;
                }
            }
        }
        #endregion
        private void bt5_reset_Click(object sender, EventArgs e)
        {
            frame.id = 5;
            frame.len = 1;
            if (!uniCAN.Send(ref frame))
            {
                timer_temperature.Enabled = true;
                return;
            }
        }
        private void сброс_результатов()
        {
            lb_test_FLASH.Text = "";
            lb_test_D19_2.Text = "";
            lb_test_D13_2.Text = "";
            lb_test_D19.Text = "";
            lb_test_D13.Text = "";
            lb_test_D21_2.Text = "";
            lb_test_D21_1.Text = "";
            lb_test_plis.Text = "";
            chb_cycle_test_D21.Checked = false;
            chb_cycle_test_D13.Checked = false;
            chb_cycle_test_D19.Checked = false;
            chb5_d21.Checked = false;
            chb5_d13.Checked = false;
            chb5_d19.Checked = false;
            chb_Peltier1.Checked = false;
            chb_Peltier2.Checked = false;
            chb_Sin.Checked = false;
        }
        #endregion

        #region Вкладка настроек
        private void button7_Click(object sender, EventArgs e)
        {
            inicfg._SetBool("setup", "key1", chb_6_1.Checked);
            inicfg._SetBool("setup", "key2", chb_6_2.Checked);
            inicfg._SetBool("setup", "key3", chb_6_3.Checked);
            inicfg._SetBool("setup", "key4", chb_6_4.Checked);
            inicfg._SetBool("setup", "key5", chb_6_5.Checked);
            inicfg._SetBool("setup", "key6", chb_6_6.Checked);
            inicfg._SetBool("setup", "key7", chb_6_7.Checked);
            inicfg._SetBool("setup", "key8", chb_6_8.Checked);
            inicfg._SetBool("setup", "key9", chb_6_9.Checked);
            inicfg._SetBool("setup", "key10", chb_6_10.Checked);
        }
        #endregion

        #region RichTextBox
        void text2rtb(RichTextBox rtb, String txt, Color bgcolor, Color fgcolor)
        {
            rtb.AppendText(txt + crlf, bgcolor, fgcolor);
            rtb.ScrollToCaret();
        }
        void text2rtb(RichTextBox rtb, String txt)
        {
            rtb.AppendText(txt + crlf);
            rtb.ScrollToCaret();
        }
        void text2rtb(RichTextBox rtb, String txt, Color fgcolor)
        {
            rtb.AppendText(txt + crlf, fgcolor);
            rtb.ScrollToCaret();
        }
        String msgdata2string(canmsg_t msg)
        {
            String rawdata = "";
            for (int j = 0; j < msg.len; j++)
                rawdata += msg.data[j].ToString("X2") + " ";
            return rawdata;
        }
        String msgdata2string(msg_t msg)
        {
            String rawdata = "";
            for (int j = 0; j < msg.messageLen; j++)
                rawdata += msg.messageData[j].ToString("X2") + " ";
            return rawdata;
        }
        #endregion

        #region Хрень всякая
        private void button3_Click(object sender, EventArgs e)
        {
            //            MessageBox.Show(String.Format("0x{0:X}", aaa));
            //            MessageBox.Show(String.Format("0x{0:X}", aaa));
            //            MessageBox.Show(trackBar2.Value.ToString() + " - " + (trackBar2.Value * 3.3f / 1023).ToString() + " - " + ((1.11f - trackBar2.Value * 3.3f / 1023) / (1.11f - 0.73f) / (300.0f - 50.0f) + 50.0f - 273.16f).ToString());
            //            warn2rtb(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString());
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int a = trackBar2.Value;
            Double v = (Double)a * 3.3 / 1023;
            const Double MIN_T = 50.0;	// degree  [K]
            const Double MAX_T = 300.0;	// degree  [K]
            const Double MIN_V = 0.73f;	// voltage [V]
            const Double MAX_V = 1.11f;	// voltage [V]
            Double k = ((MAX_V - (v)) / ((MAX_V - MIN_V) / (MAX_T - MIN_T)) + MIN_T);
            Double c = k - 273.16;
            label56.Text = a.ToString() + " # " + v.ToString() + " # " + c.ToString();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label58.Text = trackBar3.Value.ToString() + " # " + (5.5 * trackBar3.Value / 0.77 - trackBar3.Value).ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            CNF conf = new CNF(0x11, "12233445", "qqqqwqwrsdsdfs  fgdfgsd retre wet gg");
            if (!conf.Save("testconfig.bin"))
                MessageBox.Show("Error save!!!");
            else
                MessageBox.Show("Save OK!!!");

            if (!conf.Load("Fla3.bin"))
                MessageBox.Show("Error load!!!");
            else
                MessageBox.Show("Load OK!!!" + crlf + conf.dev_id.ToString("X2") + crlf + conf.ser_num + conf.comment);
        }
        Double deg2rad(Double deg)
        {
	        return deg * (Math.PI / 180);
        }
        Double rad2deg(Double rad)
        {
	        return 180 / Math.PI * rad;
        }
        Double[] sph2cart(Double az, Double um, Double r)
        {
	        Double[] ret = new Double[3];
	        ret[0] = (r * Math.Cos(deg2rad(um)) * Math.Cos(deg2rad(az)));
	        ret[1] = (r * Math.Cos(deg2rad(um)) * Math.Sin(deg2rad(az)));
	        ret[2] = (r * Math.Sin(deg2rad(um)));
	        return ret;
        }
        Double[] cart2sph(Double x, Double y, Double z)
        {
	        Double[] ret = new Double[3];
	        ret[0] = (Math.Atan2(y, x));
	        ret[1] = (Math.Atan2(z, Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2))));
	        ret[2] = (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)));
	        return ret;
        }
        Double[] turn_to_ssk(Double azin, Double umin, Double[,] mat)
        {
	        Double[] ret = new Double[3];
	        Double[] xyz = new Double[3];

	        xyz = sph2cart(-azin, umin, 1);

	        Double c11 = mat[0,0] * xyz[0] + mat[0,1] * xyz[2] + mat[0,2] * xyz[1];
	        Double c21 = mat[1,0] * xyz[0] + mat[1,1] * xyz[2] + mat[1,2] * xyz[1];
	        Double c31 = mat[2,0] * xyz[0] + mat[2,1] * xyz[2] + mat[2,2] * xyz[1];

	        xyz = cart2sph(c11, c31, c21);
            ret[0] = rad2deg(xyz[0]);
            ret[1] = rad2deg(xyz[1]);
	        return ret;
        }

        #endregion

        #region Техно Прием
        private void bt_OpenCAN8_Click(object sender, EventArgs e)
        {
/*
            if (cb_CAN8.SelectedItem.ToString() == "No CAN" || cb_CAN8.Items.Count < 1)
                return;
            if (cb_CAN8.SelectedItem.ToString() == "USB Marathon")
            {
                marCAN = new MCANConverter();
                uniCAN = marCAN as MCANConverter;
            }
            else if (cb_CAN8.SelectedItem.ToString() == "PCI Advantech")
            {
                advCAN = new ACANConverter();
                uniCAN = advCAN as ACANConverter;
            }
            else
            {
                elcCAN = new ECANConverter();
                uniCAN = elcCAN as ECANConverter;
            }
*/
            switch (cb_CAN8.SelectedItem.ToString())
            {
                case "No CAN":
                    return;
                case "USB Marathon":
                    marCAN = new MCANConverter();
                    uniCAN = marCAN as MCANConverter;
                    break;
                case "PCI Advantech":
                    advCAN = new ACANConverter();
                    uniCAN = advCAN as ACANConverter;
                    break;
                case "PCI Elcus":
                    elcCAN = new ECANConverter();
                    uniCAN = elcCAN as ECANConverter;
                    break;
                case "Fake CAN driver":
                    fakeCAN = new FCANConverter();
                    uniCAN = fakeCAN as FCANConverter;
                    break;
                default:
                    return;
            }

            uniCAN.ErrEvent += new MyDelegate(Err_Handler);
            uniCAN.Progress += new MyDelegate(Progress_Handler);

            uniCAN.Port = 0;
            uniCAN.Speed = 2;
            lb_error_CAN8.Visible = false;
            if (!uniCAN.Open())
            {
                state_Error();
                return;
            }
            state_Ready();
            frame.data = new Byte[8];
            _state = State.OpenedState;
            uniCAN.Recv_Enable();
            bt_start8.PerformClick();
        }
        private void bt_CloseCAN8_Click(object sender, EventArgs e)
        {
            if (uniCAN.Is_Open)
            {
                uniCAN.Recv_Disable();
                uniCAN.Close();
            }
            state_NotReady();
            lb_error_CAN8.Visible = false;
            uniCAN.Recv_Disable();
            uniCAN = null;
            bt_stop8.PerformClick();
        }
        private void bt_start8_Click(object sender, EventArgs e)
        {
            bt_start8.Enabled = false;
            bt_stop8.Enabled = true;
            flag_stop8 = true;
            while(flag_stop8)
            {
                Application.DoEvents();
                if (uniCAN == null)
                {
                    bt_stop8.PerformClick();
                    return;
                }
                if (uniCAN.VectorSize() == 0)
                {
                    Trace.WriteLine(".");
                    continue;
                }

                Trace.WriteLine("11111 " + uniCAN.VectorSize().ToString());
                canmsg_t msg = new canmsg_t();
                msg.data = new Byte[8];
                msg_t mm = new msg_t();
                if (uniCAN == null || !uniCAN.Recv(ref msg, 1000) || ((msg.id >> 5) != 0x31 && (msg.id >> 5) != 0x32) || msg.len != 0)
                {
                    Trace.WriteLine("qqqq 11111");
                    Application.DoEvents();
                    return;
                }
                //            Boolean leftright = false;
                mm = mm.FromCAN(msg);
                switch (mm.deviceID)
                {
                    case Const.OLO_Left:
                        lb_info8.Text = "ОЛО левый. Прием картинки ";
                        lb_info8.BackColor = Color.SpringGreen;
                        break;
                    case Const.OLO_Right:
                        lb_info8.Text = "ОЛО правый. Прием картинки ";
                        lb_info8.BackColor = Color.SpringGreen;
                        break;
                }

                if ((msg.id >> 5) == 0x31)
                {
                    lb_info8.Text += "1";
                }
                else
                {
                    lb_info8.Text += "2";
                }
                lb_info8.Refresh();
                Application.DoEvents();
                pb_loadbmp8.Value = 0;
                UInt32 image_size = Const.IMAGE_CX * Const.IMAGE_CY * sizeof(Byte);
                UInt32 image_data_count = 0;
                image_size = 81345;
                if (rb_data_8bit8.Checked)
                {
                    int msg_count = (int)(image_size + Const.CAN_MAX_DATA_SIZE - 1) / Const.CAN_MAX_DATA_SIZE;
//                    msg_count = 10169;
                    //                msg_count = 13558;

                    Byte[] data_array = new Byte[msg_count * 8];
                    image_data = new Byte[msg_count * 8];
                    pb_loadbmp8.Maximum = msg_count;

                    if (uniCAN == null || !uniCAN.RecvPack(ref data_array, ref msg_count, 60000)) //!!!!!!!!!!!!!!!!!!!!!!!!!
                    {
                        lb_info8.Text = "Ошибка приема картинки";
                        lb_info8.BackColor = Color.Red;
                        Trace.WriteLine("Err recv image data");
                        return;
                    }

                    for (int i = 0; i < 81345; i++)
                    {
                        image_data[i] = data_array[i];
                    }
                }
                else
                {
                    int msg_count = (int)(image_size + 6 - 1) / 6;

                    Byte[] data_array = new Byte[msg_count * 8];
                    image_data = new Byte[msg_count * 8];
                    pb_loadbmp8.Maximum = msg_count;

                    if (uniCAN == null || !uniCAN.RecvPack(ref data_array, ref msg_count, 60000)) //!!!!!!!!!!!!!!!!!!!!!!!!!
                    {
                        lb_info8.Text = "Ошибка приема картинки";
                        lb_info8.BackColor = Color.Red;
                        Trace.WriteLine("Err recv image data");
                        return;
                    }

                    UInt32 j = 0;
                    for (int i = 0; i < data_array.Length; i++)
                    {
                        if (i % 8 > 1)
                            image_data[j++] = data_array[i];
                        else
                            continue;
                    }
                }
                Bitmap BMP_CMOS = new Bitmap(Const.IMAGE_CX, Const.IMAGE_CY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                for (int ii = 0; ii < Const.IMAGE_CY; ii++)
                {
                    for (int jj = 0; jj < Const.IMAGE_CX; jj++)
                    {
                        if (!chb_contrast8.Checked)
                        {
                            Color col = Color.FromArgb(image_data[Const.IMAGE_CX * ii + jj], image_data[Const.IMAGE_CX * ii + jj], image_data[Const.IMAGE_CX * ii + jj]);
                            BMP_CMOS.SetPixel(jj, ii, col);
                        }
                        else
                        {
                            if (image_data[Const.IMAGE_CX * ii + jj] > num_porog8.Value)
                            {
                                Color col = Color.White;
                                BMP_CMOS.SetPixel(jj, ii, col);
                            }
                            else
                            {
                                Color col = Color.Black;
                                BMP_CMOS.SetPixel(jj, ii, col);
                            }
                        }
                    }
                }

                // draw LEFT and TOP pixel lines with BLACK COLOR (for MIM Visualizer)
                using (Graphics g = Graphics.FromImage(BMP_CMOS))
                {
                    Pen pen_black = new Pen(Color.Black);
                    g.DrawLine(pen_black, 0, 0, Const.IMAGE_CX, 0);
                    g.DrawLine(pen_black, 0, 0, 0, Const.IMAGE_CY);
                }
                String scrname = dttostr2();
                //if (select_CMOS == 0)
                //    scrname += "_CMOS1";
                //else
                //    scrname += "_CMOS2";
                Byte[] imda = new Byte[image_size];
                for (int i = 0; i < image_size; i++)
                {
                    imda[i] = image_data[i];
                }
                if ((msg.id >> 5) == 0x31)
                {
                    BMP_CMOS.Save(m_strPathToScreens + scrname + "_1_tech.bmp", ImageFormat.Bmp);
                    pictbox_81.Image = BMP_CMOS;
                    File.WriteAllBytes(m_strPathToScreens + scrname + "_1_tech.dat", imda);
                }
                else
                {
                    BMP_CMOS.Save(m_strPathToScreens + scrname + "_2_tech.bmp", ImageFormat.Bmp);
                    pictbox_82.Image = BMP_CMOS;
                    File.WriteAllBytes(m_strPathToScreens + scrname + "_2_tech.dat", imda);
                }

                lb_info8.Text = "";
                lb_info8.BackColor = Color.Transparent;
                tim_getdata8.Enabled = true;
                Application.DoEvents();
                Trace.WriteLine("22222 " + uniCAN.VectorSize().ToString());

            }
        }
        private void bt_stop8_Click(object sender, EventArgs e)
        {
            tim_getdata8.Enabled = false;
            bt_start8.Enabled = true;
            bt_stop8.Enabled = false;
            flag_stop8 = false;
        }
        private void rb_data_8bit8_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_data_8bit8.Checked)
            {
                rb_data_8bit8.BackColor = Color.SpringGreen;
            }
            else
            {
                rb_data_8bit8.BackColor = Color.Transparent;
            }
        }
        private void rb_data_6bit8_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_data_6bit8.Checked)
            {
                rb_data_6bit8.BackColor = Color.SpringGreen;
            }
            else
            {
                rb_data_6bit8.BackColor = Color.Transparent;
            }
        }
        private void tim_getdata8_Tick(object sender, EventArgs e)
        {
        }
        private void bt_About8_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }
        #endregion

        #region Техно Передача
        private void bt_OpenCAN9_Click(object sender, EventArgs e)
        {

/*
            if (cb_CAN9.SelectedItem.ToString() == "No CAN" || cb_CAN9.Items.Count < 1)
                return;
            if (cb_CAN9.SelectedItem.ToString() == "USB Marathon")
            {
                marCAN = new MCANConverter();
                uniCAN = marCAN as MCANConverter;
            }
            else if (cb_CAN9.SelectedItem.ToString() == "PCI Advantech")
            {
                advCAN = new ACANConverter();
                uniCAN = advCAN as ACANConverter;
            }
            else
            {
                elcCAN = new ECANConverter();
                uniCAN = elcCAN as ECANConverter;
            }
 */
            switch (cb_CAN9.SelectedItem.ToString())
            {
                case "No CAN":
                    return;
                case "USB Marathon":
                    marCAN = new MCANConverter();
                    uniCAN = marCAN as MCANConverter;
                    break;
                case "PCI Advantech":
                    advCAN = new ACANConverter();
                    uniCAN = advCAN as ACANConverter;
                    break;
                case "PCI Elcus":
                    elcCAN = new ECANConverter();
                    uniCAN = elcCAN as ECANConverter;
                    break;
                case "Fake CAN driver":
                    fakeCAN = new FCANConverter();
                    uniCAN = fakeCAN as FCANConverter;
                    break;
                default:
                    return;
            }
            uniCAN.ErrEvent += new MyDelegate(Err_Handler);
//            uniCAN.Progress += new MyDelegate(Progress9_Handler);

            uniCAN.Port = 0;
            uniCAN.Speed = 2;
            lb_error_CAN9.Visible = false;
            if (!uniCAN.Open())
            {
                state_Error();
                return;
            }
            state_Ready();
            frame.data = new Byte[8];
            _state = State.OpenedState;
            uniCAN.Recv_Enable();
        }
        private void bt_CloseCAN9_Click(object sender, EventArgs e)
        {
            if (uniCAN.Is_Open)
            {
                uniCAN.Recv_Disable();
                uniCAN.Close();
            }
            state_NotReady();
            lb_error_CAN9.Visible = false;
            uniCAN.Recv_Disable();
            uniCAN = null;
        }
        private void bt_loadbmp9_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openbmp = new OpenFileDialog())
            {
                openbmp.Filter = "BMP файлы (*.bmp)|*.bmp";
                if (openbmp.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                bm91 = new  Bitmap(openbmp.FileName);
                pictbox_91.Image = bm91;
                label60.Text = System.IO.Path.GetFileName(openbmp.FileName);
            }
        }
        private void bt_loadbmp92_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openbmp = new OpenFileDialog())
            {
                openbmp.Filter = "BMP файлы (*.bmp)|*.bmp";
                if (openbmp.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                bm92 = new Bitmap(openbmp.FileName);
                pictbox_92.Image = bm92;
                label66.Text = System.IO.Path.GetFileName(openbmp.FileName);
            }
        }
        private void bt_sendbmp9_Click(object sender, EventArgs e)
        {
            if(label60.Text == "")
                pictbox_91.Image = Properties.Resources.test_tech as Bitmap;
            else
                pictbox_91.Image = bm91;
            if (label66.Text == "")
                pictbox_92.Image = Properties.Resources.test_tech2 as Bitmap;
            else
                pictbox_92.Image = bm92;
       
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg_t mm = new msg_t();
            if (rb_olo_r9.Checked)
            {
                mm.deviceID = Const.OLO_Right;
            }
            else
            {
                mm.deviceID = Const.OLO_Left;
            }

            Byte numpic = (Byte)(chb_1pict9.Checked? 1 : 2);

            for (Byte k = 1; k <= numpic; k++)
            {
                mm.messageLen = 0;
                mm.messageID = (Byte)(0x30 + k);

                switch (mm.deviceID)
                {
                    case Const.OLO_Left:
                        lb_info9.Text = "ОЛО левый. Передача картинки " + k.ToString();
                        lb_info9.BackColor = Color.SpringGreen;
                        break;
                    case Const.OLO_Right:
                        lb_info9.Text = "ОЛО правый. Передача картинки " + k.ToString();
                        lb_info9.BackColor = Color.SpringGreen;
                        break;
                }
                lb_info9.Refresh();
                Application.DoEvents();
                msg = mm.ToCAN(mm);

                if (uniCAN == null || !uniCAN.Send(ref msg, 1000))
                {
                    state_Error();
                    Application.DoEvents();
                    return;
                }
                UInt32 image_size = Const.IMAGE_CX * Const.IMAGE_CY * sizeof(Byte);
                UInt32 image_data_count = 0;
                if (chb_8byte9.Checked)
                {
                    const Byte CAN_MAX_DATA_SIZE = 8;
                    int msg_count = (int)(image_size + CAN_MAX_DATA_SIZE - 1) / CAN_MAX_DATA_SIZE;
                    Byte last_msg_size = (Byte)(image_size % CAN_MAX_DATA_SIZE > 0 ? image_size % CAN_MAX_DATA_SIZE : CAN_MAX_DATA_SIZE);
                    image_data = new Byte[msg_count * 8];
                    pb_loadbmp9.Maximum = msg_count;
                    Bitmap tmp = (k == 1 ? pictbox_91.Image as Bitmap : pictbox_92.Image as Bitmap);

                    for (int ii = 0; ii < Const.IMAGE_CY; ii++)
                    {
                        for (int jj = 0; jj < Const.IMAGE_CX; jj++)
                        {
                            Color col = tmp.GetPixel(jj, ii);
                            image_data[Const.IMAGE_CX * ii + jj] = col.R;
                        }
                    }
                    UInt32 a = 0;
                    for (int i = 0; i < msg_count; i++)
                    {
                        msg.id = (UInt16)(((0x30 + numpic) << 5) | mm.deviceID);
                        msg.len = (i == msg_count - 1 ? last_msg_size : CAN_MAX_DATA_SIZE);

			            for(int j = 0; j < msg.len; j++)
				            msg.data[j] = image_data[a++];

                        if (uniCAN == null || !uniCAN.Send(ref msg, 1000))
                        {
                            state_Error();
                            return;
                        }
                        pb_loadbmp9.Value = i;
                        pb_loadbmp9.Refresh();
                        Application.DoEvents();
                    }
                }
                else
                {
                    const Byte CAN_MAX_DATA_SIZE = 6;
                    int msg_count = (int)(image_size + CAN_MAX_DATA_SIZE - 1) / CAN_MAX_DATA_SIZE;
                    Byte last_msg_size = (Byte)(image_size % CAN_MAX_DATA_SIZE > 0 ? image_size % CAN_MAX_DATA_SIZE : CAN_MAX_DATA_SIZE);
                    image_data = new Byte[msg_count * 8];
                    pb_loadbmp9.Maximum = msg_count;
                    Bitmap tmp = (k == 1 ? pictbox_91.Image as Bitmap : pictbox_92.Image as Bitmap);

                    for (int ii = 0; ii < Const.IMAGE_CY; ii++)
                    {
                        for (int jj = 0; jj < Const.IMAGE_CX; jj++)
                        {
                            Color col = tmp.GetPixel(jj, ii);
                            image_data[Const.IMAGE_CX * ii + jj] = col.R;
                        }
                    }
                    UInt16 a = 0;
                    for (int i = 0; i < msg_count; i++)
                    {
                        msg.id = (UInt16)(((0x30 + numpic) << 5) | mm.deviceID);
                        msg.len = (Byte)(i == msg_count - 1 ? last_msg_size + 2: CAN_MAX_DATA_SIZE + 2);
                        Byte[] tmpa = new Byte[2];
                        tmpa = BitConverter.GetBytes(a);
                        msg.data[0] = tmpa[0];
                        msg.data[1] = tmpa[1];
                        for (int j = 2; j < 8; j++)
                            msg.data[j] = image_data[a++];

                        if (uniCAN == null || !uniCAN.Send(ref msg, 1000))
                        {
                            state_Error();
                            return;
                        }
                        pb_loadbmp9.Value = i;
                        pb_loadbmp9.Refresh();
                        Application.DoEvents();
                    }
                }
            }
            lb_info9.Text = "";
            lb_info9.BackColor = Color.Transparent;
            Application.DoEvents();
        }
        private void rb_olo_r9_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_olo_r9.Checked)
            {
                rb_olo_r9.BackColor = Color.SpringGreen;
            }
            else
            {
                rb_olo_r9.BackColor = Color.Transparent;
            }
        }
        private void rb_olo_l9_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_olo_l9.Checked)
            {
                rb_olo_l9.BackColor = Color.SpringGreen;
            }
            else
            {
                rb_olo_l9.BackColor = Color.Transparent;
            }
        }
        private void bt_About9_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }
        private void chb_6byte9_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_6byte9.Checked)
            {
                chb_6byte9.BackColor = Color.SpringGreen;
                chb_8byte9.CheckState = CheckState.Unchecked;
            }
            else
            {
                chb_6byte9.BackColor = Color.Transparent;
                chb_8byte9.CheckState = CheckState.Checked;
            }
        }
        private void chb_8byte9_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_8byte9.Checked)
            {
                chb_8byte9.BackColor = Color.SpringGreen;
                chb_6byte9.CheckState = CheckState.Unchecked;
            }
            else
            {
                chb_8byte9.BackColor = Color.Transparent;
                chb_6byte9.CheckState = CheckState.Checked;
            }
        }
        private void chb_1pict9_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_1pict9.Checked)
            {
                chb_1pict9.BackColor = Color.SpringGreen;
                chb_2pict9.CheckState = CheckState.Unchecked;
            }
            else
            {
                chb_1pict9.BackColor = Color.Transparent;
                chb_2pict9.CheckState = CheckState.Checked;
            }
        }
        private void chb_2pict9_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_2pict9.Checked)
            {
                chb_2pict9.BackColor = Color.SpringGreen;
                chb_1pict9.CheckState = CheckState.Unchecked;
            }
            else
            {
                chb_2pict9.BackColor = Color.Transparent;
                chb_1pict9.CheckState = CheckState.Checked;
            }
        }
        #endregion

    }
        

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        public static void AppendText(this RichTextBox box, string text, Color bgcolor, Color fgcolor)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = fgcolor;
            box.SelectionBackColor = bgcolor;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.SelectionBackColor = box.BackColor;
        }
    }
    public class autoshoots
    {
        private _u8 id;
        private Int16 az;
        private Int16 um;
        private _u8 freq;
        private Boolean flag_stop;
        private Boolean auto;
        public autoshoots(_u8 id, Int16 azimut, Int16 ugolmesta, _u8 chastota, Boolean rand)
        {
            this.id = id;
            this.az = azimut;
            this.um = ugolmesta;
            this.freq = chastota;
            this.flag_stop = true;
            this.auto = rand;
        }
        public void Stop()
        {
            flag_stop = false;
        }
        private UInt64 ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return (UInt64)Math.Floor(diff.TotalSeconds);
        }
        public void Shoot_L()
        {
            while (Form1.flag_thr_l_shoot)
            {
                msg_t mm = new msg_t();
                mm.deviceID = id;
                mm.messageID = msg_t.mID_DATA;
                mm.messageLen = 8;

                UInt64 dl = (ConvertToUnixTimestamp(DateTime.Now) * 1000 + (UInt32)DateTime.Now.Millisecond) * 100;
                mm.messageData[0] = (Byte)dl;
                mm.messageData[1] = (Byte)(dl >> 8);
                mm.messageData[2] = (Byte)(dl >> 16);
                mm.messageData[3] = (Byte)(dl >> 24);
                mm.messageData[4] = 0xFF;
                mm.messageData[5] = 0x7F;
                mm.messageData[6] = 0xFF;
                mm.messageData[7] = 0x7F;

                canmsg_t mmsg = new canmsg_t();
                mmsg.data = new Byte[8];
                mmsg = mm.ToCAN(mm);
                if (!Form1.uniCAN.Send(ref mmsg, 200))
                    return;

                dl = (ConvertToUnixTimestamp(DateTime.Now) * 1000 + (UInt32)DateTime.Now.Millisecond) * 100;
                mm.messageData[0] = (Byte)dl;
                mm.messageData[1] = (Byte)(dl >> 8);
                mm.messageData[2] = (Byte)(dl >> 16);
                mm.messageData[3] = (Byte)(dl >> 24);

                Random r = new Random();
                if (auto)
                {
                    this.az = (Int16)r.Next(-90 * 60, 90 * 60);
                    this.um = (Int16)r.Next(-90 * 60, 90 * 60);
                }

                mm.messageData[4] = (Byte)this.az;
                mm.messageData[5] = (Byte)(this.az >> 8);
                mm.messageData[6] = (Byte)this.um;
                mm.messageData[7] = (Byte)(this.um >> 8);
                mmsg = new canmsg_t();
                mmsg.data = new Byte[8];
                mmsg = mm.ToCAN(mm);
                if (!Form1.uniCAN.Send(ref mmsg, 200))
                    return;
//                Form1.messages.Add(mm);
                Thread.Sleep(1000 / freq);
            }
            Trace.WriteLine("thr_l_shoot aborted");
        }
        public void Shoot_R()
        {
            while (Form1.flag_thr_r_shoot)
            {
                msg_t mm = new msg_t();
                mm.deviceID = id;
                mm.messageID = msg_t.mID_DATA;
                mm.messageLen = 8;

                UInt64 dl = (ConvertToUnixTimestamp(DateTime.Now) * 1000 + (UInt32)DateTime.Now.Millisecond) * 100;
                mm.messageData[0] = (Byte)dl;
                mm.messageData[1] = (Byte)(dl >> 8);
                mm.messageData[2] = (Byte)(dl >> 16);
                mm.messageData[3] = (Byte)(dl >> 24);
                mm.messageData[4] = 0xFF;
                mm.messageData[5] = 0x7F;
                mm.messageData[6] = 0xFF;
                mm.messageData[7] = 0x7F;

                canmsg_t mmsg = new canmsg_t();
                mmsg.data = new Byte[8];
                mmsg = mm.ToCAN(mm);
                if (!Form1.uniCAN.Send(ref mmsg, 200))
                    return;

                dl = (ConvertToUnixTimestamp(DateTime.Now) * 1000 + (UInt32)DateTime.Now.Millisecond) * 100;
                mm.messageData[0] = (Byte)dl;
                mm.messageData[1] = (Byte)(dl >> 8);
                mm.messageData[2] = (Byte)(dl >> 16);
                mm.messageData[3] = (Byte)(dl >> 24);

                Random r = new Random();
                if (auto)
                {
                    this.az = (Int16)r.Next(-90 * 60, 90 * 60);
                    this.um = (Int16)r.Next(-90 * 60, 90 * 60);
                }

                mm.messageData[4] = (Byte)this.az;
                mm.messageData[5] = (Byte)(this.az >> 8);
                mm.messageData[6] = (Byte)this.um;
                mm.messageData[7] = (Byte)(this.um >> 8);
                mmsg = new canmsg_t();
                mmsg.data = new Byte[8];
                mmsg = mm.ToCAN(mm);
                if (!Form1.uniCAN.Send(ref mmsg, 200))
                    return;
//                Form1.messages.Add(mm);
                Thread.Sleep(1000 / freq);
            }
            Trace.WriteLine("thr_r_shoot aborted");
        }
    }
}

