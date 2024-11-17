using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonFunc.Common.WinformControl;
using CommonFunc.Camera.MvCamera.Model.Enum;

namespace CommonFunc.Camera.WinForms
{
    public partial class Form_AcquisitionControl : Form
    {
        public Form_AcquisitionControl()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            //绑定枚举数据和desc
            ComboxDataBinder.DataBindingEnumDesc<AcquisitionMode>(cbAcquisitionMode);
            ComboxDataBinder.DataBindingEnumDesc<TriggerMode>(cbTriggerMode);
            ComboxDataBinder.DataBindingEnumDesc<TriggerSource>(cbTrigerSource);

        }
    }
}
