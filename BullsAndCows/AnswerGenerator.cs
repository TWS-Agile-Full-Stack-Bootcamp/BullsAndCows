using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class AnswerGenerator
    {
        private const int ANSWER_NUMBER_COUNT = 4;
        private readonly Random random;

        public AnswerGenerator(Random random)
        {
            this.random = random;
        }

        public List<int> Generate()
        {
            List<int> answer = new List<int>();
            int numberCount = 0;
            while (numberCount < ANSWER_NUMBER_COUNT)
            {
                int randomNumber = random.Next(0, 9);
                if (!answer.Contains(randomNumber))
                {
                    answer.Add(randomNumber);
                    numberCount++;
                }
            }

            return answer;
        }
    }
}
