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

            return CompareInputAndAnswer(input);
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

        private bool IsOverMaxTryChances()
        {
            return this.triedChances >= MaxTryChances;
        }

        private bool IsInputLengthInvalid(string input)
        {
            return input.Length != 4;
        }

        private bool IsInputDigitNoUnique(string input)
        {
            return input.ToCharArray().GroupBy(c => c).ToList().Count != 4;
        }
    }

    internal class DigitWithIndex
    {
        public DigitWithIndex(char digit, int index)
        {
            Digit = digit;
            Index = index;
        }

        public char Digit { get; private set; }
        public int Index { get; private set; }
    }
}