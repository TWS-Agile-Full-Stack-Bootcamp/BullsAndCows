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

        [Theory]
        [InlineData("-1 0 1 2")]
        [InlineData("0 -1 1 2")]
        [InlineData("0 1 -2 3")]
        [InlineData("0 1 2 -3")]
        [InlineData("11 2 3 4")]
        [InlineData("1 12 3 4")]
        [InlineData("1 2 23 4")]
        [InlineData("1 2 3 44")]
        [InlineData("a 2 3 44")]
        [InlineData("1 b 3 44")]
        [InlineData("1 2 c 44")]
        [InlineData("1 2 3 d")]
        public void Should_return_wrong_input_when_input_digit_no_in_range_0_9(string input)
        {
            // given
            var bullsAndCowsGame = new BullsAndCowsGame();
            // when
            var output = bullsAndCowsGame.Guess(input);
            //then
            Assert.Equal("Wrong Input，Input again", output);
        }

        [Fact]
        public void Should_return_wrong_input_when_input_length_more_than_4()
        {
            // given
            var bullsAndCowsGame = new BullsAndCowsGame();
            var inputLengthMoreThan4 = "1 2 3 4 5";
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
            var inputWithNoUniqueDigit = "1 1 3 4";
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
            var inputWithUniqueDigit = "1 2 3 4";
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
            var inputWithUniqueDigit = "1 2";
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
            var input = "1 2 3 4";
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
            var input = "6 7 8 9";
            var mockAnswerGenerator = new Mock<AnswerGenerator>();
            mockAnswerGenerator.Setup(_ => _.Generate()).Returns(string.Empty);
            var game = new BullsAndCowsGame(mockAnswerGenerator.Object);
            // when
            var output = game.Guess(input);
            // then
            Assert.Equal("0A0B", output);
        }

        [Theory]
        [InlineData("1 2 3 4", "1567")]
        [InlineData("2 1 3 4", "5167")]
        [InlineData("2 3 1 4", "5617")]
        [InlineData("2 3 4 1", "5671")]
        public void Should_return_1A0B_when_1_position_correct_and_other_wrong(string input, string answer)
        {
            var mockAnswerGenerator = new Mock<AnswerGenerator>();
            mockAnswerGenerator.Setup(_ => _.Generate()).Returns(answer);
            var game = new BullsAndCowsGame(mockAnswerGenerator.Object);
            var output = game.Guess(input);
            Assert.Equal("1A0B", output);
        }
        
        [Theory]
        [InlineData("1 2 3 4", "5167")]
        [InlineData("1 2 3 4", "5617")]
        [InlineData("1 2 3 4", "5671")]
        public void Should_return_0A1B_when_1_position_wrong_and_other_digit_no_match(string input, string answer)
        {
            var mockAnswerGenerator = new Mock<AnswerGenerator>();
            mockAnswerGenerator.Setup(_ => _.Generate()).Returns(answer);
            var game = new BullsAndCowsGame(mockAnswerGenerator.Object);
            var output = game.Guess(input);
            Assert.Equal("0A1B", output);
        }
        
        [Theory]
        [InlineData("0 1 3 2", "0123")]
        [InlineData("1 2 3 4", "2134")]
        public void Should_return_2A2B_when_2_position_correct_and_2_position_wrong(string input, string answer)
        {
            var mockAnswerGenerator = new Mock<AnswerGenerator>();
            mockAnswerGenerator.Setup(_ => _.Generate()).Returns(answer);
            var game = new BullsAndCowsGame(mockAnswerGenerator.Object);
            var output = game.Guess(input);
            Assert.Equal("2A2B", output);
        }
        
        [Theory]
        [InlineData("1 2 3 4", "1234")]
        [InlineData("5 6 7 8", "5678")]
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