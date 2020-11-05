using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    using System;

    public class BullsAndCowsGame
    {
        private readonly string answer;
        private int triedChances = 0;

        public BullsAndCowsGame(AnswerGenerator answerGeneratorObject = null)
        {
            triedChances = 0;
            if (answerGeneratorObject != null)
            {
                answer = answerGeneratorObject.Generate();
            }
        }

        public string Guess(string input)
        {
            try
            {
                VerifyInputLength(input);

                VerifyInputDigitUnique(input);

                VerifyGuessChances();

                triedChances++;

                return CompareInputAndAnswer(input);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string CompareInputAndAnswer(string input)
        {
            int correctPositionCount = 0;
            int wrongPositionCount = 0;
            input.Select((digit, index) =>
            {
                if (this.answer.Contains(digit))
                {
                    if (this.answer[index] == digit)
                    {
                        correctPositionCount++;
                    }
                    else
                    {
                        wrongPositionCount++;
                    }
                }

                return string.Empty;
            }).ToList();
            return $"{correctPositionCount}A{wrongPositionCount}B";
        }

        private void VerifyGuessChances()
        {
            if (this.triedChances >= Constant.MaxTryChances)
            {
                throw new GuessChancesOverMaxException();
            }
        }

        private void VerifyInputLength(string input)
        {
            if (input.Length != Constant.INPUT_LENGTH)
            {
                throw new InputLengthInvalidException();
            }
        }

        private void VerifyInputDigitUnique(string input)
        {
            if (input.ToCharArray().GroupBy(c => c).ToList().Count != 4)
            {
                throw new DigitNoUniqueException();
            }
        }
    }

    public class DigitNoUniqueException : Exception
    {
        public DigitNoUniqueException()
            : base(Constant.WrongInputMessage)
        {
        }
    }

    public class InputLengthInvalidException : Exception
    {
        public InputLengthInvalidException()
            : base(Constant.WrongInputMessage)
        {
        }
    }

    public class GuessChancesOverMaxException : Exception
    {
        public GuessChancesOverMaxException()
            : base(Constant.FailedMessage)
        {
        }
    }
}