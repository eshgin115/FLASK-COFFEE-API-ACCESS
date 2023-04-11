using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.FeedBack;

public class FeedBackCreateDto
{
    public IFormFile ProfilePhoto { get; set; } = default!;

    [Required]
    public string Name { get; set; } = default!;

    [Required]
    public string Content { get; set; } = default!;

    [Required]

    public int RoleId { get; set; }
}
