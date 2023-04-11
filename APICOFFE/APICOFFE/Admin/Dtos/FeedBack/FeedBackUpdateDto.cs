using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.FeedBack;

public class FeedBackUpdateRequestDto
{
    public IFormFile? ProfilePhoto { get; set; } = null!;


    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Content { get; set; }

    [Required]
    public int RoleId { get; set; }
}
