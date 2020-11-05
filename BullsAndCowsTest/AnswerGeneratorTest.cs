namespace BullsAndCowsTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BullsAndCows;
    using Xunit;

    public class AnswerGeneratorTest
    {
        [Fact]
        public void Should_return_4_numbers_when_generate_answer()
        {
            // given
            AnswerGenerator answerGenerator = new AnswerGenerator(new Random());

            // when
            List<int> answer = answerGenerator.Generate();

            // then
            Assert.Equal(4, answer.Count());
        }

        [Fact]
        public void Should_random_when_generate_answer()
        {
            // given
            AnswerGenerator answerGenerator = new AnswerGenerator(new Random());

            // when
            List<int> answer1 = answerGenerator.Generate();
            List<int> answer2 = answerGenerator.Generate();
            List<int> answer3 = answerGenerator.Generate();

            // then
            Assert.False(answer1.SequenceEqual(answer2) && answer2.SequenceEqual(answer3));
        }
    }
}
