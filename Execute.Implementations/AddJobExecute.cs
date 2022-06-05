using WigeDev.Execute.Interfaces;
using WigeDev.View.Interfaces;

namespace WigeDev.Execute.Implementations
{
    public class AddJobExecute<T> : IExecute where T : IOutputWindowAdapter, new()
    {
        protected IWindowFactory<T> windowFactory;

        public AddJobExecute(IWindowFactory<T> factory)
        {
            windowFactory = factory;
        }

        public void Execute()
        {
            var window = windowFactory.CreateWindow();
            if(window.ShowDialog() == true)
            {
                //TODO: process dialog output
            }
        }
    }
}
