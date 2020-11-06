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
    }
}
