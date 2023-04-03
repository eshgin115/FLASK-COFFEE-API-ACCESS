using APICOFFE.Admin.Dtos.ShortInfo;
using APICOFFE.Services.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;
[ApiController]
public class ShortInfoController : ControllerBase
{
    private readonly IShortInfoService _shortInfoService;

    public ShortInfoController(IShortInfoService shortInfoService)
    {
        _shortInfoService = shortInfoService;
    }

    [HttpGet("shortInfo/Get")]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _shortInfoService.GetAsync());
    }
    [HttpPut("shortInfo/update")]
    public async Task<IActionResult> UpdateAsync(ShortInfoUpdateDto dto)
    {
        return Ok(await _shortInfoService.UpdateAsync(dto));
    }
}
