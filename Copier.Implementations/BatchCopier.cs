using WigeDev.Cancellation.Interfaces;
using WigeDev.Copier.Interfaces;
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
            foreach (var job in jobList)
            {
                resetProgress(job);
                var files = await fileEnumerator.Enumerate(job.Source, cancellationManager);
                var totalFiles = files.Count;
                int filesCopied = 0;
                foreach (var file in files)
                {
                    try
                    {
                        await file.CopyTo(pathConstructor.Construct(job.Source, job.Destination, file.Name), cancellationManager);
                    }
                    catch (OperationCanceledException)
                    {
                        resetProgress(job);
                        return;
                    }

                    updateProgress(job, ++filesCopied, totalFiles);
                }
            }
        }

        protected void resetProgress(ICopyJobControlViewModel copyJob)
        {
            copyJob.Progress = 0;
        }

        protected void updateProgress(ICopyJobControlViewModel copyJob, double copied, int total)
        {
            copyJob.Progress = copied / total * 100;
        }
    }
}
