namespace SlotMachines
{
    public interface IReelSymbol : IWeighted
    {
        decimal Coefficient { get; set; }
        bool IsWilcard { get; set; }
        char Symbol { get; set; }
    }
}