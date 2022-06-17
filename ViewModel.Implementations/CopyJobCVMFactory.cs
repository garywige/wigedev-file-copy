using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class CopyJobCVMFactory : ICopyJobCVMFactory
    {
        protected IFactory<ISetExecuteCommand> editCommandFactory;
        protected IFactory<ISetExecuteCommand> deleteCommandFactory;

        public CopyJobCVMFactory(
            IFactory<ISetExecuteCommand> editCommandFactory,
            IFactory<ISetExecuteCommand> deleteCommandFactory)
        {
            this.editCommandFactory = editCommandFactory;
            this.deleteCommandFactory = deleteCommandFactory;
        }

        public ICopyJobControlViewModel Create()
        {
            return new CopyJobControlViewModel("", "", editCommandFactory.Create(), deleteCommandFactory.Create());
        }
    }
}
