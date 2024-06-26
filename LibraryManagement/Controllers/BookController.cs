using System.ComponentModel;
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

    [HttpGet($"GetBookById{{id:int}}")]
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
        return Ok(await mediator.Send(command));
    }

    [HttpPut("UpdateBook")]
    public async Task<IActionResult> UpdateBook(UpdateBookCommand command)
    {
        var book = await mediator.Send(command);
        if (book == 0) { return NotFound("Book was not found, sorry :("); }
        return Ok(book);
    }

    [HttpDelete($"DeleteBook{{id:int}}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        
        var book = await mediator.Send(new DeleteBookCommand(id));
        if (book == 0) { return NotFound("Book was not found, sorry :("); }
        return Ok(book);
    }
}
