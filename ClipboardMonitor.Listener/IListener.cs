namespace ClipboardMonitor.Listener;

public interface IListener
{
    void MessageReceived(string message);
    IObservable<string> OnMessageReceived { get; }
}