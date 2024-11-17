using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvCameraControl;

namespace MvCameraCtl
{
    //全局变量
    public class CommonData
    {
        public static IDevice device = null;
    }

    // 常量定义
    public class MvConstants
    {
        public const string TriggerModeOn = "On";
        public const string TriggerModeOff = "Off";
        public const string AcquisitionCtlModeContinues = "Continuous";
        public const string AcquisitionCtlModeSingleFrame = "SingleFrame";
    }


}
