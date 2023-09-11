namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
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

        private Node _top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            var node = new Node(item, _top);
            _top = node;
            Count++;
        }

        public T Pop()
        {
            EnsureNotEmpty();

            var topNodeElement = _top.Element;
            var newTop = _top.Next;

            _top.Next = null;
            _top = newTop;
            Count--;

            return topNodeElement;
        }

        public T Peek()
        {
            EnsureNotEmpty();
            return _top.Element;
        }
            

        public bool Contains(T item)
        {
            var node = _top;

            while (node != null)
            {
                if (node.Element.Equals(item))
                    return true;

                node = node.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = _top;

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
            if (_top == null)
                throw new InvalidOperationException();
        }
    }
}