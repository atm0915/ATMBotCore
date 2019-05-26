using System.Reflection;
using System.Threading.Tasks;
using ATMBotCore.Logging;
using ATMBotCore.Storage;
using Discord.Commands;
using Discord.WebSocket;

namespace ATMBotCore.Handlers
{
    public class DiscordCommandHandler : ICommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commandService;
        private readonly IDataStorage _storage;
        private readonly ILogger _logger;

        public DiscordCommandHandler(DiscordSocketClient client, CommandService commandService, IDataStorage storage,ILogger logger)
        {
            _client = client;
            _commandService = commandService;
            _storage = storage;
            _logger = logger;
        }

        public async Task InitializeAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly(), InversionOfControl.Container);
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            if (!(s is SocketUserMessage msg))
            {
                return;
            }

            var argPos = 0;
            if (msg.HasCharPrefix(_storage.RestoreObject<char>(Constants.PrefixConfigKey), ref argPos))
            {
                var context = new SocketCommandContext(_client, msg);
                await TryRunAsBotCommand(context, argPos).ConfigureAwait(false);
            }
        }

        private async Task TryRunAsBotCommand(SocketCommandContext context, int argPos)
        {
            var result = await _commandService.ExecuteAsync(context, argPos, InversionOfControl.Container);

            if (!result.IsSuccess)
            {
                _logger.Log($"Command execution failed. Reason: {result.ErrorReason}.");
            }
        }
    }
}