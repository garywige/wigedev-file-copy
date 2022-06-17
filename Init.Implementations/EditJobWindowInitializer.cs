using WigeDev.Init.Interfaces;
using WigeDev.View.Implementations;
using WigeDev.View.Interfaces;

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
