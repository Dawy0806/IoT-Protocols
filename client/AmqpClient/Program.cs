using AmqpApp.Protocol;
using NetCoreClient.Interfacce;
using NetCoreClient.Protocol;
using StackExchange.Redis;


// define protocol
//IProtocol protocol = new Http("http://localhost:8011/drones/123");
//IProtocol protocol = new Mqtt("5.tcp.eu.ngrok.io", "droni/", 14771);
//IProtocol protocol = new Mqtt("127.0.0.1", "droni/", 1883, TimeSpan.FromSeconds(2), "droni/error/");
IProtocol protocol = new Amqp("localhost");
Redis redis = new Redis("localhost");

// send data to server
while (true)
{

    var data = await redis.ReadData();

    protocol.Send(data);

    Console.WriteLine("Data sent: " + data);

    Thread.Sleep(5000);
}

