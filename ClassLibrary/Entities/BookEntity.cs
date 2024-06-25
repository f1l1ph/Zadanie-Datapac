using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Entities;

public class BookEntity 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Author { get; set; }
    //and many other useless fields...
}

