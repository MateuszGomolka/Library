namespace Library
{
    public class Book
    {
        public string Title { get; }

        public string AuthorFirstName { get; }

        public string AuthorLastName { get; }

        public int ReleaseYear { get; }

        public Book(string title, string authorFirstName, string authorLastName, int releaseYear)
        {
            Title = title;
            AuthorFirstName = authorFirstName;
            AuthorLastName = authorLastName;
            ReleaseYear = releaseYear;
        }

        public Book WithTitle(string title)
            => new Book(title, this.AuthorFirstName, this.AuthorLastName, this.ReleaseYear);

        public Book WithAuthorFirstName(string authorFirstName)
            => new Book(this.Title, authorFirstName, this.AuthorLastName, this.ReleaseYear);

        public Book WithAuthorLastName(string authorLastName)
            => new Book(this.Title, this.AuthorFirstName, authorLastName, this.ReleaseYear);

        public Book WithReleaseYear(int releaseYear)
            => new Book(this.Title, this.AuthorFirstName, this.AuthorLastName, releaseYear);

        public override string ToString()
            => $"{Title} - {AuthorFirstName} {AuthorLastName} {ReleaseYear}";
    }
}