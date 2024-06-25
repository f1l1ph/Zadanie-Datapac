using ClassLibrary.Context;
using ClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repositories;

    public class BookRepositoryWrite(LibraryContextWrite contextWrite) : IBookRepositoryWrite
    {
        public async Task<int> AddBook(BookEntity book)
        {
            contextWrite.Books.Add(book);
            await contextWrite.SaveChangesAsync();
            return book.Id;
        }

        public async Task<int> UpdateBook(BookEntity book)
        {
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

            if(dbBook == null) return 0;

            await contextWrite.SaveChangesAsync();
            return id;
        }
    }
