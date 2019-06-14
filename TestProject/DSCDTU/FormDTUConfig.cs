using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Runtime.InteropServices;

namespace DSCDTU
{
	/// <summary>
	/// Form3 的摘要说明。
	/// </summary>
	public class FormDTUConfig : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.CheckBox checkBox6;
		private System.Windows.Forms.CheckBox checkBox7;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.CheckBox checkBox8;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.CheckBox checkBox9;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.CheckBox checkBox10;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.CheckBox checkBox11;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.CheckBox checkBox12;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.CheckBox checkBox13;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.CheckBox checkBox14;
		private System.Windows.Forms.TextBox textBox13;
		private System.Windows.Forms.CheckBox checkBox15;
		private System.Windows.Forms.CheckBox checkBox16;
		private System.Windows.Forms.TextBox textBox14;
		private System.Windows.Forms.CheckBox checkBox17;
		private System.Windows.Forms.TextBox textBox15;
		private System.Windows.Forms.CheckBox checkBox18;
		private System.Windows.Forms.TextBox textBox16;
		private System.Windows.Forms.CheckBox checkBox19;
		private System.Windows.Forms.TextBox textBox17;
		private System.Windows.Forms.CheckBox checkBox20;
		private System.Windows.Forms.TextBox textBox18;
		private System.Windows.Forms.CheckBox checkBox21;
		private System.Windows.Forms.TextBox textBox19;
		private System.Windows.Forms.CheckBox checkBox22;
		private System.Windows.Forms.TextBox textBox20;
		private System.Windows.Forms.CheckBox checkBox23;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox checkBox24;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox comboBox5;
		private System.Windows.Forms.CheckBox checkBox25;
		private System.Windows.Forms.TextBox textBox21;
		private System.Windows.Forms.CheckBox checkBox26;
		private System.Windows.Forms.TextBox textBox22;
		private System.Windows.Forms.CheckBox checkBox27;
		private System.Windows.Forms.TextBox textBox23;
		private System.Windows.Forms.CheckBox checkBox28;
		private System.Windows.Forms.TextBox textBox24;
		private System.Windows.Forms.CheckBox checkBox29;
		private System.Windows.Forms.TextBox textBox25;
		private System.Windows.Forms.CheckBox checkBox30;
		private System.Windows.Forms.ComboBox comboBox6;
		private System.Windows.Forms.CheckBox checkBox31;
		private System.Windows.Forms.ComboBox comboBox7;
		private System.Windows.Forms.CheckBox checkBox32;
		private System.Windows.Forms.TextBox textBox26;
		private System.Windows.Forms.CheckBox checkBox33;
		private System.Windows.Forms.TextBox textBox27;
		private System.Windows.Forms.CheckBox checkBox34;
		private System.Windows.Forms.TextBox textBox28;
		private System.Windows.Forms.CheckBox checkBox35;
		private System.Windows.Forms.TextBox textBox29;
		private System.Windows.Forms.CheckBox checkBox36;
		private System.Windows.Forms.CheckBox checkBox37;
		private System.Windows.Forms.TextBox textBox30;
		private System.Windows.Forms.CheckBox checkBox38;
		private System.Windows.Forms.TextBox textBox31;
		private System.Windows.Forms.CheckBox checkBox39;
		private System.Windows.Forms.TextBox textBox32;
		private System.Windows.Forms.CheckBox checkBox40;
		private System.Windows.Forms.TextBox textBox33;
		private System.Windows.Forms.CheckBox checkBox41;
		private System.Windows.Forms.TextBox textBox34;
		private System.Windows.Forms.CheckBox checkBox42;
		private System.Windows.Forms.TextBox textBox35;
		private System.Windows.Forms.Label label6;
		public System.Windows.Forms.ComboBox comboBox8;
		private System.Windows.Forms.CheckBox checkBox43;
		private System.Windows.Forms.TextBox textBox36;
		private System.Windows.Forms.Label label7;
		public System.Windows.Forms.Button button1;
		public System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;

   //参数类型定义
		public const int    PARAM_SERVER_CODE           = 0x01;
		public const int	PARAM_USER_NAME				=0x02;
		public const int	PARAM_PASSWORDS				=0x03;
		public const int	PARAM_APN					=0x04;
		public const int	PARAM_SIMPIN				=0x05;

		public const int	PARAM_LOCAL_MT				=0x06;
		public const int	PARAM_LOCAL_PORT			=0x07;
		public const int	PARAM_TIMEVAL				=0x08;
		public const int	PARAM_PACK_LEN				=0x09;
		public const int	PARAM_RECONNECT_INTERVAL	=0x0a;
		public const int	PARAM_DEBUG_TYPE			=0x0b;
		public const int	PARAM_LAST_PACKET_IDLE		=0x0c;

		public const int	PARAM_CENTER_ADDR			=0x0d;
		public const int	PARAM_CENTER_NAME			=0x0e;
		public const int	PARAM_DOMAIN_TTL			=0x0f;
		public const int	PARAM_CENTER_PORT			=0x10;
		public const int	PARAM_DNS_ADDR				=0x11;
		public const int	PARAM_SEC_CENTER_ADDR		=0x20;
		public const int	PARAM_SEC_CENTER_PORT		=0x21;

		public const int	PARAM_SERIAL_PORT			=0x12;

		public const int	PARAM_MT_TYPE				=0x13;
		public const int	PARAM_CALL_TYPE				=0x14;
		public const int	PARAM_CALL_TIMEVAL			=0x15;
		public const int	PARAM_OFF_LINETIME			=0x16;
		public const int	PARAM_PEER_MT				=0x17;

		public const int	PARAM_TRANSPORT_TYPE		=0x18;
		public const int	PARAM_DSC_CONNECTION_TYPE	=0x19;

		public const int	PARAM_TCP_KEEPALIVE			=0x22;
		public const int	PARAM_IDENTIFIER_SEPARATOR	=0x23;

		public const int	PARAM_PPPKEEPALIVE			=0x24;
		public const int	PARAM_CUSTOM_HEART_LEN		=0x25;
		public const int	PARAM_CUSTOM_HEART			=0x26;

		public const int	PARAM_APP_VERSION			  =0x70;
		public const int	PARAM_APP_BUILT_DATE				=0x71;

		public const  int  PARAM_RO_SN 			 	  =0x72;
		public const int   PARAM_RO_HW_VERSION 				=0x73;
		public const int   PARAM_RO_LOGO 				  =0x74;
		private System.Windows.Forms.Timer timer1;
		public System.Windows.Forms.Timer timer2;
		public System.Windows.Forms.Timer timer3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		public System.Windows.Forms.Button button5;
		public const int   PARAM_RO_MT_TYPE_DESC 				=0x75;
        private Label label10;
        public FormDTUMain form1 = new FormDTUMain();
		//获得终端信息
		[DllImport(".\\wcomm_dll.dll")]
		public static extern int get_user_info(
			[MarshalAs(UnmanagedType.LPStr)]
			string userid,
			ref GPRS_USER_INFO infoPtr);

		//取消阻塞读取
		[DllImport(".\\wcomm_dll.dll")]
		public static extern void cancel_read_block();

		//使某个终端下线
		[DllImport(".\\wcomm_dll.dll")]
		public static extern int do_close_one_user(
			[MarshalAs(UnmanagedType.LPStr)]
			string userid,	
			[MarshalAs(UnmanagedType.LPStr)]
			StringBuilder mess);

		//使所有终端下线
		[DllImport(".\\wcomm_dll.dll")]
		public static extern int do_close_all_user(
			[MarshalAs(UnmanagedType.LPStr)]
			StringBuilder mess);

		//使某个终端下线
		[DllImport(".\\wcomm_dll.dll")]
		public static extern int do_close_one_user2(
			[MarshalAs(UnmanagedType.LPStr)]
			string userid,	
			[MarshalAs(UnmanagedType.LPStr)]
			StringBuilder mess);

		//使所有终端下线
		[DllImport(".\\wcomm_dll.dll")]
		public static extern int do_close_all_user2(
			[MarshalAs(UnmanagedType.LPStr)]
			StringBuilder mess);

		//设置服务类型
		[DllImport(".\\wcomm_dll.dll")]
		public static extern int SelectProtocol(int nProtocol);

		//指定服务IP
		[DllImport(".\\wcomm_dll.dll")]
		public static extern void SetCustomIP(int IP);

		//获得最大DTU连接数量
		[DllImport(".\\wcomm_dll.dll")]
		public static extern uint get_max_user_amount();

		//获得终端信息
		[DllImport(".\\wcomm_dll.dll")]
		public static extern int get_user_at(uint index,ref GPRS_USER_INFO infoPtr);

		//发送查询参数指令
		[DllImport(".\\wcomm_dll.dll")]
		public static extern int do_read_param(
			[MarshalAs(UnmanagedType.LPStr)]
			string userid,	
			[MarshalAs(UnmanagedType.LPStr)]
			StringBuilder mess);

		//发送参数设置指令
		[DllImport(".\\wcomm_dll.dll")]
		public static extern int do_update_param(
			[MarshalAs(UnmanagedType.LPStr)]
			string userid,	
			[MarshalAs(UnmanagedType.LPStr)]
			StringBuilder mess);

		//设置某项参数
		[DllImport(".\\wcomm_dll.dll")]
		public static extern int SetParam(
			int nParamType,
		//	[MarshalAs(UnmanagedType.LPStr)]
		//	StringBuilder cpValue,
			byte[] cpValue,
			int nParamLenth, int iErrorCode);

		//读取某项参数
		[DllImport(".\\wcomm_dll.dll")]
		public static extern int GetParam(
			int nParamType,
			//[MarshalAs(UnmanagedType.LPStr)]
			//StringBuilder cpValue,
			byte[] cpValue,
			ref int nParamLenth);

		//清空参数缓冲区
		[DllImport(".\\wcomm_dll.dll")]
		public static extern void ClearParam();

		private System.ComponentModel.IContainer components;

		public FormDTUConfig()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDTUConfig));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.checkBox21 = new System.Windows.Forms.CheckBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox24 = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.checkBox36 = new System.Windows.Forms.CheckBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.checkBox35 = new System.Windows.Forms.CheckBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.checkBox34 = new System.Windows.Forms.CheckBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.checkBox33 = new System.Windows.Forms.CheckBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.checkBox32 = new System.Windows.Forms.CheckBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.checkBox31 = new System.Windows.Forms.CheckBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.checkBox30 = new System.Windows.Forms.CheckBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.checkBox29 = new System.Windows.Forms.CheckBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.checkBox28 = new System.Windows.Forms.CheckBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.checkBox27 = new System.Windows.Forms.CheckBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.checkBox26 = new System.Windows.Forms.CheckBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.checkBox25 = new System.Windows.Forms.CheckBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.checkBox42 = new System.Windows.Forms.CheckBox();
            this.textBox34 = new System.Windows.Forms.TextBox();
            this.checkBox41 = new System.Windows.Forms.CheckBox();
            this.textBox33 = new System.Windows.Forms.TextBox();
            this.checkBox40 = new System.Windows.Forms.CheckBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.checkBox39 = new System.Windows.Forms.CheckBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.checkBox38 = new System.Windows.Forms.CheckBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.checkBox37 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.checkBox43 = new System.Windows.Forms.CheckBox();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(8, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(456, 264);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.checkBox6);
            this.tabPage1.Controls.Add(this.textBox5);
            this.tabPage1.Controls.Add(this.checkBox5);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.checkBox4);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.checkBox3);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.checkBox2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(448, 238);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "移动服务设置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(51, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(225, 35);
            this.label10.TabIndex = 13;
            this.label10.Text = "旧版已经作废";
            // 
            // checkBox6
            // 
            this.checkBox6.Location = new System.Drawing.Point(320, 144);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(48, 24);
            this.checkBox6.TabIndex = 12;
            this.checkBox6.Text = "全选";
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox5.HideSelection = false;
            this.textBox5.Location = new System.Drawing.Point(168, 160);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(128, 21);
            this.textBox5.TabIndex = 11;
            // 
            // checkBox5
            // 
            this.checkBox5.Location = new System.Drawing.Point(56, 160);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(104, 24);
            this.checkBox5.TabIndex = 10;
            this.checkBox5.Text = "SIM  PIN";
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(168, 136);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(128, 21);
            this.textBox4.TabIndex = 9;
            this.textBox4.Text = "CMNET";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.ForeColor = System.Drawing.Color.Red;
            this.checkBox4.Location = new System.Drawing.Point(56, 136);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(96, 24);
            this.checkBox4.TabIndex = 8;
            this.checkBox4.Text = "接入点名称";
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(168, 112);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(128, 21);
            this.textBox3.TabIndex = 7;
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(56, 112);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(96, 24);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "PPP登陆密码";
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(168, 88);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(128, 21);
            this.textBox2.TabIndex = 5;
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(56, 88);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 24);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "PPP用户名";
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(168, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "*99***1#";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(56, 64);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 24);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "服务代码";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(144, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(56, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "CDMA";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(56, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(64, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "GPRS";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox15);
            this.tabPage2.Controls.Add(this.textBox13);
            this.tabPage2.Controls.Add(this.checkBox14);
            this.tabPage2.Controls.Add(this.textBox12);
            this.tabPage2.Controls.Add(this.checkBox13);
            this.tabPage2.Controls.Add(this.textBox11);
            this.tabPage2.Controls.Add(this.checkBox12);
            this.tabPage2.Controls.Add(this.textBox10);
            this.tabPage2.Controls.Add(this.checkBox11);
            this.tabPage2.Controls.Add(this.textBox9);
            this.tabPage2.Controls.Add(this.checkBox10);
            this.tabPage2.Controls.Add(this.textBox8);
            this.tabPage2.Controls.Add(this.checkBox9);
            this.tabPage2.Controls.Add(this.textBox7);
            this.tabPage2.Controls.Add(this.checkBox8);
            this.tabPage2.Controls.Add(this.textBox6);
            this.tabPage2.Controls.Add(this.checkBox7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(448, 238);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DTU设置";
            // 
            // checkBox15
            // 
            this.checkBox15.Location = new System.Drawing.Point(360, 184);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(56, 24);
            this.checkBox15.TabIndex = 16;
            this.checkBox15.Text = "全选";
            this.checkBox15.CheckedChanged += new System.EventHandler(this.checkBox15_CheckedChanged);
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox13.Enabled = false;
            this.textBox13.Location = new System.Drawing.Point(184, 192);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(128, 21);
            this.textBox13.TabIndex = 15;
            // 
            // checkBox14
            // 
            this.checkBox14.Location = new System.Drawing.Point(40, 192);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(104, 24);
            this.checkBox14.TabIndex = 14;
            this.checkBox14.Text = "调试状态";
            this.checkBox14.CheckedChanged += new System.EventHandler(this.checkBox14_CheckedChanged);
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox12.Enabled = false;
            this.textBox12.Location = new System.Drawing.Point(184, 168);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(128, 21);
            this.textBox12.TabIndex = 13;
            this.textBox12.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
            // 
            // checkBox13
            // 
            this.checkBox13.Location = new System.Drawing.Point(40, 168);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(104, 24);
            this.checkBox13.TabIndex = 12;
            this.checkBox13.Text = "包分隔符";
            this.checkBox13.CheckedChanged += new System.EventHandler(this.checkBox13_CheckedChanged);
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox11.Enabled = false;
            this.textBox11.Location = new System.Drawing.Point(184, 144);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(128, 21);
            this.textBox11.TabIndex = 11;
            // 
            // checkBox12
            // 
            this.checkBox12.Location = new System.Drawing.Point(40, 144);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(104, 24);
            this.checkBox12.TabIndex = 10;
            this.checkBox12.Text = "最大包长";
            this.checkBox12.CheckedChanged += new System.EventHandler(this.checkBox12_CheckedChanged);
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox10.Enabled = false;
            this.textBox10.Location = new System.Drawing.Point(184, 120);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(128, 21);
            this.textBox10.TabIndex = 9;
            // 
            // checkBox11
            // 
            this.checkBox11.Location = new System.Drawing.Point(40, 120);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(144, 24);
            this.checkBox11.TabIndex = 8;
            this.checkBox11.Text = "最后包空闲时间间隔";
            this.checkBox11.CheckedChanged += new System.EventHandler(this.checkBox11_CheckedChanged);
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox9.Enabled = false;
            this.textBox9.Location = new System.Drawing.Point(184, 96);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(128, 21);
            this.textBox9.TabIndex = 7;
            // 
            // checkBox10
            // 
            this.checkBox10.Location = new System.Drawing.Point(40, 96);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(120, 24);
            this.checkBox10.TabIndex = 6;
            this.checkBox10.Text = "重连接时间间隔";
            this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox8.Enabled = false;
            this.textBox8.Location = new System.Drawing.Point(184, 72);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(128, 21);
            this.textBox8.TabIndex = 5;
            // 
            // checkBox9
            // 
            this.checkBox9.Location = new System.Drawing.Point(40, 72);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(128, 24);
            this.checkBox9.TabIndex = 4;
            this.checkBox9.Text = "在线报告时间间隔";
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(184, 48);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(128, 21);
            this.textBox7.TabIndex = 3;
            // 
            // checkBox8
            // 
            this.checkBox8.Location = new System.Drawing.Point(40, 48);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(104, 24);
            this.checkBox8.TabIndex = 2;
            this.checkBox8.Text = "本地端口";
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(184, 24);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(128, 21);
            this.textBox6.TabIndex = 1;
            // 
            // checkBox7
            // 
            this.checkBox7.Location = new System.Drawing.Point(40, 24);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(104, 24);
            this.checkBox7.TabIndex = 0;
            this.checkBox7.Text = "DTU标识";
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkBox23);
            this.tabPage3.Controls.Add(this.textBox20);
            this.tabPage3.Controls.Add(this.checkBox22);
            this.tabPage3.Controls.Add(this.textBox19);
            this.tabPage3.Controls.Add(this.checkBox21);
            this.tabPage3.Controls.Add(this.textBox18);
            this.tabPage3.Controls.Add(this.checkBox20);
            this.tabPage3.Controls.Add(this.textBox17);
            this.tabPage3.Controls.Add(this.checkBox19);
            this.tabPage3.Controls.Add(this.textBox16);
            this.tabPage3.Controls.Add(this.checkBox18);
            this.tabPage3.Controls.Add(this.textBox15);
            this.tabPage3.Controls.Add(this.checkBox17);
            this.tabPage3.Controls.Add(this.textBox14);
            this.tabPage3.Controls.Add(this.checkBox16);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(448, 238);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "数据中心设置";
            // 
            // checkBox23
            // 
            this.checkBox23.Location = new System.Drawing.Point(352, 136);
            this.checkBox23.Name = "checkBox23";
            this.checkBox23.Size = new System.Drawing.Size(72, 24);
            this.checkBox23.TabIndex = 14;
            this.checkBox23.Text = "全选";
            this.checkBox23.CheckedChanged += new System.EventHandler(this.checkBox23_CheckedChanged);
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox20.Enabled = false;
            this.textBox20.Location = new System.Drawing.Point(168, 184);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(152, 21);
            this.textBox20.TabIndex = 13;
            // 
            // checkBox22
            // 
            this.checkBox22.Location = new System.Drawing.Point(40, 184);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(104, 24);
            this.checkBox22.TabIndex = 12;
            this.checkBox22.Text = "备用DSC端口";
            this.checkBox22.CheckedChanged += new System.EventHandler(this.checkBox22_CheckedChanged);
            // 
            // textBox19
            // 
            this.textBox19.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox19.Enabled = false;
            this.textBox19.Location = new System.Drawing.Point(168, 160);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(152, 21);
            this.textBox19.TabIndex = 11;
            // 
            // checkBox21
            // 
            this.checkBox21.Location = new System.Drawing.Point(40, 160);
            this.checkBox21.Name = "checkBox21";
            this.checkBox21.Size = new System.Drawing.Size(104, 24);
            this.checkBox21.TabIndex = 10;
            this.checkBox21.Text = "备用DSC地址";
            this.checkBox21.CheckedChanged += new System.EventHandler(this.checkBox21_CheckedChanged);
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox18.Enabled = false;
            this.textBox18.Location = new System.Drawing.Point(168, 120);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(152, 21);
            this.textBox18.TabIndex = 9;
            // 
            // checkBox20
            // 
            this.checkBox20.Location = new System.Drawing.Point(40, 120);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(128, 24);
            this.checkBox20.TabIndex = 8;
            this.checkBox20.Text = "域名检测时间间隔";
            this.checkBox20.CheckedChanged += new System.EventHandler(this.checkBox20_CheckedChanged);
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox17.Enabled = false;
            this.textBox17.Location = new System.Drawing.Point(168, 96);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(152, 21);
            this.textBox17.TabIndex = 7;
            // 
            // checkBox19
            // 
            this.checkBox19.Location = new System.Drawing.Point(40, 96);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(136, 24);
            this.checkBox19.TabIndex = 6;
            this.checkBox19.Text = "域名服务器IP地址";
            this.checkBox19.CheckedChanged += new System.EventHandler(this.checkBox19_CheckedChanged);
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox16.Enabled = false;
            this.textBox16.Location = new System.Drawing.Point(168, 72);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(152, 21);
            this.textBox16.TabIndex = 5;
            // 
            // checkBox18
            // 
            this.checkBox18.ForeColor = System.Drawing.Color.Red;
            this.checkBox18.Location = new System.Drawing.Point(40, 72);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(104, 24);
            this.checkBox18.TabIndex = 4;
            this.checkBox18.Text = "DSC域名";
            this.checkBox18.CheckedChanged += new System.EventHandler(this.checkBox18_CheckedChanged);
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox15.Enabled = false;
            this.textBox15.Location = new System.Drawing.Point(168, 48);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(152, 21);
            this.textBox15.TabIndex = 3;
            // 
            // checkBox17
            // 
            this.checkBox17.ForeColor = System.Drawing.Color.Red;
            this.checkBox17.Location = new System.Drawing.Point(40, 48);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(104, 24);
            this.checkBox17.TabIndex = 2;
            this.checkBox17.Text = "主DSC端口";
            this.checkBox17.CheckedChanged += new System.EventHandler(this.checkBox17_CheckedChanged);
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox14.Enabled = false;
            this.textBox14.Location = new System.Drawing.Point(168, 24);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(152, 21);
            this.textBox14.TabIndex = 1;
            // 
            // checkBox16
            // 
            this.checkBox16.ForeColor = System.Drawing.Color.Red;
            this.checkBox16.Location = new System.Drawing.Point(40, 24);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(104, 24);
            this.checkBox16.TabIndex = 0;
            this.checkBox16.Text = "主DSC IP地址";
            this.checkBox16.CheckedChanged += new System.EventHandler(this.checkBox16_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(448, 238);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "串口设置";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox5);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox24);
            this.groupBox1.Location = new System.Drawing.Point(32, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // comboBox5
            // 
            this.comboBox5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox5.Enabled = false;
            this.comboBox5.Items.AddRange(new object[] {
            "Xon/Xoff",
            "硬件",
            "无",
            "半双工(RS485)",
            "全双工(RS422)"});
            this.comboBox5.Location = new System.Drawing.Point(168, 136);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 20);
            this.comboBox5.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(56, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "流控制";
            // 
            // comboBox4
            // 
            this.comboBox4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox4.Enabled = false;
            this.comboBox4.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.comboBox4.Location = new System.Drawing.Point(168, 112);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 20);
            this.comboBox4.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(56, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "校验位";
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox3.Enabled = false;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox3.Location = new System.Drawing.Point(168, 88);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 20);
            this.comboBox3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(56, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "停止位";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox2.Enabled = false;
            this.comboBox2.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.comboBox2.Location = new System.Drawing.Point(168, 64);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(56, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "数据位";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox1.Enabled = false;
            this.comboBox1.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBox1.Location = new System.Drawing.Point(168, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(56, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "波特率";
            // 
            // checkBox24
            // 
            this.checkBox24.Location = new System.Drawing.Point(24, 0);
            this.checkBox24.Name = "checkBox24";
            this.checkBox24.Size = new System.Drawing.Size(48, 24);
            this.checkBox24.TabIndex = 0;
            this.checkBox24.Text = "选择";
            this.checkBox24.CheckedChanged += new System.EventHandler(this.checkBox24_CheckedChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.checkBox36);
            this.tabPage5.Controls.Add(this.textBox29);
            this.tabPage5.Controls.Add(this.checkBox35);
            this.tabPage5.Controls.Add(this.textBox28);
            this.tabPage5.Controls.Add(this.checkBox34);
            this.tabPage5.Controls.Add(this.textBox27);
            this.tabPage5.Controls.Add(this.checkBox33);
            this.tabPage5.Controls.Add(this.textBox26);
            this.tabPage5.Controls.Add(this.checkBox32);
            this.tabPage5.Controls.Add(this.comboBox7);
            this.tabPage5.Controls.Add(this.checkBox31);
            this.tabPage5.Controls.Add(this.comboBox6);
            this.tabPage5.Controls.Add(this.checkBox30);
            this.tabPage5.Controls.Add(this.textBox25);
            this.tabPage5.Controls.Add(this.checkBox29);
            this.tabPage5.Controls.Add(this.textBox24);
            this.tabPage5.Controls.Add(this.checkBox28);
            this.tabPage5.Controls.Add(this.textBox23);
            this.tabPage5.Controls.Add(this.checkBox27);
            this.tabPage5.Controls.Add(this.textBox22);
            this.tabPage5.Controls.Add(this.checkBox26);
            this.tabPage5.Controls.Add(this.textBox21);
            this.tabPage5.Controls.Add(this.checkBox25);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(448, 238);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "特殊设置";
            // 
            // checkBox36
            // 
            this.checkBox36.Location = new System.Drawing.Point(320, 168);
            this.checkBox36.Name = "checkBox36";
            this.checkBox36.Size = new System.Drawing.Size(64, 24);
            this.checkBox36.TabIndex = 22;
            this.checkBox36.Text = "全选";
            this.checkBox36.CheckedChanged += new System.EventHandler(this.checkBox36_CheckedChanged);
            // 
            // textBox29
            // 
            this.textBox29.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox29.Enabled = false;
            this.textBox29.Location = new System.Drawing.Point(344, 104);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(96, 21);
            this.textBox29.TabIndex = 21;
            // 
            // checkBox35
            // 
            this.checkBox35.Location = new System.Drawing.Point(224, 104);
            this.checkBox35.Name = "checkBox35";
            this.checkBox35.Size = new System.Drawing.Size(128, 24);
            this.checkBox35.TabIndex = 20;
            this.checkBox35.Text = "自定义心跳包数据";
            this.checkBox35.CheckedChanged += new System.EventHandler(this.checkBox35_CheckedChanged);
            // 
            // textBox28
            // 
            this.textBox28.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox28.Enabled = false;
            this.textBox28.Location = new System.Drawing.Point(344, 80);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(96, 21);
            this.textBox28.TabIndex = 19;
            // 
            // checkBox34
            // 
            this.checkBox34.Location = new System.Drawing.Point(224, 80);
            this.checkBox34.Name = "checkBox34";
            this.checkBox34.Size = new System.Drawing.Size(128, 24);
            this.checkBox34.TabIndex = 18;
            this.checkBox34.Text = "自定义心跳包长度";
            this.checkBox34.CheckedChanged += new System.EventHandler(this.checkBox34_CheckedChanged);
            // 
            // textBox27
            // 
            this.textBox27.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox27.Enabled = false;
            this.textBox27.Location = new System.Drawing.Point(344, 56);
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new System.Drawing.Size(96, 21);
            this.textBox27.TabIndex = 17;
            // 
            // checkBox33
            // 
            this.checkBox33.Location = new System.Drawing.Point(224, 56);
            this.checkBox33.Name = "checkBox33";
            this.checkBox33.Size = new System.Drawing.Size(120, 24);
            this.checkBox33.TabIndex = 16;
            this.checkBox33.Text = "PPP保活时间间隔";
            this.checkBox33.CheckedChanged += new System.EventHandler(this.checkBox33_CheckedChanged);
            // 
            // textBox26
            // 
            this.textBox26.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox26.Enabled = false;
            this.textBox26.Location = new System.Drawing.Point(344, 32);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(96, 21);
            this.textBox26.TabIndex = 15;
            // 
            // checkBox32
            // 
            this.checkBox32.Location = new System.Drawing.Point(224, 32);
            this.checkBox32.Name = "checkBox32";
            this.checkBox32.Size = new System.Drawing.Size(120, 24);
            this.checkBox32.TabIndex = 14;
            this.checkBox32.Text = "TCP保活时间间隔";
            this.checkBox32.CheckedChanged += new System.EventHandler(this.checkBox32_CheckedChanged);
            // 
            // comboBox7
            // 
            this.comboBox7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox7.Enabled = false;
            this.comboBox7.Items.AddRange(new object[] {
            "0 UDP",
            "1 TCP"});
            this.comboBox7.Location = new System.Drawing.Point(120, 176);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(88, 20);
            this.comboBox7.TabIndex = 13;
            // 
            // checkBox31
            // 
            this.checkBox31.Location = new System.Drawing.Point(16, 176);
            this.checkBox31.Name = "checkBox31";
            this.checkBox31.Size = new System.Drawing.Size(104, 24);
            this.checkBox31.TabIndex = 12;
            this.checkBox31.Text = "与DSC连接方式";
            this.checkBox31.CheckedChanged += new System.EventHandler(this.checkBox31_CheckedChanged);
            // 
            // comboBox6
            // 
            this.comboBox6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox6.Enabled = false;
            this.comboBox6.Items.AddRange(new object[] {
            "0 透明传输",
            "1 协议传输"});
            this.comboBox6.Location = new System.Drawing.Point(120, 152);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(88, 20);
            this.comboBox6.TabIndex = 11;
            // 
            // checkBox30
            // 
            this.checkBox30.Location = new System.Drawing.Point(16, 152);
            this.checkBox30.Name = "checkBox30";
            this.checkBox30.Size = new System.Drawing.Size(96, 24);
            this.checkBox30.TabIndex = 10;
            this.checkBox30.Text = "传输方式";
            this.checkBox30.CheckedChanged += new System.EventHandler(this.checkBox30_CheckedChanged);
            // 
            // textBox25
            // 
            this.textBox25.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox25.Enabled = false;
            this.textBox25.Location = new System.Drawing.Point(120, 128);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(88, 21);
            this.textBox25.TabIndex = 9;
            // 
            // checkBox29
            // 
            this.checkBox29.Location = new System.Drawing.Point(16, 128);
            this.checkBox29.Name = "checkBox29";
            this.checkBox29.Size = new System.Drawing.Size(96, 24);
            this.checkBox29.TabIndex = 8;
            this.checkBox29.Text = "DSC标识";
            this.checkBox29.CheckedChanged += new System.EventHandler(this.checkBox29_CheckedChanged);
            // 
            // textBox24
            // 
            this.textBox24.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox24.Enabled = false;
            this.textBox24.Location = new System.Drawing.Point(120, 104);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(88, 21);
            this.textBox24.TabIndex = 7;
            // 
            // checkBox28
            // 
            this.checkBox28.Location = new System.Drawing.Point(16, 104);
            this.checkBox28.Name = "checkBox28";
            this.checkBox28.Size = new System.Drawing.Size(104, 24);
            this.checkBox28.TabIndex = 6;
            this.checkBox28.Text = "下线时间间隔";
            this.checkBox28.CheckedChanged += new System.EventHandler(this.checkBox28_CheckedChanged);
            // 
            // textBox23
            // 
            this.textBox23.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox23.Enabled = false;
            this.textBox23.Location = new System.Drawing.Point(120, 80);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(88, 21);
            this.textBox23.TabIndex = 5;
            // 
            // checkBox27
            // 
            this.checkBox27.Location = new System.Drawing.Point(16, 80);
            this.checkBox27.Name = "checkBox27";
            this.checkBox27.Size = new System.Drawing.Size(104, 24);
            this.checkBox27.TabIndex = 4;
            this.checkBox27.Text = "呼叫时间间隔";
            this.checkBox27.CheckedChanged += new System.EventHandler(this.checkBox27_CheckedChanged);
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox22.Enabled = false;
            this.textBox22.Location = new System.Drawing.Point(120, 56);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(88, 21);
            this.textBox22.TabIndex = 3;
            // 
            // checkBox26
            // 
            this.checkBox26.Location = new System.Drawing.Point(16, 56);
            this.checkBox26.Name = "checkBox26";
            this.checkBox26.Size = new System.Drawing.Size(96, 24);
            this.checkBox26.TabIndex = 2;
            this.checkBox26.Text = "呼叫方式";
            this.checkBox26.CheckedChanged += new System.EventHandler(this.checkBox26_CheckedChanged);
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox21.Enabled = false;
            this.textBox21.Location = new System.Drawing.Point(120, 32);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(88, 21);
            this.textBox21.TabIndex = 1;
            // 
            // checkBox25
            // 
            this.checkBox25.ForeColor = System.Drawing.Color.Red;
            this.checkBox25.Location = new System.Drawing.Point(16, 32);
            this.checkBox25.Name = "checkBox25";
            this.checkBox25.Size = new System.Drawing.Size(96, 24);
            this.checkBox25.TabIndex = 0;
            this.checkBox25.Text = "终端类型";
            this.checkBox25.CheckedChanged += new System.EventHandler(this.checkBox25_CheckedChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.textBox35);
            this.tabPage6.Controls.Add(this.checkBox42);
            this.tabPage6.Controls.Add(this.textBox34);
            this.tabPage6.Controls.Add(this.checkBox41);
            this.tabPage6.Controls.Add(this.textBox33);
            this.tabPage6.Controls.Add(this.checkBox40);
            this.tabPage6.Controls.Add(this.textBox32);
            this.tabPage6.Controls.Add(this.checkBox39);
            this.tabPage6.Controls.Add(this.textBox31);
            this.tabPage6.Controls.Add(this.checkBox38);
            this.tabPage6.Controls.Add(this.textBox30);
            this.tabPage6.Controls.Add(this.checkBox37);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(448, 238);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "其他设置";
            // 
            // textBox35
            // 
            this.textBox35.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox35.Enabled = false;
            this.textBox35.Location = new System.Drawing.Point(152, 160);
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new System.Drawing.Size(232, 21);
            this.textBox35.TabIndex = 11;
            // 
            // checkBox42
            // 
            this.checkBox42.Enabled = false;
            this.checkBox42.Location = new System.Drawing.Point(40, 160);
            this.checkBox42.Name = "checkBox42";
            this.checkBox42.Size = new System.Drawing.Size(104, 24);
            this.checkBox42.TabIndex = 10;
            this.checkBox42.Text = "DTU生产商LOGO";
            // 
            // textBox34
            // 
            this.textBox34.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox34.Enabled = false;
            this.textBox34.Location = new System.Drawing.Point(152, 136);
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new System.Drawing.Size(232, 21);
            this.textBox34.TabIndex = 9;
            // 
            // checkBox41
            // 
            this.checkBox41.Enabled = false;
            this.checkBox41.Location = new System.Drawing.Point(40, 136);
            this.checkBox41.Name = "checkBox41";
            this.checkBox41.Size = new System.Drawing.Size(120, 24);
            this.checkBox41.TabIndex = 8;
            this.checkBox41.Text = "DTU程序生成日期";
            // 
            // textBox33
            // 
            this.textBox33.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox33.Enabled = false;
            this.textBox33.Location = new System.Drawing.Point(152, 112);
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new System.Drawing.Size(232, 21);
            this.textBox33.TabIndex = 7;
            // 
            // checkBox40
            // 
            this.checkBox40.Enabled = false;
            this.checkBox40.Location = new System.Drawing.Point(40, 112);
            this.checkBox40.Name = "checkBox40";
            this.checkBox40.Size = new System.Drawing.Size(120, 24);
            this.checkBox40.TabIndex = 6;
            this.checkBox40.Text = "DTU硬件平台信息";
            // 
            // textBox32
            // 
            this.textBox32.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox32.Enabled = false;
            this.textBox32.Location = new System.Drawing.Point(152, 88);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(232, 21);
            this.textBox32.TabIndex = 5;
            // 
            // checkBox39
            // 
            this.checkBox39.Enabled = false;
            this.checkBox39.Location = new System.Drawing.Point(40, 88);
            this.checkBox39.Name = "checkBox39";
            this.checkBox39.Size = new System.Drawing.Size(104, 24);
            this.checkBox39.TabIndex = 4;
            this.checkBox39.Text = "DTU程序版本";
            // 
            // textBox31
            // 
            this.textBox31.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox31.Enabled = false;
            this.textBox31.Location = new System.Drawing.Point(152, 64);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(232, 21);
            this.textBox31.TabIndex = 3;
            // 
            // checkBox38
            // 
            this.checkBox38.Enabled = false;
            this.checkBox38.Location = new System.Drawing.Point(40, 64);
            this.checkBox38.Name = "checkBox38";
            this.checkBox38.Size = new System.Drawing.Size(104, 24);
            this.checkBox38.TabIndex = 2;
            this.checkBox38.Text = "DTU型号描述";
            // 
            // textBox30
            // 
            this.textBox30.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox30.Enabled = false;
            this.textBox30.Location = new System.Drawing.Point(152, 40);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(232, 21);
            this.textBox30.TabIndex = 1;
            // 
            // checkBox37
            // 
            this.checkBox37.Enabled = false;
            this.checkBox37.Location = new System.Drawing.Point(40, 40);
            this.checkBox37.Name = "checkBox37";
            this.checkBox37.Size = new System.Drawing.Size(104, 24);
            this.checkBox37.TabIndex = 0;
            this.checkBox37.Text = "DTU序列号";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "选择DTU:";
            // 
            // comboBox8
            // 
            this.comboBox8.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox8.Location = new System.Drawing.Point(24, 304);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(120, 20);
            this.comboBox8.TabIndex = 2;
            // 
            // checkBox43
            // 
            this.checkBox43.Location = new System.Drawing.Point(176, 320);
            this.checkBox43.Name = "checkBox43";
            this.checkBox43.Size = new System.Drawing.Size(80, 24);
            this.checkBox43.TabIndex = 3;
            this.checkBox43.Text = "超时设置";
            // 
            // textBox36
            // 
            this.textBox36.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox36.Location = new System.Drawing.Point(240, 320);
            this.textBox36.MaxLength = 5;
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new System.Drawing.Size(48, 21);
            this.textBox36.TabIndex = 4;
            this.textBox36.Text = "0";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(288, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "秒";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "查询";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(344, 296);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "设置";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(408, 296);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "默认";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(408, 328);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "重启";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(16, 322);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(142, 34);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(8, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "红色";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(40, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "的参数谨慎修改";
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(320, 328);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "取消";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FormDTUConfig
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(472, 358);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox36);
            this.Controls.Add(this.checkBox43);
            this.Controls.Add(this.comboBox8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDTUConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "远程参数设置";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		public void ChangeEditColor(CheckBox checkBox,TextBox textBox)
		{
			textBox.Enabled = checkBox.Checked;
			if(textBox.Enabled)
				textBox.BackColor = System.Drawing.SystemColors.Window;
			else
				textBox.BackColor = System.Drawing.SystemColors.ScrollBar;
		}

		public void ChangeCombColor(CheckBox checkBox,ComboBox comboBox)
		{
			comboBox.Enabled = checkBox.Checked;
			if(comboBox.Enabled)
				comboBox.BackColor = System.Drawing.SystemColors.Window;
			else
				comboBox.BackColor = System.Drawing.SystemColors.ScrollBar;
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox1.Text = "*99***1#";
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "CMNET";
			checkBox4.Enabled = true;
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox1.Text = "#777";
			textBox2.Text = "card";
			textBox3.Text = "card";
			textBox4.Text = "";
			checkBox4.Enabled = false;
			checkBox4.Checked = false;
		}

		private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox2,textBox2);
		}

		private void checkBox3_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox3,textBox3);
		}

		private void checkBox4_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox4,textBox4);
		}

		private void checkBox5_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox5,textBox5);
		}

		private void checkBox6_CheckedChanged(object sender, System.EventArgs e)
		{
			checkBox1.Checked = checkBox6.Checked;
			checkBox2.Checked = checkBox6.Checked;
			checkBox3.Checked = checkBox6.Checked;
			checkBox5.Checked = checkBox6.Checked;
			if(checkBox4.Enabled)
				checkBox4.Checked = checkBox6.Checked;
		}

		private void checkBox7_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox7,textBox6);
		}

		private void checkBox8_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox8,textBox7);
		}

		private void checkBox9_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox9,textBox8);
		}

		private void checkBox10_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox10,textBox9);
		}

		private void checkBox11_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox11,textBox10);
		}

		private void checkBox12_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox12,textBox11);
		}

		private void checkBox13_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox13,textBox12);
		}

		private void checkBox14_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox14,textBox13);
		}

		private void checkBox15_CheckedChanged(object sender, System.EventArgs e)
		{
			checkBox7.Checked = checkBox15.Checked;
			checkBox8.Checked = checkBox15.Checked;
			checkBox9.Checked = checkBox15.Checked;
			checkBox10.Checked = checkBox15.Checked;
			checkBox11.Checked = checkBox15.Checked;
			checkBox12.Checked = checkBox15.Checked;
			checkBox13.Checked = checkBox15.Checked;
			checkBox14.Checked = checkBox15.Checked;
		}

		private void checkBox16_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox16,textBox14);
		}

		private void checkBox17_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox17,textBox15);
		}

		private void checkBox18_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox18,textBox16);
		}

		private void checkBox19_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox19,textBox17);
		}

		private void checkBox20_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox20,textBox18);
		}

		private void checkBox21_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox21,textBox19);
		}

		private void checkBox22_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox22,textBox20);
		}

		private void checkBox23_CheckedChanged(object sender, System.EventArgs e)
		{
			checkBox16.Checked = checkBox23.Checked;
			checkBox17.Checked = checkBox23.Checked;
			checkBox18.Checked = checkBox23.Checked;
			checkBox19.Checked = checkBox23.Checked;
			checkBox20.Checked = checkBox23.Checked;
			checkBox21.Checked = checkBox23.Checked;
			checkBox22.Checked = checkBox23.Checked;
		}

		private void checkBox24_CheckedChanged(object sender, System.EventArgs e)
		{
			label1.Enabled = checkBox24.Checked;
			label2.Enabled = checkBox24.Checked;
			label3.Enabled = checkBox24.Checked;
			label4.Enabled = checkBox24.Checked;
			label5.Enabled = checkBox24.Checked;
			ChangeCombColor(checkBox24,comboBox1);
			ChangeCombColor(checkBox24,comboBox2);
			ChangeCombColor(checkBox24,comboBox3);
			ChangeCombColor(checkBox24,comboBox4);
			ChangeCombColor(checkBox24,comboBox5);
		}

		private void checkBox25_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox25,textBox21);
		}

		private void checkBox26_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox26,textBox22);
		}

		private void checkBox27_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox27,textBox23);
		}

		private void checkBox28_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox28,textBox24);
		}

		private void checkBox29_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox29,textBox25);
		}

		private void checkBox30_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeCombColor(checkBox30,comboBox6);
		}

		private void checkBox31_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeCombColor(checkBox31,comboBox7);
		}

		private void checkBox32_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox32,textBox26);
		}

		private void checkBox33_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox33,textBox27);
		}

		private void checkBox34_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox34,textBox28);
		}

		private void checkBox35_CheckedChanged(object sender, System.EventArgs e)
		{
			ChangeEditColor(checkBox35,textBox29);
		}

		private void checkBox36_CheckedChanged(object sender, System.EventArgs e)
		{
			checkBox25.Checked = checkBox36.Checked;
			checkBox26.Checked = checkBox36.Checked;
			checkBox27.Checked = checkBox36.Checked;
			checkBox28.Checked = checkBox36.Checked;
			checkBox29.Checked = checkBox36.Checked;
			checkBox30.Checked = checkBox36.Checked;
			checkBox31.Checked = checkBox36.Checked;
			checkBox32.Checked = checkBox36.Checked;
			checkBox33.Checked = checkBox36.Checked;
			checkBox34.Checked = checkBox36.Checked;
			checkBox35.Checked = checkBox36.Checked;
		}

//**********************************
//参数默认值
//**********************************
		private void button3_Click(object sender, System.EventArgs e)
		{
			if(radioButton1.Checked)
			{
				textBox1.Text = "*99***1#";
				textBox2.Text = "";
				textBox3.Text = "";
				textBox4.Text = "CMNET";
			}
			else if(radioButton2.Checked)
			{
				textBox1.Text = "#777";
				textBox2.Text = "card";
				textBox3.Text = "card";
				textBox4.Text = "";
			}
			textBox5.Text = "";

			textBox6.Text = "13912345678";
			textBox7.Text = "5001";
			textBox8.Text = "40";
			textBox9.Text = "0";
			textBox10.Text = "600";
			textBox11.Text = "256";
			textBox12.Text = "10";
			textBox13.Text = "1";

			textBox14.Text = "0.0.0.0";
			textBox15.Text = "5002";
			textBox16.Text = "mdtu.com";
			textBox17.Text = "202.96.134.133";
			textBox18.Text = "0";
			textBox19.Text = "0.0.0.0";
			textBox20.Text = "0";

			comboBox1.SelectedIndex = 9;
			comboBox2.SelectedIndex = 3;
			comboBox3.SelectedIndex = 0;
			comboBox4.SelectedIndex = 0;
			comboBox5.SelectedIndex = 2;

			textBox21.Text = "0";
			textBox22.Text = "2";
			textBox23.Text = "60";
			textBox24.Text = "0";
			textBox25.Text = "";
			comboBox6.SelectedIndex = 1;
			comboBox7.SelectedIndex = 0;
			textBox26.Text = "5";
			textBox27.Text = "0";
			textBox28.Text = "0";
			textBox29.Text = "";

			textBox30.Text = "";
			textBox31.Text = "";
			textBox32.Text = "";
			textBox33.Text = "";
			textBox34.Text = "";
			textBox25.Text = "";
		}

//*************************************
//重起DTU
//*************************************
		private void button4_Click(object sender, System.EventArgs e)
		{
			StringBuilder mess = new StringBuilder(500);
			if(comboBox8.Text.Length == 11)
			{
				if(MessageBox.Show("确定使该DTU下线？","确认",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)
					if(do_close_one_user2(comboBox8.Text,mess) == 0)//开发包函数，使某个DTU下线重起
					{
						RefreshDtu();
					}
			}
			else
				MessageBox.Show("请选择DTU！","确认",MessageBoxButtons.OK,MessageBoxIcon.Error);
		}

//************************************
//刷新DTU号码列表
//************************************
		public void RefreshDtu()
		{
			uint i,iDtuAmount;
			GPRS_USER_INFO user_info = new GPRS_USER_INFO();
			iDtuAmount = get_max_user_amount();//开发包函数：返回中心的最大连接终端数量
			comboBox8.Items.Clear();
			for(i =0;i < iDtuAmount;i++)
			{
				get_user_at(i,ref user_info);//开发包函数，获得DTU用户列表中某个位置的DTU信息
				if(user_info.m_status == 1)
				{
					comboBox8.Items.Add(user_info.m_userid);
				}
			}
		}

//*********************************
//定时刷新DTU号码列表
//*********************************
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			RefreshDtu();
		}

//***********************************
//读取参数
//***********************************
		private void button1_Click(object sender, System.EventArgs e)
		{
			StringBuilder mess = new StringBuilder(500);
			if(comboBox8.Text.Length == 11)
			{
				if(do_read_param(comboBox8.Text,mess) == 0)//开发包函数，发送查询参数指令给DTU
					if((checkBox43.Checked) && (int.Parse(textBox36.Text) > 0))
					{
						//启动查询超时定时器
						timer2.Interval = int.Parse(textBox36.Text)*1000;
						timer2.Enabled = true;
					}		
				button1.Enabled = false;//查询按钮变灰
				button5.Enabled = true;//取消按钮可用
			}
			else
				MessageBox.Show("请选择DTU！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
		}

		public string ByteToStr(byte[] buf)
		{
			string str = "";
			int i;
			for(i = 0;i<buf.Length;i++)
			{
				if(buf[i] == 0)
					return str;
				str = str + (char)buf[i];
			}
			return str;
		}
		
		public void StrToByte(byte[] buf,string str)
		{
			int i;
			for(i=0;i<str.Length;i++)
			{
				buf[i] = (byte)str[i];
			}
		}

		public int CmpStr(string str)
		{
			int i;
			byte[] buf;
			buf = new byte[100];
			StrToByte(buf,str);
			for(i = 0;i < str.Length;i++)
			{
				if((buf[i] < 48)||(buf[i] > 57))
					return 0;
			}
			return 1;
		}

		public int IvalidIp(string str)
		{
			int i,j;
			byte[] buf;
			buf = new byte[100];
			j = 0;
			StrToByte(buf,str);
			if((str.Length < 7)||(str.Length > 15))
				return 0;
			if((buf[0] == 46)||(buf[str.Length - 1] == 46))
				return 0;
			for(i=0;i<str.Length;i++)
			{
				if(buf[i] == 46)
				{
					j++;
					if(buf[i+1] == 46)
						return 0;
				}
				else if((buf[i] < 48)||(buf[i]>57))
					return 0;
			}
			if(j != 3)
				return 0;
			return 1;
		}
//*********************************************
//将参数缓冲区参数读取到DEMO界面
//*********************************************
		public void readconf()
		{
			//StringBuilder buf = new StringBuilder(300);
			byte[] buf;
			buf = new byte[300];
			int i;
			int paramlen;
			string s;

			if((checkBox43.Checked) && (int.Parse(textBox36.Text) > 0))
				timer2.Enabled = false;

			paramlen = 300;
			if(GetParam(PARAM_SERVER_CODE,buf,ref paramlen)==0)//开发包函数，读取某个参数
			{
				buf[paramlen] = 0;
				textBox1.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读移动服务设置参数<服务代码>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			if(textBox1.Text == "*99***1#")
				radioButton1.Checked = true;
			if(textBox1.Text == "#777")
				radioButton2.Checked = true;

			//paramlen = System.Runtime.InteropServices.Marshal.SizeOf(buf);
			paramlen = 300;
			if(GetParam(PARAM_USER_NAME,buf,ref paramlen)==0)
			{
				buf[paramlen] = 0;
				textBox2.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读移动服务设置参数<PPP用户名>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			//paramlen = System.Runtime.InteropServices.Marshal.SizeOf(buf);
			paramlen = 300;
			if(GetParam(PARAM_PASSWORDS,buf,ref paramlen)==0)
			{
				buf[paramlen] = 0;
				textBox3.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读移动服务设置参数<PPP用户密码>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			//paramlen = System.Runtime.InteropServices.Marshal.SizeOf(buf);
			paramlen = 300;
			if(GetParam(PARAM_APN,buf,ref paramlen)==0)
			{
				buf[paramlen] = 0;
				textBox4.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读移动服务设置参数<接入点名称>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			//paramlen = System.Runtime.InteropServices.Marshal.SizeOf(buf);
			paramlen = 300;
			if(GetParam(PARAM_SIMPIN,buf,ref paramlen)==0)
			{
				buf[paramlen] = 0;
				textBox5.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读移动服务设置参数<SIM  PIN>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

////////////////////////////////////////////////////

		//	paramlen = System.Runtime.InteropServices.Marshal.SizeOf(buf);
			paramlen = 300;
			if(GetParam(PARAM_LOCAL_MT,buf,ref paramlen)==0)
			{
				buf[paramlen] = 0;
				textBox6.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读DTU设置参数<DTU标识>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			//paramlen = System.Runtime.InteropServices.Marshal.SizeOf(buf);
			paramlen = 300;
			if(GetParam(PARAM_LOCAL_PORT,buf,ref paramlen)==0)
			{
				textBox7.Text = (buf[0]*256 + buf[1]).ToString();
			}
			else MessageBox.Show("读DTU设置参数<本地端口>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			//paramlen = System.Runtime.InteropServices.Marshal.SizeOf(buf);
			paramlen = 300;
			if(GetParam(PARAM_TIMEVAL,buf,ref paramlen)==0)
			{
				textBox8.Text = (buf[0]*256 + buf[1]).ToString();
			}
			else MessageBox.Show("读DTU设置参数<在线报告时间间隔>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
		
			paramlen = 300;
			if(GetParam(PARAM_RECONNECT_INTERVAL,buf,ref paramlen)==0)
			{
				textBox9.Text = ((byte)buf[0]*256 + (byte)buf[1]).ToString();
			}
			else MessageBox.Show("读DTU设置参数<重连接时间间隔>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_LAST_PACKET_IDLE,buf,ref paramlen)==0)
			{
				textBox10.Text = ((byte)buf[0]*256 + (byte)buf[1]).ToString();
			}
			else MessageBox.Show("读DTU设置参数<最后包空闲时间间隔>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_PACK_LEN,buf,ref paramlen)==0)
			{
				textBox11.Text = ((byte)buf[0]*256 + (byte)buf[1]).ToString();
			}
			else MessageBox.Show("读DTU设置参数<最大包长>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_IDENTIFIER_SEPARATOR,buf,ref paramlen)==0)
			{
				textBox12.Text = ((byte)buf[0]).ToString();
			}
			else MessageBox.Show("读DTU设置参数<包分隔符>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_DEBUG_TYPE,buf,ref paramlen)==0)
			{
				textBox13.Text = ((byte)buf[0]).ToString();
			}
			else MessageBox.Show("读DTU设置参数<调试状态>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

////////////////////////////////////////////////

			paramlen = 300;
			if(GetParam(PARAM_CENTER_ADDR,buf,ref paramlen)==0)
			{
				textBox14.Text = ((byte)buf[0]).ToString() + "."+((byte)buf[1]).ToString()+"."+((byte)buf[2]).ToString()
									+"."+((byte)buf[3]).ToString();
			}
			else MessageBox.Show("读数据中心参数<主DSC  IP地址>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_CENTER_PORT,buf,ref paramlen)==0)
			{
				textBox15.Text = ((byte)buf[0]*256 + (byte)buf[1]).ToString();
			}
			else MessageBox.Show("读数据中心参数<主DSC端口>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			
			paramlen = 300;
			if(GetParam(PARAM_CENTER_NAME,buf,ref paramlen)==0)
			{
				//buf[paramlen] = '\0';
				textBox16.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读数据中心参数<DSC域名>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
		
			paramlen = 300;
			if(GetParam(PARAM_DNS_ADDR,buf,ref paramlen)==0)
			{
				textBox17.Text = ((byte)buf[0]).ToString() + "."+((byte)buf[1]).ToString()+"."+((byte)buf[2]).ToString()
					+"."+((byte)buf[3]).ToString();
			}
			else MessageBox.Show("读数据中心参数<域名服务器IP地址>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_DOMAIN_TTL,buf,ref paramlen)==0)
			{
				textBox18.Text = ((byte)buf[0]*256 + (byte)buf[1]).ToString();
			}
			else MessageBox.Show("读数据中心参数<域名检测时间间隔>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_SEC_CENTER_ADDR,buf,ref paramlen)==0)
			{
				textBox19.Text = ((byte)buf[0]).ToString() + "."+((byte)buf[1]).ToString()+"."+((byte)buf[2]).ToString()
					+"."+((byte)buf[3]).ToString();
			}
			else MessageBox.Show("读数据中心参数<备用DSC地址>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_SEC_CENTER_PORT,buf,ref paramlen)==0)
			{
				textBox20.Text = ((byte)buf[0]*256 + (byte)buf[1]).ToString();
			}
			else MessageBox.Show("读数据中心参数<备用DSC端口>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

////////////////////////////////////////////////

			paramlen = 300;
			if(GetParam(PARAM_SERIAL_PORT,buf,ref paramlen)==0)
			{
				s = "";
				for(i = 0;i<paramlen;i++)
				{
					if(((char)buf[i]=='-') || (buf[i]==0x00))
						break;
					else 
						s = s + (char)buf[i];
				}
				comboBox1.Text = s;
				i = i + 1;
				if((i < (paramlen - 1))&&(buf[i] >= '5')&&(buf[i] <= '8'))
					comboBox2.SelectedIndex = (byte)buf[i] - 0x30 - 5;
				i = i + 2;
				if((i < (paramlen - 1))&&(buf[i] >= '1')&&(buf[i] <= '2'))
					comboBox3.SelectedIndex = (byte)buf[i] - 0x30 - 1;
				i = i + 2;
				if((i < (paramlen - 1))&&(buf[i] >= '0')&&(buf[i] <= '2'))
					comboBox4.SelectedIndex = (byte)buf[i] - 0x30;
				i = i + 2;
				if((i < paramlen) &&(buf[i] >= '1')&&(buf[i] <= '5'))
					comboBox5.SelectedIndex = (byte)buf[i] - 0x30 - 1;
			}
			else MessageBox.Show("读串口参数错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

//////////////////////////////////////////////////////////

			paramlen = 300;
			if(GetParam(PARAM_MT_TYPE,buf,ref paramlen)==0)
			{
				textBox21.Text = ((byte)buf[0]).ToString();
			}
			else MessageBox.Show("读特殊设置参数<终端类型>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_CALL_TYPE,buf,ref paramlen)==0)
			{
				textBox22.Text = ((byte)buf[0]).ToString();
			}
			else MessageBox.Show("读特殊设置参数<呼叫方式>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_CALL_TIMEVAL,buf,ref paramlen)==0)
			{
				textBox23.Text = ((byte)buf[0]*256 + (byte)buf[1]).ToString();
			}
			else MessageBox.Show("读特殊设置参数<呼叫时间间隔>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_OFF_LINETIME,buf,ref paramlen)==0)
			{
				textBox24.Text = ((byte)buf[0]*256 + (byte)buf[1]).ToString();
			}
			else MessageBox.Show("读特殊设置参数<下线时间间隔>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_PEER_MT,buf,ref paramlen)==0)
			{
				//buf[paramlen] = '\0';
				textBox25.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读特殊设置参数<DTU标识>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
		
			paramlen = 300;
			if(GetParam(PARAM_TRANSPORT_TYPE,buf,ref paramlen)==0)
			{
				comboBox6.SelectedIndex = buf[0];
			}
			else MessageBox.Show("读特殊设置参数<传输方式>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_DSC_CONNECTION_TYPE,buf,ref paramlen)==0)
			{
				comboBox7.SelectedIndex = buf[0];
			}
			else MessageBox.Show("读特殊设置参数<与DSC连接方式>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_TCP_KEEPALIVE,buf,ref paramlen)==0)
			{
				textBox26.Text = ((byte)buf[0]*256 + (byte)buf[1]).ToString();
			}
			else MessageBox.Show("读特殊设置参数<TCP保活时间间隔>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_PPPKEEPALIVE,buf,ref paramlen)==0)
			{
				textBox27.Text = ((byte)buf[0]*256 + (byte)buf[1]).ToString();
			}
			else MessageBox.Show("读特殊设置参数<PPP保活时间间隔>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_CUSTOM_HEART_LEN,buf,ref paramlen)==0)
			{
				textBox28.Text = ((byte)buf[0]).ToString();
			}
			else MessageBox.Show("读特殊设置参数<自定义心跳包长度>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

			paramlen = 300;
			if(GetParam(PARAM_CUSTOM_HEART,buf,ref paramlen)==0)
			{
			//	buf[paramlen] = '\0';
				textBox29.Text = form1.StrToHex(buf,paramlen);
			}
			else MessageBox.Show("读特殊设置参数<自定义心跳包数据>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
		
///////////////////////////////////////////////////

			paramlen = 300;
			if(GetParam(PARAM_RO_SN,buf,ref paramlen)==0)
			{
				//buf[paramlen] = '\0';
				textBox30.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读其他设置参数<DTU序列号>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
	
			paramlen = 300;
			if(GetParam(PARAM_RO_MT_TYPE_DESC,buf,ref paramlen)==0)
			{
				//buf[paramlen] = '\0';
				textBox31.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读其他设置参数<DTU型号描述>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
		
			paramlen = 300;
			if(GetParam(PARAM_APP_VERSION,buf,ref paramlen)==0)
			{
				//buf[paramlen] = '\0';
				textBox32.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读其他设置参数<DTU程序版本>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
		
			paramlen = 300;
			if(GetParam(PARAM_RO_HW_VERSION,buf,ref paramlen)==0)
			{
				//buf[paramlen] = '\0';
				textBox33.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读其他设置参数<DTU硬件平台版本>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
		
			paramlen = 300;
			if(GetParam(PARAM_APP_BUILT_DATE,buf,ref paramlen)==0)
			{
				//buf[paramlen] = '\0';
				textBox34.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读其他设置参数<DTU程序生成日期>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
		
			paramlen = 300;
			if(GetParam(PARAM_RO_LOGO,buf,ref paramlen)==0)
			{
				//buf[paramlen] = '\0';
				textBox35.Text = ByteToStr(buf);
			}
			else MessageBox.Show("读其他设置参数<DTU生产商LOGO>错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);

		}
		
		public void AddListItem(string a,string b,ListView listview)
		{
			ListViewItem list = listview.Items.Add(a);						
			list.SubItems.Add(b);
		}

		public void Addbuf(byte[] mess,string str)
		{
			int i;
			int j=0;
			string s = "";
			for(i=0;i<str.Length;i++)
			{
				if(str[i] == '.')
				{
					mess[j] = (byte)(int.Parse(s));
					j = j + 1;
					s = "";
				}
				else if(str[i] != ' ')
					s = s + str[i];
			}	  
			if(s != "")
				mess[j] = (byte)(int.Parse(s));
			
		}

//*******************************************
//设置参数
//*******************************************
		private void button2_Click(object sender, System.EventArgs e)
		{
			StringBuilder mess = new StringBuilder(500);
			byte[] buf;
			buf = new byte[300];
			int errorcode,paramlen;
			errorcode = 0;
			if(comboBox8.Text.Length == 11)
			{
				button2.Enabled = false;//设置按钮变灰
				button5.Enabled = true;//取消按钮可用
				//弹出参数设置确认对话框，将所选择的参数项和参数值添加到参数列表，若参数列表框为空，则该对话框“确定”
				//按钮为灰色，即不能进行参数设置
				FormDTUSelParam selform = new FormDTUSelParam();
				if(checkBox1.Checked)
					AddListItem("服务代码",textBox1.Text,selform.listView1);
				if(checkBox2.Checked)
					AddListItem("PPP用户名",textBox2.Text,selform.listView1);
				if(checkBox3.Checked)
					AddListItem("PPP登陆密码",textBox3.Text,selform.listView1);
				if(checkBox4.Checked)
					AddListItem("接入点名称",textBox4.Text,selform.listView1);
				if(checkBox5.Checked)
				    AddListItem("SIM  PIN",textBox5.Text,selform.listView1);

			    if(checkBox7.Checked)
					AddListItem("DTU标识",textBox6.Text,selform.listView1);
			    if(checkBox8.Checked)
					AddListItem("本地端口",textBox7.Text,selform.listView1);
			    if(checkBox9.Checked)
					AddListItem("在线报告时间间隔",textBox8.Text,selform.listView1);
				if(checkBox10.Checked)
					AddListItem("重连接时间间隔",textBox9.Text,selform.listView1);
			    if(checkBox11.Checked)
					AddListItem("最后包空闲时间间隔",textBox10.Text,selform.listView1);
			    if(checkBox12.Checked)
					AddListItem("最大包长",textBox11.Text,selform.listView1);
			    if(checkBox13.Checked)
					AddListItem("包分隔符",textBox12.Text,selform.listView1);
			    if(checkBox14.Checked)
					AddListItem("调试状态",textBox13.Text,selform.listView1);

				if(checkBox16.Checked)
					AddListItem("主DSC IP地址",textBox14.Text,selform.listView1);
				if(checkBox17.Checked)
					AddListItem("主DSC端口",textBox15.Text,selform.listView1);
			    if(checkBox18.Checked)
					AddListItem("DSC域名",textBox16.Text,selform.listView1);
				if(checkBox19.Checked)
					AddListItem("域名服务器IP地址",textBox17.Text,selform.listView1);
			    if(checkBox20.Checked)
					AddListItem("域名检测时间间隔",textBox18.Text,selform.listView1);
				if(checkBox21.Checked)
					AddListItem("备用DSC地址",textBox19.Text,selform.listView1);
			    if(checkBox22.Checked)
					AddListItem("备用DSC端口",textBox20.Text,selform.listView1);

				if(checkBox24.Checked)
				{
					AddListItem("波特率",comboBox1.Text,selform.listView1);
					AddListItem("数据位",comboBox2.Text,selform.listView1);
					AddListItem("停止位",comboBox3.Text,selform.listView1);
					AddListItem("校验位",comboBox4.Text,selform.listView1);
					AddListItem("流控制",comboBox5.Text,selform.listView1);
				}
				if(checkBox25.Checked)
					AddListItem("终端类型",textBox21.Text,selform.listView1);
			    if(checkBox26.Checked)
					AddListItem("呼叫方式",textBox22.Text,selform.listView1);
				if(checkBox27.Checked)
					AddListItem("呼叫时间间隔",textBox23.Text,selform.listView1);
				if(checkBox28.Checked)
					AddListItem("下线时间间隔",textBox24.Text,selform.listView1);
				if(checkBox29.Checked)
					AddListItem("DSC标识",textBox25.Text,selform.listView1);
				if(checkBox30.Checked)
					AddListItem("传输方式",comboBox6.Text,selform.listView1);
			    if(checkBox31.Checked)
					AddListItem("与DSC连接方式",comboBox7.Text,selform.listView1);
				if(checkBox32.Checked)
					AddListItem("TCP保活时间间隔",textBox26.Text,selform.listView1);
				if(checkBox33.Checked)
					AddListItem("PPP保活时间间隔",textBox27.Text,selform.listView1);
			    if(checkBox34.Checked)
					AddListItem("自定义心跳包长度",textBox28.Text,selform.listView1);
			    if(checkBox35.Checked)
					AddListItem("自定义心跳包数据",textBox29.Text,selform.listView1);

				if(checkBox37.Checked)
					AddListItem("DTU序列号",textBox30.Text,selform.listView1);
			    if(checkBox38.Checked)
					AddListItem("DTU型号描述",textBox31.Text,selform.listView1);
			    if(checkBox39.Checked)
					AddListItem("DTU程序版本",textBox32.Text,selform.listView1);
			    if(checkBox40.Checked)
					AddListItem("DTU硬件平台版本",textBox33.Text,selform.listView1);
			    if(checkBox41.Checked)
					AddListItem("DTU程序生成日期",textBox34.Text,selform.listView1);
			    if(checkBox42.Checked)
					AddListItem("DTU生产商LOGO",textBox35.Text,selform.listView1);

				if(selform.listView1.Items.Count == 0)
					selform.button1.Enabled = false;
				else 
					selform.button1.Enabled = true;

				if(selform.ShowDialog()==DialogResult.OK)
				{
					ClearParam();//开发包函数，清除参数缓冲区
					if(checkBox1.Checked)
					{
						StrToByte(buf,textBox1.Text);
						paramlen = textBox1.Text.Length;
						if(SetParam(PARAM_SERVER_CODE, buf, paramlen, errorcode) != 0)//开发包函数，设置某个参数
						{
							MessageBox.Show("移动服务参数‘服务代码’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox2.Checked)
					{
						StrToByte(buf,textBox2.Text);
						paramlen = textBox2.Text.Length;
						if(SetParam(PARAM_USER_NAME, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("移动服务参数‘PPP用户名’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox3.Checked)
					{
						StrToByte(buf,textBox3.Text);
						paramlen = textBox3.Text.Length;
						if(SetParam(PARAM_PASSWORDS, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("移动服务参数‘PPP密码’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox4.Checked)
					{
						StrToByte(buf,textBox4.Text);
						paramlen = textBox4.Text.Length;
						if(SetParam(PARAM_APN, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("移动服务参数‘接入点名称’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox5.Checked)
					{
						StrToByte(buf,textBox5.Text);
						paramlen = textBox5.Text.Length;
						if(SetParam(PARAM_SIMPIN, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("移动服务参数‘SIM  PIN’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

////////////////////////////////////////////////

					if(checkBox7.Checked)
					{
						StrToByte(buf,textBox6.Text);
						paramlen = textBox6.Text.Length;
						if(SetParam(PARAM_LOCAL_MT, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("DTU设置参数‘DTU标识’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox8.Checked)
					{
						if(CmpStr(textBox7.Text) == 0)
						{
							MessageBox.Show("DTU设置参数‘本地端口’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						}
						buf[0] = (byte)(int.Parse(textBox7.Text)/256);
						buf[1] = (byte)(int.Parse(textBox7.Text)%256);
						paramlen = 2;
						if(SetParam(PARAM_LOCAL_PORT, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("DTU设置参数‘本地端口’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox9.Checked)
					{
						if(CmpStr(textBox8.Text) == 0)
						{
							MessageBox.Show("DTU设置参数‘在线报告时间间隔’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox8.Text)/256);
						buf[1] = (byte)(int.Parse(textBox8.Text)%256);
						paramlen = 2;
						if(SetParam(PARAM_TIMEVAL, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("DTU设置参数‘在线报告时间间隔’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox10.Checked)
					{
						if(CmpStr(textBox9.Text) == 0)
						{
							MessageBox.Show("DTU设置参数‘重连接时间间隔’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox9.Text)/256);
						buf[1] = (byte)(int.Parse(textBox9.Text)%256);
						paramlen = 2;
						if(SetParam(PARAM_RECONNECT_INTERVAL, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("DTU设置参数‘重连接时间间隔’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox11.Checked)
					{
						if(CmpStr(textBox10.Text) == 0)
						{
							MessageBox.Show("DTU设置参数‘最后包空闲时间间隔’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox10.Text)/256);
						buf[1] = (byte)(int.Parse(textBox10.Text)%256);
						paramlen = 2;
						if(SetParam(PARAM_LAST_PACKET_IDLE, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("DTU设置参数‘最后包空闲时间间隔’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox12.Checked)
					{
						if(CmpStr(textBox11.Text) == 0)
						{
							MessageBox.Show("DTU设置参数‘最大包长’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox11.Text)/256);
						buf[1] = (byte)(int.Parse(textBox11.Text)%256);
						paramlen = 2;
						if(SetParam(PARAM_PACK_LEN, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("DTU设置参数‘最大包长’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox13.Checked)
					{
						if(CmpStr(textBox12.Text) == 0)
						{
							MessageBox.Show("DTU设置参数‘包分隔符’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox12.Text));
						paramlen = 1;
						if(SetParam(PARAM_IDENTIFIER_SEPARATOR, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("DTU设置参数‘包分隔符’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox14.Checked)
					{
						if(CmpStr(textBox13.Text) == 0)
						{
							MessageBox.Show("DTU设置参数‘调试状态’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox13.Text));
						paramlen = 1;
						if(SetParam(PARAM_DEBUG_TYPE, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("DTU设置参数‘调试状态’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

///////////////////////////////////////////


					if(checkBox16.Checked)
					{
						if(IvalidIp(textBox14.Text) == 0)
						{
							MessageBox.Show("数据中心参数‘主DSC  IP地址’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						}
						Addbuf(buf,textBox14.Text);
						paramlen = 4;
						if(SetParam(PARAM_CENTER_ADDR, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("数据中心参数‘主DSC  IP地址’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox17.Checked)
					{
						if(CmpStr(textBox15.Text) == 0)
						{
							MessageBox.Show("数据中心参数‘主DSC端口’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox15.Text)/256);
						buf[1] = (byte)(int.Parse(textBox15.Text)%256);
						paramlen = 2;
						if(SetParam(PARAM_CENTER_PORT, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("数据中心参数‘主DSC端口’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox18.Checked)
					{
						StrToByte(buf,textBox16.Text);
						paramlen = textBox16.Text.Length;
						if(SetParam(PARAM_CENTER_NAME, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("数据中心参数‘DSC域名’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox19.Checked)
					{
						if(IvalidIp(textBox17.Text) == 0)
						{
							MessageBox.Show("数据中心参数‘主DSC  IP地址’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						}
						Addbuf(buf,textBox17.Text);
						paramlen = 4;
						if(SetParam(PARAM_DNS_ADDR, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("数据中心参数‘域名服务器IP地址’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox20.Checked)
					{
						if(CmpStr(textBox18.Text) == 0)
						{
							MessageBox.Show("数据中心参数‘域名检测时间间隔’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox18.Text)/256);
						buf[1] = (byte)(int.Parse(textBox18.Text)%256);
						paramlen = 2;
						if(SetParam(PARAM_DOMAIN_TTL, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("数据中心参数‘域名检测时间间隔’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox21.Checked)
					{
						if(IvalidIp(textBox19.Text) == 0)
						{
							MessageBox.Show("数据中心参数‘主DSC  IP地址’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						}
						Addbuf(buf,textBox19.Text);
						paramlen = 4;
						if(SetParam(PARAM_SEC_CENTER_ADDR, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("数据中心参数‘备用DSC地址’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox22.Checked)
					{
						if(CmpStr(textBox20.Text) == 0)
						{
							MessageBox.Show("数据中心参数‘备用DSC端口’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox20.Text)/256);
						buf[1] = (byte)(int.Parse(textBox20.Text)%256);
						paramlen = 2;
						if(SetParam(PARAM_SEC_CENTER_PORT, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("数据中心参数‘备用DSC端口’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}
//////////////////////////////////////////////////

					if(checkBox24.Checked)
					{
						StrToByte(buf,comboBox1.Text);
						buf[comboBox1.Text.Length] = (byte)'-';
						buf[comboBox1.Text.Length + 1] = (byte)(comboBox2.SelectedIndex + 5 + 48);
						buf[comboBox1.Text.Length + 2] = (byte)'-';
						buf[comboBox1.Text.Length + 3] = (byte)(comboBox3.SelectedIndex + 1 + 48);
						buf[comboBox1.Text.Length + 4] = (byte)'-';
						buf[comboBox1.Text.Length + 5] = (byte)(comboBox4.SelectedIndex + 48);
						buf[comboBox1.Text.Length + 6] = (byte)'-';
						buf[comboBox1.Text.Length + 7] = (byte)(comboBox5.SelectedIndex + 1 + 48);
						paramlen = comboBox1.Text.Length + 8;
						if(SetParam(PARAM_SERIAL_PORT, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("串口参数设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

///////////////////////////////////////////////////////

					if(checkBox25.Checked)
					{
						if(CmpStr(textBox21.Text) == 0)
						{
							MessageBox.Show("特殊参数‘终端类型’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox21.Text));
						paramlen = 1;
						if(SetParam(PARAM_MT_TYPE, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘终端类型’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox26.Checked)
					{
						if(CmpStr(textBox22.Text) == 0)
						{
							MessageBox.Show("特殊参数‘呼叫方式’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox22.Text));
						paramlen = 1;
						if(SetParam(PARAM_CALL_TYPE, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘呼叫方式’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox27.Checked)
					{
						if(CmpStr(textBox23.Text) == 0)
						{
							MessageBox.Show("特殊参数‘呼叫时间间隔’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox23.Text)/256);
						buf[1] = (byte)(int.Parse(textBox23.Text)%256);
						paramlen = 2;
						if(SetParam(PARAM_CALL_TIMEVAL, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘呼叫时间间隔’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox28.Checked)
					{
						if(CmpStr(textBox24.Text) == 0)
						{
							MessageBox.Show("特殊参数‘下线时间间隔’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox24.Text)/256);
						buf[1] = (byte)(int.Parse(textBox24.Text)%256);
						paramlen = 2;
						if(SetParam(PARAM_OFF_LINETIME, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘下线时间间隔’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox29.Checked)
					{
						StrToByte(buf,textBox25.Text);
						paramlen = textBox25.Text.Length;
						if(SetParam(PARAM_PEER_MT, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘DSC标识’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox30.Checked)
					{
						if((comboBox6.SelectedIndex != 0)&&(comboBox6.SelectedIndex != 1))
						{
							MessageBox.Show("特殊参数‘传输方式’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						}
						buf[0] = (byte)(comboBox6.SelectedIndex);
						paramlen = 1;
						if(SetParam(PARAM_TRANSPORT_TYPE, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘传输方式’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox31.Checked)
					{
						if((comboBox7.SelectedIndex != 0)&&(comboBox7.SelectedIndex != 1))
						{
							MessageBox.Show("特殊参数‘与DSC连接方式’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						}
						buf[0] = (byte)(comboBox7.SelectedIndex);
						paramlen = 1;
						if(SetParam(PARAM_DSC_CONNECTION_TYPE, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘与DSC连接方式’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox32.Checked)
					{
						if(CmpStr(textBox26.Text) == 0)
						{
							MessageBox.Show("特殊参数‘TCP保活时间间隔’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox26.Text)/256);
						buf[1] = (byte)(int.Parse(textBox26.Text)%256);
						paramlen = 2;
						if(SetParam(PARAM_TCP_KEEPALIVE, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘TCP保活时间间隔’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox33.Checked)
					{
						if(CmpStr(textBox27.Text) == 0)
						{
							MessageBox.Show("特殊参数‘PPP保活时间间隔’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox27.Text)/256);
						buf[1] = (byte)(int.Parse(textBox27.Text)%256);
						paramlen = 2;
						if(SetParam(PARAM_PPPKEEPALIVE, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘PPP保活时间间隔’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox34.Checked)
					{
						if(CmpStr(textBox28.Text) == 0)
						{
							MessageBox.Show("特殊参数‘自定义心跳包长度’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						buf[0] = (byte)(int.Parse(textBox28.Text));
						paramlen = 1;
						if(SetParam(PARAM_CUSTOM_HEART_LEN, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘自定义心跳包长度’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox35.Checked)
					{
						paramlen = form1.HexToStr(textBox29.Text,buf);
						//StrToByte(buf,textBox29.Text);
						//paramlen = textBox29.Text.Length;
						if(paramlen != (byte)(int.Parse(textBox28.Text)))
						{
							MessageBox.Show("特殊参数‘自定义心跳包数据’设置不合法!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
						if(SetParam(PARAM_CUSTOM_HEART, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘自定义心跳包数据’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}
////////////////////////////////////////////////////////

					if(checkBox37.Checked)
					{
						StrToByte(buf,textBox30.Text);
						paramlen = textBox30.Text.Length;
						if(SetParam(PARAM_RO_SN, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘DTU序列号’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox38.Checked)
					{
						StrToByte(buf,textBox31.Text);
						paramlen = textBox31.Text.Length;
						if(SetParam(PARAM_RO_MT_TYPE_DESC, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘DTU型号描述’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox39.Checked)
					{
						StrToByte(buf,textBox32.Text);
						paramlen = textBox32.Text.Length;
						if(SetParam(PARAM_APP_VERSION, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘DTU程序版本’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox40.Checked)
					{
						StrToByte(buf,textBox33.Text);
						paramlen = textBox33.Text.Length;
						if(SetParam(PARAM_RO_HW_VERSION, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘DTU硬件平台版本’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox41.Checked)
					{
						StrToByte(buf,textBox34.Text);
						paramlen = textBox34.Text.Length;
						if(SetParam(PARAM_APP_BUILT_DATE, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘DTU程序生成日期’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}

					if(checkBox42.Checked)
					{
						StrToByte(buf,textBox35.Text);
						paramlen = textBox35.Text.Length;
						if(SetParam(PARAM_RO_LOGO, buf, paramlen, errorcode) != 0)
						{
							MessageBox.Show("特殊参数‘DTU生产商LOGO’设置错误!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
							return;
						} 
					}
					
					if(do_update_param(comboBox8.Text,mess)==0)//开发包函数。发送设置参数指令到DTU
						if((checkBox43.Checked) && (int.Parse(textBox36.Text) > 0))
						{
							timer3.Interval = int.Parse(textBox36.Text)*1000;
							timer3.Enabled = true;
						}
				}	
			}	
			else 
				MessageBox.Show("请选择DTU！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
		}
//查询参数超时定时器
		private void timer2_Tick(object sender, System.EventArgs e)
		{
			timer2.Enabled = false;
			MessageBox.Show("读取参数超时！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
		}
//设置参数超时定时器
		private void timer3_Tick(object sender, System.EventArgs e)
		{
			timer3.Enabled = false;
			MessageBox.Show("设置参数超时！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			button2.Enabled = true;
			button1.Enabled = true;
			button5.Enabled = false;
		}

		private void textBox4_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void textBox12_TextChanged(object sender, System.EventArgs e)
		{
		
		}



	}
}
