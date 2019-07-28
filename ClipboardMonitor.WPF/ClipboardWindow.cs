using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using ClipboardMonitor.Core;

namespace ClipboardMonitor.WPF
{
    public abstract class ClipboardWindow : Window , IClipboardMonitor
    {
        public bool MonitorClipboard { get; set; } 
        public event EventHandler<ClipboardArgs> OnClipboardChanged;
         
        private void NotifyClipboardChanged(string text)
        {
            if (MonitorClipboard == false) return;
            OnClipboardChanged?.Invoke(null, new ClipboardArgs(text));
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            if (hwndSource != null)
            {
                _installedHandle = hwndSource.Handle;
                _viewerHandle = SetClipboardViewer(_installedHandle);
                hwndSource.AddHook(HwndSourceHook);
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            ChangeClipboardChain(_installedHandle, _viewerHandle);
            int error = Marshal.GetLastWin32Error();
            e.Cancel = error != 0;

            base.OnClosing(e);
        }
        protected override void OnClosed(EventArgs e)
        {
            _viewerHandle = IntPtr.Zero;
            _installedHandle = IntPtr.Zero;
            base.OnClosed(e);
        }
        private IntPtr HwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
             _viewerHandle = lParam;
            try
            {
                switch (msg)
                {
                    case WmChangecbchain:
                       
                        if (_viewerHandle != IntPtr.Zero)
                        {
                            SendMessage(_viewerHandle, msg, wParam, lParam);
                        }

                        break;

                    case WmDrawclipboard:
                        if (_viewerHandle != IntPtr.Zero)
                        {
                            SendMessage(_viewerHandle, msg, wParam, lParam);
                        }
                        ClipboardChanged();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return IntPtr.Zero;
        }

        private void ClipboardChanged()
        {
            var text = Clipboard.GetText();
            if (string.IsNullOrEmpty(text)) return;
            NotifyClipboardChanged(text);
        }
        private const int WmDrawclipboard = 0x308;
        private const int WmChangecbchain = 0x30D;
        private IntPtr _installedHandle = IntPtr.Zero;
        private IntPtr _viewerHandle = IntPtr.Zero;

        [DllImport("user32.dll")]
        private static extern IntPtr SetClipboardViewer(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ChangeClipboardChain(IntPtr hWnd, IntPtr hWndNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);


    }
     
}
 