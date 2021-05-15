using System;
using System.ComponentModel;

namespace CompleteVsDispose.Completing
{
    public class ChildViewModelCompleting : INotifyPropertyChanged
    {
        public ChildViewModelCompleting(long key, IObservable<double> observable)
        {
            Key = key;
            // we rely on observable completing
            observable
                .Subscribe(t =>
                    {
                        Value = t;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                    }
                );
        }

        public long Key { get; }
        public double Value { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}