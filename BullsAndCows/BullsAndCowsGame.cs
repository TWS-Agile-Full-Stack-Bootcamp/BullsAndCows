using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    using System;

    public class BullsAndCowsGame
    {
        private const string WrongInputMessage = "Wrong Input，Input again";
        private const int MaxTryChances = 6;
        private const string FailedMessage = "You are failed";
        private int triedChances = 0;

        public BullsAndCowsGame(AnswerGenerator answerGeneratorObject = null)
        {
            triedChances = 0;
            if (answerGeneratorObject != null)
            {
                answerGeneratorObject.Generate();
            }
        }

        public string Guess(string input)
        {
            triedChances++;
            if (IsInputLengthInvalid(input))
            {
                return WrongInputMessage;
            }

            if (IsInputDigitNoUnique(input))
            {
                return WrongInputMessage;
            }

            if (IsOverMaxTryChances())
            {
                return FailedMessage;
            }

            return string.Empty;
        }

        private bool IsOverMaxTryChances()
        {
            return this.triedChances >= MaxTryChances;
        }

        private static bool IsInputLengthInvalid(string input)
        {
            return input.Length != 4;
        }

        private static bool IsInputDigitNoUnique(string input)
        {
            return input.ToCharArray().GroupBy(c => c).ToList().Count != 4;
        }
    }
}