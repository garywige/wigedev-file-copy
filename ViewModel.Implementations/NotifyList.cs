using System.Collections;
using System.Collections.Specialized;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class NotifyList<T> : INotifyList<T>
    {
        protected T[] items = new T[0];

        protected IEnumerator<T> enumerator;

        public NotifyList(INotifyListEnumerator<T> enumerator)
        {
            enumerator.List = this;
            this.enumerator = enumerator;
        }

        public T this[int index] 
        { 
            get => items[index];
            set
            { 
                items[index] = value;
                collectionChanged();
            }
        }

        public int Count => items.Length;

        public bool IsReadOnly => false;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public void Add(T item)
        {
            grow(1);
            items[items.Length - 1] = item;
            collectionChanged();
        }

        public void Clear()
        {
            items = new T[0];
            collectionChanged();
        }

        public bool Contains(T item) => items.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < items.Length; i++)
                array[arrayIndex + i] = items[i];
        }

        public IEnumerator<T> GetEnumerator() => enumerator;

        public int IndexOf(T item)
        {
            for(int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            var copy = new T[items.Length];
            CopyTo(copy, 0);
            grow(1);

            for(int i = index; i < items.Length; i++)
                items[i] = i == index ? item : copy[i - 1];
            collectionChanged();
        }

        public bool Remove(T item)
        {
            if (!Contains(item)) return false;

            RemoveAt(IndexOf(item));
            return true;
        }

        public void RemoveAt(int index)
        {
            var arr = new T[items.Length - 1];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = i < index ? items[i] : items[i + 1];
            items = arr;
            collectionChanged();
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        protected void collectionChanged()
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected void grow(int increment)
        {
            var arr = new T[items.Length + increment];
            CopyTo(arr, 0);
            items = arr;
        }
    }
}
