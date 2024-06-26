using ClassLibrary.Entities;
using ClassLibrary.Repositories.BookRepositories;
using MediatR;

namespace ClassLibrary.Application.Book;

public class GetBooksQueryHandler(IBookRepositoryRead bookRepositoryRead):IRequestHandler<GetBooksQuery, IEnumerable<BookEntity>>
{
    public async Task<IEnumerable<BookEntity>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        return await bookRepositoryRead.GetBooks();
    }
}