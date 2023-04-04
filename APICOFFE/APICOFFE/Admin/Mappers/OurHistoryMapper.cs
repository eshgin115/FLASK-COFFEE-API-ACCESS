using APICOFFE.Admin.Dtos.OurHistory;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Admin.Mappers;

public class OurHistoryMapper : Profile
{

    public OurHistoryMapper()
    {
        CreateMap<OurHistory, OurHistoryListItemDto>()
              .ForMember(d => d.ImageURL, o => o.MapFrom(s => s.ImageNameInFileSystem));


        CreateMap<OurHistoryUpdateDto, OurHistory>()
             .ForMember(d => d.ImageName, o => o.MapFrom((s, d) => s.Image != null
             ? s.Image.FileName :
             d.ImageName))
              .ForMember(d => d.Id, o => o.Ignore());
    }
}