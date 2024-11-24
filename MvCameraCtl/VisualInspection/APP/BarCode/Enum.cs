using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInspection.APP.BarCode
{
    /// <summary>
    /// 算法类型
    /// </summary>
    public enum AlgorithmType
    {
        //适用于快速读取一些质量较好的具有较高对比度的码
        IDQuick,
        //适用于读取一些图像质量不好的码
        IDMax,
    }

    /// <summary>
    /// 条码类别
    /// </summary>
    public enum BarcodeCategory
    {
        //一维条码
        BarCode,
        //QR条码
        QRCode,
        //数据矩阵条码
        DataMatrix,
    }

    /// <summary>
    /// QR模式的选择
    /// </summary>
    public enum QRModel
    {
        //
        // 摘要:
        //     Specifies that symbols will be of the original QR Code version.
        Model1 = 1,
        //
        // 摘要:
        //     Specifies that symbols will be of the enhanced QR Code version.
        Model2 = 2,
        //
        // 摘要:
        //     Specifies that symbols will be of the MicroQR (reduced size) version.
        Micro = 4,
        //
        // 摘要:
        //     All: Model 1, Model 2 and Micro.
        All = 7
    } 
}

    /// <summary>
    /// 条码用途类型
    /// </summary>
    public enum BarcodeType
    {
        //产品序列号
        SN = 0,
        EAN = 1,
        IMEI1 = 2,
        IMEI2 = 3,
        //移动设备
        MEID = 4,
        MAC = 5
    }
}
