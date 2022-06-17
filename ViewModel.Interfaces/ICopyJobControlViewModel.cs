using System.ComponentModel;

namespace WigeDev.ViewModel.Interfaces
{
    public interface ICopyJobControlViewModel : INotifyPropertyChanged
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public ISetExecuteCommand EditCommand { get; }
        public ISetExecuteCommand DeleteCommand { get; }
        public double Progress { get; set; }
    }
}
