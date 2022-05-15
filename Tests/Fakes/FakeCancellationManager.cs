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
            WasTokenAccessed = false;
        }

        ~FakeCancellationManager()
        {
            cts.Cancel();
            cts.Dispose();
        }

        public CancellationToken Token
        {
            get
            {
                WasTokenAccessed = true;
                return cts.Token;
            }
        }

        public void Cancel()
        {
            WasCancelCalled = true;
            cts.Cancel();
            cts.Dispose();
            cts = new();
        }

        public bool WasCancelCalled { get; private set; }
        public bool WasTokenAccessed { get; private set; }
    }
}
