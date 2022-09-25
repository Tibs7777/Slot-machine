namespace SlotMachines
{
    public class UserInput
    {
        public delegate bool AdditionalInputValidation(decimal input);
        
        public static decimal GetUserMoney(string message, string retryMessage = null, AdditionalInputValidation additionalInputValidation = null)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            bool validInput = decimal.TryParse(input, out var result) && result > 0 && decimal.Round(result, 2) == result ;

            if (validInput && additionalInputValidation != null)
            {
                validInput = additionalInputValidation(result);
            }

            if (!validInput)
            {
                if (string.IsNullOrEmpty(retryMessage)) retryMessage = message;
                return GetUserMoney(retryMessage, additionalInputValidation: additionalInputValidation);
            }

            return result;
        }
    }
}
