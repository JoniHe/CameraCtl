using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using CommonFunc.Common.WinformControl;
namespace CommonFuncTest
{
    public partial class Form_test1 : Form
    {
        public Form_test1()
        {
            InitializeComponent();
            ComboxDataBinder cbBinder = new ComboxDataBinder(comboBox1);
            cbBinder.DataBindingEnum<ColorEnum>(new ColorEnum());
            //cbBinder.DataBindingEnumDesc<E_ModuleType>();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    public enum E_ModuleType
    {
        [Description("YD-2040:电力监控仪表")]
        E_YD_2040 = 1,
        [Description("YD-2200:电力监控仪表")]
        E_YD_2200 = 2,
        [Description("HDESC-121:节能控制器")]
        E_HDESC121 = 3,
    }
}
