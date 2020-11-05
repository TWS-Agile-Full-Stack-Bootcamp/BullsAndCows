using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    public class AnswerGenerator
    {
        public AnswerGenerator(Random random)
        {
        }

        public List<int> Generate()
        {
            return new List<int> { 1, 2, 3, 4 };
        }
    }
}
