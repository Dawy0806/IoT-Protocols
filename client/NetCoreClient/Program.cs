using NetCoreClient.Interfacce;
using NetCoreClient.Protocols;
using NetCoreClient.SendData;
using NetCoreClient.Sensors;

// define sensors
List<ISensorJson> sensors = new();
sensors.Add(new PacchettoDati());


// define protocol
IProtocol protocol = new Http("http://localhost:8011/drones/123");


// send data to server
while (true)
{
    foreach (ISensorJson sensor in sensors)
    {

        var sensorValue = sensor.ToJson();

        protocol.Send(sensorValue);

        Console.WriteLine("Data sent: " + sensorValue);

        Thread.Sleep(1000);
    }

}