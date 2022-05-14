using System.ComponentModel;

namespace WigeDev.Model.Interfaces
{
    public interface ITextField : INotifyPropertyChanged
    {
        public string Text { get; set; }
    }
}