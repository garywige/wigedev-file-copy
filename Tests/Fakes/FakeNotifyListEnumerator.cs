using System.Collections;
using WigeDev.ViewModel.Interfaces;

namespace Tests
{
    public class FakeNotifyListEnumerator<T> : INotifyListEnumerator<T>
    {
        public T Current => throw new System.NotImplementedException();

        public INotifyList<T> List { get; set; }

        object IEnumerator.Current => throw new System.NotImplementedException();

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
