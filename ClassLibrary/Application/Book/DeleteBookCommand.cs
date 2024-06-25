using MediatR;

namespace ClassLibrary.Application.Book;

public class DeleteBookCommand:IRequest<int>
{
    public int Id { get; set; }
}
