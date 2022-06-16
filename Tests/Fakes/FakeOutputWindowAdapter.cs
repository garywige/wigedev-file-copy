using System;
using WigeDev.View.Interfaces;

namespace Tests
{
    public class FakeOutputWindowAdapter : IOutputWindowAdapter
    {
        private IWindowAdapter adapter;

        public FakeOutputWindowAdapter()
        {
            this.adapter = new FakeWindowAdapter();
        }

        public object? Output { get; private set; }

        public void Show()
        {
            adapter.Show();
        }

        public bool? ShowDialog()
        {
            Output = new object();
            ShowDialogCalled?.Invoke(this, new EventArgs());
            return adapter.ShowDialog();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public delegate void ShowDialogCalledEvent(object? sender, EventArgs args);
        public event ShowDialogCalledEvent ShowDialogCalled;
    }
}
