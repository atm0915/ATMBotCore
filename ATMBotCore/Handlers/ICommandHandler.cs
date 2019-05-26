using System.Threading.Tasks;

namespace ATMBotCore.Handlers
{
    public interface ICommandHandler
    {
        Task InitializeAsync();
    }
}