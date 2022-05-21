using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Output.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class OutputViewModel : IOutputViewModel
    {
        public OutputViewModel(IOutput output)
        {
            Output = output.Output;
            output.PropertyChanged += outputPropertyChanged;
        }

        public IList<string> Output { get; protected set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void outputPropertyChanged(object? sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Output") PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Output"));
        }
    }
}