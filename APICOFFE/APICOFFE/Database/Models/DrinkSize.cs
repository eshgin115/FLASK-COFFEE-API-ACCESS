using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class DrinkSize : BaseEntity<int>
{
    public int DrinkId { get; set; }
    public Drink? Drink { get; set; }

    public int SizeId { get; set; }
    public Size? Size { get; set; }
}