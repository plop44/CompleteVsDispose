using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace CompleteVsDispose.Completing
{
    public class ParentViewModelCompleting : IDisposable
    {
        private readonly ObservableCollection<ChildViewModelCompleting> _children = new ObservableCollection<ChildViewModelCompleting>();
        private readonly Subject<Unit> _dispose = new Subject<Unit>();

        public ParentViewModelCompleting()
        {
            Observable.Interval(TimeSpan.FromMilliseconds(300))
                .TakeUntil(_dispose)
                .GroupBy(t => t % 10)
                .Select(t => new ChildViewModelCompleting(t.Key, t.Select(t2 => new Random().NextDouble())))
                .ObserveOn(DispatcherScheduler.Current)
                .Subscribe(t => _children.Add(t));
        }

        public IEnumerable<ChildViewModelCompleting> Children => _children;

        public void Dispose()
        {
            if (_dispose.IsDisposed)
                return;

            _dispose.OnNext(Unit.Default);
            _dispose.Dispose();
        }
    }
}