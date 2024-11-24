using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Tools.Protocol.Modbus
{
    public struct ReadRequest
    {
        //从机地址
        public byte Addr;
        //功能码
        public byte FeatureCode;
        //存储地址
        public byte[] StorageAddr;
        //读取几个数据
        public byte[] Length;
    }

    class MessageRTU
    {
        private static byte[] ReverseToBytes(short value)
        {
            //如果小端存储，BitConverter.GetBytes方法会返回低字节在前，高字节在后的字节数组   
            byte[] bytes = BitConverter.GetBytes(value);
            ////ModbusRTU则需要高字节在前，低字节在后，需要进行高低字节转换
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }


        public static void RecieveMsgHandler(byte[] receiveMsg)
        {
            //计算的校验码
            byte[] msgchecksum = CheckSum.CRC16(receiveMsg.Skip(0).Take(5).ToArray());


            //校验码验证
            if (Enumerable.SequenceEqual(receiveMsg.Skip(5).Take(2).ToArray(), msgchecksum))
            {
                char[] chr = Convert.ToString(BitConverter.ToInt16(receiveMsg, 3), 2).ToArray();
                Array.Reverse(chr);

                //获取线圈状态
                BitArray bitArray = new BitArray(receiveMsg.Skip(3).Take(2).ToArray());

                Console.WriteLine($"接收到消息的二进制：{new string(chr)}");
            }
        }

        public static byte[] GenerateReadMsg(short count)
        {
            //byte[] TxData = { 0x04, 0x03, 0x00, 0x03, 0x00, 0x01, 0x74, 0x5f };
            ReadRequest request;
            request.Addr = 1;
            request.FeatureCode = 5;
            request.StorageAddr = new byte[] { 0x01, 0x02};
            request.Length = ReverseToBytes(count);
            return CreateReadMsg(request);
        }

        /// <summary>
        /// 读取数据请求报文
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static byte[] CreateReadMsg(ReadRequest request)
        {
            //创建字节列表
            List<byte> list = new List<byte>();


            //站地址
            list.Add(request.Addr);
            //功能码
            list.Add(request.FeatureCode);

            //存储地址
            list.AddRange(request.StorageAddr);
            //读取数量
            list.AddRange(request.Length);

            //获取校验码并在最后放入
            list.AddRange(CheckSum.CRC16(list));
            return list.ToArray();
        }


        /// <summary>
        /// 生成报文
        /// </summary>
        /// <param name="addr">从站地址</param>
        /// <param name="startAdr">地址</param>
        /// <param name="value">写入值</param>
        /// <returns>写入单个线圈的报文</returns>
        private static byte[] GenerateMessage(int addr, short startAdr, bool value)
        {
            //创建字节列表
            List<byte> list = new List<byte>();

            //插入站地址及功能码
            list.Add((byte)addr);
            list.Add(0x05);

            byte[] start = ReverseToBytes(startAdr);
            //插入线圈地址
            list.Add(start[0]);
            list.Add(start[1]);

            //插入写入值
            list.Add((byte)(value ? 0xFF : 0x00));
            list.Add(0x00);

            //转换为字节数组
            byte[] result = list.ToArray();

            //计算校验码并拼接，返回最后的报文结果
            return result.Concat(CheckSum.CRC16(list)).ToArray();
        }




        /// <summary>
        /// 解析线圈数据
        /// </summary>
        /// <param name="receiveMsg">接收到的报文</param>
        /// <returns></returns>
        public static BitArray GetCoil(byte[] receiveMsg)
        {
            //获取线圈状态
            BitArray bitArray = new BitArray(receiveMsg.Skip(3).Take(Convert.ToInt32(receiveMsg[2])).ToArray());

            return bitArray;
        }
    }
}
