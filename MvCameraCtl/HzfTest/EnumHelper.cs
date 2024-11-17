using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using CommonFunc.Common;
using CommonFunc.Common.WinformControl;
using System.Collections.Generic;

namespace CommonFuncTest
{
    [TestClass]
    public class EnumHelper
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<Data> datas = new List<Data>();
            Data data1 = new Data() { Id = 0x01080001, Name = "Mono8" };
            Data data2 = new Data() { Id = 0x01100003, Name = "Mono10" };
            Data data3 = new Data() { Id = 0x010C0004, Name = "Mono10Packed" };
            datas.Add(data1);
            datas.Add(data2);
            datas.Add(data3);

            ComboxDataBinder cbBinder = new ComboxDataBinder(null);
            cbBinder.DataBindingObject(datas);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Form_test1 form = new Form_test1();
            form.ShowDialog();
            
        }

    }

    public enum MyColors
    {
        //不明确引用需指定命名空间
        [System.ComponentModel.Description("yuk!")] LightGreen = 0x012020,
        [System.ComponentModel.Description("nice :-)")] VeryDeepPink = 0x123456,
        [System.ComponentModel.Description("so what")] InvisibleGray = 0x456730,
        [System.ComponentModel.Description("no comment")] DeepestRed = 0xfafafa,
        [System.ComponentModel.Description("I give up")] PitchBlack = 0xffffff,
    }

    public enum ColorEnum
    {
        红色,
        蓝色,
        白色
    }

}
