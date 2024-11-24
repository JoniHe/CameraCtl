using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Tools.Func
{
    class Transforme
    {
        /// <summary>
        ///     字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString">Hex字符串</param>
        /// <returns></returns>
        public static byte[] StringToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if (hexString.Length % 2 != 0)
                hexString += " ";
            var returnBytes = new byte[hexString.Length / 2];
            for (var i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        /// <summary>
        ///     字符串转换为Hex字符串
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="encode">编码类型</param>
        /// <returns></returns>
        public static string StringToHexString(string s, Encoding encode)
        {
            var b = encode.GetBytes(s); //按照指定编码将string编程字节数组
            return b.Aggregate(string.Empty, (current, t) => current + "%" + Convert.ToString(t, 16));
        }

        /// <summary>
        ///     Hex字符串转换为字符串
        /// </summary>
        /// <param name="hs">Hex字符串</param>
        /// <param name="encode">编码类型</param>
        /// <returns></returns>
        public static string HexStringToString(string hs, Encoding encode)
        {
            //以%分割字符串，并去掉空字符
            var chars = hs.Split(new[] { '%' }, StringSplitOptions.RemoveEmptyEntries);
            var b = new byte[chars.Length];
            //逐个字符变为16进制字节数据
            for (var i = 0; i < chars.Length; i++) b[i] = Convert.ToByte(chars[i], 16);

            //按照指定编码将字节数组变为字符串
            return encode.GetString(b);
        }

        /// <summary>
        ///     字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes">bytes</param>
        /// <returns></returns>
        public static string BytesToHexString(byte[] bytes)
        {
            const string returnStr = "";
            return bytes == null ? returnStr : bytes.Aggregate(returnStr, (current, t) => current + t.ToString("X2"));
        }

        /// <summary>
        /// 字节数组转16进制字符串：空格分隔
        /// </summary>
        /// <param name="byteDatas"></param>
        /// <returns></returns>
        public static string BytesToHexStringWithSpace(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(string.Format("{0:X2} ", bytes[i]));
            }
            return builder.ToString().Trim();
        }

            /// <summary>
            ///     将byte[]转换成int
            /// </summary>
            /// <param name="data">需要转换成整数的byte数组</param>
            public static int BytesToInt32(byte[] data)
        {
            //如果传入的字节数组长度小于4,则返回0
            if (data.Length < 4) return 0;

            //定义要返回的整数
            var num = 0;
            //如果传入的字节数组长度大于4,需要进行处理
            if (data.Length < 4) return num;
            //创建一个临时缓冲区
            var tempBuffer = new byte[4];
            //将传入的字节数组的前4个字节复制到临时缓冲区
            Buffer.BlockCopy(data, 0, tempBuffer, 0, 4);
            //将临时缓冲区的值转换成整数，并赋给num
            num = BitConverter.ToInt32(tempBuffer, 0);
            //返回整数
            return num;
        }

        /// <summary>
        ///     bytes数据转换为float类型
        /// </summary>
        /// <param name="data">byte数据</param>
        /// <returns></returns>
        public static float ValueConvertToFloat(byte[] data)
        {
            var shuju = BytesToHexString(data);
            var num = uint.Parse(shuju, NumberStyles.AllowHexSpecifier);
            var floatValues = BitConverter.GetBytes(num);
            return BitConverter.ToSingle(floatValues, 0);
        }

        /// <summary>
        ///     bytes数据转换为long类型
        /// </summary>
        /// <param name="data">byte数据</param>
        /// <returns></returns>
        public static long ValueConvertToLong(byte[] data)
        {
            var shuju = BytesToHexString(data);
            var num = ulong.Parse(shuju, NumberStyles.AllowHexSpecifier);
            return (long)num;
        }
    }
}
