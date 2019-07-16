using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommunicationDemo
{
    public partial class FormFTPush : Form
    {
        public FormFTPush()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tb_result_TextChange("wait");
            string result = HttpPost(textBox2.Text, textBox3.Text);
            Tb_result_TextChange(result);
        }

        private string HttpPost(string tb_text, string tb_desp)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://sc.ftqq.com/" + textBox1.Text + ".send");

            var postData = "text=" + tb_text;
            postData += "&desp=" + tb_desp;
            var data = Encoding.UTF8.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf8";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            label3.Text = "Uri:" + response.ResponseUri.ToString();
            var responeString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responeString;
        }

        private void Tb_result_TextChange(string text)
        {
            switch (text)
            {
                case "wait":
                    label2.Text = "wait...";
                    break;
                case "{\"errno\":0,\"errmsg\":\"success\",\"dataset\":\"done\"}":
                    label2.Text = "Success!";
                    break;
                default:
                    label2.Text = text;
                    break;
            }
        }
    }
}
