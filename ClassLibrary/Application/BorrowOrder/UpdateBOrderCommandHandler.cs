using ClassLibrary.Repositories.BorrowOrderRepositories;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class UpdateBOrderCommandHandler(IBOrderRepositoryWrite repository) : IRequestHandler<UpdateBOrderCommand, int>
{
    public async Task<int> Handle(UpdateBOrderCommand request, CancellationToken cancellationToken)
    {
        return await repository.UpdateOrder(request.Order);
    }
}