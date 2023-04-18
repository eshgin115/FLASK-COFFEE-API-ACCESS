using APICOFFE.Admin.Dtos.Order;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.Email;
using APICOFFE.Contracts.Identity;
using APICOFFE.Contracts.Order;
using APICOFFE.Exceptions;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Controllers;

[Authorize(Roles = RoleNames.ADMIN)]
[Route("order")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _orderService.ListAsync());
    }
    [HttpPut("order/{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromQuery] OrderUpdateDto dto)
    {
        return Ok(await _orderService.UpdateAsync(id, dto));
    }
    [HttpDelete("order/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _orderService.DeleteAsync(id);
        return NoContent();
    }
}
