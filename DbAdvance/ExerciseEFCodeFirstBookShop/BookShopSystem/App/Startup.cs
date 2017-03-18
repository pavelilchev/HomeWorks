namespace BookShopSystem.App
{
    using System;
    using System.Linq;
    using Data;

    public class Startup
    {
        public static void Main()
        {
            var context = new BookShopContext();

            var books = context.Books.Take(3).ToList();

            books[0].RelatedBooks.Add(books[1]);
            books[1].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);
            books[2].RelatedBooks.Add(books[0]);

            var booksFromQuery = context.Books.Take(3).ToList();

            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.RelatedBooks)
                {
                    Console.WriteLine(relatedBook.Title);
                }
            }
        }
    }
}
