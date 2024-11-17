using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;

namespace MvCameraCtl.Model
{
    public enum MvEnumError
    {
        [Description("打开相机错误")] MV_ERROR_OPEN_DEVICE = 0x001001,
        [Description("关闭相机错误")] MV_ERROR_CLOSE_DEVICE = 0x001002,
    }
}
