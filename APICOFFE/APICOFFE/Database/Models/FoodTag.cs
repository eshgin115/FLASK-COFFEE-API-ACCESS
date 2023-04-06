using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class FoodTag : BaseEntity<int>
{
    public int FoodId { get; set; }
    public Food? Food { get; set; }

    public int TagId { get; set; }
    public Tag? Tag { get; set; }
}
