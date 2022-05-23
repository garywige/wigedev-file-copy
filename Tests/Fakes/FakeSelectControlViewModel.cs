using System.Collections.Generic;
using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeSelectControlViewModel<T> : ISelectControlViewModel<T>
    {
        private T selectedItem;

        public FakeSelectControlViewModel(IList<T> itemsSource)
        {
            ItemsSource = itemsSource;
            selectedItem = itemsSource[0];
        }

        public string LabelContent => "test";

        public IList<T> ItemsSource { get; private set; }

        public T SelectedItem 
        {
            get => selectedItem; 
            set
            {
                selectedItem = value;
                propertyChanged("SelectedItem");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void propertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
