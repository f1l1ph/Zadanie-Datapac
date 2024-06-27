using ClassLibrary.Entities;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class GetBOrderByBookIdQuery(int id) : IRequest<IEnumerable<BorrowOrderEntity>>{
    public int BookId { get; set; } = id;
}
