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

        public ViewModel(ITextField source, ITextField destination, ICommand copyCancelCommand, IList<string> output)
        {
            this.source = source;
            this.destination = destination;
            this.copyCancelCommand = copyCancelCommand;
            this.output = output;
        }

        public ITextField Source => source;
        public ITextField Destination => destination;
        public ICommand CopyCancelCommand => copyCancelCommand;
        public IList<string> Output => output;
    }
}