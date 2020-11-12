using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private const int InputDigitLength = 4;
        private const char SpaceSeparator = ' ';
        private const string WrongInputMessage = "Wrong Input, input again";

        public bool CanContinue { get; private set; }

        public string Judge(string input)
        {
            if (IsValidInput(input))
            {
                return WrongInputMessage;
            }

            return string.Empty;
        }

        private static bool IsValidInput(string input)
        {
            if (IsInputDigitBetweenSpace(input))
            {
                    return true;
            }

            if (IsInputDigitDifferent(input))
            {
                    return true;
            }

            return false;
        }

        private static bool IsInputDigitDifferent(string input)
        {
            var splitDigits = input.Split(SpaceSeparator);

            var inputWithoutSpace = string.Join(string.Empty, splitDigits);

            if (inputWithoutSpace.Distinct().Count() != InputDigitLength)
            {
                return true;
            }

            return false;
        }

        private static bool IsInputDigitBetweenSpace(string input)
        {
            var splitDigits = input.Split(SpaceSeparator);
            if (splitDigits.Length != InputDigitLength)
            {
                return true;
            }

            return false;
        }
    }
}