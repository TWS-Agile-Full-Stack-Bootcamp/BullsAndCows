using System;
using System.Linq;

namespace BullsAndCows
{
    public class AnswerGenerator
    {
        public string Generate()
        {
            var backupDigits = Enumerable.Range(0, 9).ToList();
            Random random = new Random();
            string result = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                var count = backupDigits.Count - 1;
                var randomIndex = random.Next(count);
                var pickupDigit = backupDigits[randomIndex];
                backupDigits.RemoveAt(randomIndex);
                result += pickupDigit;
            }

            return result;
        }
    }
}