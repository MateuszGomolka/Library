using System;

namespace Zadanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Book a = new Book(
                title: "Tytuł A",
                authorFirstName: "Imię",
                authorLastName: "Nazwisko",
                releaseYear: 2000);  
            Book b = a.WithTitle("Tytuł B").WithReleaseYear(2002);

            Console.WriteLine(a);  
            Console.WriteLine(b);  
        }
    }
}