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
    }
}
