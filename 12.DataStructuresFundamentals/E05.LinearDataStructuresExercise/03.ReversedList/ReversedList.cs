namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
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
                return _items[Count - 1 - index];
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
            if (Count == _items.Length)
                Grow();

            _items[Count] = item;
            Count++;
        }

        public bool Contains(T item)
        {
            if (IndexOf(item) == -1 || Count == 0)
                return false;

            return true;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[Count - 1 - i].Equals(item))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            if (Count == _items.Length)
                Grow();

            var reversedIndex = Count - index;

            for (int i = Count; i > reversedIndex; i--)
                _items[i] = _items[i - 1];

            _items[reversedIndex] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index == -1)
                return false;

            RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            for (int i = Count - 1 - index; i < Count - 1; i++)
                _items[i] = _items[i + 1];

            _items[Count - 1] = default(T);
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
                yield return _items[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        void ValidateIndex(int index)
        {
            if (Count == 0 || index < 0 || index > Count - 1)
                throw new IndexOutOfRangeException();

        }

        void Grow()
        {
            T[] newArr = new T[_items.Length * 2];
            Array.Copy(_items, newArr, Count);
            _items = newArr;
        }
    }
}