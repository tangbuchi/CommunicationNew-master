﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication.Profinet.Siemens;
using CommunicationDemo.Control;

namespace CommunicationDemo
{
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormSiemens form = new FormSiemens(SiemensPLCS.S1200))
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormModbus form = new FormModbus())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormMelsecBinary form = new FormMelsecBinary())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormSiemens form = new FormSiemens(SiemensPLCS.S1500))
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormSiemens form = new FormSiemens(SiemensPLCS.S300))
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormSiemens form = new FormSiemens(SiemensPLCS.S400))
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormSiemens form = new FormSiemens(SiemensPLCS.S200Smart))
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormMelsecAscii form = new FormMelsecAscii())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {
            Communication.BasicFramework.FormSupport form = new Communication.BasicFramework.FormSupport();
            form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormSimplifyNet form = new FormSimplifyNet())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormUdpNet form = new FormUdpNet())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormSiemensFW form = new FormSiemensFW())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormOmron form = new FormOmron())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormFileClient form = new FormFileClient())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormComplexNet form = new FormComplexNet())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormMelsec1EBinary form = new FormMelsec1EBinary())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormLogNet form = new FormLogNet())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormBasicControl form = new FormBasicControl())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormGauge form = new FormGauge())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormCurve form = new FormCurve())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormModbusAlien form = new FormModbusAlien())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void FormLoad_Load(object sender, EventArgs e)
        {
            Communication.BasicFramework.SoftBasic.FrameworkVersion.ToString();

            if (Settings1.Default.language == 1)
            {
                if (System.Globalization.CultureInfo.CurrentCulture.ToString().StartsWith("zh"))
                {
                    Program.Language = 1;
                    Language(Program.Language);
                }
                else
                {
                    Communication.StringResources.SeteLanguageEnglish();
                    Program.Language = 2;
                    Language(Program.Language);
                }
            }
            else
            {
                Program.Language = 2;
                Communication.StringResources.SeteLanguageEnglish();
                Language(Program.Language);
            }
        }

        private void Language(int language)
        {
            if (language == 1)
            {
                button19.Text = "异形 Modbus Tcp";
                button24.Text = "串口调试助手";
                button30.Text = "TCP Client";
                button25.Text = "傅立叶变换";
                button26.Text = "订单号测试";
                button27.Text = "注册码功能";
                button28.Text = "邮件发送";
                button31.Text = "字节变换";
                button29.Text = "异形 Simplify Net";
                button16.Text = "常用简单控件";
                Text = "Communication 测试工具";
            }
            else
            {
                button19.Text = "Alien Modbus Tcp";
                button24.Text = "Serial debug";
                button30.Text = "TCP Client";
                button25.Text = "Fourier transformation";
                button26.Text = "OrderNumbe";
                button27.Text = "Registration";
                button28.Text = "Mail Send";
                button31.Text = "Bytes Transform";
                button29.Text = "Alien Simplify Net";
                button16.Text = "Simple Control";
                Text = "Communication Test Tool";

            }
        }


        private void button20_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormPieChart form = new FormPieChart())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormModbusRtu form = new FormModbusRtu())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormPushNet form = new FormPushNet())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (Robot.FormEfort form = new Robot.FormEfort())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormSerialDebug form = new FormSerialDebug())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (Algorithms.FourierTransform form = new Algorithms.FourierTransform())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormSeqCreate form = new FormSeqCreate())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormRegister form = new FormRegister())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormMail form = new FormMail())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormSimplifyNetAlien form = new FormSimplifyNetAlien())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormTcpDebug form = new FormTcpDebug())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormByteTransfer form = new FormByteTransfer())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormMelsecSerial form = new FormMelsecSerial())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormAllenBrandly form = new FormAllenBrandly())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormModbusAscii form = new FormModbusAscii())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormPanasonicMew form = new FormPanasonicMew())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormSiemensPPI form = new FormSiemensPPI())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormDAM3601 form = new FormDAM3601())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormMelsecLinks form = new FormMelsecLinks())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void OpenWebside(string url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 简体中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 简体中文
            Communication.StringResources.SetLanguageChinese();
            Program.Language = 1;
            Settings1.Default.language = Program.Language;
            Settings1.Default.Save();
            Language(Program.Language);
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // English
            Communication.StringResources.SeteLanguageEnglish();
            Program.Language = 2;
            Settings1.Default.language = Program.Language;
            Settings1.Default.Save();
            Language(Program.Language);
        }

        private void 日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWebside("");
        }

        private void button40_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormRedisClient form = new FormRedisClient())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormPipe form = new FormPipe())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (Redis.RedisBrowser form = new Redis.RedisBrowser())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormRedisSubscribe form = new FormRedisSubscribe())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }


        private void ThreadPoolCheckVersion(object obj)
        {
            System.Threading.Thread.Sleep(100);
            Communication.Enthernet.NetSimplifyClient simplifyClient = new Communication.Enthernet.NetSimplifyClient("127.0.0.1", 5000);
            Communication.OperateResult<Communication.NetHandle, string> read = simplifyClient.ReadCustomerFromServer(1, Communication.BasicFramework.SoftBasic.FrameworkVersion.ToString());
            if (read.IsSuccess)
            {
                Communication.BasicFramework.SystemVersion version = new Communication.BasicFramework.SystemVersion(read.Content2);
                if (version > Communication.BasicFramework.SoftBasic.FrameworkVersion)
                {
                    // 有更新
                    Invoke(new Action(() =>
                   {
                       if (MessageBox.Show("服务器有新版本：" + read.Content2 + Environment.NewLine + "是否启动更新？", "检测到更新", MessageBoxButtons.YesNo) == DialogResult.Yes)
                       {
                           try
                           {
                               System.Diagnostics.Process.Start(Application.StartupPath + "\\软件自动更新.exe");
                               System.Threading.Thread.Sleep(50);
                               Close();
                           }
                           catch (Exception ex)
                           {
                               MessageBox.Show("更新软件丢失，无法启动更新： " + ex.Message);
                           }
                       }
                   }));
                }
            }
        }



        private void button44_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (Robot.FormEfortPrevious form = new Robot.FormEfortPrevious())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormModbusServer form = new FormModbusServer())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormS7Server form = new FormS7Server())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormMelsec3C form = new FormMelsec3C())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormOmronHostLink form = new FormOmronHostLink())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button49_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormKeyenceBinary form = new FormKeyenceBinary())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormKeyenceAscii form = new FormKeyenceAscii())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormKuka form = new FormKuka())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormOmronUdp form = new FormOmronUdp())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void Button53_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormSiemens form = new FormSiemens(SiemensPLCS.S200))
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormKeyenceNanoSerial form = new FormKeyenceNanoSerial())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void Button55_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormLsisFEnet form = new FormLsisFEnet())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void Button56_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormMcServer form = new FormMcServer())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void Button57_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormLsisCnet form = new FormLsisCnet())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void Button58_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormPanasonicBinary form = new FormPanasonicBinary())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void Button59_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormLSisServer form = new FormLSisServer())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }

        private void button65_Click(object sender, EventArgs e)
        {

            //Hide();//有错误，DSCDTU x86平台才能运行
            //System.Threading.Thread.Sleep(200);
            //using (DSCDTU.FormDTUMain form = new DSCDTU.FormDTUMain())
            //{
            //    form.ShowDialog();
            //}
            //System.Threading.Thread.Sleep(200);
            //Show();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            Hide();
            System.Threading.Thread.Sleep(200);
            using (FormUdp form = new FormUdp())
            {
                form.ShowDialog();
            }
            System.Threading.Thread.Sleep(200);
            Show();
        }
    }
}
