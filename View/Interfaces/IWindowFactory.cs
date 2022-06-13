namespace WigeDev.View.Interfaces
{
    public interface IWindowFactory<T> where T : IWindowAdapter
    {
        public T CreateWindow();
    }
}
