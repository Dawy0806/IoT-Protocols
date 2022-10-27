using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors
{
    class VirtualHighnessSensor : IHighnessSensorInterface, ISensorInterface
    {
        private readonly Random Random;

        public VirtualHighnessSensor()
        {
            Random = new Random();
        }

        public int Highness()
        {
            return new Highness(Random.Next(100)).Altezza;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(new Highness(Random.Next(100)));
        }
    }
}
