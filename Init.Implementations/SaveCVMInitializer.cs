using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.Init.Implementations
{
    public class SaveCVMInitializer : IInitializer<ICommandControlViewModel>
    {
        protected IJobStatus jobStatus;
        protected INotifyList<ICopyJobControlViewModel> jobList;

        public SaveCVMInitializer(IJobStatus jobStatus, INotifyList<ICopyJobControlViewModel> jobList)
        {
            this.jobStatus = jobStatus;
            jobStatus.PropertyChanged += (s, e) => canExecuteChanged?.Invoke(this, new EventArgs());
            this.jobList = jobList;
            jobList.CollectionChanged += (s, e) => canExecuteChanged?.Invoke(this, new EventArgs());
        }

        public ICommandControlViewModel Initialize() =>
            new CommandControlViewModel(
                "Save Batch", 
                new CECCommand(
                    new Command(
                        () => !jobStatus.IsCopying && jobList.Count != 0, 
                        () => { }), 
                    ref canExecuteChanged
                    )
                );
        

        protected EventHandler canExecuteChanged;
    }
}
