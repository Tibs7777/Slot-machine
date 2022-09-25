namespace SlotMachines
{
    public interface IReels
    {
        IReel Reel { get; set; }
        int ReelCount { get; set; }
        ISpinResult Spin(decimal stake);
    }
}