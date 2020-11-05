using System.Collections.Immutable;
using BullsAndCows;
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
    }
}