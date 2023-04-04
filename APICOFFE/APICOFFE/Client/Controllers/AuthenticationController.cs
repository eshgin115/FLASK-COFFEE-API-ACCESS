using APICOFFE.Client.Dtos.Auth;
using APICOFFE.Services.Concretes;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Mvc;

namespace APICOFFE.Client.Controllers;
[ApiController]
public class AuthenticationController : ControllerBase
{
    public readonly IUserService _userService;
    public AuthenticationController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("auth/register")]
    public async Task<IActionResult> RegisterAsync(RegisterDto dto)
    {
        await _userService.CreateAsync(dto);
        return Ok();
    }
    [HttpPost("auth/login")]
    public async Task<IActionResult> LoginAsync(LoginDto dto)
    {
        return Ok(await _userService.SignInAsync(dto.Email, dto.Password));
    }

}
