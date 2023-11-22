namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> _elements;

        public MaxHeap()
        {
            _elements = new List<T>();
        }

        public int Size => _elements.Count;

        public void Add(T element)
        {
            _elements.Add(element);
            HeapifyUp(_elements.Count - 1);
        }

        public T ExtractMax()
        {
            if (_elements.Count == 0)
                throw new InvalidOperationException();

            var lastIndex = _elements.Count - 1;
            var element = _elements[0];

            Swap(0, lastIndex);
            _elements.RemoveAt(lastIndex);
            HeapifyDown(0);

            return element;
        }

        public T Peek()
        {
            if (_elements.Count == 0)
                throw new InvalidOperationException();

            return _elements[0];
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = GetParentIndex(index);

            while (index > 0 && IsGreater(index, parentIndex))
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = GetParentIndex(index);
            }
        }

        private void HeapifyDown(int index)
        {
            var biggerChildIndex = GetBiggerChildIndex(index);

            while (IsIndexValid(biggerChildIndex) && IsGreater(biggerChildIndex, index))
            {
                Swap(biggerChildIndex, index);

                index = biggerChildIndex;
                biggerChildIndex = GetBiggerChildIndex(index);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = _elements[index];
            _elements[index] = _elements[parentIndex];
            _elements[parentIndex] = temp;
        }

        private int GetParentIndex(int index)
            => (index - 1) / 2;

        private int GetBiggerChildIndex(int index)
        {
            var leftChildIndex = index * 2 + 1;
            var rightChildIndex = index * 2 + 2;

            if (rightChildIndex < _elements.Count)
            {
                if (IsGreater(leftChildIndex, rightChildIndex))
                    return leftChildIndex;

                return rightChildIndex;
            }
            else if (leftChildIndex < _elements.Count)
            {
                return leftChildIndex;
            }
            else
            {
                return -1;
            }
        }
            
        private bool IsIndexValid(int index)
            => index >= 0 && index < _elements.Count;

        private bool IsGreater(int index, int parentIndex)
            => _elements[index].CompareTo(_elements[parentIndex]) > 0;
    }
}
