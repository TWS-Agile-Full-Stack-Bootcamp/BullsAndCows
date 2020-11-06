namespace BullsAndCowsTest
{
    using BullsAndCows;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var class1 = new BullsAndCowsGame();
            Assert.NotNull(class1);
        }
    }
}
