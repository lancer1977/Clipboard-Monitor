namespace ClipboardMonitor.Listener;

public class ResultHandler
{
    public ResultHandler()
    {
        Code = System.Net.HttpStatusCode.BadRequest;
    }

    public object Data { get; set; }
    public bool Failed { get; set; }

    public System.Net.HttpStatusCode Code { get; set; }

}