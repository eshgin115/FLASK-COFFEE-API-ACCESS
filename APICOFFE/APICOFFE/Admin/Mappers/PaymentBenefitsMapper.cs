using APICOFFE.Admin.Dtos.PaymentBenefits;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Admin.Mappers;

public class PaymentBenefitsMapper : Profile
{
    public PaymentBenefitsMapper()
    {
        CreateMap<PaymentBenefits, PaymentBenefitsListItemDto>()
            .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.ImageNameInFileSystem));

        CreateMap<PaymentBenefitsCreateDto, PaymentBenefits>()
            .ForMember(d => d.Id, o => o.Ignore())
           .ForMember(d => d.ImageName, o => o.MapFrom(s => s.Image != null ? s.Image.FileName : null))
            .ForMember(d => d.Id, o => o.Ignore());

        CreateMap<PaymentBenefitsUpdateDto, PaymentBenefits>()
          .ForMember(d => d.ImageName, o => o.MapFrom((s, d) => s.Image != null
          ? s.Image.FileName :
          d.ImageName))
          .ForMember(d => d.ImageNameInFileSystem, o => o.Ignore())
            .ForMember(d => d.Id, o => o.Ignore());
    }
}
