using WigeDev.ViewModel.Interfaces;
using System.Windows.Input;

namespace WigeDev.ViewModel.Implementations
{
    public class CopyJobCVMFactory : ICopyJobCVMFactory
    {
        protected ICommand editCommand;
        protected ICommand deleteCommand;

        public CopyJobCVMFactory(ICommand editCommand, ICommand deleteCommand)
        {
            this.editCommand = editCommand;
            this.deleteCommand = deleteCommand;
        }

        public ICopyJobControlViewModel Create()
        {
            return new CopyJobControlViewModel("", "", editCommand, deleteCommand);
        }
    }
}
