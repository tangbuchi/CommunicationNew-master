using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication.Enthernet;
using Communication;

namespace CommunicationDemo
{
    public partial class FormUdp : Form
    {
        public FormUdp()
        {
            InitializeComponent();
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            panel2.Enabled = false;

        }

        private NetUdpClient udpClient = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!System.Net.IPAddress.TryParse(textBox1.Text, out System.Net.IPAddress address))
            {
                MessageBox.Show(DemoUtils.IpAddressInputWrong);
                return;
            }

            //连接
            try
            {
                udpClient = new NetUdpClient(textBox1.Text, int.Parse(textBox2.Text));

                panel2.Enabled = true;
                button1.Enabled = false;
            }
            catch (Exception ex)
            {
                Communication.BasicFramework.SoftBasic.ShowExceptionMessage(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //断开
            try
            {
                udpClient = null;
                panel2.Enabled = false;
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                Communication.BasicFramework.SoftBasic.ShowExceptionMessage(ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 数据发送

            DateTime start = DateTime.Now;

            OperateResult<string> read = udpClient.ReadFromServer(textBox4.Text);

            if (read.IsSuccess)
            {
                textBox8.AppendText(read.Content + Environment.NewLine);
            }
            else
            {
                textBox8.AppendText("Read Failed：" + read.Message + Environment.NewLine);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 清空
            textBox4.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linkLabel1.Text);
            }
            catch (Exception ex)
            {
                Communication.BasicFramework.SoftBasic.ShowExceptionMessage(ex);
            }
        }
    }
}
