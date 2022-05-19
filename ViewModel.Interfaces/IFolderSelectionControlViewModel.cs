using System.ComponentModel;
using System.Windows.Input;
using WigeDev.Model.Interfaces;

namespace WigeDev.ViewModel.Interfaces
{
    public interface IFolderSelectionControlViewModel : INotifyPropertyChanged
    {
        public string LabelContent { get; }
        public ITextField TextField { get; }
        public bool IsNotCopying { get; }
        public ICommand BrowseCommand { get; }
    }
}
