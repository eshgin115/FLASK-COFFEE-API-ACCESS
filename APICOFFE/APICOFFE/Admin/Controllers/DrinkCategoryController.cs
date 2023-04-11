using APICOFFE.Admin.Dtos.DrinkCategory;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.Identity;
using APICOFFE.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;
[ApiController]
[Route("drink-category")]

[Authorize(Roles = RoleNames.ADMIN)]

public class DrinkCategoryController : ControllerBase
{
    private readonly IDrinkCategoryService _drinkCategoryService;

    public DrinkCategoryController(IDrinkCategoryService drinkCategoryService)
    {
        _drinkCategoryService = drinkCategoryService;
    }

    #region List
    [HttpGet("drink-categories")]
    public async Task<IActionResult> ListAsync()
    {

        return Ok(await _drinkCategoryService.ListAsync());
    }

    #endregion

    #region Add

    [HttpPost("drink-category")]
    public async Task<IActionResult> AddAsync([FromForm] DrinkCategoryCreateDto dto)
    {
        return Created(string.Empty, await _drinkCategoryService.AddAsync(dto));
    }
    #endregion

    #region Update

    [HttpPut("drink-category/{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromForm] DrinkCategoryUpdateDto dto)
    {
        return Ok(await _drinkCategoryService.UpdateAsync(id, dto));
    }
    #endregion

    #region Delete

    [HttpDelete("drink-category/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _drinkCategoryService.DeleteAsync(id);

        return NoContent();
    }

    #endregion
}
