using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class Judge
    {
        public static string SetSecret()
        {
            string secret = string.Empty;
            List<int> digits = Enumerable.Range(0, 9).ToList();
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                var randmonIndex = random.Next(digits.Count);
                secret += digits[randmonIndex];
                digits.RemoveAt(randmonIndex);
            }

            return secret;
        }
    }
}