namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        Node _root;

        public BinarySearchTree() { }

        private BinarySearchTree(Node node)
        {

            _root = node;
        }

        public bool Contains(T element)
            => FindNode(element) != null;

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action, _root);
        }

        public void Insert(T element)
        {
            _root = Insert(element, _root);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = FindNode(element);

            if (node is null) return null;

            return new BinarySearchTree<T>(node);
        }

        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node is null) return;

            EachInOrder(action, node.Left);
            action.Invoke(node.Value);
            EachInOrder(action, node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node is null) node = new Node(element);
            else if (element.CompareTo(node.Value) < 0) node.Left = Insert(element, node.Left);
            else if (element.CompareTo(node.Value) > 0) node.Right = Insert(element, node.Right);

            return node;
        }

        private Node FindNode(T element)
        {
            var node = _root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0) node = node.Left;
                else if (element.CompareTo(node.Value) > 0) node = node.Right;
                else break;
            }

            return node;
        }

        private void PreOrderCopy(Node node)
        {
            if (node is null) return;

            Insert(node.Value);
            PreOrderCopy(node.Left);
            PreOrderCopy(node.Right);
        }
    }
}
