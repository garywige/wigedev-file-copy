using System.Windows.Input;
using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class CopyCancelCCVMInitializer : IInitializer<ICommandControlViewModel>
    {
        protected IJobStatus jobStatus;
        protected ICommand command;

        public CopyCancelCCVMInitializer(IJobStatus jobStatus, ICommand command)
        {
            this.jobStatus = jobStatus;
            this.command = command;
        }

        public ICommandControlViewModel Initialize() => new CopyCancelCommandControlViewModel(jobStatus, command);
    }
}
