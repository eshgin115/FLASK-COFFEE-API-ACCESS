using APICOFFE.Admin.Dtos.WelcomeSlider;
using APICOFFE.Services.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;
[ApiController]
public class WelcomeSliderController : ControllerBase
{
    private readonly IWelcomeSliderService _welcomeSliderService;

    public WelcomeSliderController(IWelcomeSliderService welcomeSliderService)
    {
        _welcomeSliderService = welcomeSliderService;
    }
    #region List
    [HttpGet("welcomeSlider/list")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _welcomeSliderService.ListAsync());
    }
    #endregion

    #region Add
    [HttpPost("welcomeSlider/add")]
    public async Task<IActionResult> AddAsync([FromForm] WelcomeSliderCreateDto dto)
    {
        return Created(string.Empty, await _welcomeSliderService.AddAsync(dto));
    }
    #endregion

    #region Update
    [HttpPut("welcomeSlider/update/{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] WelcomeSliderUpdateDto dto)
    {
        return Ok(await _welcomeSliderService.UpdateAsync(id, dto));
    }
    #endregion

    #region Delete
    [HttpDelete("welcomeSlider/delete/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _welcomeSliderService.DeleteAsync(id);

        return NoContent();
    }
    #endregion
}
