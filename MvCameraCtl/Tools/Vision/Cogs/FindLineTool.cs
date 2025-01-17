using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;

namespace Tools.Vision.Cogs
{
    public struct Point
    {
        public double X;
        public double Y;
    }


    class FindLineTool
    {
        #region Private Member Variables
        private CogFindLineTool Tool;
        CogLineSegment LineSegment;
        #endregion


        public FindLineTool()
        {
            Tool = new CogFindLineTool();
        }
        public FindLineTool(string toolName)
        {
            Tool = new CogFindLineTool();
            Tool.Name = toolName;
        }

        public FindLineTool(string toolName,Point start,Point end)
        {
            Tool = new CogFindLineTool();
            Tool.Name = toolName;
            LineSegment = new CogLineSegment();

            //起点
            LineSegment.StartX = start.X;
            LineSegment.StartY = start.Y;
            //终点
            LineSegment.EndX = end.X;
            LineSegment.EndY = end.Y;

        }

        public void Setting()
        {
            Tool.CurrentRecordEnable = CogFindLineCurrentRecordConstants.All;
        }

        public void GraphicsDisplay(CogGraphicCollection gc)
        {
            CogLineSegment Region;
            CogGraphicCollection caliperRegions;
            ICogRecord record = Tool.CreateCurrentRecord();

            //卡尺区域
            caliperRegions = (CogGraphicCollection)record.SubRecords["InputImage"].SubRecords["CaliperRegions"].Content;
            for (int i = 0; i < caliperRegions.Count; i++)
            {
                gc.Add(caliperRegions[i]);
            }


            //预期线段
            //gc.Add(Tool.RunParams.ExpectedLineSegment);
        }
    }

}
