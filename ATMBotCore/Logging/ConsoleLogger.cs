using System;
using System.Threading.Tasks;
using Discord;

namespace ATMBotCore.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            if (message is null)
                throw new ArgumentException("The message to log was null");
            Console.WriteLine(message);
        }

        public Task Log(LogMessage logMessage)
        {
            Log(logMessage.Message);
            return Task.CompletedTask;
        }
    }
}