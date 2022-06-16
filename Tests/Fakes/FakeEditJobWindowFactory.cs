using WigeDev.View.Implementations;
using WigeDev.View.Interfaces;

namespace Tests
{
    public class FakeEditJobWindowFactory : IWindowFactory<EditJobWindowAdapter>
    {
        public EditJobWindowAdapter CreateWindow()
        {
            return new EditJobWindowAdapter(null, null, null, null);
        }
    }
}
