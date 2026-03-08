using System.Threading.Tasks;

namespace ClipboardMonitor.Core
{

    public interface IMessengerHandler
    {
        Task SendMessage(string message);
    }
}
