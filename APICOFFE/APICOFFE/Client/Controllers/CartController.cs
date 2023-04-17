using APICOFFE.Client.Dtos.Cart;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Controllers;

[Route("cart")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IFileService _fileService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public CartController
        (DataContext dataContext,
        IFileService fileService,
        IUserService userService,
        IMapper mapper)
    {
        _dataContext = dataContext;
        _fileService = fileService;
        _userService = userService;
        _mapper = mapper;
    }
    [HttpGet("cart")]
    public async Task<IActionResult> Index()
    {
        var basketFoods = await _dataContext.BasketProducts
                                        .Where(bp => bp.Basket.UserId == _userService.CurrentUser.Id)
                                        .Where(bp => bp.Food != null)!
                                        .Include(bp => bp.Food)!
                                        .ThenInclude(fi => fi.FoodImages)!
                                        .Include(bp => bp.Food)!
                                        .ThenInclude(fs => fs.FoodSizes)!
                                        .ThenInclude(bp => bp.Size)
                                        .Include(bp => bp.Drink)
                                        .ToListAsync();


        var basketDrinks = await _dataContext.BasketProducts
            .Where(bp => bp.Drink != null)
            .Where(bp => bp.Basket!.UserId == _userService.CurrentUser.Id)
            .ToListAsync();
        var basketDto = _mapper.Map<CartListItemDto>((basketFoods, basketDrinks));

        //if (basketModel.FoodListViewModels is not null)
        //    basketModel.FoodListViewModels.ForEach(f => f.ImageUrl = f.ImageUrl != null
        //    ? _fileService.GetFileUrl(f.ImageUrl, UploadDirectory.FoodImage)
        //    : null);
        //if (basketModel.DrinkListViewModels is not null)
        //    basketModel.DrinkListViewModels.ForEach(f => f.ImageUrl = f.ImageUrl != null
        //    ? _fileService.GetFileUrl(f.ImageUrl, UploadDirectory.DrinkImage)
        //    : null);

        return Ok();
    }
}
