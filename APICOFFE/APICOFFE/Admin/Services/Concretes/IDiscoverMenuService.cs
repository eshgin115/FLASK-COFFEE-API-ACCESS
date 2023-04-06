using APICOFFE.Admin.Dtos.DiscoverMenu;

namespace APICOFFE.Admin.Services.Concretes;

public interface IDiscoverMenuService
{
    Task<DiscoverMenuUpdateResponseDto> UpdateAsync(DiscoverMenuUpdateRequsetDto dto);
    Task<DiscoverMenuUpdateResponseDto> GetAsync();
}
