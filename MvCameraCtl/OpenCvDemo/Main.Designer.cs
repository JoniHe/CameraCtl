namespace OpenCvDemo
{
    partial class Main
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
            this.BtLoadImage = new System.Windows.Forms.Button();
            this.PbIamge = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.PbIamge)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtLoadImage
            // 
            this.BtLoadImage.Location = new System.Drawing.Point(670, 67);
            this.BtLoadImage.Name = "BtLoadImage";
            this.BtLoadImage.Size = new System.Drawing.Size(107, 49);
            this.BtLoadImage.TabIndex = 0;
            this.BtLoadImage.Text = "加载图像";
            this.BtLoadImage.UseVisualStyleBackColor = true;
            this.BtLoadImage.Click += new System.EventHandler(this.BtLoadImage_Click);
            // 
            // PbIamge
            // 
            this.PbIamge.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PbIamge.Location = new System.Drawing.Point(3, 22);
            this.PbIamge.Name = "PbIamge";
            this.PbIamge.Size = new System.Drawing.Size(580, 473);
            this.PbIamge.TabIndex = 1;
            this.PbIamge.TabStop = false;
            this.PbIamge.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PbIamge_MouseWheel);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PbIamge);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 550);
            this.panel1.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 748);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtLoadImage);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PbIamge)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtLoadImage;
        private System.Windows.Forms.PictureBox PbIamge;
        private System.Windows.Forms.Panel panel1;
    }
}

