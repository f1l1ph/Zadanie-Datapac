using ClassLibrary.Entities;
using MediatR;

namespace ClassLibrary.Application.Book;

public class GetBookByIdQuery:IRequest<BookEntity>
{
    public int id { get; set; }

}
