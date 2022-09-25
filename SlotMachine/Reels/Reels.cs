namespace SlotMachines
{
    public class Reels : IReels
    {
        public int ReelCount { get; set; }
        public int ReelLength { get; set; }
        public IList<IReelSymbol> Symbols {get; set;}
        
        public ISpinResult Spin(decimal stake)
        {
            var reels = new List<List<IReelSymbol>>();

            var reel = new WeightedItemSelector<IReelSymbol>()
            {
                Items = Symbols
            };

            for (int i = 0; i < ReelCount; i++)
            {
                reels.Add(reel.GetRandomList(ReelLength));
            }

            decimal winnings = CalculateWinnings(reels, stake);

            return new SpinResult()
            {
                Result = reels,
                Winnings = winnings
            };
        }
        
        private decimal CalculateReelCoefficient(IEnumerable<IReelSymbol> reel)
        {
            char? firstNonWildCardSymbol = null;

            decimal reelCoefficient = 0; 

            foreach (var symbol in reel)
            {
                if (!symbol.IsWilcard)
                {
                    if (firstNonWildCardSymbol == null)
                    {
                        firstNonWildCardSymbol = symbol.Symbol;
                    }
                    else if (symbol.Symbol != firstNonWildCardSymbol)
                    {
                        reelCoefficient = 0;
                        break;
                    }
                }

                reelCoefficient += symbol.Coefficient;
            }

            return reelCoefficient;
        }

        public decimal CalculateWinnings(IEnumerable<IEnumerable<IReelSymbol>> reels, decimal stake)
        {
            decimal totalCoefficient = 0;

            foreach (var reel in reels)
            {
                totalCoefficient += CalculateReelCoefficient(reel);
            };

            return stake * totalCoefficient;
        }
    }
}
