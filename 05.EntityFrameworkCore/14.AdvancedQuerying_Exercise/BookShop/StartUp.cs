namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            //int input = int.Parse(Console.ReadLine());
            //string input = Console.ReadLine();

            //Console.WriteLine(GetBooksByAgeRestriction(db, command));
            //Console.WriteLine(GetGoldenBooks(db));
            //Console.WriteLine(GetBooksByPrice(db));
            //Console.WriteLine(GetBooksNotReleasedIn(db, year));
            //Console.WriteLine(GetBooksByCategory(db, input));
            //Console.WriteLine(GetBooksReleasedBefore(db, date));
            //Console.WriteLine(GetAuthorNamesEndingIn(db, input));
            //Console.WriteLine(GetBookTitlesContaining(db, input));
            //Console.WriteLine(GetBooksByAuthor(db, input));
            //Console.WriteLine(CountBooks(db, input));
            //Console.WriteLine(CountCopiesByAuthor(db));
            //Console.WriteLine(GetTotalProfitByCategory(db));
            //Console.WriteLine(GetMostRecentBooks(db));
            //IncreasePrices(db);
            Console.WriteLine(RemoveBooks(db));
        }

        //Exercise 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            bool parseSuccess 
                = Enum.TryParse(command, true, out AgeRestriction ageRestriction);

            if (!parseSuccess)
            {
                return String.Empty;
            }

            string[] bookTitles = context
                .Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }

        //Exercise 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();
            EditionType goldenEdition = (EditionType)2;

            var goldenBookTitles = context
                .Books
                .Where(b => b.EditionType == goldenEdition
                         && b.Copies < 5000)
                .Select(b => new
                {
                    BookId = b.BookId,
                    BookTitle = b.Title
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            foreach(var b in goldenBookTitles)
            {
                output.AppendLine($"{b.BookTitle}");
            }

            return output.ToString().TrimEnd();
        }

        //Exercise 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var booksWithPrice = context
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookPrice = b.Price
                })
                .OrderByDescending(b => b.BookPrice)
                .ToArray();

            foreach(var b in booksWithPrice)
            {
                output.AppendLine($"{b.BookTitle} - ${b.BookPrice:F2}");
            }

            return output.ToString().TrimEnd();
        }

        //Exercise 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder output = new StringBuilder();

            var bookTitles = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    BookId = b.BookId,
                    BookTitle = b.Title
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            foreach(var b in bookTitles)
            {
                output.AppendLine($"{b.BookTitle}");
            }

            return output.ToString().TrimEnd();
        }

        //Exercise 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] books = context
                .Books
                .Where(b => b.BookCategories
                    .Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        //Exercise 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder output = new StringBuilder();
            DateTime parsedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context
                .Books
                .Where(b => b.ReleaseDate < parsedDate)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookEdition = b.EditionType,
                    BookPrice = b.Price,
                    BookReleaseDate = b.ReleaseDate
                })
                .OrderByDescending(b => b.BookReleaseDate)
                .ToArray();

            foreach(var b in books)
            {
                output.AppendLine($"{b.BookTitle} - {b.BookEdition} - ${b.BookPrice:F2}");
            }

            return output.ToString().TrimEnd();
        }

        //Exercise 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context
                .Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToArray()
                .OrderBy(a => a)
                .ToArray();

            return String.Join(Environment.NewLine, authorNames);
        }

        //Exercise 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitles = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }

        //Exercise 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder output = new StringBuilder();

            var booksAndAuthors = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    BookId = b.BookId,
                    BookTitle = b.Title,
                    AuthorFullName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            foreach(var b in booksAndAuthors)
            {
                output.AppendLine($"{b.BookTitle} ({b.AuthorFullName})");
            }

            return output.ToString().TrimEnd();
        }

        //Exercise 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var bookTitles = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.Title)
                .ToArray();

            return bookTitles.Count();
        }

        //Exercise 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var authorCopies = context
                .Authors
                .Select(a => new
                {
                    AuthorFullName = $"{a.FirstName} {a.LastName}",
                    AuthorCopies = a.Books
                        .Select(b => b.Copies)
                        .Sum()
                })
                .OrderByDescending(a => a.AuthorCopies)
                .ToArray();

            foreach(var a in authorCopies)
            {
                output.AppendLine($"{a.AuthorFullName} - {a.AuthorCopies}");
            }

            return output.ToString().TrimEnd();
        }

        //Exercise 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var categoryPrice = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    ProfitByCategory = c.CategoryBooks
                        .Select(cb => cb.Book.Price * cb.Book.Copies)
                        .Sum()
                })
                .OrderByDescending(c => c.ProfitByCategory)
                .ThenBy(c => c.CategoryName)
                .ToArray();
                
            foreach(var c in categoryPrice)
            {
                output.AppendLine($"{c.CategoryName} ${c.ProfitByCategory:F2}");
            }

            return output.ToString().TrimEnd();
        }

        //Exercise 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder output = new StringBuilder();

            var recentBooks = context
                .Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    ThreeMostRecentBooks = String.Join(Environment.NewLine, c.CategoryBooks
                        .Select(cb => cb.Book)
                        .OrderByDescending(cb => cb.ReleaseDate)
                        .Take(3)
                        .Select(b => $"{b.Title} ({b.ReleaseDate.Value.Year})"))
                })
                .OrderBy(c => c.CategoryName)
                .Select(c => $"--{c.CategoryName}{Environment.NewLine}{c.ThreeMostRecentBooks}")
                .ToArray();

            foreach (var rb in recentBooks)
            {
                output.AppendLine(rb);
            }
            
            return output.ToString().TrimEnd();
        }

        //Exercise 15
        public static void IncreasePrices(BookShopContext context)
        {
            var bookPricesToIncrease = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var b in bookPricesToIncrease)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }

        //Exercise 16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            int removedBooks = booksToRemove.Length;

            context.Books.RemoveRange(booksToRemove);
            context.SaveChanges();

            return removedBooks;
        }
    }
}
