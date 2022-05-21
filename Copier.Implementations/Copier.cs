using WigeDev.Cancellation.Interfaces;
using WigeDev.Copier.Interfaces;
using WigeDev.Model.Interfaces;
using WigeDev.Output.Interfaces;
using WigeDev.ViewModel.Interfaces;


namespace WigeDev.Copier.Implementations
{
    public class Copier : ICopier
    {
        protected static readonly string messageJobComplete = "The job completed successfully.";
        protected static readonly string messageJobCanceled = "The job was canceled.";

        protected IFileEnumerator enumerator;
        protected ITextField source;
        protected ITextField dest;
        protected IOutput output;
        protected IPathConstructor pathConstructor;
        protected ICancellationManager cancellationManager;
        protected IJobStatus jobStatus;

        public Copier(IFileEnumerator enumerator, 
            ITextField source, 
            ITextField dest, 
            IOutput output, 
            IPathConstructor constructor,
            ICancellationManager cancellationManager,
            IJobStatus jobStatus)
        {
            this.enumerator = enumerator;
            this.source = source;
            this.dest = dest;
            this.output = output;
            this.pathConstructor = constructor;
            this.cancellationManager = cancellationManager;
            this.jobStatus = jobStatus;
        }

        public void Cancel()
        {
            cancellationManager.Cancel();
        }

        public async Task Copy()
        {
            output.Output.Clear();

            try
            {
                await copyFiles();

                output.Write(messageJobComplete);
            }
            catch(OperationCanceledException)
            {
                output.Write(messageJobCanceled);
                setFilesCopied(0);
            }
        }

        protected async Task copyFiles()
        {
            int fileCount = 0;

            var files = await enumerator.Enumerate(source.Text, cancellationManager);
            setTotalFiles(files.Count);

            foreach (var file in files)
            {
                await copyFile(file);
                setFilesCopied(++fileCount);
            }
        }

        protected async Task copyFile(ISourceFile file)
        {
            output.Write(file.Name);
            await file.CopyTo(pathConstructor.Construct(source.Text, dest.Text, file.Name), cancellationManager);
        }

        protected void setTotalFiles(int count) => jobStatus.TotalFiles = count;

        protected void setFilesCopied(int count) => jobStatus.FilesCopied = count;
    }
}