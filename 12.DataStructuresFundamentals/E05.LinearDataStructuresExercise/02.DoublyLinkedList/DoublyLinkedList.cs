namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T element, Node next, Node previous)
            {
                Element = element;
                Next = next;
                Previous = previous;
            }

            public Node(T element)
                : this(element, null, null)
            {
            }

            public Node(T element, Node next)
                : this(element, next, null)
            {
            }
        }

        Node _head;
        Node _tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item, _head);

            if (_head != null)
            {
                _head.Previous = node;    
                node.Next = _head;
            }

            _head = node;
            Count++;

            if (_tail == null)
                _tail = node;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Previous = _tail;
                _tail = newNode;
            }

            Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();

            return _head.Element;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            return _tail.Element;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            var oldHead = _head;

            _head = oldHead.Next;

            if (_head != null)
                _head.Previous = null;

            Count--;

            return oldHead.Element;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            var oldTail = _tail;

            _tail = oldTail.Previous;

            if (_tail != null)
                _tail.Next = null;

            Count--;

            return oldTail.Element;
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
            if (Count == 0)
                throw new InvalidOperationException();
        }
    }
}