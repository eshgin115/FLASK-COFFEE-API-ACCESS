namespace APICOFFE.Admin.Dtos.FeedBack;

public class FeedBackListItemDto
{

    public int Id { get; set; }
    public string ProfilePhotoUrl { get; set; } = default!;
    public string FullName { get; set; } = default!;
    public string RoleName { get; set; } = default!;
    public string Content { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}