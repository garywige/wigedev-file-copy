using System;
using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeBrowseCommand : IBrowseCommand
    {
        private string folderPath = String.Empty;

        public string FolderPath
        {
            get => folderPath;
            set
            {
                folderPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FolderPath"));
            }
        }

        public event EventHandler? CanExecuteChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
