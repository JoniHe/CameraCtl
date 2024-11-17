namespace CommonFunc.Camera.WinForms
{
    partial class Form_AcquisitionControl
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
            this.nudExposureTime = new System.Windows.Forms.NumericUpDown();
            this.cbTrigerSource = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAcquisitionMode = new System.Windows.Forms.ComboBox();
            this.cbTriggerMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudExposureTime)).BeginInit();
            this.SuspendLayout();
            // 
            // nudExposureTime
            // 
            this.nudExposureTime.Location = new System.Drawing.Point(226, 199);
            this.nudExposureTime.Name = "nudExposureTime";
            this.nudExposureTime.Size = new System.Drawing.Size(120, 25);
            this.nudExposureTime.TabIndex = 16;
            // 
            // cbTrigerSource
            // 
            this.cbTrigerSource.FormattingEnabled = true;
            this.cbTrigerSource.Location = new System.Drawing.Point(225, 149);
            this.cbTrigerSource.Name = "cbTrigerSource";
            this.cbTrigerSource.Size = new System.Drawing.Size(121, 23);
            this.cbTrigerSource.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Trigger Source";
            // 
            // cbAcquisitionMode
            // 
            this.cbAcquisitionMode.FormattingEnabled = true;
            this.cbAcquisitionMode.Location = new System.Drawing.Point(225, 99);
            this.cbAcquisitionMode.Name = "cbAcquisitionMode";
            this.cbAcquisitionMode.Size = new System.Drawing.Size(121, 23);
            this.cbAcquisitionMode.TabIndex = 13;
            // 
            // cbTriggerMode
            // 
            this.cbTriggerMode.FormattingEnabled = true;
            this.cbTriggerMode.Location = new System.Drawing.Point(225, 59);
            this.cbTriggerMode.Name = "cbTriggerMode";
            this.cbTriggerMode.Size = new System.Drawing.Size(121, 23);
            this.cbTriggerMode.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Exposure Time(us)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Acquisition Mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Trigger Mode";
            // 
            // Form_AcquisitionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 638);
            this.Controls.Add(this.nudExposureTime);
            this.Controls.Add(this.cbTrigerSource);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbAcquisitionMode);
            this.Controls.Add(this.cbTriggerMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_AcquisitionControl";
            this.Text = "Form_AcquisitionControl";
            ((System.ComponentModel.ISupportInitialize)(this.nudExposureTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudExposureTime;
        private System.Windows.Forms.ComboBox cbTrigerSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbAcquisitionMode;
        private System.Windows.Forms.ComboBox cbTriggerMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}