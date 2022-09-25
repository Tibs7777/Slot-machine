namespace SlotMachines
{
    public interface ISlotMachine
    {
        IReels Reels { get; set; }
        void Start();
    }
}