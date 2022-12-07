using RabbitMQ.Client;
using System.Text;

namespace NetCoreClient.Protocols
{
    public class Amqp : Interfacce.IProtocol
    {

        private string? _hostName;

        private IConnection? _conn;

        public Amqp(string? hostName)
        {
            _hostName = hostName;
            var client = new ConnectionFactory()
            {
                HostName = _hostName,
            };
            _conn = client.CreateConnection();
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
