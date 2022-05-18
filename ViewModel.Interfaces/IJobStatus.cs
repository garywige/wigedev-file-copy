using System.ComponentModel;

namespace WigeDev.ViewModel.Interfaces
{
    public interface IJobStatus : INotifyPropertyChanged
    {
        public bool IsCopying { get; set; }
    }
}
