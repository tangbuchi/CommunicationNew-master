﻿namespace ipScan.Classes.Main
{
    partial class IPScanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_ThreadCount = new System.Windows.Forms.TextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.textBox_Timeout = new System.Windows.Forms.TextBox();
            this.label_Progress = new System.Windows.Forms.Label();
            this.button_Pause = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSL_Found = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSL_ThreadIPWorks = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSL_ThreadsDNS = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSL_pauseTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SG_Result = new SourceGrid.Grid();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_IPFirst = new System.Windows.Forms.ComboBox();
            this.comboBox_IPLast = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_ThreadCount
            // 
            this.textBox_ThreadCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_ThreadCount.Location = new System.Drawing.Point(64, 398);
            this.textBox_ThreadCount.Name = "textBox_ThreadCount";
            this.textBox_ThreadCount.Size = new System.Drawing.Size(50, 21);
            this.textBox_ThreadCount.TabIndex = 2;
            this.textBox_ThreadCount.TabStop = false;
            this.textBox_ThreadCount.Text = "500";
            this.textBox_ThreadCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ThreadCount_KeyPress);
            // 
            // button_Start
            // 
            this.button_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Start.Location = new System.Drawing.Point(12, 473);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 21);
            this.button_Start.TabIndex = 4;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Stop.Enabled = false;
            this.button_Stop.Location = new System.Drawing.Point(497, 473);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(75, 21);
            this.button_Stop.TabIndex = 6;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // textBox_Timeout
            // 
            this.textBox_Timeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox_Timeout.Location = new System.Drawing.Point(195, 398);
            this.textBox_Timeout.Name = "textBox_Timeout";
            this.textBox_Timeout.Size = new System.Drawing.Size(50, 21);
            this.textBox_Timeout.TabIndex = 3;
            this.textBox_Timeout.TabStop = false;
            this.textBox_Timeout.Text = "1000";
            // 
            // label_Progress
            // 
            this.label_Progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_Progress.AutoSize = true;
            this.label_Progress.Location = new System.Drawing.Point(12, 450);
            this.label_Progress.Name = "label_Progress";
            this.label_Progress.Size = new System.Drawing.Size(0, 12);
            this.label_Progress.TabIndex = 8;
            // 
            // button_Pause
            // 
            this.button_Pause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Pause.Enabled = false;
            this.button_Pause.Location = new System.Drawing.Point(416, 473);
            this.button_Pause.Name = "button_Pause";
            this.button_Pause.Size = new System.Drawing.Size(75, 21);
            this.button_Pause.TabIndex = 5;
            this.button_Pause.Tag = "true";
            this.button_Pause.Text = "Pause";
            this.button_Pause.UseVisualStyleBackColor = true;
            this.button_Pause.Click += new System.EventHandler(this.button_Pause_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tSSL_Found,
            this.toolStripStatusLabel2,
            this.tSSL_ThreadIPWorks,
            this.toolStripStatusLabel3,
            this.tSSL_ThreadsDNS,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel4,
            this.tSSL_pauseTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 504);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 23);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 18);
            this.toolStripStatusLabel1.Text = "Found";
            // 
            // tSSL_Found
            // 
            this.tSSL_Found.AutoSize = false;
            this.tSSL_Found.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tSSL_Found.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tSSL_Found.Name = "tSSL_Found";
            this.tSSL_Found.Size = new System.Drawing.Size(50, 18);
            this.tSSL_Found.Text = "0";
            this.tSSL_Found.ToolTipText = "Знайдено IP";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(55, 18);
            this.toolStripStatusLabel2.Text = "Threads";
            // 
            // tSSL_ThreadIPWorks
            // 
            this.tSSL_ThreadIPWorks.AutoSize = false;
            this.tSSL_ThreadIPWorks.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tSSL_ThreadIPWorks.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tSSL_ThreadIPWorks.Name = "tSSL_ThreadIPWorks";
            this.tSSL_ThreadIPWorks.Size = new System.Drawing.Size(50, 18);
            this.tSSL_ThreadIPWorks.Text = "0";
            this.tSSL_ThreadIPWorks.ToolTipText = "Потоків запущено";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(88, 18);
            this.toolStripStatusLabel3.Text = "DNS requests";
            // 
            // tSSL_ThreadsDNS
            // 
            this.tSSL_ThreadsDNS.AutoSize = false;
            this.tSSL_ThreadsDNS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tSSL_ThreadsDNS.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tSSL_ThreadsDNS.Name = "tSSL_ThreadsDNS";
            this.tSSL_ThreadsDNS.Size = new System.Drawing.Size(50, 18);
            this.tSSL_ThreadsDNS.Text = "0";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(63, 18);
            this.toolStripStatusLabel4.Text = "loopTime";
            // 
            // tSSL_pauseTime
            // 
            this.tSSL_pauseTime.AutoSize = false;
            this.tSSL_pauseTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tSSL_pauseTime.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tSSL_pauseTime.Name = "tSSL_pauseTime";
            this.tSSL_pauseTime.Size = new System.Drawing.Size(50, 18);
            this.tSSL_pauseTime.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(13, 423);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(559, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "0";
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_SizeChanged);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // SG_Result
            // 
            this.SG_Result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SG_Result.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SG_Result.AutoStretchColumnsToFitWidth = true;
            this.SG_Result.ClipboardMode = SourceGrid.ClipboardMode.Copy;
            this.SG_Result.ColumnsCount = 3;
            this.SG_Result.EnableSort = true;
            this.SG_Result.FixedRows = 1;
            this.SG_Result.Location = new System.Drawing.Point(15, 35);
            this.SG_Result.Name = "SG_Result";
            this.SG_Result.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.SG_Result.RowsCount = 1;
            this.SG_Result.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.SG_Result.Size = new System.Drawing.Size(557, 357);
            this.SG_Result.TabIndex = 7;
            this.SG_Result.TabStop = true;
            this.SG_Result.Tag = "123434";
            this.SG_Result.ToolTipText = "";
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Threads";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ping Timeout";
            // 
            // comboBox_IPFirst
            // 
            this.comboBox_IPFirst.FormattingEnabled = true;
            this.comboBox_IPFirst.Location = new System.Drawing.Point(15, 11);
            this.comboBox_IPFirst.Name = "comboBox_IPFirst";
            this.comboBox_IPFirst.Size = new System.Drawing.Size(165, 20);
            this.comboBox_IPFirst.TabIndex = 12;
            // 
            // comboBox_IPLast
            // 
            this.comboBox_IPLast.FormattingEnabled = true;
            this.comboBox_IPLast.Location = new System.Drawing.Point(186, 11);
            this.comboBox_IPLast.Name = "comboBox_IPLast";
            this.comboBox_IPLast.Size = new System.Drawing.Size(165, 20);
            this.comboBox_IPLast.TabIndex = 13;
            // 
            // IPScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 527);
            this.Controls.Add(this.comboBox_IPLast);
            this.Controls.Add(this.comboBox_IPFirst);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SG_Result);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_Pause);
            this.Controls.Add(this.label_Progress);
            this.Controls.Add(this.textBox_Timeout);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.textBox_ThreadCount);
            this.MinimumSize = new System.Drawing.Size(600, 418);
            this.Name = "IPScanForm";
            this.Text = "ipScan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IPScanForm_FormClosing);
            this.Load += new System.EventHandler(this.IPScanForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_ThreadCount;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.TextBox textBox_Timeout;
        private System.Windows.Forms.Label label_Progress;
        private System.Windows.Forms.Button button_Pause;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tSSL_Found;
        private System.Windows.Forms.ToolStripStatusLabel tSSL_ThreadIPWorks;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tSSL_ThreadsDNS;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel tSSL_pauseTime;
        private SourceGrid.Grid SG_Result;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_IPFirst;
        private System.Windows.Forms.ComboBox comboBox_IPLast;
    }
}

