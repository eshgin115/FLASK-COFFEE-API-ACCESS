using APICOFFE.Client.Dtos.Basket;
using APICOFFE.Contracts.ModelName;
using APICOFFE.Contracts.Order;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Services.Services;

public class OrderService : IOrderService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly INotificationService _notificationService;
    private const int MIN_RANDOM_NUMBER = 10000;
    private const int MAX_RANDOM_NUMBER = 100000;
    private const string PREFIX = "OR";


    public OrderService
        (DataContext dataContext,
        IUserService userService,
        IMapper mapper,
        INotificationService notificationService)
    {
        _dataContext = dataContext;
        _userService = userService;
        _mapper = mapper;
        _notificationService = notificationService;
    }
    private async Task<Order> AddOrderAsync(decimal SumToal)
    {
        var order = _mapper.Map<Order>((SumToal, GenerateId(), _userService.CurrentUser));

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

        //remove basketProduct
        _dataContext.BasketProducts
            .RemoveRange(_dataContext.BasketProducts
            .Where(bp => bp.Basket.UserId == _userService.CurrentUser.Id));

        await _notificationService.SenOrderCreatedToAdmin(order.Id);

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
                ?? throw new NotFoundException(DomainModelNames.FOOD, food.Id!);

            if (!product.FoodSizes!.Any(fs => fs.SizeId == food.SizId))
                throw new NotFoundException(DomainModelNames.SIZE, food.SizId);
            sumTotalFood += product.Price * food.Quantity;
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
                ?? throw new NotFoundException(DomainModelNames.DRINK, drink.Id!);

            if (!product.DrinkSizes!.Any(fs => fs.SizeId == drink.SizeId))
                throw new NotFoundException(DomainModelNames.SIZE, drink.SizeId);
            sumTotalDrink += product.Price * drink.Quantity;
        }
        return sumTotalDrink;
    }
    private async Task AddOrderProductAsync(List<PlaceOrderDto.FoodListItemDto> foodDtos, Order order)
    {
        foreach (var food in foodDtos)
        {
            var foodPrice = _dataContext.Foods.First(f => f.Id == food.Id).Price;

            await _dataContext.Orderproducts.AddAsync(_mapper.Map<OrderProduct>((order, food, foodPrice)));
        }
    }
    private async Task AddOrderProductAsync(List<PlaceOrderDto.DrinkListItemDto> drinkDtos, Order order)
    {
        foreach (var drink in drinkDtos)
        {
            var drinkPrice = _dataContext.Drinks.First(f => f.Id == drink.Id).Price;

            await _dataContext.Orderproducts.AddAsync(_mapper.Map<OrderProduct>((order, drink, drinkPrice)));
        }
    }
}
