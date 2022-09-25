using SlotMachines;

//Assumptions on game rules that will never change (to keep complexity smaller):
//1. Having multiple non wildcard symbols on the same reel is a loss on that reel
//2. Reels should all be the same on the slot machine
//3. We're only worried about calculating winnings on a per reel basis and not thinking about extras like columns

//How would I resolve each assumption if it was needed?
//1. This really depends on why we're changing this. Something like symbols be passed a 'group' and matching that same group still counts could be very easily done.

//2. Passing a list of reels to the Reels class instead of a single reel would solve this and be easy to do - I've just decided to cut complexity a bit here

//3. Using a 2d array works well for symbol positioning and is more generally adaptable than lists but introduces complexity I didn't want to deal with in a small demo.

//One extra thing I'd highly consider is use of base abstract classes for some parts of this but keeping complexity down and time limits I've kept everything in a basic class for now

public class Program
{
    static void Main(string[] args)
    {
        ISlotMachine fruitSlotMachine = SlotMachineFactory.CreateFruitSlotMachine();

        fruitSlotMachine.Start();
    }
}