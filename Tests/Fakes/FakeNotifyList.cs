using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using WigeDev.ViewModel.Interfaces;
using System.Collections.ObjectModel;

namespace Tests
{
    public sealed class FakeNotifyList<T> : INotifyList<T>
    {
        private ObservableCollection<T> list;

        public FakeNotifyList(ObservableCollection<T> list)
        {
            this.list = list;
            this.list.CollectionChanged += (s, e) => CollectionChanged?.Invoke(this, e);
        }

        public T this[int index] { get => list[index]; set => list[index] = value; }

        public int Count => list.Count;

        public bool IsReadOnly => false;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public void Add(T item) => list.Add(item);

        public void Clear() => list.Clear();

        public bool Contains(T item) => list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator()
        {
            GetEnumeratorCalled = true;
            return list.GetEnumerator();
        }

        public int IndexOf(T item) => list.IndexOf(item);

        public void Insert(int index, T item) => list.Insert(index, item);

        public bool Remove(T item) => list.Remove(item);

        public void RemoveAt(int index) => list.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public bool GetEnumeratorCalled { get; private set; } = false;
    }
}
