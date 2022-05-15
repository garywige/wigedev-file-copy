using WigeDev.Cancellation.Interfaces;

namespace WigeDev.Copier.Interfaces
{
    public interface ISourceFile
    {
        public string Name { get; }
        public Task CopyTo(string dest, ICancellationManager cancellationManager);
    }
}
