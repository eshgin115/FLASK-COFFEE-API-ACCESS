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


    #region update
    [HttpGet("update/{id}", Name = "admin-navbar-update")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id)
    {
        var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == id);


        if (navbar is null) return NotFound();


        return View(_mapper.Map<UpdateViewModel>(navbar));

    }
    [HttpPost("update/{id}", Name = "admin-navbar-update")]
    public async Task<IActionResult> UpdateAsync(UpdateViewModel model)
    {
        var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == model.Id);
        if (navbar is null) return NotFound();



        if (!ModelState.IsValid) return View(model);




        if (!_dataContext.Navbars.Any(n => n.Id == model.Id) && !(model.Order == navbar.Order)) return View(model);

        _mapper.Map(model, navbar);


        await _dataContext.SaveChangesAsync();

        return RedirectToRoute("admin-navbar-list");



    }
    #endregion
    #region delete
    [HttpPost("delete/{id}", Name = "admin-navbar-delete")]
    public async Task<IActionResult> DeleteAsync(UpdateViewModel model)
    {
        var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == model.Id);
        if (navbar is null) return NotFound();


        _dataContext.Navbars.Remove(navbar);
        await _dataContext.SaveChangesAsync();



        return RedirectToRoute("admin-navbar-list");

    }
    #endregion
}
