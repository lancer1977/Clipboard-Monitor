using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;

namespace ClipboardMonitor.Listener;

public class ClipboardController : WebApiController //, ILocalCombatManagerService
{
    private readonly IListener _listener; 

    public ClipboardController(IListener listener)

    {
        _listener = listener;
    }
 
    [Route(HttpVerbs.Post, "/")]
    public async Task PostJsonData()
    {
        var data = await HttpContext.GetRequestBodyAsStringAsync();
        Console.WriteLine(data);
        _listener.MessageReceived(data.ToString());
        // Perform an operation with the data
        //await SaveData(data);
    }
}