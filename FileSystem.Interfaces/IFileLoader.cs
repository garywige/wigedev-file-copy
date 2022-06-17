namespace WigeDev.FileSystem.Interfaces
{
    public interface IFileLoader<T> where T : class
    {
        public void Load(T data, string filePath);
    }
}
