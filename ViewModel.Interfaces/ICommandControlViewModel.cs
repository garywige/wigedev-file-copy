using System.ComponentModel;
using System.Windows.Input;

namespace WigeDev.ViewModel.Interfaces
{
    public interface ICommandControlViewModel : INotifyPropertyChanged
    {
        public string ButtonContent { get; }
        public ICommand Command { get; }
    }
}
