using ClassLibrary.Models;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class AddBOrderCommand : IRequest<int>
{
    public required AddBOrderModel Order { get; set; }
}
