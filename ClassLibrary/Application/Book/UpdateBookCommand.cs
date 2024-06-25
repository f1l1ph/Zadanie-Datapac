using MediatR;

namespace ClassLibrary.Application.Book;

public class UpdateBookCommand:IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
}
