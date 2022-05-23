using System.ComponentModel;

namespace WigeDev.ViewModel.Interfaces
{
    public interface IFolderSelectionControlViewModel : INotifyPropertyChanged
    {
        public string LabelContent { get; }
        public ITextField TextField { get; }
        public bool IsEnabled { get; }
        public IBrowseCommand BrowseCommand { get; }
    }
}
