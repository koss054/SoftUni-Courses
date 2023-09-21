namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> _nodesByKey;

        public IntegerTreeFactory()
        {
            _nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (var inputLine in input)
            {
                var keys = inputLine.Split(' ').Select(int.Parse).ToArray();

                var parent = keys[0];
                var child = keys[1];

                AddEdge(parent, child);
            }

            return GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!_nodesByKey.ContainsKey(key))
                _nodesByKey.Add(key, new IntegerTree(key));

            return _nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = CreateNodeByKey(parent);
            var childNode = CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        public IntegerTree GetRoot()
        {
            foreach (var kvp in _nodesByKey)
            {
                if (kvp.Value.Parent is null)
                    return kvp.Value;
            }

            return null;
        }
    }
}
