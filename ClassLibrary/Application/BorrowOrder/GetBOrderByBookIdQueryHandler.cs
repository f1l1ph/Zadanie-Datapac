using ClassLibrary.Entities;
using ClassLibrary.Repositories.BorrowOrderRepositories;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class GetBOrderByBookIdQueryHandler(IBOrderRepositoryRead repository):IRequestHandler<GetBOrderByBookIdQuery, IEnumerable<BorrowOrderEntity>>
{
    public async Task<IEnumerable<BorrowOrderEntity>?> Handle(GetBOrderByBookIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetBorrowOrderByBookId(request.BookId);
    }
}

