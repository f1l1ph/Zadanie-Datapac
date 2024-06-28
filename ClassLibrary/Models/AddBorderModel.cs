namespace ClassLibrary.Models;

public class AddBOrderModel
{
    public string User {get; set; }
    public DateTime OpenDate { get; set; }
    public DateTime CloseDate { get; set; }
    public int BookId { get; set; }
}
