using System.Windows.Input;
using WigeDev.Execute.Interfaces;
using WigeDev.Validation.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class CopyCancelCommand : ICommand
    {
        protected IValidator validator;
        protected IExecute execute;
        protected bool lastCanExecute;

        public CopyCancelCommand(IValidator validator, IExecute execute)
        {
            this.validator = validator;
            this.execute = execute;
            lastCanExecute = CanExecute(null);
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => validator.IsValid;

        public void Execute(object? parameter) => execute.Execute();

        public void TestCanExecute()
        {
            var result = CanExecute(null);

            if (result != lastCanExecute)
            {
                lastCanExecute = result;
                if (CanExecuteChanged != null)
                    CanExecuteChanged(this, new EventArgs());
            }
        }
    }
}
