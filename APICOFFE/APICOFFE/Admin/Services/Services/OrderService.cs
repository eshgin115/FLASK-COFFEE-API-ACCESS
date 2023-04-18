using APICOFFE.Admin.Dtos.Order;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.Email;
using APICOFFE.Contracts.Order;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Services.Services;

public class OrderService : Concretes.IOrderService
{
    private readonly DataContext _dbContext;
    public IEmailService _emailService { get; set; }
    private readonly IMapper _mapper;

    public OrderService(DataContext dbContext, IEmailService emailService, IMapper mapper)
    {
        _dbContext = dbContext;
        _emailService = emailService;
        _mapper = mapper;
    }
   
    public async Task<List<OrderListItemDto>> ListAsync()
    {
        var orders = await _dbContext.Orders.ToListAsync();

        return _mapper.Map<List<OrderListItemDto>>(orders);
    }
    public async Task<OrderListItemDto> UpdateAsync(string id, OrderUpdateDto dto)
    {
        var order = await _dbContext.Orders.Include(o => o.User)
          .FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException("Order", id);


        order!.Status = dto.Statuse;

        var stausMessageDto = PrepareStausMessage(order.User!.Email!);

        _emailService.Send(stausMessageDto);

        await _dbContext.SaveChangesAsync();
        
        return _mapper.Map<OrderListItemDto>(order);

        MessageDto PrepareStausMessage(string email)
        {
            string body = StatusCodeExtensions.GetNotification(order.Status, order.User.FirstName!, order.User.LastName!, order.Id);

            string subject = EmailMessages.Subject.ORDER_MESSAGE;

            return new MessageDto(email, subject, body);
        }
    }
    public async Task DeleteAsync(string id)
    {
        var order = await _dbContext.Orders
            .Include(o => o.OrderProducts)
            .FirstOrDefaultAsync(o => o.Id == id)
            ?? throw new NotFoundException("Order", id);

        _dbContext.Orders.Remove(order);

        await _dbContext.SaveChangesAsync();

    }
}
