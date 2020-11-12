using BullsAndCows;
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
        }

        [Theory]
        [InlineData("1234")]
        [InlineData("12 3 4")]
        [InlineData("12 34")]
        public void Should_return_wrong_input_message_when_input_not_between_space(string input)
        {
            var game = new BullsAndCowsGame();
            var output = game.Judge(input);
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
            var output = game.Judge(input);
            Assert.Equal("Wrong Input, input again", output);
        }
    }
}