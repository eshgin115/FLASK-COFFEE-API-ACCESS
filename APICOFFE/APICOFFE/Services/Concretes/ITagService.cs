using APICOFFE.Admin.Dtos.Tag;

namespace APICOFFE.Services.Concretes;

public interface ITagService
{
    Task<TagListItemDto> AddAsync(TagCreateDto dto);
    Task<TagListItemDto> UpdateAsync(int id, TagUpdateDto dto);
    Task<List<TagListItemDto>> ListAsync();
    Task DeleteAsync(int id);
}
