using System;
using System.ComponentModel;
using System.Windows.Input;

namespace CompleteVsDispose
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            DisposeCommand = new DelegateCommand(OnDisposeCommandExecute);
        }

        private void OnDisposeCommandExecute()
        {
            ParentViewModelCompleting?.Dispose();
            ParentViewModelDisposing?.Dispose();
        }

        public Completing.ParentViewModelCompleting ParentViewModelCompleting { get; } = new Completing.ParentViewModelCompleting();
        public Disposing.ParentViewModelDisposing ParentViewModelDisposing { get; } = new Disposing.ParentViewModelDisposing();
        public ICommand DisposeCommand { get; }

        public void Dispose()
        {
            ParentViewModelCompleting?.Dispose();
            ParentViewModelDisposing?.Dispose();
        }
    }
}