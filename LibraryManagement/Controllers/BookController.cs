using ClassLibrary.Application.Book;
using ClassLibrary.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController(IMediator mediator) : Controller
{
    [HttpGet("GetBooks")]
    public async Task<IEnumerable<BookEntity>> GetBooks()
    {
        return await mediator.Send(new GetBooksQuery());
    }

    [HttpGet($"GetBookById/{{id:int}}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await mediator.Send(new GetBookByIdQuery(id));
        if (book is { Name: "", Author: "" })
        {
            return NotFound("Book not found");
        }
        return Ok(book);
    }

    [HttpPost("AddBook")]
    public async Task<IActionResult> AddBook(AddBookCommand command)
    {
        var book = await mediator.Send(command);

        if (book == -2) { return NotFound("Sorry, wrong input");}
        return Ok(book);
    }

    [HttpPut("UpdateBook")]
    public async Task<IActionResult> UpdateBook(UpdateBookCommand command)
    {
        var book = await mediator.Send(command);
        return book switch
        {
            0 => NotFound("Book was not found, sorry :("),
            -2 => NotFound("Sorry, wrong input"),
            _ => Ok(book)
        };
    }

    [HttpDelete($"DeleteBook{{id:int}}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await mediator.Send(new DeleteBookCommand(id));
        if (book == 0) { return NotFound("Book was not found, sorry :("); }
        return Ok(book);
    }
}
