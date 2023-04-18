using APICOFFE.Admin.Dtos.Order;

namespace APICOFFE.Admin.Services.Concretes;

public interface IOrderService
{
    Task<List<OrderListItemDto>> ListAsync();
    Task<OrderListItemDto> UpdateAsync(string id, OrderUpdateDto dto);
    Task DeleteAsync(string id);
}
