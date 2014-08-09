using System;

namespace ClipboardMonitorClass
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