﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace CommunicationDemo
{
    public partial class FormTcpDebug : Form
    {
        public FormTcpDebug()
        {
            InitializeComponent();
        }

        private void FormTcpDebug_Load(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            //timer = new Timer();
            //timer.Interval = 200;
            //timer.Tick += Timer_Tick;
            //timer.Start();

            Language(Program.Language);
        }

        private void Language(int language)
        {
            if (language == 1)
            {
                Text = "TCP Client";
                label1.Text = "IP：";
                label3.Text = "端口号：";
                button1.Text = "连接";
                button2.Text = "关闭连接";
                label6.Text = "数据发送区：";
                checkBox1.Text = "是否使用二进制通信";
                label7.Text = "数据接收区：";
                checkBox3.Text = "是否显示发送数据";
                checkBox4.Text = "是否显示时间";
                button3.Text = "发送数据";
            }
            else
            {
                Text = "TCP Client";
                label1.Text = "IP：";
                label3.Text = "Port:";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                label6.Text = "Data sending Area:";
                checkBox1.Text = "Whether to use binary communication";
                label7.Text = "Data receiving Area:";
                checkBox3.Text = "Whether to display send data";
                checkBox4.Text = "Whether to show time";
                button3.Text = "Send Data";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                string select = textBox6.SelectedText;
                if (!string.IsNullOrEmpty(select))
                {
                    if (checkBox1.Checked)
                    {
                        // 二进制
                        byte[] bytes = Communication.BasicFramework.SoftBasic.HexStringToBytes(select);
                        //label8.Text = Program.Language == 1? "已选择数据字节数：" : "Number of data bytes selected:" + bytes.Length;
                    }
                    else
                    {
                        //label8.Text = Program.Language == 1 ? "已选择数据字节数：" : "Number of data bytes selected:" + select.Length;
                    }
                }
            }
        }
        /// <summary>
        /// 核心套接字
        /// </summary>
        private Socket socketCore = null;
        /// <summary>
        /// 连接成功
        /// </summary>
        private bool connectSuccess = false;
        /// <summary>
        /// 缓冲区
        /// </summary>
        private byte[] buffer = new byte[2048];
        //private Timer timer;

        private void button1_Click(object sender, EventArgs e)
        {
            // 连接服务器
            try
            {
                socketCore?.Close();
                socketCore = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                connectSuccess = false;
                new System.Threading.Thread(() =>
               {
                   System.Threading.Thread.Sleep(2000);
                   if (!connectSuccess) socketCore?.Close();
               }).Start();
                socketCore.Connect(System.Net.IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
                connectSuccess = true;

                socketCore.BeginReceive(buffer, 0, 2048, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socketCore);
                button1.Enabled = false;
                button2.Enabled = true;
                panel2.Enabled = true;

                MessageBox.Show(Communication.StringResources.Language.ConnectServerSuccess);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Communication.StringResources.Language.ConnectedFailed + Environment.NewLine + ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            socketCore?.Close();
            button1.Enabled = true;
            button2.Enabled = false;
            panel2.Enabled = false;
        }

        /// <summary>
        /// 收到返回数据
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                int length = socketCore.EndReceive(ar);
                socketCore.BeginReceive(buffer, 0, 2048, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socketCore);

                if (length == 0) return;

                byte[] data = new byte[length];
                Array.Copy(buffer, 0, data, 0, length);
                Invoke(new Action(() =>
              {
                  string msg = string.Empty;
                  if (checkBox1.Checked)
                  {
                      msg = Communication.BasicFramework.SoftBasic.ByteToHexString(data, ' ');
                  }
                  else
                  {
                      msg = Encoding.ASCII.GetString(data);
                  }


                  if (checkBox4.Checked)
                  {
                      textBox6.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + (Program.Language == 1 ? "][接收]   " : "][R]   ") + msg + Environment.NewLine);
                  }
                  else
                  {
                      textBox6.AppendText((Program.Language == 1 ? "][接收]   " : "][R]   ") + msg + Environment.NewLine);
                  }
              }));
            }
            catch (ObjectDisposedException)
            {

            }
            catch (Exception)
            {
                Invoke(new Action(() =>
              {
                  MessageBox.Show(Program.Language == 1 ? "服务器断开连接。" : "DisConnect from remote");
                  panel2.Enabled = false;
                  button1.Enabled = true;
                  button2.Enabled = false;
              }));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 发送数据
            byte[] send = null;
            if (checkBox1.Checked)
            {
                send = Communication.BasicFramework.SoftBasic.HexStringToBytes(textBox5.Text);
            }
            else
            {
                send = Encoding.ASCII.GetBytes(textBox5.Text.Replace("\\n", "\r\n"));
            }

            if (checkBox2.Checked)
            {
                send = Communication.BasicFramework.SoftBasic.SpliceTwoByteArray(send, new byte[] { 0x0A });
            }

            if (checkBox3.Checked)
            {
                // 显示发送信息
                if (checkBox4.Checked)
                {
                    textBox6.AppendText("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + (Program.Language == 1 ? "][发送]   " : "][S]   ") + Communication.BasicFramework.SoftBasic.ByteToHexString(send, ' ') + Environment.NewLine);
                }
                else
                {
                    textBox6.AppendText((Program.Language == 1 ? "][发送]   " : "][S]   ") + Communication.BasicFramework.SoftBasic.ByteToHexString(send, ' ') + Environment.NewLine);
                }
            }
            try
            {
                socketCore?.Send(send, 0, send.Length, SocketFlags.None);
            }
            catch (Exception ex)
            {
                Communication.BasicFramework.SoftBasic.ShowExceptionMessage(ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = "02 03 01 53 00 20 B5 CC";
        }
    }
}