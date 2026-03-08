using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardMonitor.Broadcaster.Other;

public class HttpClientMessengerHandler : IMessengerHandler
{
    private readonly HttpClient _httpClient = new HttpClient();
    public string Port { get; set; }
    public string Address { get; set; }
    public bool Enabled { get; set; }

    public async Task SendMessage(string message)
    {
        try
        {
            // NOTE: SettingsViewModel passes raw clipboard text (not JSON).
            // Use text/plain so the receiver can treat the body as the message.
            var httpContent = new StringContent(message, Encoding.UTF8, "text/plain");
            var url = $"{Address}:{Port}";
            Debug.WriteLine(url);
            Debug.WriteLine(message);
            await _httpClient.PostAsync(url, httpContent);
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
   
    }
}
