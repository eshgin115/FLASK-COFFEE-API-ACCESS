namespace APICOFFE.Client.Dtos.DiscoverMenu;

public class DiscoverMenuListItemDto
{
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string FirstHrefName { get; set; } = default!;
    public string FirstHrefURL { get; set; } = default!;
    public List<string> ImageURLs { get; set; } = default!;
}
