using NetCoreClient.Interfacce;
using NetCoreClient.Protocols;
using NetCoreClient.SendData;
using NetCoreClient.Sensors;

// define sensors
List<ISensorJson> sensors = new();
sensors.Add(new PacchettoDati());


// define protocol
IProtocolInterface protocol = new Mqtt("127.0.0.1");


// send data to server
while (true)
{
    foreach (ISensorJson sensor in sensors)
    {

        var sensorValue = sensor.ToJson();

        protocol.Send(sensorValue, sensor.GetSlug());

        Console.WriteLine("Data sent: " + sensorValue);

        Thread.Sleep(1000);
    }

}