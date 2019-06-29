using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DSCDTU
{
    //结构定义
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct GPRS_DATA_RECORD
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string m_userid;                         //终端模块号码
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string m_recv_date;                     //接收到数据包的时间
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)] //这里做了修改，转换时由ByValTStr变为ByValArray类型，
        public byte[] m_data_buf;                   //存储接收到的数据
        public ushort m_data_len;                   //接收到的数据包长度
        public byte m_data_type;                //接收到的数据包类型
        public void Initialize()                    //初始化byte[]的字段
        {
            m_data_buf = new byte[1024];
        }

    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct GPRS_USER_INFO
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public string m_userid;             //终端模块号码	
        public uint m_sin_addr;             //终端模块进入Internet的代理主机IP地址
        public ushort m_sin_port;               //终端模块进入Internet的代理主机IP端口
        public uint m_local_addr;           //终端模块在移动网内IP地址
        public ushort m_local_port;         //终端模块在移动网内IP端口
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string m_logon_date;         //终端模块登录时间
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]   //这里做了修改，转换时由ByValTStr变为ByValArray类型，
        public byte[] m_update_time;            //终端用户更新时间
                                                //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
                                                //	public string	m_update_time;
        public byte m_status;               //终端模块状态, 1 在线 0 不在线
        public void Initialize()                    //初始化byte[]的字段
        {
            m_update_time = new byte[20];
        }
    }
    /// <summary>
    /// Form1 的摘要说明。
    /// </summary>
    public class FormDTUMain : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.ComponentModel.IContainer components;

        public FormDTUSetting serviceinfo = new FormDTUSetting();
        public FormDTUConfig config;
        public string serv_ip;
        public int connect_time;
        public int refresh_time;
        public int serv_port;
        public int serv_type;
        public int serv_mode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        public int serv_start = 0;
        private System.Windows.Forms.Timer timer3;
        public int sign;

        public bool recvdata;
        public bool threadrun;//控制线程
        private StatusBarPanel statusBarPanel3;
        private StatusBarPanel statusBarPanel2;
        private StatusBarPanel statusBarPanel1;
        private StatusBar statusBar1;
        private ColumnHeader columnHeader7;
        private GroupBox groupBox3;
        private CheckBox checkBox3;
        private MenuItem menuItem9;
        private MenuItem menuItem13;
        public Thread thread;//阻塞模式读取数据线程
                             //定义接口函数		

        //启动服务
        [DllImport(".\\wcomm_dll.dll")]
        public static extern int start_gprs_server(
            IntPtr hWnd,
            int wMsg,
            int nServerPort,
            [MarshalAs(UnmanagedType.LPStr)]
            StringBuilder mess);
        //启动服务
        [DllImport(".\\wcomm_dll.dll")]
        public static extern int start_net_service(
            IntPtr hWnd,
            int wMsg,
            int nServerPort,
            [MarshalAs(UnmanagedType.LPStr)]
            StringBuilder mess);

        //停止服务
        [DllImport(".\\wcomm_dll.dll")]
        public static extern int stop_gprs_server(
            [MarshalAs(UnmanagedType.LPStr)]
            StringBuilder mess);
        //停止服务
        [DllImport(".\\wcomm_dll.dll")]
        public static extern int stop_net_service(
            [MarshalAs(UnmanagedType.LPStr)]
            StringBuilder mess);

        //读取数据
        [DllImport(".\\wcomm_dll.dll")]
        public static extern int do_read_proc(
            ref GPRS_DATA_RECORD recdPtr,
            [MarshalAs(UnmanagedType.LPStr)]
            StringBuilder mess,
            bool reply);

        //发送数据
        [DllImport(".\\wcomm_dll.dll")]
        public static extern int do_send_user_data(
            [MarshalAs(UnmanagedType.LPStr)]
            string userid,
            //[MarshalAs(UnmanagedType.LPStr)]
            //string data,
            byte[] data,
            int len,
            [MarshalAs(UnmanagedType.LPStr)]
            StringBuilder mess);

        //获取终端信息
        [DllImport(".\\wcomm_dll.dll")]
        public static extern int get_user_info(
            [MarshalAs(UnmanagedType.LPStr)]
            string userid,
            ref GPRS_USER_INFO infoPtr);

        //设置服务模式
        [DllImport(".\\wcomm_dll.dll")]
        public static extern int SetWorkMode(int nWorkMode);

        //取消阻塞读取
        [DllImport(".\\wcomm_dll.dll")]
        public static extern void cancel_read_block();

        //使某个DTU下线
        [DllImport(".\\wcomm_dll.dll")]
        public static extern int do_close_one_user(
            [MarshalAs(UnmanagedType.LPStr)]
            string userid,
            [MarshalAs(UnmanagedType.LPStr)]
            StringBuilder mess);

        //使所有DTU下线
        [DllImport(".\\wcomm_dll.dll")]
        public static extern int do_close_all_user(
            [MarshalAs(UnmanagedType.LPStr)]
            StringBuilder mess);

        //使某个DTU下线
        [DllImport(".\\wcomm_dll.dll")]
        public static extern int do_close_one_user2(
            [MarshalAs(UnmanagedType.LPStr)]
            string userid,
            [MarshalAs(UnmanagedType.LPStr)]
            StringBuilder mess);

        //使所有DTU下线
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

        //获取终端信息
        [DllImport(".\\wcomm_dll.dll")]
        public static extern int get_user_at(uint index, ref GPRS_USER_INFO infoPtr);

        //加载配置查询的对话框
        [DllImport(".\\wcomm_dll.dll")]
        public static extern void InvokeParamUI(IntPtr hWnd);

        //加载日志
        [DllImport(".\\wcomm_dll.dll")]
        public static extern void InvokeLogUI(IntPtr hWnd);

        //加载DTU升级
        [DllImport(".\\wcomm_dll.dll")]
        public static extern void InvokeUpdateUI(IntPtr hWnd);



        //定义一些SOCKET API函数
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);
        [DllImport("Ws2_32.dll")]
        private static extern string inet_ntoa(uint ip);
        [DllImport("Ws2_32.dll")]
        private static extern uint htonl(uint ip);
        [DllImport("Ws2_32.dll")]
        private static extern uint ntohl(uint ip);
        [DllImport("Ws2_32.dll")]
        private static extern ushort htons(ushort ip);
        [DllImport("Ws2_32.dll")]
        private static extern ushort ntohs(ushort ip);

        public const int WM_DTU = 0x400 + 100;

        public FormDTUMain()
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDTUMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.statusBarPanel3 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem6,
            this.menuItem7,
            this.menuItem8,
            this.menuItem10});
            this.menuItem1.Text = "服务控制";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "启动服务";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Enabled = false;
            this.menuItem6.Index = 1;
            this.menuItem6.Text = "停止服务";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Enabled = false;
            this.menuItem7.Index = 2;
            this.menuItem7.Text = "分离终端";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 3;
            this.menuItem8.Text = "刷新信息";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 4;
            this.menuItem10.Text = "退出";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11});
            this.menuItem2.Text = "系统设置";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 0;
            this.menuItem11.Text = "服务参数设置";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem12,
            this.menuItem9,
            this.menuItem13});
            this.menuItem3.Text = "DTU管理";
            // 
            // menuItem12
            // 
            this.menuItem12.Enabled = false;
            this.menuItem12.Index = 0;
            this.menuItem12.Text = "远程参数设置";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Enabled = false;
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "日志管理";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Enabled = false;
            this.menuItem13.Index = 2;
            this.menuItem13.Text = "DTU升级";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "帮助";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "play-circle.png");
            this.imageList1.Images.SetKeyName(1, "close-circle.png");
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(6, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(730, 160);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "终端登陆号码";
            this.columnHeader1.Width = 116;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "登陆时间";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "最后注册时间";
            this.columnHeader3.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "终端IP地址";
            this.columnHeader4.Width = 103;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "终端端口";
            this.columnHeader5.Width = 65;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "网关IP地址";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "网关端口";
            this.columnHeader7.Width = 64;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 467);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运行信息";
            // 
            // checkBox3
            // 
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(257, 12);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(125, 24);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "禁用DTU列表刷新";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(201, 12);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(112, 24);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "应答";
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(84, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 24);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "16进制显示数据";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox1.Location = new System.Drawing.Point(6, 38);
            this.textBox1.MaxLength = 30000;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(730, 423);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 677);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(742, 72);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送信息";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(563, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "(毫秒)";
            // 
            // comboBox1
            // 
            this.comboBox1.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "500",
            "1000",
            "2000",
            "3000",
            "5000",
            "10000"});
            this.comboBox1.Location = new System.Drawing.Point(485, 13);
            this.comboBox1.MaxDropDownItems = 12;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(72, 20);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Tag = "";
            this.comboBox1.Text = "1000";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(415, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 26);
            this.button2.TabIndex = 7;
            this.button2.Text = "定时发送";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(288, 13);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 21);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "16进制";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(229, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 21);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.Text = "文本";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(182, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "信息：";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(617, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "发送";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(184, 40);
            this.textBox3.MaxLength = 300;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(416, 21);
            this.textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(32, 40);
            this.textBox2.MaxLength = 11;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(120, 21);
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(30, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "终端号码：";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // statusBarPanel3
            // 
            this.statusBarPanel3.Name = "statusBarPanel3";
            this.statusBarPanel3.Text = "糖不吃先生";
            this.statusBarPanel3.Width = 220;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Text = "服务停止";
            this.statusBarPanel2.Width = 370;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "服务状态：";
            this.statusBarPanel1.Width = 80;
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 755);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanel3});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(766, 23);
            this.statusBar1.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.Location = new System.Drawing.Point(12, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(742, 194);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DTU列表";
            // 
            // FormDTUMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(766, 778);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "FormDTUMain";
            this.Text = "DSCDTU";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new FormDTUMain());
        }

        //**********************************************************
        //获得本机所有IP，并添加到IP列表框		
        //**********************************************************
        public void addIP(ComboBox comboBox)
        {
            string hostname = Dns.GetHostName();
            System.Net.IPHostEntry addr = Dns.GetHostByName(hostname);
            IPAddress[] IpAddr = addr.AddressList;
            for (int i = 0; i < IpAddr.Length; i++)
            {
                string a = IpAddr[i].ToString();
                comboBox.Items.Add(IpAddr[i].ToString());
            }
        }

        public void AddText(string str)
        {
            this.Invoke(new EventHandler(delegate
            {
                if (textBox1.Text.Length >= textBox1.MaxLength)
                    textBox1.Text = "";
                textBox1.AppendText(str);
            }));


        }

        //*****************************************************
        //16进制转化为字符串函数
        //*****************************************************
        public int HexToStr(string hex, byte[] str)//将16进制字符串转换放到BYTE数组里，并返回转换后的数据长度，参数是16进制字符串和字                                            节数组
        {
            int asc = 0;
            int len = 0;
            string s = "";
            string ss = "";
            for (int i = 0; i < hex.Length; i++)
            {
                if (hex[i] != ' ')
                {
                    s = s + hex[i];
                    asc = (byte)hex[i];
                    if ((asc < 48) || ((asc > 57) && (asc < 65)) || ((asc > 70) && (asc < 97)) || (asc > 102))
                    {
                        MessageBox.Show("字符串中有字超过16进制范围！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                }

            }
            for (int j = 0; j < (s.Length - 1); j = j + 2)
            {
                ss = "";
                ss = ss + s[j] + s[j + 1];
                str[len] = (byte)(System.Convert.ToInt32(ss, 16));
                len++;
            }
            return len;
        }

        //****************************************************************
        //字符串转化为16进制函数
        //****************************************************************
        public string StrToHex(byte[] str, int len)//将BYTE数组里的数据转换为16进制，参数是BYTE数组，和数组里的数据长度
        {
            string hex = "";
            string s;
            int asc;
            for (int i = 0; i < len; i++)
            {
                s = "";
                asc = str[i];
                //hex = hex + System.Convert.ToString(asc,16);
                s = System.Convert.ToString(asc, 16);
                for (int j = 0; j < s.Length; j++)
                {
                    if (s.Length == 1)
                        hex = hex + '0';
                    if (s[j] == 'a')
                        hex = hex + 'A';
                    else if (s[j] == 'b')
                        hex = hex + 'B';
                    else if (s[j] == 'c')
                        hex = hex + 'C';
                    else if (s[j] == 'd')
                        hex = hex + 'D';
                    else if (s[j] == 'e')
                        hex = hex + 'E';
                    else if (s[j] == 'f')
                        hex = hex + 'F';
                    else
                        hex = hex + s[j];
                }
                if (i < (len - 1))
                    hex = hex + " ";
            }
            return hex;
        }
        //工具条响应函数，使菜单和工具条上按钮功能对应
        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.ImageIndex)
            {
                case 0:
                    menuItem5.PerformClick();
                    break;
                case 1:
                    menuItem6.PerformClick();
                    break;
                case 2:
                    menuItem7.PerformClick();
                    break;
                case 3:
                    menuItem8.PerformClick();
                    break;
                case 4:
                    menuItem11.PerformClick();
                    break;
                case 5:
                    menuItem12.PerformClick();
                    break;
                case 6:
                    this.Close();
                    break;
                case 7:
                    menuItem4.PerformClick();
                    break;
                default:
                    break;
            }

        }

        //**********************************
        //启动服务
        //**********************************
        private void menuItem5_Click(object sender, System.EventArgs e)
        {
            sign = 9999;
            SetCustomIP(inet_addr(serv_ip));
            SetWorkMode(serv_mode);//开发包函数，设置服务模式：2-消息，0-阻塞，1-非阻塞
            SelectProtocol(serv_type);//开发包函数，设置服务类型：0-UDP，1-TCP
            StringBuilder mess = new StringBuilder(1000);
            if (serv_mode == 2)
                sign = start_net_service(this.Handle, WM_DTU, serv_port, mess);//开发包函数，消息模式启动服务
            else
            {
                sign = start_net_service(this.Handle, 0, serv_port, mess);//开发包函数，非消息模式启动服务
                timer3.Interval = 100;
                timer3.Enabled = true;//启动非消息模式下数据读取和处理定时器
            }
            if (serv_mode == 0)
            {
                timer3.Enabled = false;
                threadrun = true;
                recvdata = false;
                TaskFactory taskFactory = new TaskFactory();//创建新的阻塞模式下读取数据线程
                taskFactory.StartNew(() => this.pressdata());//启动阻塞模式下读取数据线程

                //thread = new Thread(new ThreadStart(pressdata));//创建新的阻塞模式下读取数据线程
                //thread.Start(); //启动阻塞模式下读取数据线程
            }
            if (serv_mode == 1)
            {
                threadrun = true;//控制线程
                recvdata = false;// 接收数据
                TaskFactory taskFactory = new TaskFactory();//创建新的阻塞模式下读取数据线程
                taskFactory.StartNew(() => this.pressdata());//启动阻塞模式下读取数据线程

                //thread = new Thread(new ThreadStart(pressdata));//创建新的阻塞模式下读取数据线程
                //thread.Start();
            }
            if (sign == 0)
            {
                //服务启动后，主窗口设置
                timer2.Interval = refresh_time * 1000;
                timer2.Enabled = true;
                serv_start = 1;
                menuItem5.Enabled = false;
                menuItem6.Enabled = true;
                menuItem7.Enabled = true;
                menuItem12.Enabled = true;
                menuItem9.Enabled = true;
                menuItem13.Enabled = true;


                //toolBarButton1.Enabled = false;
                //toolBarButton2.Enabled = true;
                //toolBarButton3.Enabled = true;
                //toolBarButton8.Enabled = true;
                statusBar1.Panels[1].Text = "服务启动";
                if (serv_type == 0)
                {
                    if (serv_mode == 0) AddText("UDP:阻塞模式" + "\r\n");
                    else if (serv_mode == 1) AddText("UDP:非阻塞模式" + "\r\n");
                    else if (serv_mode == 2) AddText("UDP:消息模式" + "\r\n");
                }
                else if (serv_type == 1)
                {
                    if (serv_mode == 0) AddText("TCP:阻塞模式" + "\r\n");
                    else if (serv_mode == 1) AddText("TCP:非阻塞模式" + "\r\n");
                    else if (serv_mode == 2) AddText("TCP:消息模式" + "\r\n");
                }
            }
            else
                serv_start = 0;
            AddText(mess.ToString() + "\n");
        }

        //*********************************
        //停止服务
        //*********************************
        private void menuItem6_Click(object sender, System.EventArgs e)
        {
            StringBuilder mess = new StringBuilder(1000);
            //停止服务
            do_close_all_user2(mess);//开发包函数，使所有DTU下线
            timer2.Enabled = false;
            if (serv_mode != 2)
                timer3.Enabled = false;
            if (serv_mode == 0)
            {
                cancel_read_block();//阻塞模式下取消阻塞读取
                threadrun = false;//退出线程处理函数
                thread.Abort();//终止线程
            }
            if (stop_net_service(mess) == 0)//开发包函数，停止服务
            {
                //界面处理
                serv_start = 0;
                RefreshList();
                menuItem5.Enabled = true;
                menuItem6.Enabled = false;
                menuItem7.Enabled = false;
                menuItem12.Enabled = false;
                //toolBarButton1.Enabled = true;
                //toolBarButton2.Enabled = false;
                //toolBarButton3.Enabled = false;
                //toolBarButton8.Enabled = false;
                statusBar1.Panels[1].Text = "服务停止";
            }
            AddText("\n" + mess.ToString());
        }

        //*************************************
        //服务参数配置菜单响应函数
        //*************************************
        private void menuItem11_Click(object sender, System.EventArgs e)
        {
            if (serv_start == 0)
            {
                addIP(serviceinfo.comboBox1);
                serviceinfo.comboBox1.SelectedIndex = 0;
                serviceinfo.comboBox2.Text = connect_time.ToString();
                serviceinfo.comboBox3.Text = refresh_time.ToString();
                serviceinfo.textBox1.Text = serv_port.ToString();
                if (serv_type == 0)
                    serviceinfo.radioButton2.Checked = true;
                else if (serv_type == 1)
                    serviceinfo.radioButton1.Checked = true;
                if (serv_mode == 0)
                    serviceinfo.radioButton4.Checked = true;
                else if (serv_mode == 1)
                    serviceinfo.radioButton5.Checked = true;
                else if (serv_type == 2)
                    serviceinfo.radioButton3.Checked = true;
                if (serviceinfo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    serv_ip = serviceinfo.comboBox1.Text;
                    connect_time = int.Parse(serviceinfo.comboBox2.Text);
                    refresh_time = int.Parse(serviceinfo.comboBox3.Text);
                    serv_port = int.Parse(serviceinfo.textBox1.Text);
                    if (serviceinfo.radioButton2.Checked)
                        serv_type = 0;
                    else if (serviceinfo.radioButton1.Checked)
                        serv_type = 1;
                    if (serviceinfo.radioButton4.Checked)
                        serv_mode = 0;
                    else if (serviceinfo.radioButton5.Checked)
                        serv_mode = 1;
                    else if (serviceinfo.radioButton3.Checked)
                        serv_mode = 2;
                }
            }
            if (serv_start == 1)
            {
                MessageBox.Show("请先关闭服务!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //********************************************************
        //阻塞模式下线程处理函数
        //********************************************************
        protected void pressdata()
        {
            int i;
            GPRS_DATA_RECORD recdPtr = new GPRS_DATA_RECORD();
            StringBuilder mess = new StringBuilder(100);
            GPRS_USER_INFO user_info = new GPRS_USER_INFO();
            ushort usPort;

            //读取DTU数据				
            while (threadrun)
            {
                if (recvdata)
                    continue;
                if (threadrun == false)
                    break;
                if (do_read_proc(ref recdPtr, mess, checkBox2.Checked) >= 0)
                {
                    //byte a = recdPtr.m_data_type;
                    //RefreshList();
                    recvdata = true;
                    try
                    {


                        switch (recdPtr.m_data_type)
                        {
                            case 0x01:  //注册包
                                if (get_user_info(recdPtr.m_userid, ref user_info) == 0)//开发包函数，通过ID获取DTU信息
                                {
                                    //System.Console.WriteLine($"阻塞模式下线程处理函数 线程：{Thread.CurrentThread.ManagedThreadId.ToString()}");
                                    //已经注册过	
                                    AddText("\n" + recdPtr.m_userid + "（注册）" + "\r\n");
                                    //for (i = 0; i < listView1.Items.Count; i++)
                                    //    this.Invoke(new EventHandler(delegate
                                    //    {
                                    //        Console.WriteLine($"listView1.Items[i]:{i}次 {user_info.m_userid}");
                                    //        if (listView1.Items[i].Text == user_info.m_userid)

                                    //        {
                                    //            
                                    //            listView1.Items[i].SubItems.Add(user_info.m_logon_date);
                                    //            listView1.Items[i].SubItems.Add(user_info.m_update_time.ToString());
                                    //            listView1.Items[i].SubItems.Add(inet_ntoa(ntohl(user_info.m_sin_addr)));
                                    //            usPort = user_info.m_sin_port;
                                    //            listView1.Items[i].SubItems.Add(usPort.ToString());
                                    //            listView1.Items[i].SubItems.Add(inet_ntoa(ntohl(user_info.m_local_addr)));
                                    //            usPort = user_info.m_local_port;
                                    //            listView1.Items[i].SubItems.Add(usPort.ToString());
                                    //        }
                                    //    }));

                                    //没有注册过
                                }
                                RefreshList();
                                break;
                            case 0x02:  //注销包
                                AddText("\n" + recdPtr.m_userid + "（注销）" + "\r\n");
                                for (i = 0; i < listView1.Items.Count; i++)
                                    if (listView1.Items[i].Text == recdPtr.m_userid)
                                    {
                                        listView1.Items[i].Remove();
                                        break;
                                    }
                                break;
                            case 0x04:  //无效包
                                break;
                            case 0x09:  //数据包
                                if (checkBox1.Checked)
                                    AddText("\r\n终端号码" + recdPtr.m_userid + " 接收时间" + recdPtr.m_recv_date + " 接收长度" + recdPtr.m_data_len.ToString() + "\r\n"
                                        + StrToHex(recdPtr.m_data_buf, recdPtr.m_data_len) + "\r\n");
                                else
                                    AddText("\r\n终端号码" + recdPtr.m_userid + " 接收时间" + recdPtr.m_recv_date + " 接收长度" + recdPtr.m_data_len.ToString() + "\r\n"
                                        + System.Text.Encoding.Default.GetString(recdPtr.m_data_buf) + "\r\n");
                                break;
                            case 0x0d:
                                AddText("\n" + recdPtr.m_userid + "（参数设置成功）" + "\r\n");
                                config.timer3.Enabled = false;
                                config.button2.Enabled = true;
                                MessageBox.Show("参数设置成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case 0x0b:
                                AddText("\n" + recdPtr.m_userid + "（参数查询成功）" + "\r\n");
                                config.readconf();
                                config.timer2.Enabled = false;
                                config.button1.Enabled = true;
                                MessageBox.Show("参数查询成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case 0x06:
                                AddText("\n" + recdPtr.m_userid + "（断开PPP连接成功）" + "\r\n");
                                break;
                            case 0x07:
                                AddText("\n" + recdPtr.m_userid + "（停止向DSC发送数据）" + "\r\n");
                                break;
                            case 0x08:
                                AddText("\n" + recdPtr.m_userid + "（允许向DSC发送数据）" + "\r\n");
                                break;
                            case 0x0A:
                                AddText("\n" + recdPtr.m_userid + "（丢弃用户数据）" + "\r\n");
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {

                        AddText("\n" + ex + "（错误）" + "\r\n");
                    }
                    recvdata = false;
                }
            }
            //	thread.Abort();
        }

        //*******************************************
        //消息模式时定义消息的响应函数
        //*******************************************
        protected override void WndProc(ref Message m)
        {
            int i;

            //响应DTU消息
            if (m.Msg == WM_DTU)
            {
                GPRS_DATA_RECORD recdPtr = new GPRS_DATA_RECORD();
                StringBuilder mess = new StringBuilder(100);

                //开发包函数，读取DTU数据				
                if (do_read_proc(ref recdPtr, mess, checkBox2.Checked) >= 0)
                {
                    byte a = recdPtr.m_data_type;
                    //RefreshList();
                    switch (recdPtr.m_data_type)
                    {
                        case 0x01:  //注册包												
                            GPRS_USER_INFO user_info = new GPRS_USER_INFO();
                            ushort usPort;
                            if (get_user_info(recdPtr.m_userid, ref user_info) == 0)//开发包函数，通过ID获取DTU信息
                            {
                                //已经注册过	
                                AddText("\n" + recdPtr.m_userid + "（注册）" + "\r\n");
                                //	RefreshList();//刷新终端登陆列表
                            }
                            break;
                        case 0x02:  //注销包
                            AddText("\n" + recdPtr.m_userid + "（注销）" + "\r\n");
                            //收到的是注销包，从终端登陆列表中删除该DTU信息
                            for (i = 0; i < listView1.Items.Count; i++)
                                if (listView1.Items[i].Text == recdPtr.m_userid)
                                {
                                    listView1.Items[i].Remove();
                                    break;
                                }
                            break;
                        case 0x04:  //无效包
                            break;
                        case 0x09:  //数据包
                                    //16进制显示收到的数据
                            if (checkBox1.Checked)

                                AddText("\r\n终端号码" + recdPtr.m_userid + " 接收时间" + recdPtr.m_recv_date + " 接收长度" + recdPtr.m_data_len.ToString() + "\r\n"
                                    + StrToHex(recdPtr.m_data_buf, recdPtr.m_data_len) + "\r\n");
                            else
                                //显示数据
                                AddText("\r\n终端号码" + recdPtr.m_userid + " 接收时间" + recdPtr.m_recv_date + " 接收长度" + recdPtr.m_data_len.ToString() + "\r\n"
                                    + System.Text.Encoding.Default.GetString(recdPtr.m_data_buf) + "\r\n");
                            break;
                        case 0x0d:
                            //收到参数设置成功数据包，取消参数设置超时定时器
                            AddText("\n" + recdPtr.m_userid + "（参数设置成功）" + "\r\n");
                            config.timer3.Enabled = false;
                            config.button2.Enabled = true;
                            MessageBox.Show("参数设置成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 0x0b:
                            //收到查询参数数据包，取消参数查询超时定时器，并读取各项参数到DEMO
                            AddText("\n" + recdPtr.m_userid + "（参数查询成功）" + "\r\n");
                            config.readconf();//读取各项参数
                            config.timer2.Enabled = false;
                            config.button1.Enabled = true;
                            MessageBox.Show("参数查询成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 0x06:
                            AddText("\n" + recdPtr.m_userid + "（断开PPP连接成功）" + "\r\n");
                            break;
                        case 0x07:
                            AddText("\n" + recdPtr.m_userid + "（停止向DSC发送数据）" + "\r\n");
                            break;
                        case 0x08:
                            AddText("\n" + recdPtr.m_userid + "（允许向DSC发送数据）" + "\r\n");
                            break;
                        case 0x0A:
                            AddText("\n" + recdPtr.m_userid + "（丢弃用户数据）" + "\r\n");
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                //缺省消息处理
                base.WndProc(ref m);
            }
        }

        //************************************
        //刷新终端登陆列表
        //************************************
        public void RefreshList()
        {
            uint i, iDtuAmount;
            string str = "";
            long t_update, t_now;
            StringBuilder mess = new StringBuilder(1000);
            GPRS_USER_INFO user_info = new GPRS_USER_INFO();
            this.Invoke(new EventHandler(delegate
            {
                listView1.Items.Clear();//清空终端登陆列表
            }));

            str = str + 0x00 + 0x00 + 0x00;
            iDtuAmount = get_max_user_amount();//开发包函数，返回中心最大连接DTU数量
            for (i = 0; i < iDtuAmount; i++)
            {
                get_user_at(i, ref user_info);//开发包函数，通过DTU顺序号获取DTU信息
                if (user_info.m_status == 1)
                {
                    t_update = (long)(user_info.m_update_time[0])
                                + (long)(user_info.m_update_time[1]) * 256
                                + (long)(user_info.m_update_time[2]) * 256 * 256
                                + (long)(user_info.m_update_time[3]) * 256 * 256 * 256
                                + 3600 * 8;
                    t_now = (long)Math.Round((DateTime.Now.ToOADate() - 25569) * 3600 * 24);
                    if ((t_now - t_update) > connect_time * 60)//判断DTU最后注册时间与现在时间的差值是否超过设置的超时时间
                    {                                       //若超时则认为该DTU不在线，调用开发包函数使其下线
                        do_close_one_user2(user_info.m_userid, mess);//开发包函数，使某个DTU下线并发下线指令
                        continue;
                    }
                    if (!checkBox3.Checked)
                    {
                        ListInsert(user_info, t_update);
                    }

                }
            }
        }

        //***************************************
        //终端登陆列表中添加项
        //***************************************
        public void ListInsert(GPRS_USER_INFO user_info, long a)
        {
            double m_update;
            m_update = (a * 10000000) / (3600 * 24);
            m_update = m_update / 10000000 + 25569;
            this.Invoke(new EventHandler(delegate
            {
                ListViewItem list = listView1.Items.Add(user_info.m_userid);
                list.SubItems.Add(user_info.m_logon_date);
                list.SubItems.Add(DateTime.FromOADate(m_update).ToString());
                list.SubItems.Add(inet_ntoa(ntohl(user_info.m_sin_addr)));
                list.SubItems.Add(user_info.m_sin_port.ToString());
                list.SubItems.Add(inet_ntoa(ntohl(user_info.m_local_addr)));
                list.SubItems.Add(user_info.m_local_port.ToString());
            }));



        }

        //****************************************
        //远程参数配置菜单响应函数
        //****************************************
        private void menuItem12_Click(object sender, System.EventArgs e)
        {
            {
                ////旧版本
                //uint i, iDtuAmount;
                //GPRS_USER_INFO user_info = new GPRS_USER_INFO();
                //config = new Form3();
                //iDtuAmount = get_max_user_amount();
                //for (i = 0; i < iDtuAmount; i++)
                //{
                //    get_user_at(i, ref user_info);//开发包函数，通过DTU顺序号获得DTU信息
                //    if (user_info.m_status == 1)//在线
                //    {
                //        //向列表框添加ID号
                //        config.comboBox8.Items.Add(user_info.m_userid);
                //    }
                //}
                //config.ShowDialog();
            }
            {
                try
                {
                    InvokeParamUI(this.Handle);
                }
                catch (Exception ex)
                {
                    AddText("\n" + ex + "（错误）" + "\r\n");
                }
            }
        }

        //*************************************
        //保存服务参数到配置文件Sysconfig.ini
        //*************************************
        private void Form1_Closed(object sender, System.EventArgs e)
        {
            //保存各项参数到配置文件Sysconfig.ini
            string path = System.IO.Directory.GetCurrentDirectory();
            path = path + "\\Sysconfig.ini";
            IniFile ini = new IniFile(path);
            ini.IniWriteValue("Section", "serv_ip", serv_ip);
            ini.IniWriteValue("Section", "connect_time", connect_time.ToString());
            ini.IniWriteValue("Section", "refresh_time", refresh_time.ToString());
            ini.IniWriteValue("Section", "serv_port", serv_port.ToString());
            ini.IniWriteValue("Section", "serv_type", serv_type.ToString());
            ini.IniWriteValue("Section", "serv_mode", serv_mode.ToString());
        }

        //********************************************
        //退出
        //********************************************
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StringBuilder mess = new StringBuilder(500);
            if (MessageBox.Show("确定退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                //如果服务正在启动，调用开发包函数使所有DTU下线并关闭服务
                if (serv_start == 1)
                {
                    menuItem6.PerformClick();
                }
                e.Cancel = false;
            }
            else
                e.Cancel = true;
        }

        //***************************************************
        //加载窗体时读取服务参数配置文件到各服务参数变量
        //***************************************************
        private void Form1_Load(object sender, System.EventArgs e)
        {
            //从配置文件Sysconfig.ini读取各项参数到服务参数变量
            //thread = new Thread(new ThreadStart( pressdata ));
            serv_start = 0;
            string path = System.IO.Directory.GetCurrentDirectory();
            path = path + "\\Sysconfig.ini";
            IniFile ini = new IniFile(path);
            serv_ip = ini.IniReadValue("Section", "serv_ip", "127.0.0.1");
            connect_time = int.Parse(ini.IniReadValue("Section", "connect_time", "30"));
            refresh_time = int.Parse(ini.IniReadValue("Section", "refresh_time", "3"));
            serv_port = int.Parse(ini.IniReadValue("Section", "serv_port", "5002"));
            serv_type = int.Parse(ini.IniReadValue("Section", "serv_type", "0"));
            serv_mode = int.Parse(ini.IniReadValue("Section", "serv_mode", "2"));
        }

        //*********************************************
        //发送数据
        //*********************************************
        private void button1_Click(object sender, System.EventArgs e)
        {
            string str;
            string msg;
            int len;
            StringBuilder mess = new StringBuilder(500);
            string s = new string((char)0, 1024);                   //分配1024字									节长度的字符串数组
            byte[] bc = System.Text.Encoding.Default.GetBytes(s);   //转换到字节数组
                                                                    //判断发送终端ID是否正确，判断发送内容是否为空
            if ((textBox2.TextLength == 11) && textBox3.Text != "")
            {
                bc = System.Text.Encoding.Default.GetBytes(textBox3.Text.ToCharArray(0, textBox3.TextLength), 0, textBox3.TextLength);
                if (radioButton2.Checked)
                {
                    //16进制发送数据
                    len = HexToStr(textBox3.Text, bc);
                    //str = System.Text.Encoding.Default.GetString(bc, 0, len);	//将该字节数组转换到字符串进行传送
                    if (len > 0)
                        if (do_send_user_data(textBox2.Text, bc, len, mess) == 0)//开发包函数，发送数据到DTU
                        {
                            msg = "\n向 ";
                            msg = msg + textBox2.Text + " 16进制发送数据:" + textBox3.Text + "\r\n";
                            AddText(msg);
                        }
                }
                else if (do_send_user_data(textBox2.Text, bc, textBox3.TextLength, mess) == 0)
                {
                    msg = "\n向 ";
                    msg = msg + textBox2.Text + " 发送数据:" + textBox3.Text + "\r\n";
                    AddText(msg);
                }
            }
            else
                MessageBox.Show("没有选择DTU或发送内容为空！", "发送信息错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //**********************************
        //定时发送数据定时器
        //**********************************
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            //System.Console.WriteLine($"定时发送数据定时器 线程：{Thread.CurrentThread.ManagedThreadId.ToString()}");
            StringBuilder mess = new StringBuilder(500);
            string str;
            string msg;
            int len;
            string s = new string((char)0, 1024);                   //分配1024字									节长度的字符串数组
            byte[] bc = System.Text.Encoding.Default.GetBytes(s);   //转换到字节数组
            if ((textBox2.TextLength == 11) && textBox3.Text != "")
            {
                bc = System.Text.Encoding.Default.GetBytes(textBox3.Text.ToCharArray(0, textBox3.TextLength), 0, textBox3.TextLength);
                if (radioButton2.Checked)
                {
                    len = HexToStr(textBox3.Text, bc);
                    str = System.Text.Encoding.Default.GetString(bc, 0, len);   //将该字节数组转换到字符串进行传送
                    if (len > 0)
                        if (do_send_user_data(textBox2.Text, bc, len, mess) == 0)//开发包函数，发送数据到DTU
                        {
                            msg = "\n向 ";
                            msg = msg + textBox2.Text + " 16进制发送数据:" + textBox3.Text + "\r\n";
                            AddText(msg);
                        }
                }
                else if (do_send_user_data(textBox2.Text, bc, textBox3.TextLength, mess) == 0)
                {
                    msg = "\n向 ";
                    msg = msg + textBox2.Text + " 发送数据:" + textBox3.Text + "\r\n";
                    AddText(msg);
                }
            }
            else
                MessageBox.Show("没有选择DTU或发送内容为空！", "发送信息错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //*********************************
        //定时发送数据
        //*********************************
        private void button2_Click(object sender, System.EventArgs e)
        {
            if ((textBox2.TextLength == 11) && textBox3.Text != "")
            {
                if (button2.Text == "定时发送")
                {
                    //启动定时发送定时器并改控件标题为“停止发送”
                    button2.Text = "停止发送";
                    timer1.Interval = int.Parse(comboBox1.Text);
                    timer1.Enabled = true;
                    comboBox1.Enabled = false;
                    button1.Enabled = false;
                }
                else if (button2.Text == "停止发送")
                {
                    //取消定时发送定时器并改控件标题为“定时发送”
                    timer1.Enabled = false;
                    button2.Text = "定时发送";
                    comboBox1.Enabled = true;
                    button1.Enabled = true;
                }
            }
            else
                MessageBox.Show("没有选择DTU或发送内容为空！", "定时发送错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //********************************************
        //终端登陆列表单击响应函数
        //********************************************
        private void listView1_Click(object sender, System.EventArgs e)
        {
            //单击DTU用户列表项将DTU ID号映射到编辑框
            if (listView1.SelectedItems.Count == 0)
                textBox2.Text = "";
            else
                textBox2.Text = listView1.SelectedItems[0].Text;
            if (textBox2.Text != "")
            {
                button2.Enabled = true;
                button1.Enabled = true;
            }
        }

        //*****************************************
        //定时刷新终端登陆列表
        //*****************************************
        private void timer2_Tick(object sender, System.EventArgs e)
        {
            RefreshList();
        }

        //*****************************************
        //分离终端菜单响应函数
        //*****************************************
        private void menuItem7_Click(object sender, System.EventArgs e)
        {
            StringBuilder mess = new StringBuilder(500);
            if (textBox2.Text.Length == 11)
            {
                if (MessageBox.Show("确定使该DTU下线？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    if (do_close_one_user2(textBox2.Text, mess) == 0)//开发包函数，使某个DTU下线并发下线指令
                    {
                        RefreshList();//刷新终端登陆列表
                    }
            }
            else
                MessageBox.Show("请选择DTU！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //**************************************
        //清空运行信息框
        //**************************************
        private void menuItem8_Click(object sender, System.EventArgs e)
        {
            textBox1.Text = "";
        }
        private void DataProcessing()
        {

            //System.Console.WriteLine($"非阻塞模式下数据处理定时器 线程：{Thread.CurrentThread.ManagedThreadId.ToString()}");
            int i;
            GPRS_DATA_RECORD recdPtr = new GPRS_DATA_RECORD();
            StringBuilder mess = new StringBuilder(100);

            //读取DTU数据		
            if (serv_mode == 1)
            {
                if (do_read_proc(ref recdPtr, mess, checkBox2.Checked) >= 0)
                {
                    try
                    {

                        byte a = recdPtr.m_data_type;
                        //RefreshList();
                        switch (recdPtr.m_data_type)
                        {
                            case 0x01:  //注册包												
                                GPRS_USER_INFO user_info = new GPRS_USER_INFO();
                                ushort usPort;
                                if (get_user_info(recdPtr.m_userid, ref user_info) == 0)
                                {
                                    //已经注册过	
                                    AddText("\n" + recdPtr.m_userid + "（注册）" + "\r\n");
                                    //for (i = 0; i < listView1.Items.Count; i++)
                                    //    this.Invoke(new EventHandler(delegate
                                    // {
                                    //     if (listView1.Items[i].Text == user_info.m_userid)
                                    //     {
                                    //         listView1.Items[i].SubItems.Add(user_info.m_logon_date);
                                    //         listView1.Items[i].SubItems.Add(user_info.m_update_time.ToString());
                                    //         listView1.Items[i].SubItems.Add(inet_ntoa(ntohl(user_info.m_sin_addr)));
                                    //         usPort = user_info.m_sin_port;
                                    //         listView1.Items[i].SubItems.Add(usPort.ToString());
                                    //         listView1.Items[i].SubItems.Add(inet_ntoa(ntohl(user_info.m_local_addr)));
                                    //         usPort = user_info.m_local_port;
                                    //         listView1.Items[i].SubItems.Add(usPort.ToString());
                                    //         return;
                                    //     }
                                    // }));
                                    //没有注册过
                                }
                                RefreshList();
                                break;
                            case 0x02:  //注销包
                                AddText("\n" + recdPtr.m_userid + "（注销）" + "\r\n");
                                for (i = 0; i < listView1.Items.Count; i++)
                                    if (listView1.Items[i].Text == recdPtr.m_userid)
                                    {
                                        listView1.Items[i].Remove();
                                        break;
                                    }
                                break;
                            case 0x04:  //无效包
                                break;
                            case 0x09:  //数据包
                                if (checkBox1.Checked)

                                    AddText("\r\n终端号码" + recdPtr.m_userid + " 接收时间" + recdPtr.m_recv_date + " 接收长度" + recdPtr.m_data_len.ToString() + "\r\n"
                                        + StrToHex(recdPtr.m_data_buf, recdPtr.m_data_len) + "\r\n");
                                else
                                    AddText("\r\n终端号码" + recdPtr.m_userid + " 接收时间" + recdPtr.m_recv_date + " 接收长度" + recdPtr.m_data_len.ToString() + "\r\n"
                                        + System.Text.Encoding.Default.GetString(recdPtr.m_data_buf) + "\r\n");
                                break;
                            case 0x0d:
                                AddText("\n" + recdPtr.m_userid + "（参数设置成功）" + "\r\n");
                                config.timer3.Enabled = false;
                                config.button2.Enabled = true;
                                MessageBox.Show("参数设置成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case 0x0b:
                                AddText("\n" + recdPtr.m_userid + "（参数查询成功）" + "\r\n");
                                config.readconf();
                                config.timer2.Enabled = false;
                                config.button1.Enabled = true;
                                MessageBox.Show("参数查询成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case 0x06:
                                AddText("\n" + recdPtr.m_userid + "（断开PPP连接成功）" + "\r\n");
                                break;
                            case 0x07:
                                AddText("\n" + recdPtr.m_userid + "（停止向DSC发送数据）" + "\r\n");
                                break;
                            case 0x08:
                                AddText("\n" + recdPtr.m_userid + "（允许向DSC发送数据）" + "\r\n");
                                break;
                            case 0x0A:
                                AddText("\n" + recdPtr.m_userid + "（丢弃用户数据）" + "\r\n");
                                break;
                            default:
                                break;
                        }

                    }
                    catch (Exception ex)
                    {

                        AddText("\n" + ex + "（错误）" + "\r\n");
                    }
                }
            }
        }

        //************************************************
        //非阻塞模式下数据处理定时器
        //************************************************
        private void timer3_Tick(object sender, System.EventArgs e)
        {
            TaskFactory taskFactory = new TaskFactory();
            taskFactory.StartNew(() => this.DataProcessing());
        }

        //***************************************
        //关于对话框菜单响应函数
        //***************************************
        private void menuItem4_Click(object sender, System.EventArgs e)
        {
            FormDTUAbout aboutbox = new FormDTUAbout();
            aboutbox.ShowDialog();
        }
        //退出
        private void menuItem10_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            try
            {
                InvokeLogUI(this.Handle);
            }
            catch (Exception ex)
            {
                AddText("\n" + ex + "（错误）" + "\r\n");
            }
        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            try
            {
                InvokeUpdateUI(this.Handle);
            }
            catch (Exception ex)
            {
                AddText("\n" + ex + "（错误）" + "\r\n");
            }
        }
    }
    /// <summary>
    /// IniFile 的摘要说明。
    /// </summary>

    //*********************************************
    //ini文件操作类，调用该类中函数操作配置文件，
    //用来保存和读取服务参数
    //*********************************************
    public class IniFile
    {
        public string inipath;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        /// <summary> 
        /// 构造方法 
        /// </summary> 
        /// <param name="INIPath">文件路径</param> 
        public IniFile(string INIPath)
        {
            inipath = INIPath;
        }
        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        /// <param name="Value">值</param> 
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.inipath);
        }
        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="Section">项目名称(如 [TypeName] )</param> 
        /// <param name="Key">键</param> 
        public string IniReadValue(string Section, string Key, string Value)
        {
            StringBuilder temp = new StringBuilder(500);
            int i = GetPrivateProfileString(Section, Key, "", temp, 500, this.inipath);
            if (i == 0)
                return Value;
            else
                return temp.ToString();
        }
        /// <summary> 
        /// 验证文件是否存在 
        /// </summary> 
        /// <returns>布尔值</returns> 
        public bool ExistINIFile()
        {
            return File.Exists(inipath);
        }
    }
}
