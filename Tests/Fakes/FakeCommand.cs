using System;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeCommand : ISetExecuteCommand
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

        public void SetExecute(Action execute)
        {
            throw new NotImplementedException();
        }

        public bool WasCanExecuteCalled { get; private set; } = false;
        public bool WasExecuteCalled { get; private set; } = false;
    }
}
