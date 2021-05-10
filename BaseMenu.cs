using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Zadanie
{
    public class BaseMenu
    {
        private readonly BookRepository bookRepository;

        public BaseMenu(BookRepository bookRepository)
        {
            this.bookRepository = BookRepository;
        }

        public void Start()
        {
            Title = "Zbiór książek - Biblioteka";
            RunMainMenu();           
        }

        private void RunMainMenu()
        {
            Console.CursorVisible = false;
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
            Clear();
            WriteLine("Wybrano opcję dodanie książki do zbioru biblioteki.");
            WriteLine("\nNaciśnij dowolny przycisk aby wrócić do menu głównego.");
            ReadKey(true);
            RunMainMenu();
        }            
    
        private void ChooseFindBookByTitle()
        {
            Clear();
            WriteLine("Wybrano opcję wyszukaj książkę po tytule.");
            WriteLine("\nNaciśnij dowolny przycisk aby wrócić do menu głównego.");
            ReadKey(true);
            RunMainMenu();
        }

        private void ChooseFindBookByAuthor()
        {
            Clear();
            WriteLine("Wybrano opcję wyszukaj książkę po autorze.");
            WriteLine("\nNaciśnij dowolny przycisk aby wrócić do menu głównego.");
            ReadKey(true);
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
