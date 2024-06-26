using MediatR;

namespace ClassLibrary.Application.Book;

public class DeleteBookCommand(int id):IRequest<int>
{
    public int Id { get; set; } = id;
}
