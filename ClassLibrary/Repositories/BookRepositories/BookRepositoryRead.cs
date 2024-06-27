using ClassLibrary.Context;
using ClassLibrary.Entities;
using ClassLibrary.Repositories.BorrowOrderRepositories;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories.BookRepositories;

public class BookRepositoryRead(LibraryContextRead contextRead) : IBookRepositoryRead
{
    public async Task<IEnumerable<BookEntity>> GetBooks()
    {
        var books = await contextRead.Books.ToArrayAsync();
        foreach (var book in books)
        {
            var orders = await contextRead.Orders.Where(x => x.Book.Id == book.Id).ToArrayAsync();
            foreach (var order in orders)
            {
                order.Book = null;
            }

            book.BorrowOrders = orders;
        }
        return books;
    }

    public async Task<BookEntity?> GetBookById(int id)
    {
        var book = await contextRead.Books.FirstOrDefaultAsync(x => x.Id == id) ?? null;
        if(book == null) return null;

        var orders = await contextRead.Orders.Where(x => x.Book.Id == book.Id).ToArrayAsync();
        foreach (var order in orders)
        {
            order.Book = null;
        }

        book.BorrowOrders = orders;

        return book;
    }

    public async Task<IEnumerable<BookEntity>> GetBooksByAuthor(string author)
    {
        return await contextRead.Books.Where(x => x.Author == author).ToArrayAsync();
    }
}

