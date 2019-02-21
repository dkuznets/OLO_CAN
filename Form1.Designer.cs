namespace OLO_CAN
{
	partial class Form1
	{
		/// <summary>
		/// Требуется переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.VideoTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chb0_srfon = new System.Windows.Forms.CheckBox();
            this.cb_shotshow = new System.Windows.Forms.CheckBox();
            this.chb0_screen = new System.Windows.Forms.CheckBox();
            this.bt_SAVESN1 = new System.Windows.Forms.Button();
            this.bt_REQSN1 = new System.Windows.Forms.Button();
            this.tb_SN1 = new System.Windows.Forms.TextBox();
            this.gbox_Temperature = new System.Windows.Forms.GroupBox();
            this.lb_T1 = new System.Windows.Forms.Label();
            this.lb_T2 = new System.Windows.Forms.Label();
            this.lb_T2_val = new System.Windows.Forms.Label();
            this.lb_T1_val = new System.Windows.Forms.Label();
            this.gbox_Cross = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chb_oldlens = new System.Windows.Forms.CheckBox();
            this.rb_RightW = new System.Windows.Forms.RadioButton();
            this.rb_LeftW = new System.Windows.Forms.RadioButton();
            this.bt_SaveConf = new System.Windows.Forms.Button();
            this.chb_CCirkle = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.num_CCirkle = new System.Windows.Forms.NumericUpDown();
            this.num_CAngle = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.num_CY = new System.Windows.Forms.NumericUpDown();
            this.num_CX = new System.Windows.Forms.NumericUpDown();
            this.chb_EnableCross = new System.Windows.Forms.CheckBox();
            this.bt_About = new System.Windows.Forms.Button();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.gbox_Process = new System.Windows.Forms.GroupBox();
            this.chb_PHidebadpix = new System.Windows.Forms.CheckBox();
            this.chb_PFIFO = new System.Windows.Forms.CheckBox();
            this.chb_PShot = new System.Windows.Forms.CheckBox();
            this.chb_PRunVideo = new System.Windows.Forms.CheckBox();
            this.rb_CMOS2 = new System.Windows.Forms.RadioButton();
            this.rb_CMOS1 = new System.Windows.Forms.RadioButton();
            this.gbox_Passports = new System.Windows.Forms.GroupBox();
            this.chb_Calibr = new System.Windows.Forms.CheckBox();
            this.lb_num_bad_points = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.num_BadPixLimit = new System.Windows.Forms.NumericUpDown();
            this.bt_sort_badpix = new System.Windows.Forms.Button();
            this.bt_clear_badpix = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listb_badpix = new System.Windows.Forms.ListBox();
            this.bt_DnLoadConf = new System.Windows.Forms.Button();
            this.bt_UpLoadConf = new System.Windows.Forms.Button();
            this.bt_DnLoadPass = new System.Windows.Forms.Button();
            this.bt_UpLoadPass = new System.Windows.Forms.Button();
            this.bt_SavePass = new System.Windows.Forms.Button();
            this.lb_num_points_in_pass = new System.Windows.Forms.Label();
            this.listb_Passport = new System.Windows.Forms.ListBox();
            this.gbox_CMOS2 = new System.Windows.Forms.GroupBox();
            this.cb_CMOS2Enable = new System.Windows.Forms.CheckBox();
            this.tb_VINB2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CMOS2SetDAC2 = new System.Windows.Forms.Button();
            this.tb_VREF2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CMOS2SetDAC1 = new System.Windows.Forms.Button();
            this.gbox_CMOS1 = new System.Windows.Forms.GroupBox();
            this.cb_CMOS1Enable = new System.Windows.Forms.CheckBox();
            this.tb_VINB1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CMOS1SetDAC2 = new System.Windows.Forms.Button();
            this.tb_VREF1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_CMOS1SetDAC1 = new System.Windows.Forms.Button();
            this.gbox_Image = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.pb_CMOS = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbox_CAN = new System.Windows.Forms.GroupBox();
            this.lb_noerr = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lb_error_CAN = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_CloseCAN = new System.Windows.Forms.Button();
            this.bt_OpenCAN = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.gb1_Addr = new System.Windows.Forms.GroupBox();
            this.rb1_addr_right = new System.Windows.Forms.RadioButton();
            this.rb1_addr_left = new System.Windows.Forms.RadioButton();
            this.rb1_addr_uni = new System.Windows.Forms.RadioButton();
            this.bt_About1 = new System.Windows.Forms.Button();
            this.bt_Exit1 = new System.Windows.Forms.Button();
            this.gb_MC1 = new System.Windows.Forms.GroupBox();
            this.rb_flight_universal = new System.Windows.Forms.RadioButton();
            this.rb_new_RUP = new System.Windows.Forms.RadioButton();
            this.rb_cmos12_select2 = new System.Windows.Forms.RadioButton();
            this.rb_cmos12_select_long_time2 = new System.Windows.Forms.RadioButton();
            this.chb1_need_reset = new System.Windows.Forms.CheckBox();
            this.rb_file_open = new System.Windows.Forms.RadioButton();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.rb_flight_right_wing_double_pass = new System.Windows.Forms.RadioButton();
            this.rb_flight_left_wing_double_pass = new System.Windows.Forms.RadioButton();
            this.rb_cmos12_select = new System.Windows.Forms.RadioButton();
            this.rb_cmos12_select_long_time = new System.Windows.Forms.RadioButton();
            this.tb_fnameMC1 = new System.Windows.Forms.TextBox();
            this.pb_loadMC1 = new System.Windows.Forms.ProgressBar();
            this.chb_eraseALL1 = new System.Windows.Forms.CheckBox();
            this.bt_runMC1 = new System.Windows.Forms.Button();
            this.lb_Load_OK1 = new System.Windows.Forms.Label();
            this.bt_loadMC1 = new System.Windows.Forms.Button();
            this.bt_openMC1 = new System.Windows.Forms.Button();
            this.gb_CAN1 = new System.Windows.Forms.GroupBox();
            this.lb_noerr1 = new System.Windows.Forms.Label();
            this.lb_error_CAN1 = new System.Windows.Forms.Label();
            this.cb_CAN1 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rb2_piv11 = new System.Windows.Forms.RadioButton();
            this.rb2_piv10 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb2_filter_all = new System.Windows.Forms.RadioButton();
            this.rb2_filter_7fff = new System.Windows.Forms.RadioButton();
            this.rb2_filter_data = new System.Windows.Forms.RadioButton();
            this.rtb2_datagrid = new System.Windows.Forms.RichTextBox();
            this.cb_clear_shot = new System.Windows.Forms.CheckBox();
            this.label42 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.gb_stR2 = new System.Windows.Forms.GroupBox();
            this.lb_stR2_cmos2 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.lb_stR2_cmos1 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.gb_stL2 = new System.Windows.Forms.GroupBox();
            this.lb_stL2_cmos2 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lb_stL2_cmos1 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.btn_SAVESN = new System.Windows.Forms.Button();
            this.tb_SN = new System.Windows.Forms.TextBox();
            this.gbox_ecR2 = new System.Windows.Forms.GroupBox();
            this.lb_ecR2_ram2 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.lb_ecR2_ram1 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.lb_ecR2_ram = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.lb_ecR2_file = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.lb_ecR2_plis2 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.lb_ecR2_plis1 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.gbox_ecL2 = new System.Windows.Forms.GroupBox();
            this.lb_ecL2_ram2 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.lb_ecL2_ram1 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.lb_ecL2_ram = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.lb_ecL2_file = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.lb_ecL2_plis2 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.lb_ecL2_plis1 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.gbox_statusR2 = new System.Windows.Forms.GroupBox();
            this.lb_statusR_t32 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lb_statusR_t22 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.lb_statusR_t12 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.lb_statusR_file2 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.lb_statusR_plis2 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.lb_statusR_status2 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.lb_statusR_reason2 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.lb_statusR_mode2 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.gbox_statusL2 = new System.Windows.Forms.GroupBox();
            this.lb_statusL_t32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lb_statusL_t22 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lb_statusL_t12 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lb_statusL_file2 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lb_statusL_plis2 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.lb_statusL_status2 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lb_statusL_reason2 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lb_statusL_mode2 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cb_module2 = new System.Windows.Forms.ComboBox();
            this.bt_mod2 = new System.Windows.Forms.Button();
            this.REQ_VER = new System.Windows.Forms.Button();
            this.chb3_savelog = new System.Windows.Forms.CheckBox();
            this.btn_REQSN = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.chb_dgview2 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.bt_Request2 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.bt_SyncTime = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.gbox_CAN2 = new System.Windows.Forms.GroupBox();
            this.lb_noerr2 = new System.Windows.Forms.Label();
            this.cb_CAN2 = new System.Windows.Forms.ComboBox();
            this.lb_error_CAN2 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.bt_CloseCAN2 = new System.Windows.Forms.Button();
            this.bt_OpenCAN2 = new System.Windows.Forms.Button();
            this.bt_About2 = new System.Windows.Forms.Button();
            this.bt_Exit2 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.rtb3_datagrid = new System.Windows.Forms.RichTextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.chb4_nopaint = new System.Windows.Forms.CheckBox();
            this.gb3_shoot = new System.Windows.Forms.GroupBox();
            this.lb3_freq_val_r = new System.Windows.Forms.Label();
            this.lb3_freq_txt_r = new System.Windows.Forms.Label();
            this.lb3_shoot_um_val_r = new System.Windows.Forms.Label();
            this.lb3_shoot_az_val_r = new System.Windows.Forms.Label();
            this.lb3_shoot_um_txt_r = new System.Windows.Forms.Label();
            this.lb3_shoot_az_txt_r = new System.Windows.Forms.Label();
            this.trackBar3_freq_r = new System.Windows.Forms.TrackBar();
            this.trackBar3_um_r = new System.Windows.Forms.TrackBar();
            this.chb4_enshr = new System.Windows.Forms.CheckBox();
            this.trackBar3_az_r = new System.Windows.Forms.TrackBar();
            this.chb4_enshl = new System.Windows.Forms.CheckBox();
            this.lb3_freq_val_l = new System.Windows.Forms.Label();
            this.lb3_freq_txt_l = new System.Windows.Forms.Label();
            this.trackBar3_freq_l = new System.Windows.Forms.TrackBar();
            this.chb3_shoot_ena = new System.Windows.Forms.CheckBox();
            this.lb3_shoot_um_val_l = new System.Windows.Forms.Label();
            this.lb3_shoot_az_val_l = new System.Windows.Forms.Label();
            this.trackBar3_um_l = new System.Windows.Forms.TrackBar();
            this.lb3_shoot_um_txt_l = new System.Windows.Forms.Label();
            this.trackBar3_az_l = new System.Windows.Forms.TrackBar();
            this.lb3_shoot_az_txt_l = new System.Windows.Forms.Label();
            this.chb_dgview3 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.gb_olo_R = new System.Windows.Forms.GroupBox();
            this.bt3_trash_r = new System.Windows.Forms.Button();
            this.bt3_baddata_r = new System.Windows.Forms.Button();
            this.bt3_badstatus_r = new System.Windows.Forms.Button();
            this.lb3_t2_r = new System.Windows.Forms.Label();
            this.tb3_t2_r = new System.Windows.Forms.TextBox();
            this.lb3_t1_r = new System.Windows.Forms.Label();
            this.tb3_t1_r = new System.Windows.Forms.TextBox();
            this.lb3_tarm_r = new System.Windows.Forms.Label();
            this.tb3_tarm_r = new System.Windows.Forms.TextBox();
            this.chb_R_Err_file = new System.Windows.Forms.CheckBox();
            this.cb_olo_r_ena = new System.Windows.Forms.CheckBox();
            this.chb_R_Err_plis = new System.Windows.Forms.CheckBox();
            this.shoot_r = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.chb_R_Err_int = new System.Windows.Forms.CheckBox();
            this.gb_olo_L = new System.Windows.Forms.GroupBox();
            this.bt3_trash_l = new System.Windows.Forms.Button();
            this.bt3_baddata_l = new System.Windows.Forms.Button();
            this.bt3_badstatus_l = new System.Windows.Forms.Button();
            this.lb3_t2_l = new System.Windows.Forms.Label();
            this.tb3_t2_l = new System.Windows.Forms.TextBox();
            this.lb3_t1_l = new System.Windows.Forms.Label();
            this.tb3_t1_l = new System.Windows.Forms.TextBox();
            this.lb3_tarm_l = new System.Windows.Forms.Label();
            this.tb3_tarm_l = new System.Windows.Forms.TextBox();
            this.chb_L_Err_file = new System.Windows.Forms.CheckBox();
            this.chb_L_Err_plis = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.chb_L_Err_int = new System.Windows.Forms.CheckBox();
            this.cb_olo_l_ena = new System.Windows.Forms.CheckBox();
            this.shoot_l = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbox_CAN3 = new System.Windows.Forms.GroupBox();
            this.lb_noerr3 = new System.Windows.Forms.Label();
            this.cb_CAN3 = new System.Windows.Forms.ComboBox();
            this.lb_error_CAN3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.bt_CloseCAN3 = new System.Windows.Forms.Button();
            this.bt_OpenCAN3 = new System.Windows.Forms.Button();
            this.bt_About3 = new System.Windows.Forms.Button();
            this.bt_Exit3 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.lb_plis_init = new System.Windows.Forms.Label();
            this.chb5_timer_enable = new System.Windows.Forms.CheckBox();
            this.lb_plis2_load = new System.Windows.Forms.Label();
            this.gb_Image24 = new System.Windows.Forms.GroupBox();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.pb_CMOS2 = new System.Windows.Forms.ProgressBar();
            this.lb_CMOS24 = new System.Windows.Forms.Label();
            this.bt_get_CMOS2 = new System.Windows.Forms.Button();
            this.lb_plis1_load = new System.Windows.Forms.Label();
            this.gb_Temperature = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lb_T3_val4 = new System.Windows.Forms.Label();
            this.lb_T3 = new System.Windows.Forms.Label();
            this.lb_T2_val4 = new System.Windows.Forms.Label();
            this.lb_T1_val4 = new System.Windows.Forms.Label();
            this.bt_plis2_load = new System.Windows.Forms.Button();
            this.gb_Image14 = new System.Windows.Forms.GroupBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pb_CMOS1 = new System.Windows.Forms.ProgressBar();
            this.bt_get_CMOS1 = new System.Windows.Forms.Button();
            this.lb_CMOS14 = new System.Windows.Forms.Label();
            this.bt_plis1_load = new System.Windows.Forms.Button();
            this.gb_Tests = new System.Windows.Forms.GroupBox();
            this.bt5_reset = new System.Windows.Forms.Button();
            this.chb5_d19 = new System.Windows.Forms.CheckBox();
            this.chb5_d13 = new System.Windows.Forms.CheckBox();
            this.gb5_ba = new System.Windows.Forms.GroupBox();
            this.rb5_a_01 = new System.Windows.Forms.RadioButton();
            this.rb5_a_1 = new System.Windows.Forms.RadioButton();
            this.rb5_a_0 = new System.Windows.Forms.RadioButton();
            this.chb5_d21 = new System.Windows.Forms.CheckBox();
            this.gb5_bd = new System.Windows.Forms.GroupBox();
            this.rb5_d_01 = new System.Windows.Forms.RadioButton();
            this.rb5_d_1 = new System.Windows.Forms.RadioButton();
            this.rb5_d_0 = new System.Windows.Forms.RadioButton();
            this.lb_test_D19_2 = new System.Windows.Forms.Label();
            this.bt_test_D19_2 = new System.Windows.Forms.Button();
            this.lb_test_D13_2 = new System.Windows.Forms.Label();
            this.bt_test_D13_2 = new System.Windows.Forms.Button();
            this.lb_test_FLASH_2 = new System.Windows.Forms.Label();
            this.chb_Sin = new System.Windows.Forms.CheckBox();
            this.chb_Peltier2 = new System.Windows.Forms.CheckBox();
            this.chb_Peltier1 = new System.Windows.Forms.CheckBox();
            this.chb_cycle_test_D19 = new System.Windows.Forms.CheckBox();
            this.chb_cycle_test_D13 = new System.Windows.Forms.CheckBox();
            this.chb_cycle_test_D21 = new System.Windows.Forms.CheckBox();
            this.lb_test_FLASH = new System.Windows.Forms.Label();
            this.bt_test_FLASH = new System.Windows.Forms.Button();
            this.lb_test_D21_2 = new System.Windows.Forms.Label();
            this.bt_test_D21_2 = new System.Windows.Forms.Button();
            this.lb_test_D19 = new System.Windows.Forms.Label();
            this.bt_test_D19 = new System.Windows.Forms.Button();
            this.lb_test_D13 = new System.Windows.Forms.Label();
            this.bt_test_D13 = new System.Windows.Forms.Button();
            this.lb_test_D21_1 = new System.Windows.Forms.Label();
            this.bt_test_D21_1 = new System.Windows.Forms.Button();
            this.lb_test_plis = new System.Windows.Forms.Label();
            this.bt_test_PLIS = new System.Windows.Forms.Button();
            this.bt_plis_init = new System.Windows.Forms.Button();
            this.gbox_CAN4 = new System.Windows.Forms.GroupBox();
            this.lb_version = new System.Windows.Forms.Label();
            this.lb_noerr4 = new System.Windows.Forms.Label();
            this.cb_CAN4 = new System.Windows.Forms.ComboBox();
            this.lb_error_CAN4 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.bt_CloseCAN4 = new System.Windows.Forms.Button();
            this.bt_OpenCAN4 = new System.Windows.Forms.Button();
            this.bt_About4 = new System.Windows.Forms.Button();
            this.bt_Exit4 = new System.Windows.Forms.Button();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label56 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.button3 = new System.Windows.Forms.Button();
            this.bt_verifi5 = new System.Windows.Forms.Button();
            this.bt_status5 = new System.Windows.Forms.Button();
            this.bt_reboot5 = new System.Windows.Forms.Button();
            this.rb_l5 = new System.Windows.Forms.RadioButton();
            this.rb_r5 = new System.Windows.Forms.RadioButton();
            this.bt_aktiv5 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crc32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_About5 = new System.Windows.Forms.Button();
            this.bt_Exit5 = new System.Windows.Forms.Button();
            this.gbox_CAN5 = new System.Windows.Forms.GroupBox();
            this.lb_noerr5 = new System.Windows.Forms.Label();
            this.cb_CAN5 = new System.Windows.Forms.ComboBox();
            this.lb_error_CAN5 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.bt_CloseCAN5 = new System.Windows.Forms.Button();
            this.bt_OpenCAN5 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.chb_6_6 = new System.Windows.Forms.CheckBox();
            this.bt_6_savesetup = new System.Windows.Forms.Button();
            this.chb_6_7 = new System.Windows.Forms.CheckBox();
            this.chb_6_5 = new System.Windows.Forms.CheckBox();
            this.chb_6_4 = new System.Windows.Forms.CheckBox();
            this.chb_6_3 = new System.Windows.Forms.CheckBox();
            this.chb_6_2 = new System.Windows.Forms.CheckBox();
            this.chb_6_1 = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer_UpdateTime = new System.Windows.Forms.Timer(this.components);
            this.Timer_GetData = new System.Windows.Forms.Timer(this.components);
            this.timer_testOLO_L = new System.Windows.Forms.Timer(this.components);
            this.timer_testOLO_R = new System.Windows.Forms.Timer(this.components);
            this.timer_Reset_Shots = new System.Windows.Forms.Timer(this.components);
            this.timer_Reset_Shots3 = new System.Windows.Forms.Timer(this.components);
            this.timer_testOLO_R3 = new System.Windows.Forms.Timer(this.components);
            this.timer_testOLO_L3 = new System.Windows.Forms.Timer(this.components);
            this.Timer_GetData3 = new System.Windows.Forms.Timer(this.components);
            this.timer_temperature = new System.Windows.Forms.Timer(this.components);
            this.timer_Error_Boot = new System.Windows.Forms.Timer(this.components);
            this.tm4_counter = new System.Windows.Forms.Timer(this.components);
            this.tm4_test = new System.Windows.Forms.Timer(this.components);
            this.timer1s = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer3_reset_l = new System.Windows.Forms.Timer(this.components);
            this.timer3_reset_r = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbox_Temperature.SuspendLayout();
            this.gbox_Cross.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_CCirkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_CAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_CY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_CX)).BeginInit();
            this.gbox_Process.SuspendLayout();
            this.gbox_Passports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_BadPixLimit)).BeginInit();
            this.gbox_CMOS2.SuspendLayout();
            this.gbox_CMOS1.SuspendLayout();
            this.gbox_Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbox_CAN.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gb1_Addr.SuspendLayout();
            this.gb_MC1.SuspendLayout();
            this.gb_CAN1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gb_stR2.SuspendLayout();
            this.gb_stL2.SuspendLayout();
            this.gbox_ecR2.SuspendLayout();
            this.gbox_ecL2.SuspendLayout();
            this.gbox_statusR2.SuspendLayout();
            this.gbox_statusL2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.gbox_CAN2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.gb3_shoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_freq_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_um_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_az_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_freq_l)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_um_l)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_az_l)).BeginInit();
            this.gb_olo_R.SuspendLayout();
            this.gb_olo_L.SuspendLayout();
            this.gbox_CAN3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.gb_Image24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            this.gb_Temperature.SuspendLayout();
            this.gb_Image14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            this.gb_Tests.SuspendLayout();
            this.gb5_ba.SuspendLayout();
            this.gb5_bd.SuspendLayout();
            this.gbox_CAN4.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbox_CAN5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // VideoTimer
            // 
            this.VideoTimer.Interval = 10;
            this.VideoTimer.Tick += new System.EventHandler(this.VideoTimer_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(95, 25);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(970, 687);
            this.tabControl1.TabIndex = 25;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chb0_srfon);
            this.tabPage1.Controls.Add(this.cb_shotshow);
            this.tabPage1.Controls.Add(this.chb0_screen);
            this.tabPage1.Controls.Add(this.bt_SAVESN1);
            this.tabPage1.Controls.Add(this.bt_REQSN1);
            this.tabPage1.Controls.Add(this.tb_SN1);
            this.tabPage1.Controls.Add(this.gbox_Temperature);
            this.tabPage1.Controls.Add(this.gbox_Cross);
            this.tabPage1.Controls.Add(this.bt_About);
            this.tabPage1.Controls.Add(this.bt_Exit);
            this.tabPage1.Controls.Add(this.gbox_Process);
            this.tabPage1.Controls.Add(this.rb_CMOS2);
            this.tabPage1.Controls.Add(this.rb_CMOS1);
            this.tabPage1.Controls.Add(this.gbox_Passports);
            this.tabPage1.Controls.Add(this.gbox_CMOS2);
            this.tabPage1.Controls.Add(this.gbox_CMOS1);
            this.tabPage1.Controls.Add(this.gbox_Image);
            this.tabPage1.Controls.Add(this.gbox_CAN);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(962, 654);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Юстировка ОЛО";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chb0_srfon
            // 
            this.chb0_srfon.AutoSize = true;
            this.chb0_srfon.Checked = true;
            this.chb0_srfon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb0_srfon.Location = new System.Drawing.Point(669, 559);
            this.chb0_srfon.Name = "chb0_srfon";
            this.chb0_srfon.Size = new System.Drawing.Size(92, 17);
            this.chb0_srfon.TabIndex = 74;
            this.chb0_srfon.Text = "Средний фон";
            this.chb0_srfon.UseVisualStyleBackColor = true;
            // 
            // cb_shotshow
            // 
            this.cb_shotshow.AutoSize = true;
            this.cb_shotshow.Location = new System.Drawing.Point(810, 541);
            this.cb_shotshow.Name = "cb_shotshow";
            this.cb_shotshow.Size = new System.Drawing.Size(143, 17);
            this.cb_shotshow.TabIndex = 73;
            this.cb_shotshow.Text = "Показывать выстрелы";
            this.cb_shotshow.UseVisualStyleBackColor = true;
            // 
            // chb0_screen
            // 
            this.chb0_screen.AutoSize = true;
            this.chb0_screen.Location = new System.Drawing.Point(669, 541);
            this.chb0_screen.Name = "chb0_screen";
            this.chb0_screen.Size = new System.Drawing.Size(85, 17);
            this.chb0_screen.TabIndex = 72;
            this.chb0_screen.Text = "Screenshots";
            this.chb0_screen.UseVisualStyleBackColor = true;
            // 
            // bt_SAVESN1
            // 
            this.bt_SAVESN1.Location = new System.Drawing.Point(378, 622);
            this.bt_SAVESN1.Name = "bt_SAVESN1";
            this.bt_SAVESN1.Size = new System.Drawing.Size(53, 23);
            this.bt_SAVESN1.TabIndex = 71;
            this.bt_SAVESN1.Text = "Запись";
            this.bt_SAVESN1.UseVisualStyleBackColor = true;
            this.bt_SAVESN1.Click += new System.EventHandler(this.bt_SAVESN1_Click);
            // 
            // bt_REQSN1
            // 
            this.bt_REQSN1.Location = new System.Drawing.Point(319, 622);
            this.bt_REQSN1.Name = "bt_REQSN1";
            this.bt_REQSN1.Size = new System.Drawing.Size(53, 23);
            this.bt_REQSN1.TabIndex = 70;
            this.bt_REQSN1.Text = "Запрос";
            this.bt_REQSN1.UseVisualStyleBackColor = true;
            this.bt_REQSN1.Click += new System.EventHandler(this.bt_REQSN1_Click);
            // 
            // tb_SN1
            // 
            this.tb_SN1.Location = new System.Drawing.Point(255, 623);
            this.tb_SN1.Name = "tb_SN1";
            this.tb_SN1.Size = new System.Drawing.Size(58, 20);
            this.tb_SN1.TabIndex = 69;
            // 
            // gbox_Temperature
            // 
            this.gbox_Temperature.Controls.Add(this.lb_T1);
            this.gbox_Temperature.Controls.Add(this.lb_T2);
            this.gbox_Temperature.Controls.Add(this.lb_T2_val);
            this.gbox_Temperature.Controls.Add(this.lb_T1_val);
            this.gbox_Temperature.Location = new System.Drawing.Point(252, 571);
            this.gbox_Temperature.Name = "gbox_Temperature";
            this.gbox_Temperature.Size = new System.Drawing.Size(179, 41);
            this.gbox_Temperature.TabIndex = 32;
            this.gbox_Temperature.TabStop = false;
            this.gbox_Temperature.Text = "Температуры";
            // 
            // lb_T1
            // 
            this.lb_T1.AutoSize = true;
            this.lb_T1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lb_T1.Location = new System.Drawing.Point(6, 20);
            this.lb_T1.Name = "lb_T1";
            this.lb_T1.Size = new System.Drawing.Size(46, 13);
            this.lb_T1.TabIndex = 7;
            this.lb_T1.Text = "Темп. 1";
            // 
            // lb_T2
            // 
            this.lb_T2.AutoSize = true;
            this.lb_T2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lb_T2.Location = new System.Drawing.Point(92, 20);
            this.lb_T2.Name = "lb_T2";
            this.lb_T2.Size = new System.Drawing.Size(46, 13);
            this.lb_T2.TabIndex = 8;
            this.lb_T2.Text = "Темп. 2";
            // 
            // lb_T2_val
            // 
            this.lb_T2_val.AutoSize = true;
            this.lb_T2_val.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lb_T2_val.Location = new System.Drawing.Point(138, 20);
            this.lb_T2_val.Name = "lb_T2_val";
            this.lb_T2_val.Size = new System.Drawing.Size(11, 13);
            this.lb_T2_val.TabIndex = 11;
            this.lb_T2_val.Text = "-";
            // 
            // lb_T1_val
            // 
            this.lb_T1_val.AutoSize = true;
            this.lb_T1_val.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lb_T1_val.Location = new System.Drawing.Point(51, 20);
            this.lb_T1_val.Name = "lb_T1_val";
            this.lb_T1_val.Size = new System.Drawing.Size(11, 13);
            this.lb_T1_val.TabIndex = 10;
            this.lb_T1_val.Text = "-";
            // 
            // gbox_Cross
            // 
            this.gbox_Cross.Controls.Add(this.label12);
            this.gbox_Cross.Controls.Add(this.chb_oldlens);
            this.gbox_Cross.Controls.Add(this.rb_RightW);
            this.gbox_Cross.Controls.Add(this.rb_LeftW);
            this.gbox_Cross.Controls.Add(this.bt_SaveConf);
            this.gbox_Cross.Controls.Add(this.chb_CCirkle);
            this.gbox_Cross.Controls.Add(this.label13);
            this.gbox_Cross.Controls.Add(this.label14);
            this.gbox_Cross.Controls.Add(this.label15);
            this.gbox_Cross.Controls.Add(this.num_CCirkle);
            this.gbox_Cross.Controls.Add(this.num_CAngle);
            this.gbox_Cross.Controls.Add(this.label10);
            this.gbox_Cross.Controls.Add(this.label11);
            this.gbox_Cross.Controls.Add(this.label9);
            this.gbox_Cross.Controls.Add(this.label8);
            this.gbox_Cross.Controls.Add(this.num_CY);
            this.gbox_Cross.Controls.Add(this.num_CX);
            this.gbox_Cross.Controls.Add(this.chb_EnableCross);
            this.gbox_Cross.Location = new System.Drawing.Point(437, 571);
            this.gbox_Cross.Name = "gbox_Cross";
            this.gbox_Cross.Size = new System.Drawing.Size(396, 78);
            this.gbox_Cross.TabIndex = 31;
            this.gbox_Cross.TabStop = false;
            this.gbox_Cross.Text = "Крест";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(225, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Борт";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chb_oldlens
            // 
            this.chb_oldlens.AutoSize = true;
            this.chb_oldlens.Location = new System.Drawing.Point(258, 11);
            this.chb_oldlens.Name = "chb_oldlens";
            this.chb_oldlens.Size = new System.Drawing.Size(115, 17);
            this.chb_oldlens.TabIndex = 27;
            this.chb_oldlens.Text = "Старый объектив";
            this.chb_oldlens.UseVisualStyleBackColor = true;
            // 
            // rb_RightW
            // 
            this.rb_RightW.AutoSize = true;
            this.rb_RightW.Location = new System.Drawing.Point(323, 27);
            this.rb_RightW.Name = "rb_RightW";
            this.rb_RightW.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rb_RightW.Size = new System.Drawing.Size(65, 17);
            this.rb_RightW.TabIndex = 26;
            this.rb_RightW.Text = "Правый";
            this.rb_RightW.UseVisualStyleBackColor = true;
            this.rb_RightW.CheckedChanged += new System.EventHandler(this.rb_RightW_CheckedChanged);
            // 
            // rb_LeftW
            // 
            this.rb_LeftW.AutoSize = true;
            this.rb_LeftW.Checked = true;
            this.rb_LeftW.Location = new System.Drawing.Point(258, 27);
            this.rb_LeftW.Name = "rb_LeftW";
            this.rb_LeftW.Size = new System.Drawing.Size(59, 17);
            this.rb_LeftW.TabIndex = 25;
            this.rb_LeftW.TabStop = true;
            this.rb_LeftW.Text = "Левый";
            this.rb_LeftW.UseVisualStyleBackColor = true;
            this.rb_LeftW.CheckedChanged += new System.EventHandler(this.rb_LeftW_CheckedChanged);
            // 
            // bt_SaveConf
            // 
            this.bt_SaveConf.Location = new System.Drawing.Point(258, 50);
            this.bt_SaveConf.Name = "bt_SaveConf";
            this.bt_SaveConf.Size = new System.Drawing.Size(134, 23);
            this.bt_SaveConf.TabIndex = 24;
            this.bt_SaveConf.Text = "Сохранить конфиг";
            this.bt_SaveConf.UseVisualStyleBackColor = true;
            this.bt_SaveConf.Click += new System.EventHandler(this.bt_SaveConf_Click);
            // 
            // chb_CCirkle
            // 
            this.chb_CCirkle.Location = new System.Drawing.Point(188, 53);
            this.chb_CCirkle.Name = "chb_CCirkle";
            this.chb_CCirkle.Size = new System.Drawing.Size(50, 20);
            this.chb_CCirkle.TabIndex = 23;
            this.chb_CCirkle.Text = "Круг";
            this.chb_CCirkle.UseVisualStyleBackColor = true;
            this.chb_CCirkle.Click += new System.EventHandler(this.chb_CCirkle_CheckedChanged);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(187, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 20);
            this.label13.TabIndex = 22;
            this.label13.Text = "Град.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(120, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 20);
            this.label14.TabIndex = 21;
            this.label14.Text = "R";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(107, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 20);
            this.label15.TabIndex = 20;
            this.label15.Text = "Угол";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // num_CCirkle
            // 
            this.num_CCirkle.Location = new System.Drawing.Point(140, 53);
            this.num_CCirkle.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_CCirkle.Name = "num_CCirkle";
            this.num_CCirkle.Size = new System.Drawing.Size(45, 20);
            this.num_CCirkle.TabIndex = 19;
            this.num_CCirkle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_CCirkle.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // num_CAngle
            // 
            this.num_CAngle.Location = new System.Drawing.Point(140, 25);
            this.num_CAngle.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.num_CAngle.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.num_CAngle.Name = "num_CAngle";
            this.num_CAngle.Size = new System.Drawing.Size(45, 20);
            this.num_CAngle.TabIndex = 18;
            this.num_CAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(69, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Пикс.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(69, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "Пикс.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Y";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "X";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // num_CY
            // 
            this.num_CY.Location = new System.Drawing.Point(22, 53);
            this.num_CY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_CY.Name = "num_CY";
            this.num_CY.Size = new System.Drawing.Size(45, 20);
            this.num_CY.TabIndex = 13;
            this.num_CY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_CY.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            // 
            // num_CX
            // 
            this.num_CX.Location = new System.Drawing.Point(22, 23);
            this.num_CX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_CX.Name = "num_CX";
            this.num_CX.Size = new System.Drawing.Size(45, 20);
            this.num_CX.TabIndex = 12;
            this.num_CX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_CX.Value = new decimal(new int[] {
            159,
            0,
            0,
            0});
            // 
            // chb_EnableCross
            // 
            this.chb_EnableCross.AutoSize = true;
            this.chb_EnableCross.Location = new System.Drawing.Point(46, 1);
            this.chb_EnableCross.Name = "chb_EnableCross";
            this.chb_EnableCross.Size = new System.Drawing.Size(15, 14);
            this.chb_EnableCross.TabIndex = 11;
            this.chb_EnableCross.UseVisualStyleBackColor = true;
            this.chb_EnableCross.Click += new System.EventHandler(this.chb_EnableCross_CheckedChanged);
            // 
            // bt_About
            // 
            this.bt_About.Location = new System.Drawing.Point(839, 592);
            this.bt_About.Name = "bt_About";
            this.bt_About.Size = new System.Drawing.Size(108, 23);
            this.bt_About.TabIndex = 34;
            this.bt_About.Text = "О программе";
            this.bt_About.UseVisualStyleBackColor = true;
            this.bt_About.Click += new System.EventHandler(this.bt_About_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(839, 621);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(108, 23);
            this.bt_Exit.TabIndex = 33;
            this.bt_Exit.Text = "Выход";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // gbox_Process
            // 
            this.gbox_Process.Controls.Add(this.chb_PHidebadpix);
            this.gbox_Process.Controls.Add(this.chb_PFIFO);
            this.gbox_Process.Controls.Add(this.chb_PShot);
            this.gbox_Process.Controls.Add(this.chb_PRunVideo);
            this.gbox_Process.Location = new System.Drawing.Point(663, 476);
            this.gbox_Process.Name = "gbox_Process";
            this.gbox_Process.Size = new System.Drawing.Size(284, 59);
            this.gbox_Process.TabIndex = 30;
            this.gbox_Process.TabStop = false;
            // 
            // chb_PHidebadpix
            // 
            this.chb_PHidebadpix.AutoSize = true;
            this.chb_PHidebadpix.Location = new System.Drawing.Point(147, 35);
            this.chb_PHidebadpix.Name = "chb_PHidebadpix";
            this.chb_PHidebadpix.Size = new System.Drawing.Size(133, 17);
            this.chb_PHidebadpix.TabIndex = 3;
            this.chb_PHidebadpix.Text = "Скрыть плохие точки";
            this.chb_PHidebadpix.UseVisualStyleBackColor = true;
            // 
            // chb_PFIFO
            // 
            this.chb_PFIFO.AutoSize = true;
            this.chb_PFIFO.Location = new System.Drawing.Point(147, 13);
            this.chb_PFIFO.Name = "chb_PFIFO";
            this.chb_PFIFO.Size = new System.Drawing.Size(89, 17);
            this.chb_PFIFO.TabIndex = 2;
            this.chb_PFIFO.Text = "Только FIFO";
            this.chb_PFIFO.UseVisualStyleBackColor = true;
            // 
            // chb_PShot
            // 
            this.chb_PShot.AutoSize = true;
            this.chb_PShot.Location = new System.Drawing.Point(6, 35);
            this.chb_PShot.Name = "chb_PShot";
            this.chb_PShot.Size = new System.Drawing.Size(135, 17);
            this.chb_PShot.TabIndex = 1;
            this.chb_PShot.Text = "Имитация выстрелов";
            this.chb_PShot.UseVisualStyleBackColor = true;
            // 
            // chb_PRunVideo
            // 
            this.chb_PRunVideo.AutoSize = true;
            this.chb_PRunVideo.Location = new System.Drawing.Point(6, 13);
            this.chb_PRunVideo.Name = "chb_PRunVideo";
            this.chb_PRunVideo.Size = new System.Drawing.Size(114, 17);
            this.chb_PRunVideo.TabIndex = 0;
            this.chb_PRunVideo.Text = "Передача кадров";
            this.chb_PRunVideo.UseVisualStyleBackColor = true;
            this.chb_PRunVideo.CheckedChanged += new System.EventHandler(this.chb_PRunVideo_CheckedChanged);
            this.chb_PRunVideo.Click += new System.EventHandler(this.chb_PRunVideo_CheckedChanged);
            // 
            // rb_CMOS2
            // 
            this.rb_CMOS2.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_CMOS2.Location = new System.Drawing.Point(808, 9);
            this.rb_CMOS2.Name = "rb_CMOS2";
            this.rb_CMOS2.Size = new System.Drawing.Size(139, 24);
            this.rb_CMOS2.TabIndex = 29;
            this.rb_CMOS2.Text = "CMOS2";
            this.rb_CMOS2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_CMOS2.UseVisualStyleBackColor = true;
            this.rb_CMOS2.Click += new System.EventHandler(this.rb_CMOS2_CheckedChanged);
            // 
            // rb_CMOS1
            // 
            this.rb_CMOS1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rb_CMOS1.Checked = true;
            this.rb_CMOS1.Location = new System.Drawing.Point(663, 9);
            this.rb_CMOS1.Name = "rb_CMOS1";
            this.rb_CMOS1.Size = new System.Drawing.Size(139, 24);
            this.rb_CMOS1.TabIndex = 28;
            this.rb_CMOS1.TabStop = true;
            this.rb_CMOS1.Text = "CMOS1";
            this.rb_CMOS1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_CMOS1.UseVisualStyleBackColor = true;
            this.rb_CMOS1.CheckedChanged += new System.EventHandler(this.rb_CMOS1_CheckedChanged);
            this.rb_CMOS1.Click += new System.EventHandler(this.rb_CMOS1_CheckedChanged);
            // 
            // gbox_Passports
            // 
            this.gbox_Passports.Controls.Add(this.chb_Calibr);
            this.gbox_Passports.Controls.Add(this.lb_num_bad_points);
            this.gbox_Passports.Controls.Add(this.label6);
            this.gbox_Passports.Controls.Add(this.num_BadPixLimit);
            this.gbox_Passports.Controls.Add(this.bt_sort_badpix);
            this.gbox_Passports.Controls.Add(this.bt_clear_badpix);
            this.gbox_Passports.Controls.Add(this.label5);
            this.gbox_Passports.Controls.Add(this.listb_badpix);
            this.gbox_Passports.Controls.Add(this.bt_DnLoadConf);
            this.gbox_Passports.Controls.Add(this.bt_UpLoadConf);
            this.gbox_Passports.Controls.Add(this.bt_DnLoadPass);
            this.gbox_Passports.Controls.Add(this.bt_UpLoadPass);
            this.gbox_Passports.Controls.Add(this.bt_SavePass);
            this.gbox_Passports.Controls.Add(this.lb_num_points_in_pass);
            this.gbox_Passports.Controls.Add(this.listb_Passport);
            this.gbox_Passports.Location = new System.Drawing.Point(663, 123);
            this.gbox_Passports.Name = "gbox_Passports";
            this.gbox_Passports.Size = new System.Drawing.Size(284, 354);
            this.gbox_Passports.TabIndex = 27;
            this.gbox_Passports.TabStop = false;
            this.gbox_Passports.Text = "Паспорта матриц";
            // 
            // chb_Calibr
            // 
            this.chb_Calibr.Location = new System.Drawing.Point(174, 289);
            this.chb_Calibr.Name = "chb_Calibr";
            this.chb_Calibr.Size = new System.Drawing.Size(103, 23);
            this.chb_Calibr.TabIndex = 14;
            this.chb_Calibr.Text = "Калибровка";
            this.chb_Calibr.UseVisualStyleBackColor = true;
            this.chb_Calibr.Click += new System.EventHandler(this.chb_Calibr_CheckedChanged);
            // 
            // lb_num_bad_points
            // 
            this.lb_num_bad_points.BackColor = System.Drawing.SystemColors.Control;
            this.lb_num_bad_points.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb_num_bad_points.Location = new System.Drawing.Point(174, 318);
            this.lb_num_bad_points.Name = "lb_num_bad_points";
            this.lb_num_bad_points.Size = new System.Drawing.Size(103, 21);
            this.lb_num_bad_points.TabIndex = 13;
            this.lb_num_bad_points.Text = "Плохих точек:";
            this.lb_num_bad_points.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Порог плохих точек";
            // 
            // num_BadPixLimit
            // 
            this.num_BadPixLimit.Location = new System.Drawing.Point(174, 260);
            this.num_BadPixLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_BadPixLimit.Name = "num_BadPixLimit";
            this.num_BadPixLimit.Size = new System.Drawing.Size(103, 20);
            this.num_BadPixLimit.TabIndex = 11;
            this.num_BadPixLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_BadPixLimit.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            // 
            // bt_sort_badpix
            // 
            this.bt_sort_badpix.Location = new System.Drawing.Point(174, 202);
            this.bt_sort_badpix.Name = "bt_sort_badpix";
            this.bt_sort_badpix.Size = new System.Drawing.Size(103, 23);
            this.bt_sort_badpix.TabIndex = 10;
            this.bt_sort_badpix.Text = "Сортировка";
            this.bt_sort_badpix.UseVisualStyleBackColor = true;
            this.bt_sort_badpix.Click += new System.EventHandler(this.bt_sort_badpix_Click);
            // 
            // bt_clear_badpix
            // 
            this.bt_clear_badpix.Location = new System.Drawing.Point(174, 174);
            this.bt_clear_badpix.Name = "bt_clear_badpix";
            this.bt_clear_badpix.Size = new System.Drawing.Size(103, 23);
            this.bt_clear_badpix.TabIndex = 9;
            this.bt_clear_badpix.Text = "Очистка";
            this.bt_clear_badpix.UseVisualStyleBackColor = true;
            this.bt_clear_badpix.Click += new System.EventHandler(this.bt_clear_badpix_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "   X             Y";
            // 
            // listb_badpix
            // 
            this.listb_badpix.FormattingEnabled = true;
            this.listb_badpix.Location = new System.Drawing.Point(174, 35);
            this.listb_badpix.Name = "listb_badpix";
            this.listb_badpix.Size = new System.Drawing.Size(103, 134);
            this.listb_badpix.TabIndex = 7;
            // 
            // bt_DnLoadConf
            // 
            this.bt_DnLoadConf.Location = new System.Drawing.Point(6, 318);
            this.bt_DnLoadConf.Name = "bt_DnLoadConf";
            this.bt_DnLoadConf.Size = new System.Drawing.Size(162, 23);
            this.bt_DnLoadConf.TabIndex = 6;
            this.bt_DnLoadConf.Text = "Прочитать конфиг из ОЛО";
            this.bt_DnLoadConf.UseVisualStyleBackColor = true;
            this.bt_DnLoadConf.Click += new System.EventHandler(this.bt_DnLoadConf_Click);
            // 
            // bt_UpLoadConf
            // 
            this.bt_UpLoadConf.Location = new System.Drawing.Point(6, 289);
            this.bt_UpLoadConf.Name = "bt_UpLoadConf";
            this.bt_UpLoadConf.Size = new System.Drawing.Size(162, 23);
            this.bt_UpLoadConf.TabIndex = 5;
            this.bt_UpLoadConf.Text = "Загрузить конфиг в ОЛО";
            this.bt_UpLoadConf.UseVisualStyleBackColor = true;
            this.bt_UpLoadConf.Click += new System.EventHandler(this.bt_UpLoadConf_Click);
            // 
            // bt_DnLoadPass
            // 
            this.bt_DnLoadPass.Location = new System.Drawing.Point(6, 260);
            this.bt_DnLoadPass.Name = "bt_DnLoadPass";
            this.bt_DnLoadPass.Size = new System.Drawing.Size(162, 23);
            this.bt_DnLoadPass.TabIndex = 4;
            this.bt_DnLoadPass.Text = "Прочитать паспорт из ОЛО";
            this.bt_DnLoadPass.UseVisualStyleBackColor = true;
            this.bt_DnLoadPass.Click += new System.EventHandler(this.bt_DnLoadPass_Click);
            // 
            // bt_UpLoadPass
            // 
            this.bt_UpLoadPass.Location = new System.Drawing.Point(6, 231);
            this.bt_UpLoadPass.Name = "bt_UpLoadPass";
            this.bt_UpLoadPass.Size = new System.Drawing.Size(162, 23);
            this.bt_UpLoadPass.TabIndex = 3;
            this.bt_UpLoadPass.Text = "Загрузить паспорт в ОЛО";
            this.bt_UpLoadPass.UseVisualStyleBackColor = true;
            this.bt_UpLoadPass.Click += new System.EventHandler(this.bt_UpLoadPass_Click);
            // 
            // bt_SavePass
            // 
            this.bt_SavePass.Location = new System.Drawing.Point(6, 202);
            this.bt_SavePass.Name = "bt_SavePass";
            this.bt_SavePass.Size = new System.Drawing.Size(162, 23);
            this.bt_SavePass.TabIndex = 2;
            this.bt_SavePass.Text = "Сохранить паспорт CMOS";
            this.bt_SavePass.UseVisualStyleBackColor = true;
            this.bt_SavePass.Click += new System.EventHandler(this.bt_SavePass_Click);
            // 
            // lb_num_points_in_pass
            // 
            this.lb_num_points_in_pass.AutoSize = true;
            this.lb_num_points_in_pass.Location = new System.Drawing.Point(6, 186);
            this.lb_num_points_in_pass.Name = "lb_num_points_in_pass";
            this.lb_num_points_in_pass.Size = new System.Drawing.Size(0, 13);
            this.lb_num_points_in_pass.TabIndex = 1;
            // 
            // listb_Passport
            // 
            this.listb_Passport.FormattingEnabled = true;
            this.listb_Passport.Location = new System.Drawing.Point(6, 19);
            this.listb_Passport.Name = "listb_Passport";
            this.listb_Passport.Size = new System.Drawing.Size(162, 160);
            this.listb_Passport.TabIndex = 0;
            this.listb_Passport.Click += new System.EventHandler(this.listb_Passport_Click);
            this.listb_Passport.SelectedIndexChanged += new System.EventHandler(this.listb_Passport_SelectedIndexChanged);
            this.listb_Passport.DoubleClick += new System.EventHandler(this.listb_Passport_DoubleClick);
            this.listb_Passport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listb_Passport_MouseUp);
            // 
            // gbox_CMOS2
            // 
            this.gbox_CMOS2.Controls.Add(this.cb_CMOS2Enable);
            this.gbox_CMOS2.Controls.Add(this.tb_VINB2);
            this.gbox_CMOS2.Controls.Add(this.label3);
            this.gbox_CMOS2.Controls.Add(this.CMOS2SetDAC2);
            this.gbox_CMOS2.Controls.Add(this.tb_VREF2);
            this.gbox_CMOS2.Controls.Add(this.label4);
            this.gbox_CMOS2.Controls.Add(this.CMOS2SetDAC1);
            this.gbox_CMOS2.Enabled = false;
            this.gbox_CMOS2.Location = new System.Drawing.Point(808, 28);
            this.gbox_CMOS2.Name = "gbox_CMOS2";
            this.gbox_CMOS2.Size = new System.Drawing.Size(139, 89);
            this.gbox_CMOS2.TabIndex = 26;
            this.gbox_CMOS2.TabStop = false;
            // 
            // cb_CMOS2Enable
            // 
            this.cb_CMOS2Enable.AutoSize = true;
            this.cb_CMOS2Enable.Checked = true;
            this.cb_CMOS2Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_CMOS2Enable.Location = new System.Drawing.Point(6, 64);
            this.cb_CMOS2Enable.Name = "cb_CMOS2Enable";
            this.cb_CMOS2Enable.Size = new System.Drawing.Size(131, 17);
            this.cb_CMOS2Enable.TabIndex = 7;
            this.cb_CMOS2Enable.Text = "Включить термостат";
            this.cb_CMOS2Enable.UseVisualStyleBackColor = true;
            this.cb_CMOS2Enable.Click += new System.EventHandler(this.cb_CMOS2Enable_CheckedChanged);
            // 
            // tb_VINB2
            // 
            this.tb_VINB2.Location = new System.Drawing.Point(6, 39);
            this.tb_VINB2.Name = "tb_VINB2";
            this.tb_VINB2.Size = new System.Drawing.Size(36, 20);
            this.tb_VINB2.TabIndex = 5;
            this.tb_VINB2.Text = "1024";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "VINB";
            // 
            // CMOS2SetDAC2
            // 
            this.CMOS2SetDAC2.Location = new System.Drawing.Point(81, 37);
            this.CMOS2SetDAC2.Name = "CMOS2SetDAC2";
            this.CMOS2SetDAC2.Size = new System.Drawing.Size(51, 23);
            this.CMOS2SetDAC2.TabIndex = 3;
            this.CMOS2SetDAC2.Text = "Задать";
            this.CMOS2SetDAC2.UseVisualStyleBackColor = true;
            this.CMOS2SetDAC2.Click += new System.EventHandler(this.CMOS2SetDAC2_Click);
            // 
            // tb_VREF2
            // 
            this.tb_VREF2.Location = new System.Drawing.Point(6, 13);
            this.tb_VREF2.Name = "tb_VREF2";
            this.tb_VREF2.Size = new System.Drawing.Size(36, 20);
            this.tb_VREF2.TabIndex = 2;
            this.tb_VREF2.Text = "1024";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "VREF";
            // 
            // CMOS2SetDAC1
            // 
            this.CMOS2SetDAC1.Location = new System.Drawing.Point(81, 11);
            this.CMOS2SetDAC1.Name = "CMOS2SetDAC1";
            this.CMOS2SetDAC1.Size = new System.Drawing.Size(51, 23);
            this.CMOS2SetDAC1.TabIndex = 0;
            this.CMOS2SetDAC1.Text = "Задать";
            this.CMOS2SetDAC1.UseVisualStyleBackColor = true;
            this.CMOS2SetDAC1.Click += new System.EventHandler(this.CMOS2SetDAC1_Click);
            // 
            // gbox_CMOS1
            // 
            this.gbox_CMOS1.BackColor = System.Drawing.Color.PowderBlue;
            this.gbox_CMOS1.Controls.Add(this.cb_CMOS1Enable);
            this.gbox_CMOS1.Controls.Add(this.tb_VINB1);
            this.gbox_CMOS1.Controls.Add(this.label2);
            this.gbox_CMOS1.Controls.Add(this.CMOS1SetDAC2);
            this.gbox_CMOS1.Controls.Add(this.tb_VREF1);
            this.gbox_CMOS1.Controls.Add(this.label1);
            this.gbox_CMOS1.Controls.Add(this.bt_CMOS1SetDAC1);
            this.gbox_CMOS1.Location = new System.Drawing.Point(663, 28);
            this.gbox_CMOS1.Name = "gbox_CMOS1";
            this.gbox_CMOS1.Size = new System.Drawing.Size(139, 89);
            this.gbox_CMOS1.TabIndex = 25;
            this.gbox_CMOS1.TabStop = false;
            // 
            // cb_CMOS1Enable
            // 
            this.cb_CMOS1Enable.AutoSize = true;
            this.cb_CMOS1Enable.Checked = true;
            this.cb_CMOS1Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_CMOS1Enable.Location = new System.Drawing.Point(6, 64);
            this.cb_CMOS1Enable.Name = "cb_CMOS1Enable";
            this.cb_CMOS1Enable.Size = new System.Drawing.Size(131, 17);
            this.cb_CMOS1Enable.TabIndex = 6;
            this.cb_CMOS1Enable.Text = "Включить термостат";
            this.cb_CMOS1Enable.UseVisualStyleBackColor = true;
            this.cb_CMOS1Enable.Click += new System.EventHandler(this.cb_CMOS1Enable_CheckedChanged);
            // 
            // tb_VINB1
            // 
            this.tb_VINB1.Location = new System.Drawing.Point(6, 39);
            this.tb_VINB1.Name = "tb_VINB1";
            this.tb_VINB1.Size = new System.Drawing.Size(36, 20);
            this.tb_VINB1.TabIndex = 5;
            this.tb_VINB1.Text = "1024";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "VINB";
            // 
            // CMOS1SetDAC2
            // 
            this.CMOS1SetDAC2.Location = new System.Drawing.Point(81, 37);
            this.CMOS1SetDAC2.Name = "CMOS1SetDAC2";
            this.CMOS1SetDAC2.Size = new System.Drawing.Size(51, 23);
            this.CMOS1SetDAC2.TabIndex = 3;
            this.CMOS1SetDAC2.Text = "Задать";
            this.CMOS1SetDAC2.UseVisualStyleBackColor = true;
            this.CMOS1SetDAC2.Click += new System.EventHandler(this.CMOS1SetDAC2_Click);
            // 
            // tb_VREF1
            // 
            this.tb_VREF1.Location = new System.Drawing.Point(6, 13);
            this.tb_VREF1.Name = "tb_VREF1";
            this.tb_VREF1.Size = new System.Drawing.Size(36, 20);
            this.tb_VREF1.TabIndex = 2;
            this.tb_VREF1.Text = "1024";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "VREF";
            // 
            // bt_CMOS1SetDAC1
            // 
            this.bt_CMOS1SetDAC1.Location = new System.Drawing.Point(81, 11);
            this.bt_CMOS1SetDAC1.Name = "bt_CMOS1SetDAC1";
            this.bt_CMOS1SetDAC1.Size = new System.Drawing.Size(51, 23);
            this.bt_CMOS1SetDAC1.TabIndex = 0;
            this.bt_CMOS1SetDAC1.Text = "Задать";
            this.bt_CMOS1SetDAC1.UseVisualStyleBackColor = true;
            this.bt_CMOS1SetDAC1.Click += new System.EventHandler(this.bt_CMOS1SetDAC1_Click);
            // 
            // gbox_Image
            // 
            this.gbox_Image.Controls.Add(this.label29);
            this.gbox_Image.Controls.Add(this.pb_CMOS);
            this.gbox_Image.Controls.Add(this.pictureBox1);
            this.gbox_Image.Location = new System.Drawing.Point(6, 9);
            this.gbox_Image.Name = "gbox_Image";
            this.gbox_Image.Size = new System.Drawing.Size(651, 556);
            this.gbox_Image.TabIndex = 16;
            this.gbox_Image.TabStop = false;
            this.gbox_Image.Text = "Картинка";
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(514, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(0, 13);
            this.label29.TabIndex = 15;
            // 
            // pb_CMOS
            // 
            this.pb_CMOS.Location = new System.Drawing.Point(6, 532);
            this.pb_CMOS.Name = "pb_CMOS";
            this.pb_CMOS.Size = new System.Drawing.Size(638, 17);
            this.pb_CMOS.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(6, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(638, 510);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // gbox_CAN
            // 
            this.gbox_CAN.Controls.Add(this.lb_noerr);
            this.gbox_CAN.Controls.Add(this.comboBox1);
            this.gbox_CAN.Controls.Add(this.lb_error_CAN);
            this.gbox_CAN.Controls.Add(this.label7);
            this.gbox_CAN.Controls.Add(this.bt_CloseCAN);
            this.gbox_CAN.Controls.Add(this.bt_OpenCAN);
            this.gbox_CAN.Location = new System.Drawing.Point(6, 571);
            this.gbox_CAN.Name = "gbox_CAN";
            this.gbox_CAN.Size = new System.Drawing.Size(240, 78);
            this.gbox_CAN.TabIndex = 15;
            this.gbox_CAN.TabStop = false;
            this.gbox_CAN.Text = "CAN";
            // 
            // lb_noerr
            // 
            this.lb_noerr.BackColor = System.Drawing.Color.SpringGreen;
            this.lb_noerr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_noerr.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_noerr.Location = new System.Drawing.Point(6, 49);
            this.lb_noerr.Name = "lb_noerr";
            this.lb_noerr.Size = new System.Drawing.Size(228, 21);
            this.lb_noerr.TabIndex = 15;
            this.lb_noerr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_noerr.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(93, 21);
            this.comboBox1.TabIndex = 29;
            // 
            // lb_error_CAN
            // 
            this.lb_error_CAN.BackColor = System.Drawing.Color.Red;
            this.lb_error_CAN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_error_CAN.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_error_CAN.Location = new System.Drawing.Point(6, 49);
            this.lb_error_CAN.Name = "lb_error_CAN";
            this.lb_error_CAN.Size = new System.Drawing.Size(228, 21);
            this.lb_error_CAN.TabIndex = 14;
            this.lb_error_CAN.Text = "Не удалось открыть CAN";
            this.lb_error_CAN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_error_CAN.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(159, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 10;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_CloseCAN
            // 
            this.bt_CloseCAN.Enabled = false;
            this.bt_CloseCAN.Location = new System.Drawing.Point(171, 19);
            this.bt_CloseCAN.Name = "bt_CloseCAN";
            this.bt_CloseCAN.Size = new System.Drawing.Size(63, 23);
            this.bt_CloseCAN.TabIndex = 2;
            this.bt_CloseCAN.Text = "Закрыть";
            this.bt_CloseCAN.UseVisualStyleBackColor = true;
            this.bt_CloseCAN.Click += new System.EventHandler(this.bt_CloseCAN_Click);
            // 
            // bt_OpenCAN
            // 
            this.bt_OpenCAN.Location = new System.Drawing.Point(105, 19);
            this.bt_OpenCAN.Name = "bt_OpenCAN";
            this.bt_OpenCAN.Size = new System.Drawing.Size(60, 23);
            this.bt_OpenCAN.TabIndex = 0;
            this.bt_OpenCAN.Text = "Открыть";
            this.bt_OpenCAN.UseVisualStyleBackColor = true;
            this.bt_OpenCAN.Click += new System.EventHandler(this.bt_OpenCAN_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.gb1_Addr);
            this.tabPage2.Controls.Add(this.bt_About1);
            this.tabPage2.Controls.Add(this.bt_Exit1);
            this.tabPage2.Controls.Add(this.gb_MC1);
            this.tabPage2.Controls.Add(this.gb_CAN1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(962, 654);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Загрузка ПО";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(567, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 39;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(485, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 38;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // gb1_Addr
            // 
            this.gb1_Addr.Controls.Add(this.rb1_addr_right);
            this.gb1_Addr.Controls.Add(this.rb1_addr_left);
            this.gb1_Addr.Controls.Add(this.rb1_addr_uni);
            this.gb1_Addr.Location = new System.Drawing.Point(6, 70);
            this.gb1_Addr.Name = "gb1_Addr";
            this.gb1_Addr.Size = new System.Drawing.Size(463, 49);
            this.gb1_Addr.TabIndex = 37;
            this.gb1_Addr.TabStop = false;
            this.gb1_Addr.Text = "Адрес прошивки";
            // 
            // rb1_addr_right
            // 
            this.rb1_addr_right.AutoSize = true;
            this.rb1_addr_right.Enabled = false;
            this.rb1_addr_right.Location = new System.Drawing.Point(267, 19);
            this.rb1_addr_right.Name = "rb1_addr_right";
            this.rb1_addr_right.Size = new System.Drawing.Size(147, 17);
            this.rb1_addr_right.TabIndex = 2;
            this.rb1_addr_right.Text = "Прошивка ОЛО-Правый";
            this.rb1_addr_right.UseVisualStyleBackColor = true;
            // 
            // rb1_addr_left
            // 
            this.rb1_addr_left.AutoSize = true;
            this.rb1_addr_left.Enabled = false;
            this.rb1_addr_left.Location = new System.Drawing.Point(120, 20);
            this.rb1_addr_left.Name = "rb1_addr_left";
            this.rb1_addr_left.Size = new System.Drawing.Size(141, 17);
            this.rb1_addr_left.TabIndex = 1;
            this.rb1_addr_left.Text = "Прошивка ОЛО-Левый";
            this.rb1_addr_left.UseVisualStyleBackColor = true;
            // 
            // rb1_addr_uni
            // 
            this.rb1_addr_uni.AutoSize = true;
            this.rb1_addr_uni.Checked = true;
            this.rb1_addr_uni.Location = new System.Drawing.Point(9, 20);
            this.rb1_addr_uni.Name = "rb1_addr_uni";
            this.rb1_addr_uni.Size = new System.Drawing.Size(105, 17);
            this.rb1_addr_uni.TabIndex = 0;
            this.rb1_addr_uni.TabStop = true;
            this.rb1_addr_uni.Text = "Универсальная";
            this.rb1_addr_uni.UseVisualStyleBackColor = true;
            // 
            // bt_About1
            // 
            this.bt_About1.Location = new System.Drawing.Point(839, 592);
            this.bt_About1.Name = "bt_About1";
            this.bt_About1.Size = new System.Drawing.Size(108, 23);
            this.bt_About1.TabIndex = 36;
            this.bt_About1.Text = "О программе";
            this.bt_About1.UseVisualStyleBackColor = true;
            this.bt_About1.Click += new System.EventHandler(this.bt_About_Click);
            // 
            // bt_Exit1
            // 
            this.bt_Exit1.Location = new System.Drawing.Point(839, 621);
            this.bt_Exit1.Name = "bt_Exit1";
            this.bt_Exit1.Size = new System.Drawing.Size(108, 23);
            this.bt_Exit1.TabIndex = 35;
            this.bt_Exit1.Text = "Выход";
            this.bt_Exit1.UseVisualStyleBackColor = true;
            this.bt_Exit1.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // gb_MC1
            // 
            this.gb_MC1.Controls.Add(this.rb_flight_universal);
            this.gb_MC1.Controls.Add(this.rb_new_RUP);
            this.gb_MC1.Controls.Add(this.rb_cmos12_select2);
            this.gb_MC1.Controls.Add(this.rb_cmos12_select_long_time2);
            this.gb_MC1.Controls.Add(this.chb1_need_reset);
            this.gb_MC1.Controls.Add(this.rb_file_open);
            this.gb_MC1.Controls.Add(this.label25);
            this.gb_MC1.Controls.Add(this.label24);
            this.gb_MC1.Controls.Add(this.rb_flight_right_wing_double_pass);
            this.gb_MC1.Controls.Add(this.rb_flight_left_wing_double_pass);
            this.gb_MC1.Controls.Add(this.rb_cmos12_select);
            this.gb_MC1.Controls.Add(this.rb_cmos12_select_long_time);
            this.gb_MC1.Controls.Add(this.tb_fnameMC1);
            this.gb_MC1.Controls.Add(this.pb_loadMC1);
            this.gb_MC1.Controls.Add(this.chb_eraseALL1);
            this.gb_MC1.Controls.Add(this.bt_runMC1);
            this.gb_MC1.Controls.Add(this.lb_Load_OK1);
            this.gb_MC1.Controls.Add(this.bt_loadMC1);
            this.gb_MC1.Controls.Add(this.bt_openMC1);
            this.gb_MC1.Location = new System.Drawing.Point(6, 131);
            this.gb_MC1.Name = "gb_MC1";
            this.gb_MC1.Size = new System.Drawing.Size(463, 513);
            this.gb_MC1.TabIndex = 7;
            this.gb_MC1.TabStop = false;
            this.gb_MC1.Text = "Микропрограмма";
            // 
            // rb_flight_universal
            // 
            this.rb_flight_universal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_flight_universal.Location = new System.Drawing.Point(9, 272);
            this.rb_flight_universal.Name = "rb_flight_universal";
            this.rb_flight_universal.Size = new System.Drawing.Size(444, 17);
            this.rb_flight_universal.TabIndex = 39;
            this.rb_flight_universal.Text = "Загрузка прошивки \"FLIGHT_UNIVERSAL\"";
            this.rb_flight_universal.UseVisualStyleBackColor = true;
            this.rb_flight_universal.CheckedChanged += new System.EventHandler(this.rb_flight_universal_CheckedChanged);
            // 
            // rb_new_RUP
            // 
            this.rb_new_RUP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_new_RUP.Location = new System.Drawing.Point(9, 167);
            this.rb_new_RUP.Name = "rb_new_RUP";
            this.rb_new_RUP.Size = new System.Drawing.Size(444, 17);
            this.rb_new_RUP.TabIndex = 38;
            this.rb_new_RUP.Text = "Загрузка прошивки МУП";
            this.rb_new_RUP.UseVisualStyleBackColor = true;
            this.rb_new_RUP.CheckedChanged += new System.EventHandler(this.rb_new_RUP_CheckedChanged);
            // 
            // rb_cmos12_select2
            // 
            this.rb_cmos12_select2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_cmos12_select2.Location = new System.Drawing.Point(9, 144);
            this.rb_cmos12_select2.Name = "rb_cmos12_select2";
            this.rb_cmos12_select2.Size = new System.Drawing.Size(444, 17);
            this.rb_cmos12_select2.TabIndex = 37;
            this.rb_cmos12_select2.Text = "Загрузка прошивки \"SOLO2_SELECT 2\"";
            this.rb_cmos12_select2.UseVisualStyleBackColor = true;
            this.rb_cmos12_select2.CheckedChanged += new System.EventHandler(this.rb_cmos12_select2_CheckedChanged);
            // 
            // rb_cmos12_select_long_time2
            // 
            this.rb_cmos12_select_long_time2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_cmos12_select_long_time2.Location = new System.Drawing.Point(9, 121);
            this.rb_cmos12_select_long_time2.Name = "rb_cmos12_select_long_time2";
            this.rb_cmos12_select_long_time2.Size = new System.Drawing.Size(444, 17);
            this.rb_cmos12_select_long_time2.TabIndex = 36;
            this.rb_cmos12_select_long_time2.Text = "Загрузка прошивки \"SOLO2_SELECT_LONG_TIME 2\"";
            this.rb_cmos12_select_long_time2.UseVisualStyleBackColor = true;
            this.rb_cmos12_select_long_time2.CheckedChanged += new System.EventHandler(this.rb_cmos12_select_long_time2_CheckedChanged);
            // 
            // chb1_need_reset
            // 
            this.chb1_need_reset.AutoSize = true;
            this.chb1_need_reset.Location = new System.Drawing.Point(113, 481);
            this.chb1_need_reset.Name = "chb1_need_reset";
            this.chb1_need_reset.Size = new System.Drawing.Size(57, 17);
            this.chb1_need_reset.TabIndex = 35;
            this.chb1_need_reset.Text = "Сброс";
            this.chb1_need_reset.UseVisualStyleBackColor = true;
            // 
            // rb_file_open
            // 
            this.rb_file_open.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rb_file_open.Checked = true;
            this.rb_file_open.Location = new System.Drawing.Point(436, 23);
            this.rb_file_open.Name = "rb_file_open";
            this.rb_file_open.Size = new System.Drawing.Size(17, 17);
            this.rb_file_open.TabIndex = 31;
            this.rb_file_open.TabStop = true;
            this.rb_file_open.UseVisualStyleBackColor = true;
            this.rb_file_open.CheckedChanged += new System.EventHandler(this.rb_file_open_CheckedChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.Location = new System.Drawing.Point(6, 55);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(158, 13);
            this.label25.TabIndex = 30;
            this.label25.Text = "Прошивки для настройки";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.Location = new System.Drawing.Point(6, 198);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(114, 13);
            this.label24.TabIndex = 29;
            this.label24.Text = "Боевые прошивки";
            // 
            // rb_flight_right_wing_double_pass
            // 
            this.rb_flight_right_wing_double_pass.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_flight_right_wing_double_pass.Location = new System.Drawing.Point(9, 249);
            this.rb_flight_right_wing_double_pass.Name = "rb_flight_right_wing_double_pass";
            this.rb_flight_right_wing_double_pass.Size = new System.Drawing.Size(444, 17);
            this.rb_flight_right_wing_double_pass.TabIndex = 28;
            this.rb_flight_right_wing_double_pass.Text = "Загрузка прошивки \"SOLO2_FLIGHT_RIGHT\"";
            this.rb_flight_right_wing_double_pass.UseVisualStyleBackColor = true;
            this.rb_flight_right_wing_double_pass.CheckedChanged += new System.EventHandler(this.rb_flight_right_wing_double_pass_CheckedChanged);
            // 
            // rb_flight_left_wing_double_pass
            // 
            this.rb_flight_left_wing_double_pass.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_flight_left_wing_double_pass.Location = new System.Drawing.Point(9, 226);
            this.rb_flight_left_wing_double_pass.Name = "rb_flight_left_wing_double_pass";
            this.rb_flight_left_wing_double_pass.Size = new System.Drawing.Size(444, 17);
            this.rb_flight_left_wing_double_pass.TabIndex = 27;
            this.rb_flight_left_wing_double_pass.Text = "Загрузка прошивки \"SOLO2_FLIGHT_LEFT\"";
            this.rb_flight_left_wing_double_pass.UseVisualStyleBackColor = true;
            this.rb_flight_left_wing_double_pass.CheckedChanged += new System.EventHandler(this.rb_flight_left_wing_double_pass_CheckedChanged);
            // 
            // rb_cmos12_select
            // 
            this.rb_cmos12_select.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_cmos12_select.Location = new System.Drawing.Point(9, 98);
            this.rb_cmos12_select.Name = "rb_cmos12_select";
            this.rb_cmos12_select.Size = new System.Drawing.Size(444, 17);
            this.rb_cmos12_select.TabIndex = 26;
            this.rb_cmos12_select.Text = "Загрузка прошивки \"SOLO2_SELECT\"";
            this.rb_cmos12_select.UseVisualStyleBackColor = true;
            this.rb_cmos12_select.CheckedChanged += new System.EventHandler(this.rb_cmos12_select_CheckedChanged);
            // 
            // rb_cmos12_select_long_time
            // 
            this.rb_cmos12_select_long_time.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_cmos12_select_long_time.Location = new System.Drawing.Point(9, 75);
            this.rb_cmos12_select_long_time.Name = "rb_cmos12_select_long_time";
            this.rb_cmos12_select_long_time.Size = new System.Drawing.Size(444, 17);
            this.rb_cmos12_select_long_time.TabIndex = 25;
            this.rb_cmos12_select_long_time.Text = "Загрузка прошивки \"SOLO2_SELECT_LONG_TIME\"";
            this.rb_cmos12_select_long_time.UseVisualStyleBackColor = true;
            this.rb_cmos12_select_long_time.CheckedChanged += new System.EventHandler(this.rb_cmos12_select_long_time_CheckedChanged);
            // 
            // tb_fnameMC1
            // 
            this.tb_fnameMC1.Location = new System.Drawing.Point(113, 22);
            this.tb_fnameMC1.Name = "tb_fnameMC1";
            this.tb_fnameMC1.Size = new System.Drawing.Size(317, 20);
            this.tb_fnameMC1.TabIndex = 24;
            // 
            // pb_loadMC1
            // 
            this.pb_loadMC1.Location = new System.Drawing.Point(113, 445);
            this.pb_loadMC1.Name = "pb_loadMC1";
            this.pb_loadMC1.Size = new System.Drawing.Size(337, 21);
            this.pb_loadMC1.Step = 1;
            this.pb_loadMC1.TabIndex = 21;
            this.pb_loadMC1.Visible = false;
            // 
            // chb_eraseALL1
            // 
            this.chb_eraseALL1.AutoSize = true;
            this.chb_eraseALL1.Enabled = false;
            this.chb_eraseALL1.Location = new System.Drawing.Point(6, 481);
            this.chb_eraseALL1.Name = "chb_eraseALL1";
            this.chb_eraseALL1.Size = new System.Drawing.Size(104, 17);
            this.chb_eraseALL1.TabIndex = 14;
            this.chb_eraseALL1.Text = "Стереть FLASH";
            this.chb_eraseALL1.UseVisualStyleBackColor = true;
            // 
            // bt_runMC1
            // 
            this.bt_runMC1.Location = new System.Drawing.Point(280, 477);
            this.bt_runMC1.Name = "bt_runMC1";
            this.bt_runMC1.Size = new System.Drawing.Size(170, 23);
            this.bt_runMC1.TabIndex = 11;
            this.bt_runMC1.Text = "Запустить программу в ОЛО";
            this.bt_runMC1.UseVisualStyleBackColor = true;
            this.bt_runMC1.Click += new System.EventHandler(this.bt_runMC_Click);
            // 
            // lb_Load_OK1
            // 
            this.lb_Load_OK1.AutoSize = true;
            this.lb_Load_OK1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Load_OK1.Location = new System.Drawing.Point(117, 449);
            this.lb_Load_OK1.Name = "lb_Load_OK1";
            this.lb_Load_OK1.Size = new System.Drawing.Size(0, 13);
            this.lb_Load_OK1.TabIndex = 7;
            this.lb_Load_OK1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Load_OK1.Visible = false;
            // 
            // bt_loadMC1
            // 
            this.bt_loadMC1.Enabled = false;
            this.bt_loadMC1.Location = new System.Drawing.Point(6, 444);
            this.bt_loadMC1.Name = "bt_loadMC1";
            this.bt_loadMC1.Size = new System.Drawing.Size(101, 23);
            this.bt_loadMC1.TabIndex = 2;
            this.bt_loadMC1.Text = "Загрузить файл";
            this.bt_loadMC1.UseVisualStyleBackColor = true;
            this.bt_loadMC1.Click += new System.EventHandler(this.bt_loadMC1_Click);
            // 
            // bt_openMC1
            // 
            this.bt_openMC1.Location = new System.Drawing.Point(6, 20);
            this.bt_openMC1.Name = "bt_openMC1";
            this.bt_openMC1.Size = new System.Drawing.Size(101, 23);
            this.bt_openMC1.TabIndex = 0;
            this.bt_openMC1.Text = "Открыть файл";
            this.bt_openMC1.UseVisualStyleBackColor = true;
            this.bt_openMC1.Click += new System.EventHandler(this.bt_openMC1_Click);
            // 
            // gb_CAN1
            // 
            this.gb_CAN1.Controls.Add(this.lb_noerr1);
            this.gb_CAN1.Controls.Add(this.lb_error_CAN1);
            this.gb_CAN1.Controls.Add(this.cb_CAN1);
            this.gb_CAN1.Location = new System.Drawing.Point(6, 9);
            this.gb_CAN1.Name = "gb_CAN1";
            this.gb_CAN1.Size = new System.Drawing.Size(463, 50);
            this.gb_CAN1.TabIndex = 6;
            this.gb_CAN1.TabStop = false;
            this.gb_CAN1.Text = "CAN";
            // 
            // lb_noerr1
            // 
            this.lb_noerr1.BackColor = System.Drawing.Color.SpringGreen;
            this.lb_noerr1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_noerr1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_noerr1.Location = new System.Drawing.Point(150, 19);
            this.lb_noerr1.Name = "lb_noerr1";
            this.lb_noerr1.Size = new System.Drawing.Size(307, 21);
            this.lb_noerr1.TabIndex = 12;
            this.lb_noerr1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_noerr1.Visible = false;
            // 
            // lb_error_CAN1
            // 
            this.lb_error_CAN1.BackColor = System.Drawing.Color.Red;
            this.lb_error_CAN1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_error_CAN1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_error_CAN1.Location = new System.Drawing.Point(150, 19);
            this.lb_error_CAN1.Name = "lb_error_CAN1";
            this.lb_error_CAN1.Size = new System.Drawing.Size(307, 21);
            this.lb_error_CAN1.TabIndex = 11;
            this.lb_error_CAN1.Text = "Не удалось открыть CAN";
            this.lb_error_CAN1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_error_CAN1.Visible = false;
            // 
            // cb_CAN1
            // 
            this.cb_CAN1.FormattingEnabled = true;
            this.cb_CAN1.Location = new System.Drawing.Point(6, 19);
            this.cb_CAN1.Name = "cb_CAN1";
            this.cb_CAN1.Size = new System.Drawing.Size(138, 21);
            this.cb_CAN1.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rb2_piv11);
            this.tabPage3.Controls.Add(this.rb2_piv10);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.rtb2_datagrid);
            this.tabPage3.Controls.Add(this.cb_clear_shot);
            this.tabPage3.Controls.Add(this.label42);
            this.tabPage3.Controls.Add(this.label37);
            this.tabPage3.Controls.Add(this.gb_stR2);
            this.tabPage3.Controls.Add(this.gb_stL2);
            this.tabPage3.Controls.Add(this.btn_SAVESN);
            this.tabPage3.Controls.Add(this.tb_SN);
            this.tabPage3.Controls.Add(this.gbox_ecR2);
            this.tabPage3.Controls.Add(this.gbox_ecL2);
            this.tabPage3.Controls.Add(this.gbox_statusR2);
            this.tabPage3.Controls.Add(this.gbox_statusL2);
            this.tabPage3.Controls.Add(this.cb_module2);
            this.tabPage3.Controls.Add(this.bt_mod2);
            this.tabPage3.Controls.Add(this.REQ_VER);
            this.tabPage3.Controls.Add(this.chb3_savelog);
            this.tabPage3.Controls.Add(this.btn_REQSN);
            this.tabPage3.Controls.Add(this.btn_Reset);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.numericUpDown1);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.chb_dgview2);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.comboBox3);
            this.tabPage3.Controls.Add(this.bt_Request2);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.bt_SyncTime);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.comboBox2);
            this.tabPage3.Controls.Add(this.gbox_CAN2);
            this.tabPage3.Controls.Add(this.bt_About2);
            this.tabPage3.Controls.Add(this.bt_Exit2);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(962, 654);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Тестирование ОЛО (с боевой прошивкой)";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rb2_piv11
            // 
            this.rb2_piv11.AutoSize = true;
            this.rb2_piv11.Location = new System.Drawing.Point(692, 396);
            this.rb2_piv11.Name = "rb2_piv11";
            this.rb2_piv11.Size = new System.Drawing.Size(66, 17);
            this.rb2_piv11.TabIndex = 81;
            this.rb2_piv11.Text = "ПИВ 1.1";
            this.rb2_piv11.UseVisualStyleBackColor = true;
            // 
            // rb2_piv10
            // 
            this.rb2_piv10.AutoSize = true;
            this.rb2_piv10.Checked = true;
            this.rb2_piv10.Location = new System.Drawing.Point(620, 396);
            this.rb2_piv10.Name = "rb2_piv10";
            this.rb2_piv10.Size = new System.Drawing.Size(66, 17);
            this.rb2_piv10.TabIndex = 80;
            this.rb2_piv10.TabStop = true;
            this.rb2_piv10.Text = "ПИВ 1.0";
            this.rb2_piv10.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox1.Controls.Add(this.rb2_filter_all);
            this.groupBox1.Controls.Add(this.rb2_filter_7fff);
            this.groupBox1.Controls.Add(this.rb2_filter_data);
            this.groupBox1.Location = new System.Drawing.Point(620, 483);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 94);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтр";
            // 
            // rb2_filter_all
            // 
            this.rb2_filter_all.AutoSize = true;
            this.rb2_filter_all.Checked = true;
            this.rb2_filter_all.Location = new System.Drawing.Point(7, 19);
            this.rb2_filter_all.Name = "rb2_filter_all";
            this.rb2_filter_all.Size = new System.Drawing.Size(96, 17);
            this.rb2_filter_all.TabIndex = 76;
            this.rb2_filter_all.TabStop = true;
            this.rb2_filter_all.Text = "Выводить все";
            this.rb2_filter_all.UseVisualStyleBackColor = true;
            // 
            // rb2_filter_7fff
            // 
            this.rb2_filter_7fff.AutoSize = true;
            this.rb2_filter_7fff.Location = new System.Drawing.Point(6, 64);
            this.rb2_filter_7fff.Name = "rb2_filter_7fff";
            this.rb2_filter_7fff.Size = new System.Drawing.Size(100, 17);
            this.rb2_filter_7fff.TabIndex = 78;
            this.rb2_filter_7fff.Text = "Только 0x7FFF";
            this.rb2_filter_7fff.UseVisualStyleBackColor = true;
            // 
            // rb2_filter_data
            // 
            this.rb2_filter_data.AutoSize = true;
            this.rb2_filter_data.Location = new System.Drawing.Point(7, 41);
            this.rb2_filter_data.Name = "rb2_filter_data";
            this.rb2_filter_data.Size = new System.Drawing.Size(103, 17);
            this.rb2_filter_data.TabIndex = 77;
            this.rb2_filter_data.Text = "Только данные";
            this.rb2_filter_data.UseVisualStyleBackColor = true;
            // 
            // rtb2_datagrid
            // 
            this.rtb2_datagrid.DetectUrls = false;
            this.rtb2_datagrid.Location = new System.Drawing.Point(6, 245);
            this.rtb2_datagrid.Name = "rtb2_datagrid";
            this.rtb2_datagrid.Size = new System.Drawing.Size(607, 399);
            this.rtb2_datagrid.TabIndex = 75;
            this.rtb2_datagrid.Text = "";
            this.rtb2_datagrid.WordWrap = false;
            // 
            // cb_clear_shot
            // 
            this.cb_clear_shot.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_clear_shot.AutoSize = true;
            this.cb_clear_shot.Location = new System.Drawing.Point(717, 454);
            this.cb_clear_shot.Name = "cb_clear_shot";
            this.cb_clear_shot.Size = new System.Drawing.Size(112, 23);
            this.cb_clear_shot.TabIndex = 74;
            this.cb_clear_shot.Text = "Стирать выстрелы";
            this.cb_clear_shot.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(884, 459);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(0, 13);
            this.label42.TabIndex = 73;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(918, 459);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(0, 13);
            this.label37.TabIndex = 72;
            // 
            // gb_stR2
            // 
            this.gb_stR2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gb_stR2.Controls.Add(this.lb_stR2_cmos2);
            this.gb_stR2.Controls.Add(this.label46);
            this.gb_stR2.Controls.Add(this.lb_stR2_cmos1);
            this.gb_stR2.Controls.Add(this.label54);
            this.gb_stR2.Enabled = false;
            this.gb_stR2.Location = new System.Drawing.Point(791, 332);
            this.gb_stR2.Name = "gb_stR2";
            this.gb_stR2.Size = new System.Drawing.Size(163, 58);
            this.gb_stR2.TabIndex = 71;
            this.gb_stR2.TabStop = false;
            this.gb_stR2.Text = "Среднее значение";
            // 
            // lb_stR2_cmos2
            // 
            this.lb_stR2_cmos2.AutoSize = true;
            this.lb_stR2_cmos2.Location = new System.Drawing.Point(59, 38);
            this.lb_stR2_cmos2.Name = "lb_stR2_cmos2";
            this.lb_stR2_cmos2.Size = new System.Drawing.Size(25, 13);
            this.lb_stR2_cmos2.TabIndex = 7;
            this.lb_stR2_cmos2.Text = "      ";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(6, 38);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(44, 13);
            this.label46.TabIndex = 6;
            this.label46.Text = "CMOS2";
            // 
            // lb_stR2_cmos1
            // 
            this.lb_stR2_cmos1.AutoSize = true;
            this.lb_stR2_cmos1.Location = new System.Drawing.Point(59, 18);
            this.lb_stR2_cmos1.Name = "lb_stR2_cmos1";
            this.lb_stR2_cmos1.Size = new System.Drawing.Size(25, 13);
            this.lb_stR2_cmos1.TabIndex = 5;
            this.lb_stR2_cmos1.Text = "      ";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(6, 18);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(44, 13);
            this.label54.TabIndex = 4;
            this.label54.Text = "CMOS1";
            // 
            // gb_stL2
            // 
            this.gb_stL2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gb_stL2.Controls.Add(this.lb_stL2_cmos2);
            this.gb_stL2.Controls.Add(this.label33);
            this.gb_stL2.Controls.Add(this.lb_stL2_cmos1);
            this.gb_stL2.Controls.Add(this.label40);
            this.gb_stL2.Enabled = false;
            this.gb_stL2.Location = new System.Drawing.Point(620, 332);
            this.gb_stL2.Name = "gb_stL2";
            this.gb_stL2.Size = new System.Drawing.Size(163, 58);
            this.gb_stL2.TabIndex = 70;
            this.gb_stL2.TabStop = false;
            this.gb_stL2.Text = "Среднее значение";
            // 
            // lb_stL2_cmos2
            // 
            this.lb_stL2_cmos2.AutoSize = true;
            this.lb_stL2_cmos2.Location = new System.Drawing.Point(59, 38);
            this.lb_stL2_cmos2.Name = "lb_stL2_cmos2";
            this.lb_stL2_cmos2.Size = new System.Drawing.Size(25, 13);
            this.lb_stL2_cmos2.TabIndex = 7;
            this.lb_stL2_cmos2.Text = "      ";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 38);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(44, 13);
            this.label33.TabIndex = 6;
            this.label33.Text = "CMOS2";
            // 
            // lb_stL2_cmos1
            // 
            this.lb_stL2_cmos1.AutoSize = true;
            this.lb_stL2_cmos1.Location = new System.Drawing.Point(59, 18);
            this.lb_stL2_cmos1.Name = "lb_stL2_cmos1";
            this.lb_stL2_cmos1.Size = new System.Drawing.Size(25, 13);
            this.lb_stL2_cmos1.TabIndex = 5;
            this.lb_stL2_cmos1.Text = "      ";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 18);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(44, 13);
            this.label40.TabIndex = 4;
            this.label40.Text = "CMOS1";
            // 
            // btn_SAVESN
            // 
            this.btn_SAVESN.Location = new System.Drawing.Point(108, 187);
            this.btn_SAVESN.Name = "btn_SAVESN";
            this.btn_SAVESN.Size = new System.Drawing.Size(87, 23);
            this.btn_SAVESN.TabIndex = 69;
            this.btn_SAVESN.Text = "Запись SN";
            this.btn_SAVESN.UseVisualStyleBackColor = true;
            this.btn_SAVESN.Visible = false;
            this.btn_SAVESN.Click += new System.EventHandler(this.btn_SAVESN_Click);
            // 
            // tb_SN
            // 
            this.tb_SN.Location = new System.Drawing.Point(137, 160);
            this.tb_SN.Name = "tb_SN";
            this.tb_SN.Size = new System.Drawing.Size(58, 20);
            this.tb_SN.TabIndex = 68;
            this.tb_SN.Visible = false;
            // 
            // gbox_ecR2
            // 
            this.gbox_ecR2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gbox_ecR2.Controls.Add(this.lb_ecR2_ram2);
            this.gbox_ecR2.Controls.Add(this.label44);
            this.gbox_ecR2.Controls.Add(this.lb_ecR2_ram1);
            this.gbox_ecR2.Controls.Add(this.label48);
            this.gbox_ecR2.Controls.Add(this.lb_ecR2_ram);
            this.gbox_ecR2.Controls.Add(this.label52);
            this.gbox_ecR2.Controls.Add(this.lb_ecR2_file);
            this.gbox_ecR2.Controls.Add(this.label55);
            this.gbox_ecR2.Controls.Add(this.lb_ecR2_plis2);
            this.gbox_ecR2.Controls.Add(this.label57);
            this.gbox_ecR2.Controls.Add(this.lb_ecR2_plis1);
            this.gbox_ecR2.Controls.Add(this.label59);
            this.gbox_ecR2.Enabled = false;
            this.gbox_ecR2.Location = new System.Drawing.Point(791, 187);
            this.gbox_ecR2.Name = "gbox_ecR2";
            this.gbox_ecR2.Size = new System.Drawing.Size(163, 139);
            this.gbox_ecR2.TabIndex = 67;
            this.gbox_ecR2.TabStop = false;
            this.gbox_ecR2.Text = "Контроль ОЛО-П";
            // 
            // lb_ecR2_ram2
            // 
            this.lb_ecR2_ram2.AutoSize = true;
            this.lb_ecR2_ram2.Location = new System.Drawing.Point(59, 118);
            this.lb_ecR2_ram2.Name = "lb_ecR2_ram2";
            this.lb_ecR2_ram2.Size = new System.Drawing.Size(25, 13);
            this.lb_ecR2_ram2.TabIndex = 11;
            this.lb_ecR2_ram2.Text = "      ";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(6, 118);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(36, 13);
            this.label44.TabIndex = 10;
            this.label44.Text = "ОЗУ2";
            // 
            // lb_ecR2_ram1
            // 
            this.lb_ecR2_ram1.AutoSize = true;
            this.lb_ecR2_ram1.Location = new System.Drawing.Point(59, 98);
            this.lb_ecR2_ram1.Name = "lb_ecR2_ram1";
            this.lb_ecR2_ram1.Size = new System.Drawing.Size(25, 13);
            this.lb_ecR2_ram1.TabIndex = 9;
            this.lb_ecR2_ram1.Text = "      ";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(6, 98);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(36, 13);
            this.label48.TabIndex = 8;
            this.label48.Text = "ОЗУ1";
            // 
            // lb_ecR2_ram
            // 
            this.lb_ecR2_ram.AutoSize = true;
            this.lb_ecR2_ram.Location = new System.Drawing.Point(59, 78);
            this.lb_ecR2_ram.Name = "lb_ecR2_ram";
            this.lb_ecR2_ram.Size = new System.Drawing.Size(25, 13);
            this.lb_ecR2_ram.TabIndex = 7;
            this.lb_ecR2_ram.Text = "      ";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(6, 78);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(30, 13);
            this.label52.TabIndex = 6;
            this.label52.Text = "ОЗУ";
            // 
            // lb_ecR2_file
            // 
            this.lb_ecR2_file.AutoSize = true;
            this.lb_ecR2_file.Location = new System.Drawing.Point(59, 58);
            this.lb_ecR2_file.Name = "lb_ecR2_file";
            this.lb_ecR2_file.Size = new System.Drawing.Size(25, 13);
            this.lb_ecR2_file.TabIndex = 5;
            this.lb_ecR2_file.Text = "      ";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(6, 58);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(44, 13);
            this.label55.TabIndex = 4;
            this.label55.Text = "Файлы";
            // 
            // lb_ecR2_plis2
            // 
            this.lb_ecR2_plis2.AutoSize = true;
            this.lb_ecR2_plis2.Location = new System.Drawing.Point(59, 38);
            this.lb_ecR2_plis2.Name = "lb_ecR2_plis2";
            this.lb_ecR2_plis2.Size = new System.Drawing.Size(25, 13);
            this.lb_ecR2_plis2.TabIndex = 3;
            this.lb_ecR2_plis2.Text = "      ";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(6, 38);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(44, 13);
            this.label57.TabIndex = 2;
            this.label57.Text = "ПЛИС2";
            // 
            // lb_ecR2_plis1
            // 
            this.lb_ecR2_plis1.AutoSize = true;
            this.lb_ecR2_plis1.Location = new System.Drawing.Point(59, 18);
            this.lb_ecR2_plis1.Name = "lb_ecR2_plis1";
            this.lb_ecR2_plis1.Size = new System.Drawing.Size(25, 13);
            this.lb_ecR2_plis1.TabIndex = 1;
            this.lb_ecR2_plis1.Text = "      ";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(6, 18);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(44, 13);
            this.label59.TabIndex = 0;
            this.label59.Text = "ПЛИС1";
            // 
            // gbox_ecL2
            // 
            this.gbox_ecL2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gbox_ecL2.Controls.Add(this.lb_ecL2_ram2);
            this.gbox_ecL2.Controls.Add(this.label65);
            this.gbox_ecL2.Controls.Add(this.lb_ecL2_ram1);
            this.gbox_ecL2.Controls.Add(this.label67);
            this.gbox_ecL2.Controls.Add(this.lb_ecL2_ram);
            this.gbox_ecL2.Controls.Add(this.label69);
            this.gbox_ecL2.Controls.Add(this.lb_ecL2_file);
            this.gbox_ecL2.Controls.Add(this.label71);
            this.gbox_ecL2.Controls.Add(this.lb_ecL2_plis2);
            this.gbox_ecL2.Controls.Add(this.label73);
            this.gbox_ecL2.Controls.Add(this.lb_ecL2_plis1);
            this.gbox_ecL2.Controls.Add(this.label75);
            this.gbox_ecL2.Enabled = false;
            this.gbox_ecL2.Location = new System.Drawing.Point(620, 187);
            this.gbox_ecL2.Name = "gbox_ecL2";
            this.gbox_ecL2.Size = new System.Drawing.Size(163, 139);
            this.gbox_ecL2.TabIndex = 66;
            this.gbox_ecL2.TabStop = false;
            this.gbox_ecL2.Text = "Контроль ОЛО-Л";
            // 
            // lb_ecL2_ram2
            // 
            this.lb_ecL2_ram2.AutoSize = true;
            this.lb_ecL2_ram2.Location = new System.Drawing.Point(59, 118);
            this.lb_ecL2_ram2.Name = "lb_ecL2_ram2";
            this.lb_ecL2_ram2.Size = new System.Drawing.Size(25, 13);
            this.lb_ecL2_ram2.TabIndex = 11;
            this.lb_ecL2_ram2.Text = "      ";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(6, 118);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(36, 13);
            this.label65.TabIndex = 10;
            this.label65.Text = "ОЗУ2";
            // 
            // lb_ecL2_ram1
            // 
            this.lb_ecL2_ram1.AutoSize = true;
            this.lb_ecL2_ram1.Location = new System.Drawing.Point(59, 98);
            this.lb_ecL2_ram1.Name = "lb_ecL2_ram1";
            this.lb_ecL2_ram1.Size = new System.Drawing.Size(25, 13);
            this.lb_ecL2_ram1.TabIndex = 9;
            this.lb_ecL2_ram1.Text = "      ";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(6, 98);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(36, 13);
            this.label67.TabIndex = 8;
            this.label67.Text = "ОЗУ1";
            // 
            // lb_ecL2_ram
            // 
            this.lb_ecL2_ram.AutoSize = true;
            this.lb_ecL2_ram.Location = new System.Drawing.Point(59, 78);
            this.lb_ecL2_ram.Name = "lb_ecL2_ram";
            this.lb_ecL2_ram.Size = new System.Drawing.Size(25, 13);
            this.lb_ecL2_ram.TabIndex = 7;
            this.lb_ecL2_ram.Text = "      ";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(6, 78);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(30, 13);
            this.label69.TabIndex = 6;
            this.label69.Text = "ОЗУ";
            // 
            // lb_ecL2_file
            // 
            this.lb_ecL2_file.AutoSize = true;
            this.lb_ecL2_file.Location = new System.Drawing.Point(59, 58);
            this.lb_ecL2_file.Name = "lb_ecL2_file";
            this.lb_ecL2_file.Size = new System.Drawing.Size(25, 13);
            this.lb_ecL2_file.TabIndex = 5;
            this.lb_ecL2_file.Text = "      ";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(6, 58);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(44, 13);
            this.label71.TabIndex = 4;
            this.label71.Text = "Файлы";
            // 
            // lb_ecL2_plis2
            // 
            this.lb_ecL2_plis2.AutoSize = true;
            this.lb_ecL2_plis2.Location = new System.Drawing.Point(59, 38);
            this.lb_ecL2_plis2.Name = "lb_ecL2_plis2";
            this.lb_ecL2_plis2.Size = new System.Drawing.Size(25, 13);
            this.lb_ecL2_plis2.TabIndex = 3;
            this.lb_ecL2_plis2.Text = "      ";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(6, 38);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(44, 13);
            this.label73.TabIndex = 2;
            this.label73.Text = "ПЛИС2";
            // 
            // lb_ecL2_plis1
            // 
            this.lb_ecL2_plis1.AutoSize = true;
            this.lb_ecL2_plis1.Location = new System.Drawing.Point(59, 18);
            this.lb_ecL2_plis1.Name = "lb_ecL2_plis1";
            this.lb_ecL2_plis1.Size = new System.Drawing.Size(25, 13);
            this.lb_ecL2_plis1.TabIndex = 1;
            this.lb_ecL2_plis1.Text = "      ";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(6, 18);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(44, 13);
            this.label75.TabIndex = 0;
            this.label75.Text = "ПЛИС1";
            // 
            // gbox_statusR2
            // 
            this.gbox_statusR2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gbox_statusR2.Controls.Add(this.lb_statusR_t32);
            this.gbox_statusR2.Controls.Add(this.label39);
            this.gbox_statusR2.Controls.Add(this.lb_statusR_t22);
            this.gbox_statusR2.Controls.Add(this.label41);
            this.gbox_statusR2.Controls.Add(this.lb_statusR_t12);
            this.gbox_statusR2.Controls.Add(this.label43);
            this.gbox_statusR2.Controls.Add(this.lb_statusR_file2);
            this.gbox_statusR2.Controls.Add(this.label45);
            this.gbox_statusR2.Controls.Add(this.lb_statusR_plis2);
            this.gbox_statusR2.Controls.Add(this.label47);
            this.gbox_statusR2.Controls.Add(this.lb_statusR_status2);
            this.gbox_statusR2.Controls.Add(this.label49);
            this.gbox_statusR2.Controls.Add(this.lb_statusR_reason2);
            this.gbox_statusR2.Controls.Add(this.label50);
            this.gbox_statusR2.Controls.Add(this.lb_statusR_mode2);
            this.gbox_statusR2.Controls.Add(this.label53);
            this.gbox_statusR2.Location = new System.Drawing.Point(791, 9);
            this.gbox_statusR2.Name = "gbox_statusR2";
            this.gbox_statusR2.Size = new System.Drawing.Size(163, 174);
            this.gbox_statusR2.TabIndex = 65;
            this.gbox_statusR2.TabStop = false;
            this.gbox_statusR2.Text = "Статус ОЛО-П";
            // 
            // lb_statusR_t32
            // 
            this.lb_statusR_t32.AutoSize = true;
            this.lb_statusR_t32.Location = new System.Drawing.Point(59, 156);
            this.lb_statusR_t32.Name = "lb_statusR_t32";
            this.lb_statusR_t32.Size = new System.Drawing.Size(25, 13);
            this.lb_statusR_t32.TabIndex = 15;
            this.lb_statusR_t32.Text = "      ";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 156);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(48, 13);
            this.label39.TabIndex = 14;
            this.label39.Text = "T cmos2";
            // 
            // lb_statusR_t22
            // 
            this.lb_statusR_t22.AutoSize = true;
            this.lb_statusR_t22.Location = new System.Drawing.Point(59, 136);
            this.lb_statusR_t22.Name = "lb_statusR_t22";
            this.lb_statusR_t22.Size = new System.Drawing.Size(25, 13);
            this.lb_statusR_t22.TabIndex = 13;
            this.lb_statusR_t22.Text = "      ";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 136);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(48, 13);
            this.label41.TabIndex = 12;
            this.label41.Text = "T cmos1";
            // 
            // lb_statusR_t12
            // 
            this.lb_statusR_t12.AutoSize = true;
            this.lb_statusR_t12.Location = new System.Drawing.Point(59, 116);
            this.lb_statusR_t12.Name = "lb_statusR_t12";
            this.lb_statusR_t12.Size = new System.Drawing.Size(25, 13);
            this.lb_statusR_t12.TabIndex = 11;
            this.lb_statusR_t12.Text = "      ";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 116);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(37, 13);
            this.label43.TabIndex = 10;
            this.label43.Text = "Т арм";
            // 
            // lb_statusR_file2
            // 
            this.lb_statusR_file2.AutoSize = true;
            this.lb_statusR_file2.Location = new System.Drawing.Point(59, 96);
            this.lb_statusR_file2.Name = "lb_statusR_file2";
            this.lb_statusR_file2.Size = new System.Drawing.Size(25, 13);
            this.lb_statusR_file2.TabIndex = 9;
            this.lb_statusR_file2.Text = "      ";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 96);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(44, 13);
            this.label45.TabIndex = 8;
            this.label45.Text = "Файлы";
            // 
            // lb_statusR_plis2
            // 
            this.lb_statusR_plis2.AutoSize = true;
            this.lb_statusR_plis2.Location = new System.Drawing.Point(59, 76);
            this.lb_statusR_plis2.Name = "lb_statusR_plis2";
            this.lb_statusR_plis2.Size = new System.Drawing.Size(25, 13);
            this.lb_statusR_plis2.TabIndex = 7;
            this.lb_statusR_plis2.Text = "      ";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(6, 76);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(38, 13);
            this.label47.TabIndex = 6;
            this.label47.Text = "ПЛИС";
            // 
            // lb_statusR_status2
            // 
            this.lb_statusR_status2.AutoSize = true;
            this.lb_statusR_status2.Location = new System.Drawing.Point(59, 56);
            this.lb_statusR_status2.Name = "lb_statusR_status2";
            this.lb_statusR_status2.Size = new System.Drawing.Size(25, 13);
            this.lb_statusR_status2.TabIndex = 5;
            this.lb_statusR_status2.Text = "      ";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(6, 56);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(41, 13);
            this.label49.TabIndex = 4;
            this.label49.Text = "Статус";
            // 
            // lb_statusR_reason2
            // 
            this.lb_statusR_reason2.AutoSize = true;
            this.lb_statusR_reason2.Location = new System.Drawing.Point(59, 36);
            this.lb_statusR_reason2.Name = "lb_statusR_reason2";
            this.lb_statusR_reason2.Size = new System.Drawing.Size(25, 13);
            this.lb_statusR_reason2.TabIndex = 3;
            this.lb_statusR_reason2.Text = "      ";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(6, 36);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(50, 13);
            this.label50.TabIndex = 2;
            this.label50.Text = "Причина";
            // 
            // lb_statusR_mode2
            // 
            this.lb_statusR_mode2.AutoSize = true;
            this.lb_statusR_mode2.Location = new System.Drawing.Point(59, 16);
            this.lb_statusR_mode2.Name = "lb_statusR_mode2";
            this.lb_statusR_mode2.Size = new System.Drawing.Size(25, 13);
            this.lb_statusR_mode2.TabIndex = 1;
            this.lb_statusR_mode2.Text = "      ";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(6, 16);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(42, 13);
            this.label53.TabIndex = 0;
            this.label53.Text = "Режим";
            // 
            // gbox_statusL2
            // 
            this.gbox_statusL2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gbox_statusL2.Controls.Add(this.lb_statusL_t32);
            this.gbox_statusL2.Controls.Add(this.label31);
            this.gbox_statusL2.Controls.Add(this.lb_statusL_t22);
            this.gbox_statusL2.Controls.Add(this.label35);
            this.gbox_statusL2.Controls.Add(this.lb_statusL_t12);
            this.gbox_statusL2.Controls.Add(this.label34);
            this.gbox_statusL2.Controls.Add(this.lb_statusL_file2);
            this.gbox_statusL2.Controls.Add(this.label36);
            this.gbox_statusL2.Controls.Add(this.lb_statusL_plis2);
            this.gbox_statusL2.Controls.Add(this.label38);
            this.gbox_statusL2.Controls.Add(this.lb_statusL_status2);
            this.gbox_statusL2.Controls.Add(this.label32);
            this.gbox_statusL2.Controls.Add(this.lb_statusL_reason2);
            this.gbox_statusL2.Controls.Add(this.label30);
            this.gbox_statusL2.Controls.Add(this.lb_statusL_mode2);
            this.gbox_statusL2.Controls.Add(this.label28);
            this.gbox_statusL2.Location = new System.Drawing.Point(620, 9);
            this.gbox_statusL2.Name = "gbox_statusL2";
            this.gbox_statusL2.Size = new System.Drawing.Size(163, 174);
            this.gbox_statusL2.TabIndex = 64;
            this.gbox_statusL2.TabStop = false;
            this.gbox_statusL2.Text = "Статус ОЛО-Л";
            // 
            // lb_statusL_t32
            // 
            this.lb_statusL_t32.AutoSize = true;
            this.lb_statusL_t32.Location = new System.Drawing.Point(59, 156);
            this.lb_statusL_t32.Name = "lb_statusL_t32";
            this.lb_statusL_t32.Size = new System.Drawing.Size(25, 13);
            this.lb_statusL_t32.TabIndex = 15;
            this.lb_statusL_t32.Text = "      ";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 156);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 13);
            this.label31.TabIndex = 14;
            this.label31.Text = "T cmos2";
            // 
            // lb_statusL_t22
            // 
            this.lb_statusL_t22.AutoSize = true;
            this.lb_statusL_t22.Location = new System.Drawing.Point(59, 136);
            this.lb_statusL_t22.Name = "lb_statusL_t22";
            this.lb_statusL_t22.Size = new System.Drawing.Size(25, 13);
            this.lb_statusL_t22.TabIndex = 13;
            this.lb_statusL_t22.Text = "      ";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 136);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(48, 13);
            this.label35.TabIndex = 12;
            this.label35.Text = "T cmos1";
            // 
            // lb_statusL_t12
            // 
            this.lb_statusL_t12.AutoSize = true;
            this.lb_statusL_t12.Location = new System.Drawing.Point(59, 116);
            this.lb_statusL_t12.Name = "lb_statusL_t12";
            this.lb_statusL_t12.Size = new System.Drawing.Size(25, 13);
            this.lb_statusL_t12.TabIndex = 11;
            this.lb_statusL_t12.Text = "      ";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 116);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(37, 13);
            this.label34.TabIndex = 10;
            this.label34.Text = "Т арм";
            // 
            // lb_statusL_file2
            // 
            this.lb_statusL_file2.AutoSize = true;
            this.lb_statusL_file2.Location = new System.Drawing.Point(59, 96);
            this.lb_statusL_file2.Name = "lb_statusL_file2";
            this.lb_statusL_file2.Size = new System.Drawing.Size(25, 13);
            this.lb_statusL_file2.TabIndex = 9;
            this.lb_statusL_file2.Text = "      ";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(6, 96);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(44, 13);
            this.label36.TabIndex = 8;
            this.label36.Text = "Файлы";
            // 
            // lb_statusL_plis2
            // 
            this.lb_statusL_plis2.AutoSize = true;
            this.lb_statusL_plis2.Location = new System.Drawing.Point(59, 76);
            this.lb_statusL_plis2.Name = "lb_statusL_plis2";
            this.lb_statusL_plis2.Size = new System.Drawing.Size(25, 13);
            this.lb_statusL_plis2.TabIndex = 7;
            this.lb_statusL_plis2.Text = "      ";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 76);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(38, 13);
            this.label38.TabIndex = 6;
            this.label38.Text = "ПЛИС";
            // 
            // lb_statusL_status2
            // 
            this.lb_statusL_status2.AutoSize = true;
            this.lb_statusL_status2.Location = new System.Drawing.Point(59, 56);
            this.lb_statusL_status2.Name = "lb_statusL_status2";
            this.lb_statusL_status2.Size = new System.Drawing.Size(25, 13);
            this.lb_statusL_status2.TabIndex = 5;
            this.lb_statusL_status2.Text = "      ";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 56);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(41, 13);
            this.label32.TabIndex = 4;
            this.label32.Text = "Статус";
            // 
            // lb_statusL_reason2
            // 
            this.lb_statusL_reason2.AutoSize = true;
            this.lb_statusL_reason2.Location = new System.Drawing.Point(59, 36);
            this.lb_statusL_reason2.Name = "lb_statusL_reason2";
            this.lb_statusL_reason2.Size = new System.Drawing.Size(25, 13);
            this.lb_statusL_reason2.TabIndex = 3;
            this.lb_statusL_reason2.Text = "      ";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 36);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 13);
            this.label30.TabIndex = 2;
            this.label30.Text = "Причина";
            // 
            // lb_statusL_mode2
            // 
            this.lb_statusL_mode2.AutoSize = true;
            this.lb_statusL_mode2.Location = new System.Drawing.Point(59, 16);
            this.lb_statusL_mode2.Name = "lb_statusL_mode2";
            this.lb_statusL_mode2.Size = new System.Drawing.Size(25, 13);
            this.lb_statusL_mode2.TabIndex = 1;
            this.lb_statusL_mode2.Text = "      ";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(42, 13);
            this.label28.TabIndex = 0;
            this.label28.Text = "Режим";
            // 
            // cb_module2
            // 
            this.cb_module2.FormattingEnabled = true;
            this.cb_module2.Items.AddRange(new object[] {
            "Рабочий режим",
            "Режим самотестирования",
            "Встроенный контроль",
            "Режим программирования"});
            this.cb_module2.Location = new System.Drawing.Point(717, 426);
            this.cb_module2.Name = "cb_module2";
            this.cb_module2.Size = new System.Drawing.Size(158, 21);
            this.cb_module2.TabIndex = 63;
            this.cb_module2.Visible = false;
            // 
            // bt_mod2
            // 
            this.bt_mod2.Location = new System.Drawing.Point(620, 425);
            this.bt_mod2.Name = "bt_mod2";
            this.bt_mod2.Size = new System.Drawing.Size(91, 23);
            this.bt_mod2.TabIndex = 62;
            this.bt_mod2.Text = "Режим модуля";
            this.bt_mod2.UseVisualStyleBackColor = true;
            this.bt_mod2.Visible = false;
            this.bt_mod2.Click += new System.EventHandler(this.bt_mod2_Click);
            // 
            // REQ_VER
            // 
            this.REQ_VER.Location = new System.Drawing.Point(883, 424);
            this.REQ_VER.Name = "REQ_VER";
            this.REQ_VER.Size = new System.Drawing.Size(71, 23);
            this.REQ_VER.TabIndex = 61;
            this.REQ_VER.Text = "Версия прошивки";
            this.REQ_VER.UseVisualStyleBackColor = true;
            this.REQ_VER.Visible = false;
            this.REQ_VER.Click += new System.EventHandler(this.REQ_VER_Click);
            // 
            // chb3_savelog
            // 
            this.chb3_savelog.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb3_savelog.Location = new System.Drawing.Point(619, 454);
            this.chb3_savelog.Name = "chb3_savelog";
            this.chb3_savelog.Size = new System.Drawing.Size(91, 23);
            this.chb3_savelog.TabIndex = 60;
            this.chb3_savelog.Text = "Включить лог";
            this.chb3_savelog.UseVisualStyleBackColor = true;
            this.chb3_savelog.CheckedChanged += new System.EventHandler(this.chb3_savelog_CheckedChanged);
            // 
            // btn_REQSN
            // 
            this.btn_REQSN.Location = new System.Drawing.Point(8, 187);
            this.btn_REQSN.Name = "btn_REQSN";
            this.btn_REQSN.Size = new System.Drawing.Size(87, 23);
            this.btn_REQSN.TabIndex = 56;
            this.btn_REQSN.Text = "Запрос SN";
            this.btn_REQSN.UseVisualStyleBackColor = true;
            this.btn_REQSN.Visible = false;
            this.btn_REQSN.Click += new System.EventHandler(this.btn_REQSN_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(201, 187);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(181, 23);
            this.btn_Reset.TabIndex = 54;
            this.btn_Reset.Text = "Сброс ОЛО";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(410, 221);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(149, 18);
            this.label16.TabIndex = 53;
            this.label16.Text = "Таймер сброса выстрелов";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(565, 219);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
            this.numericUpDown1.TabIndex = 52;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 23);
            this.button1.TabIndex = 51;
            this.button1.Text = "Очистить грид";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chb_dgview2
            // 
            this.chb_dgview2.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_dgview2.BackColor = System.Drawing.Color.SpringGreen;
            this.chb_dgview2.Checked = true;
            this.chb_dgview2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_dgview2.Location = new System.Drawing.Point(201, 216);
            this.chb_dgview2.Name = "chb_dgview2";
            this.chb_dgview2.Size = new System.Drawing.Size(181, 23);
            this.chb_dgview2.TabIndex = 50;
            this.chb_dgview2.Text = "Скролл включен";
            this.chb_dgview2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_dgview2.UseVisualStyleBackColor = false;
            this.chb_dgview2.CheckedChanged += new System.EventHandler(this.chb_dgview2_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::OLO_CAN.Properties.Resources.olo10;
            this.panel1.Location = new System.Drawing.Point(413, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 200);
            this.panel1.TabIndex = 49;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "ОЛО левый борт",
            "ОЛО правый борт",
            "Широковещательный"});
            this.comboBox3.Location = new System.Drawing.Point(201, 101);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(181, 21);
            this.comboBox3.TabIndex = 47;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // bt_Request2
            // 
            this.bt_Request2.Location = new System.Drawing.Point(201, 128);
            this.bt_Request2.Name = "bt_Request2";
            this.bt_Request2.Size = new System.Drawing.Size(181, 23);
            this.bt_Request2.TabIndex = 46;
            this.bt_Request2.Text = "Отправить запрос";
            this.bt_Request2.UseVisualStyleBackColor = true;
            this.bt_Request2.Click += new System.EventHandler(this.bt_Request2_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(9, 163);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 45;
            this.label17.Text = "label17";
            // 
            // bt_SyncTime
            // 
            this.bt_SyncTime.Enabled = false;
            this.bt_SyncTime.Location = new System.Drawing.Point(201, 158);
            this.bt_SyncTime.Name = "bt_SyncTime";
            this.bt_SyncTime.Size = new System.Drawing.Size(181, 23);
            this.bt_SyncTime.TabIndex = 44;
            this.bt_SyncTime.Text = "Перевести в РУП";
            this.bt_SyncTime.UseVisualStyleBackColor = true;
            this.bt_SyncTime.Click += new System.EventHandler(this.bt_SyncTime_Click);
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(9, 101);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(192, 21);
            this.label18.TabIndex = 43;
            this.label18.Text = "Период выдачи статуса ";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "По запросу",
            "2 с",
            "1 с",
            "0.5 с"});
            this.comboBox2.Location = new System.Drawing.Point(12, 130);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(183, 21);
            this.comboBox2.TabIndex = 42;
            // 
            // gbox_CAN2
            // 
            this.gbox_CAN2.Controls.Add(this.lb_noerr2);
            this.gbox_CAN2.Controls.Add(this.cb_CAN2);
            this.gbox_CAN2.Controls.Add(this.lb_error_CAN2);
            this.gbox_CAN2.Controls.Add(this.label21);
            this.gbox_CAN2.Controls.Add(this.bt_CloseCAN2);
            this.gbox_CAN2.Controls.Add(this.bt_OpenCAN2);
            this.gbox_CAN2.Location = new System.Drawing.Point(6, 9);
            this.gbox_CAN2.Name = "gbox_CAN2";
            this.gbox_CAN2.Size = new System.Drawing.Size(369, 78);
            this.gbox_CAN2.TabIndex = 39;
            this.gbox_CAN2.TabStop = false;
            this.gbox_CAN2.Text = "CAN";
            // 
            // lb_noerr2
            // 
            this.lb_noerr2.BackColor = System.Drawing.Color.SpringGreen;
            this.lb_noerr2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_noerr2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_noerr2.Location = new System.Drawing.Point(6, 49);
            this.lb_noerr2.Name = "lb_noerr2";
            this.lb_noerr2.Size = new System.Drawing.Size(357, 21);
            this.lb_noerr2.TabIndex = 15;
            this.lb_noerr2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_noerr2.Visible = false;
            // 
            // cb_CAN2
            // 
            this.cb_CAN2.FormattingEnabled = true;
            this.cb_CAN2.Location = new System.Drawing.Point(6, 20);
            this.cb_CAN2.Name = "cb_CAN2";
            this.cb_CAN2.Size = new System.Drawing.Size(225, 21);
            this.cb_CAN2.TabIndex = 29;
            // 
            // lb_error_CAN2
            // 
            this.lb_error_CAN2.BackColor = System.Drawing.Color.Red;
            this.lb_error_CAN2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_error_CAN2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_error_CAN2.Location = new System.Drawing.Point(6, 49);
            this.lb_error_CAN2.Name = "lb_error_CAN2";
            this.lb_error_CAN2.Size = new System.Drawing.Size(357, 21);
            this.lb_error_CAN2.TabIndex = 14;
            this.lb_error_CAN2.Text = "Не удалось открыть CAN";
            this.lb_error_CAN2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_error_CAN2.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(159, 49);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(0, 13);
            this.label21.TabIndex = 10;
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_CloseCAN2
            // 
            this.bt_CloseCAN2.Enabled = false;
            this.bt_CloseCAN2.Location = new System.Drawing.Point(300, 18);
            this.bt_CloseCAN2.Name = "bt_CloseCAN2";
            this.bt_CloseCAN2.Size = new System.Drawing.Size(63, 23);
            this.bt_CloseCAN2.TabIndex = 2;
            this.bt_CloseCAN2.Text = "Закрыть";
            this.bt_CloseCAN2.UseVisualStyleBackColor = true;
            this.bt_CloseCAN2.Click += new System.EventHandler(this.bt_CloseCAN2_Click);
            // 
            // bt_OpenCAN2
            // 
            this.bt_OpenCAN2.Location = new System.Drawing.Point(237, 18);
            this.bt_OpenCAN2.Name = "bt_OpenCAN2";
            this.bt_OpenCAN2.Size = new System.Drawing.Size(60, 23);
            this.bt_OpenCAN2.TabIndex = 0;
            this.bt_OpenCAN2.Text = "Открыть";
            this.bt_OpenCAN2.UseVisualStyleBackColor = true;
            this.bt_OpenCAN2.Click += new System.EventHandler(this.bt_OpenCAN2_Click);
            // 
            // bt_About2
            // 
            this.bt_About2.Location = new System.Drawing.Point(839, 592);
            this.bt_About2.Name = "bt_About2";
            this.bt_About2.Size = new System.Drawing.Size(108, 23);
            this.bt_About2.TabIndex = 36;
            this.bt_About2.Text = "О программе";
            this.bt_About2.UseVisualStyleBackColor = true;
            this.bt_About2.Click += new System.EventHandler(this.bt_About_Click);
            // 
            // bt_Exit2
            // 
            this.bt_Exit2.Location = new System.Drawing.Point(839, 621);
            this.bt_Exit2.Name = "bt_Exit2";
            this.bt_Exit2.Size = new System.Drawing.Size(108, 23);
            this.bt_Exit2.TabIndex = 35;
            this.bt_Exit2.Text = "Выход";
            this.bt_Exit2.UseVisualStyleBackColor = true;
            this.bt_Exit2.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.rtb3_datagrid);
            this.tabPage4.Controls.Add(this.checkBox2);
            this.tabPage4.Controls.Add(this.chb4_nopaint);
            this.tabPage4.Controls.Add(this.gb3_shoot);
            this.tabPage4.Controls.Add(this.chb_dgview3);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.gb_olo_R);
            this.tabPage4.Controls.Add(this.gb_olo_L);
            this.tabPage4.Controls.Add(this.panel3);
            this.tabPage4.Controls.Add(this.gbox_CAN3);
            this.tabPage4.Controls.Add(this.bt_About3);
            this.tabPage4.Controls.Add(this.bt_Exit3);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(962, 654);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Эмуляция ОЛО";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // rtb3_datagrid
            // 
            this.rtb3_datagrid.Location = new System.Drawing.Point(6, 424);
            this.rtb3_datagrid.Name = "rtb3_datagrid";
            this.rtb3_datagrid.Size = new System.Drawing.Size(607, 220);
            this.rtb3_datagrid.TabIndex = 59;
            this.rtb3_datagrid.Text = "";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(413, 248);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(127, 17);
            this.checkBox2.TabIndex = 58;
            this.checkBox2.Text = "Не выводить в грид";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // chb4_nopaint
            // 
            this.chb4_nopaint.AutoSize = true;
            this.chb4_nopaint.Location = new System.Drawing.Point(413, 225);
            this.chb4_nopaint.Name = "chb4_nopaint";
            this.chb4_nopaint.Size = new System.Drawing.Size(122, 17);
            this.chb4_nopaint.TabIndex = 57;
            this.chb4_nopaint.Text = "Не прорисовывать";
            this.chb4_nopaint.UseVisualStyleBackColor = true;
            // 
            // gb3_shoot
            // 
            this.gb3_shoot.Controls.Add(this.lb3_freq_val_r);
            this.gb3_shoot.Controls.Add(this.lb3_freq_txt_r);
            this.gb3_shoot.Controls.Add(this.lb3_shoot_um_val_r);
            this.gb3_shoot.Controls.Add(this.lb3_shoot_az_val_r);
            this.gb3_shoot.Controls.Add(this.lb3_shoot_um_txt_r);
            this.gb3_shoot.Controls.Add(this.lb3_shoot_az_txt_r);
            this.gb3_shoot.Controls.Add(this.trackBar3_freq_r);
            this.gb3_shoot.Controls.Add(this.trackBar3_um_r);
            this.gb3_shoot.Controls.Add(this.chb4_enshr);
            this.gb3_shoot.Controls.Add(this.trackBar3_az_r);
            this.gb3_shoot.Controls.Add(this.chb4_enshl);
            this.gb3_shoot.Controls.Add(this.lb3_freq_val_l);
            this.gb3_shoot.Controls.Add(this.lb3_freq_txt_l);
            this.gb3_shoot.Controls.Add(this.trackBar3_freq_l);
            this.gb3_shoot.Controls.Add(this.chb3_shoot_ena);
            this.gb3_shoot.Controls.Add(this.lb3_shoot_um_val_l);
            this.gb3_shoot.Controls.Add(this.lb3_shoot_az_val_l);
            this.gb3_shoot.Controls.Add(this.trackBar3_um_l);
            this.gb3_shoot.Controls.Add(this.lb3_shoot_um_txt_l);
            this.gb3_shoot.Controls.Add(this.trackBar3_az_l);
            this.gb3_shoot.Controls.Add(this.lb3_shoot_az_txt_l);
            this.gb3_shoot.Enabled = false;
            this.gb3_shoot.Location = new System.Drawing.Point(619, 9);
            this.gb3_shoot.Name = "gb3_shoot";
            this.gb3_shoot.Size = new System.Drawing.Size(225, 419);
            this.gb3_shoot.TabIndex = 56;
            this.gb3_shoot.TabStop = false;
            this.gb3_shoot.Text = "Выстрелы";
            // 
            // lb3_freq_val_r
            // 
            this.lb3_freq_val_r.BackColor = System.Drawing.Color.Transparent;
            this.lb3_freq_val_r.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb3_freq_val_r.Enabled = false;
            this.lb3_freq_val_r.Location = new System.Drawing.Point(176, 371);
            this.lb3_freq_val_r.Name = "lb3_freq_val_r";
            this.lb3_freq_val_r.Size = new System.Drawing.Size(39, 15);
            this.lb3_freq_val_r.TabIndex = 72;
            this.lb3_freq_val_r.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lb3_freq_txt_r
            // 
            this.lb3_freq_txt_r.AutoSize = true;
            this.lb3_freq_txt_r.Enabled = false;
            this.lb3_freq_txt_r.Location = new System.Drawing.Point(111, 371);
            this.lb3_freq_txt_r.Name = "lb3_freq_txt_r";
            this.lb3_freq_txt_r.Size = new System.Drawing.Size(49, 13);
            this.lb3_freq_txt_r.TabIndex = 71;
            this.lb3_freq_txt_r.Text = "Частота";
            // 
            // lb3_shoot_um_val_r
            // 
            this.lb3_shoot_um_val_r.BackColor = System.Drawing.Color.Transparent;
            this.lb3_shoot_um_val_r.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb3_shoot_um_val_r.Enabled = false;
            this.lb3_shoot_um_val_r.Location = new System.Drawing.Point(176, 351);
            this.lb3_shoot_um_val_r.Name = "lb3_shoot_um_val_r";
            this.lb3_shoot_um_val_r.Size = new System.Drawing.Size(39, 15);
            this.lb3_shoot_um_val_r.TabIndex = 70;
            this.lb3_shoot_um_val_r.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lb3_shoot_az_val_r
            // 
            this.lb3_shoot_az_val_r.BackColor = System.Drawing.Color.Transparent;
            this.lb3_shoot_az_val_r.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb3_shoot_az_val_r.Enabled = false;
            this.lb3_shoot_az_val_r.Location = new System.Drawing.Point(176, 331);
            this.lb3_shoot_az_val_r.Name = "lb3_shoot_az_val_r";
            this.lb3_shoot_az_val_r.Size = new System.Drawing.Size(39, 15);
            this.lb3_shoot_az_val_r.TabIndex = 69;
            this.lb3_shoot_az_val_r.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lb3_shoot_um_txt_r
            // 
            this.lb3_shoot_um_txt_r.AutoSize = true;
            this.lb3_shoot_um_txt_r.Enabled = false;
            this.lb3_shoot_um_txt_r.Location = new System.Drawing.Point(111, 351);
            this.lb3_shoot_um_txt_r.Name = "lb3_shoot_um_txt_r";
            this.lb3_shoot_um_txt_r.Size = new System.Drawing.Size(66, 13);
            this.lb3_shoot_um_txt_r.TabIndex = 68;
            this.lb3_shoot_um_txt_r.Text = "Угол места";
            // 
            // lb3_shoot_az_txt_r
            // 
            this.lb3_shoot_az_txt_r.AutoSize = true;
            this.lb3_shoot_az_txt_r.Enabled = false;
            this.lb3_shoot_az_txt_r.Location = new System.Drawing.Point(111, 331);
            this.lb3_shoot_az_txt_r.Name = "lb3_shoot_az_txt_r";
            this.lb3_shoot_az_txt_r.Size = new System.Drawing.Size(44, 13);
            this.lb3_shoot_az_txt_r.TabIndex = 67;
            this.lb3_shoot_az_txt_r.Text = "Азимут";
            // 
            // trackBar3_freq_r
            // 
            this.trackBar3_freq_r.AutoSize = false;
            this.trackBar3_freq_r.Enabled = false;
            this.trackBar3_freq_r.LargeChange = 10;
            this.trackBar3_freq_r.Location = new System.Drawing.Point(186, 20);
            this.trackBar3_freq_r.Maximum = 70;
            this.trackBar3_freq_r.Minimum = 1;
            this.trackBar3_freq_r.Name = "trackBar3_freq_r";
            this.trackBar3_freq_r.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3_freq_r.Size = new System.Drawing.Size(30, 305);
            this.trackBar3_freq_r.TabIndex = 65;
            this.trackBar3_freq_r.Value = 2;
            this.trackBar3_freq_r.Scroll += new System.EventHandler(this.trackBar3_freq_r_Scroll);
            // 
            // trackBar3_um_r
            // 
            this.trackBar3_um_r.AutoSize = false;
            this.trackBar3_um_r.Enabled = false;
            this.trackBar3_um_r.LargeChange = 1080;
            this.trackBar3_um_r.Location = new System.Drawing.Point(150, 20);
            this.trackBar3_um_r.Maximum = 90;
            this.trackBar3_um_r.Minimum = -90;
            this.trackBar3_um_r.Name = "trackBar3_um_r";
            this.trackBar3_um_r.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3_um_r.Size = new System.Drawing.Size(30, 305);
            this.trackBar3_um_r.TabIndex = 64;
            this.trackBar3_um_r.Value = 60;
            this.trackBar3_um_r.Scroll += new System.EventHandler(this.trackBar3_um_r_Scroll);
            // 
            // chb4_enshr
            // 
            this.chb4_enshr.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb4_enshr.Enabled = false;
            this.chb4_enshr.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
            this.chb4_enshr.Location = new System.Drawing.Point(114, 389);
            this.chb4_enshr.Name = "chb4_enshr";
            this.chb4_enshr.Size = new System.Drawing.Size(102, 23);
            this.chb4_enshr.TabIndex = 66;
            this.chb4_enshr.Text = "Авто ОЛО-П";
            this.chb4_enshr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb4_enshr.UseVisualStyleBackColor = true;
            this.chb4_enshr.CheckedChanged += new System.EventHandler(this.chb4_enshr_CheckedChanged);
            // 
            // trackBar3_az_r
            // 
            this.trackBar3_az_r.AutoSize = false;
            this.trackBar3_az_r.Enabled = false;
            this.trackBar3_az_r.LargeChange = 1080;
            this.trackBar3_az_r.Location = new System.Drawing.Point(114, 20);
            this.trackBar3_az_r.Maximum = 90;
            this.trackBar3_az_r.Minimum = -90;
            this.trackBar3_az_r.Name = "trackBar3_az_r";
            this.trackBar3_az_r.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3_az_r.Size = new System.Drawing.Size(30, 305);
            this.trackBar3_az_r.TabIndex = 63;
            this.trackBar3_az_r.Value = -30;
            this.trackBar3_az_r.Scroll += new System.EventHandler(this.trackBar3_az_r_Scroll);
            // 
            // chb4_enshl
            // 
            this.chb4_enshl.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb4_enshl.Enabled = false;
            this.chb4_enshl.Location = new System.Drawing.Point(6, 389);
            this.chb4_enshl.Name = "chb4_enshl";
            this.chb4_enshl.Size = new System.Drawing.Size(102, 23);
            this.chb4_enshl.TabIndex = 65;
            this.chb4_enshl.Text = "Авто ОЛО-Л";
            this.chb4_enshl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb4_enshl.UseVisualStyleBackColor = true;
            this.chb4_enshl.CheckedChanged += new System.EventHandler(this.chb4_enshl_CheckedChanged);
            // 
            // lb3_freq_val_l
            // 
            this.lb3_freq_val_l.BackColor = System.Drawing.Color.Transparent;
            this.lb3_freq_val_l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb3_freq_val_l.Enabled = false;
            this.lb3_freq_val_l.Location = new System.Drawing.Point(68, 371);
            this.lb3_freq_val_l.Name = "lb3_freq_val_l";
            this.lb3_freq_val_l.Size = new System.Drawing.Size(39, 15);
            this.lb3_freq_val_l.TabIndex = 64;
            this.lb3_freq_val_l.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lb3_freq_txt_l
            // 
            this.lb3_freq_txt_l.AutoSize = true;
            this.lb3_freq_txt_l.Enabled = false;
            this.lb3_freq_txt_l.Location = new System.Drawing.Point(3, 371);
            this.lb3_freq_txt_l.Name = "lb3_freq_txt_l";
            this.lb3_freq_txt_l.Size = new System.Drawing.Size(49, 13);
            this.lb3_freq_txt_l.TabIndex = 63;
            this.lb3_freq_txt_l.Text = "Частота";
            // 
            // trackBar3_freq_l
            // 
            this.trackBar3_freq_l.AutoSize = false;
            this.trackBar3_freq_l.Enabled = false;
            this.trackBar3_freq_l.LargeChange = 10;
            this.trackBar3_freq_l.Location = new System.Drawing.Point(78, 20);
            this.trackBar3_freq_l.Maximum = 70;
            this.trackBar3_freq_l.Minimum = 1;
            this.trackBar3_freq_l.Name = "trackBar3_freq_l";
            this.trackBar3_freq_l.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3_freq_l.Size = new System.Drawing.Size(30, 305);
            this.trackBar3_freq_l.TabIndex = 62;
            this.trackBar3_freq_l.Value = 1;
            this.trackBar3_freq_l.Scroll += new System.EventHandler(this.trackBar3_freq_l_Scroll);
            // 
            // chb3_shoot_ena
            // 
            this.chb3_shoot_ena.AutoSize = true;
            this.chb3_shoot_ena.Location = new System.Drawing.Point(74, 0);
            this.chb3_shoot_ena.Name = "chb3_shoot_ena";
            this.chb3_shoot_ena.Size = new System.Drawing.Size(15, 14);
            this.chb3_shoot_ena.TabIndex = 57;
            this.chb3_shoot_ena.UseVisualStyleBackColor = true;
            this.chb3_shoot_ena.CheckedChanged += new System.EventHandler(this.chb3_shoot_ena_CheckedChanged);
            // 
            // lb3_shoot_um_val_l
            // 
            this.lb3_shoot_um_val_l.BackColor = System.Drawing.Color.Transparent;
            this.lb3_shoot_um_val_l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb3_shoot_um_val_l.Enabled = false;
            this.lb3_shoot_um_val_l.Location = new System.Drawing.Point(68, 351);
            this.lb3_shoot_um_val_l.Name = "lb3_shoot_um_val_l";
            this.lb3_shoot_um_val_l.Size = new System.Drawing.Size(39, 15);
            this.lb3_shoot_um_val_l.TabIndex = 61;
            this.lb3_shoot_um_val_l.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lb3_shoot_az_val_l
            // 
            this.lb3_shoot_az_val_l.BackColor = System.Drawing.Color.Transparent;
            this.lb3_shoot_az_val_l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb3_shoot_az_val_l.Enabled = false;
            this.lb3_shoot_az_val_l.Location = new System.Drawing.Point(68, 331);
            this.lb3_shoot_az_val_l.Name = "lb3_shoot_az_val_l";
            this.lb3_shoot_az_val_l.Size = new System.Drawing.Size(39, 15);
            this.lb3_shoot_az_val_l.TabIndex = 60;
            this.lb3_shoot_az_val_l.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // trackBar3_um_l
            // 
            this.trackBar3_um_l.AutoSize = false;
            this.trackBar3_um_l.Enabled = false;
            this.trackBar3_um_l.LargeChange = 1080;
            this.trackBar3_um_l.Location = new System.Drawing.Point(42, 20);
            this.trackBar3_um_l.Maximum = 90;
            this.trackBar3_um_l.Minimum = -90;
            this.trackBar3_um_l.Name = "trackBar3_um_l";
            this.trackBar3_um_l.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3_um_l.Size = new System.Drawing.Size(30, 305);
            this.trackBar3_um_l.TabIndex = 58;
            this.trackBar3_um_l.Value = -45;
            this.trackBar3_um_l.Scroll += new System.EventHandler(this.trackBar3_um_l_Scroll);
            // 
            // lb3_shoot_um_txt_l
            // 
            this.lb3_shoot_um_txt_l.AutoSize = true;
            this.lb3_shoot_um_txt_l.Enabled = false;
            this.lb3_shoot_um_txt_l.Location = new System.Drawing.Point(3, 351);
            this.lb3_shoot_um_txt_l.Name = "lb3_shoot_um_txt_l";
            this.lb3_shoot_um_txt_l.Size = new System.Drawing.Size(66, 13);
            this.lb3_shoot_um_txt_l.TabIndex = 59;
            this.lb3_shoot_um_txt_l.Text = "Угол места";
            // 
            // trackBar3_az_l
            // 
            this.trackBar3_az_l.AutoSize = false;
            this.trackBar3_az_l.Enabled = false;
            this.trackBar3_az_l.LargeChange = 1080;
            this.trackBar3_az_l.Location = new System.Drawing.Point(6, 20);
            this.trackBar3_az_l.Maximum = 90;
            this.trackBar3_az_l.Minimum = -90;
            this.trackBar3_az_l.Name = "trackBar3_az_l";
            this.trackBar3_az_l.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3_az_l.Size = new System.Drawing.Size(30, 305);
            this.trackBar3_az_l.TabIndex = 54;
            this.trackBar3_az_l.Value = 45;
            this.trackBar3_az_l.Scroll += new System.EventHandler(this.trackBar3_az_l_Scroll);
            // 
            // lb3_shoot_az_txt_l
            // 
            this.lb3_shoot_az_txt_l.AutoSize = true;
            this.lb3_shoot_az_txt_l.Enabled = false;
            this.lb3_shoot_az_txt_l.Location = new System.Drawing.Point(3, 331);
            this.lb3_shoot_az_txt_l.Name = "lb3_shoot_az_txt_l";
            this.lb3_shoot_az_txt_l.Size = new System.Drawing.Size(44, 13);
            this.lb3_shoot_az_txt_l.TabIndex = 55;
            this.lb3_shoot_az_txt_l.Text = "Азимут";
            // 
            // chb_dgview3
            // 
            this.chb_dgview3.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_dgview3.BackColor = System.Drawing.Color.Transparent;
            this.chb_dgview3.Checked = true;
            this.chb_dgview3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_dgview3.Enabled = false;
            this.chb_dgview3.Location = new System.Drawing.Point(195, 395);
            this.chb_dgview3.Name = "chb_dgview3";
            this.chb_dgview3.Size = new System.Drawing.Size(180, 23);
            this.chb_dgview3.TabIndex = 50;
            this.chb_dgview3.Text = "Скролл включен";
            this.chb_dgview3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_dgview3.UseVisualStyleBackColor = false;
            this.chb_dgview3.CheckedChanged += new System.EventHandler(this.chb_dgview3_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 23);
            this.button2.TabIndex = 53;
            this.button2.Text = "Очистка лога";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gb_olo_R
            // 
            this.gb_olo_R.Controls.Add(this.bt3_trash_r);
            this.gb_olo_R.Controls.Add(this.bt3_baddata_r);
            this.gb_olo_R.Controls.Add(this.bt3_badstatus_r);
            this.gb_olo_R.Controls.Add(this.lb3_t2_r);
            this.gb_olo_R.Controls.Add(this.tb3_t2_r);
            this.gb_olo_R.Controls.Add(this.lb3_t1_r);
            this.gb_olo_R.Controls.Add(this.tb3_t1_r);
            this.gb_olo_R.Controls.Add(this.lb3_tarm_r);
            this.gb_olo_R.Controls.Add(this.tb3_tarm_r);
            this.gb_olo_R.Controls.Add(this.chb_R_Err_file);
            this.gb_olo_R.Controls.Add(this.cb_olo_r_ena);
            this.gb_olo_R.Controls.Add(this.chb_R_Err_plis);
            this.gb_olo_R.Controls.Add(this.shoot_r);
            this.gb_olo_R.Controls.Add(this.label27);
            this.gb_olo_R.Controls.Add(this.chb_R_Err_int);
            this.gb_olo_R.Enabled = false;
            this.gb_olo_R.Location = new System.Drawing.Point(195, 93);
            this.gb_olo_R.Name = "gb_olo_R";
            this.gb_olo_R.Size = new System.Drawing.Size(180, 296);
            this.gb_olo_R.TabIndex = 52;
            this.gb_olo_R.TabStop = false;
            this.gb_olo_R.Text = "ОЛО-Правый";
            // 
            // bt3_trash_r
            // 
            this.bt3_trash_r.Location = new System.Drawing.Point(6, 263);
            this.bt3_trash_r.Name = "bt3_trash_r";
            this.bt3_trash_r.Size = new System.Drawing.Size(168, 23);
            this.bt3_trash_r.TabIndex = 44;
            this.bt3_trash_r.Text = "Мусор";
            this.bt3_trash_r.UseVisualStyleBackColor = true;
            this.bt3_trash_r.Click += new System.EventHandler(this.bt3_trash_r_Click);
            // 
            // bt3_baddata_r
            // 
            this.bt3_baddata_r.Location = new System.Drawing.Point(6, 234);
            this.bt3_baddata_r.Name = "bt3_baddata_r";
            this.bt3_baddata_r.Size = new System.Drawing.Size(168, 23);
            this.bt3_baddata_r.TabIndex = 47;
            this.bt3_baddata_r.Text = "Неправильные данные";
            this.bt3_baddata_r.UseVisualStyleBackColor = true;
            this.bt3_baddata_r.Click += new System.EventHandler(this.bt3_baddata_r_Click);
            // 
            // bt3_badstatus_r
            // 
            this.bt3_badstatus_r.Location = new System.Drawing.Point(6, 205);
            this.bt3_badstatus_r.Name = "bt3_badstatus_r";
            this.bt3_badstatus_r.Size = new System.Drawing.Size(168, 23);
            this.bt3_badstatus_r.TabIndex = 42;
            this.bt3_badstatus_r.Text = "Неправильный статус";
            this.bt3_badstatus_r.UseVisualStyleBackColor = true;
            this.bt3_badstatus_r.Click += new System.EventHandler(this.bt3_badstatus_r_Click);
            // 
            // lb3_t2_r
            // 
            this.lb3_t2_r.AutoSize = true;
            this.lb3_t2_r.Location = new System.Drawing.Point(130, 181);
            this.lb3_t2_r.Margin = new System.Windows.Forms.Padding(0);
            this.lb3_t2_r.Name = "lb3_t2_r";
            this.lb3_t2_r.Size = new System.Drawing.Size(20, 13);
            this.lb3_t2_r.TabIndex = 46;
            this.lb3_t2_r.Text = "T2";
            // 
            // tb3_t2_r
            // 
            this.tb3_t2_r.Location = new System.Drawing.Point(107, 178);
            this.tb3_t2_r.Name = "tb3_t2_r";
            this.tb3_t2_r.Size = new System.Drawing.Size(20, 20);
            this.tb3_t2_r.TabIndex = 45;
            this.tb3_t2_r.Text = "4";
            this.tb3_t2_r.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb3_t1_r
            // 
            this.lb3_t1_r.AutoSize = true;
            this.lb3_t1_r.Location = new System.Drawing.Point(84, 181);
            this.lb3_t1_r.Margin = new System.Windows.Forms.Padding(0);
            this.lb3_t1_r.Name = "lb3_t1_r";
            this.lb3_t1_r.Size = new System.Drawing.Size(20, 13);
            this.lb3_t1_r.TabIndex = 44;
            this.lb3_t1_r.Text = "T1";
            // 
            // tb3_t1_r
            // 
            this.tb3_t1_r.Location = new System.Drawing.Point(61, 178);
            this.tb3_t1_r.Name = "tb3_t1_r";
            this.tb3_t1_r.Size = new System.Drawing.Size(20, 20);
            this.tb3_t1_r.TabIndex = 43;
            this.tb3_t1_r.Text = "6";
            this.tb3_t1_r.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb3_tarm_r
            // 
            this.lb3_tarm_r.AutoSize = true;
            this.lb3_tarm_r.Location = new System.Drawing.Point(29, 181);
            this.lb3_tarm_r.Margin = new System.Windows.Forms.Padding(0);
            this.lb3_tarm_r.Name = "lb3_tarm_r";
            this.lb3_tarm_r.Size = new System.Drawing.Size(31, 13);
            this.lb3_tarm_r.TabIndex = 42;
            this.lb3_tarm_r.Text = "Tarm";
            // 
            // tb3_tarm_r
            // 
            this.tb3_tarm_r.Location = new System.Drawing.Point(6, 178);
            this.tb3_tarm_r.Name = "tb3_tarm_r";
            this.tb3_tarm_r.Size = new System.Drawing.Size(20, 20);
            this.tb3_tarm_r.TabIndex = 41;
            this.tb3_tarm_r.Text = "32";
            // 
            // chb_R_Err_file
            // 
            this.chb_R_Err_file.AutoSize = true;
            this.chb_R_Err_file.Enabled = false;
            this.chb_R_Err_file.Location = new System.Drawing.Point(6, 155);
            this.chb_R_Err_file.Name = "chb_R_Err_file";
            this.chb_R_Err_file.Size = new System.Drawing.Size(156, 17);
            this.chb_R_Err_file.TabIndex = 38;
            this.chb_R_Err_file.Text = "Ошибка загрузки файлов";
            this.chb_R_Err_file.UseVisualStyleBackColor = true;
            // 
            // cb_olo_r_ena
            // 
            this.cb_olo_r_ena.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_olo_r_ena.Location = new System.Drawing.Point(6, 20);
            this.cb_olo_r_ena.Name = "cb_olo_r_ena";
            this.cb_olo_r_ena.Size = new System.Drawing.Size(168, 23);
            this.cb_olo_r_ena.TabIndex = 31;
            this.cb_olo_r_ena.Text = "Эмуляция выключена";
            this.cb_olo_r_ena.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_olo_r_ena.UseVisualStyleBackColor = true;
            this.cb_olo_r_ena.CheckedChanged += new System.EventHandler(this.cb_olo_r_ena_CheckedChanged);
            // 
            // chb_R_Err_plis
            // 
            this.chb_R_Err_plis.AutoSize = true;
            this.chb_R_Err_plis.Enabled = false;
            this.chb_R_Err_plis.Location = new System.Drawing.Point(6, 132);
            this.chb_R_Err_plis.Name = "chb_R_Err_plis";
            this.chb_R_Err_plis.Size = new System.Drawing.Size(149, 17);
            this.chb_R_Err_plis.TabIndex = 37;
            this.chb_R_Err_plis.Text = "Ошибка загрузки ПЛИС";
            this.chb_R_Err_plis.UseVisualStyleBackColor = true;
            // 
            // shoot_r
            // 
            this.shoot_r.Enabled = false;
            this.shoot_r.Location = new System.Drawing.Point(6, 51);
            this.shoot_r.Name = "shoot_r";
            this.shoot_r.Size = new System.Drawing.Size(168, 23);
            this.shoot_r.TabIndex = 30;
            this.shoot_r.Text = "Выстрел";
            this.shoot_r.UseVisualStyleBackColor = true;
            this.shoot_r.Click += new System.EventHandler(this.shoot_r_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Enabled = false;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(6, 83);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(143, 13);
            this.label27.TabIndex = 36;
            this.label27.Text = "Неисправности ОЛО-П";
            // 
            // chb_R_Err_int
            // 
            this.chb_R_Err_int.AutoSize = true;
            this.chb_R_Err_int.Enabled = false;
            this.chb_R_Err_int.Location = new System.Drawing.Point(6, 109);
            this.chb_R_Err_int.Name = "chb_R_Err_int";
            this.chb_R_Err_int.Size = new System.Drawing.Size(145, 17);
            this.chb_R_Err_int.TabIndex = 35;
            this.chb_R_Err_int.Text = "Интегр. неисправность";
            this.chb_R_Err_int.UseVisualStyleBackColor = true;
            // 
            // gb_olo_L
            // 
            this.gb_olo_L.Controls.Add(this.bt3_trash_l);
            this.gb_olo_L.Controls.Add(this.bt3_baddata_l);
            this.gb_olo_L.Controls.Add(this.bt3_badstatus_l);
            this.gb_olo_L.Controls.Add(this.lb3_t2_l);
            this.gb_olo_L.Controls.Add(this.tb3_t2_l);
            this.gb_olo_L.Controls.Add(this.lb3_t1_l);
            this.gb_olo_L.Controls.Add(this.tb3_t1_l);
            this.gb_olo_L.Controls.Add(this.lb3_tarm_l);
            this.gb_olo_L.Controls.Add(this.tb3_tarm_l);
            this.gb_olo_L.Controls.Add(this.chb_L_Err_file);
            this.gb_olo_L.Controls.Add(this.chb_L_Err_plis);
            this.gb_olo_L.Controls.Add(this.label26);
            this.gb_olo_L.Controls.Add(this.chb_L_Err_int);
            this.gb_olo_L.Controls.Add(this.cb_olo_l_ena);
            this.gb_olo_L.Controls.Add(this.shoot_l);
            this.gb_olo_L.Enabled = false;
            this.gb_olo_L.Location = new System.Drawing.Point(6, 93);
            this.gb_olo_L.Name = "gb_olo_L";
            this.gb_olo_L.Size = new System.Drawing.Size(180, 296);
            this.gb_olo_L.TabIndex = 51;
            this.gb_olo_L.TabStop = false;
            this.gb_olo_L.Text = "ОЛО-Левый";
            // 
            // bt3_trash_l
            // 
            this.bt3_trash_l.Location = new System.Drawing.Point(6, 263);
            this.bt3_trash_l.Name = "bt3_trash_l";
            this.bt3_trash_l.Size = new System.Drawing.Size(168, 23);
            this.bt3_trash_l.TabIndex = 43;
            this.bt3_trash_l.Text = "Мусор";
            this.bt3_trash_l.UseVisualStyleBackColor = true;
            this.bt3_trash_l.Click += new System.EventHandler(this.bt3_trash_l_Click);
            // 
            // bt3_baddata_l
            // 
            this.bt3_baddata_l.Location = new System.Drawing.Point(6, 234);
            this.bt3_baddata_l.Name = "bt3_baddata_l";
            this.bt3_baddata_l.Size = new System.Drawing.Size(168, 23);
            this.bt3_baddata_l.TabIndex = 42;
            this.bt3_baddata_l.Text = "Неправильные данные";
            this.bt3_baddata_l.UseVisualStyleBackColor = true;
            this.bt3_baddata_l.Click += new System.EventHandler(this.bt3_baddata_l_Click);
            // 
            // bt3_badstatus_l
            // 
            this.bt3_badstatus_l.Location = new System.Drawing.Point(6, 205);
            this.bt3_badstatus_l.Name = "bt3_badstatus_l";
            this.bt3_badstatus_l.Size = new System.Drawing.Size(168, 23);
            this.bt3_badstatus_l.TabIndex = 41;
            this.bt3_badstatus_l.Text = "Неправильный статус";
            this.bt3_badstatus_l.UseVisualStyleBackColor = true;
            this.bt3_badstatus_l.Click += new System.EventHandler(this.bt3_badstatus_l_Click);
            // 
            // lb3_t2_l
            // 
            this.lb3_t2_l.AutoSize = true;
            this.lb3_t2_l.Location = new System.Drawing.Point(130, 181);
            this.lb3_t2_l.Margin = new System.Windows.Forms.Padding(0);
            this.lb3_t2_l.Name = "lb3_t2_l";
            this.lb3_t2_l.Size = new System.Drawing.Size(20, 13);
            this.lb3_t2_l.TabIndex = 40;
            this.lb3_t2_l.Text = "T2";
            // 
            // tb3_t2_l
            // 
            this.tb3_t2_l.Location = new System.Drawing.Point(107, 178);
            this.tb3_t2_l.Name = "tb3_t2_l";
            this.tb3_t2_l.Size = new System.Drawing.Size(20, 20);
            this.tb3_t2_l.TabIndex = 39;
            this.tb3_t2_l.Text = "7";
            this.tb3_t2_l.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb3_t1_l
            // 
            this.lb3_t1_l.AutoSize = true;
            this.lb3_t1_l.Location = new System.Drawing.Point(84, 181);
            this.lb3_t1_l.Margin = new System.Windows.Forms.Padding(0);
            this.lb3_t1_l.Name = "lb3_t1_l";
            this.lb3_t1_l.Size = new System.Drawing.Size(20, 13);
            this.lb3_t1_l.TabIndex = 38;
            this.lb3_t1_l.Text = "T1";
            // 
            // tb3_t1_l
            // 
            this.tb3_t1_l.Location = new System.Drawing.Point(61, 178);
            this.tb3_t1_l.Name = "tb3_t1_l";
            this.tb3_t1_l.Size = new System.Drawing.Size(20, 20);
            this.tb3_t1_l.TabIndex = 37;
            this.tb3_t1_l.Text = "5";
            this.tb3_t1_l.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lb3_tarm_l
            // 
            this.lb3_tarm_l.AutoSize = true;
            this.lb3_tarm_l.Location = new System.Drawing.Point(29, 181);
            this.lb3_tarm_l.Margin = new System.Windows.Forms.Padding(0);
            this.lb3_tarm_l.Name = "lb3_tarm_l";
            this.lb3_tarm_l.Size = new System.Drawing.Size(31, 13);
            this.lb3_tarm_l.TabIndex = 36;
            this.lb3_tarm_l.Text = "Tarm";
            // 
            // tb3_tarm_l
            // 
            this.tb3_tarm_l.Location = new System.Drawing.Point(6, 178);
            this.tb3_tarm_l.Name = "tb3_tarm_l";
            this.tb3_tarm_l.Size = new System.Drawing.Size(20, 20);
            this.tb3_tarm_l.TabIndex = 35;
            this.tb3_tarm_l.Text = "35";
            // 
            // chb_L_Err_file
            // 
            this.chb_L_Err_file.AutoSize = true;
            this.chb_L_Err_file.Enabled = false;
            this.chb_L_Err_file.Location = new System.Drawing.Point(6, 155);
            this.chb_L_Err_file.Name = "chb_L_Err_file";
            this.chb_L_Err_file.Size = new System.Drawing.Size(156, 17);
            this.chb_L_Err_file.TabIndex = 34;
            this.chb_L_Err_file.Text = "Ошибка загрузки файлов";
            this.chb_L_Err_file.UseVisualStyleBackColor = true;
            // 
            // chb_L_Err_plis
            // 
            this.chb_L_Err_plis.AutoSize = true;
            this.chb_L_Err_plis.Enabled = false;
            this.chb_L_Err_plis.Location = new System.Drawing.Point(6, 132);
            this.chb_L_Err_plis.Name = "chb_L_Err_plis";
            this.chb_L_Err_plis.Size = new System.Drawing.Size(149, 17);
            this.chb_L_Err_plis.TabIndex = 33;
            this.chb_L_Err_plis.Text = "Ошибка загрузки ПЛИС";
            this.chb_L_Err_plis.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Enabled = false;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(6, 83);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(143, 13);
            this.label26.TabIndex = 32;
            this.label26.Text = "Неисправности ОЛО-Л";
            // 
            // chb_L_Err_int
            // 
            this.chb_L_Err_int.AutoSize = true;
            this.chb_L_Err_int.Enabled = false;
            this.chb_L_Err_int.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chb_L_Err_int.Location = new System.Drawing.Point(6, 109);
            this.chb_L_Err_int.Name = "chb_L_Err_int";
            this.chb_L_Err_int.Size = new System.Drawing.Size(145, 17);
            this.chb_L_Err_int.TabIndex = 31;
            this.chb_L_Err_int.Text = "Интегр. неисправность";
            this.chb_L_Err_int.UseVisualStyleBackColor = true;
            // 
            // cb_olo_l_ena
            // 
            this.cb_olo_l_ena.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_olo_l_ena.Location = new System.Drawing.Point(6, 20);
            this.cb_olo_l_ena.Name = "cb_olo_l_ena";
            this.cb_olo_l_ena.Size = new System.Drawing.Size(168, 23);
            this.cb_olo_l_ena.TabIndex = 30;
            this.cb_olo_l_ena.Text = "Эмуляция выключена";
            this.cb_olo_l_ena.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_olo_l_ena.UseVisualStyleBackColor = true;
            this.cb_olo_l_ena.CheckedChanged += new System.EventHandler(this.cb_olo_l_ena_CheckedChanged);
            // 
            // shoot_l
            // 
            this.shoot_l.Enabled = false;
            this.shoot_l.Location = new System.Drawing.Point(6, 51);
            this.shoot_l.Name = "shoot_l";
            this.shoot_l.Size = new System.Drawing.Size(168, 23);
            this.shoot_l.TabIndex = 29;
            this.shoot_l.Text = "Выстрел";
            this.shoot_l.UseVisualStyleBackColor = true;
            this.shoot_l.Click += new System.EventHandler(this.shoot_l_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::OLO_CAN.Properties.Resources.olo10;
            this.panel3.Location = new System.Drawing.Point(413, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 200);
            this.panel3.TabIndex = 49;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // gbox_CAN3
            // 
            this.gbox_CAN3.Controls.Add(this.lb_noerr3);
            this.gbox_CAN3.Controls.Add(this.cb_CAN3);
            this.gbox_CAN3.Controls.Add(this.lb_error_CAN3);
            this.gbox_CAN3.Controls.Add(this.label19);
            this.gbox_CAN3.Controls.Add(this.bt_CloseCAN3);
            this.gbox_CAN3.Controls.Add(this.bt_OpenCAN3);
            this.gbox_CAN3.Location = new System.Drawing.Point(6, 9);
            this.gbox_CAN3.Name = "gbox_CAN3";
            this.gbox_CAN3.Size = new System.Drawing.Size(369, 78);
            this.gbox_CAN3.TabIndex = 45;
            this.gbox_CAN3.TabStop = false;
            this.gbox_CAN3.Text = "CAN";
            // 
            // lb_noerr3
            // 
            this.lb_noerr3.BackColor = System.Drawing.Color.SpringGreen;
            this.lb_noerr3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_noerr3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_noerr3.Location = new System.Drawing.Point(6, 49);
            this.lb_noerr3.Name = "lb_noerr3";
            this.lb_noerr3.Size = new System.Drawing.Size(357, 21);
            this.lb_noerr3.TabIndex = 15;
            this.lb_noerr3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_noerr3.Visible = false;
            // 
            // cb_CAN3
            // 
            this.cb_CAN3.FormattingEnabled = true;
            this.cb_CAN3.Location = new System.Drawing.Point(6, 20);
            this.cb_CAN3.Name = "cb_CAN3";
            this.cb_CAN3.Size = new System.Drawing.Size(225, 21);
            this.cb_CAN3.TabIndex = 29;
            // 
            // lb_error_CAN3
            // 
            this.lb_error_CAN3.BackColor = System.Drawing.Color.Red;
            this.lb_error_CAN3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_error_CAN3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_error_CAN3.Location = new System.Drawing.Point(6, 49);
            this.lb_error_CAN3.Name = "lb_error_CAN3";
            this.lb_error_CAN3.Size = new System.Drawing.Size(357, 21);
            this.lb_error_CAN3.TabIndex = 14;
            this.lb_error_CAN3.Text = "Не удалось открыть CAN";
            this.lb_error_CAN3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_error_CAN3.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(159, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 13);
            this.label19.TabIndex = 10;
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_CloseCAN3
            // 
            this.bt_CloseCAN3.Enabled = false;
            this.bt_CloseCAN3.Location = new System.Drawing.Point(300, 18);
            this.bt_CloseCAN3.Name = "bt_CloseCAN3";
            this.bt_CloseCAN3.Size = new System.Drawing.Size(63, 23);
            this.bt_CloseCAN3.TabIndex = 2;
            this.bt_CloseCAN3.Text = "Закрыть";
            this.bt_CloseCAN3.UseVisualStyleBackColor = true;
            this.bt_CloseCAN3.Click += new System.EventHandler(this.bt_CloseCAN3_Click);
            // 
            // bt_OpenCAN3
            // 
            this.bt_OpenCAN3.Location = new System.Drawing.Point(237, 18);
            this.bt_OpenCAN3.Name = "bt_OpenCAN3";
            this.bt_OpenCAN3.Size = new System.Drawing.Size(60, 23);
            this.bt_OpenCAN3.TabIndex = 0;
            this.bt_OpenCAN3.Text = "Открыть";
            this.bt_OpenCAN3.UseVisualStyleBackColor = true;
            this.bt_OpenCAN3.Click += new System.EventHandler(this.bt_OpenCAN3_Click);
            // 
            // bt_About3
            // 
            this.bt_About3.Location = new System.Drawing.Point(839, 592);
            this.bt_About3.Name = "bt_About3";
            this.bt_About3.Size = new System.Drawing.Size(108, 23);
            this.bt_About3.TabIndex = 36;
            this.bt_About3.Text = "О программе";
            this.bt_About3.UseVisualStyleBackColor = true;
            this.bt_About3.Click += new System.EventHandler(this.bt_About_Click);
            // 
            // bt_Exit3
            // 
            this.bt_Exit3.Location = new System.Drawing.Point(839, 621);
            this.bt_Exit3.Name = "bt_Exit3";
            this.bt_Exit3.Size = new System.Drawing.Size(108, 23);
            this.bt_Exit3.TabIndex = 35;
            this.bt_Exit3.Text = "Выход";
            this.bt_Exit3.UseVisualStyleBackColor = true;
            this.bt_Exit3.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.lb_plis_init);
            this.tabPage5.Controls.Add(this.chb5_timer_enable);
            this.tabPage5.Controls.Add(this.lb_plis2_load);
            this.tabPage5.Controls.Add(this.gb_Image24);
            this.tabPage5.Controls.Add(this.lb_plis1_load);
            this.tabPage5.Controls.Add(this.gb_Temperature);
            this.tabPage5.Controls.Add(this.bt_plis2_load);
            this.tabPage5.Controls.Add(this.gb_Image14);
            this.tabPage5.Controls.Add(this.bt_plis1_load);
            this.tabPage5.Controls.Add(this.gb_Tests);
            this.tabPage5.Controls.Add(this.bt_plis_init);
            this.tabPage5.Controls.Add(this.gbox_CAN4);
            this.tabPage5.Controls.Add(this.bt_About4);
            this.tabPage5.Controls.Add(this.bt_Exit4);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(962, 654);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Тестирование платы БОС";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // lb_plis_init
            // 
            this.lb_plis_init.AutoSize = true;
            this.lb_plis_init.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_plis_init.Location = new System.Drawing.Point(776, 161);
            this.lb_plis_init.Name = "lb_plis_init";
            this.lb_plis_init.Size = new System.Drawing.Size(0, 13);
            this.lb_plis_init.TabIndex = 39;
            this.lb_plis_init.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chb5_timer_enable
            // 
            this.chb5_timer_enable.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb5_timer_enable.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb5_timer_enable.Checked = true;
            this.chb5_timer_enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb5_timer_enable.Location = new System.Drawing.Point(726, 126);
            this.chb5_timer_enable.Name = "chb5_timer_enable";
            this.chb5_timer_enable.Size = new System.Drawing.Size(228, 23);
            this.chb5_timer_enable.TabIndex = 46;
            this.chb5_timer_enable.Text = "Таймер";
            this.chb5_timer_enable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb5_timer_enable.UseVisualStyleBackColor = true;
            // 
            // lb_plis2_load
            // 
            this.lb_plis2_load.AutoSize = true;
            this.lb_plis2_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_plis2_load.Location = new System.Drawing.Point(776, 219);
            this.lb_plis2_load.Name = "lb_plis2_load";
            this.lb_plis2_load.Size = new System.Drawing.Size(0, 13);
            this.lb_plis2_load.TabIndex = 38;
            this.lb_plis2_load.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gb_Image24
            // 
            this.gb_Image24.Controls.Add(this.pictureBox24);
            this.gb_Image24.Controls.Add(this.pb_CMOS2);
            this.gb_Image24.Controls.Add(this.lb_CMOS24);
            this.gb_Image24.Controls.Add(this.bt_get_CMOS2);
            this.gb_Image24.Enabled = false;
            this.gb_Image24.Location = new System.Drawing.Point(388, 334);
            this.gb_Image24.Name = "gb_Image24";
            this.gb_Image24.Size = new System.Drawing.Size(332, 310);
            this.gb_Image24.TabIndex = 45;
            this.gb_Image24.TabStop = false;
            this.gb_Image24.Text = "Кадр CMOS2";
            // 
            // pictureBox24
            // 
            this.pictureBox24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox24.Location = new System.Drawing.Point(6, 19);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Size = new System.Drawing.Size(319, 255);
            this.pictureBox24.TabIndex = 6;
            this.pictureBox24.TabStop = false;
            // 
            // pb_CMOS2
            // 
            this.pb_CMOS2.Location = new System.Drawing.Point(69, 281);
            this.pb_CMOS2.Name = "pb_CMOS2";
            this.pb_CMOS2.Size = new System.Drawing.Size(256, 23);
            this.pb_CMOS2.Step = 1;
            this.pb_CMOS2.TabIndex = 21;
            this.pb_CMOS2.Visible = false;
            // 
            // lb_CMOS24
            // 
            this.lb_CMOS24.AutoSize = true;
            this.lb_CMOS24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_CMOS24.Location = new System.Drawing.Point(76, 286);
            this.lb_CMOS24.Name = "lb_CMOS24";
            this.lb_CMOS24.Size = new System.Drawing.Size(0, 13);
            this.lb_CMOS24.TabIndex = 23;
            this.lb_CMOS24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_get_CMOS2
            // 
            this.bt_get_CMOS2.Location = new System.Drawing.Point(6, 281);
            this.bt_get_CMOS2.Name = "bt_get_CMOS2";
            this.bt_get_CMOS2.Size = new System.Drawing.Size(57, 23);
            this.bt_get_CMOS2.TabIndex = 11;
            this.bt_get_CMOS2.Text = "Считать";
            this.bt_get_CMOS2.UseVisualStyleBackColor = true;
            this.bt_get_CMOS2.Click += new System.EventHandler(this.bt_get_CMOS2_Click);
            // 
            // lb_plis1_load
            // 
            this.lb_plis1_load.AutoSize = true;
            this.lb_plis1_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_plis1_load.Location = new System.Drawing.Point(776, 190);
            this.lb_plis1_load.Name = "lb_plis1_load";
            this.lb_plis1_load.Size = new System.Drawing.Size(0, 13);
            this.lb_plis1_load.TabIndex = 37;
            this.lb_plis1_load.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gb_Temperature
            // 
            this.gb_Temperature.Controls.Add(this.label22);
            this.gb_Temperature.Controls.Add(this.label23);
            this.gb_Temperature.Controls.Add(this.lb_T3_val4);
            this.gb_Temperature.Controls.Add(this.lb_T3);
            this.gb_Temperature.Controls.Add(this.lb_T2_val4);
            this.gb_Temperature.Controls.Add(this.lb_T1_val4);
            this.gb_Temperature.Enabled = false;
            this.gb_Temperature.Location = new System.Drawing.Point(726, 9);
            this.gb_Temperature.Name = "gb_Temperature";
            this.gb_Temperature.Size = new System.Drawing.Size(228, 110);
            this.gb_Temperature.TabIndex = 44;
            this.gb_Temperature.TabStop = false;
            this.gb_Temperature.Text = "Температуры";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(6, 26);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(107, 16);
            this.label22.TabIndex = 7;
            this.label22.Text = "Температура 1";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(6, 50);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(107, 16);
            this.label23.TabIndex = 8;
            this.label23.Text = "Температура 2";
            // 
            // lb_T3_val4
            // 
            this.lb_T3_val4.AutoSize = true;
            this.lb_T3_val4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_T3_val4.Location = new System.Drawing.Point(119, 74);
            this.lb_T3_val4.Name = "lb_T3_val4";
            this.lb_T3_val4.Size = new System.Drawing.Size(12, 16);
            this.lb_T3_val4.TabIndex = 12;
            this.lb_T3_val4.Text = "-";
            // 
            // lb_T3
            // 
            this.lb_T3.AutoSize = true;
            this.lb_T3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_T3.Location = new System.Drawing.Point(6, 74);
            this.lb_T3.Name = "lb_T3";
            this.lb_T3.Size = new System.Drawing.Size(107, 16);
            this.lb_T3.TabIndex = 9;
            this.lb_T3.Text = "Температура 3";
            // 
            // lb_T2_val4
            // 
            this.lb_T2_val4.AutoSize = true;
            this.lb_T2_val4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_T2_val4.Location = new System.Drawing.Point(119, 50);
            this.lb_T2_val4.Name = "lb_T2_val4";
            this.lb_T2_val4.Size = new System.Drawing.Size(12, 16);
            this.lb_T2_val4.TabIndex = 11;
            this.lb_T2_val4.Text = "-";
            // 
            // lb_T1_val4
            // 
            this.lb_T1_val4.AutoSize = true;
            this.lb_T1_val4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_T1_val4.Location = new System.Drawing.Point(119, 26);
            this.lb_T1_val4.Name = "lb_T1_val4";
            this.lb_T1_val4.Size = new System.Drawing.Size(12, 16);
            this.lb_T1_val4.TabIndex = 10;
            this.lb_T1_val4.Text = "-";
            // 
            // bt_plis2_load
            // 
            this.bt_plis2_load.Location = new System.Drawing.Point(725, 214);
            this.bt_plis2_load.Name = "bt_plis2_load";
            this.bt_plis2_load.Size = new System.Drawing.Size(44, 23);
            this.bt_plis2_load.TabIndex = 36;
            this.bt_plis2_load.Text = "PLIS2";
            this.bt_plis2_load.UseVisualStyleBackColor = true;
            this.bt_plis2_load.Click += new System.EventHandler(this.bt_plis2_load_Click);
            // 
            // gb_Image14
            // 
            this.gb_Image14.Controls.Add(this.pictureBox14);
            this.gb_Image14.Controls.Add(this.pb_CMOS1);
            this.gb_Image14.Controls.Add(this.bt_get_CMOS1);
            this.gb_Image14.Controls.Add(this.lb_CMOS14);
            this.gb_Image14.Enabled = false;
            this.gb_Image14.Location = new System.Drawing.Point(388, 9);
            this.gb_Image14.Name = "gb_Image14";
            this.gb_Image14.Size = new System.Drawing.Size(332, 310);
            this.gb_Image14.TabIndex = 43;
            this.gb_Image14.TabStop = false;
            this.gb_Image14.Text = "Кадр CMOS1";
            // 
            // pictureBox14
            // 
            this.pictureBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox14.Location = new System.Drawing.Point(6, 19);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(319, 255);
            this.pictureBox14.TabIndex = 6;
            this.pictureBox14.TabStop = false;
            // 
            // pb_CMOS1
            // 
            this.pb_CMOS1.Location = new System.Drawing.Point(69, 281);
            this.pb_CMOS1.Name = "pb_CMOS1";
            this.pb_CMOS1.Size = new System.Drawing.Size(256, 23);
            this.pb_CMOS1.Step = 1;
            this.pb_CMOS1.TabIndex = 20;
            this.pb_CMOS1.Visible = false;
            // 
            // bt_get_CMOS1
            // 
            this.bt_get_CMOS1.Location = new System.Drawing.Point(6, 281);
            this.bt_get_CMOS1.Name = "bt_get_CMOS1";
            this.bt_get_CMOS1.Size = new System.Drawing.Size(57, 23);
            this.bt_get_CMOS1.TabIndex = 10;
            this.bt_get_CMOS1.Text = "Считать";
            this.bt_get_CMOS1.UseVisualStyleBackColor = true;
            this.bt_get_CMOS1.Click += new System.EventHandler(this.bt_get_CMOS1_Click);
            // 
            // lb_CMOS14
            // 
            this.lb_CMOS14.AutoSize = true;
            this.lb_CMOS14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_CMOS14.Location = new System.Drawing.Point(76, 286);
            this.lb_CMOS14.Name = "lb_CMOS14";
            this.lb_CMOS14.Size = new System.Drawing.Size(0, 13);
            this.lb_CMOS14.TabIndex = 22;
            this.lb_CMOS14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_plis1_load
            // 
            this.bt_plis1_load.Location = new System.Drawing.Point(726, 185);
            this.bt_plis1_load.Name = "bt_plis1_load";
            this.bt_plis1_load.Size = new System.Drawing.Size(44, 23);
            this.bt_plis1_load.TabIndex = 35;
            this.bt_plis1_load.Text = "PLIS1";
            this.bt_plis1_load.UseVisualStyleBackColor = true;
            this.bt_plis1_load.Click += new System.EventHandler(this.bt_plis1_load_Click);
            // 
            // gb_Tests
            // 
            this.gb_Tests.Controls.Add(this.bt5_reset);
            this.gb_Tests.Controls.Add(this.chb5_d19);
            this.gb_Tests.Controls.Add(this.chb5_d13);
            this.gb_Tests.Controls.Add(this.gb5_ba);
            this.gb_Tests.Controls.Add(this.chb5_d21);
            this.gb_Tests.Controls.Add(this.gb5_bd);
            this.gb_Tests.Controls.Add(this.lb_test_D19_2);
            this.gb_Tests.Controls.Add(this.bt_test_D19_2);
            this.gb_Tests.Controls.Add(this.lb_test_D13_2);
            this.gb_Tests.Controls.Add(this.bt_test_D13_2);
            this.gb_Tests.Controls.Add(this.lb_test_FLASH_2);
            this.gb_Tests.Controls.Add(this.chb_Sin);
            this.gb_Tests.Controls.Add(this.chb_Peltier2);
            this.gb_Tests.Controls.Add(this.chb_Peltier1);
            this.gb_Tests.Controls.Add(this.chb_cycle_test_D19);
            this.gb_Tests.Controls.Add(this.chb_cycle_test_D13);
            this.gb_Tests.Controls.Add(this.chb_cycle_test_D21);
            this.gb_Tests.Controls.Add(this.lb_test_FLASH);
            this.gb_Tests.Controls.Add(this.bt_test_FLASH);
            this.gb_Tests.Controls.Add(this.lb_test_D21_2);
            this.gb_Tests.Controls.Add(this.bt_test_D21_2);
            this.gb_Tests.Controls.Add(this.lb_test_D19);
            this.gb_Tests.Controls.Add(this.bt_test_D19);
            this.gb_Tests.Controls.Add(this.lb_test_D13);
            this.gb_Tests.Controls.Add(this.bt_test_D13);
            this.gb_Tests.Controls.Add(this.lb_test_D21_1);
            this.gb_Tests.Controls.Add(this.bt_test_D21_1);
            this.gb_Tests.Controls.Add(this.lb_test_plis);
            this.gb_Tests.Controls.Add(this.bt_test_PLIS);
            this.gb_Tests.Enabled = false;
            this.gb_Tests.Location = new System.Drawing.Point(6, 120);
            this.gb_Tests.Name = "gb_Tests";
            this.gb_Tests.Size = new System.Drawing.Size(376, 524);
            this.gb_Tests.TabIndex = 42;
            this.gb_Tests.TabStop = false;
            this.gb_Tests.Text = "Тесты";
            // 
            // bt5_reset
            // 
            this.bt5_reset.Location = new System.Drawing.Point(145, 305);
            this.bt5_reset.Name = "bt5_reset";
            this.bt5_reset.Size = new System.Drawing.Size(54, 23);
            this.bt5_reset.TabIndex = 33;
            this.bt5_reset.Text = "Сброс";
            this.bt5_reset.UseVisualStyleBackColor = true;
            this.bt5_reset.Click += new System.EventHandler(this.bt5_reset_Click);
            // 
            // chb5_d19
            // 
            this.chb5_d19.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb5_d19.Location = new System.Drawing.Point(99, 305);
            this.chb5_d19.Name = "chb5_d19";
            this.chb5_d19.Size = new System.Drawing.Size(40, 23);
            this.chb5_d19.TabIndex = 32;
            this.chb5_d19.Text = "D19";
            this.chb5_d19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb5_d19.UseVisualStyleBackColor = true;
            this.chb5_d19.CheckedChanged += new System.EventHandler(this.chb5_d19_CheckedChanged);
            // 
            // chb5_d13
            // 
            this.chb5_d13.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb5_d13.Location = new System.Drawing.Point(53, 305);
            this.chb5_d13.Name = "chb5_d13";
            this.chb5_d13.Size = new System.Drawing.Size(40, 23);
            this.chb5_d13.TabIndex = 31;
            this.chb5_d13.Text = "D13";
            this.chb5_d13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb5_d13.UseVisualStyleBackColor = true;
            this.chb5_d13.CheckedChanged += new System.EventHandler(this.chb5_d13_CheckedChanged);
            // 
            // gb5_ba
            // 
            this.gb5_ba.Controls.Add(this.rb5_a_01);
            this.gb5_ba.Controls.Add(this.rb5_a_1);
            this.gb5_ba.Controls.Add(this.rb5_a_0);
            this.gb5_ba.Location = new System.Drawing.Point(106, 334);
            this.gb5_ba.Name = "gb5_ba";
            this.gb5_ba.Size = new System.Drawing.Size(93, 90);
            this.gb5_ba.TabIndex = 30;
            this.gb5_ba.TabStop = false;
            this.gb5_ba.Text = "шина адреса";
            // 
            // rb5_a_01
            // 
            this.rb5_a_01.AutoSize = true;
            this.rb5_a_01.Location = new System.Drawing.Point(7, 65);
            this.rb5_a_01.Name = "rb5_a_01";
            this.rb5_a_01.Size = new System.Drawing.Size(68, 17);
            this.rb5_a_01.TabIndex = 2;
            this.rb5_a_01.Text = "одна \"1\"";
            this.rb5_a_01.UseVisualStyleBackColor = true;
            // 
            // rb5_a_1
            // 
            this.rb5_a_1.AutoSize = true;
            this.rb5_a_1.Location = new System.Drawing.Point(7, 42);
            this.rb5_a_1.Name = "rb5_a_1";
            this.rb5_a_1.Size = new System.Drawing.Size(62, 17);
            this.rb5_a_1.TabIndex = 1;
            this.rb5_a_1.Text = "все \"1\"";
            this.rb5_a_1.UseVisualStyleBackColor = true;
            // 
            // rb5_a_0
            // 
            this.rb5_a_0.AutoSize = true;
            this.rb5_a_0.Checked = true;
            this.rb5_a_0.Location = new System.Drawing.Point(7, 20);
            this.rb5_a_0.Name = "rb5_a_0";
            this.rb5_a_0.Size = new System.Drawing.Size(62, 17);
            this.rb5_a_0.TabIndex = 0;
            this.rb5_a_0.TabStop = true;
            this.rb5_a_0.Text = "все \"0\"";
            this.rb5_a_0.UseVisualStyleBackColor = true;
            // 
            // chb5_d21
            // 
            this.chb5_d21.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb5_d21.Location = new System.Drawing.Point(7, 305);
            this.chb5_d21.Name = "chb5_d21";
            this.chb5_d21.Size = new System.Drawing.Size(40, 23);
            this.chb5_d21.TabIndex = 30;
            this.chb5_d21.Text = "D21";
            this.chb5_d21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb5_d21.UseVisualStyleBackColor = true;
            this.chb5_d21.CheckedChanged += new System.EventHandler(this.chb5_d21_CheckedChanged);
            // 
            // gb5_bd
            // 
            this.gb5_bd.Controls.Add(this.rb5_d_01);
            this.gb5_bd.Controls.Add(this.rb5_d_1);
            this.gb5_bd.Controls.Add(this.rb5_d_0);
            this.gb5_bd.Location = new System.Drawing.Point(7, 334);
            this.gb5_bd.Name = "gb5_bd";
            this.gb5_bd.Size = new System.Drawing.Size(93, 90);
            this.gb5_bd.TabIndex = 29;
            this.gb5_bd.TabStop = false;
            this.gb5_bd.Text = "шина данных";
            // 
            // rb5_d_01
            // 
            this.rb5_d_01.AutoSize = true;
            this.rb5_d_01.Location = new System.Drawing.Point(7, 65);
            this.rb5_d_01.Name = "rb5_d_01";
            this.rb5_d_01.Size = new System.Drawing.Size(68, 17);
            this.rb5_d_01.TabIndex = 2;
            this.rb5_d_01.Text = "одна \"1\"";
            this.rb5_d_01.UseVisualStyleBackColor = true;
            // 
            // rb5_d_1
            // 
            this.rb5_d_1.AutoSize = true;
            this.rb5_d_1.Location = new System.Drawing.Point(7, 42);
            this.rb5_d_1.Name = "rb5_d_1";
            this.rb5_d_1.Size = new System.Drawing.Size(62, 17);
            this.rb5_d_1.TabIndex = 1;
            this.rb5_d_1.Text = "все \"1\"";
            this.rb5_d_1.UseVisualStyleBackColor = true;
            // 
            // rb5_d_0
            // 
            this.rb5_d_0.AutoSize = true;
            this.rb5_d_0.Checked = true;
            this.rb5_d_0.Location = new System.Drawing.Point(7, 20);
            this.rb5_d_0.Name = "rb5_d_0";
            this.rb5_d_0.Size = new System.Drawing.Size(62, 17);
            this.rb5_d_0.TabIndex = 0;
            this.rb5_d_0.TabStop = true;
            this.rb5_d_0.Text = "все \"0\"";
            this.rb5_d_0.UseVisualStyleBackColor = true;
            // 
            // lb_test_D19_2
            // 
            this.lb_test_D19_2.AutoSize = true;
            this.lb_test_D19_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_test_D19_2.Location = new System.Drawing.Point(185, 251);
            this.lb_test_D19_2.Name = "lb_test_D19_2";
            this.lb_test_D19_2.Size = new System.Drawing.Size(0, 13);
            this.lb_test_D19_2.TabIndex = 28;
            this.lb_test_D19_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_test_D19_2
            // 
            this.bt_test_D19_2.Location = new System.Drawing.Point(6, 246);
            this.bt_test_D19_2.Name = "bt_test_D19_2";
            this.bt_test_D19_2.Size = new System.Drawing.Size(150, 23);
            this.bt_test_D19_2.TabIndex = 27;
            this.bt_test_D19_2.Text = "Проверка памяти D19 (2)";
            this.bt_test_D19_2.UseVisualStyleBackColor = true;
            this.bt_test_D19_2.Click += new System.EventHandler(this.bt_test_D19_2_Click);
            // 
            // lb_test_D13_2
            // 
            this.lb_test_D13_2.AutoSize = true;
            this.lb_test_D13_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_test_D13_2.Location = new System.Drawing.Point(185, 222);
            this.lb_test_D13_2.Name = "lb_test_D13_2";
            this.lb_test_D13_2.Size = new System.Drawing.Size(0, 13);
            this.lb_test_D13_2.TabIndex = 26;
            this.lb_test_D13_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_test_D13_2
            // 
            this.bt_test_D13_2.Location = new System.Drawing.Point(6, 217);
            this.bt_test_D13_2.Name = "bt_test_D13_2";
            this.bt_test_D13_2.Size = new System.Drawing.Size(150, 23);
            this.bt_test_D13_2.TabIndex = 25;
            this.bt_test_D13_2.Text = "Проверка памяти D13 (2)";
            this.bt_test_D13_2.UseVisualStyleBackColor = true;
            this.bt_test_D13_2.Click += new System.EventHandler(this.bt_test_D13_2_Click);
            // 
            // lb_test_FLASH_2
            // 
            this.lb_test_FLASH_2.AutoSize = true;
            this.lb_test_FLASH_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_test_FLASH_2.Location = new System.Drawing.Point(281, 280);
            this.lb_test_FLASH_2.Name = "lb_test_FLASH_2";
            this.lb_test_FLASH_2.Size = new System.Drawing.Size(0, 13);
            this.lb_test_FLASH_2.TabIndex = 24;
            this.lb_test_FLASH_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chb_Sin
            // 
            this.chb_Sin.AutoSize = true;
            this.chb_Sin.Location = new System.Drawing.Point(7, 501);
            this.chb_Sin.Name = "chb_Sin";
            this.chb_Sin.Size = new System.Drawing.Size(168, 17);
            this.chb_Sin.TabIndex = 19;
            this.chb_Sin.Text = "Включить генератор синуса";
            this.chb_Sin.UseVisualStyleBackColor = true;
            // 
            // chb_Peltier2
            // 
            this.chb_Peltier2.AutoSize = true;
            this.chb_Peltier2.Location = new System.Drawing.Point(154, 478);
            this.chb_Peltier2.Name = "chb_Peltier2";
            this.chb_Peltier2.Size = new System.Drawing.Size(141, 17);
            this.chb_Peltier2.TabIndex = 18;
            this.chb_Peltier2.Text = "Включить Пельтье №2";
            this.chb_Peltier2.UseVisualStyleBackColor = true;
            this.chb_Peltier2.CheckedChanged += new System.EventHandler(this.chb_Peltier2_CheckedChanged);
            // 
            // chb_Peltier1
            // 
            this.chb_Peltier1.AutoSize = true;
            this.chb_Peltier1.Location = new System.Drawing.Point(7, 478);
            this.chb_Peltier1.Name = "chb_Peltier1";
            this.chb_Peltier1.Size = new System.Drawing.Size(141, 17);
            this.chb_Peltier1.TabIndex = 17;
            this.chb_Peltier1.Text = "Включить Пельтье №1";
            this.chb_Peltier1.UseVisualStyleBackColor = true;
            this.chb_Peltier1.CheckedChanged += new System.EventHandler(this.chb_Peltier1_CheckedChanged);
            // 
            // chb_cycle_test_D19
            // 
            this.chb_cycle_test_D19.AutoSize = true;
            this.chb_cycle_test_D19.Location = new System.Drawing.Point(165, 193);
            this.chb_cycle_test_D19.Name = "chb_cycle_test_D19";
            this.chb_cycle_test_D19.Size = new System.Drawing.Size(15, 14);
            this.chb_cycle_test_D19.TabIndex = 16;
            this.chb_cycle_test_D19.UseVisualStyleBackColor = true;
            // 
            // chb_cycle_test_D13
            // 
            this.chb_cycle_test_D13.AutoSize = true;
            this.chb_cycle_test_D13.Location = new System.Drawing.Point(165, 164);
            this.chb_cycle_test_D13.Name = "chb_cycle_test_D13";
            this.chb_cycle_test_D13.Size = new System.Drawing.Size(15, 14);
            this.chb_cycle_test_D13.TabIndex = 15;
            this.chb_cycle_test_D13.UseVisualStyleBackColor = true;
            // 
            // chb_cycle_test_D21
            // 
            this.chb_cycle_test_D21.AutoSize = true;
            this.chb_cycle_test_D21.Location = new System.Drawing.Point(165, 54);
            this.chb_cycle_test_D21.Name = "chb_cycle_test_D21";
            this.chb_cycle_test_D21.Size = new System.Drawing.Size(15, 14);
            this.chb_cycle_test_D21.TabIndex = 14;
            this.chb_cycle_test_D21.UseVisualStyleBackColor = true;
            // 
            // lb_test_FLASH
            // 
            this.lb_test_FLASH.AutoSize = true;
            this.lb_test_FLASH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_test_FLASH.Location = new System.Drawing.Point(187, 280);
            this.lb_test_FLASH.Name = "lb_test_FLASH";
            this.lb_test_FLASH.Size = new System.Drawing.Size(0, 13);
            this.lb_test_FLASH.TabIndex = 13;
            this.lb_test_FLASH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_test_FLASH
            // 
            this.bt_test_FLASH.Location = new System.Drawing.Point(6, 275);
            this.bt_test_FLASH.Name = "bt_test_FLASH";
            this.bt_test_FLASH.Size = new System.Drawing.Size(150, 23);
            this.bt_test_FLASH.TabIndex = 12;
            this.bt_test_FLASH.Text = "Проверка памяти FLASH";
            this.bt_test_FLASH.UseVisualStyleBackColor = true;
            this.bt_test_FLASH.Click += new System.EventHandler(this.bt_test_FLASH_Click);
            // 
            // lb_test_D21_2
            // 
            this.lb_test_D21_2.AutoSize = true;
            this.lb_test_D21_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_test_D21_2.Location = new System.Drawing.Point(186, 135);
            this.lb_test_D21_2.Name = "lb_test_D21_2";
            this.lb_test_D21_2.Size = new System.Drawing.Size(0, 13);
            this.lb_test_D21_2.TabIndex = 9;
            this.lb_test_D21_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_test_D21_2
            // 
            this.bt_test_D21_2.Location = new System.Drawing.Point(6, 130);
            this.bt_test_D21_2.Name = "bt_test_D21_2";
            this.bt_test_D21_2.Size = new System.Drawing.Size(150, 23);
            this.bt_test_D21_2.TabIndex = 8;
            this.bt_test_D21_2.Text = "Проверка памяти D21 (2)";
            this.bt_test_D21_2.UseVisualStyleBackColor = true;
            this.bt_test_D21_2.Click += new System.EventHandler(this.bt_test_D21_2_Click);
            // 
            // lb_test_D19
            // 
            this.lb_test_D19.AutoSize = true;
            this.lb_test_D19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_test_D19.Location = new System.Drawing.Point(186, 193);
            this.lb_test_D19.Name = "lb_test_D19";
            this.lb_test_D19.Size = new System.Drawing.Size(0, 13);
            this.lb_test_D19.TabIndex = 7;
            this.lb_test_D19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_test_D19
            // 
            this.bt_test_D19.Location = new System.Drawing.Point(6, 188);
            this.bt_test_D19.Name = "bt_test_D19";
            this.bt_test_D19.Size = new System.Drawing.Size(150, 23);
            this.bt_test_D19.TabIndex = 6;
            this.bt_test_D19.Text = "Проверка памяти D19";
            this.bt_test_D19.UseVisualStyleBackColor = true;
            this.bt_test_D19.Click += new System.EventHandler(this.bt_test_D19_Click);
            // 
            // lb_test_D13
            // 
            this.lb_test_D13.AutoSize = true;
            this.lb_test_D13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_test_D13.Location = new System.Drawing.Point(186, 164);
            this.lb_test_D13.Name = "lb_test_D13";
            this.lb_test_D13.Size = new System.Drawing.Size(0, 13);
            this.lb_test_D13.TabIndex = 5;
            this.lb_test_D13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_test_D13
            // 
            this.bt_test_D13.Location = new System.Drawing.Point(6, 159);
            this.bt_test_D13.Name = "bt_test_D13";
            this.bt_test_D13.Size = new System.Drawing.Size(150, 23);
            this.bt_test_D13.TabIndex = 4;
            this.bt_test_D13.Text = "Проверка памяти D13";
            this.bt_test_D13.UseVisualStyleBackColor = true;
            this.bt_test_D13.Click += new System.EventHandler(this.bt_test_D13_Click);
            // 
            // lb_test_D21_1
            // 
            this.lb_test_D21_1.AutoSize = true;
            this.lb_test_D21_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_test_D21_1.Location = new System.Drawing.Point(186, 54);
            this.lb_test_D21_1.Name = "lb_test_D21_1";
            this.lb_test_D21_1.Size = new System.Drawing.Size(0, 13);
            this.lb_test_D21_1.TabIndex = 3;
            this.lb_test_D21_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_test_D21_1
            // 
            this.bt_test_D21_1.Location = new System.Drawing.Point(7, 49);
            this.bt_test_D21_1.Name = "bt_test_D21_1";
            this.bt_test_D21_1.Size = new System.Drawing.Size(150, 23);
            this.bt_test_D21_1.TabIndex = 2;
            this.bt_test_D21_1.Text = "Проверка памяти D21 (1)";
            this.bt_test_D21_1.UseVisualStyleBackColor = true;
            this.bt_test_D21_1.Click += new System.EventHandler(this.bt_test_D21_1_Click);
            // 
            // lb_test_plis
            // 
            this.lb_test_plis.AutoSize = true;
            this.lb_test_plis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_test_plis.Location = new System.Drawing.Point(186, 25);
            this.lb_test_plis.Name = "lb_test_plis";
            this.lb_test_plis.Size = new System.Drawing.Size(0, 13);
            this.lb_test_plis.TabIndex = 1;
            this.lb_test_plis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_test_PLIS
            // 
            this.bt_test_PLIS.Location = new System.Drawing.Point(7, 20);
            this.bt_test_PLIS.Name = "bt_test_PLIS";
            this.bt_test_PLIS.Size = new System.Drawing.Size(150, 23);
            this.bt_test_PLIS.TabIndex = 0;
            this.bt_test_PLIS.Text = "Проверка загрузки ПЛИС";
            this.bt_test_PLIS.UseVisualStyleBackColor = true;
            this.bt_test_PLIS.Click += new System.EventHandler(this.bt_test_PLIS_Click);
            // 
            // bt_plis_init
            // 
            this.bt_plis_init.Location = new System.Drawing.Point(726, 155);
            this.bt_plis_init.Name = "bt_plis_init";
            this.bt_plis_init.Size = new System.Drawing.Size(44, 23);
            this.bt_plis_init.TabIndex = 34;
            this.bt_plis_init.Text = "Init";
            this.bt_plis_init.UseVisualStyleBackColor = true;
            this.bt_plis_init.Click += new System.EventHandler(this.bt_plis_init_Click);
            // 
            // gbox_CAN4
            // 
            this.gbox_CAN4.Controls.Add(this.lb_version);
            this.gbox_CAN4.Controls.Add(this.lb_noerr4);
            this.gbox_CAN4.Controls.Add(this.cb_CAN4);
            this.gbox_CAN4.Controls.Add(this.lb_error_CAN4);
            this.gbox_CAN4.Controls.Add(this.label20);
            this.gbox_CAN4.Controls.Add(this.bt_CloseCAN4);
            this.gbox_CAN4.Controls.Add(this.bt_OpenCAN4);
            this.gbox_CAN4.Location = new System.Drawing.Point(6, 9);
            this.gbox_CAN4.Name = "gbox_CAN4";
            this.gbox_CAN4.Size = new System.Drawing.Size(369, 105);
            this.gbox_CAN4.TabIndex = 41;
            this.gbox_CAN4.TabStop = false;
            this.gbox_CAN4.Text = "CAN";
            // 
            // lb_version
            // 
            this.lb_version.BackColor = System.Drawing.Color.SpringGreen;
            this.lb_version.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_version.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_version.Location = new System.Drawing.Point(6, 76);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(357, 21);
            this.lb_version.TabIndex = 30;
            this.lb_version.Text = "Тестовая прошивка";
            this.lb_version.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_version.Visible = false;
            // 
            // lb_noerr4
            // 
            this.lb_noerr4.BackColor = System.Drawing.Color.SpringGreen;
            this.lb_noerr4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_noerr4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_noerr4.Location = new System.Drawing.Point(6, 49);
            this.lb_noerr4.Name = "lb_noerr4";
            this.lb_noerr4.Size = new System.Drawing.Size(357, 21);
            this.lb_noerr4.TabIndex = 15;
            this.lb_noerr4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_noerr4.Visible = false;
            // 
            // cb_CAN4
            // 
            this.cb_CAN4.FormattingEnabled = true;
            this.cb_CAN4.Location = new System.Drawing.Point(6, 20);
            this.cb_CAN4.Name = "cb_CAN4";
            this.cb_CAN4.Size = new System.Drawing.Size(225, 21);
            this.cb_CAN4.TabIndex = 29;
            // 
            // lb_error_CAN4
            // 
            this.lb_error_CAN4.BackColor = System.Drawing.Color.Red;
            this.lb_error_CAN4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_error_CAN4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_error_CAN4.Location = new System.Drawing.Point(6, 49);
            this.lb_error_CAN4.Name = "lb_error_CAN4";
            this.lb_error_CAN4.Size = new System.Drawing.Size(357, 21);
            this.lb_error_CAN4.TabIndex = 14;
            this.lb_error_CAN4.Text = "Не удалось открыть CAN";
            this.lb_error_CAN4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_error_CAN4.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(159, 49);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 13);
            this.label20.TabIndex = 10;
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_CloseCAN4
            // 
            this.bt_CloseCAN4.Enabled = false;
            this.bt_CloseCAN4.Location = new System.Drawing.Point(300, 18);
            this.bt_CloseCAN4.Name = "bt_CloseCAN4";
            this.bt_CloseCAN4.Size = new System.Drawing.Size(63, 23);
            this.bt_CloseCAN4.TabIndex = 2;
            this.bt_CloseCAN4.Text = "Закрыть";
            this.bt_CloseCAN4.UseVisualStyleBackColor = true;
            this.bt_CloseCAN4.Click += new System.EventHandler(this.bt_CloseCAN4_Click);
            // 
            // bt_OpenCAN4
            // 
            this.bt_OpenCAN4.Location = new System.Drawing.Point(237, 18);
            this.bt_OpenCAN4.Name = "bt_OpenCAN4";
            this.bt_OpenCAN4.Size = new System.Drawing.Size(60, 23);
            this.bt_OpenCAN4.TabIndex = 0;
            this.bt_OpenCAN4.Text = "Открыть";
            this.bt_OpenCAN4.UseVisualStyleBackColor = true;
            this.bt_OpenCAN4.Click += new System.EventHandler(this.bt_OpenCAN4_Click);
            // 
            // bt_About4
            // 
            this.bt_About4.Location = new System.Drawing.Point(839, 592);
            this.bt_About4.Name = "bt_About4";
            this.bt_About4.Size = new System.Drawing.Size(108, 23);
            this.bt_About4.TabIndex = 38;
            this.bt_About4.Text = "О программе";
            this.bt_About4.UseVisualStyleBackColor = true;
            this.bt_About4.Click += new System.EventHandler(this.bt_About_Click);
            // 
            // bt_Exit4
            // 
            this.bt_Exit4.Location = new System.Drawing.Point(839, 621);
            this.bt_Exit4.Name = "bt_Exit4";
            this.bt_Exit4.Size = new System.Drawing.Size(108, 23);
            this.bt_Exit4.TabIndex = 37;
            this.bt_Exit4.Text = "Выход";
            this.bt_Exit4.UseVisualStyleBackColor = true;
            this.bt_Exit4.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.richTextBox1);
            this.tabPage7.Controls.Add(this.label58);
            this.tabPage7.Controls.Add(this.trackBar3);
            this.tabPage7.Controls.Add(this.label56);
            this.tabPage7.Controls.Add(this.trackBar2);
            this.tabPage7.Controls.Add(this.button3);
            this.tabPage7.Controls.Add(this.bt_verifi5);
            this.tabPage7.Controls.Add(this.bt_status5);
            this.tabPage7.Controls.Add(this.bt_reboot5);
            this.tabPage7.Controls.Add(this.rb_l5);
            this.tabPage7.Controls.Add(this.rb_r5);
            this.tabPage7.Controls.Add(this.bt_aktiv5);
            this.tabPage7.Controls.Add(this.progressBar1);
            this.tabPage7.Controls.Add(this.dataGridView1);
            this.tabPage7.Controls.Add(this.bt_About5);
            this.tabPage7.Controls.Add(this.bt_Exit5);
            this.tabPage7.Controls.Add(this.gbox_CAN5);
            this.tabPage7.Location = new System.Drawing.Point(4, 29);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(962, 654);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "МУП";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 296);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox1.Size = new System.Drawing.Size(776, 348);
            this.richTextBox1.TabIndex = 74;
            this.richTextBox1.Text = "";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(433, 23);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(41, 13);
            this.label58.TabIndex = 73;
            this.label58.Text = "label58";
            this.label58.Visible = false;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(423, 42);
            this.trackBar3.Maximum = 1000;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(284, 45);
            this.trackBar3.TabIndex = 72;
            this.trackBar3.Visible = false;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(722, 23);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(41, 13);
            this.label56.TabIndex = 71;
            this.label56.Text = "label56";
            this.label56.Visible = false;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(713, 42);
            this.trackBar2.Maximum = 1023;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(243, 45);
            this.trackBar2.TabIndex = 70;
            this.trackBar2.Visible = false;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(713, 103);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 69;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bt_verifi5
            // 
            this.bt_verifi5.Location = new System.Drawing.Point(551, 103);
            this.bt_verifi5.Name = "bt_verifi5";
            this.bt_verifi5.Size = new System.Drawing.Size(95, 23);
            this.bt_verifi5.TabIndex = 67;
            this.bt_verifi5.Text = "Верификация";
            this.bt_verifi5.UseVisualStyleBackColor = true;
            this.bt_verifi5.Click += new System.EventHandler(this.bt_verifi5_Click);
            // 
            // bt_status5
            // 
            this.bt_status5.Location = new System.Drawing.Point(450, 103);
            this.bt_status5.Name = "bt_status5";
            this.bt_status5.Size = new System.Drawing.Size(95, 23);
            this.bt_status5.TabIndex = 66;
            this.bt_status5.Text = "Статус";
            this.bt_status5.UseVisualStyleBackColor = true;
            this.bt_status5.Click += new System.EventHandler(this.bt_status5_Click);
            // 
            // bt_reboot5
            // 
            this.bt_reboot5.Location = new System.Drawing.Point(303, 103);
            this.bt_reboot5.Name = "bt_reboot5";
            this.bt_reboot5.Size = new System.Drawing.Size(95, 23);
            this.bt_reboot5.TabIndex = 65;
            this.bt_reboot5.Text = "Перезагрузить";
            this.bt_reboot5.UseVisualStyleBackColor = true;
            this.bt_reboot5.Click += new System.EventHandler(this.bt_reboot5_Click);
            // 
            // rb_l5
            // 
            this.rb_l5.AutoSize = true;
            this.rb_l5.Location = new System.Drawing.Point(110, 106);
            this.rb_l5.Name = "rb_l5";
            this.rb_l5.Size = new System.Drawing.Size(86, 17);
            this.rb_l5.TabIndex = 64;
            this.rb_l5.Text = "ОЛО-Левый";
            this.rb_l5.UseVisualStyleBackColor = true;
            // 
            // rb_r5
            // 
            this.rb_r5.AutoSize = true;
            this.rb_r5.Checked = true;
            this.rb_r5.Location = new System.Drawing.Point(12, 106);
            this.rb_r5.Name = "rb_r5";
            this.rb_r5.Size = new System.Drawing.Size(92, 17);
            this.rb_r5.TabIndex = 63;
            this.rb_r5.TabStop = true;
            this.rb_r5.Text = "ОЛО-Правый";
            this.rb_r5.UseVisualStyleBackColor = true;
            // 
            // bt_aktiv5
            // 
            this.bt_aktiv5.Location = new System.Drawing.Point(202, 103);
            this.bt_aktiv5.Name = "bt_aktiv5";
            this.bt_aktiv5.Size = new System.Drawing.Size(95, 23);
            this.bt_aktiv5.TabIndex = 62;
            this.bt_aktiv5.Text = "Активировать";
            this.bt_aktiv5.UseVisualStyleBackColor = true;
            this.bt_aktiv5.Click += new System.EventHandler(this.bt_aktiv5_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 277);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(776, 13);
            this.progressBar1.TabIndex = 61;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.start,
            this._size,
            this.time,
            this.crc32,
            this.vers,
            this.comment,
            this.id});
            this.dataGridView1.Location = new System.Drawing.Point(12, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 136);
            this.dataGridView1.TabIndex = 60;
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // name
            // 
            this.name.HeaderText = "Имя файла";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.name.Width = 150;
            // 
            // start
            // 
            this.start.HeaderText = "Адрес";
            this.start.Name = "start";
            this.start.ReadOnly = true;
            this.start.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.start.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.start.Width = 50;
            // 
            // _size
            // 
            this._size.HeaderText = "Размер";
            this._size.Name = "_size";
            this._size.ReadOnly = true;
            this._size.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._size.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._size.Width = 60;
            // 
            // time
            // 
            this.time.HeaderText = "Время";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.time.Width = 110;
            // 
            // crc32
            // 
            this.crc32.HeaderText = "CRC32";
            this.crc32.Name = "crc32";
            this.crc32.ReadOnly = true;
            this.crc32.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.crc32.Width = 70;
            // 
            // vers
            // 
            this.vers.HeaderText = "Версия";
            this.vers.Name = "vers";
            this.vers.ReadOnly = true;
            this.vers.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.vers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.vers.Width = 50;
            // 
            // comment
            // 
            this.comment.HeaderText = "Комментарий";
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            this.comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.comment.Width = 280;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // bt_About5
            // 
            this.bt_About5.Location = new System.Drawing.Point(839, 592);
            this.bt_About5.Name = "bt_About5";
            this.bt_About5.Size = new System.Drawing.Size(108, 23);
            this.bt_About5.TabIndex = 42;
            this.bt_About5.Text = "О программе";
            this.bt_About5.UseVisualStyleBackColor = true;
            this.bt_About5.Click += new System.EventHandler(this.bt_About_Click);
            // 
            // bt_Exit5
            // 
            this.bt_Exit5.Location = new System.Drawing.Point(839, 621);
            this.bt_Exit5.Name = "bt_Exit5";
            this.bt_Exit5.Size = new System.Drawing.Size(108, 23);
            this.bt_Exit5.TabIndex = 41;
            this.bt_Exit5.Text = "Выход";
            this.bt_Exit5.UseVisualStyleBackColor = true;
            this.bt_Exit5.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // gbox_CAN5
            // 
            this.gbox_CAN5.Controls.Add(this.lb_noerr5);
            this.gbox_CAN5.Controls.Add(this.cb_CAN5);
            this.gbox_CAN5.Controls.Add(this.lb_error_CAN5);
            this.gbox_CAN5.Controls.Add(this.label51);
            this.gbox_CAN5.Controls.Add(this.bt_CloseCAN5);
            this.gbox_CAN5.Controls.Add(this.bt_OpenCAN5);
            this.gbox_CAN5.Location = new System.Drawing.Point(6, 9);
            this.gbox_CAN5.Name = "gbox_CAN5";
            this.gbox_CAN5.Size = new System.Drawing.Size(369, 78);
            this.gbox_CAN5.TabIndex = 40;
            this.gbox_CAN5.TabStop = false;
            this.gbox_CAN5.Text = "CAN";
            // 
            // lb_noerr5
            // 
            this.lb_noerr5.BackColor = System.Drawing.Color.SpringGreen;
            this.lb_noerr5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_noerr5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_noerr5.Location = new System.Drawing.Point(6, 49);
            this.lb_noerr5.Name = "lb_noerr5";
            this.lb_noerr5.Size = new System.Drawing.Size(357, 21);
            this.lb_noerr5.TabIndex = 15;
            this.lb_noerr5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_noerr5.Visible = false;
            // 
            // cb_CAN5
            // 
            this.cb_CAN5.FormattingEnabled = true;
            this.cb_CAN5.Location = new System.Drawing.Point(6, 20);
            this.cb_CAN5.Name = "cb_CAN5";
            this.cb_CAN5.Size = new System.Drawing.Size(225, 21);
            this.cb_CAN5.TabIndex = 29;
            // 
            // lb_error_CAN5
            // 
            this.lb_error_CAN5.BackColor = System.Drawing.Color.Red;
            this.lb_error_CAN5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_error_CAN5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_error_CAN5.Location = new System.Drawing.Point(6, 49);
            this.lb_error_CAN5.Name = "lb_error_CAN5";
            this.lb_error_CAN5.Size = new System.Drawing.Size(357, 21);
            this.lb_error_CAN5.TabIndex = 14;
            this.lb_error_CAN5.Text = "Не удалось открыть CAN";
            this.lb_error_CAN5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_error_CAN5.Visible = false;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label51.Location = new System.Drawing.Point(159, 49);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(0, 13);
            this.label51.TabIndex = 10;
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_CloseCAN5
            // 
            this.bt_CloseCAN5.Enabled = false;
            this.bt_CloseCAN5.Location = new System.Drawing.Point(300, 18);
            this.bt_CloseCAN5.Name = "bt_CloseCAN5";
            this.bt_CloseCAN5.Size = new System.Drawing.Size(63, 23);
            this.bt_CloseCAN5.TabIndex = 2;
            this.bt_CloseCAN5.Text = "Закрыть";
            this.bt_CloseCAN5.UseVisualStyleBackColor = true;
            this.bt_CloseCAN5.Click += new System.EventHandler(this.bt_CloseCAN5_Click);
            // 
            // bt_OpenCAN5
            // 
            this.bt_OpenCAN5.Location = new System.Drawing.Point(237, 18);
            this.bt_OpenCAN5.Name = "bt_OpenCAN5";
            this.bt_OpenCAN5.Size = new System.Drawing.Size(60, 23);
            this.bt_OpenCAN5.TabIndex = 0;
            this.bt_OpenCAN5.Text = "Открыть";
            this.bt_OpenCAN5.UseVisualStyleBackColor = true;
            this.bt_OpenCAN5.Click += new System.EventHandler(this.bt_OpenCAN5_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button4);
            this.tabPage6.Controls.Add(this.chb_6_6);
            this.tabPage6.Controls.Add(this.bt_6_savesetup);
            this.tabPage6.Controls.Add(this.chb_6_7);
            this.tabPage6.Controls.Add(this.chb_6_5);
            this.tabPage6.Controls.Add(this.chb_6_4);
            this.tabPage6.Controls.Add(this.chb_6_3);
            this.tabPage6.Controls.Add(this.chb_6_2);
            this.tabPage6.Controls.Add(this.chb_6_1);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(962, 654);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Настройка";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(879, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // chb_6_6
            // 
            this.chb_6_6.AutoSize = true;
            this.chb_6_6.Location = new System.Drawing.Point(9, 161);
            this.chb_6_6.Name = "chb_6_6";
            this.chb_6_6.Size = new System.Drawing.Size(81, 17);
            this.chb_6_6.TabIndex = 7;
            this.chb_6_6.Text = "Настройка";
            this.chb_6_6.UseVisualStyleBackColor = true;
            // 
            // bt_6_savesetup
            // 
            this.bt_6_savesetup.Location = new System.Drawing.Point(9, 184);
            this.bt_6_savesetup.Name = "bt_6_savesetup";
            this.bt_6_savesetup.Size = new System.Drawing.Size(75, 23);
            this.bt_6_savesetup.TabIndex = 6;
            this.bt_6_savesetup.Text = "save";
            this.bt_6_savesetup.UseVisualStyleBackColor = true;
            this.bt_6_savesetup.Click += new System.EventHandler(this.button7_Click);
            // 
            // chb_6_7
            // 
            this.chb_6_7.AutoSize = true;
            this.chb_6_7.Location = new System.Drawing.Point(9, 138);
            this.chb_6_7.Name = "chb_6_7";
            this.chb_6_7.Size = new System.Drawing.Size(51, 17);
            this.chb_6_7.TabIndex = 5;
            this.chb_6_7.Text = "МУП";
            this.chb_6_7.UseVisualStyleBackColor = true;
            // 
            // chb_6_5
            // 
            this.chb_6_5.AutoSize = true;
            this.chb_6_5.Location = new System.Drawing.Point(9, 114);
            this.chb_6_5.Name = "chb_6_5";
            this.chb_6_5.Size = new System.Drawing.Size(75, 17);
            this.chb_6_5.TabIndex = 4;
            this.chb_6_5.Text = "Тест БОС";
            this.chb_6_5.UseVisualStyleBackColor = true;
            // 
            // chb_6_4
            // 
            this.chb_6_4.AutoSize = true;
            this.chb_6_4.Location = new System.Drawing.Point(9, 90);
            this.chb_6_4.Name = "chb_6_4";
            this.chb_6_4.Size = new System.Drawing.Size(75, 17);
            this.chb_6_4.TabIndex = 3;
            this.chb_6_4.Text = "Эмулятор";
            this.chb_6_4.UseVisualStyleBackColor = true;
            // 
            // chb_6_3
            // 
            this.chb_6_3.AutoSize = true;
            this.chb_6_3.Location = new System.Drawing.Point(9, 66);
            this.chb_6_3.Name = "chb_6_3";
            this.chb_6_3.Size = new System.Drawing.Size(77, 17);
            this.chb_6_3.TabIndex = 2;
            this.chb_6_3.Text = "Тест ОЛО";
            this.chb_6_3.UseVisualStyleBackColor = true;
            // 
            // chb_6_2
            // 
            this.chb_6_2.AutoSize = true;
            this.chb_6_2.Location = new System.Drawing.Point(9, 42);
            this.chb_6_2.Name = "chb_6_2";
            this.chb_6_2.Size = new System.Drawing.Size(92, 17);
            this.chb_6_2.TabIndex = 1;
            this.chb_6_2.Text = "Загрузка ПО";
            this.chb_6_2.UseVisualStyleBackColor = true;
            // 
            // chb_6_1
            // 
            this.chb_6_1.AutoSize = true;
            this.chb_6_1.Location = new System.Drawing.Point(9, 18);
            this.chb_6_1.Name = "chb_6_1";
            this.chb_6_1.Size = new System.Drawing.Size(82, 17);
            this.chb_6_1.TabIndex = 0;
            this.chb_6_1.Text = "Юстировка";
            this.chb_6_1.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripSeparator1,
            this.toolStripMenuItem4,
            this.toolStripSeparator2,
            this.toolStripMenuItem5});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 126);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "Скачать";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "Заменить";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "Стереть";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem5.Image")));
            this.toolStripMenuItem5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = "Проверить";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // Timer_UpdateTime
            // 
            this.Timer_UpdateTime.Enabled = true;
            this.Timer_UpdateTime.Interval = 500;
            this.Timer_UpdateTime.Tick += new System.EventHandler(this.Timer_UpdateTime_Tick);
            // 
            // Timer_GetData
            // 
            this.Timer_GetData.Interval = 5;
            this.Timer_GetData.Tick += new System.EventHandler(this.Timer_GetData_Tick);
            // 
            // timer_testOLO_L
            // 
            this.timer_testOLO_L.Tick += new System.EventHandler(this.timer_testOLO_L_Tick);
            // 
            // timer_testOLO_R
            // 
            this.timer_testOLO_R.Tick += new System.EventHandler(this.timer_testOLO_R_Tick);
            // 
            // timer_Reset_Shots
            // 
            this.timer_Reset_Shots.Interval = 10000;
            this.timer_Reset_Shots.Tick += new System.EventHandler(this.timer_Reset_Shots_Tick);
            // 
            // timer_Reset_Shots3
            // 
            this.timer_Reset_Shots3.Interval = 5000;
            this.timer_Reset_Shots3.Tick += new System.EventHandler(this.timer_Reset_Shots3_Tick);
            // 
            // timer_testOLO_R3
            // 
            this.timer_testOLO_R3.Tick += new System.EventHandler(this.timer_testOLO_R3_Tick);
            // 
            // timer_testOLO_L3
            // 
            this.timer_testOLO_L3.Tick += new System.EventHandler(this.timer_testOLO_L3_Tick);
            // 
            // Timer_GetData3
            // 
            this.Timer_GetData3.Tick += new System.EventHandler(this.Timer_GetData3_Tick);
            // 
            // timer_temperature
            // 
            this.timer_temperature.Interval = 500;
            this.timer_temperature.Tick += new System.EventHandler(this.timer_temperature_Tick);
            // 
            // timer_Error_Boot
            // 
            this.timer_Error_Boot.Interval = 75000;
            this.timer_Error_Boot.Tick += new System.EventHandler(this.timer_Error_Boot_Tick);
            // 
            // tm4_counter
            // 
            this.tm4_counter.Tick += new System.EventHandler(this.tm4_counter_Tick);
            // 
            // tm4_test
            // 
            this.tm4_test.Interval = 50;
            this.tm4_test.Tick += new System.EventHandler(this.tm4_test_Tick);
            // 
            // timer1s
            // 
            this.timer1s.Interval = 1000;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripSeparator3,
            this.toolStripMenuItem9,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripSeparator4,
            this.toolStripMenuItem8});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(294, 148);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem6.Image")));
            this.toolStripMenuItem6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(293, 22);
            this.toolStripMenuItem6.Text = "toolStripMenuItem6";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem7.Image")));
            this.toolStripMenuItem7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(293, 22);
            this.toolStripMenuItem7.Text = "Закачать";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(290, 6);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem9.Image")));
            this.toolStripMenuItem9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(293, 22);
            this.toolStripMenuItem9.Text = "Закачать файл прошивки";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem10.Image")));
            this.toolStripMenuItem10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(293, 22);
            this.toolStripMenuItem10.Text = "Закачать файл конфигурации";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Image = global::OLO_CAN.Properties.Resources.a_right;
            this.toolStripMenuItem11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(293, 22);
            this.toolStripMenuItem11.Text = "Создать и закачать файл конфигурации";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(290, 6);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem8.Image")));
            this.toolStripMenuItem8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(293, 22);
            this.toolStripMenuItem8.Text = "Форматировать";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // timer3_reset_l
            // 
            this.timer3_reset_l.Interval = 30000;
            this.timer3_reset_l.Tick += new System.EventHandler(this.timer3_reset_l_Tick);
            // 
            // timer3_reset_r
            // 
            this.timer3_reset_r.Interval = 30000;
            this.timer3_reset_r.Tick += new System.EventHandler(this.timer3_reset_r_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 687);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbox_Temperature.ResumeLayout(false);
            this.gbox_Temperature.PerformLayout();
            this.gbox_Cross.ResumeLayout(false);
            this.gbox_Cross.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_CCirkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_CAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_CY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_CX)).EndInit();
            this.gbox_Process.ResumeLayout(false);
            this.gbox_Process.PerformLayout();
            this.gbox_Passports.ResumeLayout(false);
            this.gbox_Passports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_BadPixLimit)).EndInit();
            this.gbox_CMOS2.ResumeLayout(false);
            this.gbox_CMOS2.PerformLayout();
            this.gbox_CMOS1.ResumeLayout(false);
            this.gbox_CMOS1.PerformLayout();
            this.gbox_Image.ResumeLayout(false);
            this.gbox_Image.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbox_CAN.ResumeLayout(false);
            this.gbox_CAN.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.gb1_Addr.ResumeLayout(false);
            this.gb1_Addr.PerformLayout();
            this.gb_MC1.ResumeLayout(false);
            this.gb_MC1.PerformLayout();
            this.gb_CAN1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_stR2.ResumeLayout(false);
            this.gb_stR2.PerformLayout();
            this.gb_stL2.ResumeLayout(false);
            this.gb_stL2.PerformLayout();
            this.gbox_ecR2.ResumeLayout(false);
            this.gbox_ecR2.PerformLayout();
            this.gbox_ecL2.ResumeLayout(false);
            this.gbox_ecL2.PerformLayout();
            this.gbox_statusR2.ResumeLayout(false);
            this.gbox_statusR2.PerformLayout();
            this.gbox_statusL2.ResumeLayout(false);
            this.gbox_statusL2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.gbox_CAN2.ResumeLayout(false);
            this.gbox_CAN2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.gb3_shoot.ResumeLayout(false);
            this.gb3_shoot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_freq_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_um_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_az_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_freq_l)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_um_l)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_az_l)).EndInit();
            this.gb_olo_R.ResumeLayout(false);
            this.gb_olo_R.PerformLayout();
            this.gb_olo_L.ResumeLayout(false);
            this.gb_olo_L.PerformLayout();
            this.gbox_CAN3.ResumeLayout(false);
            this.gbox_CAN3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.gb_Image24.ResumeLayout(false);
            this.gb_Image24.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            this.gb_Temperature.ResumeLayout(false);
            this.gb_Temperature.PerformLayout();
            this.gb_Image14.ResumeLayout(false);
            this.gb_Image14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            this.gb_Tests.ResumeLayout(false);
            this.gb_Tests.PerformLayout();
            this.gb5_ba.ResumeLayout(false);
            this.gb5_ba.PerformLayout();
            this.gb5_bd.ResumeLayout(false);
            this.gb5_bd.PerformLayout();
            this.gbox_CAN4.ResumeLayout(false);
            this.gbox_CAN4.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbox_CAN5.ResumeLayout(false);
            this.gbox_CAN5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Timer VideoTimer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbox_Temperature;
        private System.Windows.Forms.Label lb_T1;
        private System.Windows.Forms.Label lb_T2;
        private System.Windows.Forms.Label lb_T2_val;
        private System.Windows.Forms.Label lb_T1_val;
        private System.Windows.Forms.GroupBox gbox_Cross;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chb_oldlens;
        private System.Windows.Forms.RadioButton rb_RightW;
        private System.Windows.Forms.RadioButton rb_LeftW;
        private System.Windows.Forms.Button bt_SaveConf;
        private System.Windows.Forms.CheckBox chb_CCirkle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown num_CCirkle;
        private System.Windows.Forms.NumericUpDown num_CAngle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown num_CY;
        private System.Windows.Forms.NumericUpDown num_CX;
        private System.Windows.Forms.CheckBox chb_EnableCross;
        private System.Windows.Forms.Button bt_About;
        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.GroupBox gbox_Process;
        private System.Windows.Forms.CheckBox chb_PHidebadpix;
        private System.Windows.Forms.CheckBox chb_PFIFO;
        private System.Windows.Forms.CheckBox chb_PShot;
        private System.Windows.Forms.CheckBox chb_PRunVideo;
        private System.Windows.Forms.RadioButton rb_CMOS2;
        private System.Windows.Forms.RadioButton rb_CMOS1;
        private System.Windows.Forms.GroupBox gbox_Passports;
        private System.Windows.Forms.CheckBox chb_Calibr;
        private System.Windows.Forms.Label lb_num_bad_points;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown num_BadPixLimit;
        private System.Windows.Forms.Button bt_sort_badpix;
        private System.Windows.Forms.Button bt_clear_badpix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listb_badpix;
        private System.Windows.Forms.Button bt_DnLoadConf;
        private System.Windows.Forms.Button bt_UpLoadConf;
        private System.Windows.Forms.Button bt_DnLoadPass;
        private System.Windows.Forms.Button bt_UpLoadPass;
        private System.Windows.Forms.Button bt_SavePass;
        private System.Windows.Forms.Label lb_num_points_in_pass;
        private System.Windows.Forms.ListBox listb_Passport;
        private System.Windows.Forms.GroupBox gbox_CMOS2;
        private System.Windows.Forms.CheckBox cb_CMOS2Enable;
        private System.Windows.Forms.TextBox tb_VINB2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CMOS2SetDAC2;
        private System.Windows.Forms.TextBox tb_VREF2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CMOS2SetDAC1;
        private System.Windows.Forms.GroupBox gbox_CMOS1;
        private System.Windows.Forms.CheckBox cb_CMOS1Enable;
        private System.Windows.Forms.TextBox tb_VINB1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CMOS1SetDAC2;
        private System.Windows.Forms.TextBox tb_VREF1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_CMOS1SetDAC1;
        private System.Windows.Forms.GroupBox gbox_Image;
        private System.Windows.Forms.ProgressBar pb_CMOS;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbox_CAN;
        private System.Windows.Forms.Label lb_noerr;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lb_error_CAN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bt_CloseCAN;
        private System.Windows.Forms.Button bt_OpenCAN;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox gb_MC1;
        private System.Windows.Forms.TextBox tb_fnameMC1;
        private System.Windows.Forms.ProgressBar pb_loadMC1;
        private System.Windows.Forms.CheckBox chb_eraseALL1;
        private System.Windows.Forms.Button bt_runMC1;
        private System.Windows.Forms.Label lb_Load_OK1;
        private System.Windows.Forms.Button bt_loadMC1;
        private System.Windows.Forms.Button bt_openMC1;
        private System.Windows.Forms.GroupBox gb_CAN1;
        private System.Windows.Forms.Label lb_noerr1;
        private System.Windows.Forms.Label lb_error_CAN1;
        private System.Windows.Forms.ComboBox cb_CAN1;
        private System.Windows.Forms.Button bt_About1;
        private System.Windows.Forms.Button bt_Exit1;
        private System.Windows.Forms.Button bt_About2;
        private System.Windows.Forms.Button bt_Exit2;
        private System.Windows.Forms.Button bt_About3;
        private System.Windows.Forms.Button bt_Exit3;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button bt_About4;
        private System.Windows.Forms.Button bt_Exit4;
        private System.Windows.Forms.Button btn_REQSN;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chb_dgview2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button bt_Request2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button bt_SyncTime;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox gbox_CAN2;
        private System.Windows.Forms.Label lb_noerr2;
        private System.Windows.Forms.ComboBox cb_CAN2;
        private System.Windows.Forms.Label lb_error_CAN2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button bt_CloseCAN2;
        private System.Windows.Forms.Button bt_OpenCAN2;
        private System.Windows.Forms.Timer Timer_UpdateTime;
        private System.Windows.Forms.Timer Timer_GetData;
        private System.Windows.Forms.Timer timer_testOLO_L;
        private System.Windows.Forms.Timer timer_testOLO_R;
        private System.Windows.Forms.Timer timer_Reset_Shots;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gb_olo_R;
        private System.Windows.Forms.CheckBox cb_olo_r_ena;
        private System.Windows.Forms.Button shoot_r;
        private System.Windows.Forms.GroupBox gb_olo_L;
        private System.Windows.Forms.CheckBox cb_olo_l_ena;
        private System.Windows.Forms.Button shoot_l;
        private System.Windows.Forms.CheckBox chb_dgview3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbox_CAN3;
        private System.Windows.Forms.Label lb_noerr3;
        private System.Windows.Forms.ComboBox cb_CAN3;
        private System.Windows.Forms.Label lb_error_CAN3;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button bt_CloseCAN3;
        private System.Windows.Forms.Button bt_OpenCAN3;
        private System.Windows.Forms.Timer timer_Reset_Shots3;
        private System.Windows.Forms.Timer timer_testOLO_R3;
        private System.Windows.Forms.Timer timer_testOLO_L3;
        private System.Windows.Forms.Timer Timer_GetData3;
        private System.Windows.Forms.GroupBox gbox_CAN4;
        private System.Windows.Forms.Label lb_noerr4;
        private System.Windows.Forms.ComboBox cb_CAN4;
        private System.Windows.Forms.Label lb_error_CAN4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button bt_CloseCAN4;
        private System.Windows.Forms.Button bt_OpenCAN4;
        private System.Windows.Forms.Label lb_version;
        private System.Windows.Forms.GroupBox gb_Image24;
        private System.Windows.Forms.PictureBox pictureBox24;
        private System.Windows.Forms.ProgressBar pb_CMOS2;
        private System.Windows.Forms.Label lb_CMOS24;
        private System.Windows.Forms.Button bt_get_CMOS2;
        private System.Windows.Forms.ProgressBar pb_CMOS1;
        private System.Windows.Forms.GroupBox gb_Temperature;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lb_T3_val4;
        private System.Windows.Forms.Label lb_T3;
        private System.Windows.Forms.Label lb_T2_val4;
        private System.Windows.Forms.Label lb_T1_val4;
        private System.Windows.Forms.GroupBox gb_Image14;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Button bt_get_CMOS1;
        private System.Windows.Forms.Label lb_CMOS14;
        private System.Windows.Forms.GroupBox gb_Tests;
        private System.Windows.Forms.Label lb_test_D19_2;
        private System.Windows.Forms.Button bt_test_D19_2;
        private System.Windows.Forms.Label lb_test_D13_2;
        private System.Windows.Forms.Button bt_test_D13_2;
        private System.Windows.Forms.Label lb_test_FLASH_2;
        private System.Windows.Forms.CheckBox chb_Sin;
        private System.Windows.Forms.CheckBox chb_Peltier2;
        private System.Windows.Forms.CheckBox chb_Peltier1;
        private System.Windows.Forms.CheckBox chb_cycle_test_D19;
        private System.Windows.Forms.CheckBox chb_cycle_test_D13;
        private System.Windows.Forms.CheckBox chb_cycle_test_D21;
        private System.Windows.Forms.Label lb_test_FLASH;
        private System.Windows.Forms.Button bt_test_FLASH;
        private System.Windows.Forms.Label lb_test_D21_2;
        private System.Windows.Forms.Button bt_test_D21_2;
        private System.Windows.Forms.Label lb_test_D19;
        private System.Windows.Forms.Button bt_test_D19;
        private System.Windows.Forms.Label lb_test_D13;
        private System.Windows.Forms.Button bt_test_D13;
        private System.Windows.Forms.Label lb_test_D21_1;
        private System.Windows.Forms.Button bt_test_D21_1;
        private System.Windows.Forms.Label lb_test_plis;
        private System.Windows.Forms.Button bt_test_PLIS;
        private System.Windows.Forms.Timer timer_temperature;
        private System.Windows.Forms.Timer timer_Error_Boot;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.RadioButton rb_flight_right_wing_double_pass;
        private System.Windows.Forms.RadioButton rb_flight_left_wing_double_pass;
        private System.Windows.Forms.RadioButton rb_cmos12_select;
        private System.Windows.Forms.RadioButton rb_cmos12_select_long_time;
        private System.Windows.Forms.RadioButton rb_file_open;
        private System.Windows.Forms.CheckBox chb_R_Err_file;
        private System.Windows.Forms.CheckBox chb_R_Err_plis;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox chb_R_Err_int;
        private System.Windows.Forms.CheckBox chb_L_Err_file;
        private System.Windows.Forms.CheckBox chb_L_Err_plis;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox chb_L_Err_int;
        private System.Windows.Forms.GroupBox gb3_shoot;
        private System.Windows.Forms.TrackBar trackBar3_um_l;
        private System.Windows.Forms.Label lb3_shoot_um_txt_l;
        private System.Windows.Forms.CheckBox chb3_shoot_ena;
        private System.Windows.Forms.TrackBar trackBar3_az_l;
        private System.Windows.Forms.Label lb3_shoot_az_txt_l;
        private System.Windows.Forms.Label lb3_shoot_um_val_l;
        private System.Windows.Forms.Label lb3_shoot_az_val_l;
        private System.Windows.Forms.GroupBox gb1_Addr;
        private System.Windows.Forms.RadioButton rb1_addr_right;
        private System.Windows.Forms.RadioButton rb1_addr_left;
        private System.Windows.Forms.RadioButton rb1_addr_uni;
        private System.Windows.Forms.GroupBox gb5_ba;
        private System.Windows.Forms.RadioButton rb5_a_01;
        private System.Windows.Forms.RadioButton rb5_a_1;
        private System.Windows.Forms.RadioButton rb5_a_0;
        private System.Windows.Forms.CheckBox chb5_d21;
        private System.Windows.Forms.GroupBox gb5_bd;
        private System.Windows.Forms.RadioButton rb5_d_01;
        private System.Windows.Forms.RadioButton rb5_d_1;
        private System.Windows.Forms.RadioButton rb5_d_0;
        private System.Windows.Forms.CheckBox chb5_d19;
        private System.Windows.Forms.CheckBox chb5_d13;
        private System.Windows.Forms.Button bt5_reset;
        private System.Windows.Forms.CheckBox chb5_timer_enable;
        private System.Windows.Forms.CheckBox chb3_savelog;
        private System.Windows.Forms.Label lb3_freq_txt_l;
        private System.Windows.Forms.TrackBar trackBar3_freq_l;
        private System.Windows.Forms.Label lb3_freq_val_l;
        private System.Windows.Forms.CheckBox chb4_enshr;
        private System.Windows.Forms.CheckBox chb4_enshl;
        private System.Windows.Forms.Timer tm4_counter;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox chb4_nopaint;
        private System.Windows.Forms.Timer tm4_test;
        private System.Windows.Forms.Timer timer1s;
        private System.Windows.Forms.Button REQ_VER;
        private System.Windows.Forms.CheckBox chb1_need_reset;
        private System.Windows.Forms.ComboBox cb_module2;
        private System.Windows.Forms.Button bt_mod2;
        private System.Windows.Forms.GroupBox gbox_statusL2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lb_statusL_t12;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label lb_statusL_file2;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label lb_statusL_plis2;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label lb_statusL_status2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lb_statusL_reason2;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lb_statusL_mode2;
        private System.Windows.Forms.Label lb_statusL_t32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lb_statusL_t22;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox gbox_statusR2;
        private System.Windows.Forms.Label lb_statusR_t32;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label lb_statusR_t22;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label lb_statusR_t12;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label lb_statusR_file2;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label lb_statusR_plis2;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label lb_statusR_status2;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label lb_statusR_reason2;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label lb_statusR_mode2;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox gbox_ecR2;
        private System.Windows.Forms.Label lb_ecR2_ram2;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label lb_ecR2_ram1;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label lb_ecR2_ram;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label lb_ecR2_file;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label lb_ecR2_plis2;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label lb_ecR2_plis1;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.GroupBox gbox_ecL2;
        private System.Windows.Forms.Label lb_ecL2_ram2;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label lb_ecL2_ram1;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label lb_ecL2_ram;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label lb_ecL2_file;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label lb_ecL2_plis2;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Label lb_ecL2_plis1;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Button btn_SAVESN;
        private System.Windows.Forms.TextBox tb_SN;
        private System.Windows.Forms.GroupBox gb_stR2;
        private System.Windows.Forms.Label lb_stR2_cmos2;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label lb_stR2_cmos1;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.GroupBox gb_stL2;
        private System.Windows.Forms.Label lb_stL2_cmos2;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lb_stL2_cmos1;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lb_plis_init;
        private System.Windows.Forms.Label lb_plis2_load;
        private System.Windows.Forms.Label lb_plis1_load;
        private System.Windows.Forms.Button bt_plis2_load;
        private System.Windows.Forms.Button bt_plis1_load;
        private System.Windows.Forms.Button bt_plis_init;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button bt_6_savesetup;
        private System.Windows.Forms.CheckBox chb_6_7;
        private System.Windows.Forms.CheckBox chb_6_5;
        private System.Windows.Forms.CheckBox chb_6_4;
        private System.Windows.Forms.CheckBox chb_6_3;
        private System.Windows.Forms.CheckBox chb_6_2;
        private System.Windows.Forms.CheckBox chb_6_1;
        private System.Windows.Forms.TextBox tb_SN1;
        private System.Windows.Forms.Button bt_SAVESN1;
        private System.Windows.Forms.Button bt_REQSN1;
        private System.Windows.Forms.CheckBox chb0_screen;
        private System.Windows.Forms.RadioButton rb_cmos12_select_long_time2;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.GroupBox gbox_CAN5;
        private System.Windows.Forms.Label lb_noerr5;
        private System.Windows.Forms.ComboBox cb_CAN5;
        private System.Windows.Forms.Label lb_error_CAN5;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Button bt_CloseCAN5;
        private System.Windows.Forms.Button bt_OpenCAN5;
        private System.Windows.Forms.Button bt_About5;
        private System.Windows.Forms.Button bt_Exit5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton rb_l5;
        private System.Windows.Forms.RadioButton rb_r5;
        private System.Windows.Forms.Button bt_aktiv5;
        private System.Windows.Forms.Button bt_verifi5;
        private System.Windows.Forms.Button bt_status5;
        private System.Windows.Forms.Button bt_reboot5;
        private System.Windows.Forms.CheckBox chb_6_6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.RadioButton rb_cmos12_select2;
        private System.Windows.Forms.RadioButton rb_new_RUP;
        private System.Windows.Forms.CheckBox cb_shotshow;
        private System.Windows.Forms.CheckBox cb_clear_shot;
        private System.Windows.Forms.CheckBox chb0_srfon;
        private System.Windows.Forms.RichTextBox rtb2_datagrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb2_filter_all;
        private System.Windows.Forms.RadioButton rb2_filter_7fff;
        private System.Windows.Forms.RadioButton rb2_filter_data;
        private System.Windows.Forms.RadioButton rb_flight_universal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn start;
        private System.Windows.Forms.DataGridViewTextBoxColumn _size;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn crc32;
        private System.Windows.Forms.DataGridViewTextBoxColumn vers;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TrackBar trackBar3;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox rtb3_datagrid;
        private System.Windows.Forms.Label lb3_t2_r;
        private System.Windows.Forms.TextBox tb3_t2_r;
        private System.Windows.Forms.Label lb3_t1_r;
        private System.Windows.Forms.TextBox tb3_t1_r;
        private System.Windows.Forms.Label lb3_tarm_r;
        private System.Windows.Forms.TextBox tb3_tarm_r;
        private System.Windows.Forms.Label lb3_t2_l;
        private System.Windows.Forms.TextBox tb3_t2_l;
        private System.Windows.Forms.Label lb3_t1_l;
        private System.Windows.Forms.TextBox tb3_t1_l;
        private System.Windows.Forms.Label lb3_tarm_l;
        private System.Windows.Forms.TextBox tb3_tarm_l;
        private System.Windows.Forms.Button bt3_badstatus_r;
        private System.Windows.Forms.Button bt3_badstatus_l;
        private System.Windows.Forms.Timer timer3_reset_l;
        private System.Windows.Forms.Timer timer3_reset_r;
        private System.Windows.Forms.TrackBar trackBar3_freq_r;
        private System.Windows.Forms.TrackBar trackBar3_um_r;
        private System.Windows.Forms.TrackBar trackBar3_az_r;
        private System.Windows.Forms.Label lb3_freq_val_r;
        private System.Windows.Forms.Label lb3_freq_txt_r;
        private System.Windows.Forms.Label lb3_shoot_um_val_r;
        private System.Windows.Forms.Label lb3_shoot_az_val_r;
        private System.Windows.Forms.Label lb3_shoot_um_txt_r;
        private System.Windows.Forms.Label lb3_shoot_az_txt_r;
        private System.Windows.Forms.RadioButton rb2_piv11;
        private System.Windows.Forms.RadioButton rb2_piv10;
        private System.Windows.Forms.Button bt3_baddata_r;
        private System.Windows.Forms.Button bt3_baddata_l;
        private System.Windows.Forms.Button bt3_trash_r;
        private System.Windows.Forms.Button bt3_trash_l;
	}
}

