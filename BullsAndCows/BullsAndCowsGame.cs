using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    using System;

    public class BullsAndCowsGame
    {
        private const string WrongInputInputAgain = "Wrong Input，Input again";

        public string Guess(string input)
        {
            if (input.Length != 4)
            {
                return WrongInputInputAgain;
            }

            var group = input.ToCharArray().GroupBy(c => c);

            if (group.ToList().Count != 4)
            {
                return WrongInputInputAgain;
            }

            return string.Empty;
        }
    }
}