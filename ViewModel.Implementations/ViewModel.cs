using System.ComponentModel;
using System.Windows.Input;
using WigeDev.Model.Interfaces;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class ViewModel : IViewModel
    {
        protected ITextField source;
        protected ITextField destination;
        protected ICommand copyCancelCommand;
        protected IList<string> output;

        public ViewModel(ITextField source, ITextField destination, ICommand copyCancelCommand, IList<string> output, PropertyChangedEventHandler propertyChanged)
        {
            this.source = source;
            this.destination = destination;
            this.copyCancelCommand = copyCancelCommand;
            this.output = output;
            this.source.PropertyChanged += propertyChanged;
            this.destination.PropertyChanged += propertyChanged;
        }

        public ITextField Source => source;
        public ITextField Destination => destination;
        public ICommand CopyCancelCommand => copyCancelCommand;
        public IList<string> Output => output;
    }
}