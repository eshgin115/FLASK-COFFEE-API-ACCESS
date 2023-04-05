using APICOFFE.Client.Dtos.Auth;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Client.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<RegisterDto, User>();

            CreateMap<LoginDto, User>();

            CreateMap<User, Basket>()
                   .ForMember(d => d.User, opt => opt.MapFrom(s => s));
        }
    }
}
