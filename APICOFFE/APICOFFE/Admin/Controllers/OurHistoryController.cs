using APICOFFE.Admin.Dtos.OurHistory;
using APICOFFE.Contracts.Identity;
using APICOFFE.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;
[ApiController]
//[Authorize(Roles = RoleNames.ADMIN)]

public class OurHistoryController : ControllerBase
{
    private readonly IOurHistoryService _OurHistoryService;

    public OurHistoryController(IOurHistoryService ourHistoryService)
    {
        _OurHistoryService = ourHistoryService;
    }
    #region Get
    [HttpGet("ourhistory/Get")]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _OurHistoryService.GetAsync());
    }
    #endregion

    #region Update
    [HttpPut("ourhistory/update")]
    public async Task<IActionResult> UpdateAsync([FromForm]OurHistoryUpdateDto dto)
    {
        return Ok(await _OurHistoryService.UpdateAsync(dto));
    }
    #endregion
}
