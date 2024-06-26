using ClassLibrary.Entities;
using MediatR;

namespace ClassLibrary.Application.Book;

public class GetBookByIdQuery(int id):IRequest<BookEntity>
{
    public int Id { get; set; } = id;
}
