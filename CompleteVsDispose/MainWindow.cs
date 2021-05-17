using System;
using System.ComponentModel;
using System.Windows;

namespace CompleteVsDispose
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += OnClosing;
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            (DataContext as IDisposable)?.Dispose();
        }
    }
}
