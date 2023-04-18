using APICOFFE.Client.Dtos.Basket;
using APICOFFE.Contracts.Order;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Services.Services;

public class OrderService : IOrderService
{
    private readonly DataContext _dataContext;
    private readonly IUserService _userService;
    private const int MIN_RANDOM_NUMBER = 10000;
    private const int MAX_RANDOM_NUMBER = 100000;
    private const string PREFIX = "OR";


    public OrderService(DataContext dataContext, IUserService userService)
    {
        _dataContext = dataContext;
        _userService = userService;
    }
    private async Task<Order> AddOrderAsync(decimal SumToal)
    {
        var order = new Order
        {
            Id = GenerateId(),
            SumTotalPrice = SumToal,
            Status = Status.Created,
            UserId = _userService.CurrentUser.Id,
        };
        await _dataContext.Orders.AddAsync(order);
        return order;
    }
    private string GenerateNumber()
    {
        Random random = new Random();
        return random.Next(MIN_RANDOM_NUMBER, MAX_RANDOM_NUMBER).ToString();
    }

    private string GenerateId()
    {
        string Id = string.Empty;
        do
        {
            Id = $"{PREFIX}{GenerateNumber()}";

        } while (_dataContext.Orders.Any(o => o.Id == Id));

        return Id;
    }
    public async Task PlaceOrderAsync(PlaceOrderDto orderDto)
    {

        var sumTotalFood = await FoodExistAsync(orderDto);

        var sumTotalDrink = await DrinkExistAsync(orderDto);

        var order = await AddOrderAsync(sumTotalFood + sumTotalDrink);

        await AddOrderProductAsync(orderDto.FoodListItemDtos, order);

        await AddOrderProductAsync(orderDto.DrinkListItemDtos, order);

        await _dataContext.SaveChangesAsync();
    }
    private async Task<decimal> FoodExistAsync(PlaceOrderDto orderDto)
    {
        decimal sumTotalFood = 0;
        foreach (var food in orderDto.FoodListItemDtos)
        {
            var product = await _dataContext.Foods
                .Include(p => p.FoodImages)!
                .Include(p => p.FoodSizes)!
                .ThenInclude(p => p.Size)
                .FirstOrDefaultAsync(p => p.Id == food.Id)
                ?? throw new NotFoundException("Food", food.Id!);

            if (!product.FoodSizes!.Any(fs => fs.SizeId == food.SizId))
                throw new NotFoundException("Size", food.SizId);
            sumTotalFood += product.Price;
        }
        return sumTotalFood;
    }
    private async Task<decimal> DrinkExistAsync(PlaceOrderDto orderDto)
    {
        decimal sumTotalDrink = 0;
        foreach (var drink in orderDto.DrinkListItemDtos)
        {
            var product = await _dataContext.Drinks
                .Include(p => p.DrinkSizes)!
                .ThenInclude(p => p.Size)
                .FirstOrDefaultAsync(p => p.Id == drink.Id)
                ?? throw new NotFoundException("Drink", drink.Id!);

            if (!product.DrinkSizes!.Any(fs => fs.SizeId == drink.SizeId))
                throw new NotFoundException("Size", drink.SizeId);
            sumTotalDrink += product.Price;
        }
        return sumTotalDrink;
    }
    private async Task AddOrderProductAsync(List<PlaceOrderDto.FoodListItemDto> foodDtos, Order order)
    {
        foreach (var food in foodDtos)
        {
            var orderProduct = new OrderProduct
            {
                OrderId = order.Id,
                FoodId = food.Id,
                QuantityFood = food.Quantity,
                Price = _dataContext.Foods.First(f => f.Id == food.Id).Price,
                SizeId = food.SizId
            };
            await _dataContext.Orderproducts.AddAsync(orderProduct);
        }
    }
    private async Task AddOrderProductAsync(List<PlaceOrderDto.DrinkListItemDto> drinkDtos, Order order)
    {
        foreach (var drink in drinkDtos)
        {
            var orderProduct = new OrderProduct
            {

                OrderId = order.Id,
                DrinkId = drink.Id,
                QuantityDrink = drink.Quantity,
                SizeId = drink.SizeId,
                Price = _dataContext.Drinks.First(f => f.Id == drink.Id).Price,
            };
            await _dataContext.Orderproducts.AddAsync(orderProduct);
        }
    }
}
