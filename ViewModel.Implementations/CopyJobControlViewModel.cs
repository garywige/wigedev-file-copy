using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class CopyJobControlViewModel : ICopyJobControlViewModel
    {
        protected string source;
        protected string destination;
        protected double progress;

        public CopyJobControlViewModel(string source, string destination, ISetExecuteCommand editCommand, ISetExecuteCommand deleteCommand)
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

        public ISetExecuteCommand EditCommand { get; protected set; }

        public ISetExecuteCommand DeleteCommand { get; protected set; }

        public double Progress
        {
            get => progress;
            set
            {
                progress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Progress"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
