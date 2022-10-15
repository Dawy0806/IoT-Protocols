using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors
{
    class VirtualPositonSensor : IPositionSensorInterface, ISensorInterface
    {
        private readonly Random Random;

        public VirtualPositonSensor()
        {
            Random = new Random();
        }

        public double[] Position()
        {
            double a = Random.NextDouble();
            double b = Random.Next(-90, 90);
            double c = Random.NextDouble();
            double d = Random.Next(-180, 180);
            double[] Position = new double[2];
            //posizione 0 = latitudine , posizione 1 = longitudine
            Position[0] = a * b;
            Position[1] = c * d;
            Position[0] = Math.Round(Position[0], 4);
            Position[1] = Math.Round(Position[1], 4);
            return Position;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(new Position(Position()));
        }
    }
}
