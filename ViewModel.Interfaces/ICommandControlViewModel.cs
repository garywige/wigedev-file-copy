using System.ComponentModel;
using System.Windows.Input;

namespace WigeDev.ViewModel.Interfaces
{
    public interface ICommandControlViewModel : INotifyPropertyChanged
    {
        public string CopyCancelButtonContent { get; }
        public ICommand CopyCancelCommand { get; }
    }
}
