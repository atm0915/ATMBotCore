using ATMBotCore.Discord;
using ATMBotCore.Storage;
using ATMBotCore.Storage.Implementations;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace ATMBotCore
{
    public static class InversionOfControl
    {
        private static ServiceProvider _provider;

        public static ServiceProvider Provider => GetOrInitProvider();

        private static ServiceProvider GetOrInitProvider()
        {
            if (_provider is null)
            {
                InitializeProvider();
            }

            return _provider;
        }

        private static void InitializeProvider()
        {
            _provider = new ServiceCollection()
                        .AddSingleton<ATMBot>()
                        .AddSingleton<IDataStorage, JsonStorage>()
                        .AddSingleton<ILogger, Logger>()
                        .AddSingleton<DiscordLogger>()
                        .AddSingleton<DiscordSocketClient>(s => new DiscordSocketClient(SocketConfig.GetDefault()))
                        .AddSingleton<Connection>()
                        .BuildServiceProvider();
        }
    }
}