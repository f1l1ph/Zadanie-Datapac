using ClassLibrary.Entities;
using ClassLibrary.Repositories.BorrowOrderRepositories;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class GetBOrdersQueryHandler(IBOrderRepositoryRead repository) : IRequestHandler<GetBOrdersQuery, IEnumerable<BorrowOrderEntity>>
{
    public async Task<IEnumerable<BorrowOrderEntity?>> Handle(GetBOrdersQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetBOrders();
    }
}
