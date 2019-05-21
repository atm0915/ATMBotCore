using Xunit;

namespace ATMBotCore.xUnit.Tests
{
    public class UtilityTests
    {
        [Fact]
        public void MyFirstTest()
        {
            const int expected = 5;

            int actual = Utilities.MyUtility(5);

            Assert.Equal(expected, actual);
        }
    }
}