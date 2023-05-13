using APICOFFE.Client.Dtos.FoodMenu;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Client.Mappers;

public class MenuMapper : Profile
{
    public MenuMapper()
    {
        CreateMap<FoodCategory, FoodCategoryListItemDto>()
                          .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                          .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                          .ForMember(d => d.Foods, o => o.MapFrom(s => s.Foods));


        CreateMap<Food, FoodCategoryListItemDto.FoodListItemDto>()
                      .ForMember(d => d.Price, o => o.MapFrom(s => s.Price))
                      .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                      .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.FoodImages.FirstOrDefault()!.ImageNameInFileSystem))
                      .ForMember(d => d.Content, o => o.MapFrom(s => s.Content))
                      .ForMember(d => d.Title, o => o.MapFrom(s => s.Title));
    }
}
