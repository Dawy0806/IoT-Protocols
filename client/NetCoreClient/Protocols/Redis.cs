using NetCoreClient.Interfacce;
using StackExchange.Redis;
using System.Text.Json;

namespace NetCoreClient.Protocol
{
    public class Redis : IProtocol
    {
        private IConnectionMultiplexer _conn;
        private string? _endPoint;
        private int _port;
        private string? _key;

        public Redis(string? endPoint)
        {
            _endPoint = endPoint;
            _port = 6379;
            _key = "key";
            _conn = ConnectionMultiplexer.ConnectAsync(
                    new ConfigurationOptions()
                    {
                        EndPoints = { $"{_endPoint}:{_port}" }
                    }
                ).Result;
        }

        public void Send(string data)
        {

            try
            {
                var db = _conn.GetDatabase();
                var dbConn = db.PingAsync();
                db.StringSetAsync(_key, data);
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella connesione alla db");
            }
        }


        public string ReadData()
        {
            try
            {
                var db = _conn.GetDatabase();

                var dbConn = db.PingAsync();

                var value = db.StringGetAsync("key");
                Console.WriteLine("ciao come stai " + value.Result);
                return value.Result;

            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella connesione alla db");
            }
        }
    }
}
