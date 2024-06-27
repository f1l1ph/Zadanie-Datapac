using ClassLibrary.Entities;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class GetBOrderByIdQuery(int id) : IRequest<BorrowOrderEntity>
{
    public int Id { get; set; } = id;
}
