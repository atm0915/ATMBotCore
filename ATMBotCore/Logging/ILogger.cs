using System.Threading.Tasks;
using Discord;

namespace ATMBotCore.Logging
{
    public interface ILogger
    {
        void Log(string message);
        Task Log(LogMessage logMessage);
    }
}