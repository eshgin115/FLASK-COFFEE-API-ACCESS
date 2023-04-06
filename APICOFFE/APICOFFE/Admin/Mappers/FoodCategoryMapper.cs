using APICOFFE.Admin.Dtos.FoodCategory;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Admin.Mappers;

public class FoodCategoryMapper:Profile
{
    public FoodCategoryMapper()
    {
        CreateMap<FoodCategory, FoodCategoryListItemDto>()
                 .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
        CreateMap<FoodCategoryCreateDto, FoodCategory>()
          .ForMember(d => d.Id, opt => opt.Ignore());
        CreateMap<FoodCategoryUpdateDto, FoodCategory>()
             .ForMember(d => d.Id, opt => opt.Ignore());
    }
}
