using System.Threading.Tasks;

namespace ClipboardMonitor.Core
{

    public interface IMessangerHandler
    {
        Task SendMessage(string json);
    }
}