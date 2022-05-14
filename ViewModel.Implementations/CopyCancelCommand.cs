using System.Windows.Input;
using WigeDev.Validation.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class CopyCancelCommand : ICommand
    {
        protected IValidator validator;
        protected IExecute execute;

        public CopyCancelCommand(IValidator validator, IExecute execute)
        {
            this.validator = validator;
            this.execute = execute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => validator.IsValid;

        public void Execute(object? parameter)
        {
            execute.Execute();
        }
    }
}
