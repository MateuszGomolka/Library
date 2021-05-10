using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseMenu MainMenu = new BaseMenu();
            MainMenu.Start();

            /*
            var fileManager = new FileManager(booksPath: "./Books.json");
            var bookRepository = new BookRepository (fileManager);

            Book a = new Book(
                title: "Tytuł A",
                authorFirstName: "Imię",
                authorLastName: "Nazwisko",
                releaseYear: 2000);  

            IList<Book> booksWithTitle = bookRepository.FindBooksByTitle("tytuł");

            foreach(Book book in booksWithTitle)
            {
                System.Console.WriteLine(book);
            }
            */
        }
    }
}