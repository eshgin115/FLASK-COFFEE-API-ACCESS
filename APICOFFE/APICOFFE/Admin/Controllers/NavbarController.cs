using APICOFFE.Admin.Dtos.Navbar;
using APICOFFE.Database.Models;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Admin.Controllers;

[ApiController]
public class NavbarController : ControllerBase
{
    private readonly INavbarService _navbarService;

    public NavbarController(INavbarService navbarService)
    {
        _navbarService = navbarService;
    }
    #region List
    [HttpGet("navbar/list")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _navbarService.ListAsync());
    }
    #endregion


    #region add

    [HttpPost("navbar/add")]
    public async Task<IActionResult> AddAsync(NavbarCreateDto dto)
    {
        return Created(string.Empty, await _navbarService.AddAsync(dto));

    }
    #endregion

    #region Update

    [HttpPut("navbar/update/{id}")]
    public async Task<IActionResult> UpdateAsync(int id, NavbarUpdateDto dto)
    {
        return Ok(await _navbarService.UpdateAsync(id, dto));
    }
    #endregion
    #region delete
    [HttpDelete("navbar/delete/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _navbarService.DeleteAsync(id);

        return NoContent();
    }
    #endregion
}
