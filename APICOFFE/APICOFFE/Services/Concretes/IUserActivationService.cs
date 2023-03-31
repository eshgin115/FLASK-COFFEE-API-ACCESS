using APICOFFE.Database.Models;

namespace APICOFFE.Services.Concretes;

public interface IUserActivationService
{
    Task SendActivationUrlAsync(User user);
}