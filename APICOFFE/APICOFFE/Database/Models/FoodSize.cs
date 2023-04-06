using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class FoodSize : BaseEntity<int>
{
    public int FoodId { get; set; }
    public Food? Food { get; set; }

    public int SizeId { get; set; }
    public Size? Size { get; set; }
}
