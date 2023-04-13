using APICOFFE.Admin.Dtos.Food;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;

[ApiController]
[Route("food")]
//[Authorize(Roles = RoleNames.ADMIN)]
public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodController(IFoodService foodService)
    {
        _foodService = foodService;
    }
    #region List
    [HttpGet("foods")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _foodService.ListAsync());
    }

    #endregion

    #region Add

    [HttpPost("food")]
    public async Task<IActionResult> AddAsync([FromForm] FoodCreateDto dto)
    {
        return Created(string.Empty, await _foodService.AddAsync(dto));
    }
    #endregion

    #region Update

    [HttpPut("food/{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromForm] FoodUpdateDto dto)
    {
        return Ok(await _foodService.UpdateAsync(id, dto));
    }
    #endregion

    #region Delete

    [HttpDelete("food/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _foodService.DeleteAsync(id);

        return NoContent();
    }

    #endregion
}
