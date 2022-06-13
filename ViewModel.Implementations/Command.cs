using System.Windows.Input;

namespace WigeDev.ViewModel.Implementations
{
    public class Command : ICommand
    {
        protected Func<bool> canExecute;
        protected Action execute;

        public Command(Func<bool> canExecute, Action execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => canExecute();

        public void Execute(object? parameter) => execute();
    }
}
