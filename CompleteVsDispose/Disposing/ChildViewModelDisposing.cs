using System;
using System.ComponentModel;

namespace CompleteVsDispose.Disposing
{
    public class ChildViewModelDisposing : INotifyPropertyChanged, IDisposable
    {
        private readonly IDisposable _subscription;

        public ChildViewModelDisposing(long key, IObservable<double> observable)
        {
            Key = key;
            _subscription = observable
                .Subscribe(t =>
                    {
                        Value = t;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                    }
                );
        }

        public long Key { get; }
        public double Value { get; private set; }

        public void Dispose()
        {
            _subscription?.Dispose();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}