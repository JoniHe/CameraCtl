using System;
using System.Collections.Generic;
using System.Text;


public static void ShowMsg(int code, string msg, string detail)
{
    MessageBox.Show(string.Format("Error {0}:{1}.{2}"), code, msg, detail);
}