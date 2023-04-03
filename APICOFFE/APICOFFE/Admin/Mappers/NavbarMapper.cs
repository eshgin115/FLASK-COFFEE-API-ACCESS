using APICOFFE.Admin.Dtos.FeedBack;
using APICOFFE.Admin.Dtos.Navbar;
using APICOFFE.Database.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace APICOFFE.Admin.Mappers
{
    public class NavbarMapper : Profile
    {
        public NavbarMapper()
        {
            CreateMap<Navbar, NavbarListItemDto>()
                 .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));
            CreateMap<NavbarCreateDto, Navbar>()
              .ForMember(d => d.Id, opt => opt.Ignore());
            CreateMap<Navbar, NavbarUpdateDto>();
            CreateMap<NavbarUpdateDto, Navbar>()
                 .ForMember(d => d.Id, opt => opt.Ignore());




          



        }
    }
}
