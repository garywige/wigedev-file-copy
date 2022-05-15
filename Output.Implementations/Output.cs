using WigeDev.Output.Interfaces;

namespace WigeDev.Output.Implementations
{
    public class Output : IOutput
    {
        protected IList<string> output;

        public Output(IList<string> output) =>
            this.output = output;

        public void Write(string message) =>
            this.output.Add(message);
    }
}