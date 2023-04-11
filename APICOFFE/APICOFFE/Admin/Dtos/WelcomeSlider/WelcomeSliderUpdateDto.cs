using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.WelcomeSlider;

public class WelcomeSliderUpdateDto
{
    [Required]
    public string Subheading { get; set; } = null!;
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Content { get; set; } = null!;
    [Required]
    public string FirstHrefName { get; set; } = null!;
    [Required]
    public string FirstHrefURL { get; set; } = null!;
    [Required]
    public string SecondHrefName { get; set; } = null!;
    [Required]
    public string SecondHrefURL { get; set; } = null!;
    public IFormFile? Image { get; set; }
    [Required]
    public int Order { get; set; }
    [Required]
    public string Page { get; set; }

}
