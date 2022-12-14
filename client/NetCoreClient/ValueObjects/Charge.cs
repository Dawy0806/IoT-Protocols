using System.Runtime.InteropServices;

namespace NetCoreClient.ValueObjects
{
    public class Charge
    {
        public int Batteria { get; private set; }

        public Charge(int value)
        {
            this.Batteria = value;
        }
        public override string? ToString()
        {
            return "Carica: " + Batteria;
        }

    }
}