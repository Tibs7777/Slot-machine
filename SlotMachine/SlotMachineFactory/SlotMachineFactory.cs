namespace SlotMachines
{
    public class SlotMachineFactory
    {
        public static ISlotMachine CreateFruitSlotMachine()
        {
            var slotMachineSymbols = new List<IReelSymbol>() 
            {
                new ReelSymbol() {Symbol = 'A', Coefficient = 0.4M, Weight = 45},
                new ReelSymbol() {Symbol = 'B', Coefficient = 0.6M, Weight = 35},
                new ReelSymbol() {Symbol = 'P', Coefficient = 0.8M, Weight = 15},
                new ReelSymbol() {Symbol = '*', Coefficient = 0M, Weight = 5, IsWilcard = true},
            };

            var reel = new Reel()
            {
                Symbols = slotMachineSymbols,
                Length = 3
            };

            var reels = new Reels()
            {
                Reel = reel,
                ReelCount = 4
            };

            return new SlotMachine()
            {
                Reels = reels
            };
        }
    }
}
