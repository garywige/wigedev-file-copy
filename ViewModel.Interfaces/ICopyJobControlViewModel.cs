using System.ComponentModel;
using System.Windows.Input;

namespace WigeDev.ViewModel.Interfaces
{
    public interface ICopyJobControlViewModel : INotifyPropertyChanged
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public double Progress { get; set; }
    }
}
