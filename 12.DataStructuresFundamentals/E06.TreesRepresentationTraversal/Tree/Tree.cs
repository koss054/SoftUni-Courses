namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        T _value;
        Tree<T> _parent;
        List<Tree<T>> _children;

        public Tree(T value)
        {
            _value = value;
            _children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child._parent = this;
                _children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = FindNodeWithBfs(parentKey);

            if (parentNode != null)
            {
                parentNode._children.Add(child);
                child._parent = parentNode;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree._value);

                foreach (var child in subtree._children)
                    queue.Enqueue(child);
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var order = new List<T>();
            Dfs(this, order);
            return order;
        }

        public void RemoveNode(T nodeKey)
        {
            var nodeToDelete = FindNodeWithBfs(nodeKey);

            if (nodeToDelete == null)
                throw new ArgumentNullException();

            var parentNode = nodeToDelete._parent;

            if (parentNode == null)
                throw new ArgumentException();

            parentNode._children.Remove(nodeToDelete);
            nodeToDelete._parent = null;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = FindNodeWithBfs(firstKey);
            var secondNode = FindNodeWithBfs(secondKey);

            if (firstNode == null || secondNode == null)
                throw new ArgumentNullException();

            var firstParent = firstNode._parent;
            var secondParent = secondNode._parent;

            if (firstParent == null || secondParent == null)
                throw new ArgumentException();

            var firstChildIndex = firstParent._children.IndexOf(firstNode);
            var secondChildIndex = secondParent._children.IndexOf(secondNode);

            firstParent._children[firstChildIndex] = secondNode;
            secondParent._children[secondChildIndex] = firstNode;
        }

        Tree<T> FindNodeWithBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();

                if (subtree._value.Equals(parentKey))
                    return subtree;

                foreach (var child in subtree._children)
                    queue.Enqueue(child);
            }

            return null;
        }

        void Dfs(Tree<T> tree, List<T> order)
        {
            foreach (var child in tree._children)
                Dfs(child, order);

            order.Add(tree._value);
        }
    }
}
