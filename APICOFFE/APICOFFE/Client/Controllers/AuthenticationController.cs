using APICOFFE.Client.Dtos.Auth;
using APICOFFE.Client.Services.Concretes;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using FLASK_COFFEE_API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Controllers;
[ApiController]
public class AuthenticationController : ControllerBase
{
    public readonly IAuthenticationService _authenticationService;
    public readonly IUserService _userService;

    public AuthenticationController(IAuthenticationService authenticationService, IUserService userService)
    {
        _authenticationService = authenticationService;
        _userService = userService;
    }

    [HttpPost("auth/register")]
    public async Task<IActionResult> RegisterAsync(RegisterDto dto)
    {
        await _authenticationService.RegisterAsync(dto);

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
        await _authenticationService.ActivateAsync(token);

        return Ok();
    }

}
