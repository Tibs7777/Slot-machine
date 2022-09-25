namespace SlotMachines
{
    public interface IReel
    {
        int Length { get; set; }
        List<IReelSymbol> Symbols { get; set; }
        List<IReelSymbol> Spin();
    }
}