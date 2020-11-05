using System;
using System.Linq;
namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        public BullsAndCowsGame()
        {
        }

        public bool ValidateGuess(string guess)
        {
            return guess.Length == 7 && guess.Split(" ").Distinct().Count() == 4;
        }
    }
}
