using APICOFFE.Client.Dtos.Auth;

namespace APICOFFE.Client.Services.Concretes;

public interface IAuthenticationService
{
    Task RegisterAsync(RegisterDto dto);
    Task ActivateAsync(string token);
}
