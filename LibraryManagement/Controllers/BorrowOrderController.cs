using ClassLibrary.Application.BorrowOrder;
using ClassLibrary.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class BorrowOrderController(IMediator mediator) : Controller
{
    [HttpGet("GetBorrowOrders")]
    public async Task<IEnumerable<BorrowOrderEntity>> GetBooks()
    {
        return await mediator.Send(new GetBOrdersQuery());
    }

    [HttpGet($"GetBorrowOrder/{{id:int}}")]
    public async Task<IActionResult> GetBook(int id)
    {
       var order = await mediator.Send(new GetBOrderByIdQuery(id));
        
       if (order == null) { return NotFound("Sorry order was not found :("); }

       return Ok(order);
    }

    [HttpGet($"GetBorrowOrderByBookId/{{id:int}}")]
    public async Task<IActionResult> GetBorrowOrderByBookId(int id)
    {
        var order = await mediator.Send(new GetBOrderByBookIdQuery(id));

        if(order == null){ return NotFound("Sorry order or book was not found :("); }

        var orderArray = order.ToArray();

        foreach (var _order in orderArray)
        {
            _order.Book = null;
        }
        return Ok(order);
    }

    [HttpPost("AddBorrowOrder")]
    public async Task<IActionResult> AddBook(AddBOrderCommand command)
    {
        //check if book has active borrow order, if so, check if active borrow order exists and isn't expired and check if has been returned

        var order = await mediator.Send(command);
        if (order == 0) { return NotFound("Book not found"); }

        if (order == -1) { return NotFound("Book is not available"); }

        return Ok(order);
    }

    [HttpPut("UpdateBorrowOrder")]
    public async Task<IActionResult> UpdateBook()
    {
        return NotFound("Sorry but due to security reasons you are unable to Modify Borrow orders");
    }

    [HttpDelete($"RemoveOrder{{id:int}}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var order = await mediator.Send(new DeleteBOrderCommand(id));
        if (order == 0) { return NotFound("Order was not found, sorry :("); }
        return Ok(order);
    }
}