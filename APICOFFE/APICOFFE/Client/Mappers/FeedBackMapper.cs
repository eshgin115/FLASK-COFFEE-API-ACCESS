using APICOFFE.Client.Dtos.FeedBack;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Client.Mappers;

public class FeedBackMapper :Profile
{
    public FeedBackMapper()
    {
        CreateMap<FeedBack, FeedBackListItemDto>()
                           .ForMember(d => d.RoleName, o => o.MapFrom(s => s.Role!.Name))
                           .ForMember(d => d.FullName, o => o.MapFrom(s => s.Name))
                           .ForMember(d => d.ProfilePhotoUrl, o => o.MapFrom(s => s.ImageNameInFileSystem));
    }
}
