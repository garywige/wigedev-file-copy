using System.Threading.Tasks;
using WigeDev.Copier.Interfaces;

namespace Tests
{
    public class FakeCopier : ICopier
    {
        public FakeCopier()
        {
            WasCopyCalled = false;
            WasCancelCalled = false;
        }

        public void Cancel()
        {
            WasCancelCalled=true;
        }

        public Task Copy()
        {
            WasCopyCalled = true;
            return Task.Delay(1000);
        }

        public bool WasCopyCalled { get; private set; }
        public bool WasCancelCalled { get; private set; }
    }
}
