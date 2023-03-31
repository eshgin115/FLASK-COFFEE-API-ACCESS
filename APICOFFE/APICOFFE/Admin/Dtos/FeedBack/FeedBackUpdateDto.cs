namespace APICOFFE.Admin.Dtos.FeedBack;

public class FeedBackUpdateRequestDto
{
    public IFormFile? ProfilePhoto { get; set; } = null!;

    public string? Name { get; set; }

    public string? Content { get; set; }

    public int RoleId { get; set; }
}
