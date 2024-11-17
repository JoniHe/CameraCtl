using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using MvCameraControl;
using System.Windows.Forms;

namespace CommonFunc.Camera.MvCamera
{
    public class MvErrorCode
    {
        public MvErrorCode()
        {

        }

        public static void ShowMsg(int code,string data)
        {
            string msg;
            if (code == 0)
            {
                msg = data;
            }
            else
            {
                msg = String.Format("Error[{0}]:", code);
            }


            switch (code)
            {
                case MvError.MV_E_HANDLE: msg += " Error or invalid handle "; break;
                case MvError.MV_E_SUPPORT: msg += " Not supported function "; break;
                case MvError.MV_E_BUFOVER: msg += " Cache is full "; break;
                case MvError.MV_E_CALLORDER: msg += " Function calling order error "; break;
                case MvError.MV_E_PARAMETER: msg += " Incorrect parameter "; break;
                case MvError.MV_E_RESOURCE: msg += " Applying resource failed "; break;
                case MvError.MV_E_NODATA: msg += " No data "; break;
                case MvError.MV_E_PRECONDITION: msg += " Precondition error, or running environment changed "; break;
                case MvError.MV_E_VERSION: msg += " Version mismatches "; break;
                case MvError.MV_E_NOENOUGH_BUF: msg += " Insufficient memory "; break;
                case MvError.MV_E_UNKNOW: msg += " Unknown error "; break;
                case MvError.MV_E_GC_GENERIC: msg += " General error "; break;
                case MvError.MV_E_GC_ACCESS: msg += " Node accessing condition error "; break;
                case MvError.MV_E_ACCESS_DENIED: msg += " No permission "; break;
                case MvError.MV_E_BUSY: msg += " Device is busy, or network disconnected "; break;
                case MvError.MV_E_NETER: msg += " Network error "; break;
            }

            MessageBox.Show(msg, "PROMPT");
        }
    }

    public enum MvEnumError
    {
        [Description("OK")] MV_SUCCESS = 0x0,
        [Description("获取枚举设备信息错误")] MV_ERROR_ENUM_DEVICE = 0x001001,
        [Description("获取设备句柄错误")] MV_ERROR_DEVICE_HANDLE = 0x001002,
        [Description("打开相机错误")] MV_ERROR_OPEN_DEVICE = 0x001003,
        [Description("关闭相机错误")] MV_ERROR_CLOSE_DEVICE = 0x001004,
    }
}
