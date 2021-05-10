using System;
using System.Linq;

namespace Zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileManager = new FileManager(booksPath: "./Books.json");

            Book a = new Book(
                title: "Tytuł A",
                authorFirstName: "Imię",
                authorLastName: "Nazwisko",
                releaseYear: 2000);

            //fileManager.GetBooks().ToList().ForEach(Console.WriteLine);
            fileManager.SaveBook(a);
        }
    }
}