using ClassLibrary.Repositories.BorrowOrderRepositories;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class ReturnBOrderCommandHandler(IBOrderRepositoryWrite repository):IRequestHandler<ReturnBOrderCommand, int>
{
    public async Task<int> Handle(ReturnBOrderCommand request, CancellationToken cancellationToken)
    {
        return await repository.ReturnBook(request.OrderId);
    }
}
