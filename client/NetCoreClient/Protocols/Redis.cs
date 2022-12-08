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
            _conn = GetConnection(_endPoint);
        }


        private IConnectionMultiplexer GetConnection(string? endpoint)
        {
            try
            {
                return ConnectionMultiplexer.ConnectAsync(
                                    new ConfigurationOptions()
                                    {
                                        EndPoints = { $"{endpoint}:{_port}" }
                                    }).Result;
            }catch(Exception)
            {
                throw new Exception("errore nella connesione");
            }
            
        }

        public void Send(string data)
        {

            try
            {
                var db = _conn.GetDatabase();
                var dbConn = db.PingAsync();
                db.StringSetAsync(_key, data);
            }
            catch (Exception)
            {
                throw new Exception("Errore nella connesione alla db");
            }
        }


        public async Task<string> ReadData()
        {
            try
            {
                var db = _conn.GetDatabase();

                var dbConn = await db.PingAsync();

                var value = db.StringGetAsync("key");
                
                if(value is not null)
                {
                    return value.Result;
                }
                else{
                    return null;
                }

            }
            catch (Exception)
            {
                throw new Exception("Errore nella connesione alla db");
            }
        }
    }
}
