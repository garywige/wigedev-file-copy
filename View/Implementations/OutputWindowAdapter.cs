using System;
using WigeDev.View.Interfaces;


namespace WigeDev.View.Implementations
{
    public class OutputWindowAdapter : IOutputWindowAdapter
    {
        protected Action<object?> show;
        protected Func<object?, bool?> showDialog;

        public OutputWindowAdapter(Action<object?> show, Func<object?, bool?> showDialog)
        {
            this.show = show;
            this.showDialog = showDialog;
        }

        public object? Output => null;

        public void Show()
        {
            show?.Invoke(Output);
        }

        public bool? ShowDialog()
        {
            return showDialog?.Invoke(Output);
        }
    }
}
