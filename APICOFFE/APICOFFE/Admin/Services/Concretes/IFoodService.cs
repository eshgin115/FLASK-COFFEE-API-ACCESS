using APICOFFE.Admin.Dtos.Food;

namespace APICOFFE.Admin.Services.Concretes;

public interface IFoodService
{
    Task<FoodListItemDto> AddAsync(FoodCreateDto dto);
    Task<FoodListItemDto> UpdateAsync(int id, FoodUpdateDto dto);
    Task<List<FoodListItemDto>> ListAsync();
    Task DeleteAsync(int id);
}
