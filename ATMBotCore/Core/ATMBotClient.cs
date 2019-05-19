using System;
using System.Threading.Tasks;
using ATMBotCore.Storage;
using ATMBotCore.Storage.Implementations;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace ATMBotCore.Core
{
    public class ATMBotClient
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        public ATMBotClient(CommandService commands = null, DiscordSocketClient client = null)
        {
            //Create our new DiscordClient (Setting LogServerity to Verbose)
            _client = client ?? new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose,
                AlwaysDownloadUsers = true,
                MessageCacheSize = 100
            });

            //Create our new CommandService (Setting RunMode to async by default on all commands)
            _commands = commands ?? new CommandService(new CommandServiceConfig
            {
                DefaultRunMode = RunMode.Async,
                CaseSensitiveCommands = false,
                LogLevel = LogSeverity.Verbose
            });
        }

        public async Task InitializeAsync()
        {
            //Setup Our Services
            _services = ConfigureServices();

            //Login with the client
            //await _client.LoginAsync(TokenType.Bot, _config.DiscordToken);

            //Start the client
            await _client.StartAsync();

            //Hook up our events
            HookEvents();


            //This is used so the bot doesn't shut down instantly.
            await Task.Delay(-1);
        }

        //This is where we hook up any events we want to use.
        private void HookEvents()
        {
            //_client.Log += LogAsync;
            //_client.Ready += OnReadyAsync;
        }


        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                   .AddSingleton<IDataStorage, InMemoryStorage>()
                   .BuildServiceProvider();
        }
    }
}