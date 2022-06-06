using System.ComponentModel;
using System.Windows.Input;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class CopyJobControlViewModel : ICopyJobControlViewModel
    {
        public CopyJobControlViewModel(string source, string destination, ICommand editCommand, ICommand deleteCommand)
        {
            Source = source;
            Destination = destination;
            EditCommand = editCommand;
            DeleteCommand = deleteCommand;
        }

        public string Source { get; protected set; }

        public string Destination { get; protected set; }

        public ICommand EditCommand { get; protected set; }

        public ICommand DeleteCommand { get; protected set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
