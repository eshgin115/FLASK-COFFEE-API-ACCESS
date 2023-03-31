namespace APICOFFE.Admin.Dtos.DiscoverMenu;

public class DiscoverMenuUpdateResponseDto
{
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string FirstHrefName { get; set; } = default!;
    public string FirstHrefURL { get; set; } = default!;
    public string? ImageURL { get; set; }
}
