namespace WigeDev.Copier.Interfaces
{
    public interface ICopyStrategy
    {
        public Task CopyFile(FileInfo source, FileInfo dest, CancellationToken token);
    }
}
