﻿using WigeDev.View.Interfaces;
using System;

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

        public delegate void ShowDialogCalledEvent(object? sender, EventArgs args);
        public event ShowDialogCalledEvent ShowDialogCalled;
    }
}
