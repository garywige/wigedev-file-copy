using System;
using WigeDev.View.Interfaces;

namespace WigeDev.View.Implementations
{
    public class OutputWindowFactory : IWindowFactory<IOutputWindowAdapter>
    {
        protected Action<object?> show;
        protected Func<object?, bool?> showDialog;

        public OutputWindowFactory(Action<object?> show, Func<object?, bool?> showDialog)
        {
            this.show = show;
            this.showDialog = showDialog;
        }

        public IOutputWindowAdapter CreateWindow() =>
            new OutputWindowAdapter(show, showDialog);
        
    }
}
