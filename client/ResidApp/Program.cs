using NetCoreClient.Interfacce;
using NetCoreClient.Sensors;
using ResidApp;
using ResidApp.Protocol;


// define protocol
//IProtocol protocol = new Http("http://localhost:8011/drones/123");
//IProtocol protocol = new Mqtt("5.tcp.eu.ngrok.io", "droni/", 14771);
//IProtocol protocol = new Mqtt("127.0.0.1", "droni/", 1883, TimeSpan.FromSeconds(2), "droni/error/");
IProtocol protocol = new Amqp("localhost");


// send data to server
while (true)
{
    //foreach (ISensorJson sensor in sensors)
    //{

    //    var sensorValue = sensor.ToJson();

    //    protocol.Send(sensorValue);

    //    Console.WriteLine("Data sent: " + sensorValue);

    //    Thread.Sleep(5000);
    //}
}

