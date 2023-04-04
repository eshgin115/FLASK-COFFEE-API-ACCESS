namespace APICOFFE.Admin.Dtos.OurHistory;

public class OurHistoryUpdateDto
{

    public string Subheading { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public IFormFile? Image { get; set; }
}
