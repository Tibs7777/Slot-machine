namespace SlotMachines
{
    //Maybe bit overkill to make this generic here but the idea is we have our own random class that deals with any & all random selections based on weight
    public class WeightedItemSelector<T> : IWeightedItemSelector<T> where T : IWeighted
    {
        private IList<T> _items;
        private int pWeightSum;
        
        public IList<T> Items
        {
            get { return _items; }
            set { _items = value; pWeightSum = value.Sum(s => s.Weight); }
        }
        
        public int PWeightSum
        {
            get { return pWeightSum; }
        }

        public List<T> GetRandomList(int resultLength)
        {
            var reel = new List<T>();

            for (int i = 0; i < resultLength; i++)
            {
                reel.Add(GetRandomItem());
            }

            return reel;
        }
        
        public T GetRandomItem() 
        {
            Random random = new Random();
            int randomNumber = random.Next(1, PWeightSum + 1);
            
            int rangeChecked = 0;

            for (int j = 0; j < Items.Count; j++)
            {
                rangeChecked += Items[j].Weight;

                if (randomNumber <= rangeChecked)
                {
                    return Items[j];
                }
            }

            throw new Exception("No item found");
        }
    }
}
