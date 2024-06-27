using ClassLibrary.Repositories.BorrowOrderRepositories;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class DeleteBOrderCommandHandler(IBOrderRepositoryWrite repository): IRequestHandler<DeleteBOrderCommand, int>
{
    public async Task<int> Handle(DeleteBOrderCommand request, CancellationToken cancellationToken)
    {
        return await repository.RemoveOrder(request.Id);
    }
}