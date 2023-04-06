using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class FoodImage : BaseEntity<int>, IAuditable
{
    public string ImageName { get; set; } = null!;
    public string ImageNameInFileSystem { get; set; } = null!;

    public bool IsMain { get; set; }

    public int FoodId { get; set; }
    public Food? Food { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
