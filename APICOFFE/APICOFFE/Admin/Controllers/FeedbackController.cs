using APICOFFE.Admin.Dtos.FeedBack;
using APICOFFE.Contracts.File;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Controllers;

[ApiController]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackService _feedbackService;
    public FeedbackController(IFeedbackService feedbackService)
    {
        _feedbackService = feedbackService;
    }

    #region List
    [HttpGet("feedback/list")]
    public async Task<IActionResult> ListAsync()
    {

        return Ok(await _feedbackService.ListAsync());
    }

    #endregion

    #region Add

    [HttpPost("feedback/add")]
    public async Task<IActionResult> AddAsync([FromForm] FeedBackCreateDto dto)
    {
        return Created(string.Empty, await _feedbackService.AddAsync(dto));
    }
    #endregion

    #region Update

    [HttpPut("feedback/update/{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromForm] FeedBackUpdateRequestDto dto)
    {
        return Ok(await _feedbackService.UpdateAsync(id,dto));
    }
    #endregion

    #region Delete

    [HttpDelete("feedback/delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
        await _feedbackService.DeleteAsync(id);

        return NoContent();
    }

    #endregion
}
