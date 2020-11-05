namespace BullsAndCowsTest
{
    using BullsAndCows;
    using Xunit;

    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_return_true_when_ValidateGuess_given_4_different_numbers()
        {
            // given
            string guess = "1 2 3 4";

            // when
            BullsAndCowsGame game = new BullsAndCowsGame();
            bool isValid = game.ValidateGuess(guess);

            // then
            Assert.True(isValid);
        }

        [Fact]
        public void Should_return_false_when_ValidateGuess_given_2_numbers()
        {
            // given
            string guess = "1 2";

            // when
            BullsAndCowsGame game = new BullsAndCowsGame();
            bool isValid = game.ValidateGuess(guess);

            // then
            Assert.False(isValid);
        }
    }
}
