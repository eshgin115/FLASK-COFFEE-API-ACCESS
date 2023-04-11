using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.Subnavbar;

public class SubnavbarUpdateDto
{
    [Required]
    public string Name { get; set; } = default!;
    [Required]
    public string ToURL { get; set; } = default!;
    [Required]
    public int Order { get; set; }
    [Required]
    public int NavbarId { get; set; }
}
