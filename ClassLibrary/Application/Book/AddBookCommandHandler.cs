using ClassLibrary.Entities;
using ClassLibrary.Repositories;
using MediatR;

namespace ClassLibrary.Application.Book;

public class AddBookCommandHandler(IBookRepositoryWrite bookRepositoryWrite):IRequestHandler<AddBookCommand, int>
{
    public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = new BookEntity
        {
            Name = request.Name,
            Author = request.Author
        };
        return await bookRepositoryWrite.AddBook(book);
    }
}