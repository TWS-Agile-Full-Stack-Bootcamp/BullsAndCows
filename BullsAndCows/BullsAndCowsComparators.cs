using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsComparators
    {
        public BullsAndCowsComparators()
        {
        }

        public string CompareNumber(string answer, string guess)
        {
            if (answer.Equals(guess))
            {
                return "4A0B";
            }

            if (answer.Split(" ").Intersect(guess.Split(" ")).Count() == 4)
            {
                return "0A4B";
            }

            return "0A0B";
        }
    }
}