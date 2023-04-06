using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class Tag : BaseEntity<int>, IAuditable
{
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<FoodTag>? FoodTags { get; set; }
    public List<DrinkTag>? DrinkTags { get; set; }
}