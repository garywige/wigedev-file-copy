using WigeDev.FileSystem.Interfaces;
using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class SaveCVMInitializer : IInitializer<ICommandControlViewModel>
    {
        protected IJobStatus jobStatus;
        protected INotifyList<ICopyJobControlViewModel> jobList;
        protected IBrowserDialogAdapter browserDialogAdapter;
        protected IFileSaver<INotifyList<ICopyJobControlViewModel>> fileSaver;

        public SaveCVMInitializer(IJobStatus jobStatus, INotifyList<ICopyJobControlViewModel> jobList, IBrowserDialogAdapter browserDialogAdapter, IFileSaver<INotifyList<ICopyJobControlViewModel>> fileSaver)
        {
            this.jobStatus = jobStatus;
            jobStatus.PropertyChanged += (s, e) => canExecuteChanged?.Invoke(this, new EventArgs());
            this.jobList = jobList;
            jobList.CollectionChanged += (s, e) => canExecuteChanged?.Invoke(this, new EventArgs());
            this.browserDialogAdapter = browserDialogAdapter;
            this.fileSaver = fileSaver;
        }

        public ICommandControlViewModel Initialize() =>
            new CommandControlViewModel(
                "Save Batch",
                new CECCommand(
                    new Command(
                        canExecute,
                        execute),
                    ref canExecuteChanged
                    )
                );


        protected EventHandler canExecuteChanged;

        protected bool canExecute() => !jobStatus.IsCopying && jobList.Count != 0;

        protected void execute()
        {
            if (browserDialogAdapter.ShowDialog())
            {
                fileSaver.Save(jobList, browserDialogAdapter.SelectedPath);
            }
        }
    }
}
