using System.Linq;

namespace BullsAndCowsTest
{
    using BullsAndCows;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Should_generate_answer_with_unique_digit()
        {
            // Given
            var answerGenerator = new AnswerGenerator();
            // When
            string answer = answerGenerator.Generate();
            //Then
            
            Assert.True(IsValidAnswer(answer));
        }

        private bool IsValidAnswer(string answer)
        {
            var digits = Enumerable.Range(1, 9);
            var answerContainsDigits = digits.Where(digit => answer.Contains(digit.ToString())).ToList();
            return answerContainsDigits.Count == 4;
        }
    }
}