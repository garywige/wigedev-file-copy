using WigeDev.Cancellation.Interfaces;
using WigeDev.Copier.Interfaces;

namespace WigeDev.Copier.Implementations
{
    public class SourceFile : ISourceFile
    {
        protected FileInfo fi;

        public SourceFile(FileInfo fi)
        {
            this.fi = fi;
        }

        public string Name => throw new NotImplementedException();

        public Task CopyTo(string dest, ICancellationManager cancellationManager)
        {
            throw new NotImplementedException();
        }

        public static SourceFile Create(FileInfo fi)
        {
            return new SourceFile(fi);
        }
    }
}
