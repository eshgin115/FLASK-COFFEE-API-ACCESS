using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class BlogCategory : BaseEntity<int>, IAuditable
{
    public string Title { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<Blog>? Blogs { get; set; }
}