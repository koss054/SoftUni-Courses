namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var result = new List<List<int>>();
            var currentPath = new LinkedList<int>();
            int currentSum = this.Key;

            currentPath.AddFirst(this.Key);
            Dfs(this, result, currentPath, ref currentSum, sum);

            return result;
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            var result = new List<Tree<int>>();
            var allSubtrees = GetAllNodesBfs();

            foreach (var subtree in allSubtrees)
            {
                if (HasGivenSum(subtree, sum))
                    result.Add(subtree);
            }

            return result;
        }

        bool HasGivenSum(Tree<int> subtree, int wantedSum)
        {
            int actualSum = subtree.Key;
            GetSubtreeSumDfs(subtree, wantedSum, ref actualSum);
            return actualSum == wantedSum;
        }

        void GetSubtreeSumDfs(Tree<int> subtree, int wantedSum, ref int actualSum)
        {
            foreach (var child in subtree.Children)
            {
                actualSum += child.Key;
                GetSubtreeSumDfs(child, wantedSum, ref actualSum);
            }
        }

        List<Tree<int>> GetAllNodesBfs()
        {
            var result = new List<Tree<int>>();
            var queue = new Queue<Tree<int>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree);

                foreach (var child in subtree.Children)
                    queue.Enqueue(child);
            }

            return result;
        }

        void Dfs(
            Tree<int> subtree, 
            List<List<int>> result, 
            LinkedList<int> currentPath, 
            ref int currentSum,
            int wantedSum)
        {
            foreach (var child in subtree.Children)
            {
                currentSum += child.Key;
                currentPath.AddLast(child.Key);
                Dfs(child, result, currentPath, ref currentSum, wantedSum);
            }

            if (currentSum == wantedSum)
                result.Add(new List<int>(currentPath));

            currentSum -= subtree.Key;
            currentPath.RemoveLast();
        }
    }
}
