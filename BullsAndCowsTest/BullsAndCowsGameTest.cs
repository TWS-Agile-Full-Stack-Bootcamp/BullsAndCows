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

        [Fact]
        public void Should_return_false_when_ValidateGuess_given_4_numbers_with_duplicate()
        {
            // given
            string guess = "1 1 2 3";

            // when
            BullsAndCowsGame game = new BullsAndCowsGame();
            bool isValid = game.ValidateGuess(guess);

            // then
            Assert.False(isValid);
        }

        [Fact]
        public void Should_return_wrong_input_message_when_Guess_given_invalid_guess()
        {
            // given
            string answer = "1 2 3 4";
            string guess = "1 1 2 3";

            // when
            BullsAndCowsGame game = new BullsAndCowsGame();
            string result = game.Guess(answer, guess);

            // then
            Assert.Equal("Wrong Input，Input again", result);
        }

        [Fact]
        public void Should_return_xAxB_when_Guess_given_valid_guess()
        {
            // given
            string answer = "1 2 3 4";
            string guess = "1 2 5 6";

            // when
            BullsAndCowsGame game = new BullsAndCowsGame();
            string result = game.Guess(answer, guess);

            // then
            Assert.Equal("2A0B", result);
        }
    }
}
