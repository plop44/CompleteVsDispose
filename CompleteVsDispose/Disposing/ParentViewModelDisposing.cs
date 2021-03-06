using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace CompleteVsDispose.Disposing
{
    public class ParentViewModelDisposing : INotifyPropertyChanged, IDisposable
    {
        private readonly ObservableCollection<ChildViewModelDisposing> _children = new ObservableCollection<ChildViewModelDisposing>();
        private readonly IDisposable _subscription;

        public ParentViewModelDisposing()
        {
            _subscription = Observable.Interval(TimeSpan.FromMilliseconds(300))
                .GroupBy(t => t % 10)
                .Select(t => new ChildViewModelDisposing(t.Key, t.Select(t2 => new Random().NextDouble())))
                .ObserveOn(DispatcherScheduler.Current)
                .Subscribe(t => _children.Add(t));
        }

        public IEnumerable<ChildViewModelDisposing> Children => _children;

        public void Dispose()
        {
            _subscription.Dispose();

            foreach (var childViewModel in _children) childViewModel.Dispose();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}