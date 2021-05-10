using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadanie 
{
    public class BookRepository
    {
        private readonly FileManager fileManager;

        public BookRepository(FileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetAllBooks() => fileManager.GetBooks();

        public IList<Book> FindBooksByTitle(string title)
            => fileManager
                .GetBooks()
                .Where(b => b.Title.Contains(title))
                .ToList();

        public IList<Book> FindBooksByAuthor(string firstName, string lastName)
            => fileManager
                .GetBooks()
                .Where(b => 
                    b.AuthorFirstName.Contains(firstName) && 
                    b.AuthorLastName.Contains(lastName))
                .ToList();
    }
}