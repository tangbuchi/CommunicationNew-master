﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication.Profinet;
using System.Threading;
using Communication.Robot.KUKA;
using Communication;

namespace CommunicationDemo
{
    public partial class FormKuka : Form
    {
        public FormKuka( )
        {
            InitializeComponent( );
        }


        private KukaAvarProxyNet melsec_net = null;

        private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            try
            {
                System.Diagnostics.Process.Start( linkLabel1.Text );
            }
            catch (Exception ex) 
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            panel2.Enabled = false;
            
            Language( Program.Language );

            if (!Program.ShowAuthorInfomation)
            {
                label2.Visible = false;
                linkLabel1.Visible = false;
                label20.Visible = false;
            }
        }

        private void Language( int language )
        {
            if (language == 2)
            {
                Text = "Kuka Robot Demo";
                label2.Text = "Blogs:";
                label4.Text = "Protocols:";
                label20.Text = "Author:";
                label5.Text = "KUKAVARPROXY Protocol";

                label1.Text = "Ip:";
                label3.Text = "Port:";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                label21.Text = "Address:";
                label6.Text = "address:";
                label7.Text = "result:";

                button_read_string.Text = "r-string";


                label10.Text = "Address:";
                label9.Text = "Value:";

                button14.Text = "w-string";

                groupBox1.Text = "Single Data Read test";
                groupBox2.Text = "Single Data Write test";
                label22.Text = "Parameter name of robot";
            }
        }

        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {
        }

        /// <summary>
        /// 统一的读取结果的数据解析，显示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="address"></param>
        /// <param name="textBox"></param>
        private void readResultRender<T>( OperateResult<T> result, string address, TextBox textBox )
        {
            if (result.IsSuccess)
            {
                textBox.AppendText( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] {result.Content}{Environment.NewLine}" );
            }
            else
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Read Failed{Environment.NewLine} Reason：{result.ToMessageShowString( )}" );
            }
        }

        /// <summary>
        /// 统一的数据写入的结果显示
        /// </summary>
        /// <param name="result"></param>
        /// <param name="address"></param>
        private void writeResultRender( OperateResult result, string address )
        {
            if (result.IsSuccess)
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Success" );
            }
            else
            {
                MessageBox.Show( DateTime.Now.ToString( "[HH:mm:ss] " ) + $"[{address}] Write Failed{Environment.NewLine} Reason：{result.ToMessageShowString( )}" );
            }
        }


        #region Connect And Close



        private void button1_Click( object sender, EventArgs e )
        {
            // 连接
            if (!System.Net.IPAddress.TryParse( textBox1.Text, out System.Net.IPAddress address ))
            {
                MessageBox.Show( "Ip地址输入不正确！" );
                return;
            }
            
            if(!int.TryParse(textBox2.Text,out int port))
            {
                MessageBox.Show( "端口输入格式不正确！" );
                return;
            }
            
            melsec_net?.ConnectClose( );
            melsec_net = new KukaAvarProxyNet( textBox1.Text, port );
            melsec_net.ConnectClose( );

            try
            {
                OperateResult connect = melsec_net.ConnectServer( );
                if (connect.IsSuccess)
                {
                    MessageBox.Show( "连接成功！" );
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;
                }
                else
                {
                    MessageBox.Show( "连接失败！" );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            melsec_net.ConnectClose( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }







        #endregion

        #region 单数据读取测试
        

        private void button_read_string_Click( object sender, EventArgs e )
        {
            // 读取字符串
            readResultRender( melsec_net.ReadString( textBox3.Text ), textBox3.Text, textBox4 );
        }


        #endregion

        #region 单数据写入测试
        

        private void button14_Click( object sender, EventArgs e )
        {
            // string写入
            try
            {
                writeResultRender( melsec_net.Write( textBox8.Text, textBox7.Text ), textBox8.Text );
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }
        
        #endregion
        
    }
    
}
