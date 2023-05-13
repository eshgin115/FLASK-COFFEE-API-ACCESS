using APICOFFE.Admin.Dtos.FeedBack;
using APICOFFE.Admin.Services.Concretes;
using APICOFFE.Admin.Services.Services;
using APICOFFE.Contracts.File;
using APICOFFE.Contracts.Identity;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Controllers;

[ApiController]
[Route("feedback")]

[Authorize(Roles = RoleNames.ADMIN)]

public class FeedbackController : ControllerBase
{
    private readonly IFeedbackSevice _feedbackService;
    public FeedbackController(IFeedbackSevice feedbackService)
    {
        _feedbackService = feedbackService;
    }

    #region List
    [HttpGet("feedbacks")]
    public async Task<IActionResult> ListAsync()
    {

        return Ok(await _feedbackService.ListAsync());
    }

    #endregion

    #region Add

    [HttpPost("feedback")]
    public async Task<IActionResult> AddAsync([FromForm] FeedBackCreateDto dto)
    {
        return Created(string.Empty, await _feedbackService.AddAsync(dto));
    }
    #endregion

    #region Update

    [HttpPut("feedback/{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromForm] FeedBackUpdateRequestDto dto)
    {
        return Ok(await _feedbackService.UpdateAsync(id,dto));
    }
    #endregion

    #region Delete

    [HttpDelete("feedback/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _feedbackService.DeleteAsync(id);

        return NoContent();
    }

    #endregion
}
