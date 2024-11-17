using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonFunc.Camera.WinForms;
using System.Collections.Generic;

namespace CommonFuncTest
{
    [TestClass]
    public class FormPanelTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bigCities = new List<string>()
                    {
                        "New York",
                        "London",
                        "Mumbai",
                        "Chicago"
                    };
            Form_CamFeature form = new Form_CamFeature(bigCities);
            form.ShowDialog();
        }
    }
}
