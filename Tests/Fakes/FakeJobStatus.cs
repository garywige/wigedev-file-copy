using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeJobStatus : IJobStatus
    {
        private bool isCopying;
        private int filesCopied = 0;
        private int totalFiles = 0;

        public FakeJobStatus()
        {
            isCopying = false;
        }

        public bool IsCopying
        {
            get => isCopying;
            set
            {
                isCopying = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsCopying"));
            }
        }

        public int FilesCopied 
        {
            get => filesCopied;
            set
            {
                filesCopied = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FilesCopied"));
            }
        }

        public int TotalFiles 
        {
            get => totalFiles;
            set
            {
                totalFiles = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalFiles"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
