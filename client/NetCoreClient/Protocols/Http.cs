using NetCoreClient.Interfacce;
using System.Net;

namespace NetCoreClient.Protocols
{
    class Http : IProtocol
    {
        private string Endpoint;
        private HttpClient _client;
        public Http(string endpoint)
        {
            this.Endpoint = endpoint;
            _client = new HttpClient();
        }
        public async void Send(string data)
        {
            if (_client is not null)
            {
                var result = await _client.PostAsync(Endpoint, new StringContent(data));
                Console.Out.WriteLine(result.StatusCode);
            }
        }
    }
}
