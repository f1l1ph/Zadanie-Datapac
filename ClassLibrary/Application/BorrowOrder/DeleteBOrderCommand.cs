using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class DeleteBOrderCommand(int id) : IRequest<int>
{
    public int Id { get; set; } = id;
}
