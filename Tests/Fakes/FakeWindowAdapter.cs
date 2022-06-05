using WigeDev.View.Interfaces;
using System;

namespace Tests
{
    public class FakeWindowAdapter : IWindowAdapter
    {
        public void Show()
        {
        }

        public bool? ShowDialog()
        {
            ShowDialogCalled?.Invoke(this, new EventArgs());
            return false;
        }

        public delegate void ShowDialogCalledEvent(object? sender, EventArgs args);
        public event ShowDialogCalledEvent ShowDialogCalled;
    }
}
