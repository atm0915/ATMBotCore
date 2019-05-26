using System.Threading.Tasks;
using ATMBotCore.Connection;
using ATMBotCore.Handlers;

namespace ATMBotCore
{
    public class ATMBot
    {
        private readonly IConnection _connection;
        private readonly ICommandHandler _commandHandler;

        public ATMBot(IConnection connection, ICommandHandler commandHandler)
        {
            _connection = connection;
            _commandHandler = commandHandler;
        }

        public async Task RunAsync()
        {
            await _connection.Connect();
            await _commandHandler.InitializeAsync();
        }
    }
}