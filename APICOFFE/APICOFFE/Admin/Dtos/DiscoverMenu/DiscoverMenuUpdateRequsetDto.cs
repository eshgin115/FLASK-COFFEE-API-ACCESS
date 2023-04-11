using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.DiscoverMenu;

public class DiscoverMenuUpdateRequsetDto
{
    [Required]
    public string Title { get; set; } = default!;

    [Required]
    public string Content { get; set; } = default!;

    [Required]
    public string FirstHrefName { get; set; } = default!;

    [Required]
    public string FirstHrefURL { get; set; } = default!;
    public List<IFormFile>? Images { get; set; }
}
