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

            return $"0A{CountB(answer, guess)}B";
        }

        private int CountB(string answer, string guess)
        {
            return answer.Split(" ").Intersect(guess.Split(" ")).Count();
        }
    }
}