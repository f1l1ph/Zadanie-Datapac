using MediatR;

namespace ClassLibrary.Application.Book;

public class AddBookCommand: IRequest<int>
{
    public string Name { get; set; }
    public string Author { get; set; }
}
