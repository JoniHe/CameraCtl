using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Collections.Concurrent;
using System.Threading;
using System.Windows.Forms;
using Tools.Func;
using System.Collections;

namespace Tools.Protocol.Modbus
{
    public class ModbusRTU : IProtocol
    {
        private SerialPort SerialPort;
        private readonly object Locker = new object();//创建锁
        private readonly ConcurrentQueue<byte[]> MessageQueue;//用于异步消息处理队列
        private readonly EventWaitHandle MessageWaitHandle;
        private bool AsyncOp;//是否异步收发
        SerialDataReceivedEventHandler DataReceivehandler;
        public static bool Status { get; private set; }

        public delegate void RecieveMsgCallback(string message);
        public RecieveMsgCallback Read{ get; set; }
        public ModbusRTU(string portName, int baudRate, int dataBits, Parity parity, StopBits stopBits)
        {
            //MessageQueue = new ConcurrentQueue<byte[]>();
            //MessageWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            SerialPort = new SerialPort();
            //串口名
            SerialPort.PortName = portName;
            //波特率
            SerialPort.BaudRate = baudRate;
            //校验位
            SerialPort.Parity = parity;
            //数据位
            SerialPort.DataBits = dataBits;
            //停止位
            SerialPort.StopBits = stopBits;

            // Set the read / write timeouts
            SerialPort.ReadTimeout = 500;
            SerialPort.WriteTimeout = 500;

            // Set read / write buffer Size，the default of value is 1MB
            SerialPort.ReadBufferSize = 1024 * 1024;
            SerialPort.WriteBufferSize = 1024 * 1024;
            AsyncOp = false;

        }

        /// <summary>
        /// 打开串口
        /// </summary>
        public void Open()
        {
            try
            {
                if (SerialPort.IsOpen) SerialPort.Close();
                SerialPort.Open();
                Status = true;
                // Discard Buffer
                SerialPort.DiscardInBuffer();
                SerialPort.DiscardOutBuffer();

                if (AsyncOp)
                {
                    DataReceivehandler = AsyncPushMessage;
                }
                else
                {
                    DataReceivehandler = SyncPushMessage;
                }

                SerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivehandler);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw new Exception("打开串口"+ SerialPort.PortName+"失败");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        private void AnalyseMsg(byte[] buffer)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SyncPushMessage(object sender, SerialDataReceivedEventArgs e)
        {
            if (SerialPort.IsOpen == false) return;
            int length = SerialPort.BytesToRead;
            byte[] buffer = new byte[length];
            if (length <= 0) return;
            SerialPort.Read(buffer, 0, length);
            BitArray bitArray = MessageRTU.GetCoil(buffer);
            Read(Transforme.BytesToHexStringWithSpace(buffer));
        }

        /// <summary>
        /// 异步处理先存入队列然后使用其他工作线程处理接收的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AsyncPushMessage(object sender, SerialDataReceivedEventArgs e)
        {
            lock (Locker)
            {
                if (SerialPort.IsOpen == false) return;
                int length = SerialPort.BytesToRead;
                byte[] buffer = new byte[length];
                if (length <= 0) return;
                SerialPort.Read(buffer, 0, length);
                MessageQueue.Enqueue(buffer);
                MessageWaitHandle.Set();
            }
        }


        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            SerialPort.DataReceived -= DataReceivehandler;
            if (SerialPort.IsOpen) SerialPort.Close();
            Status = false;
        }


        public void Send()
        { }
        /// <summary>
        /// 发送消息（字符串）
        /// </summary>
        /// <param name="data"></param>
        public void Send(string data)
        {
            var buffer = Transforme.StringToHexByte(data);
            try
            {
                SerialPort.Write(buffer, 0, buffer.Length); 

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        public void Send(byte[] buffer, int offset, int count)
        {
            if (AsyncOp) lock (Locker)
                {
                    //异常测试
                    SerialPort.Write(buffer, offset, count);
                }
        }

        public void Recieve()
        { }



        #region Static
        /// <summary>
        /// 获取当前计算机的串行端口名的数组
        /// </summary>
        /// <returns></returns>
        public static string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }
        #endregion



        /// <summary>
        /// 获取串口接受到的内容
        /// </summary>
        /// <param name="millisecondsToTimeout">取消息的超时时间</param>
        /// <returns>返回byte数组</returns>
        public byte[] TryMessage(int millisecondsToTimeout = -1)
        {
            if (MessageQueue.Count > 0 && MessageQueue.TryDequeue(out var message))
            {
                return message;
            }
            else
            {
                Console.WriteLine("1");
            }

            if (MessageWaitHandle.WaitOne(millisecondsToTimeout))
            {
                if (MessageQueue.TryDequeue(out message))
                {
                    return message;
                }
                else
                {
                    Console.WriteLine("2");
                }
            }
            return null;
        }

        /// <summary>
        /// 异步线程处理接收消息
        /// </summary>
        private void StartReceive()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var buffer = TryMessage();
                    if (buffer == null) continue;

                    //添加业务逻辑
                }
            }, TaskCreationOptions.LongRunning);
        }
    }
}