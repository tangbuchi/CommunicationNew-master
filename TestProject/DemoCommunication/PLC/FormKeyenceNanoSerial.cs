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
using Communication.Profinet.Melsec;
using Communication;
using Communication.Profinet.Keyence;

namespace CommunicationDemo
{
    public partial class FormKeyenceNanoSerial : Form
    {
        public FormKeyenceNanoSerial( )
        {
            InitializeComponent( );
            keyenceNanoSerial = new KeyenceNanoSerial( );
        }


        private KeyenceNanoSerial keyenceNanoSerial = null;

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
            comboBox1.SelectedIndex = 2;

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
                Text = "Melsec Read PLC Demo";
                label2.Text = "Blogs:";
                label4.Text = "Protocols:";
                label20.Text = "Author:";
                label5.Text = "Fx Serial";

                label1.Text = "parity:";
                label3.Text = "Stop bits";
                label27.Text = "Com:";
                label26.Text = "BaudRate";
                label25.Text = "Data bits";
                button1.Text = "Connect";
                button2.Text = "Disconnect";
                label21.Text = "Address:";
                label6.Text = "address:";
                label7.Text = "result:";

                button_read_bool.Text = "Read Bit";
                label23.Text = "X,Y,M,L,V,B";
                button_read_short.Text = "r-short";
                button_read_ushort.Text = "r-ushort";
                button_read_int.Text = "r-int";
                button_read_uint.Text = "r-uint"; 
                label8.Text = "length:";
                label11.Text = "Address:";
                label12.Text = "length:";
                button25.Text = "Bulk Read";
                label13.Text = "Results:";
                label16.Text = "Message:";
                label14.Text = "Results:";
                button26.Text = "Read";

                label10.Text = "Address:";
                label9.Text = "Value:";
                label19.Text = "Note: The value of the string needs to be converted";
                button24.Text = "Write Bit";
                button22.Text = "w-short";
                button21.Text = "w-ushort";
                button20.Text = "w-int";
                button19.Text = "w-uint"; 

                groupBox1.Text = "Single Data Read test";
                groupBox2.Text = "Single Data Write test";
                groupBox3.Text = "Bulk Read test";
                groupBox4.Text = "Message reading test, hex string needs to be filled in";

                button3.Text = "Pressure test, r/w 3,000s";
                label24.Text = "X,Y,M,L,V,B";
                comboBox1.DataSource = new string[] { "None", "Odd", "Even" };
            }
        }

        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {

        }
        
        #region Connect And Close

        
        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox2.Text, out int baudRate ))
            {
                MessageBox.Show( DemoUtils.BaudRateInputWrong );
                return;
            }

            if (!int.TryParse( textBox16.Text, out int dataBits ))
            {
                MessageBox.Show( DemoUtils.DataBitsInputWrong );
                return;
            }

            if (!int.TryParse( textBox17.Text, out int stopBits ))
            {
                MessageBox.Show( DemoUtils.StopBitInputWrong );
                return;
            }
            

            keyenceNanoSerial?.Close( );
            keyenceNanoSerial = new KeyenceNanoSerial( );
            
            try
            {
                keyenceNanoSerial.SerialPortInni( sp =>
                {
                    sp.PortName = textBox1.Text;
                    sp.BaudRate = baudRate;
                    sp.DataBits = dataBits;
                    sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
                    sp.Parity = comboBox1.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox1.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
                } );
                keyenceNanoSerial.Open( );
                
                button2.Enabled = true;
                button1.Enabled = false;
                panel2.Enabled = true;

                userControlCurve1.ReadWriteNet = keyenceNanoSerial;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            keyenceNanoSerial.Close( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }

        

        #endregion

        #region 单数据读取测试


        private void button_read_bool_Click( object sender, EventArgs e )
        {
            // 读取bool变量
            DemoUtils.ReadResultRender( keyenceNanoSerial.ReadBool( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_short_Click( object sender, EventArgs e )
        {
            // 读取short变量
            DemoUtils.ReadResultRender( keyenceNanoSerial.ReadInt16( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_ushort_Click( object sender, EventArgs e )
        {
            // 读取ushort变量
            DemoUtils.ReadResultRender( keyenceNanoSerial.ReadUInt16( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_int_Click( object sender, EventArgs e )
        {
            // 读取int变量
            DemoUtils.ReadResultRender( keyenceNanoSerial.ReadInt32( textBox3.Text ), textBox3.Text, textBox4 );
        }
        private void button_read_uint_Click( object sender, EventArgs e )
        {
            // 读取uint变量
            DemoUtils.ReadResultRender( keyenceNanoSerial.ReadUInt32( textBox3.Text ), textBox3.Text, textBox4 );
        }
        private void button_read_long_Click( object sender, EventArgs e )
        {
            // 读取long变量
            DemoUtils.ReadResultRender( keyenceNanoSerial.ReadInt64( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_ulong_Click( object sender, EventArgs e )
        {
            // 读取ulong变量
            DemoUtils.ReadResultRender( keyenceNanoSerial.ReadUInt64( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_float_Click( object sender, EventArgs e )
        {
            // 读取float变量
            DemoUtils.ReadResultRender( keyenceNanoSerial.ReadFloat( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_double_Click( object sender, EventArgs e )
        {
            // 读取double变量
            DemoUtils.ReadResultRender( keyenceNanoSerial.ReadDouble( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_string_Click( object sender, EventArgs e )
        {      }


        #endregion

        #region 单数据写入测试


        private void button24_Click(object sender, EventArgs e)
        {
            // bool写入
            DemoUtils.WriteResultRender(() => keyenceNanoSerial.Write(textBox8.Text, bool.Parse(textBox7.Text)), textBox8.Text);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            // short写入
            DemoUtils.WriteResultRender(() => keyenceNanoSerial.Write(textBox8.Text, short.Parse(textBox7.Text)), textBox8.Text);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // ushort写入
            DemoUtils.WriteResultRender(() => keyenceNanoSerial.Write(textBox8.Text, ushort.Parse(textBox7.Text)), textBox8.Text);
        }


        private void button20_Click(object sender, EventArgs e)
        {
            // int写入
            DemoUtils.WriteResultRender(() => keyenceNanoSerial.Write(textBox8.Text, int.Parse(textBox7.Text)), textBox8.Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // uint写入
            DemoUtils.WriteResultRender(() => keyenceNanoSerial.Write(textBox8.Text, uint.Parse(textBox7.Text)), textBox8.Text);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // long写入
            DemoUtils.WriteResultRender(() => keyenceNanoSerial.Write(textBox8.Text, long.Parse(textBox7.Text)), textBox8.Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // ulong写入
            DemoUtils.WriteResultRender(() => keyenceNanoSerial.Write(textBox8.Text, ulong.Parse(textBox7.Text)), textBox8.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // float写入
            DemoUtils.WriteResultRender(() => keyenceNanoSerial.Write(textBox8.Text, float.Parse(textBox7.Text)), textBox8.Text);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // double写入
            DemoUtils.WriteResultRender(() => keyenceNanoSerial.Write(textBox8.Text, double.Parse(textBox7.Text)), textBox8.Text);
        }


        private void button14_Click(object sender, EventArgs e)
        {
            // string写入
            DemoUtils.WriteResultRender(() => keyenceNanoSerial.Write(textBox8.Text, textBox7.Text), textBox8.Text);
        }


        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            if (int.Parse(textBox9.Text)>64)
            {
                MessageBox.Show("批量读取int32最多支持64个！");
                return;
            }
            try
            {
                OperateResult<int[]> read = keyenceNanoSerial.ReadInt32(textBox6.Text, ushort.Parse(textBox9.Text));
                if (read.IsSuccess)
                {
                    string result = "";
                    for(int i =0; i<read.Content.Length;i++)
                    {
                        result += read.Content[i].ToString() + ",";
                    }
                    textBox10.Text = "Result：" + result;
                }
                else
                {
                    MessageBox.Show("Read Failed：" + read.ToMessageShowString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Read Failed：" + ex.Message);
            }

        }


        #endregion

        #region 报文读取测试


        private void button26_Click( object sender, EventArgs e )
        {
            OperateResult<byte[]> read = keyenceNanoSerial.ReadBase( Communication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
            if (read.IsSuccess)
            {
                textBox11.Text = "Result：" + Communication.BasicFramework.SoftBasic.ByteToHexString( read.Content );
            }
            else
            {
                MessageBox.Show( "Read Failed：" + read.ToMessageShowString( ) );
            }
        }


        #endregion

        #region Use Exmaple

        private void test1()
        {
            // 如果我们想要读取M100-M109，我们可以按照如下的代码进行操作

            // if we want read M100-M109, so we can do like this
            OperateResult<bool[]> read = keyenceNanoSerial.ReadBool( "M100", 10 );
            if (read.IsSuccess)
            {
                bool m100 = read.Content[0];
                // and so on
                // ...
                // then
                bool m109 = read.Content[9];
            }
            else
            {
                // failed, the follow operation is output the wrong msg
                Console.WriteLine( "Read failed: " + read.ToMessageShowString( ) );
            }
        }


        private void test3()
        {
            // These are the underlying operations that ignore validation of success
            short d100_short = keyenceNanoSerial.ReadInt16( "D100" ).Content;
            ushort d100_ushort = keyenceNanoSerial.ReadUInt16( "D100" ).Content;
            int d100_int = keyenceNanoSerial.ReadInt32( "D100" ).Content;
            uint d100_uint = keyenceNanoSerial.ReadUInt32( "D100" ).Content;
            long d100_long = keyenceNanoSerial.ReadInt64( "D100" ).Content;
            ulong d100_ulong = keyenceNanoSerial.ReadUInt64( "D100" ).Content;
            float d100_float = keyenceNanoSerial.ReadFloat( "D100" ).Content;
            double d100_double = keyenceNanoSerial.ReadDouble( "D100" ).Content;
            // need to specify the text length
            string d100_string = keyenceNanoSerial.ReadString( "D100", 10 ).Content;
        }
        private void test4()
        {
            // These are the underlying operations that ignore validation of success
            keyenceNanoSerial.Write( "D100", (short)5 );
            keyenceNanoSerial.Write( "D100", (ushort)5 );
            keyenceNanoSerial.Write( "D100", 5 );
            keyenceNanoSerial.Write( "D100", (uint)5 );
            keyenceNanoSerial.Write( "D100", (long)5 );
            keyenceNanoSerial.Write( "D100", (ulong)5 );
            keyenceNanoSerial.Write( "D100", 5f );
            keyenceNanoSerial.Write( "D100", 5d );
            // length should Multiples of 2 
            keyenceNanoSerial.Write( "D100", "12345678" );
        }


        private void test5()
        {
            // The complex situation is that you need to parse the byte array yourself.
            // Here's just one example.
            OperateResult<byte[]> read = keyenceNanoSerial.Read( "D100", 10 );
            if (read.IsSuccess)
            {
                int count = keyenceNanoSerial.ByteTransform.TransInt32( read.Content, 0 );
                float temp = keyenceNanoSerial.ByteTransform.TransSingle( read.Content, 4 );
                short name1 = keyenceNanoSerial.ByteTransform.TransInt16( read.Content, 8 );
                string barcode = Encoding.ASCII.GetString( read.Content, 10, 10 );
            }
        }

        private void test6()
        {
            // Custom types of Read and write situations in which type usertype need to be implemented in advance.
            // 自定义类型的读写的示例，前提是需要提前实现UserType类，做好相应的序列化，反序列化的操作

            OperateResult<UserType> read = keyenceNanoSerial.ReadCustomer<UserType>( "D100" );
            if (read.IsSuccess)
            {
                UserType value = read.Content;
            }
            // write value
            keyenceNanoSerial.WriteCustomer( "D100", new UserType( ) );

            // Sets an instance operation for the log.
            keyenceNanoSerial.LogNet = new Communication.LogNet.LogNetSingle( Application.StartupPath + "\\Logs.txt" );
        }

        #endregion

        #region 压力测试

        private int thread_status = 0;
        private int failed = 0;
        private DateTime thread_time_start = DateTime.Now;
        // 压力测试，开3个线程，每个线程进行读写操作，看使用时间
        private void button3_Click( object sender, EventArgs e )
        {
            thread_status = 3;
            failed = 0;
            thread_time_start = DateTime.Now;
            new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
            new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
            new Thread( new ThreadStart( thread_test2 ) ) { IsBackground = true, }.Start( );
            button3.Enabled = false;
        }

        private void thread_test2( )
        {
            int count = 500;
            while (count > 0)
            {
                if (!keyenceNanoSerial.Write( "D100", (short)1234 ).IsSuccess) failed++;
                if (!keyenceNanoSerial.ReadInt16( "D100" ).IsSuccess) failed++;
                count--;
            }
            thread_end( );
        }

        private void thread_end( )
        {
            if (Interlocked.Decrement( ref thread_status ) == 0)
            {
                // 执行完成
                Invoke( new Action( ( ) =>
                {
                    button3.Enabled = true;
                    MessageBox.Show( "Spend：" + (DateTime.Now - thread_time_start).TotalSeconds + Environment.NewLine + " Failed Count：" + failed );
                } ) );
            }
        }




        #endregion


    }
}
