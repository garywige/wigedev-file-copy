using System.ComponentModel;

namespace WigeDev.ViewModel.Interfaces
{
    public interface IOutputViewModel : INotifyPropertyChanged
    {
        public IList<string> Output { get; }
        public double Progress { get; }
    }
}