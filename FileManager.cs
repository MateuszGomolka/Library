using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Library 
{
    public class FileManager
    {
        private readonly string booksPath;

        public FileManager(string booksPath)
        {
            this.booksPath = booksPath;
        }

        private bool IsValid(Book book) 
            => book != null && 
               book.AuthorFirstName != null && 
               book.AuthorLastName != null &&
               book.Title != null;

        public IList<Book> GetBooks()
        {          
            string jsonTextContent = File.ReadAllText(booksPath);
            JObject jsonContent = JObject.Parse(jsonTextContent);
            JToken[] jsonBookTokens = jsonContent["Books"].ToArray();
            IList<Book> result = new List<Book>(capacity: jsonBookTokens.Length);
            
            foreach (JToken bookToken in jsonBookTokens)
            {
                Book possibleBook = null;

                try 
                {
                    possibleBook = bookToken.ToObject<Book>();
                }
                catch (JsonReaderException) {} 

                if (IsValid(possibleBook))
                {
                    result.Add(possibleBook);
                }
            }
            return result;
        }

        public void SaveBook(Book book)
        {
            if (!IsValid(book))
            {
                return;
            }
            IList<Book> books = GetBooks();
            books.Add(book);
            var bookJsonArray = new Dictionary<string, IList<Book>>();
            bookJsonArray.Add("Books", books);
            
            string jsonOutput = JsonConvert.SerializeObject(bookJsonArray, Formatting.Indented);
            File.WriteAllText(booksPath, jsonOutput);
        }
    }
}