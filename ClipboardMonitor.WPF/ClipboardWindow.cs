
using System.Windows;
using ClipboardMonitor.Core;

namespace ClipboardMonitor.WPF
{
    public abstract class ClipboardWindow : Window
    {
        public IClipboardMonitor ClipboardMonitor { get; }

        protected ClipboardWindow()
        {
            ClipboardMonitor = new ClipboardHandler(this);
        }
    }
     
}
 