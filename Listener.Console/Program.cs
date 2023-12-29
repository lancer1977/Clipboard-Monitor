// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using ClipboardMonitor.Listener;

Console.WriteLine("Hello, World!");
var listener = new Listener(){Port = "8080"};
listener.Start();
Console.WriteLine("Now running on port 8080.");
Console.WriteLine("Press a Key to Quit");
Console.ReadKey();