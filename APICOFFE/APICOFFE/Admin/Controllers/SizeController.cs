﻿using APICOFFE.Admin.Dtos.Size;
using APICOFFE.Services.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Admin.Controllers;
[ApiController]
public class SizeController : ControllerBase
{
    private readonly ISizeService _SizeService;

    public SizeController(ISizeService sizeService)
    {
        _SizeService = sizeService;
    }
    #region List
    [HttpGet("Size/list")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _SizeService.ListAsync());
    }
    #endregion

    #region Add
    [HttpPost("Size/add")]
    public async Task<IActionResult> AddAsync([FromForm] SizeCreateDto dto)
    {
        return Created(string.Empty, await _SizeService.AddAsync(dto));
    }
    #endregion

    #region Update
    [HttpPut("Size/update/{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromForm] SizeUpdateDto dto)
    {
        return Ok(await _SizeService.UpdateAsync(id, dto));
    }
    #endregion

    #region Delete
    [HttpDelete("Size/delete/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _SizeService.DeleteAsync(id);

        return NoContent();
    }
    #endregion
}