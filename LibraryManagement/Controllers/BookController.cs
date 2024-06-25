using ClassLibrary.Application.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController(IMediator mediator) : ControllerBase
{
    /*[HttpGet(Name = "GetBooks")]
    public async Task<IEnumerable<BookEntity>> GetBooks()
    {
        return await mediator.Send(new GetAllBooksQuery());
    }*/

    [HttpPost(Name = "AddBook")]
    public async Task<IActionResult> AddBook(AddBookCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}
