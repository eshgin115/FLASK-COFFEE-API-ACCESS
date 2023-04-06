using APICOFFE.Admin.Dtos.Tag;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Contracts.Identity;
using APICOFFE.Services.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;
[ApiController]
[Route("tag")]

//[Authorize(Roles = RoleNames.ADMIN)]

public class TagController : ControllerBase
{
    private readonly ITagService _TagService;

    public TagController(ITagService tagService)
    {
        _TagService = tagService;
    }
    #region List
    [HttpGet("tags")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _TagService.ListAsync());
    }
    #endregion

    #region Add
    [HttpPost("tag")]
    public async Task<IActionResult> AddAsync([FromForm] TagCreateDto dto)
    {
        return Created(string.Empty, await _TagService.AddAsync(dto));
    }
    #endregion

    #region Update
    [HttpPut("tag/{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] TagUpdateDto dto)
    {
        return Ok(await _TagService.UpdateAsync(id, dto));
    }
    #endregion

    #region Delete
    [HttpDelete("tag/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _TagService.DeleteAsync(id);

        return NoContent();
    }
    #endregion
}
