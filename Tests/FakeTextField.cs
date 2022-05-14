using System.ComponentModel;
using WigeDev.Model.Interfaces;

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
