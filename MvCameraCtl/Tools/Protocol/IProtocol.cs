using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Protocol
{
    interface IProtocol
    {
        void Open();
        void Close();
        void Send();
        void Recieve();
    }
}
