using APICOFFE.Client.Dtos.Basket;
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
    [HttpGet("products")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _basketService.GetBasketListItemDtoAsync());
    }
    [HttpPost("product")]
    public async Task<IActionResult> AddAsync(int? DrinkId = null, int? FoodId = null, [FromForm] ModalDto dto = null)
    {
        await _basketService.AddProductAsync(DrinkId, FoodId, dto);

        return Ok();
    }
    [HttpDelete("product")]
    public async Task<IActionResult> DeleteProductAsync([FromQuery] int? DrinkId = null, [FromQuery] int? FoodId = null)
    {
        await _basketService.DeleteProductAsync(DrinkId, FoodId);

        return NoContent();
    }
}
