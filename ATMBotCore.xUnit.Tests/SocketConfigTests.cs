using ATMBotCore.Discord;
using Discord;
using Xunit;

namespace ATMBotCore.xUnit.Tests
{
    public class SocketConfigTests
    {
        [Fact]
        public void ConfigDefaultTest()
        {
            const LogSeverity expected = LogSeverity.Verbose;
            var actual = SocketConfig.GetDefault().LogLevel;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConfigNewTest()
        {
            var actual = SocketConfig.GetNew();
            Assert.NotNull(actual);
        }
    }
}