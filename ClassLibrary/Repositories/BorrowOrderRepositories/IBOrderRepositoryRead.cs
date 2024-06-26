using ClassLibrary.Entities;

namespace ClassLibrary.Repositories.BorrowOrderRepositories;

public interface IBOrderRepositoryRead
{
    Task<IEnumerable<BorrowOrderEntity>> GetBOrders();

    Task<BorrowOrderEntity> GetBorrowOrderById(int id);

    Task<IEnumerable<BorrowOrderEntity>> GetBorrowOrderByBookId(int id);
}
