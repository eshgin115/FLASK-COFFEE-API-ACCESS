using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class BlogVideo : BaseEntity<int>
{
    public string? VideoName { get; set; }
    public string? VideoNameInFileSystem { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; } = default!;

    public string? VideoUrl { get; set; }
}