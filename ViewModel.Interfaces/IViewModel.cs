using System.ComponentModel;
using System.Windows.Input;
using WigeDev.Model.Interfaces;

namespace WigeDev.ViewModel.Interfaces
{
    public interface IViewModel : INotifyPropertyChanged
    {
        public ITextField Source { get; }
        public ITextField Destination { get; }
        public ICommand CopyCancelCommand { get; }
        public IList<string> Output { get; }
        public bool IsNotCopying { get; }
        public string CopyCancelButtonContent { get; }
    }
}