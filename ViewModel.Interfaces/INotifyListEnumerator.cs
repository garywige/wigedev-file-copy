namespace WigeDev.ViewModel.Interfaces
{
    public interface INotifyListEnumerator<T> : IEnumerator<T>
    {
        public INotifyList<T> List { get; set; }
    }
}
