using ClassLibrary.Context;
using ClassLibrary.Entities;
using ClassLibrary.Repositories.BookRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories.BorrowOrderRepositories;

public class BOrderRepositoryWrite(LibraryContextWrite contextWrite, IBookRepositoryRead bookRepository) : IBOrderRepositoryWrite
{//call for returning books
 //when returning book, set closed date to current date
    public async Task<int> AddOrder(BorrowOrderEntity order)
    {
        var book = await contextWrite.Books
            .FirstOrDefaultAsync(b => b.Id == order.BookId);

        if (book == null) return 0;

        book.BorrowOrders.Add(order);
        book.ActiveBorrowOrder = order;

        await contextWrite.SaveChangesAsync();
        return order.Id;
    }

    public async Task<int> UpdateOrder(BorrowOrderEntity order)
    {//check on this later
        //remake it into modifying isActive field
        var dbOrder = await contextWrite.Orders
            .FirstOrDefaultAsync(b => b.Id == order.Id);

        if (dbOrder == null) return 0;

        dbOrder.OpenDate = order.OpenDate;
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