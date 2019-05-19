using Discord.WebSocket;

namespace ATMBotCore.Discord.Entities
{
    public class ATMBotConfig
    {
        public string Token { get; set; }
        public DiscordSocketConfig SocketConfig { get; set; }
    }
}