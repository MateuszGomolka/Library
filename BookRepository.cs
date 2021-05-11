using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class BookRepository
    {
        private readonly FileManager fileManager;

        public BookRepository(FileManager fileManager) => this.fileManager = fileManager;

        public void AddBook(Book book) => fileManager.SaveBook(book);

        public IList<Book> GetAllBooks()
        => fileManager
            .GetBooks()
            .OrderBy(b => b.Title)
            .ToList();

        public IList<Book> FindBooksByTitle(string title)
            => GetAllBooks()
                .Where(b => b.Title.ToUpper().Contains(title.ToUpper()))
                .ToList();

        public IList<Book> FindBooksByAuthor(string firstName, string lastName)
            => GetAllBooks()
                .Where(b => 
                    b.AuthorFirstName.ToUpper().Contains(firstName.ToUpper()) && 
                    b.AuthorLastName.ToUpper().Contains(lastName.ToUpper()))
                .ToList();
    }
}