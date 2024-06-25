using ClassLibrary.Entities;
using MediatR;

namespace ClassLibrary.Application.Book;

public class GetBooksQuery: IRequest<IEnumerable<BookEntity>>
{

}
