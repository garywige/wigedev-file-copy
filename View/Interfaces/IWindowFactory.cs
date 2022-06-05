namespace WigeDev.View.Interfaces
{
    public interface IWindowFactory<T> where T : IWindowAdapter, new()
    {
        public T CreateWindow();
    }
}
