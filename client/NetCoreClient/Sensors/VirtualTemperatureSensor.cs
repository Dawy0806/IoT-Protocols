using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors
{
    class VirtualTemperatureSensor : ITemperatureSensor//, ISensorJson
    {
        private readonly Random Random;

        public VirtualTemperatureSensor()
        {
            Random = new Random();
        }

        public double[] Temperature()
        {
            double a = Random.NextDouble();
            double b = Random.Next(100);
            double c = Random.NextDouble();
            double d = Random.Next(100);
            double[] Temperature = new double[2];
            Temperature[0] = a * b;
            Temperature[1] = c * d;
            Temperature[0] = Math.Round(Temperature[0], 1);
            Temperature[1] = Math.Round(Temperature[1], 1);
            return Temperature;
        }

        //public string ToJson()
        //{
        //    return JsonSerializer.Serialize(new Temperature(Temperature()));
        //}
    }
}
