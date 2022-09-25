namespace SlotMachines
{
    //Base slot machine class
    //Main job is controlling the core game loop and displaying/recieving information from the user

    //Main methods set to virtual in case of needing a more custom setup while still using the rest of the machine
    public class SlotMachine : ISlotMachine
    {
        protected decimal _balance;
        protected decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance = decimal.Round(value, 2);
            }
        }
        public IReels Reels { get; set; }

        public virtual void Start()
        {
            Balance = UserInput.GetUserMoney("Please deposit money you would like to play with", "Please enter a valid amount of money");

            GameLoop();
        }

        protected virtual void GameLoop()
        {
            if (Balance <= 0)
            {
                Console.WriteLine("You have no money left, please deposit more money to play again");
                return;
            }

            decimal stake = UserInput.GetUserMoney("Please enter a stake", "Please enter a valid stake", ValidateStake);

            ISpinResult result = Reels.Spin(stake);

            PrintResult(result.Result);

            decimal winnings = result.Winnings;

            if (winnings == 0)
            {
                Balance -= stake;
                Console.WriteLine("You didn't win this time");
            }
            else
            {
                Balance += winnings;
                Console.WriteLine($"You have won {winnings:C2}");
            }

            Console.WriteLine($"Current balance is {Balance:C2}");

            GameLoop();
        }

        protected bool ValidateStake(decimal input)
        {
            return input <= Balance;
        }

        public virtual void PrintResult(List<List<IReelSymbol>> result)
        {
            foreach (var reel in result)
            {
                foreach (var symbol in reel)
                {
                    Console.Write(symbol.Symbol);
                }
                Console.WriteLine();
            }
        }
    }
}
