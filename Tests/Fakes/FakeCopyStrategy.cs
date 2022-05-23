using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WigeDev.Copier.Interfaces;

namespace Tests
{
    public class FakeCopyStrategy : ICopyStrategy
    {
        public async Task CopyFile(FileInfo source, FileInfo dest, CancellationToken token)
        {
            WasCopyFileCalled = true;
        }

        public bool WasCopyFileCalled { get; private set; } = false;
    }
}
