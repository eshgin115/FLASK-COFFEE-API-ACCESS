using APICOFFE.Admin.Dtos.FoodCategory;

namespace APICOFFE.Admin.Services.Concretes;

public interface IFoodCategoryService
{
    Task<FoodCategoryListItemDto> AddAsync(FoodCategoryCreateDto dto);
    Task<FoodCategoryListItemDto> UpdateAsync(int id, FoodCategoryUpdateDto dto);
    Task<List<FoodCategoryListItemDto>> ListAsync();
    Task DeleteAsync(int id);
}
