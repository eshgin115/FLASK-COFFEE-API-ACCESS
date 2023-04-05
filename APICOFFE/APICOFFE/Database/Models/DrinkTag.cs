using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class DrinkTag : BaseEntity<int>
{
    public int DrinkId { get; set; }
    public Drink? Drink { get; set; }

    public int TagId { get; set; }
    public Tag? Tag { get; set; }
}