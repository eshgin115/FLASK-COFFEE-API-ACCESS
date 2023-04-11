using System.ComponentModel.DataAnnotations;

namespace APICOFFE.Admin.Dtos.PaymentBenefits;

public class PaymentBenefitsUpdateDto
{
    public IFormFile? Image { get; set; } = default!;
    [Required]
    public string Title { get; set; } = default!;
    [Required]
    public int Order { get; set; } = default!;
    [Required]
    public string Content { get; set; } = default!;
}
