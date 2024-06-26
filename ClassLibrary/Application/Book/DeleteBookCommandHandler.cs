using ClassLibrary.Entities;
using ClassLibrary.Repositories.BookRepositories;
using MediatR;

namespace ClassLibrary.Application.Book;

public class DeleteBookCommandHandler(IBookRepositoryWrite bookRepositoryWrite) :IRequestHandler<DeleteBookCommand, int>
{
    public async Task<int> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        return await bookRepositoryWrite.DeleteBook(request.Id);
    }
}

