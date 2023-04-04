namespace APICOFFE.Admin.Dtos.WelcomeSlider;

public class WelcomeSliderUpdateDto
{
    public string Subheading { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string FirstHrefName { get; set; } = null!;
    public string FirstHrefURL { get; set; } = null!;
    public string SecondHrefName { get; set; } = null!;
    public string SecondHrefURL { get; set; } = null!;
    public IFormFile? Image { get; set; }
    public int Order { get; set; }
    public string Page { get; set; }

}
