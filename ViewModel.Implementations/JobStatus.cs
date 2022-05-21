using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class JobStatus : IJobStatus
    {
        protected bool isCopying;
        protected int filesCopied;
        protected int totalFiles;

        public JobStatus()
        {
            IsCopying = false;
            filesCopied = 0;
            totalFiles = 0;
        }

        public bool IsCopying 
        { 
            get => isCopying;
            set
            { 
                isCopying = value;
                propertyChanged("IsCopying");
            }
        }

        public int FilesCopied
        {
            get => filesCopied;
            set
            {
                filesCopied = value;
                propertyChanged("FilesCopied");
            }
        }

        public int TotalFiles
        {
            get => totalFiles;
            set
            {
                totalFiles = value;
                propertyChanged("TotalFiles");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void propertyChanged(string property) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        
    }
}
