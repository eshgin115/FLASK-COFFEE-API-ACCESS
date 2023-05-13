using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;

public class Blog : BaseEntity<int>, IAuditable
{
    public string ThumbNailImgName { get; set; } = default!;
    public string ThumbNailImgNameInFileSystem { get; set; }=default!;
    public int UserId { get; set; }
    public User? User { get; set; }

    public int BlogCategoryId { get; set; }
    public BlogCategory? BlogCategory { get; set; }
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public List<BlogTag>? BlogTags { get; set; }
    public List<BlogImage>? BlogImages { get; set; }
    public List<BlogVideo>? BlogVideos { get; set; }
    //public List<Comment>? Comments { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
