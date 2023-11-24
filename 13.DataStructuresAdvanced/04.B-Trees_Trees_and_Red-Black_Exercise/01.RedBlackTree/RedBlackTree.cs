namespace _01.RedBlackTree
{
    using System;
    using System.Collections.Generic;

    public class RedBlackTree<T>
        : IBinarySearchTree<T> where T : IComparable
    {
        private const bool Red = true;
        private const bool Black = false;
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
                this.Color = Red;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public bool Color { get; set; }
            public int Count { get; set; }
        }

        private Node root;

        private RedBlackTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        private void PreOrderCopy(Node node)
        {
            if (node is null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        public RedBlackTree()
        {
        }    

        public void Insert(T value)
        {
            this.root = this.Insert(this.root, value);
            this.root.Color = Black;
        }

        private Node Insert(Node node, T value)
        {
            if (node is null)
            {
                return new Node(value);
            }

            if (IsLesser(value, node.Value))
            {
                node.Left = this.Insert(node.Left, value);
            }
            else
            {
                node.Right = this.Insert(node.Right, value);
            }

            if (IsRed(node.Right))
            {
                node = RotateLeft(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColors(node);
            }

            return node;
        }

        public bool Contains(T element)
        {
            Node foundNode = this.FindNode(element);

            return foundNode.Value.CompareTo(element) is 0;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
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

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindNode(element);

            return new RedBlackTree<T>(current);
        }

        private Node FindNode(T element)
        {
            var current = this.root;

            while (current != null)
            {
                if (IsLesser(element, current.Value))
                {
                    current = current.Left;
                }
                else if (IsLesser(current.Value, element))
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        public void Delete(T element)
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.Delete(this.root, element);

            if (this.root != null)
            {
                this.root.Color = Black;
            }
        }

        private Node Delete(Node node, T element)
        {
            if (IsLesser(element, node.Value))
            {
                if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                {
                    node = this.MoveRedLeft(node);
                }

                node.Left = this.Delete(node.Left, element);
            }
            else
            {
                if (IsRed(node.Left))
                {
                    node = this.RotateRight(node);
                }

                if (AreEqual(element, node.Value) && node.Right is null)
                {
                    return null;
                }

                if (!IsRed(node.Right) && !IsRed(node.Right.Left))
                {
                    node = this.MoveRedRight(node);
                }

                if (AreEqual(element, node.Value))
                {
                    node.Value = this.FindMinimalValueInSubtree(node.Right);
                    node.Right = DeleteMin(node.Right);
                }
                else
                {
                    node.Right = this.Delete(node.Right, element);
                }
            }

            return this.FixUp(node);
        }

        private T FindMinimalValueInSubtree(Node node)
        {
            if (node.Left is null)
            {
                return node.Value;
            }

            return this.FindMinimalValueInSubtree(node.Left);
        }

        public void DeleteMin()
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMin(this.root);
            
            if (this.root != null)
            {
                this.root.Color = Black;
            }
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left is null)
            {
                return null;
            }

            if (!IsRed(node.Left) && !IsRed(node.Left.Left))
            {
                node = MoveRedLeft(node.Left);
            }

            node.Left = this.DeleteMin(node.Left);

            return this.FixUp(node);
        }

        private Node MoveRedLeft(Node node)
        {
            this.FlipColors(node);

            if (IsRed(node.Right.Left))
            {
                node.Right = RotateRight(node.Right);
                node = RotateLeft(node);
                this.FlipColors(node);
            }

            return node;
        }

        private Node FixUp(Node node) 
        {
            if (IsRed(node.Right))
            {
                node = RotateLeft(node.Left);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RotateRight(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                this.FlipColors(node);
            }

            return node;
        }

        public void DeleteMax()
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMax(this.root);

            if (this.root != null)
            {
                this.root.Color = Black;
            }
        }

        private Node DeleteMax(Node node)
        {
            if (IsRed(node.Left))
            {
                node = this.RotateRight(node);
            }

            if (node.Right is null)
            {
                return null;
            }

            if (!IsRed(node.Right) && !IsRed(node.Right.Left))
            {
                node = this.MoveRedRight(node);
            }

            node.Right = this.DeleteMax(node.Right);

            return this.FixUp(node);
        }

        private Node MoveRedRight(Node node)
        {
            this.FlipColors(node);
            
            if (IsRed(node.Left.Left))
            {
                node = this.RotateRight(node);
                this.FlipColors(node);
            }

            return node;
        }

        public int Count()
        {
            return this.Count(this.root);
        }

        private int Count(Node root)
        {
            if (root is null)
            {
                return 0;
            }

            return 1 + this.Count(root.Left) + this.Count(root.Right);
        }

        public int Rank(T element)
        {
            throw new NotImplementedException();
        }

        public T Select(int rank)
        {
            throw new NotImplementedException();
        }

        public T Ceiling(T element)
        {
            throw new NotImplementedException();
        }

        public T Floor(T element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            throw new NotImplementedException();
        }

        private Node RotateLeft(Node node)
        {
            var temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;
            temp.Color = temp.Left.Color;
            temp.Left.Color = Red;

            return temp;
        }

        private Node RotateRight(Node node)
        {
            var temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;
            temp.Color = temp.Right.Color;
            temp.Right.Color = Red;

            return temp;
        }

        private void FlipColors(Node node)
        {
            node.Color = !node.Color;
            node.Left.Color = !node.Left.Color;
            node.Right.Color = !node.Right.Color;
        }

        private bool IsRed(Node node)
        {
            if (node is null)
            {
                return false;
            }

            return node.Color == Red;
        }

        private bool IsLesser(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }

        private bool AreEqual(T a, T b)
        {
            return a.CompareTo(b) == 0;
        }
    }
}