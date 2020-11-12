using System;
using BullsAndCows;

namespace BullsAndCowsRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BullsAndCowsGame game = new BullsAndCowsGame();
            while (game.CanContinue)
            {
                var input = Console.ReadLine();
                var output = game.Guess(input);
                Console.WriteLine(output);
            }

            Console.WriteLine("Game Over");
        }
    }
}