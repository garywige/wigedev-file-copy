using System.ComponentModel;

namespace WigeDev.ViewModel.Interfaces
{
    public interface ISelectControlViewModel<T> : INotifyPropertyChanged
    {
        public string LabelContent { get; }
        public IList<T> ItemsSource { get; }
        public T SelectedItem { get; set; }
    }
}
