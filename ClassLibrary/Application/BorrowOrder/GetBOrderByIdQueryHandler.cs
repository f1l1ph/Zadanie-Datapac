using ClassLibrary.Entities;
using ClassLibrary.Repositories.BorrowOrderRepositories;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class GetBOrderByIdQueryHandler(IBOrderRepositoryRead repository):IRequestHandler<GetBOrderByIdQuery, BorrowOrderEntity>
{
    public async Task<BorrowOrderEntity?> Handle(GetBOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetBorrowOrderById(request.Id);
    }
}

