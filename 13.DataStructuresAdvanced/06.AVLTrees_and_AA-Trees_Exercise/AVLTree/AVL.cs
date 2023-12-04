namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Height = 1;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }

            public override string ToString()
            {
                return $"V:[{Value}] H:[{Height}]"; // R:[{Right}] L:[{Left}]
            }
        }

        public Node Root { get; private set; }

        public bool Contains(T element)
        {
            return this.Contains(this.Root, element) != null;
        }

        private Node Contains(Node node, T element)
        {
            if (node is null)
            {
                return null;
            }

            var compare = element.CompareTo(node.Value);

            if (compare < 0)
            {
                return this.Contains(node.Left, element);
            }
            else if (compare > 0)
            {
                return this.Contains(node.Right, element);
            }

            return node;
        }

        public void Delete(T element)
        {
            this.Root = this.Delete(this.Root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node is null)
            {
                return null;
            }

            if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Delete(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Delete(node.Right, element);
            }
            else
            {
                if (node.Left is null && node.Right is null)
                {
                    return null;
                }
                else if (node.Left is null)
                {
                    node = node.Right;
                }
                else if (node.Right is null)
                {
                    node = node.Left;
                }
                else
                {
                    Node temp = this.FindSmallestNode(node.Right);
                    node.Value = temp.Value;

                    node.Right = this.Delete(node.Right, temp.Value);
                }
            }

            if (node is null)
            {
                return null;
            }

            node = this.Balance(node);
            node.Height = Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right)) + 1;

            return node;
        }

        public void DeleteMin()
        {
            if (this.Root == null)
            {
                return;
            }

            Node temp = this.FindSmallestNode(this.Root);

            this.Root = this.Delete(this.Root, temp.Value);
        }

        private Node FindSmallestNode(Node node)
        {
            Node current = node;

            while (current.Left != null)
                current = current.Left;

            return current;
        }

        public void Insert(T element)
        {
            this.Root = this.Insert(this.Root, element);
        }

        private Node Insert(Node node, T element)
        {
            if (node is null)
            {
                return new Node(element);
            }

            if (element.CompareTo(node.Value) < 0)
            {           
                node.Left = this.Insert(node.Left, element);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(node.Right, element);
            }

            node = this.Balance(node);
            node.Height = Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right)) + 1;

            return node;
        }

        private Node Balance(Node node)
        {
            var balance = this.GetHeight(node.Left) - this.GetHeight(node.Right);

            if (balance > 1)
            {
                var childBalance = this.GetHeight(node.Left.Left) - this.GetHeight(node.Left.Right);
                if (childBalance < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                node = RotateRight(node);
            }
            else if (balance < -1)
            {
                var childBalance = this.GetHeight(node.Right.Left) - this.GetHeight(node.Right.Right);
                if (childBalance > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                node = RotateLeft(node);
            }

            return node;
        }

        private Node RotateRight(Node node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            node.Height = Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right)) + 1;

            return left;
        }

        private Node RotateLeft(Node node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            node.Height = Math.Max(this.GetHeight(node.Left), this.GetHeight(node.Right)) + 1;

            return right;
        }

        private int GetHeight(Node node)
        {
            if (node is null)
            {
                return 0;
            }

            return node.Height;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.Root, action);
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node is null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }
    }
}
