using NetCoreClient.Protocol;
using RabbitMQ.Client;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidApp.Protocol
{
    public class Amqp : NetCoreClient.Interfacce.IProtocol
    {
        private string? _hostName;

        private IConnection _conn;

        private Redis _redis;
        

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
            var dataRedis = _redis.ReadData();

            Console.WriteLine(dataRedis);

            using (var channel = _conn.CreateModel())
            {
                channel.QueueDeclare(
                        queue: "prova",
                        durable: false,
                        exclusive: false,
                        autoDelete: false
                    );

                var body = Encoding.UTF8.GetBytes(dataRedis);

                channel.BasicPublish(
                        exchange: "",
                        routingKey: "droni",
                        body: body
                    );
            }
        }
    }
}
