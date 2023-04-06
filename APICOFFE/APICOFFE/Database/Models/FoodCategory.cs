using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class FoodCategory : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public List<Food>? Foods { get; set; }
}
