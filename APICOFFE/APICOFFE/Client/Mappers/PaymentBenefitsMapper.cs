using APICOFFE.Client.Dtos.PaymentBenefits;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Client.Mappers;

public class PaymentBenefitsMapper : Profile
{
    public PaymentBenefitsMapper()
    {
        CreateMap<PaymentBenefits, PaymentBenefitsListItemDto>()
           .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.ImageNameInFileSystem));
    }
}
