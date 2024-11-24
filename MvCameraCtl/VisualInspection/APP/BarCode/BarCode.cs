using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro;
using Cognex.VisionPro.ID;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.ToolBlock;
using System.Windows.Forms;
using System.Drawing;

namespace VisualInspection.APP.BarCode
{
    class BarCodeJob : AppJob
    {
        //读码工具
        private CogIDTool IdTool;
        //图像转换工具
        private CogImageConvertTool ImageConvertTool;
        private CogToolBlock BlockTool;
        BarCodeParams BcParams;
        private CogRecordDisplay Display { get; set; }
        private ICogRegion Region { get; set; }
        public BarCodeJob()
        {


        }

        public BarCodeJob(BarCodeParams bcParams)
        {
            BcParams = bcParams;

        }

        public override void Setting(JobParams jobParams)
        {
            Display = jobParams.Display;
            Region = jobParams.Region;
        }

        private void BarCodeSetting(CogIDTool idTool, BarCodeParams bcParam)
        {
            if (bcParam.UseJob)
            {
                return;
            }
            switch (bcParam.BarcodeCategory)
            {
                case BarcodeCategory.BarCode:
                    idTool.RunParams.DisableAllCodes();
                    idTool.RunParams.Code128.Enabled = true;
                    break;
                case BarcodeCategory.QRCode:
                    idTool.RunParams.DisableAllCodes();
                    idTool.RunParams.QRCode.Enabled = true;
                    break;
                case BarcodeCategory.DataMatrix:
                    idTool.RunParams.DisableAllCodes();
                    idTool.RunParams.DataMatrix.Enabled = true;
                    break;
            }

            idTool.RunParams.ProcessingMode = (CogIDProcessingModeConstants)BcParams.AlgorithmType;
            if (Region != null)
            {
                IdTool.Region = Region;
            }

        }
        private void OnToolBlockRan(object sender, EventArgs e)
        {
        }

        //加载视觉工具
        public void InitVisionTool(string ToolPath)
        {
            try
            {
                IdTool = CogSerializer.LoadObjectFromFile(ToolPath) as CogIDTool;//加载视觉工具
                //BlockTool = CogSerializer.LoadObjectFromFile(ToolPath) as CogToolBlock;
                //IdTool = BlockTool.Tools["CogIDTool1"] as CogIDTool;

                BarCodeSetting(IdTool, BcParams);
                CogIDQRCodeModelConstants
                //CogIDTool IDCode = mToolBlock.Tools["CogIDTool1"] as CogIDTool;

                //订阅ToolBlock的Ran事件，当ToolBlock执行完毕后程序会执行这个回调函数。
                IdTool.Ran += new EventHandler(OnToolBlockRan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }//等待加载完成

        public void RunUseJob(Cognex.VisionPro.CogRecordDisplay display)
        {
            InitVisionTool(BcParams.JobPath);
            ImageConvertTool = new CogImageConvertTool();
            ImageConvertTool.InputImage = display.Image;
            ImageConvertTool.Run();
            //初始图像赋值给视觉工具
            IdTool.InputImage = ImageConvertTool.OutputImage;
            //ToolBlcok.Inputs["Image"].Value = display.Image;
            IdTool.Run();
            if (IdTool.RunStatus.Result != CogToolResultConstants.Accept)
            {
                MessageBox.Show(IdTool.RunStatus.Message.ToString());
                return;
            }
            DisplayRecord(IdTool.RunStatus, IdTool.CreateLastRunRecord(), display);
        }

        public void RunUnusedJob(Cognex.VisionPro.CogRecordDisplay display)
        {
            /*
            ImageConvertTool = new CogImageConvertTool();
            ImageConvertTool.InputImage = display.Image;
            ImageConvertTool.Run();
            //初始图像赋值给视觉工具
            IdTool.InputImage = ImageConvertTool.OutputImage;
            */
            IdTool.InputImage = display.Image;
            BarCodeSetting(IdTool, BcParams);
            IdTool.Run();
            DisplayRecord(IdTool.RunStatus,IdTool.CreateLastRunRecord(),display);
        }

        private void DisplayRecord(ICogRunStatus status, ICogRecord record, Cognex.VisionPro.CogRecordDisplay display)
        {
            CogGraphicLabel label = new CogGraphicLabel();
            label.Font = new Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Point);
            label.Alignment = CogGraphicLabelAlignmentConstants.BottomLeft;
            label.SelectedSpaceName = "#";
            if (status.Result != CogToolResultConstants.Accept || IdTool.Results.Count <= 0)
            {
                label.Color = CogColorConstants.Red;
                label.SetXYText(0, 400, "NG");
            }
            else
            {
                label.Color = CogColorConstants.Green;
                label.SetXYText(0, 400, "OK:" + IdTool.Results[0].DecodedData.DecodedString);
            }
            //display.Image = IdTool.InputImage;
            //获取结果图像（交互图层的图形）
            ICogGraphicInteractive regionGraphics = null;
            int index = display.InteractiveGraphics.FindItem("gu", Cognex.VisionPro.Display.CogDisplayZOrderConstants.Front);
            if (index != -1)
            {
                regionGraphics = display.InteractiveGraphics[index];
            }
            display.Record = IdTool.CreateLastRunRecord();
            if (regionGraphics != null)
            {
                display.InteractiveGraphics.Add(regionGraphics, "gu", false);
            }
            display.InteractiveGraphicTipsEnabled = true;
            display.DrawingEnabled = true;
            display.InteractiveGraphics.Add(label, "", false);
            //display.InteractiveGraphics.Add(label, "",false);
            //display.Image = IdTool.InputImage;
            //输出结果
            //return Convert.ToUInt32(MyToolBlcok.Outputs["OutputCount"].Value);//输出结果
        }


        public override void Run()
        {
            /*
            //清除交互图层显示
            display.InteractiveGraphics.Clear();
            //清除静态图层显示
            display.StaticGraphics.Clear();
            */
            IdTool = new CogIDTool();
            IdTool.Region = Region;

            if (BcParams.UseJob)
            {
                RunUseJob(Display);
            }
            else
            {
                RunUnusedJob(Display);

            }
        }


    }

}
