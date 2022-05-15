using WigeDev.Cancellation.Interfaces;

namespace WigeDev.Copier.Interfaces
{
    public interface IFileEnumerator
    {
        public Task<IList<ISourceFile>> Enumerate(string sourcePath, ICancellationManager cancellationManager);
    }
}
