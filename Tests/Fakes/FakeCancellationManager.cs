using System.Threading;
using WigeDev.Cancellation.Interfaces;

namespace Tests
{
    public class FakeCancellationManager : ICancellationManager
    {
        private CancellationTokenSource cts;

        public FakeCancellationManager()
        {
            cts = new();
            WasCancelCalled = false;
        }

        ~FakeCancellationManager()
        {
            cts.Cancel();
            cts.Dispose();
        }

        public CancellationToken Token => cts.Token;

        public void Cancel()
        {
            WasCancelCalled = true;
            cts.Cancel();
            cts.Dispose();
            cts = new();
        }

        public bool WasCancelCalled { get; private set; }
    }
}
