namespace NetCoreClient.ValueObjects
{
    public class Temperature
    {
        public double TempMot { get; private set; }
        public double TempPro { get; private set; }

        public Temperature(double[] Position)
        {
            this.TempMot = Position[0];
            this.TempPro = Position[1];
        }

        public override string? ToString()
        {
            return "Temperatura Motore: " + TempMot + "  Temperatura Processore: " + TempPro;
        }
    }
}