using APICOFFE.Admin.Dtos.Size;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.Identity;
using APICOFFE.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;
[ApiController]
[Route("size")]

[Authorize(Roles = RoleNames.ADMIN)]

public class SizeController : ControllerBase
{
    private readonly ISizeService _SizeService;

    public SizeController(ISizeService sizeService)
    {
        _SizeService = sizeService;
    }
    #region List
    [HttpGet("sizes")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _SizeService.ListAsync());
    }
    #endregion

    #region Add
    [HttpPost("size")]
    public async Task<IActionResult> AddAsync([FromForm] SizeCreateDto dto)
    {
        return Created(string.Empty, await _SizeService.AddAsync(dto));
    }
    #endregion

    #region Update
    [HttpPut("size/{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] SizeUpdateDto dto)
    {
        return Ok(await _SizeService.UpdateAsync(id, dto));
    }
    #endregion

    #region Delete
    [HttpDelete("Size/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _SizeService.DeleteAsync(id);

        return NoContent();
    }
    #endregion
}
