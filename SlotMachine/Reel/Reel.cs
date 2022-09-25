namespace SlotMachines
{
    public class Reel : IReel
    {
        private List<IReelSymbol> _symbols;
        private int pWeightSum;

        public List<IReelSymbol> Symbols
        {
            get { return _symbols; }
            set { _symbols = value; pWeightSum = value.Sum(s => s.Weight); }
        }

        public int Length { get; set; }

        public List<IReelSymbol> Spin()
        {
            var reel = new List<IReelSymbol>();

            Random random = new Random();

            for (int i = 0; i < Length; i++)
            {
                int randomNumber = random.Next(1, pWeightSum + 1);
                int rangeChecked = 0;

                for (int j = 0; j < Symbols.Count; j++)
                {
                    rangeChecked += Symbols[j].Weight;

                    if (randomNumber <= rangeChecked)
                    {
                        reel.Add(Symbols[j]);
                        break;
                    }
                }
            }

            return reel;
        }
    }
}
