using System;
using BullsAndCows;

namespace BullsAndCowsRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BullsAndCowsGame game = new BullsAndCowsGame();
            while (game.Status == GameStatus.Running)
            {
            }

            Console.WriteLine("Game Over");
        }
    }
}