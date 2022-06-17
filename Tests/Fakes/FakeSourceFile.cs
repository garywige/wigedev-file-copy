using System;
using System.Threading.Tasks;
using WigeDev.Cancellation.Interfaces;
using WigeDev.Copier.Interfaces;

namespace Tests
{
    public class FakeSourceFile : ISourceFile
    {
        public FakeSourceFile()
        {
            WasCopyToCalled = false;
        }

        public string Name => "test";

        public async Task CopyTo(string dest, ICancellationManager cancellationManager)
        {
            WasCopyToCalled = true;
            if (cancellationManager.Token.IsCancellationRequested)
                throw new OperationCanceledException();
        }

        public bool WasCopyToCalled { get; private set; }
    }
}
