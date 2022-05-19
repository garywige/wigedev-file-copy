using WigeDev.Cancellation.Interfaces;
using WigeDev.Copier.Interfaces;
using WigeDev.Model.Interfaces;
using WigeDev.Output.Interfaces;


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

        public Copier(IFileEnumerator enumerator, 
            ITextField source, 
            ITextField dest, 
            IOutput output, 
            IPathConstructor constructor,
            ICancellationManager cancellationManager)
        {
            this.enumerator = enumerator;
            this.source = source;
            this.dest = dest;
            this.output = output;
            this.pathConstructor = constructor;
            this.cancellationManager = cancellationManager;
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
                foreach (var file in await enumerator.Enumerate(source.Text, cancellationManager))
                    await copyFile(file);

                output.Write(messageJobComplete);
            }
            catch(OperationCanceledException)
            {
                output.Write(messageJobCanceled);
            }
        }

        protected async Task copyFile(ISourceFile file)
        {
            output.Write(file.Name);
            await file.CopyTo(pathConstructor.Construct(source.Text, dest.Text, file.Name), cancellationManager);
        }
    }
}