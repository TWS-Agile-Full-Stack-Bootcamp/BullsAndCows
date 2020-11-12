﻿using System.Linq;
using BullsAndCows;
using Xunit;

namespace BullsAndCowsTest
{
    public class JudgeTest
    {
        [Fact]
        public void Judge_should_set_secret_with_4_different_digit()
        {
            Judge judge = new Judge();
            string secret = judge.SetSecret();
            Assert.Equal(4, secret.Distinct().Count());
        }

        [Fact]
        public void Judge_should_set_different_secret_different()
        {
            var judge = new Judge();
            var secretOne = judge.SetSecret();
            var secretTwo = judge.SetSecret();
            Assert.NotEqual(secretOne, secretTwo);
        }
    }
}