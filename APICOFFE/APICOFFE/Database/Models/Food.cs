using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class Food : BaseEntity<int>, IAuditable
{
    public bool IsVegan { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public decimal Price { get; set; }
    public string Ingredients { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<FoodTag>? FoodTags { get; set; }
    public List<FoodSize>? FoodSizes { get; set; }
    public List<FoodImage>? FoodImages { get; set; }
    public List<BasketProduct>? BasketProducts { get; set; }
    public List<OrderProduct>? OrderProducts { get; set; }
    public int FoodCategoryId { get; set; }
    public FoodCategory? FoodCategory { get; set; }
}
