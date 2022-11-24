using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors
{
    class VirtualChargeSensor : IChargeSensor//, ISensorJson
    {
        private readonly Random Random;

        public VirtualChargeSensor()
        {
            Random = new Random();
        }

        public int Charge()
        {
            return new Charge(Random.Next(100)).Batteria;
            
        }
        public string GetSlug()
        {
            return "speed";
        }
        //public string ToJson()
        //{
        //    return JsonSerializer.Serialize(Charge());
        //}
    }
}
