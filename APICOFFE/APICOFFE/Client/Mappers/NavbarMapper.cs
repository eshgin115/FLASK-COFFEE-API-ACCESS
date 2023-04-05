using APICOFFE.Client.Dtos.Navbar;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Client.Mappers;

public class NavbarMapper : Profile
{
    public NavbarMapper()
    {

        CreateMap<Navbar, NavbarListItemDto>()
           .ForMember(d => d.SubnavbarItems, o => o.MapFrom(s => s.Subnavbars))
           .ForMember(d => d.URL, o => o.MapFrom(s => s.ToURL));
        CreateMap<Subnavbar, NavbarListItemDto.SubnavbarListItemDto>();
    }
}
