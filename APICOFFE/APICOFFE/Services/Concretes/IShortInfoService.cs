using APICOFFE.Admin.Dtos.ShortInfo;

namespace APICOFFE.Services.Concretes;

public interface IShortInfoService
{
    Task<ShortInfoListItemDto> GetAsync();
    Task<ShortInfoListItemDto> UpdateAsync( ShortInfoUpdateDto dto);
}
