namespace APICOFFE.Admin.Dtos.PaymentBenefits;

public class PaymentBenefitsListItemDto
{
    public int Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public int Order { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string ImageURL { get; set; } = default!;
}
