using ClassLibrary.Entities;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class UpdateBOrderCommand : IRequest<int>
{
    public required BorrowOrderEntity Order { get; set; }
}
