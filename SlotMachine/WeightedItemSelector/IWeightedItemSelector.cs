namespace SlotMachines
{
    public interface IWeightedItemSelector<T> where T : IWeighted
    {
        int PWeightSum { get; }
        IList<T> Items { get; set; }
        List<T> GetRandomList(int resultLength);
        T GetRandomItem();
    }
}