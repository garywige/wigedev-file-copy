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

            output.PropertyChanged += outputPropertyChanged;
            jobStatus.PropertyChanged += jobStatusPropertyChanged;
            
        }

        public ITextField Source => source;
        public ITextField Destination => destination;
        public ICommand CopyCancelCommand => copyCancelCommand;
        public IList<string> Output => output;
        public bool IsNotCopying => !jobStatus.IsCopying;
        public string CopyCancelButtonContent => jobStatus.IsCopying ? "Cancel" : "Copy";

        public event PropertyChangedEventHandler? PropertyChanged;

        private void outputPropertyChanged(object? sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Output") PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Output"));
        }

        private void jobStatusPropertyChanged(object? sender, PropertyChangedEventArgs args)
        {

            if (args.PropertyName == "IsCopying")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsNotCopying"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CopyCancelButtonContent"));
            }
        }
    }
}