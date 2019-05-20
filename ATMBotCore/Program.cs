using System;
using System.Threading.Tasks;
using ATMBotCore.Discord;
using ATMBotCore.Discord.Entities;
using ATMBotCore.Storage;
using ATMBotCore.Storage.Implementations;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace ATMBotCore
{
    internal static class Program
    {
        private static IServiceProvider _services;

        private static async Task Main()
        {
            //Setup Our Services
            _services = ConfigureServices();

            var storage = _services.GetRequiredService<IDataStorage>();

            var connection = _services.GetRequiredService<Connection>();
            await connection.ConnectAsync(new ATMBotConfig
            {
                Token = storage.RestoreObject<string>("Config/BotToken")
            });

            Console.ReadKey();

        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                   .AddSingleton<IDataStorage, JsonStorage>()
                   .AddSingleton<ILogger, Logger>()
                   .AddSingleton<DiscordLogger>()
                   .AddSingleton<DiscordSocketClient>(s => new DiscordSocketClient(SocketConfig.GetDefault()))
                   .AddSingleton<Connection>()
                   .BuildServiceProvider();
        }
    }
}