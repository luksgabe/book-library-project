namespace BookLibrary.Application.Books.Queries
{
    public class BookQuery
    {
        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public int TotalCopies { get; protected set; }
        public int CopiesInUse { get; protected set; }
        public string Type { get; protected set; }
        public string Isbn { get; protected set; }
        public string Category { get; protected set; }
    }
}
