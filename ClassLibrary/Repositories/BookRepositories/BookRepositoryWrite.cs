using ClassLibrary.Context;
using ClassLibrary.Entities;
using ClassLibrary.Validation;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories.BookRepositories;

public class BookRepositoryWrite(LibraryContextWrite contextWrite) : IBookRepositoryWrite
{
    public async Task<int> AddBook(BookEntity book)
    {
        var validator = new BookValidator();
        var result = await validator.ValidateAsync(book);
        if (!result.IsValid) { return -2;}

        contextWrite.Books.Add(book);
        await contextWrite.SaveChangesAsync();
        return book.Id;
    }

    public async Task<int> UpdateBook(BookEntity book)
    {
        var validator = new BookValidator();
        var result = await validator.ValidateAsync(book);
        if(!result.IsValid) { return -2; }

        var dbBook = await contextWrite.Books
            .FirstOrDefaultAsync(b => b.Id == book.Id);

        if (dbBook == null) return 0;

        dbBook.Name = book.Name;
        dbBook.Author = book.Author;

        await contextWrite.SaveChangesAsync();
        return book.Id;
    }

    public async Task<int> DeleteBook(int id)
    {
        var dbBook = await contextWrite.Books
            .FirstOrDefaultAsync(b => b.Id == id);

        if (dbBook == null) return 0;

        contextWrite.Books.Remove(dbBook);
        await contextWrite.SaveChangesAsync();

        return 1;
    }
}
