using NetCoreClient.Protocol;
using RabbitMQ.Client;
using System.Text;

namespace AmqpApp.Protocol
{
    public class Amqp : NetCoreClient.Interfacce.IProtocol
    {
        private string? _hostName;

        private IConnection _conn;

        public Amqp(string? hostName)
        {
            _hostName = hostName;
            _conn = GetConnection();
        }


        private IConnection GetConnection()
        {
            try
            {
                return new ConnectionFactory()
                {
                    HostName = _hostName,
                }
                .CreateConnection();
            }
            catch (Exception)
            {
                throw new Exception("Errore nella connesione");
            }
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
