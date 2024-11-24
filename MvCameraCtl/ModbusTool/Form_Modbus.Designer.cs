namespace ModbusTool
{
    partial class Form_Modbus
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
            this.GrpRtu = new System.Windows.Forms.GroupBox();
            this.BtOpen = new System.Windows.Forms.Button();
            this.CbbStopBits = new System.Windows.Forms.ComboBox();
            this.CbbDataBits = new System.Windows.Forms.ComboBox();
            this.CbbParity = new System.Windows.Forms.ComboBox();
            this.CbbBaudRate = new System.Windows.Forms.ComboBox();
            this.CbbPortName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RtbSendMsg = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RtbDisplay = new System.Windows.Forms.RichTextBox();
            this.BtSend = new System.Windows.Forms.Button();
            this.BtClear = new System.Windows.Forms.Button();
            this.GrpRtu.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpRtu
            // 
            this.GrpRtu.Controls.Add(this.BtOpen);
            this.GrpRtu.Controls.Add(this.CbbStopBits);
            this.GrpRtu.Controls.Add(this.CbbDataBits);
            this.GrpRtu.Controls.Add(this.CbbParity);
            this.GrpRtu.Controls.Add(this.CbbBaudRate);
            this.GrpRtu.Controls.Add(this.CbbPortName);
            this.GrpRtu.Controls.Add(this.label5);
            this.GrpRtu.Controls.Add(this.label4);
            this.GrpRtu.Controls.Add(this.label3);
            this.GrpRtu.Controls.Add(this.label2);
            this.GrpRtu.Controls.Add(this.label1);
            this.GrpRtu.Location = new System.Drawing.Point(12, 3);
            this.GrpRtu.Name = "GrpRtu";
            this.GrpRtu.Size = new System.Drawing.Size(291, 378);
            this.GrpRtu.TabIndex = 0;
            this.GrpRtu.TabStop = false;
            this.GrpRtu.Text = "RTU";
            // 
            // BtOpen
            // 
            this.BtOpen.Location = new System.Drawing.Point(177, 313);
            this.BtOpen.Name = "BtOpen";
            this.BtOpen.Size = new System.Drawing.Size(75, 29);
            this.BtOpen.TabIndex = 1;
            this.BtOpen.Text = "连接";
            this.BtOpen.UseVisualStyleBackColor = true;
            this.BtOpen.Click += new System.EventHandler(this.BtOpen_Click);
            // 
            // CbbStopBits
            // 
            this.CbbStopBits.FormattingEnabled = true;
            this.CbbStopBits.Location = new System.Drawing.Point(131, 248);
            this.CbbStopBits.Name = "CbbStopBits";
            this.CbbStopBits.Size = new System.Drawing.Size(121, 23);
            this.CbbStopBits.TabIndex = 13;
            // 
            // CbbDataBits
            // 
            this.CbbDataBits.FormattingEnabled = true;
            this.CbbDataBits.Location = new System.Drawing.Point(131, 194);
            this.CbbDataBits.Name = "CbbDataBits";
            this.CbbDataBits.Size = new System.Drawing.Size(121, 23);
            this.CbbDataBits.TabIndex = 12;
            // 
            // CbbParity
            // 
            this.CbbParity.FormattingEnabled = true;
            this.CbbParity.Location = new System.Drawing.Point(131, 143);
            this.CbbParity.Name = "CbbParity";
            this.CbbParity.Size = new System.Drawing.Size(121, 23);
            this.CbbParity.TabIndex = 11;
            // 
            // CbbBaudRate
            // 
            this.CbbBaudRate.FormattingEnabled = true;
            this.CbbBaudRate.Location = new System.Drawing.Point(131, 92);
            this.CbbBaudRate.Name = "CbbBaudRate";
            this.CbbBaudRate.Size = new System.Drawing.Size(121, 23);
            this.CbbBaudRate.TabIndex = 9;
            // 
            // CbbPortName
            // 
            this.CbbPortName.FormattingEnabled = true;
            this.CbbPortName.Location = new System.Drawing.Point(131, 41);
            this.CbbPortName.Name = "CbbPortName";
            this.CbbPortName.Size = new System.Drawing.Size(121, 23);
            this.CbbPortName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "数据位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "停止位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "波特率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "校验位";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口";
            // 
            // RtbSendMsg
            // 
            this.RtbSendMsg.Location = new System.Drawing.Point(12, 408);
            this.RtbSendMsg.Name = "RtbSendMsg";
            this.RtbSendMsg.Size = new System.Drawing.Size(376, 34);
            this.RtbSendMsg.TabIndex = 2;
            this.RtbSendMsg.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 462);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 15);
            this.label7.TabIndex = 16;
            // 
            // RtbDisplay
            // 
            this.RtbDisplay.Location = new System.Drawing.Point(12, 495);
            this.RtbDisplay.Name = "RtbDisplay";
            this.RtbDisplay.Size = new System.Drawing.Size(673, 181);
            this.RtbDisplay.TabIndex = 17;
            this.RtbDisplay.Text = "";
            // 
            // BtSend
            // 
            this.BtSend.Location = new System.Drawing.Point(404, 408);
            this.BtSend.Name = "BtSend";
            this.BtSend.Size = new System.Drawing.Size(75, 34);
            this.BtSend.TabIndex = 19;
            this.BtSend.Text = "发送";
            this.BtSend.UseVisualStyleBackColor = true;
            this.BtSend.Click += new System.EventHandler(this.BtSend_Click);
            // 
            // BtClear
            // 
            this.BtClear.Location = new System.Drawing.Point(703, 495);
            this.BtClear.Name = "BtClear";
            this.BtClear.Size = new System.Drawing.Size(75, 27);
            this.BtClear.TabIndex = 21;
            this.BtClear.Text = "清空";
            this.BtClear.UseVisualStyleBackColor = true;
            this.BtClear.Click += new System.EventHandler(this.BtClear_Click);
            // 
            // Form_Modbus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 688);
            this.Controls.Add(this.BtClear);
            this.Controls.Add(this.BtSend);
            this.Controls.Add(this.RtbDisplay);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RtbSendMsg);
            this.Controls.Add(this.GrpRtu);
            this.Name = "Form_Modbus";
            this.Text = "Form_Modbus";
            this.Load += new System.EventHandler(this.Form_Modbus_Load);
            this.GrpRtu.ResumeLayout(false);
            this.GrpRtu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpRtu;
        private System.Windows.Forms.ComboBox CbbStopBits;
        private System.Windows.Forms.ComboBox CbbDataBits;
        private System.Windows.Forms.ComboBox CbbParity;
        private System.Windows.Forms.ComboBox CbbBaudRate;
        private System.Windows.Forms.ComboBox CbbPortName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtOpen;
        private System.Windows.Forms.RichTextBox RtbSendMsg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox RtbDisplay;
        private System.Windows.Forms.Button BtSend;
        private System.Windows.Forms.Button BtClear;
    }
}