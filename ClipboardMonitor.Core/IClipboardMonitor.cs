using System;

namespace ClipboardMonitor.Core
{
    public interface IClipboardMonitor
    {
        bool MonitorClipboard { get; set; }
        event EventHandler<ClipboardArgs> OnClipboardChanged;
    }
}
