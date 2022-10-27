namespace NetCoreClient.ValueObjects
{
    internal class Speed
    {
        public int Velocita { get; private set; }
        
        public Speed(int value)
        {
            this.Velocita = value;
        }

    }
}
