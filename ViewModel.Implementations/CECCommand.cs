using System;
using System.Windows.Input;

namespace WigeDev.ViewModel.Implementations
{
    public class CECCommand : ICommand
    {
        protected ICommand command;

        public CECCommand(ICommand command, ref EventHandler? triggerCanExecuteChanged)
        {
            this.command = command;
            triggerCanExecuteChanged += (s, e) => CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) =>
            command.CanExecute(parameter);

        public void Execute(object? parameter) =>
            command.Execute(parameter);
    }
}
