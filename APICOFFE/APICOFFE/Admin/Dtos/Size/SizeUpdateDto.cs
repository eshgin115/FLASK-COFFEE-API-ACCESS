using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.Size;

public class SizeUpdateDto
{
    [Required]
    public string Name { get; set; } = null!;
}
