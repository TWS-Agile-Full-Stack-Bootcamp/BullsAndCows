using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame_correct()
        {
            var game = new BullsAndCowsGame();
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Theory]
        [InlineData("1234")]
        [InlineData("12 3 4")]
        [InlineData("12 34")]
        public void Should_return_wrong_input_message_when_input_not_between_space(string input)
        {
            var game = new BullsAndCowsGame();
            var output = game.JudgeAnswer(input);
            Assert.Equal("Wrong Input, input again", output);
        }

        [Theory]
        [InlineData("1 1 3 4")]
        [InlineData("1 3 3 4")]
        [InlineData("1 3 4 4")]
        [InlineData("1 3 4 1")]
        public void Should_return_wrong_input_message_when_input_digit_no_different(string input)
        {
            var game = new BullsAndCowsGame();
            var output = game.JudgeAnswer(input);
            Assert.Equal("Wrong Input, input again", output);
        }

        [Fact]
        public void Game_should_no_continue_when_guess_chances_more_than_6()
        {
            var game = new BullsAndCowsGame();

            string wrongInput = "1 2 3 4";
            for (int i = 0; i < 6; i++)
            {
                game.JudgeAnswer(wrongInput);
            }

            Assert.False(game.CanContinue);
        }

        [Fact]
        public void Should_return_0A0B_when_input_all_wrong()
        {
            var mockJudge = new Mock<Judge>();
            mockJudge.Setup(judge => judge.SetSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockJudge.Object);
            var input = "5 6 7 8";
            var output = game.JudgeAnswer(input);
            Assert.Equal("0A0B", output);
        }

        [Fact]
        public void Should_return_0AxB_when_input_x_wrong_position()
        {
            var mockJudge = new Mock<Judge>();
            mockJudge.Setup(judge => judge.SetSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockJudge.Object);
            var input = "4 5 6 7";
            var output = game.JudgeAnswer(input);
            Assert.Equal("0A1B", output);
        }

        [Fact]
        public void Should_return_xA0B_when_input_x_correct()
        {
            var mockJudge = new Mock<Judge>();
            mockJudge.Setup(judge => judge.SetSecret()).Returns("1234");
            var game = new BullsAndCowsGame(mockJudge.Object);
            var input = "1 5 6 7";
            var output = game.JudgeAnswer(input);
            Assert.Equal("1A0B", output);
        }
    }
}