using WigeDev.Copier.Interfaces;
using WigeDev.Output.Interfaces;

namespace WigeDev.Copier.Implementations
{
    public class OldCopyStrategy : CopyStrategyBase
    {
        protected IOutput output;

        public OldCopyStrategy(IOutput output)
        {
            this.output = output;
        }

        public override async Task CopyFile(FileInfo source, FileInfo dest, CancellationToken token)
        {
            if(source.LastWriteTime < dest.LastWriteTime)
            {
                output.Write("\tDestination file is same or newer...");
                await Task.Delay(1);
                return;
            }

            await base.CopyFile(source, dest, token);
        }

        public override string ToString() => "Copy If Newer";

        protected override void writeOutput(string message) => output.Write(message);
    }
}
