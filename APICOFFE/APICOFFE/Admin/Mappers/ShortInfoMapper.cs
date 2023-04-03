using APICOFFE.Admin.Dtos.ShortInfo;
using APICOFFE.Admin.Dtos.Subnavbar;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Admin.Mappers;
public class ShortInfoMapper : Profile
{
    public ShortInfoMapper()
    {
        CreateMap<ShortInfo, ShortInfoListItemDto>();
        CreateMap<ShortInfoUpdateDto, ShortInfo>()
              .ForMember(d => d.Id, o => o.Ignore());
    }
}