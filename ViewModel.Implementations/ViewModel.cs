using System.ComponentModel;
using System.Windows.Input;
using WigeDev.Model.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Output.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class ViewModel : IViewModel
    {
        protected ITextField source;
        protected ITextField destination;
        protected ICommand copyCancelCommand;
        protected IList<string> output;
        protected IJobStatus jobStatus;

        public ViewModel(ITextField source, ITextField destination, ICommand copyCancelCommand, IOutput output, PropertyChangedEventHandler propertyChanged, IJobStatus jobStatus)
        {
            this.source = source;
            this.destination = destination;
            this.copyCancelCommand = copyCancelCommand;
            this.output = output.Output;
            this.jobStatus = jobStatus;

            this.source.PropertyChanged += propertyChanged;
            this.destination.PropertyChanged += propertyChanged;

            output.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Output") PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Output"));
            };

            jobStatus.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "IsCopying") PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsNotCopying"));
            };
            
        }

        public ITextField Source => source;
        public ITextField Destination => destination;
        public ICommand CopyCancelCommand => copyCancelCommand;
        public IList<string> Output => output;
        public bool IsNotCopying => !jobStatus.IsCopying;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}