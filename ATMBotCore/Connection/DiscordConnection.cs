using System.Threading.Tasks;
using ATMBotCore.Logging;
using ATMBotCore.Storage;
using Discord;
using Discord.WebSocket;

namespace ATMBotCore.Connection
{
    public class DiscordConnection : IConnection
    {
        private readonly DiscordSocketClient _client;
        private readonly IDataStorage _storage;
        private readonly ILogger _logger;

        public DiscordConnection(DiscordSocketClient client, IDataStorage storage, ILogger logger)
        {
            _client = client;
            _storage = storage;
            _logger = logger;
        }

        public async Task Connect()
        {
            _client.Log += _logger.Log;
            await _client.LoginAsync(TokenType.Bot, _storage.RestoreObject<string>(Constants.TokenConfigKey));
            await _client.StartAsync();
        }
    }
}