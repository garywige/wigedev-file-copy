using WigeDev.FileSystem.Interfaces;
using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class LoadCVMInitializer : IInitializer<ICommandControlViewModel>
    {
        protected IJobStatus jobStatus;
        protected IBrowserDialogAdapter browserDialogAdapter;
        protected IFileLoader<INotifyList<ICopyJobControlViewModel>> fileLoader;
        protected INotifyList<ICopyJobControlViewModel> jobList;
        protected Func<ICopyJobControlViewModel, Action> editCommandExecute;

        public LoadCVMInitializer(
            IJobStatus jobStatus,
            IBrowserDialogAdapter browserDialogAdapter,
            IFileLoader<INotifyList<ICopyJobControlViewModel>> fileLoader,
            INotifyList<ICopyJobControlViewModel> jobList,
            Func<ICopyJobControlViewModel, Action> editCommandExecute)
        {
            this.jobStatus = jobStatus;
            jobStatus.PropertyChanged += (s, e) => canExecuteChanged?.Invoke(this, new EventArgs());
            this.browserDialogAdapter = browserDialogAdapter;
            this.fileLoader = fileLoader;
            this.jobList = jobList;
            this.editCommandExecute = editCommandExecute;
        }

        public ICommandControlViewModel Initialize()
        {
            return new CommandControlViewModel(
                "Load Batch",
                new CECCommand(
                    new Command(
                        canExecute,
                        execute
                        ),
                    ref canExecuteChanged
                    )
                );
        }

        protected EventHandler canExecuteChanged;

        protected bool canExecute() => !jobStatus.IsCopying;

        protected void execute()
        {
            if (browserDialogAdapter.ShowDialog())
            {
                fileLoader.Load(jobList, browserDialogAdapter.SelectedPath);
                foreach (var job in jobList)
                {
                    job.EditCommand.SetExecute(editCommandExecute(job));
                    job.DeleteCommand.SetExecute(() => jobList.Remove(job));
                }
            }
        }
    }
}
