namespace Library.Application.Features.Books;

public class Book
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
    
}