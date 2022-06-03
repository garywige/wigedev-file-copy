using System.ComponentModel;

namespace WigeDev.ViewModel.Interfaces
{
    public interface IBatchListControlViewModel : INotifyPropertyChanged
    {
        public IList<ICopyJobControlViewModel> Items { get; }
    }
}
