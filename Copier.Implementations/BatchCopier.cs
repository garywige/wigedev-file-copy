using WigeDev.Copier.Interfaces;
using WigeDev.Cancellation.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.Copier.Implementations
{
    public class BatchCopier : ICopier
    {
        protected ICancellationManager cancellationManager;
        protected INotifyList<ICopyJobControlViewModel> jobList;
        protected IFileEnumerator fileEnumerator;
        protected IPathConstructor pathConstructor;

        public BatchCopier(
            ICancellationManager cancellationManager,
            INotifyList<ICopyJobControlViewModel> jobList,
            IFileEnumerator fileEnumerator,
            IPathConstructor pathConstructor)
        {
            this.cancellationManager = cancellationManager;
            this.jobList = jobList;
            this.fileEnumerator = fileEnumerator;
            this.pathConstructor = pathConstructor;
        }

        public void Cancel() => cancellationManager.Cancel();

        public async Task Copy()
        {
            foreach(var job in jobList)
            {
                foreach (var file in await fileEnumerator.Enumerate(job.Source, cancellationManager))
                {
                    await file.CopyTo(pathConstructor.Construct(job.Source, job.Destination, file.Name), cancellationManager);
                }
            }
        }
    }
}
