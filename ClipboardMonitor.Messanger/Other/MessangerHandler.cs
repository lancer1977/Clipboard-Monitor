using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardMonitor.Broadcaster.Other;

public class HttpClientMessangerHandler : IMessangerHandler
{
    private readonly HttpClient _httpClient = new HttpClient();
    public string Port { get; set; }
    public string Address { get; set; }
    public bool Enabled { get; set; }

    public async Task SendMessage(string json)
    {
        try
        {
            //var json = JsonConvert.SerializeObject(payload);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var url = $"{Address}:{Port}";
            Debug.WriteLine(url);
            Debug.WriteLine(json);
            await _httpClient.PostAsync(url, httpContent);
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
   
    }
}