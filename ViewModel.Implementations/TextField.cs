using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class TextField : ITextField
    {
        protected string text;

        public TextField()
        {
            text = String.Empty;
        }

        public string Text
        {
            get => text;
            set
            {
                text = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString() => Text;
    }
}