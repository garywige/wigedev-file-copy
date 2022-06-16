using System.Windows.Input;

namespace WigeDev.ViewModel.Implementations
{
    public class SetExecuteCommand : ICommand
    {
        protected ICommand command;
        protected Action? execute;

        public SetExecuteCommand(ICommand command)
        {
            this.command = command;
            this.command.CanExecuteChanged += (s, e) => CanExecuteChanged?.Invoke(this, e);
            execute = null;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) =>
            command.CanExecute(parameter);

        public void Execute(object? parameter)
        {
            if (this.execute != null)
                this.execute();
            else
                command.Execute(parameter);
        }

        public void SetExecute(Action execute) =>
            this.execute = execute;
    }
}
