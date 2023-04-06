using APICOFFE.Admin.Dtos.Drink;

namespace APICOFFE.Admin.Services.Concretes;

public interface IDrinkService
{
    Task<DrinkListItemDto> AddAsync(DrinkCreateDto dto);
    Task<DrinkListItemDto> UpdateAsync(int id, DrinkUpdateDto dto);
    Task<List<DrinkListItemDto>> ListAsync();
    Task DeleteAsync(int id);
}
