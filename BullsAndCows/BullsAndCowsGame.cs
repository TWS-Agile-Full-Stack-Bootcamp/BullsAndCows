﻿using System;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private const int InputDigitLength = 4;
        private const char SpaceSeparator = ' ';
        private const string WrongInputMessage = "Wrong Input, input again";
        private const int MaxChances = 6;

        private readonly Judge judge;
        private int usedChances = 0;
        private string secret = string.Empty;

        public BullsAndCowsGame(Judge judge = null)
        {
            secret = (judge ?? new Judge()).SetSecret();
        }

        public bool CanContinue => usedChances < MaxChances;

        public string JudgeAnswer(string input)
        {
            if (IsValidInput(input))
            {
                return WrongInputMessage;
            }

            if (usedChances >= MaxChances)
            {
                return "Game Over";
            }

            usedChances++;

            return JudgeGuess(input);
        }

        private string JudgeGuess(string input)
        {
            var digitWithoutSpace = input.Replace(" ", string.Empty);
            var inputDigitsInSecret = digitWithoutSpace.Where(digit => secret.Contains(digit)).ToList();
            return $"0A{inputDigitsInSecret.Count()}B";
        }

        private static bool IsValidInput(string input)
        {
            if (IsInputDigitBetweenSpace(input))
            {
                return true;
            }

            if (IsInputDigitDifferent(input))
            {
                return true;
            }

            return false;
        }

        private static bool IsInputDigitDifferent(string input)
        {
            var splitDigits = input.Split(SpaceSeparator);

            var inputWithoutSpace = string.Join(string.Empty, splitDigits);

            if (inputWithoutSpace.Distinct().Count() != InputDigitLength)
            {
                return true;
            }

            return false;
        }

        private static bool IsInputDigitBetweenSpace(string input)
        {
            var splitDigits = input.Split(SpaceSeparator);
            if (splitDigits.Length != InputDigitLength)
            {
                return true;
            }

            return false;
        }
    }
}