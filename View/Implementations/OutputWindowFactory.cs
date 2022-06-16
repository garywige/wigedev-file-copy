using System;
using WigeDev.View.Interfaces;

namespace WigeDev.View.Implementations
{
    public class OutputWindowFactory : IWindowFactory<IOutputWindowAdapter>
    {
        protected Action<object?> show;
        protected Func<object?, bool?> showDialog;
        protected Action close;

        public OutputWindowFactory(Action<object?> show, Func<object?, bool?> showDialog, Action close)
        {
            this.show = show;
            this.showDialog = showDialog;
            this.close = close;
        }

        public IOutputWindowAdapter CreateWindow() =>
            new OutputWindowAdapter(show, showDialog, close);

    }
}
