using System.ComponentModel;
using WigeDev.Output.Interfaces;

namespace WigeDev.Output.Implementations
{
    public class BasicOutput : IOutput
    {

        public BasicOutput(IList<string> output) =>
            this.Output = output;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Write(string message)
        {
            this.Output.Add(message);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Output"));
        }

        public IList<string> Output { get; private set; }
    }
}