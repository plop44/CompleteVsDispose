using System.Windows;
using System.Windows.Input;

namespace CompleteVsDispose
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DisposeCommand = new DelegateCommand(OnDisposeCommandExecute);
            InitializeComponent();            
        }

        private void OnDisposeCommandExecute()
        {
            ParentViewModelCompleting?.Dispose();
            ParentViewModelDisposing?.Dispose();
        }

        public Completing.ParentViewModelCompleting ParentViewModelCompleting { get; } = new Completing.ParentViewModelCompleting();
        public Disposing.ParentViewModelDisposing ParentViewModelDisposing { get; } = new Disposing.ParentViewModelDisposing();
        public ICommand DisposeCommand { get; }
    }
}
