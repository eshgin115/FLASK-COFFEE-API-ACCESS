using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class OrderProduct : BaseEntity<int>, IAuditable
{
    public string OrderId { get; set; }
    public Order? Order { get; set; }
    public decimal Price { get; set; }
    public int? FoodId { get; set; }
    public Food? Food { get; set; }
    public int? DrinkId { get; set; }
    public Drink? Drink { get; set; }
    public decimal? QuantityFood { get; set; }
    public decimal? QuantityDrink { get; set; }
    public int? SizeId { get; set; }
    public Size? Size { get; set; }


    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
