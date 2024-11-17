using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonFunc.Common.WinformControl
{
    class PanelControl
    {
        public PanelControl(Panel panel)
        {
            this.PanelBackGround = panel;
        }


        public void PanelSetting()
        {

        }
        public void Control_Add(Form form)
        {
            PanelBackGround.Controls.Clear();    //移除所有控件
            form.TopLevel = false;      //设置为非顶级窗体
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //设置窗体为非边框样式
            form.Dock = System.Windows.Forms.DockStyle.Fill;                  //设置样式是否填充整个panel
            PanelBackGround.Controls.Add(form);        //添加窗体
            form.Show();                      //窗体运行
        }

        public Panel PanelBackGround { get; set; }
    }
}
