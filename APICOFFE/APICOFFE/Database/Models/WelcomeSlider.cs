using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database;

public class WelcomeSlider : BaseEntity<int>, IAuditable
{
    public string? Subheading { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Content { get; set; } = null!;
    public string ImageName { get; set; } = null!;
    public string ImageNameInFileSystem { get; set; } = null!;
    public string FirstHrefName { get; set; } = null!;
    public string FirstHrefURL { get; set; } = null!;
    public string SecondHrefName { get; set; } = null!;
    public string SecondHrefURL { get; set; } = null!;
    public int Order { get; set; }
    public string? ForPage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}