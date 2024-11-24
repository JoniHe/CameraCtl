using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tools.Protocol.Modbus;
namespace ToolsTest
{
    [TestClass]
    public class ModbusTest
    {
        [TestMethod]
        public void TestModbus()
        {
            bool a = false;
            if(!a)
            {
                a = true;
            }

            Form_Modbus form = new Form_Modbus();
            form.ShowDialog();
        }
    }
}
