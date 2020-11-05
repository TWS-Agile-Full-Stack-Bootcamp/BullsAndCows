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
        private IConsole console;

        public BullsAndCowsGameTest()
        {
            this.answerGenerator = new AnswerGenerator(new Random());
            this.console = new ConsoleWrapper();
        }

        [Fact]
        public void Should_return_true_when_ValidateGuess_given_4_different_numbers()
        {
            // given
            string guess = "1 2 3 4";

            // when
            BullsAndCowsGame game = new BullsAndCowsGame(answerGenerator, console);
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
            BullsAndCowsGame game = new BullsAndCowsGame(answerGenerator, console);
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
            BullsAndCowsGame game = new BullsAndCowsGame(answerGenerator, console);
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
            BullsAndCowsGame game = new BullsAndCowsGame(answerGenerator, console);
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
            BullsAndCowsGame game = new BullsAndCowsGame(answerGenerator, console);
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
            new BullsAndCowsGame(mock.Object, console);

            // then
            mock.Verify(_ => _.Generate());
        }

        [Fact]
        public void Should_finish_game_when_guess_right_in_first_round()
        {
            // given
            var mockAnswerGenerator = new Mock<AnswerGenerator>(new Random());
            mockAnswerGenerator.Setup(_ => _.Generate()).Returns(new List<int> { 1, 2, 3, 4 });

            var mockIConsole = new Mock<IConsole>();
            mockIConsole.Setup(_ => _.ReadLine()).Returns("1 2 3 4");
            BullsAndCowsGame game = new BullsAndCowsGame(mockAnswerGenerator.Object, mockIConsole.Object);

            // when
            game.Run();

            // then
            mockIConsole.Verify(_ => _.WriteLine("4A0B"));
        }

        [Fact]
        public void Should_finish_game_when_guess_wrong_in_all_6_rounds()
        {
            // given
            var mockAnswerGenerator = new Mock<AnswerGenerator>(new Random());
            mockAnswerGenerator.Setup(_ => _.Generate()).Returns(new List<int> { 1, 2, 3, 4 });

            var mockIConsole = new Mock<IConsole>();
            mockIConsole.SetupSequence(_ => _.ReadLine())
                .Returns("1 1 2 3")
                .Returns("1 1")
                .Returns("1 3 2 4")
                .Returns("1 4 3 2")
                .Returns("5 6 7 8")
                .Returns("9 8 7 6");
            BullsAndCowsGame game = new BullsAndCowsGame(mockAnswerGenerator.Object, mockIConsole.Object);

            // when
            game.Run();

            // then
            mockIConsole.Verify(_ => _.WriteLine("Wrong Input，Input again"), Times.Exactly(2));
            mockIConsole.Verify(_ => _.WriteLine("2A2B"), Times.Exactly(2));
            mockIConsole.Verify(_ => _.WriteLine("0A0B"), Times.Exactly(2));
        }
    }
}
