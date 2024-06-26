using ClassLibrary.Context;
using ClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories.BorrowOrderRepositories;

public class BOrderRepositoryWrite(LibraryContextWrite contextWrite) : IBOrderRepositoryWrite
{
    public async Task<int> AddOrder(BorrowOrderEntity order)
    {
        contextWrite.Orders.Add(order);
        await contextWrite.SaveChangesAsync();
        return order.Id;
    }

    public async Task<int> UpdateOrder(BorrowOrderEntity order)
    {
        var dbOrder = await contextWrite.Orders
            .FirstOrDefaultAsync(b => b.Id == order.Id);

        if (dbOrder == null) return 0;

        dbOrder.OpenDate = order.OpenDate;//only changing these two, BookId and Book should not change
        dbOrder.CloseDate = order.CloseDate;

        await contextWrite.SaveChangesAsync();
        return order.Id;
    }

    public async Task<int> RemoveOrder(int id)
    {
        var dbOrder = await contextWrite.Orders
            .FirstOrDefaultAsync(b => b.Id == id);

        if (dbOrder == null) return 0;

        contextWrite.Orders.Remove(dbOrder);
        await contextWrite.SaveChangesAsync();

        return 1;
    }
}
