using APICOFFE.Client.Dtos.Basket;
using APICOFFE.Database.Models;

namespace APICOFFE.Services.Concretes;

public interface IBasketService
{
    Task AddProductAsync(int? DrinkId = null, int? FoodId = null, ModalDto dto = null!);
    Task DeleteProductAsync(int? DrinkId = null, int? FoodId = null);
    Task<BasketListItemDto> GetBasketListItemDtoAsync();
}
