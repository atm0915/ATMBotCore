using System;
using System.Threading.Tasks;
using ATMBotCore.Discord;
using ATMBotCore.Discord.Entities;
using ATMBotCore.Storage;
using ATMBotCore.Storage.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ATMBotCore
{
    internal static class Program
    {
        private static IServiceProvider _services;

        private static async Task Main()
        {
            var discordBotConfig = new ATMBotConfig
            {
                Token = "ABC",
                SocketConfig = SocketConfig.GetDefault()
            };


            //Setup Our Services
            _services = ConfigureServices();

            var a = _services.GetRequiredService<Connection>();

            Console.ReadKey();

        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                   .AddSingleton<IDataStorage, InMemoryStorage>()
                   .AddSingleton<ILogger, Logger>()
                   .AddSingleton<DiscordLogger>()
                   .AddSingleton<Connection>()
                   .BuildServiceProvider();
        }
    }
}