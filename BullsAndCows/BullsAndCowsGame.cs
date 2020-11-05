using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    using System;

    public class BullsAndCowsGame
    {
        private const string WrongInputMessage = "Wrong Input，Input again";

        public string Guess(string input)
        {
            if (IsInputLengthInvalid(input))
            {
                return WrongInputMessage;
            }

            if (IsInputDigitNoUnique(input))
            {
                return WrongInputMessage;
            }

            return string.Empty;
        }

        private static bool IsInputLengthInvalid(string input)
        {
            return input.Length != 4;
        }

        private static bool IsInputDigitNoUnique(string input)
        {
            return input.ToCharArray().GroupBy(c => c).ToList().Count != 4;
        }
    }
}