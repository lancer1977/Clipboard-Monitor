// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using ClipboardMonitor.Listener;

var port = "8080"; // default
if (args.Length > 0)
{
    port = args[0];
}
Console.WriteLine($"Starting Clipboard Monitor Listener on port {port}...");
var listener = new Listener(){Port = port};
listener.Start();
Console.WriteLine($"Now running on port {port}.");
Console.WriteLine("Press a Key to Quit");
Console.ReadKey();
