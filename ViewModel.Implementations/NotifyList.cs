using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using WigeDev.ViewModel.Interfaces;

namespace WigeDev.ViewModel.Implementations
{
    public class NotifyList<T> : INotifyList<T>
    {
        protected T[] items = new T[0];

        public T this[int index] 
        { 
            get => items[index];
            set
            {
                var oldValue = items[index];
                items[index] = value;
                collectionChanged(NotifyCollectionChangedAction.Replace, createItemList(value), createItemList(oldValue));
            }
        }

        public int Count => items.Length;

        public bool IsReadOnly => false;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public void Add(T item)
        {
            grow(1);
            items[items.Length - 1] = item;
            collectionChanged(NotifyCollectionChangedAction.Add, createItemList(item));
        }

        public void Clear()
        {
            items = new T[0];
            collectionChanged(NotifyCollectionChangedAction.Reset);
        }

        public bool Contains(T item) => items.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < items.Length; i++)
                array[arrayIndex + i] = items[i];
        }

        public IEnumerator<T> GetEnumerator()
        {
            var enumerator = new NotifyListEnumerator<T>();
            enumerator.List = this;
            return enumerator;
        }

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

            collectionChanged(NotifyCollectionChangedAction.Add, createItemList(item));
        }

        public bool Remove(T item)
        {
            if (!Contains(item)) return false;

            RemoveAt(IndexOf(item));
            return true;
        }

        public void RemoveAt(int index)
        {
            var oldValue = items[index];

            var arr = new T[items.Length - 1];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = i < index ? items[i] : items[i + 1];
            items = arr;
            
            collectionChanged(NotifyCollectionChangedAction.Remove, createItemList(oldValue), null, index);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        protected void collectionChanged(NotifyCollectionChangedAction action, IList changedItems = null, IList oldItems = null, int index = 0)
        {
            var args = action switch
            {
                NotifyCollectionChangedAction.Replace => new NotifyCollectionChangedEventArgs(action, changedItems, oldItems),
                NotifyCollectionChangedAction.Add => new NotifyCollectionChangedEventArgs(action, changedItems),
                NotifyCollectionChangedAction.Remove => new NotifyCollectionChangedEventArgs(action, changedItems, index),
                NotifyCollectionChangedAction.Reset => new NotifyCollectionChangedEventArgs(action)
            };

            CollectionChanged?.Invoke(this, args);
        }

        protected void grow(int increment)
        {
            var arr = new T[items.Length + increment];
            CopyTo(arr, 0);
            items = arr;
        }

        protected IList createItemList(T value)
        {
            var list = new List<T>();
            list.Add(value);
            return list;
        }
    }
}
