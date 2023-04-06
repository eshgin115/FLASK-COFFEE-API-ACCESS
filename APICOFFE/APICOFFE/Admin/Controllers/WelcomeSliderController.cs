using APICOFFE.Admin.Dtos.WelcomeSlider;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.Identity;
using APICOFFE.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;
[ApiController]
[Route("welcome-slider")]
//[Authorize(Roles = RoleNames.ADMIN)]

public class WelcomeSliderController : ControllerBase
{
    private readonly IWelcomeSliderService _welcomeSliderService;

    public WelcomeSliderController(IWelcomeSliderService welcomeSliderService)
    {
        _welcomeSliderService = welcomeSliderService;
    }
    #region List
    [HttpGet("welcome-slideries")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _welcomeSliderService.ListAsync());
    }
    #endregion

    #region Add
    [HttpPost("welcome-slider")]
    public async Task<IActionResult> AddAsync([FromForm] WelcomeSliderCreateDto dto)
    {
        return Created(string.Empty, await _welcomeSliderService.AddAsync(dto));
    }
    #endregion

    #region Update
    [HttpPut("welcome-slider/{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] WelcomeSliderUpdateDto dto)
    {
        return Ok(await _welcomeSliderService.UpdateAsync(id, dto));
    }
    #endregion

    #region Delete
    [HttpDelete("welcome-slider/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _welcomeSliderService.DeleteAsync(id);

        return NoContent();
    }
    #endregion
}
