namespace APICOFFE.Admin.Dtos.OurHistory;

public class OurHistoryListItemDto
{
    public string Subheading { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string? ImageURL { get; set; }
}
