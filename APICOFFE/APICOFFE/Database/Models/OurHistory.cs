using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class OurHistory : BaseEntity<int>, IAuditable
{
    public string Subheading { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string? ImageName { get; set; } = null!;
    public string? ImageNameInFileSystem { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}