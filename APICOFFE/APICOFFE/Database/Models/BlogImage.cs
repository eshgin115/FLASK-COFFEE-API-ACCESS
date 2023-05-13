using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class BlogImage : BaseEntity<int>
{
    public string ImageName { get; set; } = default!;
    public string ImageNameInFileSystem { get; set; } = default!;
    public int BlogId { get; set; }
    public Blog Blog { get; set; } = default!;
}