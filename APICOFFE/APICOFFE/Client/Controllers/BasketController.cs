using APICOFFE.Client.Dtos.Product;
using APICOFFE.Services.Concretes;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Client.Controllers;
[ApiController]
[Route("basket")]
[Authorize]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketController
        (IBasketService basketService)
    {
        _basketService = basketService;
    }
    [HttpPost("product")]
    public async Task<IActionResult> AddAsync(int? DrinkId = null, int? FoodId = null, ModalDto dto = null!)
    {
        await _basketService.AddProductAsync(DrinkId, FoodId, dto);
        return Ok();
    }
}
