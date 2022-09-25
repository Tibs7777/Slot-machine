namespace SlotMachines
{
    public interface ISpinResult
    {
        List<List<IReelSymbol>> Result { get; set; }
        decimal Winnings { get; set; }
    }
}