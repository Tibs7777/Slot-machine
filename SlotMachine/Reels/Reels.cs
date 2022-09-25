namespace SlotMachines
{
    public class Reels : IReels
    {
        public IReel Reel { get; set; }
        public int ReelCount { get; set; }

        public ISpinResult Spin(decimal stake)
        {
            var reels = new List<List<IReelSymbol>>();

            for (int i = 0; i < ReelCount; i++)
            {
                reels.Add(Reel.Spin());
            }

            decimal winnings = CalculateWinnings(reels, stake);

            return new SpinResult()
            {
                Result = reels,
                Winnings = winnings
            };
        }
        
        public decimal CalculateReelCoefficient(List<IReelSymbol> reel)
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

        public decimal CalculateWinnings(List<List<IReelSymbol>> reels, decimal stake)
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
