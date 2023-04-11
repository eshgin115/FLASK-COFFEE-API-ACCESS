using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.PaymentBenefits;

public class PaymentBenefitsCreateDto
{
    [Required]
    public IFormFile Image { get; set; } = default!;
    [Required]
    public string Title { get; set; } = default!;
    [Required]
    public int Order { get; set; } = default!;
    [Required]
    public string Content { get; set; } = default!;
}
