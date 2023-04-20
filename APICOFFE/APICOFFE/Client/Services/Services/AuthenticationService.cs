using APICOFFE.Client.Dtos.Auth;
using APICOFFE.Client.Services.Concretes;
using APICOFFE.Exceptions;
using APICOFFE.Services.Concretes;
using FLASK_COFFEE_API.Database;
using Microsoft.EntityFrameworkCore;

namespace APICOFFE.Client.Services.Services;

public class AuthenticationService: IAuthenticationService
{
    private readonly DataContext _dataContext;
    public readonly IUserService _userService;

    public AuthenticationService(IUserService userService, DataContext dataContext)
    {
        _userService = userService;
        _dataContext = dataContext;
    }
    public async Task RegisterAsync(RegisterDto dto)
    {
        var user = await _dataContext.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);

        if (user is not null) throw new ValidationException("Email already exists");

        var hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        dto.Password = hash;
        await _userService.CreateAsync(dto);
    }

    public async Task ActivateAsync(string token)
    {
        var userActivation = await _dataContext.UserActivations
            .Include(ua => ua.User)
            .FirstOrDefaultAsync(ua => !ua!.User!.IsEmailConfirmed && ua.ActivationToken == token)
            ?? throw new NotFoundException("UserActiovation",token);

        if (DateTime.Now > userActivation!.ExpireDate) throw new ValidationException("Token expired olub teessufler");

        userActivation!.User!.IsEmailConfirmed = true;

        await _dataContext.SaveChangesAsync();

    }
}
