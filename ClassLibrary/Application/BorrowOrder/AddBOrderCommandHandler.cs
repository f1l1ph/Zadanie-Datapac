using ClassLibrary.Entities;
using ClassLibrary.Repositories.BookRepositories;
using ClassLibrary.Repositories.BorrowOrderRepositories;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class AddBOrderCommandHandler(IBOrderRepositoryWrite repository) : IRequestHandler<AddBOrderCommand, int>
{
    public async Task<int> Handle(AddBOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new BorrowOrderEntity
        {
            User = request.Order.User,
            OpenDate = request.Order.OpenDate,
            CloseDate = request.Order.CloseDate,
            BookId = request.Order.BookId,
            IsActive = true
        };

        return await repository.AddOrder(order);
    }
}

