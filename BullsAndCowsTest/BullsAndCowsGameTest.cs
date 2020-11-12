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

        [Fact]
        public void Should_return_wrong_input_message_when_input_not_between_space()
        {
            var game = new BullsAndCowsGame();
            var input = "1234";
            var output = game.Judge(input);
            Assert.Equal("Wrong Input, input again", output);
        }
    }
}