using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Tools.Func.WinFormCtl
{
    public class PictureBox
    {
        #region
        private System.Windows.Forms.PictureBox WPictureBox;
        Point MouseDownPoint = new Point(); //记录拖拽过程鼠标位置
        bool IsMove = false;    //判断鼠标在picturebox上移动时，是否处于拖拽过程(鼠标左键是否按下)
        private double Scaling;
        private Image SrcImage;

        private float Scale = 1;
        #endregion
        public PictureBox(System.Windows.Forms.PictureBox pictureBox)
        {
            WPictureBox = pictureBox;
            Init();
        }

        private void Init()
        {
            SrcImage = WPictureBox.Image;

            WPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            //WPictureBox.Width = WPictureBox.Image.Width;
            //WPictureBox.Height = WPictureBox.Image.Height;
        }

        public void ResizeImageV1(MouseEventArgs e)
        {
            {
                int x = e.Location.X;
                int y = e.Location.Y;
                int ow = WPictureBox.Width;
                int oh = WPictureBox.Height;
                int VX, VY;  //因缩放产生的位移矢量
                if (e.Delta > 0) //放大
                {

                    int width = Convert.ToInt32(WPictureBox.Width * 1.5);
                    int height = Convert.ToInt32(WPictureBox.Height * 1.5);
                    if (width * height > 45800000)
                        return;
                    WPictureBox.Width = width;
                    WPictureBox.Height = height;
                    PropertyInfo pInfo = WPictureBox.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                     BindingFlags.NonPublic);
                    Rectangle rect = (Rectangle)pInfo.GetValue(WPictureBox, null);

                    WPictureBox.Width = rect.Width;
                    WPictureBox.Height = rect.Height;
                }
                if (e.Delta < 0) //缩小
                {
                    //防止一直缩成负值
                    if (WPictureBox.Width < 100 || WPictureBox.Height < 100)
                        return;
                    WPictureBox.Width = WPictureBox.Width / 2;
                    WPictureBox.Height = WPictureBox.Height / 2;
                    PropertyInfo pInfo = WPictureBox.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
                     BindingFlags.NonPublic);
                    Rectangle rect = (Rectangle)pInfo.GetValue(WPictureBox, null);
                    WPictureBox.Width = rect.Width;
                    WPictureBox.Height = rect.Height;
                }
                //求因缩放产生的位移，进行补偿，实现锚点缩放的效果
                VX = (int)((double)x * (ow - WPictureBox.Width) / ow);
                VY = (int)((double)y * (oh - WPictureBox.Height) / oh);
                WPictureBox.Location = new Point(WPictureBox.Location.X + VX, WPictureBox.Location.Y + VY);

            }
        }


        public void ResizeImageV2(MouseEventArgs e)
        {

            Size srcImageSize = WPictureBox.Image.Size; //源图像大小
            Size dstImageSize = new Size(); //目标图像大小
            Point mousePoint = e.Location; //鼠标坐標

            //缩放倍率
            float scaleStep = e.Delta > 0 ? 1.1f : 0.9f;
            
            if ((e.Delta > 0 && Scale > 10) || (e.Delta < 0 && Scale < 0.1))
                return;
            Scale *= scaleStep;

            dstImageSize.Width = Convert.ToInt32(srcImageSize.Width * scaleStep);
            dstImageSize.Height = Convert.ToInt32(srcImageSize.Height * scaleStep);

            Bitmap dstImage = new Bitmap(dstImageSize.Width, dstImageSize.Height);
            dstImage.SetResolution(WPictureBox.Image.HorizontalResolution, WPictureBox.Image.VerticalResolution);


            Graphics gh = Graphics.FromImage(dstImage);
            gh.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gh.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gh.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            Rectangle dstRect = new Rectangle(0, 0, dstImageSize.Width, dstImageSize.Height);
            Rectangle srcRect = new Rectangle(0, 0, srcImageSize.Width, srcImageSize.Height);
            gh.DrawImage(WPictureBox.Image, dstRect, srcRect, GraphicsUnit.Pixel);
            gh.Dispose();

            WPictureBox.Image = dstImage;           
            WPictureBox.Refresh();
        }

        /// <summary>
        /// 按比例缩放
        /// </summary>
        /// <param name="e"></param>
        public void ResizeImageV3(MouseEventArgs e)
        {
            //最大缩放限制
            //if (WPictureBox.Height >= Screen.PrimaryScreen.Bounds.Height * 10 || WPictureBox.Height <= Screen.PrimaryScreen.Bounds.Height / 10)
            //    return;

            //当前图片的大小和位置
            Size curSize = WPictureBox.Image.Size;
            Point curLocation = WPictureBox.Location;

            //缩放后图片大小和位置
            Size newSize = new Size();
            Point newLocation = new Point();

            //缩放倍率
            float ratioStep = e.Delta > 0 ? 2f : 0.5f;


            newSize.Width = (int)(curSize.Width * ratioStep);
            newSize.Height = (int)(curSize.Height * ratioStep);

            newLocation.X = curLocation.X - (int)((newSize.Width - curSize.Width) * e.Location.X / curSize.Width);
            newLocation.Y = curLocation.Y - (int)((newSize.Height - curSize.Height) * e.Location.Y / curSize.Height);



            //设置图片的新大小和位置
            //WPictureBox.Size = newSize;
            //WPictureBox.Location = newLocation;

            Image newImage = new Bitmap(newSize.Width, newSize.Height);
            Graphics gh = Graphics.FromImage(newImage);

            //gh.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //gh.DrawImage(WPictureBox.Image,new Rectangle(0,0,newSize.Width,newSize.Height),new Rectangle(0,0,curSize.Width,curSize.Height),GraphicsUnit.Pixel);

            gh.ScaleTransform(ratioStep, ratioStep);
            gh.DrawImage(SrcImage, 0, 0);

            WPictureBox.Image = newImage;
            WPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            WPictureBox.Location = newLocation;
        }


        //鼠标按下功能
        public void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownPoint.X = Cursor.Position.X;
                MouseDownPoint.Y = Cursor.Position.Y;
                IsMove = true;
                WPictureBox.Focus();
            }
        }

        //鼠标松开功能
        public void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsMove = false;
            }
        }

        //鼠标移动功能
        public void MouseMove(object sender, MouseEventArgs e)
        {
            WPictureBox.Focus();
            if (IsMove)
            {
                int x, y;
                int moveX, moveY;
                moveX = Cursor.Position.X - MouseDownPoint.X;
                moveY = Cursor.Position.Y - MouseDownPoint.Y;
                x = WPictureBox.Location.X + moveX;
                y = WPictureBox.Location.Y + moveY;
                WPictureBox.Location = new Point(x, y);
                MouseDownPoint.X = Cursor.Position.X;
                MouseDownPoint.Y = Cursor.Position.Y;
            }
        }
    }
}
