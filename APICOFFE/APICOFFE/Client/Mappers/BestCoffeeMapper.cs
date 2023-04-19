using APICOFFE.Client.Dtos.BestCoffee;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Client.Mappers;

public class BestCoffeeMapper : Profile
{
    public BestCoffeeMapper()
    {
        CreateMap<Drink, BestCoffeeListItemDto>()
                           .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.ImageNameInFileSystem));
    }
}
