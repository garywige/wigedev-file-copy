using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class OverwriteSelectControlViewModel<T> : ISelectControlViewModel<T>
    {
        protected T selectedItem;

        public OverwriteSelectControlViewModel(string labelContent, IList<T> itemsSource)
        {
            LabelContent = labelContent;
            ItemsSource = itemsSource;
            selectedItem = itemsSource[0];
        }

        public string LabelContent { get; protected set; }

        public IList<T> ItemsSource { get; protected set; }

        public T SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedItem"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
