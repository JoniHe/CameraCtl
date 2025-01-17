using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using System.Windows.Forms;
using System.Drawing;

namespace Tools.Func.WinFormCtl
{
    public class CvDisplayGraphicsObject
    {
        public virtual void Reset(){ }
        public virtual void Dispose() { }
        public virtual void OnPaint(PaintEventArgs e, Size2d pixelSize) { }

        public virtual bool IsFocus(PointF pos)
        {
            return true;
        }

    }
}
