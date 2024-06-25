using ClassLibrary.Entities;

namespace ClassLibrary.Repositories;

public interface IBookRepositoryRead
{
    Task<IEnumerable<BookEntity>> GetBooks();
    Task<BookEntity?> GetBookById(int id);
    Task<IEnumerable<BookEntity>> GetBooksByAuthor(string author);
}

