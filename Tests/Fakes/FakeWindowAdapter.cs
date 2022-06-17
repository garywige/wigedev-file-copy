using System;
using WigeDev.View.Interfaces;

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

        public void Close()
        {
        }

        public delegate void ShowDialogCalledEvent(object? sender, EventArgs args);
        public event ShowDialogCalledEvent ShowDialogCalled;
    }
}
