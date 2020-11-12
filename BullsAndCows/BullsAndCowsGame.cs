using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        public bool CanContinue { get; private set; }

        public string Judge(string input)
        {
            var splitedDigits = input.Split(' ');
            if (splitedDigits.Length != 4)
            {
                return "Wrong Input, input again";
            }

            return string.Empty;
        }
    }
}