using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class DrinkCategory : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public List<Drink>? Drinks { get; set; }
}