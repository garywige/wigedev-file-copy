using System.ComponentModel;
using System.Windows.Input;

namespace WigeDev.ViewModel.Interfaces
{
    public interface IBrowseCommand : ICommand, INotifyPropertyChanged
    {
        public string FolderPath { get; }
    }
}
