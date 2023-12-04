using System.Collections.Generic;

namespace Exam.Categorization
{
    public class Categorizator : ICategorizator
    {
        public void AddCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public void AssignParent(string childCategoryId, string parentCategoryId)
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(Category category)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetChildren(string categoryId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetHierarchy(string categoryId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Category> GetTop3CategoriesOrderedByDepthOfChildrenThenByName()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCategory(string categoryId)
        {
            throw new System.NotImplementedException();
        }

        public int Size()
        {
            throw new System.NotImplementedException();
        }
    }
}
