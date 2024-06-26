using ClassLibrary.Entities;
using ClassLibrary.Repositories.BookRepositories;
using MediatR;

namespace ClassLibrary.Application.Book;

public class UpdateBookCommandHandler(IBookRepositoryWrite bookRepositoryWrite): IRequestHandler<UpdateBookCommand, int>
{
    public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new BookEntity
        {
            Id = request.Id,
            Name = request.Name,
            Author = request.Author
        };
        return await bookRepositoryWrite.UpdateBook(book);
    }
}

