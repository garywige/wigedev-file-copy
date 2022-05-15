using System.Threading.Tasks;
using WigeDev.Copier.Interfaces;
using WigeDev.Cancellation.Interfaces;

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
        }

        public bool WasCopyToCalled { get; private set; }
    }
}
