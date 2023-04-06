using APICOFFE.Admin.Dtos.Size;

namespace APICOFFE.Admin.Services.Concretes;

public interface ISizeService
{
    Task<SizeListItemDto> AddAsync(SizeCreateDto dto);
    Task<SizeListItemDto> UpdateAsync(int id, SizeUpdateDto dto);
    Task<List<SizeListItemDto>> ListAsync();
    Task DeleteAsync(int id);
}
