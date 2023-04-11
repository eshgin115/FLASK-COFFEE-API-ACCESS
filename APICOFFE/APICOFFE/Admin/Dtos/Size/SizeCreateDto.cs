using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.Size;

public class SizeCreateDto
{
    [Required]
    public string Name { get; set; } = default!;
}
