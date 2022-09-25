namespace SlotMachines
{
    public interface IReel
    {
        int Length { get; set; }
        int PWeightSum { get; }
        List<IReelSymbol> Symbols { get; set; }
        List<IReelSymbol> Spin();
    }
}