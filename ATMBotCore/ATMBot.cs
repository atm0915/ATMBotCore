using System;
using System.Threading.Tasks;
using ATMBotCore.Discord;
using ATMBotCore.Discord.Entities;
using ATMBotCore.Storage;

namespace ATMBotCore
{
    public class ATMBot
    {
        private readonly IDataStorage _storage;
        private readonly Connection _connection;

        public ATMBot(IDataStorage storage, Connection connection)
        {
            _storage = storage;
            _connection = connection;
        }

        public async Task Start()
        {
            await _connection.ConnectAsync(new ATMBotConfig
            {
                Token = _storage.RestoreObject<string>("Config/BotToken")
            });

            Console.ReadKey();
        }
    }
}