namespace WigeDev.Init.Interfaces
{
    public interface IFactory<T>
    {
        public T Create();
    }
}
