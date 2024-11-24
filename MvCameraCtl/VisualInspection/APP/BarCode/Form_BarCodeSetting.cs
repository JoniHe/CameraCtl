using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisualInspection.Common;
using Tools.Func.WinFormCtl;
using Cognex.VisionPro.ImageProcessing;

namespace VisualInspection.APP.BarCode
{
    public partial class Form_BarCodeSetting : Form
    {
        //文件夹对话框
        private FolderBrowserDialog FolderBrowserDialogImage;

        //文件对话框
        private OpenFileDialog OpenFileDialogImage;
        private string DefaultfilePath = string.Empty;
        Form_Main FormMain = null;
        public BarCodeParams BcParams;
        public Form_BarCodeSetting()
        {
            InitializeComponent();
            Init();
        }

        public Form_BarCodeSetting(Form_Main frm)
        {

            FormMain = frm;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            CbbDataBinder cbBinder = new CbbDataBinder(CbbBarcodeCategory);
            cbBinder.DataBindingEnum<BarcodeCategory>(new BarcodeCategory());
            CbbBarcodeCategory.SelectedIndex = 0;

            cbBinder.ComboBox = CbbAlgorithmType;
            cbBinder.DataBindingEnum<AlgorithmType>(new AlgorithmType());
            CbbAlgorithmType.SelectedIndex = 0;


            BcParams = new BarCodeParams();


            BcParams.ImagePath = "D:\\work\\images\\二维码.png";
            BcParams.JobPath = "D:\\work\\Vpp\\CogIdToolQR.vpp";
        }

        private void BtBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialogImage = new OpenFileDialog();
                OpenFileDialogImage.Filter = "png图像|*.png|bmp 图像|*.bmp";
                DialogResult result = OpenFileDialogImage.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TbImagePath.Text = OpenFileDialogImage.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtConfirm_Click(object sender, EventArgs e)
        {
            CogImageConvertTool ImageConvertTool = new CogImageConvertTool();
            ImageConvertTool.InputImage = Func.ReadImage(BcParams.ImagePath);
            ImageConvertTool.Run();
            //初始图像赋值给视觉工具
            FormMain.GetDisplay().Image = ImageConvertTool.OutputImage;
            FormMain.GetDisplay().Fit(true);
            this.Close();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtBrowseJob_Click(object sender, EventArgs e)
        {
            TbJobPath.Text = MyDialogs.MyOpenFileDialogs("*.vpp|*.vpp");
            BcParams.JobPath = TbJobPath.Text;
            BcParams.UseJob = true;
        }

        private void CbbBarcodeCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BcParams.BarcodeCategory = (BarcodeCategory)Enum.Parse(typeof(BarcodeCategory), CbbBarcodeCategory.SelectedValue.ToString());
        }





        /* 
       try
            {
                Cognex.VisionPro.ID.CogIDTool refTool = jobManager.JobWorkers[camid].subjobworkers[snapid].tool_barcodes[toolIndex];
                if (refTool != null)
                {
                    Form frm = new Form();
                    frm.Width = 1024; frm.Height = 768;

                    Cognex.VisionPro.ID.CogIDEditV2 CogIdEdit = new Cognex.VisionPro.ID.CogIDEditV2();

                    ((System.ComponentModel.ISupportInitialize)CogIdEdit).BeginInit();
                    CogIdEdit.Enabled = true;
                    CogIdEdit.Size = new System.Drawing.Size(1000, 600);
                    CogIdEdit.Location = new Point(0, 0);
                    frm.Controls.Add(CogIdEdit);
                    CogIdEdit.Dock = DockStyle.Fill;
                    ((System.ComponentModel.ISupportInitialize)CogIdEdit).EndInit();
                    refTool.InputImage = (Cognex.VisionPro.CogImage8Grey)jobManager.JobWorkers[camid].subjobworkers[snapid].Image;
                    CogIdEdit.Subject = refTool;

                    frm.Text = "相机 " + (camid + 1).ToString() + "第" + (snapid + 1).ToString() + "次拍照" + "读码工具" + (toolIndex + 1) + "设置";
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                    refTool = CogIdEdit.Subject;
                    try
                    {
                        CogIdEdit.Dispose();
                        frm.Dispose();
                    }
                    catch (Exception ex)
                    {
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         */



    }
}
