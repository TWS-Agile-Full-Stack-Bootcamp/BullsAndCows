using System;

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

            return "0A0B";
        }
    }
}