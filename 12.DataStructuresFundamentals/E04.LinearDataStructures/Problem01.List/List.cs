namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            _items = new T[capacity];
        }

        public T this[int index] 
        { 
            get
            {
                ValidateIndex(index);
                return _items[index];
            } 
            set
            {
                ValidateIndex(index);
                _items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            Grow();
            _items[Count++] = item;
        }

        public bool Contains(T item)
        {
            int index = IndexOf(item);
            return index == -1 ? false : true;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);
            Grow();

            for (int i = Count; i > index; i--)
                _items[i] = _items[i - 1];

            _items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index == -1)
                return false;

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            
            for (int i = index; i < Count - 1; i++)
                _items[i] = _items[i + 1];

            _items[Count - 1] = default(T);
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Count; i++)
                yield return _items[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        void Grow()
        {
            if (Count == _items.Length)
            {
                var newItems = new T[Count * 2];
                Array.Copy(_items, newItems, _items.Length);
                _items = newItems;
            }
        }

        void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException($"The index '{index}' is out of range");
        }
    }
}