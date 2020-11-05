using System;
namespace BullsAndCows
{
    public class GuessResult
    {
        private string guess;
        private string result;

        public GuessResult(string guess, string result)
        {
            this.guess = guess;
            this.result = result;
        }

        public override string ToString()
        {
            return $"guess: {guess}, result: {result}";
        }
    }
}
