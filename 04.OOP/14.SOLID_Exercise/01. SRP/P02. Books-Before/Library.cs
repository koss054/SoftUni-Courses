using System.Collections.Generic;
using System.Linq;

namespace P02._Books_Before
{
    public class Library
    {
        private List<Book> books;

        public Library()
        {
            this.books = new List<Book>();
        }

        public int FindBook(string title)
            => this.books
            .Where(x => x.Title == title)
            .Count();

    }
}
