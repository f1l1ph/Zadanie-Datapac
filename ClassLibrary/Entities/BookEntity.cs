using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Entities;

public class BookEntity 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Author { get; set; }

    public BorrowOrderEntity? ActiveBorrowOrder { get; set; }//if ActiveBorrowOrder == null, book is available

    public ICollection<BorrowOrderEntity> BorrowOrders { get; set; } = new List<BorrowOrderEntity>();
}