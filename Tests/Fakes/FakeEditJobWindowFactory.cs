using WigeDev.View.Interfaces;
using WigeDev.View.Implementations;

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
