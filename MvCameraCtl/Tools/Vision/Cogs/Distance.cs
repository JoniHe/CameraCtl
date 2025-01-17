using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro;

namespace Tools.Vision.Cogs
{
    class Distance
    {

        public static double DistanceSegmentSegment(CogImage8Grey image,CogLineSegment a,CogLineSegment b)
        {
            CogDistanceSegmentSegmentTool tool = new CogDistanceSegmentSegmentTool();
            tool.InputImage = image;
            tool.SegmentA = a;
            tool.SegmentB = b;
            tool.Run();
            return tool.Distance;
        }
    }
}
