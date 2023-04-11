using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.OurHistory;

public class OurHistoryUpdateDto
{
    [Required]
    public string Subheading { get; set; } = null!;
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Content { get; set; } = null!;
    public IFormFile? Image { get; set; }
}
