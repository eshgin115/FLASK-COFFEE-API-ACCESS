using APICOFFE.Admin.Dtos.WelcomeSlider;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Admin.Mappers;

public class WelcomeSliderMapper : Profile
{
    public WelcomeSliderMapper()
    {
        CreateMap<WelcomeSlider, WelcomeSliderListItemDto>()
             .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.ImageNameInFileSystem!));
        CreateMap<WelcomeSliderCreateDto, WelcomeSlider>()
           .ForMember(d => d.ImageName, o => o.MapFrom(s => s.Image != null ? s.Image.FileName : null))
           .ForMember(d => d.ForPage, o => o.MapFrom(s => s.Page))
           ;

        CreateMap<WelcomeSliderUpdateDto, WelcomeSlider>()
        .ForMember(d => d.ImageName, o => o.MapFrom((s, d) => s.Image != null
        ? s.Image.FileName :
        d.ImageName))
           .ForMember(d => d.ForPage, o => o.MapFrom(s => s.Page))

        .ForMember(d => d.ImageNameInFileSystem, o => o.Ignore())
          .ForMember(d => d.Id, o => o.Ignore());





    }
}
