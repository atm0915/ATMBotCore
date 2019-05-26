using ATMBotCore.Connection;
using ATMBotCore.Handlers;
using ATMBotCore.Logging;
using ATMBotCore.Storage;
using ATMBotCore.Storage.Implementations;
using Discord.WebSocket;
using Lamar;


namespace ATMBotCore
{
    public static class InversionOfControl
    {
        private static Container _container;

        public static Container Container
        {
            get { return GetOrInitProvider(); }
        }

        private static Container GetOrInitProvider()
        {
            if (_container is null)
            {
                InitializeContainer();
            }

            return _container;
        }

        private static void InitializeContainer()
        {
            _container = new Container(c =>
            {
                c.ForSingletonOf<IDataStorage>().Use<JsonStorage>();
                c.For<IConnection>().Use<DiscordConnection>();
                c.For<ICommandHandler>().Use<DiscordCommandHandler>();
                c.For<ILogger>().Use<ConsoleLogger>();
                c.ForSingletonOf<DiscordSocketClient>().UseIfNone(DiscordSocketClientFactory.GetDefault());
            });
        }
    }
}