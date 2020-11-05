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
            var inputWithUniqueDigit = "1234";
            // when
            for (int i = 0; i < 6; i++)
            {
                bullsAndCowsGame.Guess(inputWithUniqueDigit);
            }

            var output = bullsAndCowsGame.Guess(inputWithUniqueDigit);
            //then
            Assert.Equal("You are failed", output);
        }

        [Fact]
        public void Should_return_fail_when_input_more_than_6_times_and_input_invalid()
        {
            // given
            var bullsAndCowsGame = new BullsAndCowsGame();
            var inputWithUniqueDigit = "12";
            // when
            for (int i = 0; i < 6; i++)
            {
                bullsAndCowsGame.Guess(inputWithUniqueDigit);
            }

            var output = bullsAndCowsGame.Guess(inputWithUniqueDigit);
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

        [Theory]
        [InlineData("1234", "1567")]
        [InlineData("2134", "5167")]
        [InlineData("2314", "5617")]
        [InlineData("2341", "5671")]
        public void Should_return_1A0B_when_1_position_correct_and_other_wrong(string input, string answer)
        {
            var mockAnswerGenerator = new Mock<AnswerGenerator>();
            mockAnswerGenerator.Setup(_ => _.Generate()).Returns(answer);
            var game = new BullsAndCowsGame(mockAnswerGenerator.Object);
            var output = game.Guess(input);
            Assert.Equal("1A0B", output);
        }
        
        [Theory]
        [InlineData("1234", "5167")]
        [InlineData("1234", "5617")]
        [InlineData("1234", "5671")]
        public void Should_return_0A1B_when_1_position_wrong_and_other_digit_no_match(string input, string answer)
        {
            var mockAnswerGenerator = new Mock<AnswerGenerator>();
            mockAnswerGenerator.Setup(_ => _.Generate()).Returns(answer);
            var game = new BullsAndCowsGame(mockAnswerGenerator.Object);
            var output = game.Guess(input);
            Assert.Equal("0A1B", output);
        }
        
        [Theory]
        [InlineData("1234", "1243")]
        [InlineData("1234", "2134")]
        public void Should_return_2A2B_when_2_position_correct_and_2_position_wrong(string input, string answer)
        {
            var mockAnswerGenerator = new Mock<AnswerGenerator>();
            mockAnswerGenerator.Setup(_ => _.Generate()).Returns(answer);
            var game = new BullsAndCowsGame(mockAnswerGenerator.Object);
            var output = game.Guess(input);
            Assert.Equal("2A2B", output);
        }
        
        [Theory]
        [InlineData("1234", "1234")]
        [InlineData("5678", "5678")]
        public void Should_return_4A0B_when_4_position_correct(string input, string answer)
        {
            var mockAnswerGenerator = new Mock<AnswerGenerator>();
            mockAnswerGenerator.Setup(_ => _.Generate()).Returns(answer);
            var game = new BullsAndCowsGame(mockAnswerGenerator.Object);
            var output = game.Guess(input);
            Assert.Equal("4A0B", output);
        }
    }
}