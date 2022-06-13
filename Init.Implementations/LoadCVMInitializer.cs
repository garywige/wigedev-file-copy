using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.Init.Implementations
{
    public class LoadCVMInitializer : IInitializer<ICommandControlViewModel>
    {
        protected IJobStatus jobStatus;

        public LoadCVMInitializer(IJobStatus jobStatus)
        {
            this.jobStatus = jobStatus;
            jobStatus.PropertyChanged += (s, e) => canExecuteChanged?.Invoke(this, new EventArgs());
        }

        public ICommandControlViewModel Initialize()
        {
            return new CommandControlViewModel(
                "Load Batch", 
                new CECCommand(
                    new Command(
                        () => !jobStatus.IsCopying, 
                        () => { }
                        ),
                    ref canExecuteChanged
                    )
                );
        }

        protected EventHandler canExecuteChanged;
    }
}
