using System.Collections.Specialized;
using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class BatchListControlViewModel : IBatchListControlViewModel
    {
        public BatchListControlViewModel(INotifyList<ICopyJobControlViewModel> items)
        {
            Items = items;
            items.CollectionChanged += itemsCollectionChanged;
        }

        public INotifyList<ICopyJobControlViewModel> Items { get; protected set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void itemsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs args) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
    }
}
