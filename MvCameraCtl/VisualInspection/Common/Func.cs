using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro;
using System.Windows.Forms;
using System.IO;

namespace VisualInspection.Common
{
    class Func
    {

        /// <summary>
        /// vpro读取文件到内存
        /// </summary>
        /// <param name="fileName">文件名（全路径）</param>
        /// <returns></returns>
        public static ICogImage ReadImage(string fileName)
        {
            ICogImage tempImage = null;
            using (CogImageFileTool tool = new CogImageFileTool())
            {
                tool.Operator.Open(fileName, CogImageFileModeConstants.Read);
                tool.Run();
                tempImage = tool.OutputImage;
            }
            return tempImage;
        }

        //矩形搜索区域
        public static CogRectangleAffine AffineSetting()
        {
            CogRectangleAffine affine = new CogRectangleAffine();//创建一个新的搜索区域
            affine.CenterX = 800;//设置搜索区域的圆点
            affine.CenterY = 800;
            affine.SideXLength = 500;//设置搜索区域的长宽

            affine.SideYLength = 500;
            return affine;
            //pmat.SearchRegion = affine;//应用搜索区域到工具中
        }

        public static CogImageCollection MultiImagesFilesDialogs()
        {
            CogImageCollection images = new CogImageCollection();
            using (FolderBrowserDialog lvse = new FolderBrowserDialog())                                        //打开本地文件夹
            {
                if (lvse.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo dinfo = new DirectoryInfo(lvse.SelectedPath);
                    FileInfo[] finfo = dinfo.GetFiles();
                    foreach (FileInfo file in finfo)
                    {   //将图片放入images容器中
                        images.Add(ReadImage(file.FullName));
                    }
                }
                return images;
            }
        }
    }
}
