using System.Collections.Specialized;

namespace WigeDev.ViewModel.Interfaces
{
    public interface INotifyList<T> : INotifyCollectionChanged, IList<T>
    {
    }
}
