using System.Threading.Tasks;
using ATMBotCore.Discord;
using ATMBotCore.Discord.Entities;
using Discord.Net;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ATMBotCore.xUnit.Tests
{
    public class ConnectionTests
    {
        [Fact]
        public async Task ConnectionAsyncTest()
        {
            await Assert.ThrowsAsync<HttpException>(AttemptWrongConnect);
        }

        private async Task AttemptWrongConnect()
        {
            var conn = InversionOfControl.Provider.GetRequiredService<Connection>();
            await conn.ConnectAsync(new ATMBotConfig
            {
                Token = "FAKE-TOKEN"
            });
        }

    }
}