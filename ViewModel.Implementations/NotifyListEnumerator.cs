using System.Collections;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class NotifyListEnumerator<T> : INotifyListEnumerator<T>
    {
        protected int index = -1;

        public INotifyList<T> List { get; set; }

        public T Current => index < 0 || index >= List.Count ? default(T) : List[index];

        object IEnumerator.Current => this.Current;

        public void Dispose() { }

        public bool MoveNext() => ++index < List.Count;


        public void Reset() => index = -1;
    }
}
