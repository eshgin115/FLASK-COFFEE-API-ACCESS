using APICOFFE.Client.Dtos.Auth;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Controllers;
[ApiController]
public class AuthenticationController : ControllerBase
{

    private readonly DataContext _dataContext;
    public readonly IUserService _userService;

    public AuthenticationController(IUserService userService, DataContext dataContext)
    {
        _userService = userService;
        _dataContext = dataContext;
    }
    [HttpPost("auth/register")]
    public async Task<IActionResult> RegisterAsync(RegisterDto dto)
    {
        var user = await _dataContext.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);

        if (user is not null) throw new ExistException("Email already exists");
       

        var hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        dto.Password = hash;
        await _userService.CreateAsync(dto);

        return Ok();
    }
    [HttpPost("auth/login")]
    public async Task<IActionResult> LoginAsync([FromForm] LoginDto dto)
    {
        return Ok(await _userService.SignInAsync(dto.Email, dto.Password));
    }
    [HttpGet("activate/{token}", Name = "auth-activate")]
    public async Task<IActionResult> ActivateAsync([FromRoute] string token)
    {
        var userActivation = await _dataContext.UserActivations
            .Include(ua => ua.User)
            .FirstOrDefaultAsync(ua =>
                !ua!.User!.IsEmailConfirmed &&
                ua.ActivationToken == token);

        if (userActivation is null) return NotFound();

        if (DateTime.Now > userActivation!.ExpireDate) return Ok("Token expired olub teessufler");

        userActivation!.User!.IsEmailConfirmed = true;

        await _dataContext.SaveChangesAsync();

        return Ok();
    }

}
