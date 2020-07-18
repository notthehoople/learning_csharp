using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            // Without LINQ this is the code we'd need
            var cheapBooks = new List<Book>();
            foreach (var book in books)
            {
                if (book.Price < 10)
                    cheapBooks.Add(book);
            }

            Console.WriteLine("====== Without LINQ ======");
            foreach (var book in cheapBooks)
                Console.WriteLine(book.Title + " " + book.Price);

            // With LINQ and a lamba expression
            // LINQ expressions can also be chained. Here we'll pull out the cheap books, then sort by title
            var cheapBooksLINQ = books.Where(b => b.Price < 10).OrderBy(b => b.Title);

            // To order a collection by something, use LINQ with a lamba:
            // books.OrderBy(b => b.Title);
            // To select one of more properties from an object use Select(). Here we just pick the title so the result will be a string
            // books.OrderBy(b => b.Title).Select(b => b.Title);

            Console.WriteLine("====== With LINQ ======");
            foreach (var book in cheapBooksLINQ)
                Console.WriteLine(book.Title + " " + book.Price);
        }
    }
}
