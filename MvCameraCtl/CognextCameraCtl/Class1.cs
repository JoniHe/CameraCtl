#region namespace imports
using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Blob;
using System.Collections.Generic;
using System.Drawing;
#endregion

public class CogToolBlockAdvancedScript : CogToolBlockAdvancedScriptBase
{
    #region Private Member Variables

    private Cognex.VisionPro.ToolBlock.CogToolBlock mToolBlock;
    #endregion

    CogGraphicCollection GC = new CogGraphicCollection();
    CogGraphicLabel label = new CogGraphicLabel();

    CogFindLineTool ToolLineLeft;
    CogFindLineTool ToolLineUp;
    CogFindLineTool ToolLineRight;
    CogFindLineTool ToolLineDown;


    CogCircle blobRoi = new CogCircle();

    /// <summary>
    /// Called when the parent tool is run.
    /// Add code here to customize or replace the normal run behavior.
    /// </summary>
    /// <param name="message">Sets the Message in the tool's RunStatus.</param>
    /// <param name="result">Sets the Result in the tool's RunStatus</param>
    /// <returns>True if the tool should run normally,
    ///          False if GroupRun customizes run behavior</returns>
    public override bool GroupRun(ref string message, ref CogToolResultConstants result)
    {
        // To let the execution stop in this script when a debugger is attached, uncomment the following lines.
        // #if DEBUG
        // if (System.Diagnostics.Debugger.IsAttached) System.Diagnostics.Debugger.Break();
        // #endif


        GC.Clear();
        ToolLineLeft = mToolBlock.Tools["CogFindLineToolWidth"] as CogFindLineTool;
        ToolLineUp = mToolBlock.Tools["CogFindLineToolWidth"] as CogFindLineTool;
        ToolLineRight = mToolBlock.Tools["CogFindLineToolWidth"] as CogFindLineTool;
        ToolLineDown = mToolBlock.Tools["CogFindLineToolWidth"] as CogFindLineTool;




        CogFindCircleTool findCircle = mToolBlock.Tools["CogFindCircleTool1"] as CogFindCircleTool;
        CogBlobTool bd = mToolBlock.Tools["CogBlobTool1"] as CogBlobTool;
        CogBlobResultCollection bds = bd.Results.GetBlobs();
        CogBlobResult item = bds[1];
        item.GetMeasure(CogBlobMeasureConstants.Area);
        //最小外接矩形宽度和高度
        double width = item.GetMeasure(CogBlobMeasureConstants.BoundingBoxExtremaAngleWidth);
        double height = item.GetMeasure(CogBlobMeasureConstants.BoundingBoxExtremaAngleHeight);


        double centerX = item.GetMeasure(CogBlobMeasureConstants.BoundingBoxExtremaAngleCenterX);
        double centerY = item.GetMeasure(CogBlobMeasureConstants.BoundingBoxExtremaAngleCenterY);



        //最小外接矩形
        CogRectangleAffine rectangleAffine = item.GetBoundingBox(CogBlobAxisConstants.Principal);
        double degrees = CogMisc.RadToDeg(1.57);
        GC.Add(rectangleAffine);
        CogRectangle m_rectangle = new CogRectangle();

        ToolLineLeft = CreateFindLineTool(rectangleAffine.CornerOriginX, rectangleAffine.CornerOriginY, rectangleAffine.CornerYX, rectangleAffine.CornerYY);
        ToolLineLeft.InputImage = mToolBlock.Inputs["OutputImage"].Value as CogImage8Grey ;
        ToolLineLeft.Run();
        ToolLineLeft.Results[0].CreateResultGraphics(CogFindLineResultGraphicConstants.CaliperRegion);

        //卡尺输出参数
        rectangleAffine = item.GetBoundingBoxAtAngle(item.Angle);

        RectangleF minBoundingRect = RotatingCalipers.FindMinimumBoundingRectangle(points);


        Show_Label(centerX, centerY, CogColorConstants.Green, null, "宽度:" + width.ToString() + " 高度:" + height.ToString());
        // Run each tool using the RunTool function
        foreach (ICogTool tool in mToolBlock.Tools)
            mToolBlock.RunTool(tool, ref message, ref result);

        blobRoi = findCircle.Results.GetCircle();


        double r = 265 / 3;//圆弧到边界的距离-3等分
        for (int i = 0; i < 3; i++)
        {
            CogCircle cc = new CogCircle();
            cc.CenterX = blobRoi.CenterX;
            cc.CenterY = blobRoi.CenterY;
            cc.Radius = blobRoi.Radius + i * r;
            cc.LineWidthInScreenPixels = 3;
            cc.Color = CogColorConstants.Blue;
            GC.Add(cc);
        }

        return false;
    }


    /// <summary>
    /// 找线工具
    /// </summary>
    /// <param name="startX"></param>
    /// <param name="startY"></param>
    /// <param name="endX"></param>
    /// <param name="endY"></param>
    /// <returns></returns>
    private CogFindLineTool CreateFindLineTool(double startX, double startY, double endX, double endY)
    {
        CogFindLineTool findLine = new CogFindLineTool();
        //卡尺输入参数
        //数量
        findLine.RunParams.NumCalipers = 100;
        //搜索长度
        findLine.RunParams.CaliperSearchLength = 60;
        //忽略点数
        findLine.RunParams.NumToIgnore = 10;
        //起点
        findLine.RunParams.ExpectedLineSegment.StartX = startX;
        findLine.RunParams.ExpectedLineSegment.StartY = startY;
        //终点
        findLine.RunParams.ExpectedLineSegment.EndX = endX;
        findLine.RunParams.ExpectedLineSegment.EndY = endY;
        findLine.RunParams.ExpectedLineSegment.SelectedColor = CogColorConstants.Blue;
        return findLine;
    }

    public static double DistanceBetweenPoints(double x1, double y1, double x2, double y2)
    {
        double dx = x2 - x1;
        double dy = y2 - y1;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    /// <summary>
    /// 绘制mark点
    /// </summary>
    private CogPointMarker CreateCircle(double pointMarkerX, double pointMarkerY, double Radius, CogColorConstants color)
    {
        CogPointMarker pointMarker = new CogPointMarker();//创建对象，点CogPointMarker                                                      //注意运行工具
        pointMarker.X = pointMarkerX;
        pointMarker.Y = pointMarkerY;//点坐标
        pointMarker.Color = color;//点颜色设置
        pointMarker.LineWidthInScreenPixels = 20;//点大小设置
        return pointMarker;
    }

    public void Show_Label(double x, double y, CogColorConstants color, Font font, string text)
    {
        CogGraphicLabel label = new CogGraphicLabel();
        label.Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft;
        label.BackgroundColor = CogColorConstants.Orange;//背景颜色
        label.SelectedSpaceName = "#";//显示的空间名称
        label.SetXYText(x, y, text);//显示坐标，以及输入内容
        label.Color = color;//字体颜色
        label.Font = font;//字体大小
        graphics_label.Add(label);//添加进入list
    }

    #region When the Current Run Record is Created
    /// <summary>
    /// Called when the current record may have changed and is being reconstructed
    /// </summary>
    /// <param name="currentRecord">
    /// The new currentRecord is available to be initialized or customized.</param>
    public override void ModifyCurrentRunRecord(Cognex.VisionPro.ICogRecord currentRecord)
    {
    }
    #endregion

    #region When the Last Run Record is Created
    /// <summary>
    /// Called when the last run record may have changed and is being reconstructed
    /// </summary>
    /// <param name="lastRecord">
    /// The new last run record is available to be initialized or customized.</param>
    public override void ModifyLastRunRecord(Cognex.VisionPro.ICogRecord lastRecord)
    {
        foreach (ICogGraphic cp in GC)
        {
            mToolBlock.AddGraphicToRunRecord(cp, lastRecord, "CogIPOneImageTool1.OutputImage", "");

        }
    }
    #endregion

    #region When the Script is Initialized
    /// <summary>
    /// Perform any initialization required by your script here
    /// </summary>
    /// <param name="host">The host tool</param>
    public override void Initialize(Cognex.VisionPro.ToolGroup.CogToolGroup host)
    {
        // DO NOT REMOVE - Call the base class implementation first - DO NOT REMOVE
        base.Initialize(host);


        // Store a local copy of the script host
        this.mToolBlock = ((Cognex.VisionPro.ToolBlock.CogToolBlock)(host));
    }
    #endregion

}

