using System;
namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        public BullsAndCowsGame()
        {
        }

        public bool ValidateGuess(string guess)
        {
            if (guess.Length == 7)
            {
                return true;
            }

            return false;
        }
    }
}
