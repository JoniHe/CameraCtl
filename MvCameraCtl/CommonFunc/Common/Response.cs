using System;
using System.Collections.Generic;
using System.Text;

namespace CommonFunc.Common
{

    public class Response
    {
        public Response(int code, string msg, string data)
        {
            Code = code;
            Msg = msg;
            Data = data;
        }
        public override string ToString()
        {
            return string.Format("Error: [{0}] {1}.{2}", Code, Msg, Data);
        }

        public int Code;
        public string Msg;
        public string Data;
    }
}
