using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class ReturnBOrderCommand(int orderId):IRequest<int>
{
    public int OrderId { get; set; } = orderId;
}
