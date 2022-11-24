using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors
{
    class VirtualSpeedSensor : ISpeedSensor//, ISensorJson
    {
        private readonly Random Random;

        public VirtualSpeedSensor()
        {
            Random = new Random();
        }

        public int Speed()
        {
            return new Speed(Random.Next(100)).Velocita;
        }
        public string GetSlug()
        {
            return "Speed";
        }
        //public string ToJson()
        //{
        //    return JsonSerializer.Serialize(Speed());
        //}
    }
}
