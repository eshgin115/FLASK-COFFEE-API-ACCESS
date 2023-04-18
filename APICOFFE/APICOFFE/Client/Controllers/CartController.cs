using APICOFFE.Client.Dtos.Basket;
using APICOFFE.Client.Dtos.Cart;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace APICOFFE.Client.Controllers;

[Route("cart")]
[ApiController]
[Authorize]
public class CartController : ControllerBase
{
    private readonly IOrderService _orderService;
    public CartController
        (IOrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpPost("placer-order")]
    public async Task<IActionResult> PlaceOrderAsync([FromBody] PlaceOrderDto orderDto)
    {
        await _orderService.PlaceOrderAsync(orderDto);
        return Ok();
    }
}
