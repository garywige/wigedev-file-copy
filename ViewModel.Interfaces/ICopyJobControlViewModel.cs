using System.ComponentModel;
using System.Windows.Input;

namespace WigeDev.ViewModel.Interfaces
{
    public interface ICopyJobControlViewModel : INotifyPropertyChanged
    {
        public string Source { get; }
        public string Destination { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
    }
}
