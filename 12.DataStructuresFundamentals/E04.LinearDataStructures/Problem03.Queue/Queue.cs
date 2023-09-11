namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }

            public Node(T element)
                : this(element, null)
            {
            }
        }

        private Node _head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (_head == null)
            {
                _head = new Node(item);
                Count++;
                return;
            }

            var node = _head;
            while (node.Next != null)
            {
                node = node.Next;
            }

            node.Next = new Node(item);
            Count++;
        }

        public T Dequeue()
        {
            EnsureNotEmpty();

            if (_head.Next == null)
            {
                var headElement = _head.Element;
                _head = null;
                Count--;
                return headElement;
            }

            var oldHeadElement = _head.Element;
            var newHead = _head.Next;

            _head = newHead;
            Count--;
            return oldHeadElement;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return _head.Element;
        }

        public bool Contains(T item)
        {
            var node = _head;

            while (node != null)
            {
                if (node.Element.Equals(item))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = _head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        void EnsureNotEmpty()
        {
            if (_head == null)
                throw new InvalidOperationException();
        }
    }
}