namespace APICOFFE.Admin.Dtos.WelcomeSlider;

public class WelcomeSliderListItemDto
{
    public int Id { get; set; }
    public string Subheading { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string FirstHrefName { get; set; } = null!;
    public string FirstHrefURL { get; set; } = null!;
    public string SecondHrefName { get; set; } = null!;
    public string SecondHrefURL { get; set; } = null!;
    public int Order { get; set; }
    public string ImageURL { get; set; } = null!;
    public string? Page { get; set; }
}
