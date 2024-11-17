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


namespace CommonFunc.Camera.WinForms
{
    public partial class Form_CamFeature : Form
    {
        public Form_CamFeature()
        {
            InitializeComponent();
        }

        public Form_CamFeature(List<string> devices)
        {
            InitializeComponent();
            DynamicTreeControl(devices);
        }

        private void DynamicTreeControl(List<string> devices)
        {

            foreach (string device in devices)
            {

                System.Windows.Forms.TreeNode nodeDevice = new System.Windows.Forms.TreeNode("device");
                nodeDevice.Name = device;
                nodeDevice.Text = device;


                System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("test1");
                System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("test2");
                treeNode1.Name = "AcquisitionControl";
                treeNode1.Text = "Acquisition Control";
                treeNode2.Name = "ImageFormatControl";
                treeNode2.Text = "Image Format Control";

                nodeDevice.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                treeNode1,treeNode2});

                trvwFeature.Nodes[0].Nodes.Add(nodeDevice);
            }

        }

        private void PanelSetting()
        {

        }
        private void Form_Cam_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trvwFeature_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PanelControl pnl = new PanelControl(pnlFeature);
            //有子节点展开
            
            if (e.Node.GetNodeCount(true) > 0 && e.Node.IsExpanded == false)
            {
                e.Node.Expand();
                return;
            }
            

            Form f = null;
            switch (e.Node.Name)
             {
                case "AcquisitionControl":
                    //MessageBox.Show(e.Node.Parent.Name);
                    f = new Form_AcquisitionControl();
                    break;
                case "ImageFormatControl":
                    f = new Form_ImageFormatControl();
                    break;
            }

            pnl.Control_Add(f);
            /*
            if (e.Node.Name == "AcquisitionControl")
            {
                Form_AcquisitionControl f = new Form_AcquisitionControl();
                pnl.Control_Add(f);
            }
            if (e.Node.Name == "ImageFormatControl")
            {
                Form_ImageFormatControl f = new Form_ImageFormatControl();
                pnl.Control_Add(f);
            }
            */

        }
    }
}
