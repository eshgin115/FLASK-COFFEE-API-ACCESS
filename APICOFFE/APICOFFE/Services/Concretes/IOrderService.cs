using APICOFFE.Client.Dtos.Basket;
using APICOFFE.Database.Models;

namespace APICOFFE.Services.Concretes;

public interface IOrderService
{
    Task PlaceOrderAsync(PlaceOrderDto orderDto);
}
