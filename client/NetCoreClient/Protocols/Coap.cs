using CoAPNet;
using CoAPNet.Udp;
using NetCoreClient.Interfacce;
using System.Text;

namespace NetCoreClient.Protocols
{
    class Coap : IProtocol
    {
        private CoapClient? _client;
        private string? _ip;
        private int _port;
        private ICoapEndpoint? _udpEndpoint;
        private string? _endpoint;
        private int _maxRetransmitAttempts;

        public Coap(string ip, int port, string endpoint)
        {
            _ip = ip;
            _port = port;
            _endpoint = endpoint;
            _udpEndpoint = new CoapUdpEndPoint(_ip, _port);
            _client = new CoapClient(_udpEndpoint);
            _maxRetransmitAttempts = _client.MaxRetransmitAttempts;
        }

        public async void Send(string data)
        {


            try
            {
                var message = new CoapMessage
                {
                    Code = CoapMessageCode.Post,
                    Type = CoapMessageType.Confirmable,
                    Payload = Encoding.UTF8.GetBytes(data),
                };

                message.SetUri(_endpoint);

                if (_maxRetransmitAttempts >= _client.MaxRetransmitAttempts)
                {
                    _maxRetransmitAttempts++;
                }
                _client.MaxRetransmitAttempts = _maxRetransmitAttempts;

                if (_client is not null)
                {
                    await _client.SendAsync(message, CancellationToken.None);

                    // Wait for the server to respond.
                    var response = await _client.ReceiveAsync(CancellationToken.None);

                    // Output our response
                    Console.WriteLine($"Received a response from {response.Endpoint}\n{Encoding.UTF8.GetString(response.Message.Payload)}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"errore {ex}");
            }


        }
    }
}