using System.ComponentModel;

namespace WigeDev.ViewModel.Interfaces
{
    public interface ITextField : INotifyPropertyChanged
    {
        public string Text { get; set; }
    }
}