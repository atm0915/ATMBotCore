using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ATMBotCore
{
    internal static class Program
    {
        private static async Task Main()
        {
            var bot = InversionOfControl.Provider.GetRequiredService<ATMBot>();
            await bot.Start();
        }
    }
}