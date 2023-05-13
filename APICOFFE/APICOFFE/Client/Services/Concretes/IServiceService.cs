using APICOFFE.Client.Dtos.PaymentBenefits;

namespace APICOFFE.Client.Services.Concretes;

public interface IServiceService
{
    Task<List<PaymentBenefitsListItemDto>> PaymentBenefitsListAsync();
}
