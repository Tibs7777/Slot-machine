namespace SlotMachines
{
    public class ReelSymbol : IReelSymbol
    {
        public char Symbol { get; set; }
        public decimal Coefficient { get; set; }
        public int Weight { get; set; }
        public bool IsWilcard { get; set; } = false;
    }
}
