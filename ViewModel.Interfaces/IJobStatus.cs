using System.ComponentModel;

namespace WigeDev.ViewModel.Interfaces
{
    public interface IJobStatus : INotifyPropertyChanged
    {
        public bool IsCopying { get; set; }
        public int FilesCopied { get; set; }
        public int TotalFiles { get; set; }
    }
}
