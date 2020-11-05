using System.Linq;

namespace BullsAndCowsTest
{
    using BullsAndCows;
    using Xunit;

    public class AnswerGeneratorTest
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

        [Fact]
        public void Should_generate_different_answer()
        {
            // given
            var answerGenerator = new AnswerGenerator();
            // when
            var answer1 = answerGenerator.Generate();
            var answer2 = answerGenerator.Generate();
            //then
            Assert.True(IsValidAnswer(answer1));
            Assert.True(IsValidAnswer(answer2));
            Assert.True(answer1 != answer2);
        }

        private bool IsValidAnswer(string answer)
        {
            var digits = Enumerable.Range(0, 9);
            var answerContainsDigits = digits.Where(digit => answer.Contains(digit.ToString())).ToList();
            return answerContainsDigits.Count == 4;
        }
    }
}