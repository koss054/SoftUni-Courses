using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Categorization
{
    public class Categorizator : ICategorizator
    {
        Dictionary<string, Category> _categories = new Dictionary<string, Category>();

        public void AddCategory(Category category)
        {
            if (_categories.ContainsKey(category.Id))
            {
                throw new ArgumentException();
            }

            _categories.Add(category.Id, category);
        }

        public void AssignParent(string childCategoryId, string parentCategoryId)
        {
            if (!_categories.ContainsKey(childCategoryId) || !_categories.ContainsKey(parentCategoryId))
            {
                throw new ArgumentException();
            }

            var parentCategory = _categories[parentCategoryId];
            if (parentCategory.Children.Any(x => x.Id == childCategoryId))
            {
                throw new ArgumentException();
            }

            var childCategory = _categories[childCategoryId];
            childCategory.Parent = parentCategory;
            parentCategory.Children.Add(childCategory);

            var ancestor = parentCategory;
            while (ancestor.Parent != null)
            {
                ancestor = ancestor.Parent;
            }

            UpdateParentDepth(ancestor);
        }

        private int UpdateParentDepth(Category node)
        {
            if (node is null)
            {
                return 0;
            }

            var depth = 0;
            foreach (var child in node.Children)
            {
                depth = Math.Max(depth, UpdateParentDepth(child));
            }

            node.Depth = depth + 1;
            return node.Depth;
        }

        public bool Contains(Category category)
        {
            return _categories.ContainsKey(category.Id);
        }

        public IEnumerable<Category> GetChildren(string categoryId)
        {
            if (!_categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var parentCategory = _categories[categoryId];
            var childrenToReturn = new HashSet<Category>();

            GetChildren(parentCategory.Children, childrenToReturn);
            return childrenToReturn;
        }

        private void GetChildren(IEnumerable<Category> children, HashSet<Category> childrenToReturn)
        {
            if (children.Count() == 0)
            {
                return;
            }

            foreach (var child in children)
            {
                GetChildren(child.Children, childrenToReturn);
                childrenToReturn.Add(child);
            }
        }

        public IEnumerable<Category> GetHierarchy(string categoryId)
        {
            if (!_categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var category = _categories[categoryId];
            var hierarchy = new HashSet<Category>();

            GetHierarchy(category, hierarchy);
            return hierarchy;
        }

        private void GetHierarchy(Category category, HashSet<Category> hierarchy)
        {
            if (category is null)
            {
                return;
            }

            GetHierarchy(category.Parent, hierarchy);
            hierarchy.Add(category);
        }

        public IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName()
        {
            return _categories.Values
                .OrderByDescending(x => x.Depth)
                .ThenBy(x => x.Name)
                .Take(3)
                .ToList();
        }

        public void RemoveCategory(string categoryId)
        {
            if (!_categories.ContainsKey(categoryId))
            {
                throw new ArgumentException();
            }

            var categoryToRemove = _categories[categoryId];
            foreach (var childCategory in categoryToRemove.Children)
            {
                _categories.Remove(childCategory.Id);
            }
            _categories.Remove(categoryId);
        }

        public int Size()
        {
            return _categories.Count();
        }
    }
}
