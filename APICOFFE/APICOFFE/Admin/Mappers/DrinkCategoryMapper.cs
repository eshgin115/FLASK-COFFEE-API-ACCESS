using APICOFFE.Admin.Dtos.DrinkCategory;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Admin.Mappers;

public class DrinkCategoryMapper : Profile
{
    public DrinkCategoryMapper()
    {
        CreateMap<DrinkCategory, DrinkCategoryListItemDto>();
        CreateMap<DrinkCategoryCreateDto, DrinkCategory>()
           .ForMember(d => d.Id, o => o.Ignore()).ReverseMap();
        CreateMap<DrinkCategoryUpdateDto, DrinkCategory>();
    }
}
