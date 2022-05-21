using System.Windows.Input;
using System.ComponentModel;

namespace WigeDev.ViewModel.Interfaces
{
    public interface IBrowseCommand : ICommand, INotifyPropertyChanged
    {
        public string FolderPath { get; }
    }
}
