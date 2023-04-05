using APICOFFE.Client.Dtos.DiscoverMenu;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Client.Mappers;

public class DiscoverMenuMapper:Profile
{
    public DiscoverMenuMapper()
    {
        CreateMap<DiscoverMenu, DiscoverMenuListItemDto>()
                           .ForMember(d => d.ImageURLs,
                           o => o.MapFrom(s => s.DiscoverMenuImages!.Select(dm => dm.ImageNameInFileSystem)!));
    }
}
