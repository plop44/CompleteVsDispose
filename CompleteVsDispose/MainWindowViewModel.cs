using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CompleteVsDispose.Completing;
using CompleteVsDispose.Disposing;

namespace CompleteVsDispose
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly ObservableCollection<object> _viewModels;

        public MainWindowViewModel()
        {
            _viewModels = new ObservableCollection<object>
            {
                new ParentViewModelCompleting(),
                new ParentViewModelDisposing()
            };

            AddCompletingViewModelCommand = new DelegateCommand(() => _viewModels.Add(new ParentViewModelCompleting()));
            AddDisposingViewModelCommand = new DelegateCommand(() => _viewModels.Add(new ParentViewModelDisposing()));
            RemoveViewModelCommand = new DelegateCommand<object>(t =>
            {
                _viewModels.Remove(t);
                (t as IDisposable)?.Dispose();
            });
        }

        public ICommand AddCompletingViewModelCommand { get; }
        public ICommand AddDisposingViewModelCommand { get; }

        public IEnumerable<object> ViewModels => _viewModels;

        public ICommand RemoveViewModelCommand { get; }

        public void Dispose()
        {
            foreach (var viewModel in _viewModels) (viewModel as IDisposable)?.Dispose();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}