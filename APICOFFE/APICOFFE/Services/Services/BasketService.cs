using APICOFFE.Client.Dtos.Basket;
using APICOFFE.Contracts.File;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Services.Services;

public class BasketService : IBasketService
{
    private readonly DataContext _dataContext;
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public BasketService
        (DataContext dataContext,
        IUserService userService,
        IHttpContextAccessor httpContextAccessor,
        IFileService fileService,
        IMapper mapper)
    {
        _dataContext = dataContext;
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
        _fileService = fileService;
        _mapper = mapper;
    }
    public async Task AddProductAsync(int? DrinkId = null, int? FoodId = null, ModalDto? dto = null)
    {
        if (FoodId != null)
        {
            var product = await _dataContext.Foods
                .Include(p => p.FoodImages)
                .Include(p => p.FoodSizes)!
                .ThenInclude(p => p.Size)
                .FirstOrDefaultAsync(p => p.Id == FoodId)
                ?? throw new NotFoundException("Food", FoodId);

            await UpdateFoodBasketProductAsync(product, dto);

        }
        if (DrinkId != null)
        {
            var product = await _dataContext.Drinks
               .FirstOrDefaultAsync(p => p.Id == DrinkId)
               ?? throw new NotFoundException("Drink", DrinkId);

            var basketProduct = await _dataContext.BasketProducts
                .FirstOrDefaultAsync(bp => bp.Basket!.UserId == _userService.CurrentUser.Id && bp.DrinkId == product.Id);

            await UpdateDrinkBasketProductAsync(product, dto);
        }
        await _dataContext.SaveChangesAsync();
    }
    private async Task UpdateFoodBasketProductAsync(Food food, ModalDto? dto = null)
    {
        //Add product to database if user is authenticated
        var basketProduct = await _dataContext.BasketProducts
            .FirstOrDefaultAsync(bp => bp.Basket!.UserId == _userService.CurrentUser.Id && bp.FoodId == food.Id);

        if (basketProduct is not null)
        {
            basketProduct.QuantityFood++;
        }
        else
        {
            var basket = await _dataContext.Baskets.FirstAsync(b => b.UserId == _userService.CurrentUser.Id);
            basketProduct = _mapper.Map<BasketProduct>((food,basket,dto));
           
            await _dataContext.BasketProducts.AddAsync(basketProduct);
        }
    }
    private async Task UpdateDrinkBasketProductAsync(Drink drink, ModalDto dto = null!)
    {

        var product = await _dataContext.Drinks
            .Include(d => d.DrinkSizes)
           .FirstOrDefaultAsync(p => p.Id == drink.Id)
           ?? throw new NotFoundException("Drink", drink.Id);

        var basketProduct = await _dataContext.BasketProducts
            .FirstOrDefaultAsync(bp => bp.Basket!.UserId == _userService.CurrentUser.Id && bp.DrinkId == product.Id);

        if (basketProduct is not null)
        {
            basketProduct.QuantityDrink++;
        }
        else
        {
            var basket = await _dataContext.Baskets.FirstAsync(b => b.UserId == _userService.CurrentUser.Id);
            basketProduct = _mapper.Map<BasketProduct>((drink, basket, dto));

           
            await _dataContext.BasketProducts.AddAsync(basketProduct);
        }
    }
    public async Task DeleteProductAsync(int? DrinkId = null, int? FoodId = null)
    {
        if (DrinkId is not null)
        {
            var basketProduct = await _dataContext.BasketProducts.FirstOrDefaultAsync(p => p.DrinkId == DrinkId)
                ?? throw new NotFoundException("Drink", DrinkId);
            _dataContext.BasketProducts.Remove(basketProduct);
        }
        else if (FoodId is not null)
        {
            var basketProduct = await _dataContext.BasketProducts.FirstOrDefaultAsync(p => p.FoodId == FoodId)
                ?? throw new NotFoundException("Food", FoodId);

            _dataContext.BasketProducts.Remove(basketProduct);

        }

        await _dataContext.SaveChangesAsync();
    }

    public async Task<BasketListItemDto> GetBasketListItemDtoAsync()
    {
        var basketFoods = await _dataContext.BasketProducts
                                       .Where(bp => bp.Basket!.UserId == _userService.CurrentUser.Id)
                                       .Where(bp => bp.Food != null)
                                       .Include(bp => bp.Food)
                                       .ThenInclude(fi => fi!.FoodImages)
                                       .Include(bp => bp.Food)
                                       .ThenInclude(fs => fs!.FoodSizes)!
                                       .ThenInclude(bp => bp.Size)
                                       .Include(bp => bp.Drink)
                                       .ToListAsync();
        var basketDrinks = await _dataContext.BasketProducts
            .Where(bp => bp.Drink != null)
            .Include(bp => bp.Drink)
            .ThenInclude(fs => fs!.DrinkSizes)!
            .ThenInclude(bp => bp.Size)
            .Where(bp => bp.Basket!.UserId == _userService.CurrentUser.Id)
            .ToListAsync();
        var subTotal =
            await _dataContext.BasketProducts.SumAsync(bp => bp.Drink != null ? bp.Drink.Price : bp.Food!.Price);

        var basketDto = _mapper.Map<BasketListItemDto>((basketFoods, basketDrinks, subTotal));

        if (basketDto.FoodListItemDtos is not null)
            basketDto.FoodListItemDtos.ForEach(f => f.ImageUrl = f.ImageUrl != null
            ? _fileService.GetFileUrl(f.ImageUrl, UploadDirectory.FOOD_IMAGE)
            : null);
        if (basketDto.DrinkListItemDtos is not null)
            basketDto.DrinkListItemDtos.ForEach(f => f.ImageUrl = f.ImageUrl != null
            ? _fileService.GetFileUrl(f.ImageUrl, UploadDirectory.DRINK_IMAGE)
            : null);
        return basketDto;
    }
}
