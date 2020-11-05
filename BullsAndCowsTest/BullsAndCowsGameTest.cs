namespace BullsAndCowsTest
{
    using System;
    using System.Collections.Generic;
    using BullsAndCows;
    using Moq;
    using Xunit;

    public class BullsAndCowsGameTest
    {
        private AnswerGenerator answerGenerator;

        public BullsAndCowsGameTest()
        {
            this.answerGenerator = new AnswerGenerator(new Random());
        }

        [Fact]
        public void Should_return_true_when_ValidateGuess_given_4_different_numbers()
        {
            // given
            string guess = "1 2 3 4";

            // when
            BullsAndCowsGame game = new BullsAndCowsGame(answerGenerator);
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
            BullsAndCowsGame game = new BullsAndCowsGame(answerGenerator);
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
            BullsAndCowsGame game = new BullsAndCowsGame(answerGenerator);
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
            BullsAndCowsGame game = new BullsAndCowsGame(answerGenerator);
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
            BullsAndCowsGame game = new BullsAndCowsGame(answerGenerator);
            string result = game.Guess(answer, guess);

            // then
            Assert.Equal("2A0B", result);
        }

        [Fact]
        public void Should_call_Generate_when_create_BullsAndCowsGame()
        {
            // given
            var mock = new Mock<AnswerGenerator>(new Random());
            mock.Setup(_ => _.Generate()).Returns(new List<int> { 1, 2, 3, 4 });

            // when
            new BullsAndCowsGame(mock.Object);

            // then
            mock.Verify(_ => _.Generate());
        }
    }
}
