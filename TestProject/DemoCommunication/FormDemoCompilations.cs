using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommunicationDemo
{
    public partial class FormDemoCompilations : Form
    {
        public FormDemoCompilations()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = $"server={textBox1.Text};uid={textBox2.Text};pwd={textBox3.Text};database={textBox4.Text}";
            SqlDataReader reader = null;
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                conn.Open();
                textBox5.Text += "连接成功！";
            }
            catch (Exception ex)
            {
                textBox5.Text += ex.Message;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
