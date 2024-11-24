using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using Tools.Protocol.Modbus;

namespace ModbusTool
{
    public partial class Form_Modbus : Form
    {
        private ModbusRTU ModbusRtu;
        string PortName;
        public Form_Modbus()
        {
            InitializeComponent();
        }


        #region FormEvent

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Modbus_Load(object sender, EventArgs e)
        {
            //设置可选串口
            CbbPortName.Items.AddRange(ModbusRTU.GetPortNames());
            //设置可选波特率
            CbbBaudRate.Items.AddRange(new object[] { 9600, 19200 });
            //设置可选奇偶校验
            CbbParity.Items.AddRange(new object[] { "None", "Odd", "Even", "Mark", "Space" });
            //设置可选数据位
            CbbDataBits.Items.AddRange(new object[] { 5, 6, 7, 8 });
            //设置可选停止位
            CbbStopBits.Items.AddRange(new object[] { 1, 1.5, 2 });

            //设置默认选中项
            CbbPortName.SelectedIndex = 1;
            CbbBaudRate.SelectedIndex = 0;
            CbbParity.SelectedIndex = 0;
            CbbDataBits.SelectedIndex = 3;
            CbbStopBits.SelectedIndex = 0;


            //设置为默认输入法，即为英文半角
            //tbxValue.ImeMode = ImeMode.Disable;

            BtSend.Enabled = false;
        }

        #endregion

        /*
        #region Event

        /// <summary>
        /// 接收消息的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">事件参数</param>
        private void ReceiveDataEvent(object sender, ReceiveDataEventArg e)
        {
            //在窗体上显示接收到的报文
            string msgStr = "";
            for (int i = 0; i < e.Data.Length; i++)
            {
                msgStr += e.Data[i].ToString("X2") + " ";
            }
            rbxRecMsg.Invoke(new Action(() => { rbxRecMsg.Text = msgStr; }));

            //如果是读取数据，则对接收到的消息进行解析
            if (!isWrite)
            {
                string result = "";

                if (isCoil)
                {
                    BitArray bitArray = AnalysisMessage.GetCoil(e.Data);

                    int count = Convert.ToInt32(nudCount.Value);

                    for (int i = 0; i < count; i++)
                    {
                        result += bitArray[i].ToString() + ",";
                    }
                }
                else
                {
                    List<short> list = AnalysisMessage.GetRegister(e.Data);

                    list.ForEach(m => { result += m.ToString() + ","; });
                }

                tbxValue.Invoke(new Action(() => { tbxValue.Text = result.Remove(result.LastIndexOf(","), 1); }));
            }
        }

        #endregion
        */
        #region Methods

        /// <summary>
        /// 获取窗体选中的奇偶校验
        /// </summary>
        /// <returns></returns>
        private Parity GetSelectedParity()
        {
            switch (CbbParity.SelectedItem.ToString())
            {
                case "Odd":
                    return Parity.Odd;
                case "Even":
                    return Parity.Even;
                case "Mark":
                    return Parity.Mark;
                case "Space":
                    return Parity.Space;
                case "None":
                default:
                    return Parity.None;
            }
        }

        /// <summary>
        /// 获取窗体选中的停止位
        /// </summary>
        /// <returns></returns>
        private StopBits GetSelectedStopBits()
        {
            switch (Convert.ToDouble(CbbStopBits.SelectedItem))
            {
                case 1:
                    return StopBits.One;
                case 1.5:
                    return StopBits.OnePointFive;
                case 2:
                    return StopBits.Two;
                default:
                    return StopBits.One;
            }
        }

        #endregion

        /// <summary>
        /// 连接和断开按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtOpen_Click(object sender, EventArgs e)
        {
            if (!ModbusRTU.Status)
            {
                DisplayRtb("连接中...");
                //串口号
                PortName = CbbPortName.SelectedItem.ToString();
                //波特率
                int baudrate = (int)CbbBaudRate.SelectedItem;
                //奇偶校验
                Parity parity = GetSelectedParity();
                //数据位
                int databits = (int)CbbDataBits.SelectedItem;
                //停止位
                StopBits stopBits = GetSelectedStopBits();

                //设定串口参数
                ModbusRtu = new ModbusRTU(PortName, baudrate, databits, parity, stopBits);
                ModbusRtu.Read = RecieveMsgHandler;
                //打开串口
                try
                {
                    ModbusRtu.Open();
                    DisplayRtb("连接成功");
                    Thread.Sleep(200);
                    //启用发送按钮
                    BtSend.Enabled = true;
                    BtOpen.BackColor = Color.Green;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
               
            }
            else
            {
                //关闭串口
                ModbusRtu.Close();
                DisplayRtb("已关闭");
                BtOpen.BackColor = Color.White;
                //禁用发送按钮
                BtSend.Enabled = false;
            }
            BtOpen.Text = ModbusRTU.Status ? "断开" : "连接";
        }


        private void RecieveMsgHandler(string message)
        {    
            DisplayRtb("接收:"+message);
        }

        private void BtSend_Click(object sender, EventArgs e)
        {
            ModbusRtu.Send(RtbSendMsg.Text);
            DisplayRtb("发送:" + RtbSendMsg.Text);
        }

        private void DisplayRtb(string msg)
        {
            string text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " ";
            text += PortName + " ";
            text += msg + Environment.NewLine;
            if (RtbDisplay.InvokeRequired)
            {
                RtbDisplay.Invoke(new EventHandler(delegate
                {
                    RtbDisplay.Text += text;
                }));
            }else
            {
                RtbDisplay.Text += text;
            }
        }

        private void BtClear_Click(object sender, EventArgs e)
        {
            RtbDisplay.Clear();
        }
    }
}