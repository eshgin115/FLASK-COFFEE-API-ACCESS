using APICOFFE.Admin.Dtos.Food;
using APICOFFE.Client.Dtos.MenuProduct;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Client.Mappers;

public class MenuProductMapper:Profile
{
    public MenuProductMapper()
    {
        CreateMap<FoodCategory, MenuProductListItemDto>()
                         .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                         .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                         .ForMember(d => d.Foods, o => o.MapFrom(s => s.Foods));

        CreateMap<Food, FoodListItemDto>()
                 .ForMember(d => d.FoodTags, opt => opt.MapFrom(src => src.FoodTags))
                 .ForMember(d => d.ImageURL, opt => opt.MapFrom(src => src.FoodImages!
                 .Take(1).FirstOrDefault()!.ImageNameInFileSystem))
                 .ForMember(d => d.FoodSizes, opt => opt.MapFrom(src => src.FoodSizes))
                 .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.FoodCategory.Name));
        CreateMap<FoodTag, FoodListItemDto.ItemDto>()
                    .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Tag.Name))
                    .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Tag.Id));
        CreateMap<FoodSize, FoodListItemDto.ItemDto>()
                    .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Size.Name))
                    .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Size.Id)); ;

    }
}
