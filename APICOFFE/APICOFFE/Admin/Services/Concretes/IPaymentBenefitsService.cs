using APICOFFE.Admin.Dtos.PaymentBenefits;

namespace APICOFFE.Admin.Services.Concretes;

public interface IPaymentBenefitsService
{
    Task<PaymentBenefitsListItemDto> AddAsync(PaymentBenefitsCreateDto dto);
    Task<PaymentBenefitsListItemDto> UpdateAsync(int id, PaymentBenefitsUpdateDto dto);
    Task<List<PaymentBenefitsListItemDto>> ListAsync();
    Task DeleteAsync(int id);
}
