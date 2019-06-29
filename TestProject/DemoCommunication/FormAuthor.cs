using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommunicationDemo
{
    public partial class FormAuthor : Form
    {
        public FormAuthor( )
        {
            InitializeComponent( );
        }

        private void FormAuthor_Load( object sender, EventArgs e )
        {
            
        }

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
    }
}
