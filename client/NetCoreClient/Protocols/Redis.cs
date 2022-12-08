using NetCoreClient.Interfacce;
using StackExchange.Redis;

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

        public async void Send(string data)
        {

            try
            {
                var db = _conn.GetDatabase();

                var dbConn = await db.PingAsync();

                await db.StringSetAsync(_key, data);

            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella connesione alla db");
            }
        }


        public async string ReadData()
        {
            try
            {
                var db = _conn.GetDatabase();

                var dbConn = await db.PingAsync();

                var value = await db.StringGetAsync(_key);

                return value.ToString();
                Console.WriteLine(value);
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella connesione alla db");
            }
        }
    }
}
