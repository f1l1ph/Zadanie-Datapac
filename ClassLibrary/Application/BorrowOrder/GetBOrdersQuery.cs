using ClassLibrary.Entities;
using MediatR;

namespace ClassLibrary.Application.BorrowOrder;

public class GetBOrdersQuery :IRequest<IEnumerable<BorrowOrderEntity>>
{

}

