using RabbitMQ.Client;
using StackExchange.Redis;
using System.Text;

namespace AmqpApp.Protocol
{
    public class Amqp : NetCoreClient.Interfacce.IProtocol
    {
        private string? _hostName;
        private IConnectionMultiplexer _redis;
        private IConnection _conn;

        public Amqp(string? hostName)
        {
            _hostName = hostName;
            var client = new ConnectionFactory()
            {
                HostName = _hostName,
            };
            _conn = client.CreateConnection();

            _redis = ConnectionMultiplexer.ConnectAsync(
                    new ConfigurationOptions()
                    {
                        EndPoints = { "localhost:6379" }
                    }).Result;
        }

        public void Send(string data)
        {


            using (var channel = _conn.CreateModel())
            {
                channel.QueueDeclare(
                        queue: "prova",
                        durable: false,
                        exclusive: false,
                        autoDelete: false
                    );

                var body = Encoding.UTF8.GetBytes(data);

                channel.BasicPublish(
                        exchange: "",
                        routingKey: "droni",
                        body: body
                    );
            }
        }
    }
}
