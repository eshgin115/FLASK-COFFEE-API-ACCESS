using APICOFFE.Admin.Dtos.Navbar;

namespace APICOFFE.Services.Concretes
{
    public interface INavbarService
    {
        Task<List<NavbarListItemDto>> ListAsync();
        Task<NavbarListItemDto> AddAsync(NavbarCreateDto dto);
        Task<NavbarListItemDto> UpdateAsync(int id, NavbarUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
