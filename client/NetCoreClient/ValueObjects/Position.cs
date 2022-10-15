namespace NetCoreClient.ValueObjects
{
    internal class Position
    {
        public double Lat { get; private set; }
        public double Long { get; private set; }

        public Position(double[] Position)
        {
            this.Lat = Position[0];
            this.Long = Position[1];
        }

        public override string? ToString()
        {
            return "Latitudine: " + Lat + "  Longitudine: " + Long;
        }
    }
}