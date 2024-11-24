namespace VisualInspection
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TsmnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmnApp = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmnBarCode = new System.Windows.Forms.ToolStripMenuItem();
            this.其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建作业ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BtRunJob = new System.Windows.Forms.Button();
            this.cogRecordDisplay1 = new Cognex.VisionPro.CogRecordDisplay();
            this.BtGraphicTool = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmnOpen,
            this.新建作业ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1195, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TsmnOpen
            // 
            this.TsmnOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmnApp});
            this.TsmnOpen.Name = "TsmnOpen";
            this.TsmnOpen.Size = new System.Drawing.Size(51, 24);
            this.TsmnOpen.Text = "打开";
            this.TsmnOpen.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // TsmnApp
            // 
            this.TsmnApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmnBarCode,
            this.其他ToolStripMenuItem});
            this.TsmnApp.Name = "TsmnApp";
            this.TsmnApp.Size = new System.Drawing.Size(144, 26);
            this.TsmnApp.Text = "选择应用";
            // 
            // TsmnBarCode
            // 
            this.TsmnBarCode.AutoSize = false;
            this.TsmnBarCode.Name = "TsmnBarCode";
            this.TsmnBarCode.Size = new System.Drawing.Size(181, 26);
            this.TsmnBarCode.Text = "条码检测";
            this.TsmnBarCode.Click += new System.EventHandler(this.TsmnBarCode_Click);
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.其他ToolStripMenuItem.Text = "其他";
            this.其他ToolStripMenuItem.Click += new System.EventHandler(this.其他ToolStripMenuItem_Click);
            // 
            // 新建作业ToolStripMenuItem
            // 
            this.新建作业ToolStripMenuItem.Name = "新建作业ToolStripMenuItem";
            this.新建作业ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.新建作业ToolStripMenuItem.Text = "新建作业";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // BtRunJob
            // 
            this.BtRunJob.Location = new System.Drawing.Point(945, 554);
            this.BtRunJob.Name = "BtRunJob";
            this.BtRunJob.Size = new System.Drawing.Size(137, 60);
            this.BtRunJob.TabIndex = 1;
            this.BtRunJob.Text = "执行作业";
            this.BtRunJob.UseVisualStyleBackColor = true;
            this.BtRunJob.Click += new System.EventHandler(this.BtRunJob_Click);
            // 
            // cogRecordDisplay1
            // 
            this.cogRecordDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogRecordDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogRecordDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogRecordDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogRecordDisplay1.Dock = System.Windows.Forms.DockStyle.Left;
            this.cogRecordDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogRecordDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogRecordDisplay1.Location = new System.Drawing.Point(0, 28);
            this.cogRecordDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogRecordDisplay1.MouseWheelSensitivity = 1D;
            this.cogRecordDisplay1.Name = "cogRecordDisplay1";
            this.cogRecordDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogRecordDisplay1.OcxState")));
            this.cogRecordDisplay1.Size = new System.Drawing.Size(676, 614);
            this.cogRecordDisplay1.TabIndex = 2;
            // 
            // BtGraphicTool
            // 
            this.BtGraphicTool.Location = new System.Drawing.Point(976, 358);
            this.BtGraphicTool.Name = "BtGraphicTool";
            this.BtGraphicTool.Size = new System.Drawing.Size(75, 23);
            this.BtGraphicTool.TabIndex = 3;
            this.BtGraphicTool.Text = "添加绘图";
            this.BtGraphicTool.UseVisualStyleBackColor = true;
            this.BtGraphicTool.Click += new System.EventHandler(this.BtGraphicTool_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1195, 642);
            this.Controls.Add(this.BtGraphicTool);
            this.Controls.Add(this.cogRecordDisplay1);
            this.Controls.Add(this.BtRunJob);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogRecordDisplay1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TsmnOpen;
        private System.Windows.Forms.ToolStripMenuItem 新建作业ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TsmnApp;
        private System.Windows.Forms.ToolStripMenuItem TsmnBarCode;
        private System.Windows.Forms.ToolStripMenuItem 其他ToolStripMenuItem;
        private System.Windows.Forms.Button BtRunJob;
        private Cognex.VisionPro.CogRecordDisplay cogRecordDisplay1;
        private System.Windows.Forms.Button BtGraphicTool;
    }
}

