using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.Windows.Forms;
using System.Drawing;

namespace Tools.Func.WinFormCtl
{
    public class CvDisplayGraphicsMat : CvDisplayGraphicsObject
    {
        #region
        protected Mat image = null;
        public Mat Image
        {
            get
            {
                return image;
            }
            set
            {
                if (image != null)
                {
                    image.Dispose();
                }
                if (value != null)
                    image = new Mat(value, new Rect(0, 0, value.Width, value.Height));
                Reset();
            }
        }

        public Rect2d DispRect
        {
            get
            {
                return new Rect2d(DispOrigin, DispSize);
            }
        }

        public Size2d DispSize;
        private Point2d DispOrigin;

        #endregion


        public CvDisplayGraphicsMat()
        {
            DispSize = new Size2d(0, 0);
        }



        #region override


        public override void Reset()
        {
            base.Reset();
            if (Image != null)
            {
                DispSize = new Size2d(Image.Width, Image.Height);
            }
            else
                DispSize = new Size2d(0, 0);

        }
        public override void Dispose()
        {
            if (image != null)
            {
                image.Dispose();
            }
            base.Dispose();

        }

        public override void OnPaint(PaintEventArgs e, Size2d pixelSize)
        {
            Rect showMatRect = new Rect(); //需要裁减的图片范围
            System.Drawing.PointF drawImageStartPos = new System.Drawing.PointF(); //绘制showMatRect的起始点
            if (DispRect.X < 0)
            {
                //显示区域的起始点X不在屏幕内
                showMatRect.X = (int)(Math.Abs(DispRect.X) / pixelSize.Width);
                drawImageStartPos.X = (float)(showMatRect.X * pixelSize.Width + DispRect.X);
            }
            else
            {
                showMatRect.X = 0;
                drawImageStartPos.X = (float)DispRect.X;
            }
            showMatRect.Width = (int)((e.ClipRectangle.Width - drawImageStartPos.X) / pixelSize.Width) + 1;

            if (DispRect.Y < 0)
            {
                //显示区域的起始点Y不在屏幕内
                showMatRect.Y = (int)(Math.Abs(DispRect.Y) / pixelSize.Height);
                drawImageStartPos.Y = (float)(showMatRect.Y * pixelSize.Height + DispRect.Y);
            }
            else
            {
                showMatRect.Y = 0;
                drawImageStartPos.Y = (float)DispRect.Y;
            }
            showMatRect.Height = (int)((e.ClipRectangle.Height - drawImageStartPos.Y) / pixelSize.Height) + 1;


            AdjustMatRect(Image, ref showMatRect);//调整需要显示Mat区域，以免截取的区域超出图片范围

            using (Mat displayMat = new Mat(Image, showMatRect))
            {
                //计算截取区域需要显示在屏幕中的大小
                OpenCvSharp.Size drawSize = new OpenCvSharp.Size((int)(displayMat.Width * pixelSize.Width),
               (int)(displayMat.Height * pixelSize.Height));

                if (drawSize.Width < 1) drawSize.Width = 1;
                if (drawSize.Height < 1) drawSize.Height = 1;
                Mat resizeMat = new Mat();

                //以Nearest的方式缩放图片尺寸
                Cv2.Resize(displayMat, resizeMat, drawSize, 0, 0, InterpolationFlags.Nearest);

                //缩放完的图片直接画在控件上
                System.Drawing.Image drawImage = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(resizeMat);
                e.Graphics.DrawImage(drawImage, drawImageStartPos);
            }
        }

        public override bool IsFocus(PointF pos)
        {
            return DispRect.Contains(pos.X, pos.Y);
        }



        #endregion

        #region public method

        /// <summary>
        /// 根据需要显示的像素大小，重新计算图像显示的尺寸
        /// </summary>
        /// <param name="pixelSize"></param>
        public void ResizeDispRectWithPixcelSize(Size2d pixelSize)
        {
            if (Image == null)
                DispSize = new Size2d(0, 0);
            else
                DispSize = new Size2d(
                    Image.Width * pixelSize.Width, Image.Height * pixelSize.Height
                    );
        }

        /// <summary>
        /// 转换屏幕坐标为图片中的像素坐标
        /// </summary>
        /// <param name="pos">屏幕坐标</param>
        /// <param name="pixclSize">单像元尺寸</param>
        /// <returns></returns>
        public Point2d TransformPixelPostion(PointF pos, Size2d pixclSize)
        {
            Point2d res = new Point2d(-1, -1);
            if (IsFocus(pos))
            {
                res.X = (int)((pos.X - DispRect.X) / pixclSize.Width);
                res.Y = (int)((pos.Y - DispRect.Y) / pixclSize.Height);
            }
            return res;
        }
        #endregion

        #region protected method

        /// <summary>
        /// 调整显示的图片区域，以免截取的mat越界
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="rect"></param>
        protected void AdjustMatRect(Mat mt, ref Rect rect)
        {
            //调整XY坐标
            if (rect.X < 0)
                rect.X = 0;
            if (rect.X >= mt.Width)
                rect.X = mt.Width - 1;
            if (rect.Y < 0)
                rect.Y = 0;
            if (rect.Y >= mt.Height)
                rect.Y = mt.Height - 1;

            //调整长宽
            if (rect.Width + rect.X > mt.Width)
                rect.Width = mt.Width - rect.X;
            if (rect.Height + rect.Y > mt.Height)
                rect.Height = mt.Height - rect.Y;
        }
        #endregion
    }

}
