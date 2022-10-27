using System.Runtime.InteropServices;

namespace NetCoreClient.ValueObjects
{
    public class Highness
    {
        public int Altezza { get; private set; }

        public Highness(int value)
        {
            this.Altezza = value;
        }
        public override string? ToString()
        {
            return "Altezza: " + Altezza;
        }

    }
}