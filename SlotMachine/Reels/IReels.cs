namespace SlotMachines
{
    public interface IReels
    {
        int ReelLength { get; set; }
        int ReelCount { get; set; }
        ISpinResult Spin(decimal stake);
        IList<IReelSymbol> Symbols { get; set; }
        decimal CalculateWinnings(IEnumerable<IEnumerable<IReelSymbol>> reels, decimal stake);
    }
}