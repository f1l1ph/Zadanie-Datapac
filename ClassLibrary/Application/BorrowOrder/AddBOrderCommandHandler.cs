using ClassLibrary.Entities;
using ClassLibrary.Repositories.BookRepositories;
using ClassLibrary.Repositories.BorrowOrderRepositories;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class AddBOrderCommandHandler(IBOrderRepositoryWrite repository, IBookRepositoryRead readBookRepository) : IRequestHandler<AddBOrderCommand, int>
{
    public async Task<int> Handle(AddBOrderCommand request, CancellationToken cancellationToken)
    {
        var book = await readBookRepository.GetBookById(request.Order.BookId);

        if (book == null) { return 0; }
        if(book.ActiveBorrowOrder != null) { return -1; }

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

