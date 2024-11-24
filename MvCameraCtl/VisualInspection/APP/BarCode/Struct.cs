using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInspection.APP.BarCode
{
    public struct BarCodeParams
    {
        public AlgorithmType AlgorithmType;
        public BarcodeCategory BarcodeCategory;
        public BarcodeType BarcodeType;
        //是否加载vpp作业
        public bool UseJob;
        public string JobPath;
        //相机取像源
        public bool CameraImage;    
        public string ImagePath;
    }
}
