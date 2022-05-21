using System.ComponentModel;
using System.Windows.Input;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class CommandControlViewModel : ICommandControlViewModel
    {
        protected IJobStatus jobStatus;

        public CommandControlViewModel(IJobStatus jobStatus, ICommand copyCancelCommand)
        {
            this.jobStatus = jobStatus;
            CopyCancelButtonContent = "Copy";
            CopyCancelCommand = copyCancelCommand;
            jobStatus.PropertyChanged += jobStatusPropertyChanged;
        }

        public string CopyCancelButtonContent { get; protected set; }

        public ICommand CopyCancelCommand { get; protected set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void jobStatusPropertyChanged(object? sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "IsCopying")
            {
                CopyCancelButtonContent = jobStatus.IsCopying ? "Cancel" : "Copy";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CopyCancelButtonContent"));
            }
        }
    }
}
