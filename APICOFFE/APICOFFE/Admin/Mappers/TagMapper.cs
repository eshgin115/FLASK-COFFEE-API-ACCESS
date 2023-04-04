using APICOFFE.Admin.Dtos.Tag;
using APICOFFE.Database.Models;
using AutoMapper;

namespace APICOFFE.Admin.Mappers;

public class TagMapper : Profile
{
    public TagMapper()
    {
        CreateMap<Tag, TagListItemDto>();
        CreateMap<TagCreateDto, Tag>()
           .ForMember(d => d.Id, o => o.Ignore()).ReverseMap();
        CreateMap<TagUpdateDto, Tag>();
    }
}
