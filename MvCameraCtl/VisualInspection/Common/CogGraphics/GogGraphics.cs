using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro;
namespace VisualInspection.Common
{
     interface IGogGraphics
    {
       void AddDisplayGraphics(CogRecordDisplay display,CogChangedEventHandler handler);
    }


    class RectangleTool: IGogGraphics
    {
        public CogRectangle Rectangle { get; set; }
        public RectangleTool()
        {

        }

        public void AddDisplayGraphics(CogRecordDisplay display,CogChangedEventHandler handle)
        {
            Rectangle = new CogRectangle();
            //设置用户交互属性
            Rectangle.GraphicDOFEnable = CogRectangleDOFConstants.All;
            //设置为 "*"，表示该图形可以在任何坐标空间中选择。
            //根图形放在同一空间坐标系，不然可能报   坐标空间目录树中无法找到给定的坐标空间名称
            Rectangle.SelectedSpaceName = "@";
            //设置为 true，表示该矩形是交互式的，用户可以与之进行交互。
            Rectangle.Interactive = true;
            //Rectangle.SetCenterWidthHeight(80, 80, 800, 300);
            /*
                X = 100, // 矩形左上角的X坐标
                Y = 100, // 矩形左上角的Y坐标
                Width = 200, // 矩形宽度
                Height = 150 // 矩形高度
             */
            display.InteractiveGraphics.Add((ICogGraphicInteractive)Rectangle, "gu", false);
            display.InteractiveGraphicTipsEnabled = true;
            //注册变更区域事件
            Rectangle.Changed += handle;
        }

    }

}


