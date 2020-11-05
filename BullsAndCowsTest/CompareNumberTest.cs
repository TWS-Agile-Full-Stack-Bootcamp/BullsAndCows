namespace BullsAndCowsTest
{
    using BullsAndCows;
    using Xunit;

    public class CompareNumberTest
    {
        [Fact]
        public void Should_return_4A0B_when_guess_given_numbers_all_correct_and_position_all_correct()
        {
            // given
            string answer = "1 2 3 4";
            string guess = "1 2 3 4";

            // when
            BullsAndCowsComparators comparators = new BullsAndCowsComparators();
            string xAxB = comparators.CompareNumber(answer, guess);

            // then
            Assert.Equal("4A0B", xAxB);
        }
    }
}
