using APICOFFE.Admin.Dtos.DrinkCategory;

namespace APICOFFE.Admin.Services.Concretes;

public interface IDrinkCategoryService
{
    Task<DrinkCategoryListItemDto> AddAsync(DrinkCategoryCreateDto dto);
    Task<DrinkCategoryListItemDto> UpdateAsync(int id, DrinkCategoryUpdateDto dto);
    Task<List<DrinkCategoryListItemDto>> ListAsync();
    Task DeleteAsync(int id);
}
