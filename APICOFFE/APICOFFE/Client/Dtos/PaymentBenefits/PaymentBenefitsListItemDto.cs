﻿namespace APICOFFE.Client.Dtos.PaymentBenefits;

public class PaymentBenefitsListItemDto
{
    public string Title { get; set; } = default!;
    public int Order { get; set; } = default!;
    public string Content { get; set; } = default!;
    public string ImageURL { get; set; } = default!;
}
