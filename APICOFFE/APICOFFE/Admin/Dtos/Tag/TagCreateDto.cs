using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.Tag;

public class TagCreateDto
{
    [Required]
    public string Name { get; set; } = default!;
}
