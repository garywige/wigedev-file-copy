using WigeDev.View.Interfaces;

namespace WigeDev.View.Implementations
{
    public class WindowFactory<T> : IWindowFactory<T> where T: IWindowAdapter, new()
    {
        public T CreateWindow()
        {
            return new T();
        }
    }
}
