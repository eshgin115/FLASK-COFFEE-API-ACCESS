using APICOFFE.Admin.Dtos.FoodCategory;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;
[ApiController]
[Route("food-category")]

//[Authorize(Roles = RoleNames.ADMIN)]
public class FoodCategoryController : ControllerBase
{
  private readonly IFoodCategoryService _foodCategoryService;

    public FoodCategoryController(IFoodCategoryService foodCategoryService)
    {
        _foodCategoryService = foodCategoryService;
    }

    #region List
    [HttpGet("food-categories")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _foodCategoryService.ListAsync());
    }

    #endregion

    #region Add

    [HttpPost("food-category")]
    public async Task<IActionResult> AddAsync([FromForm] FoodCategoryCreateDto dto)
    {
        return Created(string.Empty, await _foodCategoryService.AddAsync(dto));
    }
    #endregion

    #region Update

    [HttpPut("food-category/{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromForm] FoodCategoryUpdateDto dto)
    {
        return Ok(await _foodCategoryService.UpdateAsync(id, dto));
    }
    #endregion

    #region Delete

    [HttpDelete("food-category/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _foodCategoryService.DeleteAsync(id);

        return NoContent();
    }

    #endregion
}
