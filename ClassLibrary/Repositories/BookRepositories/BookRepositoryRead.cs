using ClassLibrary.Context;
using ClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories.BookRepositories;

public class BookRepositoryRead(LibraryContextRead contextRead) : IBookRepositoryRead
{
    public async Task<IEnumerable<BookEntity>> GetBooks()
    {
        return await contextRead.Books.ToArrayAsync();
    }

    public async Task<BookEntity?> GetBookById(int id)
    {
        return await contextRead.Books.FirstOrDefaultAsync(x => x.Id == id) ?? null;
    }

    public async Task<IEnumerable<BookEntity>> GetBooksByAuthor(string author)
    {
        return await contextRead.Books.Where(x => x.Author == author).ToArrayAsync();
    }
}

