using System;

namespace ClipboardMonitor.Core
{
    public class ClipboardArgs : EventArgs
    {
        public readonly string Text;

        public ClipboardArgs(string data)
        {
            Text = data;
        }
    }
}