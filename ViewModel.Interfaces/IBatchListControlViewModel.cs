using System.ComponentModel;

namespace WigeDev.ViewModel.Interfaces
{
    public interface IBatchListControlViewModel : INotifyPropertyChanged
    {
        public INotifyList<ICopyJobControlViewModel> Items { get; }
    }
}
