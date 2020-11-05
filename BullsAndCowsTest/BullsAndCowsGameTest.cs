using System.Collections.Immutable;
using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_return_wrong_input_when_propose_input_length_less_than_4()
        {
            // given
            var bullsAndCowsGame = new BullsAndCowsGame();
            var inputLengthLessThan4 = "12";
            // when
            var output = bullsAndCowsGame.Guess(inputLengthLessThan4);
            //then
            Assert.Equal("Wrong Input，Input again", output);
        }

        [Fact]
        public void Should_return_wrong_input_when_input_length_more_than_4()
        {
            // given
            var bullsAndCowsGame = new BullsAndCowsGame();
            var inputLengthMoreThan4 = "12345";
            // when
            var output = bullsAndCowsGame.Guess(inputLengthMoreThan4);
            //then
            Assert.Equal("Wrong Input，Input again", output);
        }

        [Fact]
        public void Should_return_wrong_input_when_input_digit_no_unique()
        {
            // given
            var bullsAndCowsGame = new BullsAndCowsGame();
            var inputWithNoUniqueDigit = "1134";
            // when
            var output = bullsAndCowsGame.Guess(inputWithNoUniqueDigit);
            //then
            Assert.Equal("Wrong Input，Input again", output);
        }

        [Fact]
        public void Should_return_fail_when_input_more_than_6_times()
        {
            // given
            var bullsAndCowsGame = new BullsAndCowsGame();
            var inputWithNoUniqueDigit = "1234";
            // when
            for (int i = 0; i < 6; i++)
            {
                bullsAndCowsGame.Guess(inputWithNoUniqueDigit);
            }
            
            var output = bullsAndCowsGame.Guess(inputWithNoUniqueDigit);
            //then
            Assert.Equal("You are failed", output);
        }

        [Fact]
        public void Should_execute_AnswerGenerate_Generate_method_when_game_start()
        {
            // given
            var answerGenerator = new Mock<AnswerGenerator>();
            answerGenerator.Setup(_ => _.Generate()).Returns(string.Empty);
            var game = new BullsAndCowsGame(answerGenerator.Object);
            var input = "1234";
            // when
            game.Guess(input);
            // then
            answerGenerator.Verify(a => a.Generate(), Times.Once);
        }

        [Fact]
        public void Should_return_0A0B_when_input_all_wrong()
        {
            // given
            var answer = "1234";
            var input = "6789";
            var mockAnswerGenerator = new Mock<AnswerGenerator>();
            mockAnswerGenerator.Setup(_ => _.Generate()).Returns(string.Empty);
            var game = new BullsAndCowsGame(mockAnswerGenerator.Object);
            // when
            var output = game.Guess(input);
            // then
            Assert.Equal("0A0B", output);
        }
    }
}