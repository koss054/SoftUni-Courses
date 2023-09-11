namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public void AddFirst(T item)
        {
            var node = new Node(item, _head);

            _head = node;
            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                var node = _head;
                while (node.Next != null)
                    node = node.Next;

                node.Next = newNode;
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
            EnsureNotEmpty() ;

            var node = _head;
            while (node.Next != null)
                node = node.Next;

            return node.Element;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            if (Count == 1)
                return SingleElementRemove();

            var oldHead = _head;

            _head = oldHead.Next;
            Count--;

            return oldHead.Element;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            if (Count == 1)
                return SingleElementRemove();

            var node = _head;
            while (node.Next.Next != null)
                node = node.Next;

            var newLastNode = node;
            var oldLastNode = newLastNode.Next;
            var element = oldLastNode.Element;

            newLastNode.Next = null;
            Count--;

            return element;
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

        T SingleElementRemove()
        {
            var element = _head.Element;

            _head = null;
            Count--;

            return element;
        }
    }
}