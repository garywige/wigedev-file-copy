using System;
using System.Windows.Input;

namespace Tests
{
    public class FakeCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            WasCanExecuteCalled = true;
            return true;
        }

        public void Execute(object? parameter)
        {
            WasExecuteCalled = true;
        }

        public bool WasCanExecuteCalled { get; private set; } = false;
        public bool WasExecuteCalled { get; private set; } = false;
    }
}
