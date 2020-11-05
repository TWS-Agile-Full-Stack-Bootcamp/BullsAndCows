using System;
using System.Linq;
namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private const int VALID_GUESS_STRING_LENGTH = 7;
        private const int VALID_GUESS_NUMBER_COUNT = 4;

        public BullsAndCowsGame()
        {
        }

        public bool ValidateGuess(string guess)
        {
            return guess.Length == VALID_GUESS_STRING_LENGTH
                && guess.Split(" ").Distinct().Count() == VALID_GUESS_NUMBER_COUNT;
        }
    }
}
