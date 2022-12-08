using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreClient.Interfacce
{
    public interface IProtocol
    {
        void Send(string data);
    }
}
