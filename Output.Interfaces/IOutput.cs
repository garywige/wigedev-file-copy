using System.ComponentModel;

namespace WigeDev.Output.Interfaces
{
    public interface IOutput : INotifyPropertyChanged
    {
        public void Write(string message);
        public IList<string> Output { get; }
    }
}