using WigeDev.Init.Interfaces;
using WigeDev.View.Interfaces;
using WigeDev.View.Implementations;

namespace WigeDev.Init.Implementations
{
    public class EditJobWindowInitializer : IInitializer<IWindowAdapter>
    {
        protected IWindowFactory<EditJobWindowAdapter> windowFactory;

        public EditJobWindowInitializer(IWindowFactory<EditJobWindowAdapter> windowFactory)
        {
            this.windowFactory = windowFactory;
        }

        public IWindowAdapter Initialize() => windowFactory.CreateWindow();
    }
}
