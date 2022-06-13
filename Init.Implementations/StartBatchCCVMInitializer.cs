using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;
using WigeDev.Execute.Implementations;
using WigeDev.Copier.Interfaces;
using WigeDev.Copier.Implementations;
using WigeDev.Cancellation.Interfaces;

namespace WigeDev.Init.Implementations
{
    public class StartBatchCCVMInitializer : IInitializer<ICommandControlViewModel>
    {
        protected IJobStatus jobStatus;
        protected ICancellationManager cancellationManager;
        protected INotifyList<ICopyJobControlViewModel> jobList;
        protected IFileEnumerator fileEnumerator;
        protected IPathConstructor pathConstructor;

        public StartBatchCCVMInitializer(
            IJobStatus jobStatus, 
            ICancellationManager cancellationManager,
            INotifyList<ICopyJobControlViewModel> jobList,
            IFileEnumerator fileEnumerator,
            IPathConstructor pathConstructor)
        {
            this.jobStatus = jobStatus;
            this.cancellationManager = cancellationManager;
            this.jobList = jobList;
            this.fileEnumerator = fileEnumerator;
            this.pathConstructor = pathConstructor;
        }

        public ICommandControlViewModel Initialize()
        {
            jobList.CollectionChanged += (s, e) => jobListCollectionChanged?.Invoke(this, new EventArgs());

            return new StartBatchCommandControlViewModel(jobStatus, new CECCommand(new Command(
                () => jobList.Count > 0,
                new StartBatchExecute(jobStatus, new BatchCopier(cancellationManager, jobList, fileEnumerator, pathConstructor)).Execute), ref jobListCollectionChanged));
        }

        protected EventHandler jobListCollectionChanged;
    }
}
