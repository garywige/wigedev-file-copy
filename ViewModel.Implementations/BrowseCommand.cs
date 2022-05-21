using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class BrowseCommand : IBrowseCommand
    {
        protected string folderPath;
        protected IFolderBrowserDialogAdapter dialog;

        public BrowseCommand(IFolderBrowserDialogAdapter dialog)
        {
            folderPath = String.Empty;
            this.dialog = dialog;
        }

        public string FolderPath 
        {
            get => folderPath;
            protected set
            {
                folderPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FolderPath"));
            }
        }

        public event EventHandler? CanExecuteChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (dialog.ShowDialog())
                FolderPath = dialog.SelectedPath;
        }
    }
}
