using APICOFFE.Contracts.Order;
using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class Order : BaseEntity<string>
{
    public int UserId { get; set; }
    public User? User { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<OrderProduct>? OrderProducts { get; set; }
    public Status Status { get; set; }

    public decimal SumTotalPrice { get; set; }
}
