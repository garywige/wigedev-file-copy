using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.Init.Implementations
{
    public class SaveCVMInitializer : IInitializer<ICommandControlViewModel>
    {
        protected IJobStatus jobStatus;
        protected INotifyList<ICopyJobControlViewModel> jobList;
        protected IBrowserDialogAdapter browserDialogAdapter;

        public SaveCVMInitializer(IJobStatus jobStatus, INotifyList<ICopyJobControlViewModel> jobList, IBrowserDialogAdapter browserDialogAdapter)
        {
            this.jobStatus = jobStatus;
            jobStatus.PropertyChanged += (s, e) => canExecuteChanged?.Invoke(this, new EventArgs());
            this.jobList = jobList;
            jobList.CollectionChanged += (s, e) => canExecuteChanged?.Invoke(this, new EventArgs());
            this.browserDialogAdapter = browserDialogAdapter;
        }

        public ICommandControlViewModel Initialize() =>
            new CommandControlViewModel(
                "Save Batch", 
                new CECCommand(
                    new Command(
                        () => !jobStatus.IsCopying && jobList.Count != 0, 
                        () => 
                        {
                            if(browserDialogAdapter.ShowDialog())
                            {
                                var path = browserDialogAdapter.SelectedPath;
                            }
                        }), 
                    ref canExecuteChanged
                    )
                );
        

        protected EventHandler canExecuteChanged;
    }
}
