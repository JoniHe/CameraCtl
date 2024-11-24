using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualInspection.APP.BarCode;
using VisualInspection.APP;
using Cognex.VisionPro;
using VisualInspection.Common;
using Cognex.VisionPro.ID;
namespace VisualInspection
{
    public partial class Form_Main : Form
    {
        private Form_BarCodeSetting FormBarCodeSetting;
        private AppType AppType;
        private RectangleTool RectangleTool;
        ICogRegion Region;
        AppJob Job;
        public Form_Main()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 应用菜单栏互斥
        /// </summary>
        /// <param name="sender"></param>        
        private void AppSingleCheck(object sender)
        {
            TsmnBarCode.Checked = false;
            其他ToolStripMenuItem.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
        }


        public Cognex.VisionPro.CogRecordDisplay GetDisplay()
        {
            return cogRecordDisplay1;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void TsmnBarCode_Click(object sender, EventArgs e)
        {
            AppSingleCheck(sender);
            FormBarCodeSetting = new Form_BarCodeSetting(this);
            FormBarCodeSetting.Show();
        }

        private void 其他ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppSingleCheck(sender);
        }


        private void CreatJob()
        {

            switch (AppType)
            {
                case AppType.BarCode:
                    Job = new BarCodeJob(FormBarCodeSetting.BcParams);

                    break;
                case AppType.Other:
                    break;
            }

        }
        private void BtRunJob_Click(object sender, EventArgs e)
        {
            cogRecordDisplay1.InteractiveGraphics.Clear();
            CreatJob();
            JobParams jobParams;
            jobParams.Region = Region;
            jobParams.Display = cogRecordDisplay1;
            Job.Setting(jobParams);
            Job.Run();
        }

        private void cogBarcodeEditV21_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 绘图区域位置大小改变事件函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GraphicsChanged(object sender, CogChangedEventArgs e)
        {
            Region = RectangleTool.Rectangle;
            JobParams jobParams;
            jobParams.Display = cogRecordDisplay1;
            jobParams.Region = Region;
            CreatJob();
            Job.Setting(jobParams);
            Job.Run();
        }

        private void BtGraphicTool_Click(object sender, EventArgs e)
        {
            RectangleTool = new RectangleTool();
            RectangleTool.AddDisplayGraphics(cogRecordDisplay1, GraphicsChanged);
        }
    }
}
