using System.ComponentModel;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeTextField : ITextField
    {
        private string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
