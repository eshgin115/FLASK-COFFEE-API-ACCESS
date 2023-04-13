using APICOFFE.Client.Dtos.Product;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Services.Services;

public class BasketService : IBasketService
{
    private readonly DataContext _dataContext;
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IFileService _fileService;

    public BasketService
        (DataContext dataContext,
        IUserService userService,
        IHttpContextAccessor httpContextAccessor,
        IFileService fileService)
    {
        _dataContext = dataContext;
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
        _fileService = fileService;
    }
    public async Task AddProductAsync(int? DrinkId = null, int? FoodId = null, ModalDto dto = null!)
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

            await _dataContext.SaveChangesAsync();
        }
        if (DrinkId != null)
        {
            var product = await _dataContext.Drinks
               .FirstOrDefaultAsync(p => p.Id == DrinkId)
               ?? throw new NotFoundException("Drink", DrinkId);

            var basketProduct = await _dataContext.BasketProducts
                .FirstOrDefaultAsync(bp => bp.Basket!.UserId == _userService.CurrentUser.Id && bp.DrinkId == product.Id);

            await UpdateDrinkBasketProductAsync(product, dto);

            await _dataContext.SaveChangesAsync();

        }
    }
    private async Task UpdateFoodBasketProductAsync(Food food, ModalDto dto = null!)
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
            basketProduct = new BasketProduct
            {
                //Quantity = model.Quantity != null ? model.Quantity : 1,
                BasketId = basket.Id,

                FoodId = food.Id,

                Basket = basket,

                QuantityFood = dto != null ? dto.QuantityFood : 1,

                SizeId = dto != null ? dto.SizeId : food.FoodSizes.FirstOrDefault().SizeId != null
                ? food.FoodSizes.FirstOrDefault()!.SizeId : null

                //ColorId = model.ColorId != null ? model.ColorId : null,
            };

            await _dataContext.BasketProducts.AddAsync(basketProduct);
        }
    }


    private async Task UpdateDrinkBasketProductAsync(Drink drink, ModalDto dto = null!)
    {

        var product = await _dataContext.Drinks
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
            basketProduct = new BasketProduct
            {
                QuantityDrink = dto != null ? dto.QuantityDrink : 1,
                BasketId = basket.Id,
                DrinkId = product.Id,
                Drink = product,
                Basket = basket,
                //ColorId = model.ColorId != null ? model.ColorId : null,
            };
            await _dataContext.BasketProducts.AddAsync(basketProduct);
        }

    }
}
