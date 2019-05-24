using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ATMBotCore.xUnit.Tests
{
    public class LoggerTests
    {
        [Fact]
        public void BasicLoggerTest()
        {
            var logger = InversionOfControl.Provider.GetRequiredService<ILogger>();

            Assert.NotNull(logger);

            logger.Log("Hello World!");
            Assert.Throws<ArgumentException>(() => logger.Log(null));

        }
    }
}