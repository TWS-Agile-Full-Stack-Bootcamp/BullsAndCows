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
            int aCount = CountA(answer, guess);
            int numberRightCount = CountRightNumber(answer, guess);
            int bCount = numberRightCount - aCount;

            return $"{aCount}A{bCount}B";
        }

        private int CountA(string answer, string guess)
        {
            string[] answerNumbers = answer.Split(" ");
            string[] guessNumbers = guess.Split(" ");
            return answerNumbers.Where(answerNumber =>
                answerNumber.Equals(guessNumbers[Array.IndexOf(answerNumbers, answerNumber)])).Count();
        }

        private int CountRightNumber(string answer, string guess)
        {
            return answer.Split(" ").Intersect(guess.Split(" ")).Count();
        }
    }
}