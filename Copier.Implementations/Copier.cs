using WigeDev.Cancellation.Interfaces;
using WigeDev.Copier.Interfaces;
using WigeDev.Model.Interfaces;
using WigeDev.Output.Interfaces;


namespace WigeDev.Copier.Implementations
{
    public class Copier : ICopier
    {
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

                output.Write("The copy job completed successfully.");
            }
            catch(OperationCanceledException)
            {
                output.Write("The copy job was canceled.");
            }
        }

        private async Task copyFile(ISourceFile file)
        {
            output.Write(file.Name);
            await file.CopyTo(pathConstructor.Construct(source.Text, dest.Text, file.Name), cancellationManager);
        }
    }
}