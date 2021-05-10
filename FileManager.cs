using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Zadanie 
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
            string jsonContent = File.ReadAllText(booksPath);
            JObject jsonBookArrayObject = JObject.Parse(jsonContent);
            JToken[] jsonBookTokens = jsonBookArrayObject["Books"].ToArray();

            IList<Book> result = new List<Book>(jsonBookTokens.Length);
            
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
    }
}