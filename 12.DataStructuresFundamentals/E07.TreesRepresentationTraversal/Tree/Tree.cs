namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            _children = new List<Tree<T>>();

            foreach (var child in children)
                AddChild(child);
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children
            => _children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            _children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            Parent = parent;
        }

        public string AsString()
        {
            var sb = new StringBuilder();

            DfsAsString(sb, this, 0);

            return sb.ToString().Trim();
        }

        public IEnumerable<T> GetInternalKeys()
        {
            // DFS
            //var internalNodes = new List<T>();

            //DfsNodes(internalNodes, this, tree => 
            //    tree.Children.Count > 0 && tree.Parent != null);

            //return internalNodes;

            // BFS
            return BfsNodes(tree => tree.Children.Count > 0 && tree.Parent != null)
                .Select(x => x.Key);
        }

        public IEnumerable<T> GetLeafKeys()
        {
            var leafNodes = new List<T>();

            DfsNodes(leafNodes, this, tree => 
                tree.Children.Count == 0);

            return leafNodes;         
        }

        public T GetDeepestKey()
            => GetDeepestNode().Key;

        public IEnumerable<T> GetLongestPath()
            => GetNodePath(GetDeepestNode());

        void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent)
              .Append(tree.Key)
              .AppendLine();

            foreach (var child in tree.Children)
                DfsAsString(sb, child, indent + 2);

        }

        void DfsNodes(List<T> result, Tree<T> tree, Predicate<Tree<T>> predicate)
        {
            if (predicate.Invoke(tree))
                result.Add(tree.Key);

            foreach (var child in tree.Children)
                DfsNodes(result, child, predicate);
        }

        List<Tree<T>> BfsNodes(Predicate<Tree<T>> predicate)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();

                if (predicate.Invoke(subtree))
                    result.Add(subtree);

                foreach (var child in subtree.Children)
                    queue.Enqueue(child);
            }

            return result;
        }

        Tree<T> GetDeepestNode()
        {
            var leafs = BfsNodes(tree => tree.Children.Count == 0);

            Tree<T> deepestNode = null;
            int maxDepth = 0;

            foreach (var leaf in leafs)
            {
                int depth = GetDepth(leaf);

                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        int GetDepth(Tree<T> leaf)
        {
            int leafDepth = 0;
            var tree = leaf;

            while (tree.Parent != null)
            {
                leafDepth++;
                tree = tree.Parent;
            }

            return leafDepth;
        }

        List<T> GetNodePath(Tree<T> node)
        {
            var tree = node;
            var result = new List<T>();
            var stack = new Stack<T>();

            while (tree != null)
            {
                stack.Push(tree.Key);
                tree = tree.Parent;
            }

            while (stack.Count > 0)
                result.Add(stack.Pop());

            return result;
        }
    }
}
