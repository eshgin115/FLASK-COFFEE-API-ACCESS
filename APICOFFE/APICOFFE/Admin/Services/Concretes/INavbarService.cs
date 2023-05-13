using APICOFFE.Admin.Dtos.Navbar;

namespace APICOFFE.Admin.Services.Concretes;

public interface INavbarService
{
    IEnumerable<string> GetUrlsForGetMethods();
    Task<List<NavbarListItemDto>> ListAsync();
    Task<NavbarListItemDto> AddAsync(NavbarCreateDto dto);
    Task<NavbarListItemDto> UpdateAsync(int id, NavbarUpdateDto dto);
    Task DeleteAsync(int id);
}
