using System;
using System.Collections.Generic;
using static System.Console;

namespace Zadanie
{
    public class BaseMenu
    {
        private readonly BookRepository bookRepository;
        private readonly OperationMenu addBookMenu;
        private readonly OperationMenu findBookByTitleMenu;
        private readonly OperationMenu findBookByAuthorMenu;

        public BaseMenu(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
            this.addBookMenu = new OperationMenu(
                operationHeader: "Wybrano opcję dodanie książki do zbioru biblioteki.\n", 
                operationFooter: "Naciśnij dowolny przycisk aby wrócić do menu głównego.",
                operation: AddBookOperation
            );
            this.findBookByTitleMenu = new OperationMenu(
                operationHeader: "Wybrano opcję wyszukaj książkę po tytule.\n",
                operationFooter: "Naciśnij dowolny przycisk aby wrócić do menu głównego.",
                operation: FindBookByTitleOperation
            );
            this.findBookByAuthorMenu = new OperationMenu(
                operationHeader: "Wybrano opcję wyszukaj książkę po autorze.\n",
                operationFooter: "Naciśnij dowolny przycisk aby wrócić do menu głównego.",
                operation: FindBookByAuthorOperation
            );
        }

        private void AddBookOperation()
        {
            WriteLine("Tytuł książki:");
            string title = ReadLine();

            WriteLine("Imię autora:");
            string firstName = ReadLine();

            WriteLine("Nazwisko autora:");
            string lastName = ReadLine();

            WriteLine("Rok wydania książki:");
            
            bool canParseNumber = false;
            bool isWarning = false;
            int releaseYear = 0;
            string releaseYearText = null;

            while(!canParseNumber)
            {
                if (isWarning)
                {
                    
                    SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    WriteLine(new string(' ', releaseYearText.Length));
                    SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                }
                releaseYearText = ReadLine();
                canParseNumber = int.TryParse(releaseYearText, out releaseYear);

                if (!isWarning && !canParseNumber)
                {
                    SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    isWarning = true;
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("Podaj poprawny rok wydania książki.\n");
                    ForegroundColor = ConsoleColor.White;
                }          
            }            
            var book = new Book(title, firstName, lastName, releaseYear);

            bookRepository.AddBook(book);
        }

        private void FindBookByTitleOperation()
        {
            WriteLine("Tytuł książki:");
            string title = ReadLine();

            IList<Book> booksWithTitle = bookRepository.FindBooksByTitle(title);

            foreach(Book book in booksWithTitle)
            {
                WriteLine(book);
            }

        }

        private void FindBookByAuthorOperation()
        {
            WriteLine("Imię autora:");
            string firstName = ReadLine();

            WriteLine("Nazwisko autora:");
            string lastName = ReadLine();

            IList<Book> booksWithName = bookRepository.FindBooksByAuthor(firstName, lastName);

            foreach(Book book in booksWithName)
            {
                WriteLine(book);
            }

        }

        public void Start()
        {
            Title = "Zbiór książek - Biblioteka";
            RunMainMenu();           
        }

        private void RunMainMenu()
        {
            string prompt = @"
██████╗ ██╗██████╗ ██╗     ██╗ ██████╗ ████████╗███████╗██╗  ██╗ █████╗ 
██╔══██╗██║██╔══██╗██║     ██║██╔═══██╗╚══██╔══╝██╔════╝██║ ██╔╝██╔══██╗
██████╔╝██║██████╔╝██║     ██║██║   ██║   ██║   █████╗  █████╔╝ ███████║
██╔══██╗██║██╔══██╗██║     ██║██║   ██║   ██║   ██╔══╝  ██╔═██╗ ██╔══██║
██████╔╝██║██████╔╝███████╗██║╚██████╔╝   ██║   ███████╗██║  ██╗██║  ██║
╚═════╝ ╚═╝╚═════╝ ╚══════╝╚═╝ ╚═════╝    ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝

Witaj w konsolowym zbiorze książek. 

Do poruszania się po menu należy użyć strzałek. Aby potwierdzić swój wybór należy wcisnąć ENTER.
";
            string[] options = { "Dodaj książkę", "Wyszukaj po tytule", "Wyszukaj po autorze", "Autorzy", "Zakończ" };

            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();


            switch (selectedIndex)
            {
                case 0:
                    ChooseAdd();
                    break;
                case 1:
                    ChooseFindBookByTitle();
                    break;
                case 2:
                    ChooseFindBookByAuthor();
                    break;
                case 3:
                    ChooseAbout();
                    break;
                case 4:
                    ChooseExit();
                    break;
            }
        }

        private void ChooseAdd()
        {
            addBookMenu.Run();
            RunMainMenu();
        }            
    
        private void ChooseFindBookByTitle()
        {
            findBookByTitleMenu.Run();
            RunMainMenu();
        }

        private void ChooseFindBookByAuthor()
        {
            findBookByAuthorMenu.Run();
            RunMainMenu();
        }

        private void ChooseAbout()
        {
            Clear();
            WriteLine("Przedstawiona aplikacja konsolowa 'Biblioteka' została wykonana przez:");
            WriteLine("Wicher Marcin (45596),");
            WriteLine("Gomółka Mateusz (45585).");
            WriteLine("Systemy kontroli błędów i wersji.");
            WriteLine("\nNaciśnij dowolny przycisk aby wrócić do menu głównego.");
            ReadKey(true);
            RunMainMenu();
        }

        private void ChooseExit()
        {
            Clear();
            WriteLine("Wybrano opcję zakończ.");
            WriteLine("\nNaciśnij dowolny przycisk aby zakończyć pracę.");
            ReadKey(true);
            Environment.Exit(0);
        }

    }
}
