namespace BookLibrary.Application.Books.Commands
{
    public class RegisterBookCommand : BookCommand
    {
        public RegisterBookCommand(string title, string firstName, string lastName, int totalCopies, int copiesInUse, string type, string isbn, string category)
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
    }
}
