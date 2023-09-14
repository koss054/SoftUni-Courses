namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] _elements;
        private int _startIndex;
        private int _endIndex;

        public CircularQueue(int capacity = 4)
        {
            _elements = new T[capacity];
        }

        public int Count { get; private set; }

        public T Dequeue()
        {
            EnsureNotEmpty();

            var elementToReturn = _elements[_startIndex];

            _elements[_startIndex] = default(T);
            _startIndex++;
            Count--;

            return elementToReturn;
        }

        public void Enqueue(T item)
        {
            if (Count >= _elements.Length)
                Grow();

            _elements[_endIndex] = item;
            _endIndex = (_endIndex + 1) % _elements.Length;
            Count++;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return _elements[_startIndex];
        }

        public T[] ToArray()
        {
            return CopyElements(new T[Count]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                var index = (_startIndex + i) % _elements.Length;
                yield return _elements[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        void EnsureNotEmpty()
        {
            if (Count == 0)
                throw new InvalidOperationException();
        }

        void Grow()
        {
            _elements = CopyElements(new T[_elements.Length * 2]);
            _startIndex = 0;
            _endIndex = Count;
        }

        T[] CopyElements(T[] resultArray)
        {
            for (int i = 0; i < Count; i++)
                resultArray[i] = _elements[(_startIndex + i) % _elements.Length];

            return resultArray;
        }
    }

}
