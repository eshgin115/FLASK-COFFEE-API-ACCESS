using APICOFFE.Admin.Dtos.DiscoverMenu;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Admin.Mappers
{
    public class DiscoverMenuMapper : Profile
    {
        public DiscoverMenuMapper()
        {

            CreateMap<DiscoverMenu, DiscoverMenuUpdateResponseDto>()
               .ForMember(d => d.ImageURL, opt => opt.MapFrom(src => src.DiscoverMenuImages!
             .Take(1).FirstOrDefault()!.ImageNameInFileSystem));


            CreateMap<DiscoverMenuUpdateRequsetDto, DiscoverMenu>()
                  .ForMember(d => d.Id, o => o.Ignore());


            CreateMap<(IFormFile DiscoverMenuImage, DiscoverMenu discoverMenu, string imageNameInSystem), DiscoverMenuImage>()
                         .ForMember(d => d.ImageName, opt => opt.MapFrom(src => src.DiscoverMenuImage.FileName))
                         .ForMember(d => d.ImageNameInFileSystem, opt => opt.MapFrom(src => src.imageNameInSystem))
                         .ForMember(d => d.DiscoverMenu, opt => opt.MapFrom(src => src.discoverMenu));
        }
    }
}
