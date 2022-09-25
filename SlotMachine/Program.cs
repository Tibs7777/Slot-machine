using SlotMachines;

//Assumptions on game rules that will never change (to keep complexity smaller):
//1. Having multiple non wildcard symbols on the same reel is a loss on that reel
//2. Reels should all be the same on the slot machine
//3. We're only worried about calculating winnings on a per reel basis and not thinking about extras like columns

//These aren't unimplementable with this solution and you could definitely have those in
//I just wanted to keep complexity smaller in some areas

public class Program
{
    static void Main(string[] args)
    {
        ISlotMachine fruitSlotMachine = SlotMachineFactory.CreateFruitSlotMachine();

        fruitSlotMachine.Start();
    }
}