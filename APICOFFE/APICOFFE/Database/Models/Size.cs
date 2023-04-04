using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class Size : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    //public List<FoodSize>? FoodSizes { get; set; }
    //public List<DrinkSize>? DrinkSizes { get; set; }
    //public List<BasketProduct>? BasketProducts { get; set; }
    //public List<OrderProduct>? OrderProducts { get; set; }
}