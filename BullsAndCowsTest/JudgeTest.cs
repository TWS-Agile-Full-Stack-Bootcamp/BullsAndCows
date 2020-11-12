using System.Linq;
using BullsAndCows;
using Xunit;

namespace BullsAndCowsTest
{
    public class JudgeTest
    {
        [Fact]
        public void Judge_should_set_secret_with_4_different_digit()
        {
            SecretGenerator secretGenerator = new SecretGenerator();
            string secret = secretGenerator.SetSecret();
            Assert.Equal(4, secret.Distinct().Count());
        }

        [Fact]
        public void Judge_should_set_different_secret_different()
        {
            var judge = new SecretGenerator();
            var secretOne = judge.SetSecret();
            var secretTwo = judge.SetSecret();
            Assert.NotEqual(secretOne, secretTwo);
        }
    }
}