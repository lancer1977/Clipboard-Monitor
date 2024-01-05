using System;
using System.Reactive.Linq;
using ClipboardMonitor.Broadcaster.Other;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ClipboardMonitor.Broadcaster.Views;

public class SettingsViewModel : PolyhydraGames.Core.ReactiveUI.ViewModelAsyncBase
{

    [Reactive] public string Port { get; set; }
    [Reactive] public string Address { get; set; }
    [Reactive] public bool Enabled { get; set; }
    [Reactive] public string Preview { get; set; }

    public SettingsViewModel(IClipboardMonitor monitor, HttpClientMessangerHandler handler)
    {
        Port = "8080";
        Address = "http://localhost";

        //Observable.FromEvent<ClipboardArgs>(x=> monitor.OnClipboardChanged += x,
        var onTextChanged = Observable.FromEventPattern<EventHandler<ClipboardArgs>, ClipboardArgs>(
            x => monitor.OnClipboardChanged += x,
            x => monitor.OnClipboardChanged -= x);
        onTextChanged.Select(x => x.EventArgs.Text).Subscribe(async x =>
        {
            Preview = x;
            await handler.SendMessage(x);
          
        });
        this.WhenAnyValue(x => x.Enabled).Subscribe(x =>
        {
            monitor.MonitorClipboard = x;
            handler.Enabled = x;
        });

        this.WhenAnyValue(x => x.Address).Subscribe(x => handler.Address = x);
        this.WhenAnyValue(x => x.Port).Subscribe(x => handler.Port = x);
    }
}