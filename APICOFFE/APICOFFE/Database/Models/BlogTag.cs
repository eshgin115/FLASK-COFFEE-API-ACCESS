using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class BlogTag : BaseEntity<int>
{
    public int BlogId { get; set; }
    public Blog Blog { get; set; } = default!;
    public int TagId { get; set; }
    public Tag Tag { get; set; } = default!;
}