namespace CommonFunc.Camera.WinForms
{
    partial class Form_CamFeature
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Acquisition Control");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Image Format Control");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Feature Tree", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.trvwFeature = new System.Windows.Forms.TreeView();
            this.pnlFeature = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // trvwFeature
            // 
            this.trvwFeature.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.trvwFeature.Location = new System.Drawing.Point(12, 12);
            this.trvwFeature.Name = "trvwFeature";
            treeNode1.Name = "AcquisitionControl";
            treeNode1.Text = "Acquisition Control";
            treeNode2.Name = "ImageFormatControl";
            treeNode2.Text = "Image Format Control";
            treeNode3.Name = "FeatureTree";
            treeNode3.Text = "Feature Tree";
            this.trvwFeature.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.trvwFeature.Size = new System.Drawing.Size(183, 662);
            this.trvwFeature.TabIndex = 2;
            this.trvwFeature.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvwFeature_AfterSelect);
            // 
            // pnlFeature
            // 
            this.pnlFeature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFeature.Location = new System.Drawing.Point(286, 42);
            this.pnlFeature.Name = "pnlFeature";
            this.pnlFeature.Size = new System.Drawing.Size(384, 540);
            this.pnlFeature.TabIndex = 4;
            // 
            // Form_CamFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 704);
            this.Controls.Add(this.pnlFeature);
            this.Controls.Add(this.trvwFeature);
            this.Name = "Form_CamFeature";
            this.Text = "Form_Cam";
            this.Load += new System.EventHandler(this.Form_Cam_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvwFeature;
        private System.Windows.Forms.Panel pnlFeature;
    }
}