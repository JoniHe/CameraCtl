namespace VisualInspection.APP.BarCode
{
    partial class Form_BarCodeSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.TbImagePath = new System.Windows.Forms.TextBox();
            this.BtBrowse = new System.Windows.Forms.Button();
            this.RdoCamera = new System.Windows.Forms.RadioButton();
            this.RdoLocation = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CbbBarcodeCategory = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.CbbAlgorithmType = new System.Windows.Forms.ComboBox();
            this.BtConfirm = new System.Windows.Forms.Button();
            this.BtCancel = new System.Windows.Forms.Button();
            this.BtBrowseJob = new System.Windows.Forms.Button();
            this.TbJobPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "图像路径";
            // 
            // TbImagePath
            // 
            this.TbImagePath.Location = new System.Drawing.Point(153, 106);
            this.TbImagePath.Name = "TbImagePath";
            this.TbImagePath.Size = new System.Drawing.Size(390, 25);
            this.TbImagePath.TabIndex = 1;
            // 
            // BtBrowse
            // 
            this.BtBrowse.Location = new System.Drawing.Point(589, 108);
            this.BtBrowse.Name = "BtBrowse";
            this.BtBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtBrowse.TabIndex = 2;
            this.BtBrowse.Text = "浏览";
            this.BtBrowse.UseVisualStyleBackColor = true;
            this.BtBrowse.Click += new System.EventHandler(this.BtBrowse_Click);
            // 
            // RdoCamera
            // 
            this.RdoCamera.AutoSize = true;
            this.RdoCamera.Location = new System.Drawing.Point(15, 24);
            this.RdoCamera.Name = "RdoCamera";
            this.RdoCamera.Size = new System.Drawing.Size(58, 19);
            this.RdoCamera.TabIndex = 3;
            this.RdoCamera.TabStop = true;
            this.RdoCamera.Text = "相机";
            this.RdoCamera.UseVisualStyleBackColor = true;
            // 
            // RdoLocation
            // 
            this.RdoLocation.AutoSize = true;
            this.RdoLocation.Location = new System.Drawing.Point(15, 72);
            this.RdoLocation.Name = "RdoLocation";
            this.RdoLocation.Size = new System.Drawing.Size(88, 19);
            this.RdoLocation.TabIndex = 4;
            this.RdoLocation.TabStop = true;
            this.RdoLocation.Text = "本地图像";
            this.RdoLocation.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "条码类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "算法类型";
            // 
            // CbbBarcodeCategory
            // 
            this.CbbBarcodeCategory.FormattingEnabled = true;
            this.CbbBarcodeCategory.Location = new System.Drawing.Point(203, 34);
            this.CbbBarcodeCategory.Name = "CbbBarcodeCategory";
            this.CbbBarcodeCategory.Size = new System.Drawing.Size(121, 23);
            this.CbbBarcodeCategory.TabIndex = 7;
            this.CbbBarcodeCategory.SelectedIndexChanged += new System.EventHandler(this.CbbBarcodeCategory_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(153, 24);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 8;
            // 
            // CbbAlgorithmType
            // 
            this.CbbAlgorithmType.FormattingEnabled = true;
            this.CbbAlgorithmType.Location = new System.Drawing.Point(203, 94);
            this.CbbAlgorithmType.Name = "CbbAlgorithmType";
            this.CbbAlgorithmType.Size = new System.Drawing.Size(121, 23);
            this.CbbAlgorithmType.TabIndex = 9;
            // 
            // BtConfirm
            // 
            this.BtConfirm.Location = new System.Drawing.Point(673, 461);
            this.BtConfirm.Name = "BtConfirm";
            this.BtConfirm.Size = new System.Drawing.Size(75, 23);
            this.BtConfirm.TabIndex = 10;
            this.BtConfirm.Text = "确定";
            this.BtConfirm.UseVisualStyleBackColor = true;
            this.BtConfirm.Click += new System.EventHandler(this.BtConfirm_Click);
            // 
            // BtCancel
            // 
            this.BtCancel.Location = new System.Drawing.Point(796, 461);
            this.BtCancel.Name = "BtCancel";
            this.BtCancel.Size = new System.Drawing.Size(75, 23);
            this.BtCancel.TabIndex = 11;
            this.BtCancel.Text = "取消";
            this.BtCancel.UseVisualStyleBackColor = true;
            this.BtCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // BtBrowseJob
            // 
            this.BtBrowseJob.Location = new System.Drawing.Point(639, 395);
            this.BtBrowseJob.Name = "BtBrowseJob";
            this.BtBrowseJob.Size = new System.Drawing.Size(75, 23);
            this.BtBrowseJob.TabIndex = 15;
            this.BtBrowseJob.Text = "浏览";
            this.BtBrowseJob.UseVisualStyleBackColor = true;
            this.BtBrowseJob.Click += new System.EventHandler(this.BtBrowseJob_Click);
            // 
            // TbJobPath
            // 
            this.TbJobPath.Location = new System.Drawing.Point(203, 395);
            this.TbJobPath.Name = "TbJobPath";
            this.TbJobPath.Size = new System.Drawing.Size(390, 25);
            this.TbJobPath.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 405);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "作业路径";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RdoCamera);
            this.groupBox1.Controls.Add(this.RdoLocation);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TbImagePath);
            this.groupBox1.Controls.Add(this.BtBrowse);
            this.groupBox1.Location = new System.Drawing.Point(50, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 165);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "取像源";
            // 
            // Form_BarCodeSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 496);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtBrowseJob);
            this.Controls.Add(this.TbJobPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtCancel);
            this.Controls.Add(this.BtConfirm);
            this.Controls.Add(this.CbbAlgorithmType);
            this.Controls.Add(this.CbbBarcodeCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form_BarCodeSetting";
            this.Text = "ImageSource";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbImagePath;
        private System.Windows.Forms.Button BtBrowse;
        private System.Windows.Forms.RadioButton RdoCamera;
        private System.Windows.Forms.RadioButton RdoLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CbbBarcodeCategory;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox CbbAlgorithmType;
        private System.Windows.Forms.Button BtConfirm;
        private System.Windows.Forms.Button BtCancel;
        private System.Windows.Forms.Button BtBrowseJob;
        private System.Windows.Forms.TextBox TbJobPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}