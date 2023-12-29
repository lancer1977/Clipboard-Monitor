using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using ClipboardMonitor.Core;
using MvvmCross.Platforms.Wpf.Views;

namespace ClipboardMonitor.WPF
{
    public abstract class MvxClipboardWindow : MvxWindow
    {
        protected IClipboardMonitor ClipboardMonitor { get; }

        protected MvxClipboardWindow()
        {
            ClipboardMonitor = new ClipboardHandler(this);
        }


    }
}