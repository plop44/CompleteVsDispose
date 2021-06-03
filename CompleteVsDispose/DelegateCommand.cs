using System;
using System.Windows.Input;

namespace CompleteVsDispose
{
    internal class DelegateCommand : ICommand
    {
        private readonly Action _command;

        public DelegateCommand(Action command)
        {
            _command = command;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _command.Invoke();
        }
    }

    internal class DelegateCommand<T> : ICommand where T : class
    {
        private readonly Action<T> _command;

        public DelegateCommand(Action<T> command)
        {
            _command = command;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _command.Invoke(parameter as T);
        }
    }
}