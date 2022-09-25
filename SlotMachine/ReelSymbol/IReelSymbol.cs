namespace SlotMachines
{
    public interface IReelSymbol
    {
        decimal Coefficient { get; set; }
        bool IsWilcard { get; set; }
        char Symbol { get; set; }
        int Weight { get; set; }
    }
}