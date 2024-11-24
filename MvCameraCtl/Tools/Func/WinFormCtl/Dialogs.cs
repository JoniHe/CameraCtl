using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools.Func.WinFormCtl
{
    public class MyDialogs
    {
        public static string MyOpenFileDialogs(string filter)
        {

            OpenFileDialog openFileDialogImage = new OpenFileDialog();
            openFileDialogImage.Filter = filter;
            DialogResult result = openFileDialogImage.ShowDialog();
            if (result == DialogResult.OK)
            {
                return openFileDialogImage.FileName;
            }
            MessageBox.Show("MyOpenFileDialogs failed!");
            return "";
        }

        public static string MyOpenDirDialogs()
        {

            FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            string DefaultfilePath = "";
            //设置对话框启动时的根目录,主要为C盘里的文件夹
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            //是否在对话框中设置”新建文件夹“按钮
            //FolderBrowserDialogImage.ShowNewFolderButton = true;
            if (DefaultfilePath != string.Empty)
            {
                //判断defaultfilePath是否为空，defaultfilePath不为空就可以直接赋值给SelectedPath,每次打开都可以到之前选择的位置
                folderBrowserDialog.SelectedPath = DefaultfilePath;

            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }
            MessageBox.Show("MyOpenDirDialogs failed!");
            return "";

        }

    }
}
