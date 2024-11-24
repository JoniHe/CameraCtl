using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualInspection.Common
{
    public struct AffineParams
    {
        //原点X Y坐标
        double CenterX;
        double CenterY;
        //设置搜索区域的长宽
        double SideXLength;
        double SideYLength;
    }
}
