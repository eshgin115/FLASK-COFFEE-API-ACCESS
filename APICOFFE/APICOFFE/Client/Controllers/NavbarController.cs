using APICOFFE.Client.Dtos.Navbar;
using APICOFFE.Services.Concretes;
using AutoMapper;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Controllers;
[ApiController]
public class NavbarController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;


    public NavbarController(DataContext dataContext, IMapper mapper, IUserService userService)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _userService = userService;
    }
    [HttpGet("client/navbar/list")]

    public async Task<IActionResult> ListAsync()
    {
        var navbars = await _dataContext.Navbars.Include(n => n.Subnavbars!.OrderBy(s => s.Order))
                .Where(n => n.IsViewOnHeader).OrderBy(n => n.Order).ToListAsync();

        var navbarsDto = _mapper.Map<List<NavbarListItemDto>>(navbars);

        return Ok(navbarsDto);
    }
}
