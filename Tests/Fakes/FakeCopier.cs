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
            WasCancelCalled = true;
        }

        public async Task Copy()
        {
            WasCopyCalled = true;
            if (CopyDelay) await Task.Delay(100);
        }

        public bool WasCopyCalled { get; private set; }
        public bool WasCancelCalled { get; private set; }
        public bool CopyDelay { get; set; } = false;
    }
}
