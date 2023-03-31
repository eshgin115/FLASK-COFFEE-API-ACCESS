namespace APICOFFE.Admin.Dtos.DiscoverMenu;

public class DiscoverMenuUpdateRequsetDto
{
    public string Title { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string FirstHrefName { get; set; } = default!;
    public string FirstHrefURL { get; set; } = default!;
    public List<IFormFile>? Images { get; set; }
}
