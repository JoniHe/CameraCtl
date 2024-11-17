namespace MvCameraCtl
{
    partial class Form_BasicCtl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbPixelFormat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bnSetParam = new System.Windows.Forms.Button();
            this.bnGetParam = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFrameRate = new System.Windows.Forms.TextBox();
            this.tbExposure = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbGain = new System.Windows.Forms.TextBox();
            this.bnSavePng = new System.Windows.Forms.Button();
            this.bnSaveTiff = new System.Windows.Forms.Button();
            this.bnSaveJpg = new System.Windows.Forms.Button();
            this.bnSaveBmp = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bnStopRecord = new System.Windows.Forms.Button();
            this.bnStartRecord = new System.Windows.Forms.Button();
            this.bnTriggerExec = new System.Windows.Forms.Button();
            this.cbSoftTrigger = new System.Windows.Forms.CheckBox();
            this.bnStopGrab = new System.Windows.Forms.Button();
            this.bnStartGrab = new System.Windows.Forms.Button();
            this.rbtnTriggerMode = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnContinuesMode = new System.Windows.Forms.RadioButton();
            this.bnClose = new System.Windows.Forms.Button();
            this.bnOpen = new System.Windows.Forms.Button();
            this.bnEnum = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbDeviceList = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPixelFormat
            // 
            this.cbPixelFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPixelFormat.FormattingEnabled = true;
            this.cbPixelFormat.Location = new System.Drawing.Point(163, 128);
            this.cbPixelFormat.Margin = new System.Windows.Forms.Padding(4);
            this.cbPixelFormat.Name = "cbPixelFormat";
            this.cbPixelFormat.Size = new System.Drawing.Size(152, 23);
            this.cbPixelFormat.TabIndex = 0;
            this.cbPixelFormat.SelectedIndexChanged += new System.EventHandler(this.cbPixelFormat_SelectedIndexChanged_1);
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(24, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pixel Format";
            // 
            // bnSetParam
            // 
            this.bnSetParam.Enabled = false;
            this.bnSetParam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnSetParam.Location = new System.Drawing.Point(163, 161);
            this.bnSetParam.Margin = new System.Windows.Forms.Padding(4);
            this.bnSetParam.Name = "bnSetParam";
            this.bnSetParam.Size = new System.Drawing.Size(153, 29);
            this.bnSetParam.TabIndex = 7;
            this.bnSetParam.Text = "Set Parameter";
            this.bnSetParam.UseVisualStyleBackColor = true;
            // 
            // bnGetParam
            // 
            this.bnGetParam.Enabled = false;
            this.bnGetParam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnGetParam.Location = new System.Drawing.Point(21, 161);
            this.bnGetParam.Margin = new System.Windows.Forms.Padding(4);
            this.bnGetParam.Name = "bnGetParam";
            this.bnGetParam.Size = new System.Drawing.Size(128, 29);
            this.bnGetParam.TabIndex = 6;
            this.bnGetParam.Text = "Get Parameter";
            this.bnGetParam.UseVisualStyleBackColor = true;
            this.bnGetParam.Click += new System.EventHandler(this.bnGetParam_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(24, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Frame Rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(27, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Gain";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Exposure Time";
            // 
            // tbFrameRate
            // 
            this.tbFrameRate.Enabled = false;
            this.tbFrameRate.Location = new System.Drawing.Point(163, 91);
            this.tbFrameRate.Margin = new System.Windows.Forms.Padding(4);
            this.tbFrameRate.Name = "tbFrameRate";
            this.tbFrameRate.Size = new System.Drawing.Size(152, 25);
            this.tbFrameRate.TabIndex = 2;
            // 
            // tbExposure
            // 
            this.tbExposure.Enabled = false;
            this.tbExposure.Location = new System.Drawing.Point(163, 24);
            this.tbExposure.Margin = new System.Windows.Forms.Padding(4);
            this.tbExposure.Name = "tbExposure";
            this.tbExposure.Size = new System.Drawing.Size(152, 25);
            this.tbExposure.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbPixelFormat);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.bnSetParam);
            this.groupBox4.Controls.Add(this.bnGetParam);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.tbFrameRate);
            this.groupBox4.Controls.Add(this.tbGain);
            this.groupBox4.Controls.Add(this.tbExposure);
            this.groupBox4.Location = new System.Drawing.Point(916, 495);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(324, 210);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Parameters";
            // 
            // tbGain
            // 
            this.tbGain.Enabled = false;
            this.tbGain.Location = new System.Drawing.Point(163, 58);
            this.tbGain.Margin = new System.Windows.Forms.Padding(4);
            this.tbGain.Name = "tbGain";
            this.tbGain.Size = new System.Drawing.Size(152, 25);
            this.tbGain.TabIndex = 1;
            // 
            // bnSavePng
            // 
            this.bnSavePng.Enabled = false;
            this.bnSavePng.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnSavePng.Location = new System.Drawing.Point(189, 71);
            this.bnSavePng.Margin = new System.Windows.Forms.Padding(4);
            this.bnSavePng.Name = "bnSavePng";
            this.bnSavePng.Size = new System.Drawing.Size(127, 29);
            this.bnSavePng.TabIndex = 2;
            this.bnSavePng.Text = "Save as PNG";
            this.bnSavePng.UseVisualStyleBackColor = true;
            // 
            // bnSaveTiff
            // 
            this.bnSaveTiff.Enabled = false;
            this.bnSaveTiff.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnSaveTiff.Location = new System.Drawing.Point(27, 71);
            this.bnSaveTiff.Margin = new System.Windows.Forms.Padding(4);
            this.bnSaveTiff.Name = "bnSaveTiff";
            this.bnSaveTiff.Size = new System.Drawing.Size(123, 29);
            this.bnSaveTiff.TabIndex = 1;
            this.bnSaveTiff.Text = "Save as TIFF";
            this.bnSaveTiff.UseVisualStyleBackColor = true;
            // 
            // bnSaveJpg
            // 
            this.bnSaveJpg.Enabled = false;
            this.bnSaveJpg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnSaveJpg.Location = new System.Drawing.Point(189, 25);
            this.bnSaveJpg.Margin = new System.Windows.Forms.Padding(4);
            this.bnSaveJpg.Name = "bnSaveJpg";
            this.bnSaveJpg.Size = new System.Drawing.Size(127, 29);
            this.bnSaveJpg.TabIndex = 0;
            this.bnSaveJpg.Text = "Save as JPG";
            this.bnSaveJpg.UseVisualStyleBackColor = true;
            // 
            // bnSaveBmp
            // 
            this.bnSaveBmp.Enabled = false;
            this.bnSaveBmp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnSaveBmp.Location = new System.Drawing.Point(27, 25);
            this.bnSaveBmp.Margin = new System.Windows.Forms.Padding(4);
            this.bnSaveBmp.Name = "bnSaveBmp";
            this.bnSaveBmp.Size = new System.Drawing.Size(123, 29);
            this.bnSaveBmp.TabIndex = 0;
            this.bnSaveBmp.Text = "Save as BMP";
            this.bnSaveBmp.UseVisualStyleBackColor = true;
            this.bnSaveBmp.Click += new System.EventHandler(this.bnSaveBmp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bnSavePng);
            this.groupBox3.Controls.Add(this.bnSaveTiff);
            this.groupBox3.Controls.Add(this.bnSaveJpg);
            this.groupBox3.Controls.Add(this.bnSaveBmp);
            this.groupBox3.Location = new System.Drawing.Point(916, 380);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(324, 108);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Picture Storage";
            // 
            // bnStopRecord
            // 
            this.bnStopRecord.Enabled = false;
            this.bnStopRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnStopRecord.Location = new System.Drawing.Point(197, 124);
            this.bnStopRecord.Margin = new System.Windows.Forms.Padding(4);
            this.bnStopRecord.Name = "bnStopRecord";
            this.bnStopRecord.Size = new System.Drawing.Size(116, 29);
            this.bnStopRecord.TabIndex = 7;
            this.bnStopRecord.Text = "Stop Record";
            this.bnStopRecord.UseVisualStyleBackColor = true;
            this.bnStopRecord.Click += new System.EventHandler(this.bnStopRecord_Click);
            // 
            // bnStartRecord
            // 
            this.bnStartRecord.Enabled = false;
            this.bnStartRecord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnStartRecord.Location = new System.Drawing.Point(27, 124);
            this.bnStartRecord.Margin = new System.Windows.Forms.Padding(4);
            this.bnStartRecord.Name = "bnStartRecord";
            this.bnStartRecord.Size = new System.Drawing.Size(123, 29);
            this.bnStartRecord.TabIndex = 6;
            this.bnStartRecord.Text = "Start Record";
            this.bnStartRecord.UseVisualStyleBackColor = true;
            this.bnStartRecord.Click += new System.EventHandler(this.bnStartRecord_Click);
            // 
            // bnTriggerExec
            // 
            this.bnTriggerExec.Enabled = false;
            this.bnTriggerExec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnTriggerExec.Location = new System.Drawing.Point(197, 91);
            this.bnTriggerExec.Margin = new System.Windows.Forms.Padding(4);
            this.bnTriggerExec.Name = "bnTriggerExec";
            this.bnTriggerExec.Size = new System.Drawing.Size(116, 29);
            this.bnTriggerExec.TabIndex = 5;
            this.bnTriggerExec.Text = "Trigger Once";
            this.bnTriggerExec.UseVisualStyleBackColor = true;
            this.bnTriggerExec.Click += new System.EventHandler(this.bnTriggerExec_Click);
            // 
            // cbSoftTrigger
            // 
            this.cbSoftTrigger.AutoSize = true;
            this.cbSoftTrigger.Enabled = false;
            this.cbSoftTrigger.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbSoftTrigger.Location = new System.Drawing.Point(8, 96);
            this.cbSoftTrigger.Margin = new System.Windows.Forms.Padding(4);
            this.cbSoftTrigger.Name = "cbSoftTrigger";
            this.cbSoftTrigger.Size = new System.Drawing.Size(181, 19);
            this.cbSoftTrigger.TabIndex = 4;
            this.cbSoftTrigger.Text = "Trigger by Software";
            this.cbSoftTrigger.UseVisualStyleBackColor = true;
            this.cbSoftTrigger.CheckedChanged += new System.EventHandler(this.cbSoftTrigger_CheckedChanged);
            // 
            // bnStopGrab
            // 
            this.bnStopGrab.Enabled = false;
            this.bnStopGrab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnStopGrab.Location = new System.Drawing.Point(197, 60);
            this.bnStopGrab.Margin = new System.Windows.Forms.Padding(4);
            this.bnStopGrab.Name = "bnStopGrab";
            this.bnStopGrab.Size = new System.Drawing.Size(117, 29);
            this.bnStopGrab.TabIndex = 3;
            this.bnStopGrab.Text = "Stop";
            this.bnStopGrab.UseVisualStyleBackColor = true;
            this.bnStopGrab.Click += new System.EventHandler(this.bnStopGrab_Click);
            // 
            // bnStartGrab
            // 
            this.bnStartGrab.Enabled = false;
            this.bnStartGrab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnStartGrab.Location = new System.Drawing.Point(27, 60);
            this.bnStartGrab.Margin = new System.Windows.Forms.Padding(4);
            this.bnStartGrab.Name = "bnStartGrab";
            this.bnStartGrab.Size = new System.Drawing.Size(123, 29);
            this.bnStartGrab.TabIndex = 2;
            this.bnStartGrab.Text = "Start";
            this.bnStartGrab.UseVisualStyleBackColor = true;
            this.bnStartGrab.Click += new System.EventHandler(this.bnStartGrab_Click);
            // 
            // rbtnTriggerMode
            // 
            this.rbtnTriggerMode.AutoSize = true;
            this.rbtnTriggerMode.Enabled = false;
            this.rbtnTriggerMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTriggerMode.Location = new System.Drawing.Point(197, 25);
            this.rbtnTriggerMode.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnTriggerMode.Name = "rbtnTriggerMode";
            this.rbtnTriggerMode.Size = new System.Drawing.Size(124, 19);
            this.rbtnTriggerMode.TabIndex = 1;
            this.rbtnTriggerMode.TabStop = true;
            this.rbtnTriggerMode.Text = "Trigger Mode";
            this.rbtnTriggerMode.UseMnemonic = false;
            this.rbtnTriggerMode.UseVisualStyleBackColor = true;
            this.rbtnTriggerMode.CheckedChanged += new System.EventHandler(this.bnTriggerMode_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bnStopRecord);
            this.groupBox2.Controls.Add(this.bnStartRecord);
            this.groupBox2.Controls.Add(this.bnTriggerExec);
            this.groupBox2.Controls.Add(this.cbSoftTrigger);
            this.groupBox2.Controls.Add(this.bnStopGrab);
            this.groupBox2.Controls.Add(this.bnStartGrab);
            this.groupBox2.Controls.Add(this.rbtnTriggerMode);
            this.groupBox2.Controls.Add(this.rbtnContinuesMode);
            this.groupBox2.Location = new System.Drawing.Point(916, 200);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(324, 168);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image Acquisition";
            // 
            // rbtnContinuesMode
            // 
            this.rbtnContinuesMode.AutoSize = true;
            this.rbtnContinuesMode.Enabled = false;
            this.rbtnContinuesMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnContinuesMode.Location = new System.Drawing.Point(27, 25);
            this.rbtnContinuesMode.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnContinuesMode.Name = "rbtnContinuesMode";
            this.rbtnContinuesMode.Size = new System.Drawing.Size(108, 19);
            this.rbtnContinuesMode.TabIndex = 0;
            this.rbtnContinuesMode.TabStop = true;
            this.rbtnContinuesMode.Text = "Continuous";
            this.rbtnContinuesMode.UseVisualStyleBackColor = true;
            this.rbtnContinuesMode.CheckedChanged += new System.EventHandler(this.rbtnContinuesMode_CheckedChanged);
            // 
            // bnClose
            // 
            this.bnClose.Enabled = false;
            this.bnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnClose.Location = new System.Drawing.Point(189, 86);
            this.bnClose.Margin = new System.Windows.Forms.Padding(4);
            this.bnClose.Name = "bnClose";
            this.bnClose.Size = new System.Drawing.Size(117, 29);
            this.bnClose.TabIndex = 2;
            this.bnClose.Text = "Close Device";
            this.bnClose.UseVisualStyleBackColor = true;
            this.bnClose.Click += new System.EventHandler(this.bnClose_Click);
            // 
            // bnOpen
            // 
            this.bnOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnOpen.Location = new System.Drawing.Point(27, 86);
            this.bnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.bnOpen.Name = "bnOpen";
            this.bnOpen.Size = new System.Drawing.Size(111, 29);
            this.bnOpen.TabIndex = 1;
            this.bnOpen.Text = "Open Device";
            this.bnOpen.UseVisualStyleBackColor = true;
            this.bnOpen.Click += new System.EventHandler(this.bnOpen_Click);
            // 
            // bnEnum
            // 
            this.bnEnum.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bnEnum.Location = new System.Drawing.Point(27, 25);
            this.bnEnum.Margin = new System.Windows.Forms.Padding(4);
            this.bnEnum.Name = "bnEnum";
            this.bnEnum.Size = new System.Drawing.Size(280, 29);
            this.bnEnum.TabIndex = 0;
            this.bnEnum.Text = "Search Device";
            this.bnEnum.UseVisualStyleBackColor = true;
            this.bnEnum.Click += new System.EventHandler(this.bnEnum_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bnClose);
            this.groupBox1.Controls.Add(this.bnOpen);
            this.groupBox1.Controls.Add(this.bnEnum);
            this.groupBox1.Location = new System.Drawing.Point(916, 55);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(324, 136);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initialization";
            // 
            // cbDeviceList
            // 
            this.cbDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeviceList.FormattingEnabled = true;
            this.cbDeviceList.Location = new System.Drawing.Point(23, 15);
            this.cbDeviceList.Margin = new System.Windows.Forms.Padding(4);
            this.cbDeviceList.Name = "cbDeviceList";
            this.cbDeviceList.Size = new System.Drawing.Size(841, 23);
            this.cbDeviceList.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(23, 61);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(843, 604);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form_BasicCtl
            // 
            this.ClientSize = new System.Drawing.Size(1297, 915);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbDeviceList);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form_BasicCtl";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPixelFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bnSetParam;
        private System.Windows.Forms.Button bnGetParam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFrameRate;
        private System.Windows.Forms.TextBox tbExposure;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbGain;
        private System.Windows.Forms.Button bnSavePng;
        private System.Windows.Forms.Button bnSaveTiff;
        private System.Windows.Forms.Button bnSaveJpg;
        private System.Windows.Forms.Button bnSaveBmp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bnStopRecord;
        private System.Windows.Forms.Button bnStartRecord;
        private System.Windows.Forms.Button bnTriggerExec;
        private System.Windows.Forms.CheckBox cbSoftTrigger;
        private System.Windows.Forms.Button bnStopGrab;
        private System.Windows.Forms.Button bnStartGrab;
        private System.Windows.Forms.RadioButton rbtnTriggerMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnContinuesMode;
        private System.Windows.Forms.Button bnClose;
        private System.Windows.Forms.Button bnOpen;
        private System.Windows.Forms.Button bnEnum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbDeviceList;
        private System.Windows.Forms.PictureBox pictureBox1;
    }

}