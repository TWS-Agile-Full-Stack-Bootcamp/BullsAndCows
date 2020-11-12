using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private const string WrongInputMessage = "Wrong Input, input again";

        public bool CanContinue { get; private set; }

        public string Judge(string input)
        {
            if (IsInputDigitBetweenSpace(input, out var wrongInputInputAgain))
            {
                return wrongInputInputAgain;
            }

            return string.Empty;
        }

        private static bool IsInputDigitBetweenSpace(string input, out string wrongInputInputAgain)
        {
            wrongInputInputAgain = string.Empty;
            var splitedDigits = input.Split(' ');
            if (splitedDigits.Length != 4)
            {
                {
                    wrongInputInputAgain = WrongInputMessage;
                    return true;
                }
            }

            return false;
        }
    }
}