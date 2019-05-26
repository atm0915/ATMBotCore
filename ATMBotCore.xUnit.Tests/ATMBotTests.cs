using System.Threading.Tasks;
using ATMBotCore.Connection;
using ATMBotCore.Handlers;
using Moq;
using Xunit;

namespace ATMBotCore.xUnit.Tests
{
    public class ATMBotTests
    {
        [Fact]
        public static async Task TestRun()
        {
            var bot = new ATMBot(new Mock<IConnection>().Object, new Mock<ICommandHandler>().Object);
            await bot.RunAsync();
        }
    }
}