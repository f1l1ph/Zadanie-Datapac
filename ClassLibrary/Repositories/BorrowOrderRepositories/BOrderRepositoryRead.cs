using System.ComponentModel.DataAnnotations;
using ClassLibrary.Context;
using ClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories.BorrowOrderRepositories;
public class BOrderRepositoryRead(LibraryContextRead context):IBOrderRepositoryRead
{
    public async Task<IEnumerable<BorrowOrderEntity?>> GetBOrders()
    {
        return await context.Orders.ToArrayAsync();
    }

    public async Task<BorrowOrderEntity?> GetBorrowOrderById(int id)
    {
        return await context.Orders.FirstOrDefaultAsync(x => x.Id == id) ?? null;
    }

    public async Task<IEnumerable<BorrowOrderEntity>?> GetBorrowOrderByBookId(int id)
    {
        var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id) ?? null;

        if (book == null) return null;

        var orders = await context.Orders.Where(x => x.Book.Id == id).ToArrayAsync();

        return orders.Length < 1 ? null : orders;
    }
}