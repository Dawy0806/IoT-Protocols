using RabbitMQ.Client;
using System.Text;

namespace NetCoreClient.Protocols
{
    public class Amqp : Interfacce.IProtocol
    {

        private string? _hostName;

        private ConnectionFactory? _client;
        private IConnection? _conn;
        //private IModel? _channel;
        public Amqp(string? hostName)
        {
            _hostName = hostName;
            _client = new ConnectionFactory()
            {
                HostName = _hostName,
            };
            _conn = _client.CreateConnection();
        }


        public void Send(string data)
        {
            using (var channel = _conn?.CreateModel())
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
