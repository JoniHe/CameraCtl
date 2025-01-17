using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Func.WinFormCtl;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Tools.Func.WinFormCtl;

namespace OpenCvDemo
{
    public partial class Main : Form
    {
        private Tools.Func.WinFormCtl.PictureBox Pb;
        public Main()
        {
            InitializeComponent();
        }

        private void BtLoadImage_Click(object sender, EventArgs e)
        {
            try
            {
                string path = MyDialogs.MyOpenFileDialogs("bmp图像|*.bmp|所有文件(*.*)|*.*");
                Mat srcImage = Cv2.ImRead(path, ImreadModes.GrayScale);

                //Cv2.ImShow("src image", image);
                //把Mat格式的图片转换成Bitmap
                Bitmap bitmap = BitmapConverter.ToBitmap(srcImage);
                PbIamge.Image = bitmap;

                Pb = new Tools.Func.WinFormCtl.PictureBox(PbIamge);
            }
            catch (Exception ex)
            {

            }
        }
        private void PbIamge_MouseWheel(object sender, MouseEventArgs e)
        {
            if(PbIamge.Image == null)
            {
                return;
            }
            //Pb.ChangePictureBoxSize(e);
            Pb.ResizeImageV2(e);
        }
    }

}
