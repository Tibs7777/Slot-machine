namespace SlotMachines
{
    public interface ISlotMachine
    {
        IReels Reels { get; set; }
        void Start();
        void PrintResult(IEnumerable<IEnumerable<IReelSymbol>> result);
    }
}