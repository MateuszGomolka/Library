using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileManager = new FileManager(booksPath: "./Books.json");
            var bookRepository = new BookRepository (fileManager);

            Book a = new Book(
                title: "Tytuł A",
                authorFirstName: "Imię",
                authorLastName: "Nazwisko",
                releaseYear: 2000);  
            Book b = a.WithTitle("Tytuł B").WithReleaseYear(2002);

            Console.WriteLine(a);  
            Console.WriteLine(b);  

            IList<Book> booksWithTitle = bookRepository.FindBooksByTitle("tytuł 1");

            foreach(Book book in booksWithTitle)
            {
                System.Console.WriteLine(book);
            }
        }
    }
}