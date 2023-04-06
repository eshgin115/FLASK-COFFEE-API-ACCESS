using APICOFFE.Admin.Dtos.WelcomeSlider;

namespace APICOFFE.Admin.Services.Concretes;

public interface IWelcomeSliderService
{
    Task<WelcomeSliderListItemDto> AddAsync(WelcomeSliderCreateDto dto);
    Task<WelcomeSliderListItemDto> UpdateAsync(int id, WelcomeSliderUpdateDto dto);
    Task<List<WelcomeSliderListItemDto>> ListAsync();
    Task DeleteAsync(int id);
}
