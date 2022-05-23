using WigeDev.Copier.Interfaces;
using WigeDev.Output.Interfaces;

namespace WigeDev.Copier.Implementations
{
    public class AllCopyStrategy : CopyStrategyBase
    {
        protected IOutput output;

        public AllCopyStrategy(IOutput output) =>
            this.output = output;

        public override string ToString() => "All Files";

        protected override void writeOutput(string message) => output.Write(message);
    }
}
