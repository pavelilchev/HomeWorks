namespace BookshopSystem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.SqlServer;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Data;
    using EntityFramework.Extensions;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            //You can comment  - Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>()); in BookShopContext.cs for better performance after initial seed

            var ctx = new BookShopContext();
            ctx.Database.Initialize(true);

            //1. Books Titles by Age Restriction
            //ListBookTitlesByAgeRestriction(ctx);

            //1. Golden Books
            //ListGoldenBooks(ctx);

            //2. Books by Price
            //ListBookByPrice(ctx);

            //3. Not Released Books
            //ListNotReleasedBooksOnGivenDate(ctx);

            //4. Book Titles by Category
            //ListBooksBtCategories(ctx);

            //5. Books Released Before Date
            //ListBookReleasedBeforeGivenDate(ctx);

            //6. Authors Search
            //LisstAuthorBySearchedString(ctx);

            //7. Books Search
            //SearchBookByStringInTitle(ctx);

            //8. Book Titles Search
            //ListBookByAuthorLAstNameSearched(ctx);

            //9. Count Books
            //GetBooksCountByTitleLength(ctx);

            //10. Total Book Copies
            //GetTotalBooksCopiesPerAuthor(ctx);

            //11. Find Profit
            //GetCategoriesWjthBooksProfit(ctx);

            //12. Most Recent Books
            //GetCategoriesWithMostRecent3Books(ctx);

            //13. Increase Book Copies
            //IncreaseBookCopiesReleasedAfterGivenDate(ctx);

            //14. Remove Books
            //DeleteBooksWithLowerThan4200Copies(ctx);

            //15. Stored Procedure
            //GetAuthorBooksCountAndName(ctx);
        }

        private static void GetAuthorBooksCountAndName(BookShopContext ctx)
        {
            var authors = ctx.Authors.SqlQuery("sp_GetAuthorsNameAndBooksCount").ToList();
            Console.Write("Enter author name: ");
            string authorName = Console.ReadLine();
            var author = authors.FirstOrDefault(a => a.FirstName + ' ' + a.LastName == authorName);

            if (author != null)
            {
                Console.WriteLine($"{authorName} has written {author.Books.Count} books");
            }
        }

        private static void DeleteBooksWithLowerThan4200Copies(BookShopContext ctx)
        {
            var books = ctx.Books
                .Where(b => b.Copies < 4200);

            Console.WriteLine(books.Count() + " books were deleted");

            books.Delete();
            ctx.SaveChanges();
        }

        private static void IncreaseBookCopiesReleasedAfterGivenDate(BookShopContext ctx)
        {
            var books = ctx.Books
                .Where(b => b.ReleaseDate > new DateTime(2013, 6, 6));

            books.Update(b => new Book()
            {
                Copies = b.Copies + 44
            });

            ctx.SaveChanges();
            Console.WriteLine(books.Count() * 44);
        }

        private static void GetCategoriesWithMostRecent3Books(BookShopContext ctx)
        {
            var cat = ctx.Categories.Include(c => c.Books)
                .Select(c => new
                {
                    c.Name,
                    BooksCount = c.Books.Count,
                    RecentBooks = c.Books
                        .OrderByDescending(b => b.ReleaseDate)
                        .ThenBy(b => b.Title).Take(3).Select(b => new
                        {
                            b.Title,
                            b.ReleaseDate
                        })
                })
                .Where(c => c.BooksCount > 35)
                .OrderByDescending(c => c.BooksCount)
                .ToList();

            foreach (var c in cat)
            {
                Console.WriteLine($"--{c.Name}: {c.BooksCount} books");
                foreach (var b in c.RecentBooks)
                {
                    Console.WriteLine($"{b.Title} ({b.ReleaseDate.Value.Year})");
                }
            }
        }

        private static void GetCategoriesWjthBooksProfit(BookShopContext ctx)
        {
            var cat = ctx.Categories.Include(c => c.Books)
                .Select(c => new
                {
                    c.Name,
                    Profit = c.Books.Sum(b => b.Copies * b.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var c in cat)
            {
                Console.WriteLine($"{c.Name} - ${c.Profit}");
            }
        }

        private static void GetTotalBooksCopiesPerAuthor(BookShopContext ctx)
        {
            var authors = ctx.Authors.Include(a => a.Books)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    Count = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Count);

            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName} - {author.Count}");
            }
        }

        private static void GetBooksCountByTitleLength(BookShopContext ctx)
        {
            int len = int.Parse(Console.ReadLine());
            var count = ctx.Books.Where(b => b.Title.Length > len).Count();
            Console.WriteLine(count);
        }

        private static void ListBookByAuthorLAstNameSearched(BookShopContext ctx)
        {
            Console.Write("Author last name start with: ");
            var searched = Console.ReadLine();
            var books = ctx.Books
                .Where(b => b.Author.LastName.StartsWith(searched))
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .OrderBy(b => b.Id);

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }
        }

        private static void SearchBookByStringInTitle(BookShopContext ctx)
        {
            Console.Write("Search book by: ");
            var searched = Console.ReadLine().ToLower();
            var books = ctx.Books.Where(b => b.Title.ToLower().Contains(searched)).Select(b => b.Title);

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        private static void LisstAuthorBySearchedString(BookShopContext ctx)
        {
            Console.Write("Search author by: ");
            var searched = Console.ReadLine();
            var authors = ctx.Authors
                .Where(a => a.FirstName.EndsWith(searched))
                .Select(a => new {a.FirstName, a.LastName});

            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
            }
        }

        private static void ListBookReleasedBeforeGivenDate(BookShopContext ctx)
        {
            Console.Write("Enter date: ");
            string dateString = Console.ReadLine();
            DateTime date;
            bool isValidDate = DateTime.TryParse(dateString, out date);
            if (isValidDate)
            {
                var books = ctx.Books
                    .Where(b => b.ReleaseDate < date)
                    .Select(b => new
                    {
                        b.Title,
                        b.EditionType,
                        b.Price
                    });

                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title} - {book.EditionType} - {book.Price}");
                }
            }
        }

        private static void ListBooksBtCategories(BookShopContext ctx)
        {
            Console.Write("Enter categories: ");
            var categories = Regex.Split(Console.ReadLine().ToLower(), @"\s+").Where(s => s != string.Empty);
            var books = ctx.Books
                .Include(b => b.Categories)
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Categories
                })
                .OrderBy(b => b.Id)
                .ToList();

            foreach (var book in books)
            {
                bool isBookInCategories = false;
                foreach (var cat in book.Categories)
                {
                    if (categories.Contains(cat.Name.ToLower()))
                    {
                        isBookInCategories = true;
                        break;
                    }
                }

                if (isBookInCategories)
                {
                    Console.WriteLine(book.Title);
                }
            }
        }

        private static void ListNotReleasedBooksOnGivenDate(BookShopContext ctx)
        {
            Console.Write("Enter release year: ");
            string stringYear = Console.ReadLine();
            int year;
            bool isVaid = int.TryParse(stringYear, out year);
            if (isVaid)
            {
                var books = ctx.Books
                    .Where(b => SqlFunctions.DatePart("year", b.ReleaseDate) != year)
                    .Select(b => new
                    {
                        b.Id,
                        b.Title
                    })
                    .OrderBy(b => b.Id);

                foreach (var book in books)
                {
                    Console.WriteLine(book.Title);
                }
            }
            else
            {
                Console.WriteLine("Invalid year");
            }
        }

        private static void ListBookByPrice(BookShopContext ctx)
        {
            var books = ctx.Books
                .Where(b => b.Price < 5 || b.Price > 40)
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Price
                })
                .OrderBy(b => b.Id);

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - ${book.Price}");
            }
        }

        private static void ListGoldenBooks(BookShopContext ctx)
        {
            var books = ctx.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => new
                {
                    b.Id,
                    b.Title
                })
                .OrderBy(b => b.Id);
            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }

        private static void ListBookTitlesByAgeRestriction(BookShopContext ctx)
        {
            Console.Write("Enter book's age restriction: ");
            string restrictionString = Console.ReadLine();
            AgeRestriction bookAgeRestriction;
            bool isValidRestriction = Enum.TryParse(restrictionString, true, out bookAgeRestriction);

            if (isValidRestriction)
            {
                var books = ctx.Books.Where(b => b.AgeRestriction == bookAgeRestriction);

                foreach (var book in books)
                {
                    Console.WriteLine(book.Title);
                }
            }
            else
            {
                Console.WriteLine("Invalid age restriction type");
            }
        }
    }
}