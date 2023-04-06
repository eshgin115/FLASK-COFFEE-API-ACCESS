using APICOFFE.Admin.Dtos.Drink;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Admin.Mappers;

public class DrinkMapper : Profile
{
    public DrinkMapper()
    {

        CreateMap<Drink, DrinkListItemDto>()
             .ForMember(d => d.DrinkTags, opt => opt.MapFrom(src => src.DrinkTags))
             .ForMember(d => d.ImageURL, opt => opt.MapFrom(src => src.ImageNameInFileSystem))
             .ForMember(d => d.DrinkSizes, opt => opt.MapFrom(src => src.DrinkSizes))
             .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.DrinkCategory.Name));
        CreateMap<DrinkTag, DrinkListItemDto.ItemDto>()
                       .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Tag.Name))
                       .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Tag.Id));
        CreateMap<DrinkSize, DrinkListItemDto.ItemDto>()
                    .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Size.Name))
                    .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Size.Id));

        CreateMap<DrinkCreateDto, Drink>()
             .ForMember(d => d.DrinkCategoryId, opt => opt.MapFrom(src => src.DrinkCategoryId))
             .ForMember(d => d.ImageName, o => o.MapFrom(s => s.Image != null ? s.Image.FileName : null));
        CreateMap<(int model, Drink drink), DrinkSize>()
             .ForMember(d => d.SizeId, opt => opt.MapFrom(src => src.model))
             .ForMember(d => d.Drink, opt => opt.MapFrom(src => src.drink));
        CreateMap<(int model, Drink drink), DrinkTag>()
             .ForMember(d => d.TagId, opt => opt.MapFrom(src => src.model))
             .ForMember(d => d.Drink, opt => opt.MapFrom(src => src.drink));

        CreateMap<DrinkUpdateDto, Drink>()
             .ForMember(d => d.DrinkCategoryId, opt => opt.MapFrom(src => src.DrinkCategoryId))
             .ForMember(d => d.Id, opt => opt.Ignore())
             .ForMember(d => d.ImageName, o => o.MapFrom((s, d) => s.Image != null
             ? s.Image.FileName
             :d.ImageName));
    }
}
