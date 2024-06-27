using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Entities;

public class BorrowOrderEntity 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public bool IsActive { get; set; } = true;// check whether we can borrow the book or not

    public DateTime OpenDate { get; set; }
    public DateTime CloseDate { get; set; }

    public int BookId { get; set; }
    public BookEntity Book { get; set; } = null!;

}