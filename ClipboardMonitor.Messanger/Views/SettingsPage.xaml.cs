using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClipboardMonitor.Broadcaster.Other;
using PolyhydraGames.Core.Interfaces;

namespace ClipboardMonitor.Broadcaster.Views
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsViewModel ViewModel { get; set; }
        public SettingsPage()
        {
            InitializeComponent();
            var win = App.Current.MainWindow as MainWindow;

            DataContext = ViewModel = new SettingsViewModel(win.ClipboardMonitor, new HttpClientMessangerHandler());
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("In code.");
        }
    }
}
