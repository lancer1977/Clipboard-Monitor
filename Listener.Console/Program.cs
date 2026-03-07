// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text.Json;
using ClipboardMonitor.Listener;

var configPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
string? configuredPort = null;
string? configuredHost = null;

// Load from appsettings.json if exists
if (File.Exists(configPath))
{
    try
    {
        var json = File.ReadAllText(configPath);
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;
        
        if (root.TryGetProperty("Listener", out var listener))
        {
            if (listener.TryGetProperty("Port", out var portProp))
                configuredPort = portProp.GetString();
            if (listener.TryGetProperty("Host", out var hostProp))
                configuredHost = hostProp.GetString();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Warning: Could not parse appsettings.json: {ex.Message}");
    }
}

// Default values
var port = configuredPort ?? "8085";
var host = configuredHost ?? "0.0.0.0";

// CLI args override: --port <value> or first positional arg
for (int i = 0; i < args.Length; i++)
{
    if (args[i] == "--port" && i + 1 < args.Length)
    {
        port = args[i + 1];
        i++;
    }
    else if (!args[i].StartsWith("--"))
    {
        // Positional arg for backwards compatibility
        port = args[i];
    }
}

Console.WriteLine($"Starting Clipboard Monitor Listener on {host}:{port}...");
var listenerService = new Listener(){Port = port};
listenerService.Start();
Console.WriteLine($"Now running on {host}:{port}.");
Console.WriteLine("Press a Key to Quit");
Console.ReadKey();
