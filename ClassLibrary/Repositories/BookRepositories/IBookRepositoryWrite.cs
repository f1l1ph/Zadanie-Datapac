using ClassLibrary.Entities;

namespace ClassLibrary.Repositories.BookRepositories;

public interface IBookRepositoryWrite
{
    Task<int> AddBook(BookEntity book);
    Task<int> UpdateBook(BookEntity book);
    Task<int> DeleteBook(int id);
}

