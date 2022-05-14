using System.ComponentModel;
using WigeDev.Model.Interfaces;

namespace Tests
{
    public class FakeTextField : ITextField
    {
        public string Text { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
