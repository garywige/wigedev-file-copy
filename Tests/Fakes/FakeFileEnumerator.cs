using System.Collections.Generic;
using System.Threading.Tasks;
using WigeDev.Cancellation.Interfaces;
using WigeDev.Copier.Interfaces;

namespace Tests
{
    public class FakeFileEnumerator : IFileEnumerator
    {
        private ISourceFile sourceFile;

        public FakeFileEnumerator(ISourceFile source)
        {
            WasEnumerateCalled = false;
            this.sourceFile = source;
        }

        public async Task<IList<ISourceFile>> Enumerate(string source, ICancellationManager cancellationManager)
        {
            WasEnumerateCalled = true;
            var list = new List<ISourceFile>();
            list.Add(sourceFile);
            return list;
        }

        public bool WasEnumerateCalled { get; private set; }
    }
}
