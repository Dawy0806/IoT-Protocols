
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoAPNet;
using CoAPNet.Udp;
using NetCoreClient.Interfacce;

namespace NetCoreClient.Protocols
{
    class Coap : IProtocol
    {

        private CoapClient? _coap;
        private string? _endpoint;

        public Coap(string endPoint)
        {
            _endpoint = endPoint;
            _coap = new CoapClient(new CoapUdpEndPoint(_endpoint));
        }

        public void Send(string data)
        {
            
        }
    }
}