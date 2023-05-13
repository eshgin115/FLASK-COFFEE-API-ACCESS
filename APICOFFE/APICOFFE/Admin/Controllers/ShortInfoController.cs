using APICOFFE.Admin.Dtos.ShortInfo;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.Identity;
using APICOFFE.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;
[ApiController]
[Route("short-info")]

[Authorize(Roles = RoleNames.ADMIN)]

public class ShortInfoController : ControllerBase
{
    private readonly IShortInfoService _shortInfoService;

    public ShortInfoController(IShortInfoService shortInfoService)
    {
        _shortInfoService = shortInfoService;
    }

    #region Get
    [HttpGet("short-info")]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _shortInfoService.GetAsync());
    }
    #endregion

    #region Update
    [HttpPut("short-info")]
    public async Task<IActionResult> UpdateAsync(ShortInfoUpdateDto dto)
    {
        return Ok(await _shortInfoService.UpdateAsync(dto));
    }
    #endregion
}
