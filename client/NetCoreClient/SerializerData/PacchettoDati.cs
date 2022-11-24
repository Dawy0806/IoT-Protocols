using NetCoreClient.Sensors;
using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.SendData
{
    public class PacchettoDati : ISensorJson
    {
        public string GetSlug()
        {
            throw new NotImplementedException();
        }

        public string ToJson()
        {
            var data = new {

                position = new VirtualPositonSensor().Position(),
                speed = new VirtualSpeedSensor().Speed(),
                temperature = new VirtualTemperatureSensor().Temperature(),
                highness = new VirtualHighnessSensor().Highness(),
                charge = new VirtualChargeSensor().Charge()
            };

            return JsonSerializer.Serialize(data);

        }
    }
}
