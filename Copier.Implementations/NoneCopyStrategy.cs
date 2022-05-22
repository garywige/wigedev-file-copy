using WigeDev.Copier.Interfaces;
using WigeDev.Output.Interfaces;

namespace WigeDev.Copier.Implementations
{
    public class NoneCopyStrategy : CopyStrategyBase
    {
        protected IOutput output;

        public NoneCopyStrategy(IOutput output) =>
            this.output = output;
        
        public override async Task CopyFile(FileInfo source, FileInfo dest, CancellationToken token)
        {
            if (token.IsCancellationRequested)
                throw new OperationCanceledException();

            if (dest.Exists)
            {
                output.Write("\tFile already exists at destination...");

                await Task.Delay(1);
                return;
            }

            await base.CopyFile(source, dest, token);
        }

        public override string ToString() => "No Overwrite";
        protected override void writeOutput(string message) => output.Write(message);
    }
}
