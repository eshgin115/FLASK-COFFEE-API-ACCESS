using APICOFFE.Admin.Dtos.Subnavbar;

namespace APICOFFE.Admin.Services.Concretes;

public interface ISubnavbarService
{
    Task<List<SubnavbarListItemDto>> ListAsync();
    Task<SubnavbarListItemDto> AddAsync(SubnavbarCreateDto dto);
    Task<SubnavbarListItemDto> UpdateAsync(int id, SubnavbarUpdateDto dto);
    Task DeleteAsync(int id);
}
