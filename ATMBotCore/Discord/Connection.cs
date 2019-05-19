using System.Threading.Tasks;
using ATMBotCore.Discord.Entities;
using Discord.WebSocket;

namespace ATMBotCore.Discord
{
    public class Connection
    {
        private DiscordSocketClient _client;
        private DiscordLogger _logger;

        public Connection(DiscordLogger logger)
        {
            _logger = logger;
        }

        internal async Task ConnectAsync(ATMBotConfig config)
        {
            _client = new DiscordSocketClient(config.SocketConfig);

            _client.Log += _logger.Log;
        }
    }
}