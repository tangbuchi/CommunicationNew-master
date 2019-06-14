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
using Communication;
using Communication.Profinet.Omron;

namespace CommunicationDemo
{
    public partial class FormOmronHostLink : Form
    {
        public FormOmronHostLink( )
        {
            InitializeComponent( );
            omronHostLink = new OmronHostLink( );
            // omronHostLink.LogNet = new Communication.LogNet.LogNetSingle( "omron.log.txt" );
        }


        private OmronHostLink omronHostLink = null;

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
            comboBox1.DataSource = Communication.BasicFramework.SoftBasic.GetEnumValues<Communication.Core.DataFormat>( );
            comboBox1.SelectedItem = Communication.Core.DataFormat.CDAB;
            panel2.Enabled = false;

            Language( Program.Language );

            comboBox2.SelectedIndex = 2;


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
                Text = "Omron Read PLC Demo";
                label2.Text = "Blogs:";
                label4.Text = "Protocols:";
                label20.Text = "Author:";
                label5.Text = "Fins Tcp";
                label24.Text = "Unit Num";
                label25.Text = "Net Num";
                label23.Text = "PC Net Num";

                label1.Text = "Station:";
                label3.Text = "Parity:";
                button1.Text = "Open";
                button2.Text = "Close";
                label21.Text = "Address:";
                label6.Text = "address:";
                label7.Text = "result:";
                label29.Text = "Com:";
                label28.Text = "BaudRate:";
                label27.Text = "DataBit:";
                label26.Text = "StopBit:";


                button_read_bool.Text = "Read Bit";
                button_read_short.Text = "r-short";
                button_read_ushort.Text = "r-ushort";
                button_read_int.Text = "r-int";
                button_read_uint.Text = "r-uint";
                button_read_long.Text = "r-long";
                button_read_ulong.Text = "r-ulong";
                button_read_float.Text = "r-float";
                button_read_double.Text = "r-double";
                button_read_string.Text = "r-string";
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
                button18.Text = "w-long";
                button17.Text = "w-ulong";
                button16.Text = "w-float";
                button15.Text = "w-double";
                button14.Text = "w-string";

                groupBox1.Text = "Single Data Read test";
                groupBox2.Text = "Single Data Write test";
                groupBox3.Text = "Bulk Read test";
                groupBox4.Text = "Message reading test, hex string needs to be filled in";
            }
        }

        private void FormSiemens_FormClosing( object sender, FormClosingEventArgs e )
        {

        }
        
        #region Connect And Close



        private void button1_Click( object sender, EventArgs e )
        {
            if (!int.TryParse( textBox19.Text, out int baudRate ))
            {
                MessageBox.Show( DemoUtils.BaudRateInputWrong );
                return;
            }

            if (!int.TryParse( textBox18.Text, out int dataBits ))
            {
                MessageBox.Show( DemoUtils.DataBitsInputWrong );
                return;
            }

            if (!int.TryParse( textBox2.Text, out int stopBits ))
            {
                MessageBox.Show( DemoUtils.StopBitInputWrong );
                return;
            }

            if (!byte.TryParse( textBox1.Text, out byte Station ))
            {
                MessageBox.Show( "PLC Station input wrong！" );
                return;
            }

            if (!byte.TryParse( textBox15.Text, out byte SID ))
            {
                MessageBox.Show( "PLC SID input wrong！" );
                return;
            }


            if (!byte.TryParse( textBox16.Text, out byte DA2 ))
            {
                MessageBox.Show( "PLC DA2 input wrong！" );
                return;
            }

            if (!byte.TryParse( textBox17.Text, out byte SA2 ))
            {
                MessageBox.Show( "PC SA2 input wrong" );
                return;
            }

            omronHostLink?.Close( );
            omronHostLink = new OmronHostLink( );

            try
            {
                omronHostLink.SerialPortInni( sp =>
                {
                    sp.PortName = textBox20.Text;
                    sp.BaudRate = baudRate;
                    sp.DataBits = dataBits;
                    sp.StopBits = stopBits == 0 ? System.IO.Ports.StopBits.None : (stopBits == 1 ? System.IO.Ports.StopBits.One : System.IO.Ports.StopBits.Two);
                    sp.Parity = comboBox2.SelectedIndex == 0 ? System.IO.Ports.Parity.None : (comboBox2.SelectedIndex == 1 ? System.IO.Ports.Parity.Odd : System.IO.Ports.Parity.Even);
                } );
                omronHostLink.UnitNumber = Station;
                omronHostLink.SID = SID;
                omronHostLink.DA2 = DA2;
                omronHostLink.SA2 = SA2;
                omronHostLink.ByteTransform.DataFormat = (Communication.Core.DataFormat)comboBox1.SelectedItem;


                omronHostLink.Open( );
                button2.Enabled = true;
                button1.Enabled = false;
                panel2.Enabled = true;

                userControlCurve1.ReadWriteNet = omronHostLink;
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            omronHostLink.Close( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }
        
        #endregion

        #region 单数据读取测试


        private void button_read_bool_Click( object sender, EventArgs e )
        {
            // 读取bool变量
            DemoUtils.ReadResultRender( omronHostLink.ReadBool( textBox3.Text ), textBox3.Text, textBox4 );
        }
        private void button_read_short_Click( object sender, EventArgs e )
        {
            // 读取short变量
            DemoUtils.ReadResultRender( omronHostLink.ReadInt16( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_ushort_Click( object sender, EventArgs e )
        {
            // 读取ushort变量
            DemoUtils.ReadResultRender( omronHostLink.ReadUInt16( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_int_Click( object sender, EventArgs e )
        {
            // 读取int变量
            DemoUtils.ReadResultRender( omronHostLink.ReadInt32( textBox3.Text ), textBox3.Text, textBox4 );
        }
        private void button_read_uint_Click( object sender, EventArgs e )
        {
            // 读取uint变量
            DemoUtils.ReadResultRender( omronHostLink.ReadUInt32( textBox3.Text ), textBox3.Text, textBox4 );
        }
        private void button_read_long_Click( object sender, EventArgs e )
        {
            // 读取long变量
            DemoUtils.ReadResultRender( omronHostLink.ReadInt64( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_ulong_Click( object sender, EventArgs e )
        {
            // 读取ulong变量
            DemoUtils.ReadResultRender( omronHostLink.ReadUInt64( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_float_Click( object sender, EventArgs e )
        {
            // 读取float变量
            DemoUtils.ReadResultRender( omronHostLink.ReadFloat( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_double_Click( object sender, EventArgs e )
        {
            // 读取double变量
            DemoUtils.ReadResultRender( omronHostLink.ReadDouble( textBox3.Text ), textBox3.Text, textBox4 );
        }

        private void button_read_string_Click( object sender, EventArgs e )
        {
            // 读取字符串
            DemoUtils.ReadResultRender( omronHostLink.ReadString( textBox3.Text, ushort.Parse( textBox5.Text ) ), textBox3.Text, textBox4 );
        }


        #endregion

        #region 单数据写入测试


        private void button24_Click( object sender, EventArgs e )
        {
            // bool写入
            DemoUtils.WriteResultRender( () => omronHostLink.Write( textBox8.Text, bool.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button22_Click( object sender, EventArgs e )
        {
            // short写入
            DemoUtils.WriteResultRender( () => omronHostLink.Write( textBox8.Text, short.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button21_Click( object sender, EventArgs e )
        {
            // ushort写入
            DemoUtils.WriteResultRender( () => omronHostLink.Write( textBox8.Text, ushort.Parse( textBox7.Text ) ), textBox8.Text );
        }


        private void button20_Click( object sender, EventArgs e )
        {
            // int写入
            DemoUtils.WriteResultRender( () => omronHostLink.Write( textBox8.Text, int.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button19_Click( object sender, EventArgs e )
        {
            // uint写入
            DemoUtils.WriteResultRender( () => omronHostLink.Write( textBox8.Text, uint.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button18_Click( object sender, EventArgs e )
        {
            // long写入
            DemoUtils.WriteResultRender( omronHostLink.Write( textBox8.Text, long.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button17_Click( object sender, EventArgs e )
        {
            // ulong写入
            DemoUtils.WriteResultRender( () => omronHostLink.Write( textBox8.Text, ulong.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button16_Click( object sender, EventArgs e )
        {
            // float写入
            DemoUtils.WriteResultRender( () => omronHostLink.Write( textBox8.Text, float.Parse( textBox7.Text ) ), textBox8.Text );
        }

        private void button15_Click( object sender, EventArgs e )
        {
            // double写入
            DemoUtils.WriteResultRender( () => omronHostLink.Write( textBox8.Text, double.Parse( textBox7.Text ) ), textBox8.Text );
        }


        private void button14_Click( object sender, EventArgs e )
        {
            // string写入
            DemoUtils.WriteResultRender( () => omronHostLink.Write( textBox8.Text, textBox7.Text ), textBox8.Text );
        }




        #endregion

        #region 批量读取测试

        private void button25_Click( object sender, EventArgs e )
        {
            DemoUtils.BulkReadRenderResult( omronHostLink, textBox6, textBox9, textBox10 );
        }



        #endregion

        #region 报文读取测试


        private void button26_Click( object sender, EventArgs e )
        {
            OperateResult<byte[]> read = omronHostLink.ReadBase( Communication.BasicFramework.SoftBasic.HexStringToBytes( textBox13.Text ) );
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
        
        private void test()
        {
            // 读取操作，这里的D100可以替换成C100,A100,W100,H100效果时一样的
            bool D100_7 = omronHostLink.ReadBool( "D100.7" ).Content;  // 读取D100.7是否通断，注意D100.0等同于D100
            short short_D100 = omronHostLink.ReadInt16( "D100" ).Content; // 读取D100组成的字
            ushort ushort_D100 = omronHostLink.ReadUInt16( "D100" ).Content; // 读取D100组成的无符号的值
            int int_D100 = omronHostLink.ReadInt32( "D100" ).Content;         // 读取D100-D101组成的有符号的数据
            uint uint_D100 = omronHostLink.ReadUInt32( "D100" ).Content;      // 读取D100-D101组成的无符号的值
            float float_D100 = omronHostLink.ReadFloat( "D100" ).Content;   // 读取D100-D101组成的单精度值
            long long_D100 = omronHostLink.ReadInt64( "D100" ).Content;      // 读取D100-D103组成的大数据值
            ulong ulong_D100 = omronHostLink.ReadUInt64( "D100" ).Content;   // 读取D100-D103组成的无符号大数据
            double double_D100 = omronHostLink.ReadDouble( "D100" ).Content; // 读取D100-D103组成的双精度值
            string str_D100 = omronHostLink.ReadString( "D100", 5 ).Content;// 读取D100-D104组成的ASCII字符串数据

            // 写入操作，这里的D100可以替换成C100,A100,W100,H100效果时一样的
            omronHostLink.Write( "D100", (byte)0x33 );            // 写单个字节
            omronHostLink.Write( "D100", (short)12345 );          // 写双字节有符号
            omronHostLink.Write( "D100", (ushort)45678 );         // 写双字节无符号
            omronHostLink.Write( "D100", (uint)3456789123 );      // 写双字无符号
            omronHostLink.Write( "D100", 123.456f );              // 写单精度
            omronHostLink.Write( "D100", 1234556434534545L );     // 写大整数有符号
            omronHostLink.Write( "D100", 523434234234343UL );     // 写大整数无符号
            omronHostLink.Write( "D100", 123.456d );              // 写双精度
            omronHostLink.Write( "D100", "K123456789" );// 写ASCII字符串

            OperateResult<byte[]> read = omronHostLink.Read( "D100", 5 );
            {
                if (read.IsSuccess)
                {
                    // 此处需要根据实际的情况来自定义来处理复杂的数据
                    short D100 = omronHostLink.ByteTransform.TransInt16( read.Content, 0 );
                    short D101 = omronHostLink.ByteTransform.TransInt16( read.Content, 2 );
                    short D102 = omronHostLink.ByteTransform.TransInt16( read.Content, 4 );
                    short D103 = omronHostLink.ByteTransform.TransInt16( read.Content, 6 );
                    short D104 = omronHostLink.ByteTransform.TransInt16( read.Content, 7 );
                }
                else
                {
                    // 发生了异常
                }
            }
        }        
    }
}
