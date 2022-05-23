using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class FolderSelectionControlViewModel : IFolderSelectionControlViewModel
    {
        protected IJobStatus jobStatus;

        public FolderSelectionControlViewModel(string labelContent, ITextField textField, IJobStatus jobStatus, IBrowseCommand browseCommand)
        {
            LabelContent = labelContent;
            TextField = textField;
            IsEnabled = true;
            this.jobStatus = jobStatus;
            jobStatus.PropertyChanged += jobStatusIsCopyingChanged;
            this.BrowseCommand = browseCommand;
            browseCommand.PropertyChanged += browseCommandFolderPathChanged;
        }

        public string LabelContent { get; protected set; }

        public ITextField TextField { get; protected set; }

        public bool IsEnabled { get; protected set; }

        public IBrowseCommand BrowseCommand { get; protected set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void jobStatusIsCopyingChanged(object? sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "IsCopying")
            {
                IsEnabled = !jobStatus.IsCopying;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEnabled"));
            }
        }

        protected void browseCommandFolderPathChanged(object? sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "FolderPath")
                TextField.Text = BrowseCommand.FolderPath;
        }
    }
}
