using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ATMBotCore
{
    internal static class Program
    {
        private static async Task Main()
        {
            await InversionOfControl.Container.GetInstance<ATMBot>().RunAsync();
            await Task.Delay(-1).ConfigureAwait(false);
        }
    }
}