namespace APICOFFE.Admin.Dtos.Order;

public class OrderListItemDto
{
    public string Identifikator { get; set; } = default!;
    public DateTime OrderDate { get; set; }
    public string CurrentStatus { get; set; } = default!;
    public int TotalPrice { get; set; }
}
