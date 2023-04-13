using APICOFFE.Client.Dtos.OurProduct;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Client.Mappers;

public class OurProductMapper : Profile
{
    public OurProductMapper()
    {
        CreateMap<Food, OurProductListItemDto>()
                          .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.FoodImages.FirstOrDefault().ImageNameInFileSystem));
        CreateMap<Drink, OurProductListItemDto>()
           .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.ImageNameInFileSystem));
    }
}
