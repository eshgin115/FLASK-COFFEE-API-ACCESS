using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class Drink : BaseEntity<int>, IAuditable
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public decimal Price { get; set; }
    public string ImageName { get; set; } = null!;
    public string ImageNameInFileSystem { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<DrinkTag>? DrinkTags { get; set; }
    public List<DrinkSize>? DrinkSizes { get; set; }
    public List<BasketProduct>? BasketProducts { get; set; }
    public List<OrderProduct>? OrderProducts { get; set; }
    public int DrinkCategoryId { get; set; }
    public DrinkCategory DrinkCategory { get; set; }
}
