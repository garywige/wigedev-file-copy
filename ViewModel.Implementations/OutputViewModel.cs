using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;
using WigeDev.Output.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class OutputViewModel : IOutputViewModel
    {
        public OutputViewModel(IOutput output, IJobStatus jobStatus)
        {
            Output = output.Output;
            output.PropertyChanged += outputPropertyChanged;
            jobStatus.PropertyChanged += jobStatusPropertyChanged;
        }

        public IList<string> Output { get; protected set; }

        public double Progress { get; protected set; } = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void outputPropertyChanged(object? sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Output") PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Output"));
        }

        protected void jobStatusPropertyChanged(object? sender, PropertyChangedEventArgs args)
        {
            var jobStatus = sender as IJobStatus;
            if(jobStatus.TotalFiles != 0 && (args.PropertyName == "TotalFiles" || args.PropertyName == "FilesCopied"))
            {
                Progress = (double)jobStatus.FilesCopied / jobStatus.TotalFiles * 100;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Progress"));
            }
        }
    }
}