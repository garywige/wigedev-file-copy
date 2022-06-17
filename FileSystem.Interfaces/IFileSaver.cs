namespace WigeDev.FileSystem.Interfaces
{
    public interface IFileSaver<T>
    {
        public Task Save(T data, string filePath);
    }
}
