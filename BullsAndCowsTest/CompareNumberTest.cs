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

        [Fact]
        public void Should_return_0A0B_when_guess_given_numbers_all_wrong()
        {
            // given
            string answer = "1 2 3 4";
            string guess = "5 6 7 8";

            // when
            BullsAndCowsComparators comparators = new BullsAndCowsComparators();
            string xAxB = comparators.CompareNumber(answer, guess);

            // then
            Assert.Equal("0A0B", xAxB);
        }

        [Fact]
        public void Should_return_0A4B_when_guess_given_numbers_all_correct_but_position_all_wrong()
        {
            // given
            string answer = "1 2 3 4";
            string guess = "4 3 2 1";

            // when
            BullsAndCowsComparators comparators = new BullsAndCowsComparators();
            string xAxB = comparators.CompareNumber(answer, guess);

            // then
            Assert.Equal("0A4B", xAxB);
        }

        [Fact]
        public void Should_return_0AxB_when_guess_given_numbers_partial_correct_but_position_all_wrong()
        {
            // given
            string answer = "1 2 3 4";
            string guess = "5 6 7 1";

            // when
            BullsAndCowsComparators comparators = new BullsAndCowsComparators();
            string xAxB = comparators.CompareNumber(answer, guess);

            // then
            Assert.Equal("0A1B", xAxB);
        }
    }
}
