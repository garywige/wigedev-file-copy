using System.ComponentModel;
using System.Windows.Input;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class CopyJobControlViewModel : ICopyJobControlViewModel
    {
        protected string source;
        protected string destination;

        public CopyJobControlViewModel(string source, string destination, ICommand editCommand, ICommand deleteCommand)
        {
            this.source = source;
            this.destination = destination;
            EditCommand = editCommand;
            DeleteCommand = deleteCommand;
        }

        public string Source 
        {
            get => source;
            set
            {
                source = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Source"));
            }
        }

        public string Destination
        {
            get => destination;
            set
            {
                destination = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Destination"));
            }
        }

        public ICommand EditCommand { get; protected set; }

        public ICommand DeleteCommand { get; protected set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
