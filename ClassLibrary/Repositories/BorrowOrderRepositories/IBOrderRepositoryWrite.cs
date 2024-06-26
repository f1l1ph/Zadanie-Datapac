using ClassLibrary.Entities;

namespace ClassLibrary.Repositories.BorrowOrderRepositories;

public interface IBOrderRepositoryWrite
{
    Task<int> AddOrder(BorrowOrderEntity order);

    Task<int> UpdateOrder(BorrowOrderEntity order);

    Task<int> RemoveOrder(int id);
}