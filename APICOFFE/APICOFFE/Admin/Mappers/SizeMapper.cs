using APICOFFE.Admin.Dtos.Size;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Admin.Mappers;

public class SizeMapper :Profile
{
    public SizeMapper()
    {
        CreateMap<Size, SizeListItemDto>();
        CreateMap<SizeCreateDto, Size>()
           .ForMember(d => d.Id, o => o.Ignore()).ReverseMap();
        CreateMap<SizeUpdateDto, Size>();
    }
}
