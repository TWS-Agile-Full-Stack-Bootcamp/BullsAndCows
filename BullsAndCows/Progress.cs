using System;

namespace BullsAndCows
{
    public static class Progre1ss
    {
        private static void Main(string[] args)
        {
            var answerGenerator = new AnswerGenerator();
            var game = new BullsAndCowsGame(answerGenerator);
            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(game.Guess(input));
            }
        }
    }
}