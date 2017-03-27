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
        #region Переменные
        
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
        Boolean calibration_ended = false;

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

        MCANConverter marCAN = null;
        ACANConverter advCAN = null;
        ECANConverter elcCAN = null;

        IUCANConverter uniCAN = null;

        List<String> list_badpix_TXT = new List<string>();
        List<String> list_badpixCal = new List<string>();
        List<FIFO_ITEM> list_badpix_FIFO = new List<FIFO_ITEM>();
        int num_bad_points = 0;

        String m_strPathToPassports = Path.GetDirectoryName(Application.ExecutablePath) + "\\passports\\";
        String m_strPathToConfigs = Path.GetDirectoryName(Application.ExecutablePath) + "\\configs\\";
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
        ComboBox[] cb_CAN = new ComboBox[5];
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
        List<msg_t> messages = new List<msg_t>();


        static bool generator_running = false;
        static bool cycle_test_D21_running = false;
        static bool cycle_test_D13_running = false;
        static bool cycle_test_D19_running = false;
        public uint ver = 0;
        public Bitmap image_CMOS14 = null;
        public Bitmap image_CMOS24 = null;

        bool mousetest = false;

        TM.Timer rstTimer3 = new TM.Timer();

        UInt16 count_l = 0, count_r = 0;

        #endregion

        #region Tab3
        SaveFileDialog savelog = new SaveFileDialog();
        StreamWriter logwr;
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
        }
        private void Form1_Load(object sender, EventArgs e)
        {
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

            state_Error();
            
            if (!Directory.Exists(m_strPathToPassports))
                Directory.CreateDirectory(m_strPathToPassports);
            if (!Directory.Exists(m_strPathToConfigs))
                Directory.CreateDirectory(m_strPathToConfigs);
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
            //try
            //{
            //    mar2CAN = new M2CANConverter();
            //    if (mar2CAN.Is_Present)
            //    {
            //        comboBox1.Items.Add("USB Marathon2");
            //        mar2CAN.Close();
            //    }
            //}
            //catch (Exception)
            //{
            //}
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


            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.Add("No CAN");
                comboBox1.SelectedIndex = 0;
                lb_error_CAN.Text = "CAN-контроллеры не найдены!";
                for (int k = 1; k < 5; k++)
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
            for (int k = 1; k < 5; k++)
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
            uniCAN.Close();
            uniCAN = null;
            lb_error_CAN4.Text = e.Text;
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
                pb_CMOS.Value = e.Val;
            if (pb_CMOS1.Maximum > e.Val)
                pb_CMOS1.Value = e.Val;
            if (pb_CMOS2.Maximum > e.Val)
                pb_CMOS2.Value = e.Val;
            //MyProgressBar mpb_cmos = new MyProgressBar();
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
            comboBox3.Enabled = false;
            comboBox2.Enabled = false;
            bt_About3.Enabled = false;
            bt_SyncTime.Enabled = false;
            bt_Request2.Enabled = false;
            dgview2.Enabled = false;
            panel1.Enabled = false;
            btn_REQTIME.Enabled = false;
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

            // Tab3
            bt_CloseCAN3.Enabled = false;
            bt_OpenCAN3.Enabled = true;
            lb_noerr3.Visible = false;
            bt_About3.Enabled = true;
            bt_Exit3.Enabled = true;
            dgview3.Enabled = false;
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
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
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
            comboBox3.Enabled = true;
            comboBox2.Enabled = true;
            bt_About3.Enabled = true;
            bt_SyncTime.Enabled = true;
            label17.Enabled = true;
            cb_CAN2.Enabled = true;
            bt_Request2.Enabled = true;
            dgview2.Enabled = true;
            panel1.Enabled = true;
            btn_REQTIME.Enabled = true;
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


            // Tab3
            bt_CloseCAN3.Enabled = true;
            bt_OpenCAN3.Enabled = false;

            lb_noerr3.Visible = true;
            lb_noerr3.Text = uniCAN.Info;

            bt_About3.Enabled = true;
            bt_Exit3.Enabled = true;

            //label1.Enabled = true;
            //comboBox3.Enabled = true;
            //comboBox2.Enabled = true;
            //button5.Enabled = true;
            //bt_SyncTime.Enabled = true;
            //label2.Enabled = true;
            cb_CAN3.Enabled = true;
            dgview3.Enabled = true;
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
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
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
            comboBox3.Enabled = false;
            comboBox2.Enabled = false;
            bt_SyncTime.Enabled = false;
            cb_CAN2.Enabled = true;
            bt_Request2.Enabled = false;
            dgview2.Enabled = false;
            panel1.Enabled = false;
            btn_REQTIME.Enabled = false;
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
            dgview3.Enabled = false;
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
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                        bt_CloseCAN2.PerformClick();
                        bt_CloseCAN3.PerformClick();
                        bt_CloseCAN4.PerformClick();
                        break;
                case 1:
                        bt_CloseCAN.PerformClick();
                        bt_CloseCAN2.PerformClick();
                        bt_CloseCAN3.PerformClick();
                        bt_CloseCAN4.PerformClick();
                        break;
                case 2:
                        bt_CloseCAN.PerformClick();
                        bt_CloseCAN3.PerformClick();
                        bt_CloseCAN4.PerformClick();
                        state_NotReady();
                        dgview2.Rows.Clear();
                        comboBox2.SelectedIndex = 0;
                        comboBox3.SelectedIndex = 0;
                        break;
                case 3:
                        bt_CloseCAN.PerformClick();
                        bt_CloseCAN2.PerformClick();
                        bt_CloseCAN4.PerformClick();
                        break;
                case 4:
                        bt_CloseCAN.PerformClick();
                        bt_CloseCAN2.PerformClick();
                        bt_CloseCAN3.PerformClick();
                        break;
                default:
                        break;
            }
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
                if (!uniCAN.Send(ref msg, 1000))
                    return false;
                Byte[] arr = new Byte[8];
                do
                {
                    uniCAN.Recv(ref msg, 2000);
                } while (msg.data[0] != 0x55);
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
            RESULT res = new RESULT();
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
            RESULT rr = new RESULT();
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

            if(!SendCommand(cmd, ref res))
                return;
            Trace.WriteLine("Установка симуляции выстрелов");
            //if (_state != State.VideoState)
            //    return;

            // Читаем температуру CMOS1
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS1_GET_TEMPERATURE;

            if (!SendCommand(cmd, ref res))
                return;
            Trace.WriteLine("Читаем температуру CMOS1");
            //if (_state != State.VideoState)
            //    return;

            Single fT1 = ((short)res.prm.words.lo_word.word) / (Single)10.0;
            lb_T1_val.Text = fT1.ToString("'+'0.0'°';'-'0.0'°';'0.0°'");

            // Читаем температуру CMOS2
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS2_GET_TEMPERATURE;

            if (!SendCommand(cmd, ref res))
                return;
            Trace.WriteLine("Читаем температуру CMOS2");
            //if (_state != State.VideoState)
            //    return;

            Single fT2 = ((short)res.prm.words.lo_word.word) / (Single)10.0;
            lb_T2_val.Text = fT2.ToString("'+'0.0'°';'-'0.0'°';'0.0°'");

            UInt32 shot_pixels = 0;

            // Чтение картинки
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = rb_CMOS1.Checked ? Const.COMMAND_CMOS1_GET_RAW_IMAGE : Const.COMMAND_CMOS2_GET_RAW_IMAGE;
//            Byte[] image_data = new Byte[IMAGE_CX * IMAGE_CY];

            //if (_state != State.VideoState)
            //    return;

            if (SendCommand(cmd, ref res) || res.stat == Const.STATUS_OK)
            {
                Trace.WriteLine("Чтение картинки");
                if (!chb_PFIFO.Checked)
                {
//                    UInt32 image_data_count = 0;
                    UInt32 image_size = Const.IMAGE_CX * Const.IMAGE_CY * sizeof(Byte);
                    int msg_count = (int)(image_size + Const.CAN_MAX_DATA_SIZE - 1) / Const.CAN_MAX_DATA_SIZE;
                    image_data = new Byte[msg_count * 8];

                    canmsg_t dat = new canmsg_t();
                    dat.data = new Byte[8];
                    pb_CMOS.Maximum = msg_count;
                    if (uniCAN == null || !uniCAN.RecvPack(ref image_data, ref msg_count, 10000))
                    {
                        Trace.WriteLine("Err recv image data");
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
                    //if (_state != State.VideoState)
                    //    return;

                // read CMOS FIFO buffer size
                Trace.WriteLine("Чтение кол-ва выстрелов");
                canmsg_t msg = new canmsg_t();
                msg.data = new Byte[8];
                if (uniCAN == null || !uniCAN.Recv(ref msg, 1000))
                {
                    Trace.WriteLine("Error read CMOS FIFO buffer size");
                    return;
                }
                shot_pixels = BitConverter.ToUInt16(msg.data, 0);
                Trace.WriteLine("CMOS FIFO buffer size = " + shot_pixels.ToString());
//                shot_pixels = 0;
                // read CMOS FIFO buffer data if exists
                // получаем массив координат выстрелов
//                if (shot_pixels > 0 && shot_pixels < 10) /////////////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
                if (shot_pixels > 0)
                {
                    UInt32 image_size = shot_pixels * 4;
                    int msg_count = (int)(image_size + Const.CAN_MAX_DATA_SIZE - 1) / Const.CAN_MAX_DATA_SIZE;
                    UInt32 image_data_count = 0;
                    Trace.WriteLine("Чтение выстрелов");
                    if (uniCAN.Info.Contains("Marathon"))
                    {
                        for (UInt32 i = 0; i < msg_count; i++)
                        {
                            canmsg_t dat = new canmsg_t();
                            dat.data = new Byte[8];
                            if (uniCAN == null || !uniCAN.Recv(ref dat, 1000))
                            {
                                Trace.WriteLine("Error read CMOS FIFO buffer data");
                                return;
                            }

                            UInt32 data_size = dat.len;
                            for (UInt32 j = 0; j < data_size; j++)
                                shot_array[j + image_data_count] = dat.data[j];
                            image_data_count += data_size;
                        }
                    }
                    if (uniCAN.Info.Contains("Elcus"))
                    { 
                        if (uniCAN == null || !uniCAN.RecvPack(ref shot_array, ref msg_count, 2000))
                        {
                            Trace.WriteLine("Error read CMOS FIFO buffer data");
                            return;
                        }
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
            }
            //if (_state != State.VideoState)
            //    return;
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

            // рисуем выстрелы фиолетовым !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //foreach (var item in shot_array_list)
            //    image_CMOS.SetPixel(item.x, item.y, Color.Fuchsia);

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
            if (_state == State.StoppingVideoState)
            {
                _state = State.OpenedState;
                VideoTimer.Enabled = false;
                return;
            }
            VideoTimer.Enabled = true;
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
        private void listb_Passport_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                mousetest = true;
        }
        private void listb_Passport_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                mousetest = false;
                if (MessageBox.Show("Удалить " + m_strPathToPassports + listb_Passport.SelectedItem.ToString() + "?", "Удаление файла", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    File.Delete(m_strPathToPassports + listb_Passport.SelectedItem.ToString());
                    UpdatePassportList();
                }
            }
        }

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
            bt_loadMC1.Text = "Загрузка..." + " 0%";
//            lb_progress1.Text = "0%";
            gb_CAN1.Enabled = false;
            gb_MC1.Enabled = false;

            _u8 crc8 = 0;
            for (int i = 0; i < size; i++)
                crc8 += Buffer[i];

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
                    bt_loadMC1.Text = "Сброс ОЛО... 2c";
                    bt_loadMC1.Refresh();
                    Thread.Sleep(1000);
                    bt_loadMC1.Text = "Сброс ОЛО... 1c";
                    bt_loadMC1.Refresh();
                    Thread.Sleep(1000);
                }
                else
                    chb1_need_reset.Checked = false;
            }
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

                        if (uniCAN == null || !uniCAN.Recv(ref frame, 200))
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

                //////////////////////////////////
/*
                frame.id = CAN_MSG_ID_PC2MC;
                frame.len = 8;
                for (_u8 ii = 0; ii < 8; ii++)
                    frame.data[ii] = ii;
                if (!uniCAN.Send(ref frame, 200))
                    return;
                Trace.WriteLine("Send pack ID=0x" + frame.id.ToString("X2"));
                print_msg(frame);
 */
                //////////////////////////////////
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

            //String sss = "";
            //for (int i = 0; i < 8; i++)
            //	sss += i.ToString() + " - " + Convert.ToString(frame.data[i], 2) + " - " + Convert.ToString(frame.data[i], 16) + "\r\n";
            //MessageBox.Show(sss);

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
            try
            {
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
                timer_Error_Boot.Enabled = true;
                uniCAN.Recv_Enable();
                lb_noerr1.Text = uniCAN.Info;
                uniCAN.Recv_Enable();
                frame.data = new Byte[8];
                ClearData();

                pb_loadMC1.Visible = true;

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
            finally
            {
                uniCAN.Recv_Disable();
                uniCAN.Close();
            }
        }
        #endregion
        #region Обработка радиобатонов
        private void rb_cmos12_select_long_time_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_cmos12_select_long_time.Checked)
            {
                rb_cmos12_select_long_time.BackColor = SystemColors.ActiveCaption;
                //size = (UInt32)Properties.Resources.firmware_solo2_cmos12_select_long_time.Length;
                //var assembly = Assembly.GetExecutingAssembly();
                //var firmware = "OLO_CAN.Resources.firmware_solo2_cmos12_select_long_time.bin";
                //Buffer = new _u8[size];
                //Stream stream = assembly.GetManifestResourceStream(firmware);
                //using (BinaryReader reader = new BinaryReader(stream))
                //{
                //    reader.Read(Buffer, 0, (int)stream.Length);
                //}
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
//                size = (UInt32)Properties.Resources.SOLO2_SELECT_31082016_01.Length;
////                size = (UInt32)Properties.Resources.firmware_solo2_cmos12_select.Length;
//                var assembly = Assembly.GetExecutingAssembly();
////                var firmware = "OLO_CAN.Resources.firmware_solo2_cmos12_select.bin";
//                var firmware = "OLO_CAN.Resources.SOLO2_SELECT_31082016_01.bin";
//                Buffer = new _u8[size];
//                Stream stream = assembly.GetManifestResourceStream(firmware);
//                using (BinaryReader reader = new BinaryReader(stream))
//                {
//                    reader.Read(Buffer, 0, (int)stream.Length);
//                }
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
                //size = (UInt32)Properties.Resources.firmware_solo2_flight_left_wing_double_pass.Length;
                //var assembly = Assembly.GetExecutingAssembly();
                //var firmware = "OLO_CAN.Resources.firmware_solo2_flight_left_wing_double_pass.bin";
                //Buffer = new _u8[size];
                //Stream stream = assembly.GetManifestResourceStream(firmware);
                //using (BinaryReader reader = new BinaryReader(stream))
                //{
                //    reader.Read(Buffer, 0, (int)stream.Length);
                //}
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
                //size = (UInt32)Properties.Resources.firmware_solo2_flight_right_wing_double_pass.Length;
                //var assembly = Assembly.GetExecutingAssembly();
                //var firmware = "OLO_CAN.Resources.firmware_solo2_flight_right_wing_double_pass.bin";
                //Buffer = new _u8[size];
                //Stream stream = assembly.GetManifestResourceStream(firmware);
                //using (BinaryReader reader = new BinaryReader(stream))
                //{
                //    reader.Read(Buffer, 0, (int)stream.Length);
                //}
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
        private void rb_cmos12_select_lg_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_cmos12_select_lg.Checked)
            {
                rb_cmos12_select_lg.BackColor = SystemColors.ActiveCaption;
                Buffer = new _u8[FWDATA.SOLO2_SELECT_LOWGAIN_size];
                Buffer = (_u8[])FWDATA.SOLO2_SELECT_LOWGAIN;
                size = (uint)Buffer.Length;
                bt_loadMC1.Enabled = true;
                chb_eraseALL1.Enabled = true;
            }
            else
            {
                rb_cmos12_select_lg.BackColor = Color.Transparent;
            }
        }
        private void rb_flight_right_wing_double_pass_lg_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_flight_right_wing_double_pass_lg.Checked)
            {
                rb_flight_right_wing_double_pass_lg.BackColor = SystemColors.ActiveCaption;
                Buffer = new _u8[FWDATA.SOLO2_FLIGHT_RIGHT_LOWGAIN_size];
                Buffer = (_u8[])FWDATA.SOLO2_FLIGHT_RIGHT_LOWGAIN;
                size = (uint)Buffer.Length;
                bt_loadMC1.Enabled = true;
                chb_eraseALL1.Enabled = true;
            }
            else
            {
                rb_flight_right_wing_double_pass_lg.BackColor = Color.Transparent;
            }
        }
        private void rb_flight_left_wing_double_pass_lg_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_flight_left_wing_double_pass_lg.Checked)
            {
                rb_flight_left_wing_double_pass_lg.BackColor = SystemColors.ActiveCaption;
                Buffer = new _u8[FWDATA.SOLO2_FLIGHT_LEFT_LOWGAIN_size];
                Buffer = (_u8[])FWDATA.SOLO2_FLIGHT_LEFT_LOWGAIN;
                size = (uint)Buffer.Length;
                bt_loadMC1.Enabled = true;
                chb_eraseALL1.Enabled = true;
            }
            else
            {
                rb_flight_left_wing_double_pass_lg.BackColor = Color.Transparent;
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
            if (cb_CAN2.SelectedItem.ToString() == "No CAN" || cb_CAN2.Items.Count < 1)
                return;
            if (cb_CAN2.SelectedItem.ToString() == "USB Marathon")
            {
                marCAN = new MCANConverter();
                uniCAN = marCAN as MCANConverter;
            }
            else if (cb_CAN2.SelectedItem.ToString() == "PCI Advantech")
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
//            Trace.Write("Recv... ");
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg_t mm = new msg_t();
            int az = 0, um = 0;
            while (uniCAN.VectorSize() > 0)
            {
                uniCAN.Recv(ref msg, 100);
                Application.DoEvents();
                mm = mm.FromCAN(msg);
                messages.Add(mm);
            }
//            Trace.WriteLine("OK");
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

                String mss = "", devname = "";
                switch (messages[i].deviceID)
                {
                    case Const.OLO_Left:
                        strelka_s = "ОЛО левый";
//                        strelka = strelka_LB;
                        break;
                    case Const.OLO_Right:
                        strelka_s = "ОЛО правый";
//                        strelka = strelka_LG;
                        break;
                    case Const.OLO_All:
                        strelka_s = "Всем ОЛО";
                        break;
                    default:
                        strelka_s = "Всем ОЛО";
                        break;
                }
                //if (messages[i].deviceID == Const.OLO_Left)
                //    strelka_s = "ОЛО левый";
                //else
                //    strelka_s = "ОЛО правый";
                switch (messages[i].messageID)
                {
                    case msg_t.mID_DATA:
                        az = BitConverter.ToInt16(messages[i].messageData, 4);
                        um = BitConverter.ToInt16(messages[i].messageData, 6);
                        //az = BitConverter.ToUInt16(messages[i].messageData, 4);
                        //um = BitConverter.ToUInt16(messages[i].messageData, 6);
                        if (az >= 0)
                            mss = "Азимут = " + (az / 60).ToString("0'°'") + (az % 60).ToString() + "' ";
                        else
                            mss = "Азимут = -" + (Math.Abs(az) / 60).ToString("0'°'") + (Math.Abs(az) % 60).ToString() + "' ";
                        if(um >= 0)
                              mss += "Угол = " + (um / 60).ToString("0'°'") + (um % 60).ToString() + "'";
                        else
                              mss += "Угол = -" + (Math.Abs(um) / 60).ToString("0'°'") + (Math.Abs(um) % 60).ToString() + "'";

                        if ((BitConverter.ToInt16(messages[i].messageData, 4) != 0x7FFF && BitConverter.ToInt16(messages[i].messageData, 6) != 0x7FFF) || !chb3_7fff.Checked)
                        {
                            Shots sh = new Shots();
                            sh.bort = (messages[i].deviceID == Const.OLO_Left) ? (Byte)0 : (Byte)1;
                            sh.azimut = BitConverter.ToInt16(messages[i].messageData, 4);
                            sh.ugol = BitConverter.ToInt16(messages[i].messageData, 6);
                            list_shots.Add(sh);
                        }
                        //if ((((az <= 10800) && (az >= 0)) || !chb3_az.Checked) && ((um <= 10800) && (um >= 0)) || !chb3_um.Checked)
                        //{
                        //    Shots sh = new Shots();
                        //    sh.bort = (messages[i].deviceID == Const.OLO_Left) ? (Byte)0 : (Byte)1;
                        //    sh.azimut = BitConverter.ToUInt16(messages[i].messageData, 4);
                        //    sh.ugol = BitConverter.ToUInt16(messages[i].messageData, 6);
                        //    list_shots.Add(sh);
                        //}
                        //label3.Text = list_shots.Count.ToString();
                        
                        if (timer_Reset_Shots.Enabled == false)
                        {
                            timer_Reset_Shots.Interval = (int)numericUpDown1.Value * 1000;
                            timer_Reset_Shots.Enabled = true;
                            panel1.Refresh();
                        }
                        else
                        {
                            timer_Reset_Shots.Enabled = false;
                            timer_Reset_Shots.Interval = (int)numericUpDown1.Value * 1000;
                            timer_Reset_Shots.Enabled = true;
                            panel1.Refresh();
                        }
                        strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_LB : strelka_LG;
                        break;

                    case msg_t.mID_STATUS:
                        mss = "T1=" + ((SByte)messages[i].messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                            "T2=" + ((SByte)messages[i].messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'") + " " +
                            "T3=" + ((SByte)messages[i].messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                        if (messages[i].deviceID == Const.OLO_Left)
                        {
                            switch (messages[i].messageData[0] & 3)
                            {
                                case 0:
                                    lb_statusL_mode2.Text = "OPERATIONAL";
                                    break;
                                case 1:
                                    lb_statusL_mode2.Text = "SELFTEST";
                                    break;
                                case 2:
                                    lb_statusL_mode2.Text = "EMBEDCONTROL";
                                    break;
                                case 3:
                                    lb_statusL_mode2.Text = "PROGRAMMING";
                                    break;
                                default:
                                    lb_statusL_mode2.Text = "OPERATIONAL";
                                    break;
                            }
                            switch ((messages[i].messageData[0] >> 2) & 3)
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
                            lb_statusL_status2.Text = (((messages[i].messageData[0] >> 4) & 1) == 1) ? "STATUS OK" : "STATUS BAD";
                            lb_statusL_plis2.Text = (messages[i].messageData[2] & 1) == 1 ? "PLIS OK" : "PLIS BAD";
                            lb_statusL_file2.Text = ((messages[i].messageData[2] >> 1) & 1) == 1 ? "FILE OK" : "FILE BAD";
                            lb_statusL_t12.Text = ((SByte)messages[i].messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                            lb_statusL_t22.Text = ((SByte)messages[i].messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                            lb_statusL_t32.Text = ((SByte)messages[i].messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                        }
                        else
                        {
                            switch (messages[i].messageData[0] & 3)
                            {
                                case 0:
                                    lb_statusR_mode2.Text = "OPERATIONAL";
                                    break;
                                case 1:
                                    lb_statusR_mode2.Text = "SELFTEST";
                                    break;
                                case 2:
                                    lb_statusR_mode2.Text = "EMBEDCONTROL";
                                    break;
                                case 3:
                                    lb_statusR_mode2.Text = "PROGRAMMING";
                                    break;
                                default:
                                    lb_statusR_mode2.Text = "OPERATIONAL";
                                    break;
                            }
                            switch ((messages[i].messageData[0] >> 2) & 3)
                            {
                                case 0:
                                    label50.Text = "BY REQUEST";
                                    break;
                                case 1:
                                    label50.Text = "BY TIMER";
                                    break;
                                case 2:
                                    label50.Text = "BY STATE";
                                    break;
                                default:
                                    label50.Text = "BY REQUEST";
                                    break;
                            }
                            lb_statusR_status2.Text = (((messages[i].messageData[0] >> 4) & 1) == 1) ? "STATUS OK" : "STATUS BAD";
                            lb_statusR_plis2.Text = (messages[i].messageData[2] & 1) == 1 ? "PLIS OK" : "PLIS BAD";
                            lb_statusR_file2.Text = ((messages[i].messageData[2] >> 1) & 1) == 1 ? "FILE OK" : "FILE BAD";
                            lb_statusR_t12.Text = ((SByte)messages[i].messageData[3]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                            lb_statusR_t22.Text = ((SByte)messages[i].messageData[4]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                            lb_statusR_t32.Text = ((SByte)messages[i].messageData[5]).ToString(" '+'0.0'°'; '-'0.0'°'; '0.0°'");
                        }
                        if (messages[i].deviceID != 0)
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_LB : strelka_LG;
                        else
                            strelka = strelka_L;
                        break;

                    case msg_t.mID_REQTIME:
                        mss = "Запрос времени" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                        if (messages[i].deviceID != 0)
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                        else
                            strelka = strelka_R;
                        break;

                    case msg_t.mID_GETTIME:
                        DateTime dt = ConvertFromUnixTimestamp(BitConverter.ToUInt64(messages[i].messageData, 0));
                        mss = "Время" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П") + " " + dt.ToShortDateString() + " " + dt.ToLongTimeString();
                        if (messages[i].deviceID != 0)
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_LB : strelka_LG;
                        else
                            strelka = strelka_L;
                        break;

                    case msg_t.mID_STATREQ:
                        if (messages[i].deviceID != 0)
                        {
                            mss = "Запрос статуса" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                        }
                        else
                        {
                            mss = "Запрос статуса всех ОЛО";
                            strelka = strelka_R;
                        }
                        break;

                    case msg_t.mID_MODULE:
                        if (messages[i].deviceID != 0)
                        {
                            mss = "Режим модуля"; // +((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                            switch (messages[i].messageData[0])
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
                            strelka = strelka_R;
                        }
                        break;

                    case msg_t.mID_REQVER:
                        if (messages[i].deviceID != 0)
                        {
                            mss = "Запрос версии ПО" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                        }
                        else
                        {
                            mss = "Запрос версии ПО всех ОЛО";
                            strelka = strelka_R;
                        }
                        break;

                    case msg_t.mID_GETVER:
                        mss = Convert.ToChar(messages[i].messageData[0]) + "" + Convert.ToChar(messages[i].messageData[1]);
                        mss += " " + (Convert.ToChar(messages[i].messageData[2]) == 'L' ? "Левый борт" : "Правый борт");
                        mss += " " + (messages[i].messageData[6] < 10 ? "0" + messages[i].messageData[6].ToString() : messages[i].messageData[6].ToString());
                        mss += "." + (messages[i].messageData[5] < 10 ? "0" + messages[i].messageData[5].ToString() : messages[i].messageData[5].ToString());
                        mss += "." + BitConverter.ToUInt16(messages[i].messageData, 3).ToString();
                        mss += " v." + (messages[i].messageData[7] < 10 ? "0" + messages[i].messageData[7].ToString() : messages[i].messageData[7].ToString());                        
                        if (messages[i].deviceID != 0)
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_LB : strelka_LG;
                        else
                            strelka = strelka_L;
                        break;

                    case msg_t.mID_RESET:
                        if (messages[i].deviceID != 0)
                        {
                            mss = "Системный сброс" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                        }
                        else
                        {
                            mss = "Системный сброс всех ОЛО";
                            strelka = strelka_R;
                        }
                        break;

                    case msg_t.mID_SIMRESET:
                        mss = "Сброс эмулятора" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                        if (messages[i].deviceID != 0)
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                        else
                            strelka = strelka_R;
                        break;

                    case msg_t.mID_SYNCTIME:
                        mss = "Синхронизация времени" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                        if (messages[i].deviceID != 0)
                        {
                            mss = "Синхронизация времени" + ((messages[i].deviceID == Const.OLO_Left) ? " ОЛО-Л" : " ОЛО-П");
                            strelka = (messages[i].deviceID == Const.OLO_Left) ? strelka_RB : strelka_RG;
                        }
                        else
                        {
                            mss = "Синхронизация времени всех ОЛО";
                            strelka = strelka_R;
                        }
                        break;
                }
                String rawdata = "";
                for (int j = 0; j < messages[i].messageLen; j++)
                    rawdata += messages[i].messageData[j].ToString("X2") + " ";

                if ((BitConverter.ToInt16(messages[i].messageData, 4) != 0x7FFF && BitConverter.ToInt16(messages[i].messageData, 6) != 0x7FFF) || !chb3_7fff.Checked)
//              if ((((az <= 10800) && (az >= 0)) || !chb3_az.Checked) && ((um <= 10800) && (um >= 0)) || !chb3_um.Checked)
                {
                    if (scroll)
                    {
                        if (dgview2.RowCount >= 100)
                            dgview2.Rows.Clear();
                        dgview2.Rows.Add(strelka, strelka_s, rawdata, mss, DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff"), messages[i].messageID.ToString("X2"));
                        dgview2.FirstDisplayedScrollingRowIndex = dgview2.Rows.Count - 1;
                    }

                    if (chb3_savelog.Checked)
                    {
                        logwr.Write(DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff") + ";");
                        logwr.Write(strelka_s + ";");
                        logwr.Write(rawdata + ";");
                        logwr.Write(mss + ";");
                        logwr.WriteLine(messages[i].messageID.ToString("X2") + ";");
                    }

                    //if (dgview.Rows[dgview.Rows.Count - 1].Cells[1].Value.ToString() == "ОЛО левый" && dgview.Rows[dgview.Rows.Count - 1].Cells[5].Value.ToString() != "2D")
                    //    dgview.Rows[dgview.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                    //if (dgview.Rows[dgview.Rows.Count - 1].Cells[1].Value.ToString() == "ОЛО правый" && dgview.Rows[dgview.Rows.Count - 1].Cells[5].Value.ToString() != "2D")
                    //    dgview.Rows[dgview.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                    if (dgview2.Rows[dgview2.Rows.Count - 1].Cells[5].Value.ToString() == "2D")
                        dgview2.Rows[dgview2.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Orange;
                }
            }
            if (scroll)
                messages.Clear();
        }
        private void timer_Reset_Shots_Tick(object sender, EventArgs e)
        {
            timer_Reset_Shots.Enabled = false;
            timer_Reset_Shots.Interval = (int)numericUpDown1.Value * 1000;
            list_shots.Clear();
            //label3.Text = list_shots.Count.ToString();
            panel1.Refresh();
        }
        static DateTime ConvertFromUnixTimestamp(UInt64 timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
        static UInt64 ConvertToUnixTimestamp(DateTime date)
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
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    OLO_Select = Const.OLO_Left;
                    break;
                case 1:
                    OLO_Select = Const.OLO_Right;
                    break;
                case 2:
                    OLO_Select = Const.OLO_All;
                    break;
                default:
                    OLO_Select = Const.OLO_All;
                    break;
            }
        }
        private void bt_Request2_Click(object sender, EventArgs e)
        {
            int to = 0;
            msg_t mm = new msg_t();
            mm.messageID = msg_t.mID_STATREQ;
            Byte[] tmp = new Byte[4];

            switch (comboBox2.SelectedIndex)
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
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    mm.deviceID = Const.OLO_Left;
                    break;
                case 1:
                    mm.deviceID = Const.OLO_Right;
                    break;
                case 2:
                    mm.deviceID = Const.OLO_All;
                    break;
                default:
                    mm.deviceID = Const.OLO_All;
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
            messages.Add(mm);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
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
        private void btn_REQTIME_Click(object sender, EventArgs e)
        {
            msg_t mm = new msg_t();
            if (comboBox3.SelectedIndex == 0)
                mm.deviceID = Const.OLO_Left;
            else
                mm.deviceID = Const.OLO_Right;
            mm.messageID = msg_t.mID_REQTIME;
            mm.messageLen = 1;
            mm.messageData[0] = 0;
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref msg, 100))
                return;
            messages.Add(mm);
        }
        private void dgview2_Click(object sender, EventArgs e)
        {
            if (!scroll)
            {
                scroll = true;
                chb_dgview2.Text = "Скролл включен";
                dgview2.GridColor = SystemColors.ControlDark;
                chb_dgview2.BackColor = Color.SpringGreen;
            }
            else
            {
                scroll = false;
                chb_dgview2.Text = "Скролл выключен";
                dgview2.GridColor = Color.Blue;
                chb_dgview2.BackColor = Color.OrangeRed;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            scroll = true;
            chb_dgview2.Text = "Скролл включен";
            dgview2.GridColor = SystemColors.ControlDark;
            chb_dgview2.BackColor = Color.SpringGreen;
            messages.Clear();
            dgview2.Rows.Clear();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer_Reset_Shots.Interval = (int)numericUpDown1.Value * 1000;
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            msg_t mm = new msg_t();

            if (comboBox3.SelectedIndex == 0)
                mm.deviceID = Const.OLO_Left;
            else if (comboBox3.SelectedIndex == 1)
                mm.deviceID = Const.OLO_Right;
            else
                mm.deviceID = Const.OLO_All;
            mm.messageID = msg_t.mID_RESET;
            mm.messageLen = 1;
            mm.messageData[0] = 0;
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref msg, 100))
                return;
            messages.Add(mm);
        }
        private void bt_SyncTime_Click(object sender, EventArgs e)
        {
            int to = 0;
            msg_t mm = new msg_t();

            if (comboBox3.SelectedIndex == 0)
                mm.deviceID = Const.OLO_Left;
            else if (comboBox3.SelectedIndex == 1)
                mm.deviceID = Const.OLO_Right;
            else
                mm.deviceID = Const.OLO_All;
            mm.messageID = msg_t.mID_SYNCTIME;
            mm.messageLen = 8;
            mm.messageData = TimestampToArray(ConvertToUnixTimestamp(DateTime.Now));
            //            MessageBox.Show(ConvertToUnixTimestamp(DateTime.Now).ToString());
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref msg, 100))
                return;
            messages.Add(mm);
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
                else if(messages[i].deviceID == Const.OLO_Right)
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
                        if(um >= 0)
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
                if(trackBar3_az.Value >= 0)
                    lb3_shoot_az_val.Text = (trackBar3_az.Value / 60).ToString("0'°'") + (trackBar3_az.Value % 60).ToString() + "' ";
                else
                    lb3_shoot_az_val.Text = "-" + (Math.Abs(trackBar3_az.Value) / 60).ToString("0'°'") + (Math.Abs(trackBar3_az.Value) % 60).ToString() + "' ";
                if(trackBar3_um.Value >= 0)
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

            lb_test_plis.Text += (upload1 > 0) ? "PLIS1 ERR, " : "PLIS1 OK, ";
            lb_test_plis.Text += (upload2 > 0) ? "PLIS2 ERR" : "PLIS2 OK";
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
            label1.Text = "";
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
            label1.Text += frame.data[7].ToString() + "-";
            // Flash format
            if (uniCAN == null || !uniCAN.Recv(ref frame, 10000))
            {
                lb_test_FLASH.Text = "_format ОШИБКА";
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            lb_test_FLASH.Text = (frame.data[0] > 0 ? "format OK" : "format ОШИБКА");
            label1.Text += frame.data[7].ToString() + "-";
            // Flash open
            if (uniCAN == null || !uniCAN.Recv(ref frame, 5000))
            {
                lb_test_FLASH.Text = "_open 1 ОШИБКА";
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            lb_test_FLASH.Text = (frame.data[0] > 0 ? "open 1 OK" : "open 1 ОШИБКА");
            label1.Text += frame.data[7].ToString() + "-";
            // Flash write
            if (uniCAN == null || !uniCAN.Recv(ref frame, 20000))
            {
                lb_test_FLASH.Text = "_write ОШИБКА" + frame.data[1] + " x " + (frame.data[2] + (frame.data[3] << 8)).ToString();
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            label1.Text += frame.data[7].ToString() + "-";
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
            label1.Text += frame.data[7].ToString() + "-";
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
            label1.Text += frame.data[7].ToString() + "-";
            // Flash OK
            if (uniCAN == null || !uniCAN.Recv(ref frame, 5000))
            {
                lb_test_FLASH.Text = "_Flash ОШИБКА";
                timer_temperature.Enabled = true;
                return;
            }
            Application.DoEvents();
            label1.Text += frame.data[7].ToString();
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

        private unsafe void button3_Click(object sender, EventArgs e)
        {
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
        private unsafe void button4_Click(object sender, EventArgs e)
        {
            COMMAND cmd = new COMMAND();
            RESULT res = new RESULT();
            // Установка симуляции выстрелов
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = Const.COMMAND_CMOS_SET_SIMULATION_MODE;
            cmd.prm.words.lo_word.bytes.lo_byte = 1;
            cmd.prm.words.lo_word.bytes.hi_byte = 0;

            if (!SendCommand(cmd, ref res))
                return;
            Trace.WriteLine("Установка симуляции выстрелов");
            UInt32 shot_pixels = 0;

            // Чтение картинки
            cmd.magic = Const.MAGIC_BYTE;
            cmd.cmd = rb_CMOS1.Checked ? Const.COMMAND_CMOS1_GET_RAW_IMAGE : Const.COMMAND_CMOS2_GET_RAW_IMAGE;

            List<canmsg_t> dd = new List<canmsg_t>();

            if (SendCommand(cmd, ref res) || res.stat == Const.STATUS_OK)
            {
                Trace.WriteLine("Чтение картинки");
                UInt32 image_size = Const.IMAGE_CX * Const.IMAGE_CY * sizeof(Byte);
                int msg_count = (int)(image_size + Const.CAN_MAX_DATA_SIZE - 1) / Const.CAN_MAX_DATA_SIZE;
                image_data1 = new Byte[81345];

                canmsg_t dat = new canmsg_t();
                dat.data = new Byte[8];
                //pb_CMOS.Maximum = msg_count;

                //if (uniCAN == null || !uniCAN.RecvPack(ref image_data, ref msg_count, 10000))
                //{
                //    Trace.WriteLine("Err recv image data");
                //    return;
                //}
                int j = 0;
//                for (int i = 0; i < msg_count; i++)
                uniCAN.RecvPack(ref image_data1, ref msg_count, 100);
                //for (int i = 0; i < 100000; i++)
                //{
                //    dat = new canmsg_t();
                //    dat.data = new Byte[8];
                //    if (!uniCAN.Recv(ref dat, 1000))
                //    {
                //        Trace.WriteLine("err recv image data " + dd.Count + " pack");
                //        goto _ddd;
                //    }
                //    dd.Add(dat);
//                    for (int k = 0; k < dat.len; k++)
//                        image_data1[j++] = dat.data[k];
//                }
                Trace.WriteLine("recv image data " + dd.Count + " pack");
//                goto _ddd;
                Trace.WriteLine("recv image data " + msg_count + " pack " + j + " bytes");
                // read CMOS FIFO buffer size
                Trace.WriteLine("Чтение кол-ва выстрелов");
                canmsg_t msg = new canmsg_t();
                msg.data = new Byte[8];
                if (uniCAN == null || !uniCAN.Recv(ref msg, 100))
                {
                    Trace.WriteLine("Error read CMOS FIFO buffer size");
                    return;
                }
                shot_pixels = BitConverter.ToUInt16(msg.data, 0);
                Trace.WriteLine("CMOS FIFO buffer size = " + shot_pixels.ToString());

                // read CMOS FIFO buffer data if exists
                // получаем массив координат выстрелов
                if (shot_pixels > 0)
                {
                    image_size = shot_pixels * 4;
                    msg_count = (int)(image_size + Const.CAN_MAX_DATA_SIZE - 1) / Const.CAN_MAX_DATA_SIZE;
                    UInt32 image_data_count = 0;
                    Trace.WriteLine("Чтение выстрелов");
                    j = 0;
                    for (UInt32 i = 0; i < msg_count; i++)
                    {
                        dat = new canmsg_t();
                        dat.data = new Byte[8];
                        if (uniCAN == null || !uniCAN.Recv(ref dat, 100))
                        {
                            Trace.WriteLine("Error read CMOS FIFO buffer data");
                            return;
                        }
                        for (int k = 0; k < dat.len; k++)
                            shot_array[j++] = dat.data[k];
                    }
                    Trace.WriteLine("recv FIFO data " + msg_count + " pack " + j + " bytes");
                }
            }
            _ddd:
            using (StreamWriter sw = new StreamWriter("test.csv"))
            {
                for (int l = 0; l < dd.Count; l++)
                {
                    for (int m = 0; m < dd[l].len; m++)
                    {
                        sw.Write(dd[l].data[m] + ";");
                    }
                    sw.WriteLine();
                }
            }
        }

        private void rb1_addr_left_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void REQ_VER_Click(object sender, EventArgs e)
        {
            msg_t mm = new msg_t();
            switch (comboBox3.SelectedIndex)
        	{
                case 0:
                    mm.deviceID = Const.OLO_Left;
                    break;
                case 1:
                    mm.deviceID = Const.OLO_Right;
                    break;
                case 2:
                    mm.deviceID = Const.OLO_All;
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
            int to = 0;
            msg_t mm = new msg_t();
            mm.messageID = msg_t.mID_MODULE;
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
                    break;
                case 3: // режим программирования
                    mm.messageData[0] = 3;
                    break;
            }
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    mm.deviceID = Const.OLO_Left;
                    break;
                case 1:
                    mm.deviceID = Const.OLO_Right;
                    break;
                case 2:
                    mm.deviceID = Const.OLO_All;
                    break;
                default:
                    mm.deviceID = Const.OLO_All;
                    break;
            }
//            tmp = BitConverter.GetBytes(to);
//            Array.Copy(tmp, mm.messageData, 4);
            mm.messageLen = 1;
            canmsg_t msg = new canmsg_t();
            msg.data = new Byte[8];
            msg = mm.ToCAN(mm);
            if (!uniCAN.Send(ref msg, 100))
                return;
            messages.Add(mm);
        }
    }
}
