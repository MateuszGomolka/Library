namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileManager = new FileManager(booksPath: "./Books.json");
            var bookRepository = new BookRepository(fileManager);
            var mainMenu = new BaseMenu(bookRepository);
            mainMenu.Start();
        }
    }
}