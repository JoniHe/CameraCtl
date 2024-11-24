namespace CognextCameraCtl
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbbDeviceList = new System.Windows.Forms.ComboBox();
            this.btSearchDevice = new System.Windows.Forms.Button();
            this.btGrabing = new System.Windows.Forms.Button();
            this.cbb_VideoFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_Exposure = new System.Windows.Forms.NumericUpDown();
            this.BtSnap = new System.Windows.Forms.Button();
            this.cogDisplayStatusBarV21 = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.cogDisplay1 = new Cognex.VisionPro.Display.CogDisplay();
            this.NudLatencyLevel = new System.Windows.Forms.NumericUpDown();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Exposure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudLatencyLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbDeviceList
            // 
            this.cbbDeviceList.FormattingEnabled = true;
            this.cbbDeviceList.Location = new System.Drawing.Point(212, 49);
            this.cbbDeviceList.Name = "cbbDeviceList";
            this.cbbDeviceList.Size = new System.Drawing.Size(121, 23);
            this.cbbDeviceList.TabIndex = 1;
            this.cbbDeviceList.SelectedIndexChanged += new System.EventHandler(this.cbbDeviceList_SelectedIndexChanged);
            // 
            // btSearchDevice
            // 
            this.btSearchDevice.Location = new System.Drawing.Point(356, 49);
            this.btSearchDevice.Name = "btSearchDevice";
            this.btSearchDevice.Size = new System.Drawing.Size(75, 23);
            this.btSearchDevice.TabIndex = 2;
            this.btSearchDevice.Text = "Search";
            this.btSearchDevice.UseVisualStyleBackColor = true;
            this.btSearchDevice.Click += new System.EventHandler(this.btSearchDevice_Click);
            // 
            // btGrabing
            // 
            this.btGrabing.Location = new System.Drawing.Point(605, 523);
            this.btGrabing.Name = "btGrabing";
            this.btGrabing.Size = new System.Drawing.Size(75, 23);
            this.btGrabing.TabIndex = 3;
            this.btGrabing.Text = "Grabing";
            this.btGrabing.UseVisualStyleBackColor = true;
            this.btGrabing.Click += new System.EventHandler(this.btGrabing_Click);
            // 
            // cbb_VideoFormat
            // 
            this.cbb_VideoFormat.FormattingEnabled = true;
            this.cbb_VideoFormat.Location = new System.Drawing.Point(212, 103);
            this.cbb_VideoFormat.Name = "cbb_VideoFormat";
            this.cbb_VideoFormat.Size = new System.Drawing.Size(121, 23);
            this.cbb_VideoFormat.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "设备";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "视频格式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "延迟";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "曝光（us）";
            // 
            // nud_Exposure
            // 
            this.nud_Exposure.Location = new System.Drawing.Point(212, 159);
            this.nud_Exposure.Name = "nud_Exposure";
            this.nud_Exposure.Size = new System.Drawing.Size(120, 25);
            this.nud_Exposure.TabIndex = 9;
            this.nud_Exposure.ValueChanged += new System.EventHandler(this.nud_Exposure_ValueChanged);
            // 
            // BtSnap
            // 
            this.BtSnap.Location = new System.Drawing.Point(780, 523);
            this.BtSnap.Name = "BtSnap";
            this.BtSnap.Size = new System.Drawing.Size(75, 23);
            this.BtSnap.TabIndex = 11;
            this.BtSnap.Text = "拍照";
            this.BtSnap.UseVisualStyleBackColor = true;
            this.BtSnap.Click += new System.EventHandler(this.BtSnap_Click);
            // 
            // cogDisplayStatusBarV21
            // 
            this.cogDisplayStatusBarV21.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBarV21.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBarV21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cogDisplayStatusBarV21.Location = new System.Drawing.Point(0, 616);
            this.cogDisplayStatusBarV21.Name = "cogDisplayStatusBarV21";
            this.cogDisplayStatusBarV21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBarV21.Size = new System.Drawing.Size(1321, 22);
            this.cogDisplayStatusBarV21.TabIndex = 12;
            this.cogDisplayStatusBarV21.Use3DCoordinateSpaceTree = false;
            // 
            // cogDisplay1
            // 
            this.cogDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay1.Location = new System.Drawing.Point(509, 73);
            this.cogDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay1.MouseWheelSensitivity = 1D;
            this.cogDisplay1.Name = "cogDisplay1";
            this.cogDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay1.OcxState")));
            this.cogDisplay1.Size = new System.Drawing.Size(454, 356);
            this.cogDisplay1.TabIndex = 13;
            // 
            // NudLatencyLevel
            // 
            this.NudLatencyLevel.Location = new System.Drawing.Point(212, 217);
            this.NudLatencyLevel.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NudLatencyLevel.Name = "NudLatencyLevel";
            this.NudLatencyLevel.Size = new System.Drawing.Size(120, 25);
            this.NudLatencyLevel.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 638);
            this.Controls.Add(this.NudLatencyLevel);
            this.Controls.Add(this.cogDisplay1);
            this.Controls.Add(this.cogDisplayStatusBarV21);
            this.Controls.Add(this.BtSnap);
            this.Controls.Add(this.nud_Exposure);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbb_VideoFormat);
            this.Controls.Add(this.btGrabing);
            this.Controls.Add(this.btSearchDevice);
            this.Controls.Add(this.cbbDeviceList);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nud_Exposure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudLatencyLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbbDeviceList;
        private System.Windows.Forms.Button btSearchDevice;
        private System.Windows.Forms.Button btGrabing;
        private System.Windows.Forms.ComboBox cbb_VideoFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_Exposure;
        private System.Windows.Forms.Button BtSnap;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBarV21;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay1;
        private System.Windows.Forms.NumericUpDown NudLatencyLevel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

