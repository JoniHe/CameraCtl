using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualInspection.Common;

namespace VisualInspection.APP
{
    abstract class AppJob
    { 
        public AppJob()
        {
        }

        public abstract void Run();
        public abstract void Setting(JobParams jobParams);
    }

    public struct JobParams
    {
        public Cognex.VisionPro.CogRecordDisplay Display;
        public Cognex.VisionPro.ICogRegion Region;
    }
}
