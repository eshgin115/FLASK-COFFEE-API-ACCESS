using APICOFFE.Admin.Dtos.Drink;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;
[ApiController]
[Route("drink")]

//[Authorize(Roles = RoleNames.ADMIN)]
public class DrinkController : ControllerBase
{
    private readonly IDrinkService _drinkService;

    public DrinkController(IDrinkService drinkService)
    {
        _drinkService = drinkService;
    }

    #region List
    [HttpGet("drinks")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _drinkService.ListAsync());
    }

    #endregion

    #region Add

    [HttpPost("drink")]
    public async Task<IActionResult> AddAsync([FromForm] DrinkCreateDto dto)
    {
        return Created(string.Empty, await _drinkService.AddAsync(dto));
    }
    #endregion

    #region Update

    [HttpPut("drink/{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id,  DrinkUpdateDto dto)
    {
        return Ok(await _drinkService.UpdateAsync(id, dto));
    }
    #endregion

    #region Delete

    [HttpDelete("drink/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _drinkService.DeleteAsync(id);

        return NoContent();
    }

    #endregion
}
