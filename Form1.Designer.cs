﻿namespace OLO_CAN
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.button5 = new System.Windows.Forms.Button();
            this.gb1_Addr = new System.Windows.Forms.GroupBox();
            this.rb1_addr_right = new System.Windows.Forms.RadioButton();
            this.rb1_addr_left = new System.Windows.Forms.RadioButton();
            this.rb1_addr_uni = new System.Windows.Forms.RadioButton();
            this.bt_About1 = new System.Windows.Forms.Button();
            this.bt_Exit1 = new System.Windows.Forms.Button();
            this.gb_MC1 = new System.Windows.Forms.GroupBox();
            this.chb1_need_reset = new System.Windows.Forms.CheckBox();
            this.rb_flight_right_wing_double_pass_lg = new System.Windows.Forms.RadioButton();
            this.rb_flight_left_wing_double_pass_lg = new System.Windows.Forms.RadioButton();
            this.rb_cmos12_select_lg = new System.Windows.Forms.RadioButton();
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
            this.chb3_7fff = new System.Windows.Forms.CheckBox();
            this.chb3_um = new System.Windows.Forms.CheckBox();
            this.chb3_az = new System.Windows.Forms.CheckBox();
            this.btn_REQTIME = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.chb_dgview2 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgview2 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.chb4_nopaint = new System.Windows.Forms.CheckBox();
            this.gb3_shoot = new System.Windows.Forms.GroupBox();
            this.chb4_enshr = new System.Windows.Forms.CheckBox();
            this.chb4_enshl = new System.Windows.Forms.CheckBox();
            this.lb3_freq_val = new System.Windows.Forms.Label();
            this.lb3_freq_txt = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.chb3_shoot_ena = new System.Windows.Forms.CheckBox();
            this.lb3_shoot_um_val = new System.Windows.Forms.Label();
            this.lb3_shoot_az_val = new System.Windows.Forms.Label();
            this.trackBar3_um = new System.Windows.Forms.TrackBar();
            this.lb3_shoot_um_txt = new System.Windows.Forms.Label();
            this.trackBar3_az = new System.Windows.Forms.TrackBar();
            this.lb3_shoot_az_txt = new System.Windows.Forms.Label();
            this.chb_dgview3 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.gb_olo_R = new System.Windows.Forms.GroupBox();
            this.chb_R_Err_file = new System.Windows.Forms.CheckBox();
            this.cb_olo_r_ena = new System.Windows.Forms.CheckBox();
            this.chb_R_Err_plis = new System.Windows.Forms.CheckBox();
            this.shoot_r = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.chb_R_Err_int = new System.Windows.Forms.CheckBox();
            this.gb_olo_L = new System.Windows.Forms.GroupBox();
            this.chb_L_Err_file = new System.Windows.Forms.CheckBox();
            this.chb_L_Err_plis = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.chb_L_Err_int = new System.Windows.Forms.CheckBox();
            this.cb_olo_l_ena = new System.Windows.Forms.CheckBox();
            this.shoot_l = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgview3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.chb5_timer_enable = new System.Windows.Forms.CheckBox();
            this.gb_Image24 = new System.Windows.Forms.GroupBox();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.pb_CMOS2 = new System.Windows.Forms.ProgressBar();
            this.lb_CMOS24 = new System.Windows.Forms.Label();
            this.bt_get_CMOS2 = new System.Windows.Forms.Button();
            this.gb_Temperature = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lb_T3_val4 = new System.Windows.Forms.Label();
            this.lb_T3 = new System.Windows.Forms.Label();
            this.lb_T2_val4 = new System.Windows.Forms.Label();
            this.lb_T1_val4 = new System.Windows.Forms.Label();
            this.gb_Image14 = new System.Windows.Forms.GroupBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pb_CMOS1 = new System.Windows.Forms.ProgressBar();
            this.bt_get_CMOS1 = new System.Windows.Forms.Button();
            this.lb_CMOS14 = new System.Windows.Forms.Label();
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
            this.tm4_autoshl = new System.Windows.Forms.Timer(this.components);
            this.tm4_autoshr = new System.Windows.Forms.Timer(this.components);
            this.tm4_counter = new System.Windows.Forms.Timer(this.components);
            this.tm4_test = new System.Windows.Forms.Timer(this.components);
            this.timer1s = new System.Windows.Forms.Timer(this.components);
            this.button6 = new System.Windows.Forms.Button();
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
            this.gbox_statusR2.SuspendLayout();
            this.gbox_statusL2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgview2)).BeginInit();
            this.gbox_CAN2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.gb3_shoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_um)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_az)).BeginInit();
            this.gb_olo_R.SuspendLayout();
            this.gb_olo_L.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview3)).BeginInit();
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
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
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
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(877, 567);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(37, 19);
            this.button4.TabIndex = 36;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(840, 567);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 19);
            this.button3.TabIndex = 35;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // gbox_Temperature
            // 
            this.gbox_Temperature.Controls.Add(this.lb_T1);
            this.gbox_Temperature.Controls.Add(this.lb_T2);
            this.gbox_Temperature.Controls.Add(this.lb_T2_val);
            this.gbox_Temperature.Controls.Add(this.lb_T1_val);
            this.gbox_Temperature.Location = new System.Drawing.Point(252, 571);
            this.gbox_Temperature.Name = "gbox_Temperature";
            this.gbox_Temperature.Size = new System.Drawing.Size(155, 78);
            this.gbox_Temperature.TabIndex = 32;
            this.gbox_Temperature.TabStop = false;
            this.gbox_Temperature.Text = "Температуры";
            // 
            // lb_T1
            // 
            this.lb_T1.AutoSize = true;
            this.lb_T1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lb_T1.Location = new System.Drawing.Point(6, 25);
            this.lb_T1.Name = "lb_T1";
            this.lb_T1.Size = new System.Drawing.Size(83, 13);
            this.lb_T1.TabIndex = 7;
            this.lb_T1.Text = "Температура 1";
            // 
            // lb_T2
            // 
            this.lb_T2.AutoSize = true;
            this.lb_T2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lb_T2.Location = new System.Drawing.Point(6, 55);
            this.lb_T2.Name = "lb_T2";
            this.lb_T2.Size = new System.Drawing.Size(83, 13);
            this.lb_T2.TabIndex = 8;
            this.lb_T2.Text = "Температура 2";
            // 
            // lb_T2_val
            // 
            this.lb_T2_val.AutoSize = true;
            this.lb_T2_val.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lb_T2_val.Location = new System.Drawing.Point(107, 55);
            this.lb_T2_val.Name = "lb_T2_val";
            this.lb_T2_val.Size = new System.Drawing.Size(11, 13);
            this.lb_T2_val.TabIndex = 11;
            this.lb_T2_val.Text = "-";
            // 
            // lb_T1_val
            // 
            this.lb_T1_val.AutoSize = true;
            this.lb_T1_val.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lb_T1_val.Location = new System.Drawing.Point(107, 25);
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
            this.gbox_Cross.Location = new System.Drawing.Point(413, 571);
            this.gbox_Cross.Name = "gbox_Cross";
            this.gbox_Cross.Size = new System.Drawing.Size(420, 78);
            this.gbox_Cross.TabIndex = 31;
            this.gbox_Cross.TabStop = false;
            this.gbox_Cross.Text = "Крест";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(247, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Борт";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chb_oldlens
            // 
            this.chb_oldlens.AutoSize = true;
            this.chb_oldlens.Location = new System.Drawing.Point(280, 11);
            this.chb_oldlens.Name = "chb_oldlens";
            this.chb_oldlens.Size = new System.Drawing.Size(115, 17);
            this.chb_oldlens.TabIndex = 27;
            this.chb_oldlens.Text = "Старый объектив";
            this.chb_oldlens.UseVisualStyleBackColor = true;
            // 
            // rb_RightW
            // 
            this.rb_RightW.AutoSize = true;
            this.rb_RightW.Location = new System.Drawing.Point(345, 27);
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
            this.rb_LeftW.Location = new System.Drawing.Point(280, 27);
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
            this.bt_SaveConf.Location = new System.Drawing.Point(280, 50);
            this.bt_SaveConf.Name = "bt_SaveConf";
            this.bt_SaveConf.Size = new System.Drawing.Size(134, 23);
            this.bt_SaveConf.TabIndex = 24;
            this.bt_SaveConf.Text = "Сохранить конфиг";
            this.bt_SaveConf.UseVisualStyleBackColor = true;
            this.bt_SaveConf.Click += new System.EventHandler(this.bt_SaveConf_Click);
            // 
            // chb_CCirkle
            // 
            this.chb_CCirkle.Location = new System.Drawing.Point(189, 53);
            this.chb_CCirkle.Name = "chb_CCirkle";
            this.chb_CCirkle.Size = new System.Drawing.Size(90, 20);
            this.chb_CCirkle.TabIndex = 23;
            this.chb_CCirkle.Text = "Окружность";
            this.chb_CCirkle.UseVisualStyleBackColor = true;
            this.chb_CCirkle.Click += new System.EventHandler(this.chb_CCirkle_CheckedChanged);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(188, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 20);
            this.label13.TabIndex = 22;
            this.label13.Text = "Град.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(121, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 20);
            this.label14.TabIndex = 21;
            this.label14.Text = "R";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(108, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 20);
            this.label15.TabIndex = 20;
            this.label15.Text = "Угол";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // num_CCirkle
            // 
            this.num_CCirkle.Location = new System.Drawing.Point(141, 53);
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
            this.num_CAngle.Location = new System.Drawing.Point(141, 25);
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
            this.label10.Location = new System.Drawing.Point(70, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Пикс.";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(70, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "Пикс.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(7, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Y";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(7, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "X";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // num_CY
            // 
            this.num_CY.Location = new System.Drawing.Point(23, 53);
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
            this.num_CX.Location = new System.Drawing.Point(23, 23);
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
            this.chb_EnableCross.Location = new System.Drawing.Point(47, 1);
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
            this.gbox_Process.Location = new System.Drawing.Point(663, 506);
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
            this.chb_PFIFO.Enabled = false;
            this.chb_PFIFO.Location = new System.Drawing.Point(147, 13);
            this.chb_PFIFO.Name = "chb_PFIFO";
            this.chb_PFIFO.Size = new System.Drawing.Size(113, 17);
            this.chb_PFIFO.TabIndex = 2;
            this.chb_PFIFO.Text = "Передавать FIFO";
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
            this.gbox_Passports.Location = new System.Drawing.Point(663, 153);
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
            this.listb_Passport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listb_Passport_MouseDown);
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
            this.gbox_CMOS2.Size = new System.Drawing.Size(139, 119);
            this.gbox_CMOS2.TabIndex = 26;
            this.gbox_CMOS2.TabStop = false;
            // 
            // cb_CMOS2Enable
            // 
            this.cb_CMOS2Enable.AutoSize = true;
            this.cb_CMOS2Enable.Checked = true;
            this.cb_CMOS2Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_CMOS2Enable.Location = new System.Drawing.Point(6, 96);
            this.cb_CMOS2Enable.Name = "cb_CMOS2Enable";
            this.cb_CMOS2Enable.Size = new System.Drawing.Size(131, 17);
            this.cb_CMOS2Enable.TabIndex = 7;
            this.cb_CMOS2Enable.Text = "Включить термостат";
            this.cb_CMOS2Enable.UseVisualStyleBackColor = true;
            this.cb_CMOS2Enable.Click += new System.EventHandler(this.cb_CMOS2Enable_CheckedChanged);
            // 
            // tb_VINB2
            // 
            this.tb_VINB2.Location = new System.Drawing.Point(6, 71);
            this.tb_VINB2.Name = "tb_VINB2";
            this.tb_VINB2.Size = new System.Drawing.Size(36, 20);
            this.tb_VINB2.TabIndex = 5;
            this.tb_VINB2.Text = "1024";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "VINB";
            // 
            // CMOS2SetDAC2
            // 
            this.CMOS2SetDAC2.Location = new System.Drawing.Point(48, 69);
            this.CMOS2SetDAC2.Name = "CMOS2SetDAC2";
            this.CMOS2SetDAC2.Size = new System.Drawing.Size(58, 23);
            this.CMOS2SetDAC2.TabIndex = 3;
            this.CMOS2SetDAC2.Text = "Задать";
            this.CMOS2SetDAC2.UseVisualStyleBackColor = true;
            this.CMOS2SetDAC2.Click += new System.EventHandler(this.CMOS2SetDAC2_Click);
            // 
            // tb_VREF2
            // 
            this.tb_VREF2.Location = new System.Drawing.Point(6, 32);
            this.tb_VREF2.Name = "tb_VREF2";
            this.tb_VREF2.Size = new System.Drawing.Size(36, 20);
            this.tb_VREF2.TabIndex = 2;
            this.tb_VREF2.Text = "1024";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "VREF";
            // 
            // CMOS2SetDAC1
            // 
            this.CMOS2SetDAC1.Location = new System.Drawing.Point(48, 30);
            this.CMOS2SetDAC1.Name = "CMOS2SetDAC1";
            this.CMOS2SetDAC1.Size = new System.Drawing.Size(58, 23);
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
            this.gbox_CMOS1.Size = new System.Drawing.Size(139, 119);
            this.gbox_CMOS1.TabIndex = 25;
            this.gbox_CMOS1.TabStop = false;
            // 
            // cb_CMOS1Enable
            // 
            this.cb_CMOS1Enable.AutoSize = true;
            this.cb_CMOS1Enable.Checked = true;
            this.cb_CMOS1Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_CMOS1Enable.Location = new System.Drawing.Point(6, 96);
            this.cb_CMOS1Enable.Name = "cb_CMOS1Enable";
            this.cb_CMOS1Enable.Size = new System.Drawing.Size(131, 17);
            this.cb_CMOS1Enable.TabIndex = 6;
            this.cb_CMOS1Enable.Text = "Включить термостат";
            this.cb_CMOS1Enable.UseVisualStyleBackColor = true;
            this.cb_CMOS1Enable.Click += new System.EventHandler(this.cb_CMOS1Enable_CheckedChanged);
            // 
            // tb_VINB1
            // 
            this.tb_VINB1.Location = new System.Drawing.Point(6, 71);
            this.tb_VINB1.Name = "tb_VINB1";
            this.tb_VINB1.Size = new System.Drawing.Size(36, 20);
            this.tb_VINB1.TabIndex = 5;
            this.tb_VINB1.Text = "1024";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "VINB";
            // 
            // CMOS1SetDAC2
            // 
            this.CMOS1SetDAC2.Location = new System.Drawing.Point(48, 69);
            this.CMOS1SetDAC2.Name = "CMOS1SetDAC2";
            this.CMOS1SetDAC2.Size = new System.Drawing.Size(58, 23);
            this.CMOS1SetDAC2.TabIndex = 3;
            this.CMOS1SetDAC2.Text = "Задать";
            this.CMOS1SetDAC2.UseVisualStyleBackColor = true;
            this.CMOS1SetDAC2.Click += new System.EventHandler(this.CMOS1SetDAC2_Click);
            // 
            // tb_VREF1
            // 
            this.tb_VREF1.Location = new System.Drawing.Point(6, 32);
            this.tb_VREF1.Name = "tb_VREF1";
            this.tb_VREF1.Size = new System.Drawing.Size(36, 20);
            this.tb_VREF1.TabIndex = 2;
            this.tb_VREF1.Text = "1024";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "VREF";
            // 
            // bt_CMOS1SetDAC1
            // 
            this.bt_CMOS1SetDAC1.Location = new System.Drawing.Point(48, 30);
            this.bt_CMOS1SetDAC1.Name = "bt_CMOS1SetDAC1";
            this.bt_CMOS1SetDAC1.Size = new System.Drawing.Size(58, 23);
            this.bt_CMOS1SetDAC1.TabIndex = 0;
            this.bt_CMOS1SetDAC1.Text = "Задать";
            this.bt_CMOS1SetDAC1.UseVisualStyleBackColor = true;
            this.bt_CMOS1SetDAC1.Click += new System.EventHandler(this.bt_CMOS1SetDAC1_Click);
            // 
            // gbox_Image
            // 
            this.gbox_Image.Controls.Add(this.pb_CMOS);
            this.gbox_Image.Controls.Add(this.pictureBox1);
            this.gbox_Image.Location = new System.Drawing.Point(6, 9);
            this.gbox_Image.Name = "gbox_Image";
            this.gbox_Image.Size = new System.Drawing.Size(651, 556);
            this.gbox_Image.TabIndex = 16;
            this.gbox_Image.TabStop = false;
            this.gbox_Image.Text = "Картинка";
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
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(485, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 38;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
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
            this.rb1_addr_left.Location = new System.Drawing.Point(120, 20);
            this.rb1_addr_left.Name = "rb1_addr_left";
            this.rb1_addr_left.Size = new System.Drawing.Size(141, 17);
            this.rb1_addr_left.TabIndex = 1;
            this.rb1_addr_left.Text = "Прошивка ОЛО-Левый";
            this.rb1_addr_left.UseVisualStyleBackColor = true;
            this.rb1_addr_left.CheckedChanged += new System.EventHandler(this.rb1_addr_left_CheckedChanged);
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
            this.gb_MC1.Controls.Add(this.chb1_need_reset);
            this.gb_MC1.Controls.Add(this.rb_flight_right_wing_double_pass_lg);
            this.gb_MC1.Controls.Add(this.rb_flight_left_wing_double_pass_lg);
            this.gb_MC1.Controls.Add(this.rb_cmos12_select_lg);
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
            this.gb_MC1.Size = new System.Drawing.Size(463, 360);
            this.gb_MC1.TabIndex = 7;
            this.gb_MC1.TabStop = false;
            this.gb_MC1.Text = "Микропрограмма";
            // 
            // chb1_need_reset
            // 
            this.chb1_need_reset.AutoSize = true;
            this.chb1_need_reset.Location = new System.Drawing.Point(113, 326);
            this.chb1_need_reset.Name = "chb1_need_reset";
            this.chb1_need_reset.Size = new System.Drawing.Size(57, 17);
            this.chb1_need_reset.TabIndex = 35;
            this.chb1_need_reset.Text = "Сброс";
            this.chb1_need_reset.UseVisualStyleBackColor = true;
            // 
            // rb_flight_right_wing_double_pass_lg
            // 
            this.rb_flight_right_wing_double_pass_lg.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_flight_right_wing_double_pass_lg.Location = new System.Drawing.Point(6, 246);
            this.rb_flight_right_wing_double_pass_lg.Name = "rb_flight_right_wing_double_pass_lg";
            this.rb_flight_right_wing_double_pass_lg.Size = new System.Drawing.Size(444, 17);
            this.rb_flight_right_wing_double_pass_lg.TabIndex = 34;
            this.rb_flight_right_wing_double_pass_lg.Text = "Загрузка прошивки \"SOLO2_FLIGHT_RIGHT\" для матрицы низкого усиления";
            this.rb_flight_right_wing_double_pass_lg.UseVisualStyleBackColor = true;
            this.rb_flight_right_wing_double_pass_lg.CheckedChanged += new System.EventHandler(this.rb_flight_right_wing_double_pass_lg_CheckedChanged);
            // 
            // rb_flight_left_wing_double_pass_lg
            // 
            this.rb_flight_left_wing_double_pass_lg.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_flight_left_wing_double_pass_lg.Location = new System.Drawing.Point(6, 223);
            this.rb_flight_left_wing_double_pass_lg.Name = "rb_flight_left_wing_double_pass_lg";
            this.rb_flight_left_wing_double_pass_lg.Size = new System.Drawing.Size(444, 17);
            this.rb_flight_left_wing_double_pass_lg.TabIndex = 33;
            this.rb_flight_left_wing_double_pass_lg.Text = "Загрузка прошивки \"SOLO2_FLIGHT_LEFT\" для матрицы низкого усиления";
            this.rb_flight_left_wing_double_pass_lg.UseVisualStyleBackColor = true;
            this.rb_flight_left_wing_double_pass_lg.CheckedChanged += new System.EventHandler(this.rb_flight_left_wing_double_pass_lg_CheckedChanged);
            // 
            // rb_cmos12_select_lg
            // 
            this.rb_cmos12_select_lg.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_cmos12_select_lg.Location = new System.Drawing.Point(6, 121);
            this.rb_cmos12_select_lg.Name = "rb_cmos12_select_lg";
            this.rb_cmos12_select_lg.Size = new System.Drawing.Size(444, 17);
            this.rb_cmos12_select_lg.TabIndex = 32;
            this.rb_cmos12_select_lg.Text = "Загрузка прошивки \"SOLO2_SELECT\" для матрицы низкого усиления";
            this.rb_cmos12_select_lg.UseVisualStyleBackColor = true;
            this.rb_cmos12_select_lg.CheckedChanged += new System.EventHandler(this.rb_cmos12_select_lg_CheckedChanged);
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
            this.label24.Location = new System.Drawing.Point(6, 157);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(114, 13);
            this.label24.TabIndex = 29;
            this.label24.Text = "Боевые прошивки";
            // 
            // rb_flight_right_wing_double_pass
            // 
            this.rb_flight_right_wing_double_pass.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rb_flight_right_wing_double_pass.Location = new System.Drawing.Point(6, 200);
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
            this.rb_flight_left_wing_double_pass.Location = new System.Drawing.Point(6, 177);
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
            this.rb_cmos12_select.Location = new System.Drawing.Point(6, 98);
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
            this.rb_cmos12_select_long_time.Location = new System.Drawing.Point(6, 75);
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
            this.pb_loadMC1.Location = new System.Drawing.Point(113, 290);
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
            this.chb_eraseALL1.Location = new System.Drawing.Point(6, 326);
            this.chb_eraseALL1.Name = "chb_eraseALL1";
            this.chb_eraseALL1.Size = new System.Drawing.Size(104, 17);
            this.chb_eraseALL1.TabIndex = 14;
            this.chb_eraseALL1.Text = "Стереть FLASH";
            this.chb_eraseALL1.UseVisualStyleBackColor = true;
            // 
            // bt_runMC1
            // 
            this.bt_runMC1.Location = new System.Drawing.Point(280, 322);
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
            this.lb_Load_OK1.Location = new System.Drawing.Point(117, 294);
            this.lb_Load_OK1.Name = "lb_Load_OK1";
            this.lb_Load_OK1.Size = new System.Drawing.Size(0, 13);
            this.lb_Load_OK1.TabIndex = 7;
            this.lb_Load_OK1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Load_OK1.Visible = false;
            // 
            // bt_loadMC1
            // 
            this.bt_loadMC1.Enabled = false;
            this.bt_loadMC1.Location = new System.Drawing.Point(6, 289);
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
            this.tabPage3.Controls.Add(this.gbox_statusR2);
            this.tabPage3.Controls.Add(this.gbox_statusL2);
            this.tabPage3.Controls.Add(this.cb_module2);
            this.tabPage3.Controls.Add(this.bt_mod2);
            this.tabPage3.Controls.Add(this.REQ_VER);
            this.tabPage3.Controls.Add(this.chb3_savelog);
            this.tabPage3.Controls.Add(this.chb3_7fff);
            this.tabPage3.Controls.Add(this.chb3_um);
            this.tabPage3.Controls.Add(this.chb3_az);
            this.tabPage3.Controls.Add(this.btn_REQTIME);
            this.tabPage3.Controls.Add(this.btn_Reset);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.numericUpDown1);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.chb_dgview2);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Controls.Add(this.dgview2);
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
            // gbox_statusR2
            // 
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
            this.cb_module2.Location = new System.Drawing.Point(717, 188);
            this.cb_module2.Name = "cb_module2";
            this.cb_module2.Size = new System.Drawing.Size(158, 21);
            this.cb_module2.TabIndex = 63;
            // 
            // bt_mod2
            // 
            this.bt_mod2.Location = new System.Drawing.Point(620, 187);
            this.bt_mod2.Name = "bt_mod2";
            this.bt_mod2.Size = new System.Drawing.Size(91, 23);
            this.bt_mod2.TabIndex = 62;
            this.bt_mod2.Text = "Режим модуля";
            this.bt_mod2.UseVisualStyleBackColor = true;
            this.bt_mod2.Click += new System.EventHandler(this.bt_mod2_Click);
            // 
            // REQ_VER
            // 
            this.REQ_VER.Location = new System.Drawing.Point(883, 186);
            this.REQ_VER.Name = "REQ_VER";
            this.REQ_VER.Size = new System.Drawing.Size(71, 23);
            this.REQ_VER.TabIndex = 61;
            this.REQ_VER.Text = "Версия прошивки";
            this.REQ_VER.UseVisualStyleBackColor = true;
            this.REQ_VER.Click += new System.EventHandler(this.REQ_VER_Click);
            // 
            // chb3_savelog
            // 
            this.chb3_savelog.AutoSize = true;
            this.chb3_savelog.Location = new System.Drawing.Point(620, 317);
            this.chb3_savelog.Name = "chb3_savelog";
            this.chb3_savelog.Size = new System.Drawing.Size(66, 17);
            this.chb3_savelog.TabIndex = 60;
            this.chb3_savelog.Text = "save log";
            this.chb3_savelog.UseVisualStyleBackColor = true;
            this.chb3_savelog.CheckedChanged += new System.EventHandler(this.chb3_savelog_CheckedChanged);
            // 
            // chb3_7fff
            // 
            this.chb3_7fff.AutoSize = true;
            this.chb3_7fff.Enabled = false;
            this.chb3_7fff.Location = new System.Drawing.Point(620, 293);
            this.chb3_7fff.Name = "chb3_7fff";
            this.chb3_7fff.Size = new System.Drawing.Size(103, 17);
            this.chb3_7fff.TabIndex = 59;
            this.chb3_7fff.Text = "Проверка 7FFF";
            this.chb3_7fff.UseVisualStyleBackColor = true;
            // 
            // chb3_um
            // 
            this.chb3_um.AutoSize = true;
            this.chb3_um.Enabled = false;
            this.chb3_um.Location = new System.Drawing.Point(620, 269);
            this.chb3_um.Name = "chb3_um";
            this.chb3_um.Size = new System.Drawing.Size(147, 17);
            this.chb3_um.TabIndex = 58;
            this.chb3_um.Text = "проверка по углу места";
            this.chb3_um.UseVisualStyleBackColor = true;
            // 
            // chb3_az
            // 
            this.chb3_az.AutoSize = true;
            this.chb3_az.Enabled = false;
            this.chb3_az.Location = new System.Drawing.Point(620, 245);
            this.chb3_az.Name = "chb3_az";
            this.chb3_az.Size = new System.Drawing.Size(133, 17);
            this.chb3_az.TabIndex = 57;
            this.chb3_az.Text = "проверка по азимуту";
            this.chb3_az.UseVisualStyleBackColor = true;
            // 
            // btn_REQTIME
            // 
            this.btn_REQTIME.Location = new System.Drawing.Point(8, 187);
            this.btn_REQTIME.Name = "btn_REQTIME";
            this.btn_REQTIME.Size = new System.Drawing.Size(187, 23);
            this.btn_REQTIME.TabIndex = 56;
            this.btn_REQTIME.Text = "Запрос времени";
            this.btn_REQTIME.UseVisualStyleBackColor = true;
            this.btn_REQTIME.Click += new System.EventHandler(this.btn_REQTIME_Click);
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
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.panel1.Location = new System.Drawing.Point(413, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 200);
            this.panel1.TabIndex = 49;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // dgview2
            // 
            this.dgview2.AllowUserToAddRows = false;
            this.dgview2.AllowUserToDeleteRows = false;
            this.dgview2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgview2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview2.ColumnHeadersVisible = false;
            this.dgview2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column4,
            this.Column6});
            this.dgview2.Location = new System.Drawing.Point(8, 245);
            this.dgview2.MultiSelect = false;
            this.dgview2.Name = "dgview2";
            this.dgview2.RowHeadersVisible = false;
            this.dgview2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgview2.ShowCellErrors = false;
            this.dgview2.ShowEditingIcon = false;
            this.dgview2.Size = new System.Drawing.Size(605, 399);
            this.dgview2.TabIndex = 48;
            this.dgview2.Click += new System.EventHandler(this.dgview2_Click);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "";
            this.Column1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column1.MinimumWidth = 22;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 22;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.Width = 75;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Column5";
            this.Column5.Name = "Column5";
            this.Column5.Width = 140;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.Width = 190;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.Width = 130;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Column6";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
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
            this.bt_SyncTime.Location = new System.Drawing.Point(201, 158);
            this.bt_SyncTime.Name = "bt_SyncTime";
            this.bt_SyncTime.Size = new System.Drawing.Size(181, 23);
            this.bt_SyncTime.TabIndex = 44;
            this.bt_SyncTime.Text = "Синхронизация времени";
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
            this.tabPage4.Controls.Add(this.checkBox2);
            this.tabPage4.Controls.Add(this.chb4_nopaint);
            this.tabPage4.Controls.Add(this.gb3_shoot);
            this.tabPage4.Controls.Add(this.chb_dgview3);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.gb_olo_R);
            this.tabPage4.Controls.Add(this.gb_olo_L);
            this.tabPage4.Controls.Add(this.panel3);
            this.tabPage4.Controls.Add(this.dgview3);
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
            this.gb3_shoot.Controls.Add(this.chb4_enshr);
            this.gb3_shoot.Controls.Add(this.chb4_enshl);
            this.gb3_shoot.Controls.Add(this.lb3_freq_val);
            this.gb3_shoot.Controls.Add(this.lb3_freq_txt);
            this.gb3_shoot.Controls.Add(this.trackBar1);
            this.gb3_shoot.Controls.Add(this.chb3_shoot_ena);
            this.gb3_shoot.Controls.Add(this.lb3_shoot_um_val);
            this.gb3_shoot.Controls.Add(this.lb3_shoot_az_val);
            this.gb3_shoot.Controls.Add(this.trackBar3_um);
            this.gb3_shoot.Controls.Add(this.lb3_shoot_um_txt);
            this.gb3_shoot.Controls.Add(this.trackBar3_az);
            this.gb3_shoot.Controls.Add(this.lb3_shoot_az_txt);
            this.gb3_shoot.Enabled = false;
            this.gb3_shoot.Location = new System.Drawing.Point(619, 9);
            this.gb3_shoot.Name = "gb3_shoot";
            this.gb3_shoot.Size = new System.Drawing.Size(203, 409);
            this.gb3_shoot.TabIndex = 56;
            this.gb3_shoot.TabStop = false;
            this.gb3_shoot.Text = "Выстрелы";
            // 
            // chb4_enshr
            // 
            this.chb4_enshr.AutoSize = true;
            this.chb4_enshr.Location = new System.Drawing.Point(94, 371);
            this.chb4_enshr.Name = "chb4_enshr";
            this.chb4_enshr.Size = new System.Drawing.Size(88, 17);
            this.chb4_enshr.TabIndex = 66;
            this.chb4_enshr.Text = "Авто ОЛО-П";
            this.chb4_enshr.UseVisualStyleBackColor = true;
            this.chb4_enshr.CheckedChanged += new System.EventHandler(this.chb4_enshr_CheckedChanged);
            // 
            // chb4_enshl
            // 
            this.chb4_enshl.AutoSize = true;
            this.chb4_enshl.Location = new System.Drawing.Point(7, 371);
            this.chb4_enshl.Name = "chb4_enshl";
            this.chb4_enshl.Size = new System.Drawing.Size(88, 17);
            this.chb4_enshl.TabIndex = 65;
            this.chb4_enshl.Text = "Авто ОЛО-Л";
            this.chb4_enshl.UseVisualStyleBackColor = true;
            this.chb4_enshl.CheckedChanged += new System.EventHandler(this.chb4_enshl_CheckedChanged);
            // 
            // lb3_freq_val
            // 
            this.lb3_freq_val.AutoSize = true;
            this.lb3_freq_val.Enabled = false;
            this.lb3_freq_val.Location = new System.Drawing.Point(144, 43);
            this.lb3_freq_val.Name = "lb3_freq_val";
            this.lb3_freq_val.Size = new System.Drawing.Size(0, 13);
            this.lb3_freq_val.TabIndex = 64;
            // 
            // lb3_freq_txt
            // 
            this.lb3_freq_txt.AutoSize = true;
            this.lb3_freq_txt.Enabled = false;
            this.lb3_freq_txt.Location = new System.Drawing.Point(143, 21);
            this.lb3_freq_txt.Name = "lb3_freq_txt";
            this.lb3_freq_txt.Size = new System.Drawing.Size(49, 13);
            this.lb3_freq_txt.TabIndex = 63;
            this.lb3_freq_txt.Text = "Частота";
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(141, 59);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 305);
            this.trackBar1.TabIndex = 62;
            this.trackBar1.TickFrequency = 5;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
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
            // lb3_shoot_um_val
            // 
            this.lb3_shoot_um_val.AutoSize = true;
            this.lb3_shoot_um_val.Enabled = false;
            this.lb3_shoot_um_val.Location = new System.Drawing.Point(71, 43);
            this.lb3_shoot_um_val.Name = "lb3_shoot_um_val";
            this.lb3_shoot_um_val.Size = new System.Drawing.Size(0, 13);
            this.lb3_shoot_um_val.TabIndex = 61;
            // 
            // lb3_shoot_az_val
            // 
            this.lb3_shoot_az_val.AutoSize = true;
            this.lb3_shoot_az_val.Enabled = false;
            this.lb3_shoot_az_val.Location = new System.Drawing.Point(4, 43);
            this.lb3_shoot_az_val.Name = "lb3_shoot_az_val";
            this.lb3_shoot_az_val.Size = new System.Drawing.Size(0, 13);
            this.lb3_shoot_az_val.TabIndex = 60;
            // 
            // trackBar3_um
            // 
            this.trackBar3_um.Enabled = false;
            this.trackBar3_um.LargeChange = 1080;
            this.trackBar3_um.Location = new System.Drawing.Point(74, 59);
            this.trackBar3_um.Maximum = 5400;
            this.trackBar3_um.Minimum = -5400;
            this.trackBar3_um.Name = "trackBar3_um";
            this.trackBar3_um.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3_um.Size = new System.Drawing.Size(45, 305);
            this.trackBar3_um.SmallChange = 108;
            this.trackBar3_um.TabIndex = 58;
            this.trackBar3_um.TickFrequency = 108;
            this.trackBar3_um.Value = -2000;
            this.trackBar3_um.Scroll += new System.EventHandler(this.trackBar3_um_Scroll);
            // 
            // lb3_shoot_um_txt
            // 
            this.lb3_shoot_um_txt.AutoSize = true;
            this.lb3_shoot_um_txt.Enabled = false;
            this.lb3_shoot_um_txt.Location = new System.Drawing.Point(71, 21);
            this.lb3_shoot_um_txt.Name = "lb3_shoot_um_txt";
            this.lb3_shoot_um_txt.Size = new System.Drawing.Size(66, 13);
            this.lb3_shoot_um_txt.TabIndex = 59;
            this.lb3_shoot_um_txt.Text = "Угол места";
            // 
            // trackBar3_az
            // 
            this.trackBar3_az.Enabled = false;
            this.trackBar3_az.LargeChange = 1080;
            this.trackBar3_az.Location = new System.Drawing.Point(7, 59);
            this.trackBar3_az.Maximum = 5400;
            this.trackBar3_az.Minimum = -5400;
            this.trackBar3_az.Name = "trackBar3_az";
            this.trackBar3_az.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3_az.Size = new System.Drawing.Size(45, 305);
            this.trackBar3_az.SmallChange = 108;
            this.trackBar3_az.TabIndex = 54;
            this.trackBar3_az.TickFrequency = 108;
            this.trackBar3_az.Value = 2000;
            this.trackBar3_az.Scroll += new System.EventHandler(this.trackBar3_az_Scroll);
            // 
            // lb3_shoot_az_txt
            // 
            this.lb3_shoot_az_txt.AutoSize = true;
            this.lb3_shoot_az_txt.Enabled = false;
            this.lb3_shoot_az_txt.Location = new System.Drawing.Point(4, 21);
            this.lb3_shoot_az_txt.Name = "lb3_shoot_az_txt";
            this.lb3_shoot_az_txt.Size = new System.Drawing.Size(44, 13);
            this.lb3_shoot_az_txt.TabIndex = 55;
            this.lb3_shoot_az_txt.Text = "Азимут";
            // 
            // chb_dgview3
            // 
            this.chb_dgview3.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_dgview3.BackColor = System.Drawing.Color.SpringGreen;
            this.chb_dgview3.Checked = true;
            this.chb_dgview3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_dgview3.Location = new System.Drawing.Point(328, 282);
            this.chb_dgview3.Name = "chb_dgview3";
            this.chb_dgview3.Size = new System.Drawing.Size(285, 23);
            this.chb_dgview3.TabIndex = 50;
            this.chb_dgview3.Text = "Скролл включен";
            this.chb_dgview3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_dgview3.UseVisualStyleBackColor = false;
            this.chb_dgview3.CheckedChanged += new System.EventHandler(this.chb_dgview3_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 282);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(285, 23);
            this.button2.TabIndex = 53;
            this.button2.Text = "Очистка грида";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gb_olo_R
            // 
            this.gb_olo_R.Controls.Add(this.chb_R_Err_file);
            this.gb_olo_R.Controls.Add(this.cb_olo_r_ena);
            this.gb_olo_R.Controls.Add(this.chb_R_Err_plis);
            this.gb_olo_R.Controls.Add(this.shoot_r);
            this.gb_olo_R.Controls.Add(this.label27);
            this.gb_olo_R.Controls.Add(this.chb_R_Err_int);
            this.gb_olo_R.Enabled = false;
            this.gb_olo_R.Location = new System.Drawing.Point(195, 93);
            this.gb_olo_R.Name = "gb_olo_R";
            this.gb_olo_R.Size = new System.Drawing.Size(180, 183);
            this.gb_olo_R.TabIndex = 52;
            this.gb_olo_R.TabStop = false;
            this.gb_olo_R.Text = "ОЛО-Правый";
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
            this.cb_olo_r_ena.AutoSize = true;
            this.cb_olo_r_ena.Location = new System.Drawing.Point(6, 19);
            this.cb_olo_r_ena.Name = "cb_olo_r_ena";
            this.cb_olo_r_ena.Size = new System.Drawing.Size(136, 17);
            this.cb_olo_r_ena.TabIndex = 31;
            this.cb_olo_r_ena.Text = "Эмуляция выключена";
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
            this.shoot_r.Location = new System.Drawing.Point(6, 43);
            this.shoot_r.Name = "shoot_r";
            this.shoot_r.Size = new System.Drawing.Size(128, 23);
            this.shoot_r.TabIndex = 30;
            this.shoot_r.Text = "Выстрел";
            this.shoot_r.UseVisualStyleBackColor = true;
            this.shoot_r.Click += new System.EventHandler(this.shoot_r_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Enabled = false;
            this.label27.Location = new System.Drawing.Point(6, 83);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(124, 13);
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
            this.gb_olo_L.Controls.Add(this.chb_L_Err_file);
            this.gb_olo_L.Controls.Add(this.chb_L_Err_plis);
            this.gb_olo_L.Controls.Add(this.label26);
            this.gb_olo_L.Controls.Add(this.chb_L_Err_int);
            this.gb_olo_L.Controls.Add(this.cb_olo_l_ena);
            this.gb_olo_L.Controls.Add(this.shoot_l);
            this.gb_olo_L.Enabled = false;
            this.gb_olo_L.Location = new System.Drawing.Point(6, 93);
            this.gb_olo_L.Name = "gb_olo_L";
            this.gb_olo_L.Size = new System.Drawing.Size(180, 183);
            this.gb_olo_L.TabIndex = 51;
            this.gb_olo_L.TabStop = false;
            this.gb_olo_L.Text = "ОЛО-Левый";
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
            this.label26.Location = new System.Drawing.Point(6, 83);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(124, 13);
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
            this.cb_olo_l_ena.AutoSize = true;
            this.cb_olo_l_ena.Location = new System.Drawing.Point(6, 20);
            this.cb_olo_l_ena.Name = "cb_olo_l_ena";
            this.cb_olo_l_ena.Size = new System.Drawing.Size(136, 17);
            this.cb_olo_l_ena.TabIndex = 30;
            this.cb_olo_l_ena.Text = "Эмуляция выключена";
            this.cb_olo_l_ena.UseVisualStyleBackColor = true;
            this.cb_olo_l_ena.CheckedChanged += new System.EventHandler(this.cb_olo_l_ena_CheckedChanged);
            // 
            // shoot_l
            // 
            this.shoot_l.Enabled = false;
            this.shoot_l.Location = new System.Drawing.Point(6, 43);
            this.shoot_l.Name = "shoot_l";
            this.shoot_l.Size = new System.Drawing.Size(127, 23);
            this.shoot_l.TabIndex = 29;
            this.shoot_l.Text = "Выстрел";
            this.shoot_l.UseVisualStyleBackColor = true;
            this.shoot_l.Click += new System.EventHandler(this.shoot_l_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(413, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 200);
            this.panel3.TabIndex = 49;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // dgview3
            // 
            this.dgview3.AllowUserToAddRows = false;
            this.dgview3.AllowUserToDeleteRows = false;
            this.dgview3.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgview3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview3.ColumnHeadersVisible = false;
            this.dgview3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgview3.Location = new System.Drawing.Point(8, 311);
            this.dgview3.MultiSelect = false;
            this.dgview3.Name = "dgview3";
            this.dgview3.RowHeadersVisible = false;
            this.dgview3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgview3.ShowCellErrors = false;
            this.dgview3.ShowEditingIcon = false;
            this.dgview3.Size = new System.Drawing.Size(605, 333);
            this.dgview3.TabIndex = 48;
            this.dgview3.Click += new System.EventHandler(this.dgview3_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.MinimumWidth = 22;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.Width = 22;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column5";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Column3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 190;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Column4";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 130;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Column6";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
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
            this.tabPage5.Controls.Add(this.chb5_timer_enable);
            this.tabPage5.Controls.Add(this.gb_Image24);
            this.tabPage5.Controls.Add(this.gb_Temperature);
            this.tabPage5.Controls.Add(this.gb_Image14);
            this.tabPage5.Controls.Add(this.gb_Tests);
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
            // Timer_UpdateTime
            // 
            this.Timer_UpdateTime.Enabled = true;
            this.Timer_UpdateTime.Interval = 500;
            this.Timer_UpdateTime.Tick += new System.EventHandler(this.Timer_UpdateTime_Tick);
            // 
            // Timer_GetData
            // 
            this.Timer_GetData.Interval = 200;
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
            // tm4_autoshl
            // 
            this.tm4_autoshl.Tick += new System.EventHandler(this.tm4_autoshl_Tick);
            // 
            // tm4_autoshr
            // 
            this.tm4_autoshr.Tick += new System.EventHandler(this.tm4_autoshr_Tick);
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
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(567, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 39;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
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
            this.gbox_statusR2.ResumeLayout(false);
            this.gbox_statusR2.PerformLayout();
            this.gbox_statusL2.ResumeLayout(false);
            this.gbox_statusL2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgview2)).EndInit();
            this.gbox_CAN2.ResumeLayout(false);
            this.gbox_CAN2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.gb3_shoot.ResumeLayout(false);
            this.gb3_shoot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_um)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3_az)).EndInit();
            this.gb_olo_R.ResumeLayout(false);
            this.gb_olo_R.PerformLayout();
            this.gb_olo_L.ResumeLayout(false);
            this.gb_olo_L.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview3)).EndInit();
            this.gbox_CAN3.ResumeLayout(false);
            this.gbox_CAN3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
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
        private System.Windows.Forms.Button btn_REQTIME;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chb_dgview2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgview2;
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
        private System.Windows.Forms.DataGridView dgview3;
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
        private System.Windows.Forms.RadioButton rb_cmos12_select_lg;
        private System.Windows.Forms.RadioButton rb_flight_right_wing_double_pass_lg;
        private System.Windows.Forms.RadioButton rb_flight_left_wing_double_pass_lg;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox chb_R_Err_file;
        private System.Windows.Forms.CheckBox chb_R_Err_plis;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox chb_R_Err_int;
        private System.Windows.Forms.CheckBox chb_L_Err_file;
        private System.Windows.Forms.CheckBox chb_L_Err_plis;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox chb_L_Err_int;
        private System.Windows.Forms.GroupBox gb3_shoot;
        private System.Windows.Forms.TrackBar trackBar3_um;
        private System.Windows.Forms.Label lb3_shoot_um_txt;
        private System.Windows.Forms.CheckBox chb3_shoot_ena;
        private System.Windows.Forms.TrackBar trackBar3_az;
        private System.Windows.Forms.Label lb3_shoot_az_txt;
        private System.Windows.Forms.Label lb3_shoot_um_val;
        private System.Windows.Forms.Label lb3_shoot_az_val;
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
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.CheckBox chb3_um;
        private System.Windows.Forms.CheckBox chb3_az;
        private System.Windows.Forms.CheckBox chb3_7fff;
        private System.Windows.Forms.CheckBox chb3_savelog;
        private System.Windows.Forms.Label lb3_freq_txt;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lb3_freq_val;
        private System.Windows.Forms.CheckBox chb4_enshr;
        private System.Windows.Forms.CheckBox chb4_enshl;
        private System.Windows.Forms.Timer tm4_autoshl;
        private System.Windows.Forms.Timer tm4_autoshr;
        private System.Windows.Forms.Timer tm4_counter;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox chb4_nopaint;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
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
	}
}

