using System;
using System.Linq;
namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private const int VALID_GUESS_STRING_LENGTH = 7;
        private const int VALID_GUESS_NUMBER_COUNT = 4;
        private const string ALL_CORRECT_RESULT = "4A0B";
        private const int MAX_CHANCES = 6;

        private AnswerGenerator answerGenerator;
        private string answer;
        private IConsole console;

        public BullsAndCowsGame(AnswerGenerator answerGenerator, IConsole console)
        {
            this.answerGenerator = answerGenerator;
            this.console = console;
            answer = string.Join(" ", answerGenerator.Generate());
        }

        public bool ValidateGuess(string guess)
        {
            return guess.Length == VALID_GUESS_STRING_LENGTH
                && guess.Split(" ").Distinct().Count() == VALID_GUESS_NUMBER_COUNT;
        }

        public string Guess(string answer, string guess)
        {
            if (!ValidateGuess(guess))
            {
                return "Wrong Input，Input again";
            }

            return new BullsAndCowsComparators().CompareNumber(answer, guess);
        }

        public void Run()
        {
            int guessTimes = 0;
            while (guessTimes < MAX_CHANCES)
            {
                string guess = console.ReadLine();
                string result = this.Guess(answer, guess);
                console.WriteLine(result);
                guessTimes++;
                if (ALL_CORRECT_RESULT.Equals(result))
                {
                    break;
                }
            }
        }
    }
}
