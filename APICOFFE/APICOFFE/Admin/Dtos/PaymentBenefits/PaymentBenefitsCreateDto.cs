namespace APICOFFE.Admin.Dtos.PaymentBenefits;

public class PaymentBenefitsCreateDto
{
    public IFormFile Image { get; set; } = default!;
    public string Title { get; set; } = default!;
    public int Order { get; set; } = default!;
    public string Content { get; set; } = default!;
}
