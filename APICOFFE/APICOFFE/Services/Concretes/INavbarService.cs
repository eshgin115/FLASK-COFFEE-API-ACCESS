using APICOFFE.Admin.Dtos.Navbar;

namespace APICOFFE.Services.Concretes
{
    public interface INavbarService
    {
        Task<NavbarListItemDto> AddAsync(NavbarCreateDto dto);
        Task<NavbarListItemDto> UpdateAsync(int id, NavbarUpdateDto dto);
        Task<List<NavbarListItemDto>> ListAsync();
        Task DeleteAsync(int id);
    }
}
