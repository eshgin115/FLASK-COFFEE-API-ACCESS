using APICOFFE.Client.Dtos.Product;
using APICOFFE.Database.Models;

namespace APICOFFE.Services.Concretes;

public interface IBasketService
{
    Task AddProductAsync(int? DrinkId = null, int? FoodId = null, ModalDto dto = null!);
}
