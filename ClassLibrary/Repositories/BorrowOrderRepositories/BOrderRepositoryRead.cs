using ClassLibrary.Entities;

namespace ClassLibrary.Repositories.BorrowOrderRepositories;
public class BOrderRepositoryRead:IBOrderRepositoryRead
{
    public Task<IEnumerable<BorrowOrderEntity>> GetBOrders()
    {
        throw new NotImplementedException();
    }

    public Task<BorrowOrderEntity> GetBorrowOrderById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BorrowOrderEntity>> GetBorrowOrderByBookId(int id)
    {
        throw new NotImplementedException();
    }
}

