using System.ComponentModel;
using System.Windows.Input;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class StartBatchCommandControlViewModel : ICommandControlViewModel
    {
        protected IJobStatus jobStatus;

        public StartBatchCommandControlViewModel(IJobStatus jobStatus, ICommand command)
        {
            this.jobStatus = jobStatus;
            jobStatus.PropertyChanged += (s, e) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ButtonContent"));
            Command = command;
        }

        public string ButtonContent => jobStatus.IsCopying ? "Cancel Batch" : "Start Batch";

        public ICommand Command { get; protected set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
