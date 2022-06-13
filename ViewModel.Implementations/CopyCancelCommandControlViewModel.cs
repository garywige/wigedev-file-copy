using System.ComponentModel;
using System.Windows.Input;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class CopyCancelCommandControlViewModel : ICommandControlViewModel
    {
        protected IJobStatus jobStatus;

        public CopyCancelCommandControlViewModel(IJobStatus jobStatus, ICommand copyCancelCommand)
        {
            this.jobStatus = jobStatus;
            ButtonContent = "Copy";
            Command = copyCancelCommand;
            jobStatus.PropertyChanged += jobStatusPropertyChanged;
        }

        public string ButtonContent { get; protected set; }

        public ICommand Command { get; protected set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void jobStatusPropertyChanged(object? sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "IsCopying")
            {
                ButtonContent = jobStatus.IsCopying ? "Cancel" : "Copy";
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ButtonContent"));
            }
        }
    }
}
