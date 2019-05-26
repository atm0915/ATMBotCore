using System.Threading.Tasks;

namespace ATMBotCore.Connection
{
    public interface IConnection
    {
        Task Connect();
    }
}