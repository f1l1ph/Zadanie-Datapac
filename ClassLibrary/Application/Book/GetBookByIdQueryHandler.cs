using ClassLibrary.Context;
using ClassLibrary.Entities;
using ClassLibrary.Repositories;
using MediatR;

namespace ClassLibrary.Application.Book;
public class GetBookByIdQueryHandler(IBookRepositoryRead repositoryRead): IRequestHandler<GetBookByIdQuery, BookEntity>
{
    public async Task<BookEntity> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        return await repositoryRead.GetBookById(request.Id) ?? new BookEntity
        {
            Name = "",
            Author = ""
        };
    }
}
