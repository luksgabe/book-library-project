using BookLibrary.Application.Mediator;

namespace BookLibrary.Application.Books.Events
{
    public class BookRegisterEvent : Event
    {
        public BookRegisterEvent(string title, string firstName, string lastName, int totalCopies, int copiesInUse, string type, string isbn, string category)
        {
            Title=title;
            FirstName=firstName;
            LastName=lastName;
            TotalCopies=totalCopies;
            CopiesInUse=copiesInUse;
            Type=type;
            Isbn=isbn;
            Category=category;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int TotalCopies { get; private set; }
        public int CopiesInUse { get; private set; }
        public string Type { get; private set; }
        public string Isbn { get; private set; }
        public string Category { get; private set; }
    }
}
