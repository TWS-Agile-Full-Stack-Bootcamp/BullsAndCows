using System;
using BullsAndCows;

namespace BullsAndCowsRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            BullsAndCowsGame game = new BullsAndCowsGame();
            while (game.Status == GameStatus.Running)
            {
                
            }
            Console.WriteLine("Game Over");
        }
    }
}